namespace Illallangi.GeoNames.Tests
{
    using System;
    using System.Diagnostics;

    using Illallangi.GeoNames.Clients;

    using NUnit.Framework;

    [TestFixture]
    public class TimeZoneClientTests
    {
        private TimeZoneClient Client { get; set; }

        [SetUp]
        public void Setup()
        {
            this.Client = new TimeZoneClient(new TestConfig());
        }

        [Test]
        public void CanberraTimeZoneFromLatitude()
        {
            var timeZone = this.Client.GetTimeZone(-35.3075, 149.124417);

            Assert.NotNull(timeZone.Time);
            Assert.AreEqual("Australia", timeZone.CountryName);
            Assert.NotNull(timeZone.Sunset);
            Assert.AreEqual(10, timeZone.RawOffset);
            Assert.AreEqual(10, timeZone.DstOffset);
            Assert.AreEqual("AU", timeZone.CountryCode);
            Assert.AreEqual(11, timeZone.GmtOffset);
            Assert.AreEqual(149.124417, timeZone.Longitude);
            Assert.NotNull(timeZone.Sunrise);
            Assert.AreEqual("Australia/Sydney", timeZone.TzdbId);
            Assert.AreEqual(-35.3075, timeZone.Latitude);
        }
    }
}
