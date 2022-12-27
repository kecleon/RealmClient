using ImGuiNET;
using RealmClient.Assets;
using RealmClient.Render;
using RealmClient.Scenes;
using RealmClient.Util;

namespace RealmClient;

public class Launcher {
	public static Scene Scene = new DemoScene();
	public static Thread RenderThread;
	public static Client Client;
	
	public static unsafe void Main(string[] args) {
		if (!Directory.Exists(Constants.ProfilePath)) {
			Directory.CreateDirectory(Constants.ProfilePath);
		}

		RenderThread = new Thread(() => {
			Graphics.Scene = new LoadingScene();
			Graphics.Run();
		});
		RenderThread.Start();

		Log.Info("Loading Realm Client");
		
		Time.Update();
		if (!Unity.ReadAssets()) {
			Log.Info($"Failed parsing assets properly, client unable to function");
			//start lite gui? or exit? gui with just warning?
		}

		Log.Status("Reading Account data");
		Settings.ClientSettings = new Settings("ClientSettings");
		Settings.AccountSettings = new Settings("Account");
		Settings.AccountSettings.AddOrUpdateSetting("GUID", "ertert");
		Settings.AccountSettings.AddOrUpdateSetting("Password", "ertert");
		Settings.AccountSettings.SaveSettings();
		Log.Status("Parsing XMLs");
		XmlData.ParseXmls();

		Account.LoadLauncheBaseUrls();
		var account = Account.AccountFromSettings();
		if (account is not null) {
			if (account.TryLauncherLogin()) {
				account.LoadLauncherAccountUrls();
			}

			Graphics.Scene = new MainScene();
			account.LoadLauncherPlayUrls();
			account.LoadClientUrls();
		} else {
			Graphics.Scene = new LoginScene();
		}

		Client = new(account);
	}
}