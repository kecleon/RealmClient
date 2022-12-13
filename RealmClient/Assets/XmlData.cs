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

		string manifestXml = RawXmls[manifestPath];

		XmlSerializer serializer = new(typeof(Manifest));
		using StringReader reader = new(manifestXml);
		Manifest manifest = (Manifest)serializer.Deserialize(reader);
		const string xmlHeader = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
		StringBuilder sb = new();
		sb.AppendLine(xmlHeader);
		sb.AppendLine("<Objects>");
		foreach (ObjectsLibrary library in manifest.ObjectsLibrary) {
			string xml = RawXmls[library.path];
			ObjectLibrary.Parse(xml);
			var trimmed = xml.After(xmlHeader).After("<Objects>").Before("</Objects>", true);
			sb.AppendLine(trimmed);
		}

		sb.AppendLine("</Objects>");
		File.WriteAllText("objectsmerged.xml", sb.ToString());
		sb.Clear();
		sb.AppendLine(xmlHeader);
		sb.AppendLine("<GroundTypes>");

		foreach (TilesLibrary library in manifest.TilesLibrary) {
			string xml = RawXmls[library.path];
			TileLibrary.Parse(xml);
			var trimmed = xml.After(xmlHeader).After("<GroundTypes>").Before("</GroundTypes>", true);
			sb.AppendLine(trimmed);
		}

		sb.AppendLine("</GroundTypes>");
		File.WriteAllText("tilesmerged.xml", sb.ToString());

		return true;
	}

	public static void SaveXmls() {
		foreach (var xml in XmlData.RawXmls) {
			var name = xml.Key + ".xml";
			var path = Path.GetDirectoryName(name);
			if (!Directory.Exists(path)) {
				Directory.CreateDirectory(path);
			}

			File.WriteAllText(name, xml.Value);
		}
	}
}