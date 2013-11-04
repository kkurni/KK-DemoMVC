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
    public class AdsControllerTests
    {
        private AdsController _controllerTotest;
        private Mock<ICarAdsService> _mockCarAdsService;

        [TestInitialize]
        public void TestInit()
        {
            _mockCarAdsService = new Mock<ICarAdsService>();
            _controllerTotest = new AdsController(_mockCarAdsService.Object);

        }

        [TestMethod]
        public void Index_ShouldReturnCollectionOfAds()
        {
            //Arrange
            var expectedData = new List<CarAds> {new CarAds()};
            _mockCarAdsService.Setup(t => t.GetAll()).Returns(expectedData);

            //Act
            var result = _controllerTotest.Index() as ViewResult;

            //Assert
            Assert.AreEqual(expectedData, result.Model);            
            _mockCarAdsService.VerifyAll();
        }

        [TestMethod]
        public void Detail_ShouldReturnCollectionOfAds()
        {
            //Arrange
            var guidToTest = Guid.NewGuid();
            var expectedData = new CarAds();
            _mockCarAdsService.Setup(t => t.GetById(guidToTest)).Returns(expectedData);

            //Act
            var result = _controllerTotest.Detail(guidToTest) as ViewResult;

            //Assert
            Assert.AreEqual(expectedData, result.Model);
            _mockCarAdsService.VerifyAll();
        }
    }
}
