using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimplySecureLocal.Data.Models;
using System;

namespace SimplySecureLocal.Tests
{
    [TestClass]
    public class SimplySecureLocal
    {
        [TestMethod]
        [ExpectedException(typeof(System.FormatException))]
        public void InvalidGuid()
        {
            const string moduleId = "not_a_guid";

            var heartbeat = new Heartbeat
            {
                ModuleId = Guid.Parse(moduleId),

                State = true
            };
        }

        [TestMethod]
        public void ValidGuid()
        {
            const string moduleId = "ab843dae-05d0-4031-b585-781b724659b3";

            var heartbeat = new Heartbeat
            {
                ModuleId = Guid.Parse(moduleId),

                State = true
            };

            Assert.AreEqual(heartbeat.ModuleId.ToString().ToUpper(), moduleId.ToUpper());
        }
    }
}