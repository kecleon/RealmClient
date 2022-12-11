using System.Text;

namespace RealmClient.Util;

public static class Settings {
	// Dictionary to store the settings and their values
	private static Dictionary<string, object> settingsDict = new ();
	private static string Filename = string.Empty;

	static Settings() {
		Filename = Path.Combine(Constants.ProfilePath, "settings.txt");
		if (!File.Exists(Filename)) {
			File.Create(Filename);
		}

		LoadSettings();
	}

	// Method to add a new setting with a given value
	public static void AddSetting(string name, object value) {
		if (!settingsDict.ContainsKey(name)) {
			settingsDict.Add(name, value);
		}
	}

	// Method to remove a setting
	public static void RemoveSetting(string name) {
		if (settingsDict.ContainsKey(name)) {
			settingsDict.Remove(name);
		}
	}

	// Method to retrieve the value of a setting
	public static object GetSetting(string name) {
		if (settingsDict.ContainsKey(name)) {
			return settingsDict[name];
		} else {
			return null;
		}
	}

	// Method to load the settings from a file
	public static void LoadSettings() {
		// Check if the file exists
		if (File.Exists(Filename)) {
			// Read the file into a string
			string fileContent = File.ReadAllText(Filename);

			// Split the string into individual setting-value pairs
			string[] settings = fileContent.Split(",");

			// Loop through the setting-value pairs
			foreach (string setting in settings) {
				// Split the setting-value pair into the setting name and value
				string[] settingPair = setting.Split(":");

				// Check if the setting name and value are valid
				if (settingPair.Length == 2 && !string.IsNullOrEmpty(settingPair[0]) && !string.IsNullOrEmpty(settingPair[1])) {
					// Add the setting to the dictionary
					settingsDict.Add(settingPair[0], settingPair[1]);
				}
			}
		}
	}

	// Method to save the settings to a file
	public static void SaveSettings() {
		// Create a string builder to hold the settings
		StringBuilder sb = new StringBuilder();

		// Loop through the settings in the dictionary
		foreach (KeyValuePair<string, object> setting in settingsDict) {
			// Add the setting name and value to the string builder
			sb.Append(setting.Key + ":" + setting.Value + ",");
		}

		// Write the string builder to the file
		File.WriteAllText(Filename, sb.ToString());
	}
}