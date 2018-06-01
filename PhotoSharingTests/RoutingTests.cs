using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Routing;
using System.Web.Mvc;
using PhotoSharingTests.Doubles;
using PhotoSharingApp;

namespace PhotoSharingTests
{
    [TestClass]
    public class RoutingTests
    {
        [TestMethod]
        public void Test_Default_Route_ControllerOnly()
        {
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
        }
    }
}
