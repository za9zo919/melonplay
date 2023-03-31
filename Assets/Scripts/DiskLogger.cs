using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiskLogger : MonoBehaviour
{
	private StreamWriter writer;

	private const string dir = "Logs\\";

	private void Awake()
	{
		if (!Directory.Exists("Logs\\"))
		{
			Directory.CreateDirectory("Logs\\");
		}
		writer = new StreamWriter(GetPath());
		UnityEngine.Debug.Log("Timestamp: " + DateTime.UtcNow.ToString());
		UnityEngine.Debug.Log("Current version: 1.25 preview 3");
		Application.logMessageReceived += LogMessageReceived;
	}

	private void LogMessageReceived(string condition, string stackTrace, LogType type)
	{
		writer.Write(Math.Round(Time.unscaledTime, 2));
		writer.Write(' ');
		writer.Write(GetPrefix(type));
		writer.Write(' ');
		writer.Write(condition);
		if (type != LogType.Log && !string.IsNullOrWhiteSpace(stackTrace))
		{
			writer.WriteLine();
			writer.Write('\t');
			writer.WriteLine(stackTrace);
		}
		writer.WriteLine();
	}

	private static string GetPrefix(LogType type)
	{
		switch (type)
		{
		case LogType.Error:
			return "[ERROR]";
		case LogType.Assert:
			return "[ASSERT]";
		case LogType.Warning:
			return "[WARNING]";
		case LogType.Log:
			return "[LOG]";
		case LogType.Exception:
			return "[EXCEPTION]";
		default:
			return "[UNKNOWN]";
		}
	}

	private void OnDestroy()
	{
		writer.Dispose();
		Application.logMessageReceived -= LogMessageReceived;
	}

	private string GetPath()
	{
		return "Logs\\" + DateTimeOffset.Now.ToUnixTimeSeconds().ToString() + "-" + SceneManager.GetActiveScene().name + ".log";
	}
}
