using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;

namespace PEGASUS.Pegasus
	{
internal class InfoManager
{
	private Timer timer;

	private string lastGateway;

	public InfoManager()
	{
		lastGateway = GetGatewayMAC();
	}

	public void StartListener()
	{
		timer = new Timer(delegate
		{
			OnCallBack();
		}, null, 5000, -1);
	}

	private void OnCallBack()
	{
		timer.Dispose();
		if (!(GetGatewayMAC() == lastGateway))
		{
			Constants.Breached = true;
			MessageBox.Show("ARP Cache poisoning has been detected!", ABC.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
			Process.GetCurrentProcess().Kill();
		}
		else
		{
			lastGateway = GetGatewayMAC();
		}
		timer = new Timer(delegate
		{
			OnCallBack();
		}, null, 5000, -1);
	}

	public static IPAddress GetDefaultGateway()
	{
		return (from g in (from n in NetworkInterface.GetAllNetworkInterfaces()
						   where n.OperationalStatus == OperationalStatus.Up
						   where n.NetworkInterfaceType != NetworkInterfaceType.Loopback
						   select n).SelectMany((NetworkInterface n) => n.GetIPProperties()?.GatewayAddresses)
				select g?.Address into a
				where a != null
				select a).FirstOrDefault();
	}

	private string GetArpTable()
	{
		string pathRoot = Path.GetPathRoot(Environment.SystemDirectory);
		using Process process = Process.Start(new ProcessStartInfo
		{
			FileName = pathRoot + "Windows\\System32\\arp.exe",
			Arguments = "-a",
			UseShellExecute = false,
			RedirectStandardOutput = true,
			CreateNoWindow = true
		});
		using StreamReader streamReader = process.StandardOutput;
		return streamReader.ReadToEnd();
	}

	private string GetGatewayMAC()
	{
		string arg = GetDefaultGateway().ToString();
		return new Regex($"({arg} [\\W]*) ([a-z0-9-]*)").Match(GetArpTable()).Groups[2].ToString();
	}
}
}