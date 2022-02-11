using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using PEGASUS.Tools.NetSerializer.TypeSerializers;

namespace PEGASUS.Tools.NetSerializer
{
public class Serializer
{
	private delegate void SerializerSwitch(Serializer serializer, Stream stream, object ob);

	private delegate void DeserializerSwitch(Serializer serializer, Stream stream, out object ob);

	private Dictionary<Type, ushort> m_typeIDMap;

	private SerializerSwitch m_serializerSwitch;

	private DeserializerSwitch m_deserializerSwitch;

	private static ITypeSerializer[] s_typeSerializers = new ITypeSerializer[6]
	{
		new ObjectSerializer(),
		new PrimitivesSerializer(),
		new ArraySerializer(),
		new EnumSerializer(),
		new DictionarySerializer(),
		new GenericSerializer()
	};

	private ITypeSerializer[] m_userTypeSerializers;

	public Serializer(IEnumerable<Type> rootTypes)
		: this(rootTypes, new ITypeSerializer[0])
	{
	}

	public Serializer(IEnumerable<Type> rootTypes, ITypeSerializer[] userTypeSerializers)
	{
		if (!userTypeSerializers.All((ITypeSerializer s) => s is IDynamicTypeSerializer || s is IStaticTypeSerializer))
		{
			throw new ArgumentException("TypeSerializers have to implement IDynamicTypeSerializer or  IStaticTypeSerializer");
		}
		m_userTypeSerializers = userTypeSerializers;
		Dictionary<Type, TypeData> dictionary = GenerateTypeData(rootTypes);
		GenerateDynamic(dictionary);
		m_typeIDMap = dictionary.ToDictionary((KeyValuePair<Type, TypeData> kvp) => kvp.Key, (KeyValuePair<Type, TypeData> kvp) => kvp.Value.TypeID);
	}

	public void Serialize(Stream stream, object data)
	{
		m_serializerSwitch(this, stream, data);
	}

	public object Deserialize(Stream stream)
	{
		m_deserializerSwitch(this, stream, out var ob);
		return ob;
	}

	private Dictionary<Type, TypeData> GenerateTypeData(IEnumerable<Type> rootTypes)
	{
		Dictionary<Type, TypeData> dictionary = new Dictionary<Type, TypeData>();
		Stack<Type> stack = new Stack<Type>(PrimitivesSerializer.GetSupportedTypes().Concat(rootTypes));
		stack.Push(typeof(object));
		ushort num = 1;
		while (stack.Count > 0)
		{
			Type type = stack.Pop();
			if (dictionary.ContainsKey(type) || type.IsAbstract || type.IsInterface)
			{
				continue;
			}
			if (type.ContainsGenericParameters)
			{
				throw new NotSupportedException($"Type {type.FullName} contains generic parameters");
			}
			ITypeSerializer typeSerializer = m_userTypeSerializers.FirstOrDefault((ITypeSerializer h) => h.Handles(type));
			if (typeSerializer == null)
			{
				typeSerializer = s_typeSerializers.FirstOrDefault((ITypeSerializer h) => h.Handles(type));
			}
			if (typeSerializer == null)
			{
				throw new NotSupportedException($"No serializer for {type.FullName}");
			}
			foreach (Type subtype in typeSerializer.GetSubtypes(type))
			{
				stack.Push(subtype);
			}
			TypeData value;
			if (typeSerializer is IStaticTypeSerializer)
			{
				((IStaticTypeSerializer)typeSerializer).GetStaticMethods(type, out var writer, out var reader);
				value = new TypeData(num++, writer, reader);
			}
			else
			{
				if (!(typeSerializer is IDynamicTypeSerializer))
				{
					throw new Exception();
				}
				IDynamicTypeSerializer serializer = (IDynamicTypeSerializer)typeSerializer;
				value = new TypeData(num++, serializer);
			}
			dictionary[type] = value;
		}
		return dictionary;
	}

	private void GenerateDynamic(Dictionary<Type, TypeData> map)
	{
		foreach (KeyValuePair<Type, TypeData> item in map)
		{
			Type key = item.Key;
			TypeData value = item.Value;
			if (value.IsGenerated)
			{
				value.WriterMethodInfo = Helpers.GenerateDynamicSerializerStub(key);
				value.ReaderMethodInfo = Helpers.GenerateDynamicDeserializerStub(key);
			}
		}
		CodeGenContext codeGenContext = new CodeGenContext(map);
		foreach (KeyValuePair<Type, TypeData> item2 in map)
		{
			Type key2 = item2.Key;
			TypeData value2 = item2.Value;
			if (value2.IsGenerated)
			{
				DynamicMethod dynamicMethod = (DynamicMethod)value2.WriterMethodInfo;
				value2.TypeSerializer.GenerateWriterMethod(key2, codeGenContext, dynamicMethod.GetILGenerator());
				DynamicMethod dynamicMethod2 = (DynamicMethod)value2.ReaderMethodInfo;
				value2.TypeSerializer.GenerateReaderMethod(key2, codeGenContext, dynamicMethod2.GetILGenerator());
			}
		}
		DynamicMethod dynamicMethod3 = (DynamicMethod)codeGenContext.GetWriterMethodInfo(typeof(object));
		DynamicMethod dynamicMethod4 = (DynamicMethod)codeGenContext.GetReaderMethodInfo(typeof(object));
		m_serializerSwitch = (SerializerSwitch)dynamicMethod3.CreateDelegate(typeof(SerializerSwitch));
		m_deserializerSwitch = (DeserializerSwitch)dynamicMethod4.CreateDelegate(typeof(DeserializerSwitch));
	}

	private ushort GetTypeID(object ob)
	{
		if (ob == null)
		{
			return 0;
		}
		Type type = ob.GetType();
		if (!m_typeIDMap.TryGetValue(type, out var value))
		{
			throw new InvalidOperationException($"Unknown type {type.FullName}");
		}
		return value;
	}
}
}