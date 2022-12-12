namespace RealmClient; 

public static class Constants {
	public static readonly string ProfilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RealmClient\\");
	public static readonly string RealmPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RealmOfTheMadGod\\Production");
}