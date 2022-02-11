namespace PEGASUS.Loader
	{
internal class Config
{
	[Replacement(Name = "URL2")]
	public string URL2;

	[Replacement(Name = "Loader.PEGASUS")]
	public string Namespace;

	[Replacement(Name = "Dropper")]
	public string Classname;

	[Replacement(Name = "MainMethod")]
	public string MethodName;

	[Replacement(Name = "LoadApp")]
	public string MethodName2;

	[Replacement(Name = "DownloadData")]
	public string MethodName3;

	[Replacement(Name = "ApplicationData")]
	public string ApplicationData;

	[Replacement(Name = "DirectURL")]
	public string DirectURL;
}
}