using System;
using System.Collections.Generic;
using Mono.Nat;

namespace PEGASUS.Utilities
	{
internal static class UPnP
{
	private static Dictionary<int, Mapping> _mappings;

	private static bool _discoveryComplete;

	private static INatDevice _device;

	private static int _port = -1;

	public static bool IsDeviceFound => _device != null;

	[Obsolete]
	public static void Initialize()
	{
		_mappings = new Dictionary<int, Mapping>();
		try
		{
			NatUtility.DeviceFound += DeviceFound;
			//NatUtility.add_DeviceLost((EventHandler<DeviceEventArgs>)DeviceLost);
			_discoveryComplete = false;
			NatUtility.StartDiscovery();
		}
		catch (Exception)
		{
		}
	}

	[Obsolete]
	public static void Initialize(int port)
	{
		_port = port;
		Initialize();
	}

	public static bool CreatePortMap(int port, out int externalPort)
	{
		if (!_discoveryComplete)
		{
			externalPort = -1;
			return false;
		}
		try
		{
			Mapping mapping = new Mapping(Protocol.Tcp, port, port);
			for (int i = 0; i < 3; i++)
			{
				_device.CreatePortMapAsync(mapping);
			}
			if (_mappings.ContainsKey(mapping.PrivatePort))
			{
				_mappings[mapping.PrivatePort] = mapping;
			}
			else
			{
				_mappings.Add(mapping.PrivatePort, mapping);
			}
			externalPort = mapping.PublicPort;
			return true;
		}
		catch (MappingException)
		{
			externalPort = -1;
			return false;
		}
	}

	public static void DeletePortMap(int port)
	{
		if (!_discoveryComplete || !_mappings.TryGetValue(port, out var value))
		{
			return;
		}
		try
		{
			for (int i = 0; i < 3; i++)
			{
				_device.DeletePortMapAsync(value);
			}
		}
		catch (MappingException)
		{
		}
	}

	private static void DeviceFound(object sender, DeviceEventArgs args)
	{
		_device = args.Device;
		NatUtility.StopDiscovery();
		_discoveryComplete = true;
		if (_port > 0)
		{
			CreatePortMap(_port, out var _);
		}
	}

	private static void DeviceLost(object sender, DeviceEventArgs args)
	{
		_device = null;
		_discoveryComplete = false;
	}
}
}