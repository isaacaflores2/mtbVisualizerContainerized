using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StravaVisualizer.Controllers;

namespace StravaVisualizerTest
{
    [TestClass]
    public class ErrorControllerTest
    {
        [TestMethod]
        public void Test_Index()
        {
            ErrorController controller = new ErrorController();

            var result = controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void Test_PageNotFound()
        {
            ErrorController controller = new ErrorController();

            var result = controller.PageNotFound() as ViewResult;

            Assert.AreEqual("PageNotFound", result.ViewName);
        }
    }
}
