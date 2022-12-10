using System.Text;

namespace RealmClient;

public static class Log {
	//lock for buffer
	private static object logSync = new();

	// Buffer to hold the log messages
	private static List<string> logBuffer = new();
	private static List<string> logBufferTemp = new();
	private static StringBuilder sb = new();

	// File name for the log file
	private static string logFilename;

	// Timer to periodically write the log messages to the file
	private static Timer logTimer;

	// Default log file name
	private const string DEFAULT_LOG_FILENAME = "log-{0}.txt";

	// Default log write interval
	private const int DEFAULT_LOG_WRITE_INTERVAL = 1000; // 1 second

	// Constructor
	static Log() {
		// Set the log file name
		logFilename = string.Format(DEFAULT_LOG_FILENAME, DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));

		// Create a timer to periodically write the log messages to the file
		logTimer = new Timer(WriteLog, null, DEFAULT_LOG_WRITE_INTERVAL, DEFAULT_LOG_WRITE_INTERVAL);
		
	}

	// Method to log a message
	public static void Info(string message) {
		// Add the current time to the log message
		message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ": " + message;

		// Write the message to the console
		Console.WriteLine(message);

		lock (logSync) {
			// Add the message to the log buffer
			logBuffer.Add(message);
		}
	}

	// Method to write the log messages to the file
	private static void WriteLog(object? sender) {
		lock (logSync) {
			// Check if there are any messages in the buffer
			if (logBuffer.Count > 0) {
				logBufferTemp.Clear();

				// Loop through the log messages in the buffer
				foreach (string message in logBuffer) {
					logBufferTemp.Add(message);
				}

				// Clear the log buffer
				sb.Clear();
				logBuffer.Clear();
			}
		}

		if (logBufferTemp.Count > 0) {
			// Write the log messages to the file
			foreach (string message in logBufferTemp) {
				sb.AppendLine(message);
			}

			File.AppendAllText(logFilename, sb.ToString());
			logBufferTemp.Clear();
		}
	}
}