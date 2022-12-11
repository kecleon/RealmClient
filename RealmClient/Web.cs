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

	public static void LoadLauncherUrls(Account account) {
		var appInit = Load("/app/init?platform=standalonewindows64&key=9KnJFxtTvLu2frXv", EmptyParameters);
		appInit = Load("/app/init?platform=standalonewindows64&key=9KnJFxtTvLu2frXv", new Dictionary<string, string> {
			{ "game_net", "rotmg" },
		});
		var verify = Load("/account/verify", new Dictionary<string, string> {
			{ "guid", Uri.EscapeDataString(account.Guid) },
			{ "password", Uri.EscapeDataString(account.Password) },
			{ "clientToken", account.ClientToken },
			{ "currentToken", Uri.EscapeDataString(account.AccessToken) },
			{ "accessToken", Uri.EscapeDataString(account.AccessToken) },
		});
		Load("/build/toolsVersion", new Dictionary<string, string> {
			{ "guid", Uri.EscapeDataString(account.Guid) },
			{ "platform", "standaloneosxuniversal" },
			{ "clientToken", account.ClientToken },
			{ "currentToken", Uri.EscapeDataString(account.AccessToken) },
			{ "accessToken", Uri.EscapeDataString(account.AccessToken) },
		});
		appInit = Load("/app/init?platform=standalonewindows64&key=9KnJFxtTvLu2frXv", new Dictionary<string, string> {
			{ "accessToken", Uri.EscapeDataString(account.AccessToken) },
		});
		var news = Load("/unityNews/getNews", new Dictionary<string, string> {
			{ "accessToken", Uri.EscapeDataString(account.AccessToken) },
		});
		var servers = Load("/account/servers", new Dictionary<string, string> {
			{ "accessToken", Uri.EscapeDataString(account.AccessToken) },
		});
		var status = Load("/serverStatus/getServerStatus", new Dictionary<string, string> {
			{ "accessToken", Uri.EscapeDataString(account.AccessToken) },
		});
	}

	public static void LoadLauncherPlayUrls(Account account) {
		var verify = Load("/account/verify", new Dictionary<string, string> {
			{ "guid", Uri.EscapeDataString(account.Guid) },
			{ "clientToken", account.ClientToken },
			{ "accessToken", Uri.EscapeDataString(account.AccessToken) },
		});
		var verifyAccessToken = Load("/account/verify", new Dictionary<string, string> {
			{ "clientToken", account.ClientToken },
			{ "accessToken", Uri.EscapeDataString(account.AccessToken) },
		});
	}

	public static void LoadClientUrls(Account account) {
		/*
https://www.realmofthemadgod.com/app/init
https://www.realmofthemadgod.com/account/verifyAccessTokenClient
	clientToken=account.ClientToken
	accessToken=Uri.EscapeDataString(account.AccessToken)
	game_net=Unity
	play_platform=Unity
	game_net_user_id=
https://www.realmofthemadgod.com/char/list
	do_login=true
	accessToken=Uri.EscapeDataString(account.AccessToken)
	game_net=Unity
	play_platform=Unity
	game_net_user_id=
https://www.realmofthemadgod.com/account/getOwnedPetSkins
	accessToken=Uri.EscapeDataString(account.AccessToken)
	game_net=Unity
	play_platform=Unity
	game_net_user_id=
https://www.realmofthemadgod.com/supportCampaign/status
	accessToken=Uri.EscapeDataString(account.AccessToken)
	game_net=Unity
	play_platform=Unity
	game_net_user_id=
https://www.realmofthemadgod.com/dungeonEvent/getClientEvents
	accessToken=Uri.EscapeDataString(account.AccessToken)
	game_net=Unity
	play_platform=Unity
	game_net_user_id=
https://www.realmofthemadgod.com/shop/deals
	language=en
	version=0
	accessToken=Uri.EscapeDataString(account.AccessToken)
	game_net=Unity
	play_platform=Unity
	game_net_user_id=
https://www.realmofthemadgod.com/season/info
	accessToken=Uri.EscapeDataString(account.AccessToken)
	game_net=Unity
	play_platform=Unity
	game_net_user_id=
https://www.realmofthemadgod.com/leaderboards/getBoardActive
	accessToken=Uri.EscapeDataString(account.AccessToken)
	game_net=Unity
	play_platform=Unity
	game_net_user_id=
https://www.realmofthemadgod.com/dailyLogin/fetchCalendar
	accessToken=Uri.EscapeDataString(account.AccessToken)
	game_net=Unity
	play_platform=Unity
	game_net_user_id=
https://www.realmofthemadgod.com/account/list
	type=0
	accessToken=Uri.EscapeDataString(account.AccessToken)
	game_net=Unity
	play_platform=Unity
	game_net_user_id=
https://www.realmofthemadgod.com/friends/getRequests
	targetName=
	accessToken=Uri.EscapeDataString(account.AccessToken)
	game_net=Unity
	play_platform=Unity
	game_net_user_id=
https://www.realmofthemadgod.com/account/list
	type=1
	accessToken=Uri.EscapeDataString(account.AccessToken)
	game_net=Unity
	play_platform=Unity
	game_net_user_id=
https://www.realmofthemadgod.com/app/publicStaticData
	dataType=powerUpSettings
	version=0
	accessToken=Uri.EscapeDataString(account.AccessToken)
	game_net=Unity
	play_platform=Unity
	game_net_user_id=
https://www.realmofthemadgod.com/account/listPowerUpStats
	accessToken=Uri.EscapeDataString(account.AccessToken)
	game_net=Unity
	play_platform=Unity
	game_net_user_id=
https://www.realmofthemadgod.com/app/publicStaticData
	dataType=keyRefineSettings
	version=0
	accessToken=Uri.EscapeDataString(account.AccessToken)
	game_net=Unity
	play_platform=Unity
	game_net_user_id=
		 */
	}

	public static Dictionary<string, string> EmptyParameters = new();

	public static async Task<string> Load(string path, Dictionary<string, string> parameters)
	{
		// Create a POST request with the specified URI
		HttpRequestMessage request = new(HttpMethod.Post, path);
		//server denies HEAD methods, would've been nice to skip loading useless things like unityNews

		// Create a string builder to hold the parameters
		StringBuilder sb = new();

		// Loop through the parameters in the dictionary
		foreach (KeyValuePair<string, string> parameter in parameters) {
			// Add the parameter to the string builder
			sb.Append(parameter.Key + "=" + parameter.Value + "&");
		}

		//add default parameters
		foreach (KeyValuePair<string, string> parameter in DefaultParameters)
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