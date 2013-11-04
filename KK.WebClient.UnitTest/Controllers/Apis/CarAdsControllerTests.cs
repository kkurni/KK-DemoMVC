using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using KK.Domain.Models;
using KK.Domain.Services.Interfaces;
using KK.WebClient.Controllers;
using KK.WebClient.Controllers.Apis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace KK.WebClient.UnitTest
{
    [TestClass]
    public class CarAdsControllerTests
    {
        private CarAdsController _controllerTotest;
        private Mock<ICarAdsService> _mockCarAdsService;

        [TestInitialize]
        public void TestInit()
        {
            _mockCarAdsService = new Mock<ICarAdsService>();
            _controllerTotest = new CarAdsController(_mockCarAdsService.Object);

        }
        [TestMethod]
        public void Get_ShouldCallRepository()
        {
            //Arrange
            _mockCarAdsService.Setup(t => t.GetAll()).Returns(new List<CarAds>() { new CarAds() });

            //Act
            var results = _controllerTotest.Get();

            //Assert
            Assert.AreEqual(1, results.Count());
            _mockCarAdsService.VerifyAll();
        }

        [TestMethod]
        public void GetById_ShouldCallRepository()
        {
            //Arrange
            var testGuid = Guid.NewGuid();
            _mockCarAdsService.Setup(t => t.GetById(testGuid)).Returns(new CarAds());

            //Act
            var result = _controllerTotest.Get(testGuid);

            //Assert
            Assert.IsNotNull(result);
            _mockCarAdsService.VerifyAll();
        }
    }
}
