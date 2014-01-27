namespace Illallangi.GeoNames.PowerShell
{
    using System.Configuration;
    using System.Reflection;

    using Illallangi.GeoNames.Clients;
    using Illallangi.GeoNames.Config;
    using Illallangi.GeoNames.Context;
    
    using Ninject.Modules;

    public sealed class GeoNamesModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<TimeZoneRepository>().To<TimeZoneRepository>().InSingletonScope();
            this.Bind<TimeZoneClient>().To<TimeZoneClient>().InSingletonScope();

            this.Bind<IGeoNamesConfig>()
                .ToMethod(
                    cx =>
                        (GeoNamesConfig)
                            ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location)
                                .GetSection("GeoNamesConfig")).InSingletonScope();
        }
    }
}