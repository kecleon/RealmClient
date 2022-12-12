using System.Text;
using AssetStudio;
using RealmClient.Util;

namespace RealmClient.Data;

public static class Unity {
	public static bool ReadAssets() {
		if (!File.Exists(Path.Combine(Constants.RealmPath, "RotMG Exalt_Data", "resources.assets"))) {
			Log.Info($"Please install RotMG to {Constants.RealmPath}");
			return false;
		}

		string spritesheetJson = string.Empty;
		Dictionary<string, byte[]> spritesheets = new() {
			{ "characters", new byte[0] },
			{ "characters_masks", new byte[0] },
			{ "mapObjects", new byte[0] },
			{ "groundTiles", new byte[0] },
		};

		AssetsManager manager = new();
		manager.LoadFolder(Constants.RealmPath);

		foreach (SerializedFile set in manager.assetsFileList) {
			foreach (AssetStudio.Object file in set.Objects) {
				if (file is TextAsset text && text.m_Name == "spritesheet") {
					spritesheetJson = Encoding.Default.GetString(text.m_Script);
				} else if (file is Texture2D texture && spritesheets.ContainsKey(texture.m_Name)) {
					spritesheets[texture.m_Name] = new byte[texture.image_data.Size];
					texture.image_data.GetData(spritesheets[texture.m_Name]);
				}
			}
		}

		return spritesheetJson.Length != 0 && spritesheets.Values.All(bytes => bytes.Length != 0);
	}
}