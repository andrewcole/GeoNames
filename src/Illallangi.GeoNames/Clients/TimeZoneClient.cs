namespace Illallangi.GeoNames.Clients
{
    using System.Collections.Generic;
    using System.Globalization;

    using Common.Logging;

    using Illallangi.GeoNames.Config;
    using Illallangi.GeoNames.Model;

    public sealed class TimeZoneClient : RestClient
    {
        private const string GetTimeZoneUri = @"timezoneJSON{?username,lat,lng,radius,date}";

        public TimeZoneClient(IGeoNamesConfig config, IRestCache restCache = null, ILog log = null)
            : base(config.BaseUrl, config.GetDefaultParameters(), restCache, log)
        {
        }

        public GeoNamesTimeZone GetTimeZone(double latitude, double longitude)
        {
            return this.GetObject<GeoNamesTimeZone>(
                TimeZoneClient.GetTimeZoneUri,
                new Dictionary<string, string>
                    {
                        { "lat", latitude.ToString(CultureInfo.InvariantCulture) },
                        { "lng", longitude.ToString(CultureInfo.InvariantCulture) },
                    });
        }
    }
}
