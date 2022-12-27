using ImGuiNET;
using RealmClient.Assets;
using RealmClient.Render;
using RealmClient.Scenes;
using RealmClient.Util;

namespace RealmClient;

public class Launcher {
	public static Scene Scene = new DemoScene();
	public static Thread RenderThread;
	
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
		
		Account account = new();
		Client client = new(account);
		File.WriteAllText("sheet.json", Textures.SpritesheetJson);
		account.LoadLauncherUrls();
		account.LoadLauncherPlayUrls();
		account.LoadClientUrls();
		Graphics.RunDemo();
	}
}