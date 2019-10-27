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
            ErrorController controler = new ErrorController();

            var result = controler.Index() as ViewResult;

            Assert.AreEqual("Error", result.ViewName);
        }
    }
}
