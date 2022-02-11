using System;
using System.Drawing;

namespace Remote_Process
{ 

[Serializable]
public class RemoteProcessList
{
	public string ProcessName;

	public string Pid;

	public string Integrity;

	public string CommandLine;

	public Bitmap ProcessIcon;
}
}