namespace RealmClient.Util; 

public static class Time {
	public static long LastUpdate = -1;
	public static void Update() {
		DateTimeOffset offset = new DateTimeOffset(DateTime.Now);
		LastUpdate = offset.ToUnixTimeMilliseconds();
	}
}