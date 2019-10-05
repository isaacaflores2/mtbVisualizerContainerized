using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using stravaVisualizer.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace StravaVisualizerTest
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Test_Index_Return_View()
        {
            HomeController controller = new HomeController();

            var result = controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void Test_Privacy_Return_View()
        {
            HomeController controller = new HomeController();

            var result = controller.Privacy() as ViewResult;

            Assert.AreEqual("Privacy", result.ViewName);
        }
    }
}
