namespace Archimedes.Common.Logging
{
	using Settings;

	using NLog;

	public class NLogLogger : ILogger
	{
		private readonly Logger logger;
		private readonly string applicationName;
		private readonly string applicationInstance;

		public NLogLogger(ISettings settings)
		{
			this.applicationName = settings.ApplicationName;
			this.applicationInstance = settings.ApplicationInstance;
			this.logger = LogManager.GetLogger(this.applicationName);
		}

		public void Trace(string message, object metadata)
		{
			this.WriteLogEntry(LogLevel.Trace, message, metadata);
		}

		public void Debug(string message, object metadata)
		{
			this.WriteLogEntry(LogLevel.Debug, message, metadata);
		}

		public void Info(string message, object metadata)
		{
			this.WriteLogEntry(LogLevel.Info, message, metadata);
		}

		public void Warn(string message, object metadata)
		{
			this.WriteLogEntry(LogLevel.Warn, message, metadata);
		}

		public void Error(string message, object metadata)
		{
			this.WriteLogEntry(LogLevel.Error, message, metadata);
		}

		public void Fatal(string message, object metadata)
		{
			this.WriteLogEntry(LogLevel.Fatal, message, metadata);
		}

		private void WriteLogEntry(LogLevel level, string message, object metadata)
		{
			var logEvent = new LogEventInfo(level, this.applicationName, message);
			logEvent.Properties["Metadata"] = metadata;
			logEvent.Properties["EventId"] = message;
			logEvent.Properties["InstanceName"] = this.applicationInstance;
			this.logger.Log(typeof(NLogLogger), logEvent);
		}
	}
}