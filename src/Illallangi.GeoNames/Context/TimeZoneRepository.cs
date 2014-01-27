namespace Illallangi.GeoNames.Context
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    using NodaTime;

    public sealed class TimeZoneRepository
    {
        public IEnumerable<string> GetTzdb(string timezone = "%")
        {
            var regex = new Regex(timezone.Replace(@"%", @".*").Replace(@"_", @"."), RegexOptions.Compiled);

            return DateTimeZoneProviders.Tzdb.Ids.Where(tz => regex.IsMatch(tz));
        }
    }
}
