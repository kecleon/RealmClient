using RealmClient.Util;

namespace RealmClient;

public class RealmClient {
	public static string ProfilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "/RealmClient/");  

	public static void Main(string[] args) {
		Log.Info("Loading Realm Client");
		Time.Update();
		Settings.Init(ProfilePath);
		Render.Graphics.Run();
	}
}