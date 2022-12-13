using RealmClient.Data;
using RealmClient.Render;
using RealmClient.Util;

namespace RealmClient;

public class Launcher {
	public static void Main(string[] args) {
		if (!Directory.Exists(Constants.ProfilePath)) {
			Directory.CreateDirectory(Constants.ProfilePath);
		}

		Log.Info("Loading Realm Client");
		Time.Update();
		if (!Unity.ReadAssets()) {
			Log.Info($"Failed parsing assets properly, client unable to function");
			//start lite gui? or exit? gui with just warning?
		}

		Settings.ClientSettings = new Settings("ClientSettings");
		Settings.AccountSettings = new Settings("Account");
		Settings.AccountSettings.SaveSettings();
		Account account = new();
		Client client = new(account);
		account.LoadLauncherUrls();
		account.LoadLauncherPlayUrls();
		account.LoadClientUrls();
		Graphics.Run();
	}
}