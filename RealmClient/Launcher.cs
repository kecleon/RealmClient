// This file is part of Silk.NET.
//
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


namespace RealmClient;

public class RealmClient {
	public static string ProfilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "/RealmClient/");  

	public static void Main(string[] args) {
		Log.Info("Loading Realm Client");
		Time.Update();
		Settings.LoadSettings();
		Render.Run();
	}
}