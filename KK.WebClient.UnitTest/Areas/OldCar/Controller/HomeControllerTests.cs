using System;
using System.Collections.Generic;
using System.Web.Mvc;
using KK.Domain.Models;
using KK.Domain.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace KK.WebClient.Areas.oldCar.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {

        private HomeController _controllerTotest;

        [TestInitialize]
        public void TestInit()
        {
            _controllerTotest = new HomeController();

        }

        [TestMethod]
        public void Index_ShouldReturnView()
        {        
            //Act
            var result = _controllerTotest.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
