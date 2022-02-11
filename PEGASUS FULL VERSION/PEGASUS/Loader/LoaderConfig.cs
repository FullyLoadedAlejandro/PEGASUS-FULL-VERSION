namespace PEGASUS.Loader
	{
internal class LoaderConfig
{
	[Replacement(Name = "powershell-data")]
	public string Base64Data;

	[Replacement(Name = "Loader.PEGASUS")]
	public string Namespace;

	[Replacement(Name = "Dropper")]
	public string Classname;

	[Replacement(Name = "Run")]
	public string MethodName;

	[Replacement(Name = "$dec")]
	public string Decoded;

	[Replacement(Name = "$whatever")]
	public string Encoded;

	[Replacement(Name = "$instance")]
	public string Instance;
}
}