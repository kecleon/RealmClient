using System.Xml.Serialization;
using RealmClient.Util;

namespace RealmClient;

public class Account {
	public string Guid;
	public string Password;
	public string Secret;
	public string ClientToken;
	public string AccessToken;
	public string CharList;
	public string AccountVerify;
	public bool Steam;

	public Account() {
		if (Settings.AccountSettings.GetSetting("Secret", out object secret)) {
			Secret = (string)secret;
			Steam = true;
		}

		if (Settings.AccountSettings.GetSetting("GUID", out object guid) && Settings.AccountSettings.GetSetting("Password", out object password)) {
			Guid = (string)guid;
			Password = (string)password;
			ClientToken = Guid.Hash().ToHexString();
		} else {
			Log.Info("Can't initialize Account with missing GUID and Password settings");
		}
	}

	public Account(string guid, string password) {
		Guid = guid;
		Password = password;
		ClientToken = Guid.Hash().ToHexString();
	}

	public Account(string guid, string password, string secret) {
		Guid = guid;
		Password = password;
		Secret = secret;
		Steam = true;
		ClientToken = Guid.Hash().ToHexString();
	}

	public void LoadLauncherUrls() {
		var appInit = Web.Load("/app/init?platform=standalonewindows64&key=9KnJFxtTvLu2frXv", Web.EmptyParameters);
		appInit = Web.Load("/app/init?platform=standalonewindows64&key=9KnJFxtTvLu2frXv", new Dictionary<string, string> {
			{ "game_net", "rotmg" },
		});
		var verify = Web.Load("/account/verify", new Dictionary<string, string> {
			{ "guid", Uri.EscapeDataString(Guid) },
			{ "password", Uri.EscapeDataString(Password) },
			{ "clientToken", ClientToken },
			{ "currentToken", Uri.EscapeDataString(AccessToken) },
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		});
		Web.Load("/build/toolsVersion", new Dictionary<string, string> {
			{ "guid", Uri.EscapeDataString(Guid) },
			{ "platform", "standaloneosxuniversal" },
			{ "clientToken", ClientToken },
			{ "currentToken", Uri.EscapeDataString(AccessToken) },
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		});
		appInit = Web.Load("/app/init?platform=standalonewindows64&key=9KnJFxtTvLu2frXv", new Dictionary<string, string> {
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		});
		var news = Web.Load("/unityNews/getNews", new Dictionary<string, string> {
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		});
		var servers = Web.Load("/account/servers", new Dictionary<string, string> {
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		});
		var status = Web.Load("/serverStatus/getServerStatus", new Dictionary<string, string> {
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		});
	}

	public void LoadLauncherPlayUrls() {
		var verify = Web.Load("/account/verify", new Dictionary<string, string> {
			{ "guid", Uri.EscapeDataString(Guid) },
			{ "clientToken", ClientToken },
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		});
		var verifyAccessToken = Web.Load("/account/verify", new Dictionary<string, string> {
			{ "clientToken", ClientToken },
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		});
	}

	public void LoadClientUrls() {
		var appInit = Web.Load("/app/init", Web.EmptyParameters);
		var verifyAccessToken = Web.Load("/account/verifyAccessTokenClient", new Dictionary<string, string> {
			{ "clientToken", ClientToken },
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		});
		var charList = Web.Load("/char/list", new Dictionary<string, string> {
			{ "do_login", "true" },
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		});
		var ownedPetSkins = Web.Load("/account/getOwnedPetSkins", new Dictionary<string, string> {
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		});
		var campaignStatus = Web.Load("/supportCampaign/status", new Dictionary<string, string> {
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		});
		var dungeonEvents = Web.Load("/dungeonEvent/getClientEvents", new Dictionary<string, string> {
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		});
		var shopDeals = Web.Load("/shop/deals", new Dictionary<string, string> {
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		});
		var seasonInfo = Web.Load("/season/info", new Dictionary<string, string> {
			{ "language", "en" },
			{ "version", "0" },
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		});
		var activeLeaderboard = Web.Load("/leaderboards/getBoardActive", new Dictionary<string, string> {
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		});
		var dailyLoginCalendar = Web.Load("/dailyLogin/fetchCalendar", new Dictionary<string, string> {
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		});
		var accountList0 = Web.Load("/account/list", new Dictionary<string, string> {
			{ "type", "0" }, //todo: account list constants
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		});
		var friendRequests = Web.Load("/friends/getRequests", new Dictionary<string, string> {
			{ "targetName", "" },
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		});
		var accountList1 = Web.Load("/account/list", new Dictionary<string, string> {
			{ "type", "1" }, //todo: account list constants
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		});
		var publicStatDataPowerUp = Web.Load("/app/publicStaticData", new Dictionary<string, string> {
			{ "dataType", "powerUpSettings" },
			{ "version", "0" },
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		});
		var powerUpStats = Web.Load("/account/listPowerUpStats", new Dictionary<string, string> {
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		});
		var publicStatDataKeyRefine = Web.Load("/app/publicStaticData", new Dictionary<string, string> {
			{ "dataType", "keyRefineSettings" },
			{ "version", "0" },
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		});
	}

	public void ParseAccountVerify(string xml) {
		XmlSerializer serializer = new XmlSerializer(typeof(Account));
		using StringReader reader = new StringReader(xml);
		var test = (Account)serializer.Deserialize(reader);
	}
}