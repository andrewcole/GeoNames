namespace Illallangi.GeoNames.Tests
{
    using System.Collections.Generic;

    using Illallangi.GeoNames.Config;

    public class TestConfig : IGeoNamesConfig
    {
        private readonly string currentBaseUrl;

        private readonly string currentUserName;

        public TestConfig(string userName = @"illallangi", string baseUrl = @"http://api.geonames.org")
        {
            this.currentUserName = userName;
            this.currentBaseUrl = baseUrl;
        }

        public string BaseUrl
        {
            get { return this.currentBaseUrl; }
        }

        private string UserName
        {
            get { return this.currentUserName; }
        }

        public IEnumerable<KeyValuePair<string, string>> GetDefaultParameters()
        {
            yield return new KeyValuePair<string, string>(@"username", this.UserName);
        }
    }
}