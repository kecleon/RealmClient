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

	public static Account AccountFromSettings() {
		Settings.AccountSettings.GetSetting("GUID", out object guid);
		Settings.AccountSettings.GetSetting("Password", out object password);
		Settings.AccountSettings.GetSetting("Secret", out object secret);
		Settings.AccountSettings.GetSetting("AccessToken", out object accessToken);
		if (secret is not null) {
			return new Account((string)guid, (string)password, true);
		}

		if (guid is not null && password is not null && accessToken is not null) {
			return new Account((string)guid, (string)password, false);
		}

		return null;
	}

	public Account(string guid, string password, bool steam) {
		Guid = guid;
		ClientToken = Guid.Hash().ToHexString();
		Steam = steam;
		if (steam) {
			Secret = password;
		} else {
			Password = password;
		}
	}

	public bool TryLauncherLogin() {
		if (Guid is not null && (Steam ? Secret is not null : Password is not null)) {
			var verify = Web.Load("/account/verify", new Dictionary<string, string> {
				{ "guid", Uri.EscapeDataString(Guid) },
				{ "password", Uri.EscapeDataString(Password) },
				{ "clientToken", ClientToken },
				//{ "currentToken", Uri.EscapeDataString(AccessToken) },
				//{ "accessToken", Uri.EscapeDataString(AccessToken) },
			}).Result;
			AccountVerify = verify;
			return ParseAccountVerify(verify);
		}

		return false;
	}

	public static void LoadLauncheBaseUrls() {
		var appInit = Web.Load("/app/init?platform=standalonewindows64&key=9KnJFxtTvLu2frXv", Web.EmptyParameters).Result;
		appInit = Web.Load("/app/init?platform=standalonewindows64&key=9KnJFxtTvLu2frXv", Web.EmptyParameters).Result;
		var news = Web.Load("/unityNews/getNews", Web.EmptyParameters).Result;
	}

	public void LoadLauncherAccountUrls() {
		var version = Web.Load("/build/toolsVersion", new Dictionary<string, string> {
			{ "guid", Uri.EscapeDataString(Guid) },
			{ "platform", "standaloneosxuniversal" },
			{ "clientToken", ClientToken },
			{ "currentToken", Uri.EscapeDataString(AccessToken) },
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		}).Result;
		var appInit = Web.Load("/app/init?platform=standalonewindows64&key=9KnJFxtTvLu2frXv", new Dictionary<string, string> {
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		}).Result;
		var servers = Web.Load("/account/servers", new Dictionary<string, string> {
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		}).Result;
		var status = Web.Load("/serverStatus/getServerStatus", new Dictionary<string, string> {
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		}).Result;
	}

	public void LoadLauncherPlayUrls() {
		var verify = Web.Load("/account/verify", new Dictionary<string, string> {
			{ "guid", Uri.EscapeDataString(Guid) },
			{ "clientToken", ClientToken },
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		}).Result;
		var verifyAccessToken = Web.Load("/account/verify", new Dictionary<string, string> {
			{ "clientToken", ClientToken },
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		}).Result;
	}

	public void LoadClientUrls() {
		var appInit = Web.Load("/app/init", Web.EmptyParameters).Result;
		var verifyAccessToken = Web.Load("/account/verifyAccessTokenClient", new Dictionary<string, string> {
			{ "clientToken", ClientToken },
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		}).Result;
		var charList = Web.Load("/char/list", new Dictionary<string, string> {
			{ "do_login", "true" },
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		}).Result;
		var ownedPetSkins = Web.Load("/account/getOwnedPetSkins", new Dictionary<string, string> {
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		}).Result;
		var campaignStatus = Web.Load("/supportCampaign/status", new Dictionary<string, string> {
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		}).Result;
		var dungeonEvents = Web.Load("/dungeonEvent/getClientEvents", new Dictionary<string, string> {
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		}).Result;
		var shopDeals = Web.Load("/shop/deals", new Dictionary<string, string> {
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		}).Result;
		var seasonInfo = Web.Load("/season/info", new Dictionary<string, string> {
			{ "language", "en" },
			{ "version", "0" },
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		}).Result;
		var activeLeaderboard = Web.Load("/leaderboards/getBoardActive", new Dictionary<string, string> {
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		}).Result;
		var dailyLoginCalendar = Web.Load("/dailyLogin/fetchCalendar", new Dictionary<string, string> {
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		}).Result;
		var accountList0 = Web.Load("/account/list", new Dictionary<string, string> {
			{ "type", "0" }, //todo: account list constants
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		}).Result;
		var friendRequests = Web.Load("/friends/getRequests", new Dictionary<string, string> {
			{ "targetName", "" },
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		}).Result;
		var accountList1 = Web.Load("/account/list", new Dictionary<string, string> {
			{ "type", "1" }, //todo: account list constants
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		}).Result;
		var publicStatDataPowerUp = Web.Load("/app/publicStaticData", new Dictionary<string, string> {
			{ "dataType", "powerUpSettings" },
			{ "version", "0" },
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		}).Result;
		var powerUpStats = Web.Load("/account/listPowerUpStats", new Dictionary<string, string> {
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		}).Result;
		var publicStatDataKeyRefine = Web.Load("/app/publicStaticData", new Dictionary<string, string> {
			{ "dataType", "keyRefineSettings" },
			{ "version", "0" },
			{ "accessToken", Uri.EscapeDataString(AccessToken) },
		}).Result;
	}

	public bool ParseAccountVerify(string xml) {
		XmlSerializer serializer = new(typeof(RealmClient.AppEngineXml.Account));
		using StringReader reader = new(xml);
		var account = (RealmClient.AppEngineXml.Account)serializer.Deserialize(reader);
		if (account == null) {
			return false;
		}

		AccessToken = account.AccessToken;
		return true;
	}
}