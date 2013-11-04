using System;
using System.Collections.Generic;
using KK.Domain.Models;
using KK.Domain.Repositories.Interfaces;
using KK.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace KK.Domain.Service.UnitTest
{
    [TestClass]
    public class CarAdsServiceTest
    {
        private CarAdsService _serviceToTest;
        private Mock<ICarAdsRepository> _mockRepository;

        [TestInitialize]
        public void TestInit()
        {
            _mockRepository = new Mock<ICarAdsRepository>();
            _serviceToTest = new CarAdsService(_mockRepository.Object);
        }

        [TestMethod]
        public void GetAll_ShouldCallRepository()
        {
            //Arrange
            _mockRepository.Setup(t => t.GetAll()).Returns(new List<CarAds>() {new CarAds()});

            //Act
            var results =_serviceToTest.GetAll();

            //Assert
            Assert.AreEqual(1, results.Count);
            _mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GetById_ShouldCallRepository()
        {
            //Arrange
            var testGuid = Guid.NewGuid();
            _mockRepository.Setup(t => t.GetById(testGuid)).Returns(new CarAds());

            //Act
            var result = _serviceToTest.GetById(testGuid);

            //Assert
            Assert.IsNotNull(result);
            _mockRepository.VerifyAll();
        }
    }
}
