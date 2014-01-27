namespace Illallangi.GeoNames.PowerShell
{
    using System.Collections.Generic;
    using System.Configuration;

    using Illallangi.GeoNames.Config;

    public sealed class GeoNamesConfig : ConfigurationSection, IGeoNamesConfig
    {

        [ConfigurationProperty("BaseUrl", DefaultValue = @"http://api.geonames.org")]
        public string BaseUrl
        {
            get
            {
                return (string)this["BaseUrl"];
            }
        }

        [ConfigurationProperty("UserName", IsRequired = true)]
        public string UserName
        {
            get
            {
                return (string)this["UserName"];
            }
        }

        public IEnumerable<KeyValuePair<string, string>> GetDefaultParameters()
        {
            yield return new KeyValuePair<string, string>(@"username", this.UserName);
        }
    }
}
