using System.Configuration;

namespace PetApplication.Core.Common.Config
{
    public static class Configurator
    {
        /// <summary>
        /// Main API link from configuration file.
        /// Note: key "BASE_API" from config file 
        /// </summary>
        public static string Base_Api
        {
            get
            {
                return Get("BASE_API");
            }
        }
        /// <summary>
        /// Method link from configuration file.
        /// Note: key "PEOPLE_API" from config file 
        /// </summary>
        public static string People_Api
        {
            get
            {
                return Get("PEOPLE_API");
            }
        }
        /// <summary>
        /// Default media type used for fetching response from API. 
        /// Note: key "DEFAULT_MEDIA_TYPE" from config file 
        /// </summary>
        public static string Default_Media_Type
        {
            get
            {
                return Get("DEFAULT_MEDIA_TYPE");
            }
        }
        /// <summary>
        /// Gets the config value from config file based on the given key
        /// </summary>
        /// <param name="key">Key on AppSettings</param>
        /// <returns>Returns the value of the given key</returns>
        public static string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
