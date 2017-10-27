// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace EmpTrack.Helpers
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        private const string NameKey = "name_key";
        private const string EmailKey = "email_key";
        private const string DomainKey = "domain_key";

        #endregion


        public static string GeneralSettings
		{
			get
			{
				return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(SettingsKey, value);
			}
        }
        public static string UserName
        {
            get
            {
                return AppSettings.GetValueOrDefault(NameKey, string.Empty);
            }
            set
            {
                AppSettings.AddOrUpdateValue(NameKey, value);
            }
        }

        public static string Email
        {
            get
            {
                return AppSettings.GetValueOrDefault(EmailKey, string.Empty);
            }
            set
            {
                AppSettings.AddOrUpdateValue(EmailKey, value);
            }
        }

        public static int DomainType
        {
            get
            {
                return AppSettings.GetValueOrDefault(DomainKey, 1);
            }
            set
            {
                AppSettings.AddOrUpdateValue(DomainKey, value);
            }
        }

    }
}