using System;
using KK.WebClient.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KK.WebClient.UnitTest
{
    [TestClass]
    public class CarAppControllerTests
    {
        private CarAppController _controllerTotest;

        [TestInitialize]
        public void TestInit()
        {
            _controllerTotest = new CarAppController();
        }

        [TestMethod]
        public void Index_ShouldReturnView()
        {
            var result = _controllerTotest.Index();
            Assert.IsNotNull(result);
        }
    }
}
