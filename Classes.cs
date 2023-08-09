using System.Text.Json;

namespace TTMC.Piston
{
	public class Core
	{
		public Latest? latest { get; set; }
		public List<Version>? versions { get; set; }
	}
	public class Latest
	{
		public string? release { get; set; }
		public string? snapshot { get; set; }
	}
	public class Version
	{
		private HttpClient client = new();
		public string? id { get; set; }
		public string? type { get; set; }
		public string? url { get; set; }
		public string? time { get; set; }
		public string? releaseTime { get; set; }
		public string? sha1 { get; set; }
		public int? complianceLevel { get; set; }
		public VersionPlus? moreInfo
		{
			get
			{
				return JsonSerializer.Deserialize<VersionPlus>(moreRaw);
			}
		}
		public string moreRaw
		{
			get
			{
				{
					return client.GetStringAsync(url).Result;
				}
			}
		}
	}
	public class VersionPlus
	{
		public Arguments? arguments { get; set; }
		public AssetIndex? assetIndex { get; set; }
		public string? assets { get; set; }
		public int? complianceLevel { get; set; }
		public Downloads? downloads { get; set; }
		public string? id { get; set; }
		public JavaVersion? javaVersion { get; set; }
		public List<Library>? libraries { get; set; }
		public Logging? logging { get; set; }
		public string? mainClass { get; set; }
		public string? minecraftArguments { get; set; }
		public int? minimumLauncherVersion { get; set; }
		public string? releaseTime { get; set; }
		public string? time { get; set; }
		public string? type { get; set; }
	}
	public class Arguments
	{
		public List<object>? game { get; set; }
		public List<object>? jvm { get; set; }
	}
	public class AssetIndex
	{
		private HttpClient client = new();
		public string? id { get; set; }
		public string? sha1 { get; set; }
		public int? size { get; set; }
		public int? totalSize { get; set; }
		public string? url { get; set; }
		public string raw
		{
			get
			{
				return client.GetStringAsync(url).Result;
			}
		}
		public Objects? objects
		{
			get
			{
				return JsonSerializer.Deserialize<Objects>(raw);
			}
		}
	}
	public class Downloads
	{
		public Download? client { get; set; }
		public Download? server { get; set; }
		public Download? artifact { get; set; }
		public object? classifiers { get; set; }
	}
	public class Download
	{
		private HttpClient client = new();
		public string? id { get; set; }
		public string? path { get; set; }
		public string? sha1 { get; set; }
		public int? size { get; set; }
		public string? url { get; set; }
		public byte[] file
		{
			get
			{
				return client.GetByteArrayAsync(url).Result;
			}
		}
	}
	public class JavaVersion
	{
		public string? component { get; set; }
		public int? majorVersion { get; set; }
	}
	public class Library
	{
		public Downloads? downloads { get; set; }
		public Extract? extract { get; set; }
		public string? name { get; set; }
		public Natives? natives { get; set; }
		public List<Rule>? rules { get; set; }
	}
	public class Natives
	{
		public string? linux { get; set; }
		public string? osx { get; set; }
		public string? windows { get; set; }
	}
	public class Extract
	{
		public List<string>? exclude { get; set; }
	}
	public class Rule
	{
		public string? action { get; set; }
		public OS? os { get; set; }
	}
	public class OS
	{
		public string? name { get; set; }
	}
	public class Logging
	{
		public Client? client { get; set; }
	}
	public class Client
	{
		public string? argument { get; set; }
		public Download? file { get; set; }
		public string? type { get; set; }
	}
	public class Objects
	{
		public object? objects { get; set; }
	}
}