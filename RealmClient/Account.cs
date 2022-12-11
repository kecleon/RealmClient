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