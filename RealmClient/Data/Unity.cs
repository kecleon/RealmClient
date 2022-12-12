using System.Text;
using AssetStudio;
using RealmClient.Sounds;
using RealmClient.Util;
using Object = AssetStudio.Object;

namespace RealmClient.Data;

public static class Unity {
	public static bool ReadAssets() {
		if (!File.Exists(Path.Combine(Constants.RealmPath, "RotMG Exalt_Data", "resources.assets"))) {
			Log.Info($"Please install RotMG to {Constants.RealmPath}");
			return false;
		}

		//init
		AssetsManager manager = new();
		manager.LoadFolder(Constants.RealmPath);
		//read file containers so we can automatically find all xmls and other asset directories ("containers")
		(NamedObject, string)[] files = ReadContainers(manager);
		ReadDataAssets(files);
		return true;
	}

	private static (NamedObject, string)[] ReadContainers(AssetsManager manager) {
		//copied stuff from AssetStudioGUI.Studio.BuildAssetData() where it creates a Container string used for the table that shows what Container each file belongs to
		
		//store an asset pointer along with a container string
		var containers = new List<(PPtr<Object>, string)>();
		foreach (SerializedFile set in manager.assetsFileList) {
			foreach (Object file in set.Objects) {
				if (file is AssetBundle bundle) {
					foreach (var m_Container in bundle.m_Container) {
						var preloadIndex = m_Container.Value.preloadIndex;
						var preloadSize = m_Container.Value.preloadSize;
						var preloadEnd = preloadIndex + preloadSize;
						for (int k = preloadIndex; k < preloadEnd; k++) {
							containers.Add((bundle.m_PreloadTable[k], m_Container.Key));
						}
					}
				} else if (file is ResourceManager resource) {
					foreach (var m_Container in resource.m_Container) {
						containers.Add((m_Container.Value, m_Container.Key));
					}
				}
			}
		}
		
		//filter for NamedObjects
		List<(NamedObject, string)> files = new();
		foreach ((var pptr, var container) in containers) {
			if (pptr.TryGet(out var obj) && obj is NamedObject named) {
				files.Add((named, container));
			}
		}

		return files.ToArray();
	}

	public static void ReadDataAssets((NamedObject, string)[] files) {
		foreach ((NamedObject file, string container) in files) {
			if (file is TextAsset text) {
				HandleTextAsset(text, container);
			} else if (file is Texture2D texture) {
				HandleTextureAsset(texture);
			} else if (file is AudioClip audio) {
				HandleAudioAsset(audio, container);
			}
		}
	}

	private static void HandleTextAsset(TextAsset text, string container) {
		if (container.StartsWith("xml/")) {
			XmlData.RawXmls.Add($"{container}/{text.m_Name}", Encoding.Default.GetString(text.m_Script));
		} else if (text.m_Name == "spritesheet") {
			Textures.SpritesheetJson = Encoding.Default.GetString(text.m_Script);
		}
	}

	private static void HandleTextureAsset(Texture2D texture) {
		switch (texture.m_Name) {
			case "characters":
				SaveBytes(ref Textures.Characters);
				break;
			case "characters_masks":
				SaveBytes(ref Textures.CharactersMask);
				break;
			case "mapObjects":
				SaveBytes(ref Textures.MapObjects);
				break;
			case "groundTiles":
				SaveBytes(ref Textures.GroundTiles);
				break;
		}

		void SaveBytes(ref byte[] output) {
			output = new byte[texture.image_data.Size];
			texture.image_data.GetData(output);
		}
	}

	private static void HandleAudioAsset(AudioClip audio, string container) {
		if (container.StartsWith("sounds/sounds/")) {
			Sound.SoundEffects.Add(audio.m_Name, audio.m_AudioData);
		}
	}
}