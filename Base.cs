using System.Text.Json;

namespace TTMC.Piston
{
	public class API
	{
		public string raw { get; }
		public HttpClient client;
		public API(string server = "https://piston-meta.mojang.com")
		{
			client = new()
			{
				BaseAddress = new(server)
			};
			raw = client.GetStringAsync("/mc/game/version_manifest_v2.json").Result;
		}
		public Core? core
		{
			get
			{
				return JsonSerializer.Deserialize<Core>(raw);
			}
		}
		public Latest? latest
		{
			get
			{
				return core != null ? core.latest : null;
			}
		}
		public List<Version>? versions
		{
			get
			{
				return core != null ? core.versions : null;
			}
		}
	}
}