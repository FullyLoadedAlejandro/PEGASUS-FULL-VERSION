using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace PEGASUS.Pegasus
	{
public class api
{
	[DataContract]
	private class response_structure
	{
		[DataMember]
		public bool success { get; set; }

		[DataMember]
		public string sessionid { get; set; }

		[DataMember]
		public string contents { get; set; }

		[DataMember]
		public string response { get; set; }

		[DataMember]
		public string message { get; set; }

		[DataMember]
		public string download { get; set; }

		[DataMember(IsRequired = false, EmitDefaultValue = false)]
		public user_data_structure info { get; set; }

		[DataMember]
		public List<msg> messages { get; set; }
	}

	public class msg
	{
		public string message { get; set; }

		public string author { get; set; }

		public string timestamp { get; set; }
	}

	[DataContract]
	private class user_data_structure
	{
		[DataMember]
		public string username { get; set; }

		[DataMember]
		public string ip { get; set; }

		[DataMember]
		public string hwid { get; set; }

		[DataMember]
		public string createdate { get; set; }

		[DataMember]
		public string lastlogin { get; set; }

		[DataMember]
		public List<Data> subscriptions { get; set; }
	}

	public class user_data_class
	{
		public string username { get; set; }

		public string ip { get; set; }

		public string hwid { get; set; }

		public string createdate { get; set; }

		public string lastlogin { get; set; }

		public List<Data> subscriptions { get; set; }
	}

	public class Data
	{
		public string subscription { get; set; }

		public string expiry { get; set; }

		public string timeleft { get; set; }
	}

	public string name;

	public string ownerid;

	public string secret;

	public string version;

	private string sessionid;

	private string enckey;

	private bool initzalized;

	public user_data_class user_data = new user_data_class();

	private json_wrapper response_decoder = new json_wrapper(new response_structure());

	public api(string name, string ownerid, string secret, string version)
	{
		if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(ownerid) || string.IsNullOrWhiteSpace(secret) || string.IsNullOrWhiteSpace(version))
		{
			MsgBox.Show("Application not setup correctly. Please watch video link found in Program.cs");
			Environment.Exit(0);
		}
		this.name = name;
		this.ownerid = ownerid;
		this.secret = secret;
		this.version = version;
	}

	public void init()
	{
		enckey = encryption.sha256(encryption.iv_key());
		string text = encryption.sha256(encryption.iv_key());
		string text2 = req(new NameValueCollection
		{
			["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("init")),
			["ver"] = encryption.encrypt(version, secret, text),
			["hash"] = checksum(Process.GetCurrentProcess().MainModule.FileName),
			["enckey"] = encryption.encrypt(enckey, secret, text),
			["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
			["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
			["init_iv"] = text
		});
		if (text2 == "KeyAuth_Invalid")
		{
			MsgBox.Show("Application not found");
			Environment.Exit(0);
		}
		text2 = encryption.decrypt(text2, secret, text);
		response_structure response_structure = response_decoder.string_to_generic<response_structure>(text2);
		if (response_structure.success)
		{
			sessionid = response_structure.sessionid;
			initzalized = true;
		}
		else if (response_structure.message == "invalidver")
		{
			Process.Start(response_structure.download);
			Environment.Exit(0);
		}
		else
		{
			MsgBox.Show(response_structure.message);
			Environment.Exit(0);
		}
	}

	public void register(string username, string pass, string key)
	{
		if (!initzalized)
		{
			MsgBox.Show("Please initzalize first");
			Environment.Exit(0);
		}
		string value = WindowsIdentity.GetCurrent().User.Value;
		string text = encryption.sha256(encryption.iv_key());
		string message = req(new NameValueCollection
		{
			["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("register")),
			["username"] = encryption.encrypt(username, enckey, text),
			["pass"] = encryption.encrypt(pass, enckey, text),
			["key"] = encryption.encrypt(key, enckey, text),
			["hwid"] = encryption.encrypt(value, enckey, text),
			["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
			["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
			["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
			["init_iv"] = text
		});
		message = encryption.decrypt(message, enckey, text);
		response_structure response_structure = response_decoder.string_to_generic<response_structure>(message);
		if (!response_structure.success)
		{
			MsgBox.Show(response_structure.message);
			Environment.Exit(0);
		}
		else
		{
			load_user_data(response_structure.info);
		}
	}

	public void login(string username, string pass)
	{
		if (!initzalized)
		{
			MsgBox.Show("Please initzalize first");
			Environment.Exit(0);
		}
		string value = WindowsIdentity.GetCurrent().User.Value;
		string text = encryption.sha256(encryption.iv_key());
		string message = req(new NameValueCollection
		{
			["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("login")),
			["username"] = encryption.encrypt(username, enckey, text),
			["pass"] = encryption.encrypt(pass, enckey, text),
			["hwid"] = encryption.encrypt(value, enckey, text),
			["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
			["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
			["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
			["init_iv"] = text
		});
		message = encryption.decrypt(message, enckey, text);
		response_structure response_structure = response_decoder.string_to_generic<response_structure>(message);
		if (!response_structure.success)
		{
			MsgBox.Show(response_structure.message);
			Environment.Exit(0);
		}
		else
		{
			load_user_data(response_structure.info);
		}
	}

	public void upgrade(string username, string key)
	{
		if (!initzalized)
		{
			MsgBox.Show("Please initzalize first");
			Environment.Exit(0);
		}
		_ = WindowsIdentity.GetCurrent().User.Value;
		string text = encryption.sha256(encryption.iv_key());
		string message = req(new NameValueCollection
		{
			["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("upgrade")),
			["username"] = encryption.encrypt(username, enckey, text),
			["key"] = encryption.encrypt(key, enckey, text),
			["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
			["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
			["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
			["init_iv"] = text
		});
		message = encryption.decrypt(message, enckey, text);
		response_structure response_structure = response_decoder.string_to_generic<response_structure>(message);
		if (!response_structure.success)
		{
			MsgBox.Show(response_structure.message);
			Environment.Exit(0);
		}
	}

	public void license(string key)
	{
		if (!initzalized)
		{
			MsgBox.Show("Please initzalize first");
			Environment.Exit(0);
		}
		string value = WindowsIdentity.GetCurrent().User.Value;
		string text = encryption.sha256(encryption.iv_key());
		string message = req(new NameValueCollection
		{
			["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("license")),
			["key"] = encryption.encrypt(key, enckey, text),
			["hwid"] = encryption.encrypt(value, enckey, text),
			["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
			["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
			["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
			["init_iv"] = text
		});
		message = encryption.decrypt(message, enckey, text);
		response_structure response_structure = response_decoder.string_to_generic<response_structure>(message);
		if (!response_structure.success)
		{
			MsgBox.Show(response_structure.message);
			Environment.Exit(0);
		}
		else
		{
			load_user_data(response_structure.info);
		}
	}

	public void setvar(string var, string data)
	{
		if (!initzalized)
		{
			MsgBox.Show("Please initzalize first");
			Environment.Exit(0);
		}
		string text = encryption.sha256(encryption.iv_key());
		string message = req(new NameValueCollection
		{
			["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("setvar")),
			["var"] = encryption.encrypt(var, enckey, text),
			["data"] = encryption.encrypt(data, enckey, text),
			["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
			["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
			["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
			["init_iv"] = text
		});
		message = encryption.decrypt(message, enckey, text);
		response_structure response_structure = response_decoder.string_to_generic<response_structure>(message);
		if (!response_structure.success)
		{
			MsgBox.Show(response_structure.message);
			Environment.Exit(0);
		}
	}

	public string getvar(string var)
	{
		if (!initzalized)
		{
			MsgBox.Show("Please initzalize first");
			Environment.Exit(0);
		}
		string text = encryption.sha256(encryption.iv_key());
		string message = req(new NameValueCollection
		{
			["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("getvar")),
			["var"] = encryption.encrypt(var, enckey, text),
			["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
			["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
			["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
			["init_iv"] = text
		});
		message = encryption.decrypt(message, enckey, text);
		response_structure response_structure = response_decoder.string_to_generic<response_structure>(message);
		if (!response_structure.success)
		{
			MsgBox.Show(response_structure.message);
			Environment.Exit(0);
			return null;
		}
		return response_structure.response;
	}

	public void ban()
	{
		if (!initzalized)
		{
			MsgBox.Show("Please initzalize first");
			Environment.Exit(0);
		}
		string text = encryption.sha256(encryption.iv_key());
		string message = req(new NameValueCollection
		{
			["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("ban")),
			["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
			["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
			["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
			["init_iv"] = text
		});
		message = encryption.decrypt(message, enckey, text);
		response_structure response_structure = response_decoder.string_to_generic<response_structure>(message);
		if (!response_structure.success)
		{
			MsgBox.Show(response_structure.message);
			Environment.Exit(0);
		}
	}

	public string var(string varid)
	{
		if (!initzalized)
		{
			MsgBox.Show("Please initzalize first");
			Environment.Exit(0);
		}
		_ = WindowsIdentity.GetCurrent().User.Value;
		string text = encryption.sha256(encryption.iv_key());
		string message = req(new NameValueCollection
		{
			["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("var")),
			["varid"] = encryption.encrypt(varid, enckey, text),
			["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
			["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
			["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
			["init_iv"] = text
		});
		message = encryption.decrypt(message, enckey, text);
		response_structure response_structure = response_decoder.string_to_generic<response_structure>(message);
		if (!response_structure.success)
		{
			MsgBox.Show(response_structure.message);
			Environment.Exit(0);
			return null;
		}
		return response_structure.message;
	}

	public List<msg> chatget(string channelname)
	{
		if (!initzalized)
		{
			MsgBox.Show("Please initzalize first");
			Environment.Exit(0);
		}
		string text = encryption.sha256(encryption.iv_key());
		string message = req(new NameValueCollection
		{
			["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatget")),
			["channel"] = encryption.encrypt(channelname, enckey, text),
			["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
			["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
			["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
			["init_iv"] = text
		});
		message = encryption.decrypt(message, enckey, text);
		response_structure response_structure = response_decoder.string_to_generic<response_structure>(message);
		if (!response_structure.success)
		{
			MsgBox.Show(response_structure.message);
			Environment.Exit(0);
			return null;
		}
		return response_structure.messages;
	}

	public bool chatsend(string msg, string channelname)
	{
		if (!initzalized)
		{
			MsgBox.Show("Please initzalize first");
			Environment.Exit(0);
		}
		string text = encryption.sha256(encryption.iv_key());
		string message = req(new NameValueCollection
		{
			["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatsend")),
			["message"] = encryption.encrypt(msg, enckey, text),
			["channel"] = encryption.encrypt(channelname, enckey, text),
			["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
			["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
			["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
			["init_iv"] = text
		});
		message = encryption.decrypt(message, enckey, text);
		response_structure response_structure = response_decoder.string_to_generic<response_structure>(message);
		if (!response_structure.success)
		{
			MsgBox.Show(response_structure.message);
			return false;
		}
		return true;
	}

	public bool checkblack()
	{
		if (!initzalized)
		{
			MsgBox.Show("Please initzalize first");
			Environment.Exit(0);
		}
		string value = WindowsIdentity.GetCurrent().User.Value;
		string text = encryption.sha256(encryption.iv_key());
		string message = req(new NameValueCollection
		{
			["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("checkblacklist")),
			["hwid"] = encryption.encrypt(value, enckey, text),
			["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
			["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
			["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
			["init_iv"] = text
		});
		message = encryption.decrypt(message, enckey, text);
		if (!response_decoder.string_to_generic<response_structure>(message).success)
		{
			return false;
		}
		return true;
	}

	public void webhook(string webid, string param)
	{
		if (!initzalized)
		{
			MsgBox.Show("Please initzalize first");
			Environment.Exit(0);
		}
		string text = encryption.sha256(encryption.iv_key());
		string message = req(new NameValueCollection
		{
			["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("webhook")),
			["webid"] = encryption.encrypt(webid, enckey, text),
			["params"] = encryption.encrypt(param, enckey, text),
			["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
			["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
			["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
			["init_iv"] = text
		});
		message = encryption.decrypt(message, enckey, text);
		response_structure response_structure = response_decoder.string_to_generic<response_structure>(message);
		if (!response_structure.success)
		{
			MsgBox.Show(response_structure.message);
			Environment.Exit(0);
		}
	}

	public byte[] download(string fileid)
	{
		if (!initzalized)
		{
			MsgBox.Show("Please initzalize first. File is empty since no request could be made.");
			Environment.Exit(0);
		}
		string text = encryption.sha256(encryption.iv_key());
		string message = req(new NameValueCollection
		{
			["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("file")),
			["fileid"] = encryption.encrypt(fileid, enckey, text),
			["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
			["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
			["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
			["init_iv"] = text
		});
		message = encryption.decrypt(message, enckey, text);
		response_structure response_structure = response_decoder.string_to_generic<response_structure>(message);
		if (!response_structure.success)
		{
			MsgBox.Show(response_structure.message);
			Environment.Exit(0);
		}
		return encryption.str_to_byte_arr(response_structure.contents);
	}

	public void log(string message)
	{
		if (!initzalized)
		{
			MsgBox.Show("Please initzalize first");
			Environment.Exit(0);
		}
		string text = encryption.sha256(encryption.iv_key());
		req(new NameValueCollection
		{
			["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("log")),
			["pcuser"] = encryption.encrypt(Environment.UserName, enckey, text),
			["message"] = encryption.encrypt(message, enckey, text),
			["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
			["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
			["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
			["init_iv"] = text
		});
	}

	public static string checksum(string filename)
	{
		using MD5 mD = MD5.Create();
		using FileStream inputStream = File.OpenRead(filename);
		return BitConverter.ToString(mD.ComputeHash(inputStream)).Replace("-", "").ToLowerInvariant();
	}

	public static void error(string message)
	{
		Process.Start(new ProcessStartInfo("cmd.exe", "/c start cmd /C \"color b && title Error && echo " + message + " && timeout /t 5\"")
		{
			CreateNoWindow = true,
			RedirectStandardOutput = true,
			RedirectStandardError = true,
			UseShellExecute = false
		});
		Environment.Exit(0);
	}

	private static string req(NameValueCollection post_data)
	{
		try
		{
			using WebClient webClient = new WebClient();
			byte[] bytes = webClient.UploadValues("https://keyauth.win/api/1.0/", post_data);
			return Encoding.Default.GetString(bytes);
		}
		catch (WebException ex)
		{
			if (((HttpWebResponse)ex.Response).StatusCode == (HttpStatusCode)429)
			{
				MsgBox.Show("You're connecting too fast to loader, slow down.");
				Environment.Exit(0);
				return "";
			}
			MsgBox.Show("Connection failure. Please try again, or contact us for help.");
			Environment.Exit(0);
			return "";
		}
	}

	private void load_user_data(user_data_structure data)
	{
		user_data.username = data.username;
		user_data.ip = data.ip;
		user_data.hwid = data.hwid;
		user_data.createdate = data.createdate;
		user_data.lastlogin = data.lastlogin;
		user_data.subscriptions = data.subscriptions;
	}
}
}