﻿namespace RealmClient.Util;

public static class Log {
	private static string StatusLog = "Initializing";
	private static DateTime StatusSetAt = DateTime.Now;
	private static FileStream LogFile;
	private static StreamWriter LogStream;

	private const string DefaultLogFilename = "log-{0}.txt";

	static Log() {
		string path = Path.Combine(Constants.ProfilePath, "Logs\\");
		if (!Directory.Exists(path)) {
			Directory.CreateDirectory(path);
		}

		LogFile = new FileStream(path + string.Format(DefaultLogFilename, DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")), FileMode.CreateNew);
		LogStream = new StreamWriter(LogFile);
	}

	public static void Info(string message) {
		message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ": " + message;

#if DEBUG
		Console.WriteLine(message);
#endif

		LogStream.WriteAsync(message);
	}

	public static void Status(string message) {
		StatusLog = message;
		StatusSetAt = DateTime.Now;
	}

	public static string GetStatus() {
		int ms = (int)DateTime.Now.Subtract(StatusSetAt).TotalMilliseconds;
		return $"{StatusLog} ({ms})";
	}
}