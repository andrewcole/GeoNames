﻿namespace Illallangi.GeoNames.PowerShell.TimeZone
{
    using System.Management.Automation;

    using Illallangi.GeoNames.Clients;

    using Ninject;

    [Cmdlet(VerbsCommon.Get, Nouns.TimeZone)]
    public sealed class GetTimeZoneCmdlet : NinjectCmdlet<GeoNamesModule>
    {
        public GetTimeZoneCmdlet()
            : base(new NinjectSettings() { AllowNullInjection = true })
        {
        }

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateRange(-90, 90)]
        public double Latitude { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        [ValidateRange(-180, 180)]
        public double Longitude { get; set; }

        protected override void ProcessRecord()
        {
            this.WriteObject(this.Get<TimeZoneClient>().GetTimeZone(this.Latitude, this.Longitude));
        }
    }
}
