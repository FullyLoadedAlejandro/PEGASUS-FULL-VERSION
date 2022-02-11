using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Costura
{
	// Token: 0x02000202 RID: 514
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	internal static class AssemblyLoader
	{
		// Token: 0x06000E42 RID: 3650 RVA: 0x000093E7 File Offset: 0x000075E7
		private static string CultureToString(global::System.Globalization.CultureInfo culture)
		{
			if (culture == null)
			{
				return "";
			}
			return culture.Name;
		}

		// Token: 0x06000E43 RID: 3651 RVA: 0x0008F938 File Offset: 0x0008DB38
		private static global::System.Reflection.Assembly ReadExistingAssembly(global::System.Reflection.AssemblyName name)
		{
			global::System.AppDomain currentDomain = global::System.AppDomain.CurrentDomain;
			global::System.Reflection.Assembly[] assemblies = currentDomain.GetAssemblies();
			foreach (global::System.Reflection.Assembly assembly in assemblies)
			{
				global::System.Reflection.AssemblyName name2 = assembly.GetName();
				if (string.Equals(name2.Name, name.Name, global::System.StringComparison.InvariantCultureIgnoreCase) && string.Equals(global::Costura.AssemblyLoader.CultureToString(name2.CultureInfo), global::Costura.AssemblyLoader.CultureToString(name.CultureInfo), global::System.StringComparison.InvariantCultureIgnoreCase))
				{
					return assembly;
				}
			}
			return null;
		}

		// Token: 0x06000E44 RID: 3652 RVA: 0x0008F9A8 File Offset: 0x0008DBA8
		private static void CopyTo(global::System.IO.Stream source, global::System.IO.Stream destination)
		{
			byte[] array = new byte[81920];
			int count;
			while ((count = source.Read(array, 0, array.Length)) != 0)
			{
				destination.Write(array, 0, count);
			}
		}

		// Token: 0x06000E45 RID: 3653 RVA: 0x0008F9DC File Offset: 0x0008DBDC
		private static global::System.IO.Stream LoadStream(string fullName)
		{
			global::System.Reflection.Assembly executingAssembly = global::System.Reflection.Assembly.GetExecutingAssembly();
			if (fullName.EndsWith(".compressed"))
			{
				using (global::System.IO.Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(fullName))
				{
					using (global::System.IO.Compression.DeflateStream deflateStream = new global::System.IO.Compression.DeflateStream(manifestResourceStream, global::System.IO.Compression.CompressionMode.Decompress))
					{
						global::System.IO.MemoryStream memoryStream = new global::System.IO.MemoryStream();
						global::Costura.AssemblyLoader.CopyTo(deflateStream, memoryStream);
						memoryStream.Position = 0L;
						return memoryStream;
					}
				}
			}
			return executingAssembly.GetManifestResourceStream(fullName);
		}

		// Token: 0x06000E46 RID: 3654 RVA: 0x0008FA60 File Offset: 0x0008DC60
		private static global::System.IO.Stream LoadStream(global::System.Collections.Generic.Dictionary<string, string> resourceNames, string name)
		{
			string fullName;
			if (resourceNames.TryGetValue(name, out fullName))
			{
				return global::Costura.AssemblyLoader.LoadStream(fullName);
			}
			return null;
		}

		// Token: 0x06000E47 RID: 3655 RVA: 0x0008FA80 File Offset: 0x0008DC80
		private static byte[] ReadStream(global::System.IO.Stream stream)
		{
			byte[] array = new byte[stream.Length];
			stream.Read(array, 0, array.Length);
			return array;
		}

		// Token: 0x06000E48 RID: 3656 RVA: 0x0008FAA8 File Offset: 0x0008DCA8
		private static global::System.Reflection.Assembly ReadFromEmbeddedResources(global::System.Collections.Generic.Dictionary<string, string> assemblyNames, global::System.Collections.Generic.Dictionary<string, string> symbolNames, global::System.Reflection.AssemblyName requestedAssemblyName)
		{
			string text = requestedAssemblyName.Name.ToLowerInvariant();
			if (requestedAssemblyName.CultureInfo != null && !string.IsNullOrEmpty(requestedAssemblyName.CultureInfo.Name))
			{
				text = requestedAssemblyName.CultureInfo.Name + "." + text;
			}
			byte[] rawAssembly;
			using (global::System.IO.Stream stream = global::Costura.AssemblyLoader.LoadStream(assemblyNames, text))
			{
				if (stream == null)
				{
					return null;
				}
				rawAssembly = global::Costura.AssemblyLoader.ReadStream(stream);
			}
			using (global::System.IO.Stream stream2 = global::Costura.AssemblyLoader.LoadStream(symbolNames, text))
			{
				if (stream2 != null)
				{
					byte[] rawSymbolStore = global::Costura.AssemblyLoader.ReadStream(stream2);
					return global::System.Reflection.Assembly.Load(rawAssembly, rawSymbolStore);
				}
			}
			return global::System.Reflection.Assembly.Load(rawAssembly);
		}

		// Token: 0x06000E49 RID: 3657 RVA: 0x0008FB68 File Offset: 0x0008DD68
		public static global::System.Reflection.Assembly ResolveAssembly(object sender, global::System.ResolveEventArgs e)
		{
			object obj = global::Costura.AssemblyLoader.nullCacheLock;
			lock (obj)
			{
				if (global::Costura.AssemblyLoader.nullCache.ContainsKey(e.Name))
				{
					return null;
				}
			}
			global::System.Reflection.AssemblyName assemblyName = new global::System.Reflection.AssemblyName(e.Name);
			global::System.Reflection.Assembly assembly = global::Costura.AssemblyLoader.ReadExistingAssembly(assemblyName);
			if (assembly != null)
			{
				return assembly;
			}
			assembly = global::Costura.AssemblyLoader.ReadFromEmbeddedResources(global::Costura.AssemblyLoader.assemblyNames, global::Costura.AssemblyLoader.symbolNames, assemblyName);
			if (assembly == null)
			{
				object obj2 = global::Costura.AssemblyLoader.nullCacheLock;
				lock (obj2)
				{
					global::Costura.AssemblyLoader.nullCache[e.Name] = true;
				}
				if ((assemblyName.Flags & global::System.Reflection.AssemblyNameFlags.Retargetable) != global::System.Reflection.AssemblyNameFlags.None)
				{
					assembly = global::System.Reflection.Assembly.Load(assemblyName);
				}
			}
			return assembly;
		}

		// Token: 0x06000E4A RID: 3658 RVA: 0x0008FC40 File Offset: 0x0008DE40
		// Note: this type is marked as 'beforefieldinit'.
		static AssemblyLoader()
		{
			global::Costura.AssemblyLoader.assemblyNames.Add("antire.runtime", "costura.antire.runtime.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bouncycastle.crypto", "costura.bouncycastle.crypto.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.licensing", "costura.bunifu.licensing.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.1.5.3", "costura.bunifu.ui.winforms.1.5.3.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifubutton", "costura.bunifu.ui.winforms.bunifubutton.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifucheckbox", "costura.bunifu.ui.winforms.bunifucheckbox.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifucircleprogress", "costura.bunifu.ui.winforms.bunifucircleprogress.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifucolortransition", "costura.bunifu.ui.winforms.bunifucolortransition.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifudatagridview", "costura.bunifu.ui.winforms.bunifudatagridview.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifudatepicker", "costura.bunifu.ui.winforms.bunifudatepicker.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifudropdown", "costura.bunifu.ui.winforms.bunifudropdown.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifuformdock", "costura.bunifu.ui.winforms.bunifuformdock.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifugauge", "costura.bunifu.ui.winforms.bunifugauge.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifugradientpanel", "costura.bunifu.ui.winforms.bunifugradientpanel.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifugroupbox", "costura.bunifu.ui.winforms.bunifugroupbox.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifuimagebutton", "costura.bunifu.ui.winforms.bunifuimagebutton.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifulabel", "costura.bunifu.ui.winforms.bunifulabel.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifuloader", "costura.bunifu.ui.winforms.bunifuloader.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifupages", "costura.bunifu.ui.winforms.bunifupages.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifupanel", "costura.bunifu.ui.winforms.bunifupanel.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifupicturebox", "costura.bunifu.ui.winforms.bunifupicturebox.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifuprogressbar", "costura.bunifu.ui.winforms.bunifuprogressbar.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifuradiobutton", "costura.bunifu.ui.winforms.bunifuradiobutton.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifurating", "costura.bunifu.ui.winforms.bunifurating.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifuscrollbar", "costura.bunifu.ui.winforms.bunifuscrollbar.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifuseparator", "costura.bunifu.ui.winforms.bunifuseparator.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifushadowpanel", "costura.bunifu.ui.winforms.bunifushadowpanel.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifushapes", "costura.bunifu.ui.winforms.bunifushapes.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifuslider", "costura.bunifu.ui.winforms.bunifuslider.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifusnackbar", "costura.bunifu.ui.winforms.bunifusnackbar.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifutextbox", "costura.bunifu.ui.winforms.bunifutextbox.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifutoggleswitch", "costura.bunifu.ui.winforms.bunifutoggleswitch.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifutooltip", "costura.bunifu.ui.winforms.bunifutooltip.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifutransition", "costura.bunifu.ui.winforms.bunifutransition.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.bunifuusercontrol", "costura.bunifu.ui.winforms.bunifuusercontrol.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("bunifu.ui.winforms.deprecated", "costura.bunifu.ui.winforms.deprecated.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("cgeoip", "costura.cgeoip.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("costura", "costura.costura.dll.compressed");
			global::Costura.AssemblyLoader.symbolNames.Add("costura", "costura.costura.pdb.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("customcontrols", "costura.customcontrols.dll.compressed");
			global::Costura.AssemblyLoader.symbolNames.Add("customcontrols", "costura.customcontrols.pdb.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("discord.net.commands", "costura.discord.net.commands.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("discord.net.core", "costura.discord.net.core.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("discord.net.rest", "costura.discord.net.rest.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("discord.net.webhook", "costura.discord.net.webhook.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("discord.net.websocket", "costura.discord.net.websocket.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("dnlib", "costura.dnlib.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("fastcoloredtextbox", "costura.fastcoloredtextbox.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("guna.ui2", "costura.guna.ui2.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("iconextractor", "costura.iconextractor.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("microsoft.bcl.asyncinterfaces", "costura.microsoft.bcl.asyncinterfaces.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("microsoft.win32.primitives", "costura.microsoft.win32.primitives.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("mono.cecil", "costura.mono.cecil.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("mono.cecil.mdb", "costura.mono.cecil.mdb.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("mono.cecil.pdb", "costura.mono.cecil.pdb.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("mono.cecil.rocks", "costura.mono.cecil.rocks.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("mono.httputility", "costura.mono.httputility.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("mono.nat", "costura.mono.nat.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("netstandard", "costura.netstandard.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("newtonsoft.json", "costura.newtonsoft.json.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("pinvoke.kernel32", "costura.pinvoke.kernel32.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("pinvoke.shell32", "costura.pinvoke.shell32.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("pinvoke.windows.core", "costura.pinvoke.windows.core.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("protobuf-net", "costura.protobuf-net.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("server", "costura.server.dll.compressed");
			global::Costura.AssemblyLoader.symbolNames.Add("server", "costura.server.pdb.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("sharpupdate", "costura.sharpupdate.dll.compressed");
			global::Costura.AssemblyLoader.symbolNames.Add("sharpupdate", "costura.sharpupdate.pdb.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("siticone.ui", "costura.siticone.ui.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.appcontext", "costura.system.appcontext.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.buffers", "costura.system.buffers.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.collections.concurrent", "costura.system.collections.concurrent.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.collections", "costura.system.collections.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.collections.immutable", "costura.system.collections.immutable.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.collections.nongeneric", "costura.system.collections.nongeneric.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.collections.specialized", "costura.system.collections.specialized.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.componentmodel", "costura.system.componentmodel.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.componentmodel.eventbasedasync", "costura.system.componentmodel.eventbasedasync.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.componentmodel.primitives", "costura.system.componentmodel.primitives.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.componentmodel.typeconverter", "costura.system.componentmodel.typeconverter.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.console", "costura.system.console.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.data.common", "costura.system.data.common.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.diagnostics.contracts", "costura.system.diagnostics.contracts.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.diagnostics.debug", "costura.system.diagnostics.debug.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.diagnostics.diagnosticsource", "costura.system.diagnostics.diagnosticsource.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.diagnostics.fileversioninfo", "costura.system.diagnostics.fileversioninfo.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.diagnostics.process", "costura.system.diagnostics.process.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.diagnostics.stacktrace", "costura.system.diagnostics.stacktrace.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.diagnostics.textwritertracelistener", "costura.system.diagnostics.textwritertracelistener.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.diagnostics.tools", "costura.system.diagnostics.tools.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.diagnostics.tracesource", "costura.system.diagnostics.tracesource.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.diagnostics.tracing", "costura.system.diagnostics.tracing.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.drawing.primitives", "costura.system.drawing.primitives.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.dynamic.runtime", "costura.system.dynamic.runtime.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.globalization.calendars", "costura.system.globalization.calendars.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.globalization", "costura.system.globalization.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.globalization.extensions", "costura.system.globalization.extensions.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.interactive.async", "costura.system.interactive.async.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.io.compression", "costura.system.io.compression.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.io.compression.zipfile", "costura.system.io.compression.zipfile.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.io", "costura.system.io.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.io.filesystem", "costura.system.io.filesystem.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.io.filesystem.driveinfo", "costura.system.io.filesystem.driveinfo.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.io.filesystem.primitives", "costura.system.io.filesystem.primitives.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.io.filesystem.watcher", "costura.system.io.filesystem.watcher.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.io.isolatedstorage", "costura.system.io.isolatedstorage.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.io.memorymappedfiles", "costura.system.io.memorymappedfiles.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.io.pipes", "costura.system.io.pipes.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.io.unmanagedmemorystream", "costura.system.io.unmanagedmemorystream.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.linq.async", "costura.system.linq.async.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.linq", "costura.system.linq.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.linq.expressions", "costura.system.linq.expressions.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.linq.parallel", "costura.system.linq.parallel.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.linq.queryable", "costura.system.linq.queryable.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.memory", "costura.system.memory.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.net.http", "costura.system.net.http.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.net.nameresolution", "costura.system.net.nameresolution.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.net.networkinformation", "costura.system.net.networkinformation.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.net.ping", "costura.system.net.ping.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.net.primitives", "costura.system.net.primitives.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.net.requests", "costura.system.net.requests.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.net.security", "costura.system.net.security.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.net.sockets", "costura.system.net.sockets.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.net.webheadercollection", "costura.system.net.webheadercollection.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.net.websockets.client", "costura.system.net.websockets.client.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.net.websockets", "costura.system.net.websockets.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.numerics.vectors", "costura.system.numerics.vectors.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.objectmodel", "costura.system.objectmodel.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.reflection", "costura.system.reflection.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.reflection.extensions", "costura.system.reflection.extensions.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.reflection.primitives", "costura.system.reflection.primitives.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.resources.reader", "costura.system.resources.reader.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.resources.resourcemanager", "costura.system.resources.resourcemanager.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.resources.writer", "costura.system.resources.writer.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.runtime.compilerservices.unsafe", "costura.system.runtime.compilerservices.unsafe.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.runtime.compilerservices.visualc", "costura.system.runtime.compilerservices.visualc.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.runtime", "costura.system.runtime.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.runtime.extensions", "costura.system.runtime.extensions.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.runtime.handles", "costura.system.runtime.handles.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.runtime.interopservices", "costura.system.runtime.interopservices.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.runtime.interopservices.runtimeinformation", "costura.system.runtime.interopservices.runtimeinformation.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.runtime.numerics", "costura.system.runtime.numerics.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.runtime.serialization.formatters", "costura.system.runtime.serialization.formatters.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.runtime.serialization.json", "costura.system.runtime.serialization.json.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.runtime.serialization.primitives", "costura.system.runtime.serialization.primitives.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.runtime.serialization.xml", "costura.system.runtime.serialization.xml.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.security.claims", "costura.system.security.claims.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.security.cryptography.algorithms", "costura.system.security.cryptography.algorithms.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.security.cryptography.csp", "costura.system.security.cryptography.csp.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.security.cryptography.encoding", "costura.system.security.cryptography.encoding.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.security.cryptography.primitives", "costura.system.security.cryptography.primitives.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.security.cryptography.x509certificates", "costura.system.security.cryptography.x509certificates.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.security.principal", "costura.system.security.principal.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.security.securestring", "costura.system.security.securestring.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.text.encoding", "costura.system.text.encoding.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.text.encoding.extensions", "costura.system.text.encoding.extensions.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.text.regularexpressions", "costura.system.text.regularexpressions.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.threading", "costura.system.threading.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.threading.overlapped", "costura.system.threading.overlapped.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.threading.tasks", "costura.system.threading.tasks.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.threading.tasks.extensions", "costura.system.threading.tasks.extensions.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.threading.tasks.parallel", "costura.system.threading.tasks.parallel.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.threading.thread", "costura.system.threading.thread.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.threading.threadpool", "costura.system.threading.threadpool.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.threading.timer", "costura.system.threading.timer.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.valuetuple", "costura.system.valuetuple.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.xml.readerwriter", "costura.system.xml.readerwriter.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.xml.xdocument", "costura.system.xml.xdocument.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.xml.xmldocument", "costura.system.xml.xmldocument.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.xml.xmlserializer", "costura.system.xml.xmlserializer.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.xml.xpath", "costura.system.xml.xpath.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("system.xml.xpath.xdocument", "costura.system.xml.xpath.xdocument.dll.compressed");
			global::Costura.AssemblyLoader.assemblyNames.Add("vestris.resourcelib", "costura.vestris.resourcelib.dll.compressed");
		}

		// Token: 0x06000E4B RID: 3659 RVA: 0x000909FC File Offset: 0x0008EBFC
		public static void Attach()
		{
			if (global::System.Threading.Interlocked.Exchange(ref global::Costura.AssemblyLoader.isAttached, 1) == 1)
			{
				return;
			}
			global::System.AppDomain currentDomain = global::System.AppDomain.CurrentDomain;
			currentDomain.AssemblyResolve += global::Costura.AssemblyLoader.ResolveAssembly;
		}

		// Token: 0x04000BAD RID: 2989
		private static object nullCacheLock = new object();

		// Token: 0x04000BAE RID: 2990
		private static global::System.Collections.Generic.Dictionary<string, bool> nullCache = new global::System.Collections.Generic.Dictionary<string, bool>();

		// Token: 0x04000BAF RID: 2991
		private static global::System.Collections.Generic.Dictionary<string, string> assemblyNames = new global::System.Collections.Generic.Dictionary<string, string>();

		// Token: 0x04000BB0 RID: 2992
		private static global::System.Collections.Generic.Dictionary<string, string> symbolNames = new global::System.Collections.Generic.Dictionary<string, string>();

		// Token: 0x04000BB1 RID: 2993
		private static int isAttached;
	}
}
