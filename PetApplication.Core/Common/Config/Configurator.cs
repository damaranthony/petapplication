using System.Configuration;

namespace PetApplication.Core.Common.Config
{
    public static class Configurator
    {
        public static string Base_Api
        {
            get
            {
                return Get("BASE_API");
            }
        }

        public static string People_Api
        {
            get
            {
                return Get("PEOPLE_API");
            }
        }

        public static string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
