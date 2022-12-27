using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace RealmClient.Util; 

public class Web {
	private static HttpClient Client = new();

	public static Dictionary<string, string> EmptyParameters = new();
	private static Dictionary<string, string> DefaultParameters = new() {
		{ "game_net", "Unity" },
		{ "play_platform", "Unity" },
		{ "game_net_user_id", "" },
	};

	//present in both
	private static WebHeaderCollection DefaultHeaders = new() {
		{"Accept", "*/*"},
		{"Accept-Encoding", "deflate, gzip"},
	};

	//present in exalt launcher
	private static WebHeaderCollection LauncherHeaders = new() {
		{"User-Agent","UnityPlayer/2020.3.30f1 (UnityWebRequest/1.0, libcurl/7.80.0-DEV)"},
		{"X-Unity-Version", "2020.3.30f1"},
	};

	//present in exalt client
	private static WebHeaderCollection ClientHeaders = new() {
		{"User-Agent","UnityPlayer/2021.3.5f1 (UnityWebRequest/1.0, libcurl/7.80.0-DEV)"},
		{"X-Unity-Version", "2021.3.5f1"},
	};

	static Web() {
		//todo: test server support
		Client.BaseAddress = new Uri("https://www.realmofthemadgod.com/");
		Client.Timeout = TimeSpan.FromMinutes(1);
		LauncherMode();
	}

	public static void LauncherMode() {
		Client.DefaultRequestHeaders.Clear();
		AddHeaders(Client.DefaultRequestHeaders, DefaultHeaders);
		AddHeaders(Client.DefaultRequestHeaders, LauncherHeaders);
	}

	public static void ClientMode() {
		Client.DefaultRequestHeaders.Clear();
		AddHeaders(Client.DefaultRequestHeaders, DefaultHeaders);
		AddHeaders(Client.DefaultRequestHeaders, ClientHeaders);
	}

	//this is so stupid, why is there no overload for HttpRequestHeaders.Add(WebHeaderCollection)?
	private static void AddHeaders(HttpRequestHeaders target, WebHeaderCollection headers) {
		foreach (string key in headers.Keys) {
			target.Add(key, headers[key]);
		}
	}

	public static async Task<string> Load(string path, Dictionary<string, string> parameters) {
		var requestParameters = new Dictionary<string, string>();
		var request = new HttpRequestMessage(HttpMethod.Post, path);

		//use form url encoded content type, because HttpClient doesn't let you manually specify the Content-Type header
		foreach (KeyValuePair<string, string> parameter in DefaultParameters) {
			requestParameters.Add(parameter.Key, parameter.Value);
		}

		foreach (var parameter in parameters) {
			requestParameters.Add(parameter.Key, parameter.Value);
		}

		request.Content = new FormUrlEncodedContent(requestParameters);
		Console.WriteLine(path + request.Content);

		// Send the request to the server
		var response = await Client.SendAsync(request);

		// Check if the request was successful
		if (response.IsSuccessStatusCode) {
			// Log the response content
			string result = await response.Content.ReadAsStringAsync();
			//Console.WriteLine("Response content: " + result);
			return result;
		}

		return String.Empty;
	}
}