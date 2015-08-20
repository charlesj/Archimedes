namespace Archimedes.Common.Settings
{
	public interface ISettings
	{
		string ApplicationName { get; }
		string ApplicationInstance { get; }
		void CheckAllSettingForValues();
	}
}