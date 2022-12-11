using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace RealmClient; 

public class Web {
	private static HttpClient Client = new();

	private static Dictionary<string, string> DefaultParameters = new() {
		{ "game_net", "Unity" },
		{ "play_platform", "Unity" },
		{ "game_net_user_id", "" },
	};

	//present in both
	private static WebHeaderCollection DefaultHeaders = new() {
		{"Accept", "*/*"},
		{"Accept-Encoding", "deflate, gzip"},
		{"Content-Type", "application/x-www-form-urlencoded"},
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

	public static void RunLauncherUrls(Account account) {
		/*
logged in
https:www.realmofthemadgod.com/app/init?platform=standalonewindows64&key=9KnJFxtTvLu2frXv
	game_net=Unity&play_platform=Unity&game_net_user_id=
https:www.realmofthemadgod.com/app/init?platform=standalonewindows64&key=9KnJFxtTvLu2frXv
	game_net=rotmg&game_net=Unity&play_platform=Unity&game_net_user_id=
https://www.realmofthemadgod.com/account/verify
	guid=email&password=pass&clientToken=clienttoken&game_net=Unity&play_platform=Unity&game_net_user_id=
https://www.realmofthemadgod.com/build/toolsVersion
	guid=email&platform=standaloneosxuniversal&clientToken=clienttoken&currentToken=accesstoken&accessToken=accesstoken&game_net=Unity&play_platform=Unity&game_net_user_id=
https://www.realmofthemadgod.com/app/init?platform=standalonewindows64&key=9KnJFxtTvLu2frXv
	accessToken=accesstoken&game_net=Unity&play_platform=Unity&game_net_user_id=
https://www.realmofthemadgod.com/unityNews/getNews
	accessToken=accesstoken&game_net=Unity&play_platform=Unity&game_net_user_id=
https://www.realmofthemadgod.com/account/servers
	accessToken=accesstoken&game_net=Unity&play_platform=Unity&game_net_user_id=
https://www.realmofthemadgod.com/serverStatus/getServerStatus
	accessToken=accesstoken&game_net=Unity&play_platform=Unity&game_net_user_id=
		 */
	}

	public static async Task<string> Load(string path, Dictionary<string,string> parameters)
	{
		// Create a POST request with the specified URI
		HttpRequestMessage request = new(HttpMethod.Post, path);

		// Create a string builder to hold the parameters
		StringBuilder sb = new();

		// Loop through the parameters in the dictionary
		foreach (KeyValuePair<string, string> parameter in parameters)
		{
			// Add the parameter to the string builder
			sb.Append(parameter.Key + "=" + parameter.Value + "&");
		}

		// Remove the last trailing &
		sb.Remove(sb.Length - 1, 1);

		// Set the content of the request
		request.Content = new StringContent(sb.ToString());

		// Send the request to the server
		HttpResponseMessage response = await Client.SendAsync(request);

		// Check if the request was successful
		if (response.IsSuccessStatusCode)
		{
			// Log the response content
			string result = await response.Content.ReadAsStringAsync();
			Console.WriteLine("Response content: " + result);
			return result;
		}
		else
		{
			Console.WriteLine("POST request failed");
		}
		
		//todo: some timeouts here

		return String.Empty;
	}
}