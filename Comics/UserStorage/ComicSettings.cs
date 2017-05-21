using System;

namespace Comics.UserStorage
{
    public class ComicSettings
    {
        public string Key { get; }

        public Uri LastViewedUri
        {
            get
            {
                var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                var settings = localSettings.CreateContainer(Key, Windows.Storage.ApplicationDataCreateDisposition.Always);

                settings.Values.TryGetValue(SettingsKeys.LastViewedKey, out object retrieved);

                if (retrieved == null)
                {
                    return null;
                }
                else
                {
                    var uriString = retrieved as string;
                    return uriString == null ? null : new Uri(uriString);
                }
            }
            set
            {
                var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                var settings = localSettings.CreateContainer(Key, Windows.Storage.ApplicationDataCreateDisposition.Always);

                settings.Values[SettingsKeys.LastViewedKey] = value.AbsoluteUri;
            }
        }

        private ComicSettings(string key)
        {
            Key = key;
        }

        public static ComicSettings ExplosmSettings = new ComicSettings("Explosm");
    }
}
