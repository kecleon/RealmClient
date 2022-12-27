using System.Text;
using System.Xml.Serialization;
using RealmClient.Data;
using RealmClient.Structures;
using RealmClient.Util;

namespace RealmClient.Assets;

public static class XmlData {
	public static Dictionary<string, string> RawXmls = new();
	public static bool ParseXmls() {
		const string manifestPath = "xml/assets_manifest/assets_manifest";
		if (!RawXmls.ContainsKey(manifestPath)) {
			Log.Info($"Failed reading asset manifest xml");
			return false;
		}

		SaveXmls();

		string manifestXml = RawXmls[manifestPath];

		Log.Status("Parsing Manifest");
		XmlSerializer serializer = new(typeof(Manifest));
		using StringReader reader = new(manifestXml);
		//Manifest manifest = (Manifest)serializer.Deserialize(reader);
		const string xmlHeader = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n";
		foreach (var pair in RawXmls) {
			var xml = RawXmls[pair.Key].After(xmlHeader);
			if (xml.StartsWith("<Objects>")) {
				Log.Status($"Parsing objects {pair.Key}");
				ObjectLibrary.Parse(xml);
			} else if (xml.StartsWith("<GroundTypes>")) {
				Log.Status($"Parsing tiles {pair.Key}");
				TileLibrary.Parse(xml);
			}
		}
		
		Log.Status("Finished parsing assets");

		return true;
	}

	public static void SaveXmls() {
		foreach (var xml in RawXmls) {
			var name = xml.Key + ".xml";
			var path = Path.GetDirectoryName(name);
			if (!Directory.Exists(path)) {
				Directory.CreateDirectory(path);
			}

			File.WriteAllText(name, xml.Value);
		}
	}
}