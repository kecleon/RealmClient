using System.Text;

namespace RealmClient.Util;

public class Settings : IDisposable {
	public static Settings ClientSettings;
	public static Settings AccountSettings; //todo: encrypt? no real way to encrypt in any meaningful way because we'll have to decrypt it and send the raw credentials to deca... if only their token system made sense...

	// Dictionary to store the settings and their values
	private Dictionary<string, object> SettingsDict = new();
	private string Filename;

	public Settings(string name) {
		Filename = Path.Combine(Constants.ProfilePath, $"{name}.txt");
		if (!File.Exists(Filename)) {
			using var file = File.Create(Filename);
		}

		LoadSettings();
	}

	// Method to add a new setting with a given value
	public void AddOrUpdateSetting(string name, object value) {
		if (!SettingsDict.ContainsKey(name)) {
			SettingsDict.Add(name, value);
		} else {
			SettingsDict[name] = value;
		}
	}

	// Method to remove a setting
	public void RemoveSetting(string name) {
		if (SettingsDict.ContainsKey(name)) {
			SettingsDict.Remove(name);
		}
	}

	// Method to retrieve the value of a setting
	public bool GetSetting(string name, out object value) {
		if (SettingsDict.ContainsKey(name)) {
			value = SettingsDict[name];
			return true;
		} else {
			value = null;
			return false;
		}
	}

	// Method to load the settings from a file
	public void LoadSettings() {
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
					SettingsDict.Add(settingPair[0], settingPair[1]);
				}
			}
		}
	}

	// Method to save the settings to a file
	public void SaveSettings() {
		// Create a string builder to hold the settings
		StringBuilder sb = new();

		// Loop through the settings in the dictionary
		foreach (KeyValuePair<string, object> setting in SettingsDict) {
			// Add the setting name and value to the string builder
			sb.Append(setting.Key + ":" + setting.Value + ",");
		}

		// Write the string builder to the file
		File.WriteAllText(Filename, sb.ToString());
	}
	public void Dispose() {
		SaveSettings();
		SettingsDict.Clear();
	}
}