namespace Illallangi.GeoNames.PowerShell
{
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Reflection;

    using Common.Logging;
    using Common.Logging.Log4Net;

    using Illallangi.ETagCache.Context;
    using Illallangi.GeoNames.Clients;
    using Illallangi.GeoNames.Config;
    using Illallangi.GeoNames.Context;

    using log4net.Config;

    using Ninject.Modules;

    public sealed class GeoNamesModule : NinjectModule
    {
        public override void Load()
        {
            LogManager.Adapter = new Log4NetLoggerFactoryAdapter(new NameValueCollection { { "configType", "EXTERNAL" } });

            XmlConfigurator.Configure(
                Assembly
                    .GetExecutingAssembly()
                    .GetManifestResourceStream(
                        string.Format(
                            "{0}.Log4Net.config",
                            Assembly.GetExecutingAssembly().GetName().Name)));

            this.Bind<IGeoNamesConfig>()
                .ToMethod(
                    cx =>
                        (GeoNamesConfig)
                            ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location)
                                .GetSection("GeoNamesConfig")).InSingletonScope();

            this.Bind<TimeZoneRepository>().To<TimeZoneRepository>().InSingletonScope();
            this.Bind<TimeZoneClient>().To<TimeZoneClient>().InSingletonScope();

            this.Bind<IRestCache>().To<CacheEntryRepository>().InTransientScope();

            this.Bind<ILog>().ToMethod(cx => LogManager.GetLogger(cx.Request.Target.Type));
        }
    }
}