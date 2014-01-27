namespace Illallangi.GeoNames.Config
{
    using System.Collections.Generic;

    public interface IGeoNamesConfig
    {
        string BaseUrl { get; }

        IEnumerable<KeyValuePair<string, string>> GetDefaultParameters();
    }
}