namespace Illallangi.GeoNames.Model
{
    using System;

    using Newtonsoft.Json;

    public sealed class GeoNamesTimeZone
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lng")]
        public double Longitude { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("countryName")]
        public string CountryName { get; set; }

        [JsonProperty("rawOffset")]
        public int RawOffset { get; set; }

        [JsonProperty("gmtOffset")]
        public int GmtOffset { get; set; }

        [JsonProperty("dstOffset")]
        public int DstOffset { get; set; }

        [JsonProperty("sunrise")]
        public DateTime Sunrise { get; set; }

        [JsonProperty("sunset")]
        public DateTime Sunset { get; set; }

        [JsonProperty("time")]
        public DateTime Time { get; set; }

        [JsonProperty("timezoneId")]
        public string TzdbId { get; set; }
    }
}