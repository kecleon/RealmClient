namespace RealmClient; 

public class Account {
	public string Guid;
	public string Password;
	public string AccessToken;
	public string CharList;
	public string AccountVerify;

	public void Load(string path) {
		var parameters = new Dictionary<string, string>();
		parameters.Add("accessToken", Uri.EscapeDataString(AccessToken));
		Web.Load(path, parameters);
	}
}