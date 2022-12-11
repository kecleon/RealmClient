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
		Graphics.Run();
	}
}