namespace RealmClient.Util;

public static class Log {
	private static FileStream LogFile;
	private static StreamWriter LogStream;

	private const string DefaultLogFilename = "log-{0}.txt";

	static Log() {
		LogFile = new FileStream(Path.Combine(Constants.ProfilePath, string.Format(DefaultLogFilename, DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"))), FileMode.CreateNew);
		LogStream = new StreamWriter(LogFile);
	}

	public static void Info(string message) {
		message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ": " + message;

#if DEBUG
		Console.WriteLine(message);
#endif

		LogStream.WriteAsync(message);
	}
}