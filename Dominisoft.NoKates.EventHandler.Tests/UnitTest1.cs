using System;
using Dominisoft.Nokates.Common.Infrastructure.Helpers;
using Dominisoft.NoKates.EventHandler.Common.Clients;
using Dominisoft.NoKates.EventHandler.Common.Models;
using NUnit.Framework;

namespace Dominisoft.NoKates.EventHandler.Tests
{
    public class Tests
    {
        private const string serviceRootUri = "http://wkservices-dev.wardkraft.com";
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var client = new EventClient(serviceRootUri);
            HttpHelper.SetToken("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiIwZjcxMTg4ZC0xZjM4LTQ1ZTMtYjNmZC00OWUxZDM1Zjg2YjciLCJ2YWxpZCI6IjEiLCJ1c2VyaWQiOiIxMCIsIm5hbWUiOiJjc21pdGggICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIiwiZW5kcG9pbnRfcGVybWlzc2lvbiI6WyIiLCIiXSwicm9sZV9uYW1lIjoiQWRtaW4gICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICIsImV4cCI6MTY2MjU2MjY4NiwiaXNzIjoiaHR0cDovL215c2l0ZS5jb20iLCJhdWQiOiJodHRwOi8vbXlzaXRlLmNvbSJ9.t6d8n4nAA4KDM7qWCtN6k6b9vN9ZoVmIUmB-WTatVNY");
            var registered = client.RegisterListener("UnitTests");
            var message = new EventMessage
                { Domain = "UnitTesting",EntityName = "Test",Entity = "{}", EventName = "Started", EventTime = DateTime.Now, AdditionalDetails = "{}", Id = 0,};
            client.PublishEvent(message);
            var messages = client.GetEvents("UnitTests", true);
            
            Assert.AreEqual(1, messages.Count);
        }
    }
}