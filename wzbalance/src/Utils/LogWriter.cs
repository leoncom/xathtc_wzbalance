using System;
using System.IO;
namespace wzbalance
{
	class LogWriter
	{
		private static string[] LevelEnum = new string[] {
			"info",
			"warning",
			"error"
		};

		public static void LogEntry(string logLevel, string message)
		{
			int i;
			for (i = 0; i < LogWriter.LevelEnum.Length; i++) {
				if (logLevel == LogWriter.LevelEnum[i]) {
					break;
				}
			}
			if (i == LogWriter.LevelEnum.Length) {
				logLevel = "other";
			}
			if (!Directory.Exists("./log")) {
				Directory.CreateDirectory("./log");
			}
			string path = "./log/" + DateTime.Now.ToString("yyyy-MM") + "_" + logLevel + ".txt";
			StreamWriter streamWriter = new StreamWriter(path, true);
			streamWriter.WriteLine("[" + DateTime.Now.ToLocalTime() + "] " + message);
			streamWriter.Close();
		}
	}
}

