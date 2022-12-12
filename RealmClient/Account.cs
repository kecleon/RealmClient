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
		if (Settings.GetSetting("Secret", out object secret)) {
			Secret = (string)secret;
			Steam = true;
		}

		if (Settings.GetSetting("GUID", out object guid) && Settings.GetSetting("Password", out object password)) {
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

	public void Load(string path) {
		var parameters = new Dictionary<string, string>();
		parameters.Add("accessToken", Uri.EscapeDataString(AccessToken));
		Web.Load(path, parameters);
	}
}