using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using KK.Domain.Models;
using KK.Domain.Services.Interfaces;
using KK.WebClient.Controllers;
using KK.WebClient.Controllers.Apis;
using KK.WebClient.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace KK.WebClient.UnitTest
{
    [TestClass]
    public class EnquiryControllerTests
    {
        private EnquiryController _controllerTotest;
        private Mock<IEnquiryService> _mockEnquiryService;
        private Mock<ICarAdsService> _mockCarAdsService;

        [TestInitialize]
        public void TestInit()
        {
            _mockCarAdsService = new Mock<ICarAdsService>();
            _mockEnquiryService = new Mock<IEnquiryService>();
            _controllerTotest = new EnquiryController(_mockEnquiryService.Object,_mockCarAdsService.Object);

        }
        [TestMethod]
        public void Get_ShouldCallRepository()
        {
            //Arrange
            _mockEnquiryService.Setup(t => t.GetAll()).Returns(new List<Enquiry>() { new Enquiry() });

            //Act
            var results = _controllerTotest.Get();

            //Assert
            Assert.AreEqual(1, results.Count());
            _mockEnquiryService.VerifyAll();
        }


        [TestMethod]
        public void AddEnquiry_ShouldCallRepository()
        {
            //Arrange
            var enquiryToTest = new EnquiryViewModel()
            {
                Name = "test",
                EmailAddress = "testEmail",
                CarAdsId = Guid.NewGuid()
            };
            var expectedCarAds = new CarAds();
            var testGuid = Guid.NewGuid();
            _mockEnquiryService.Setup(t => t.AddEnquiry(It.IsAny<Enquiry>())).Returns(testGuid);
            _mockCarAdsService.Setup(t => t.GetById(enquiryToTest.CarAdsId)).Returns(expectedCarAds);

            //Act
            var result = _controllerTotest.Post(enquiryToTest);

            //Assert
            Assert.AreEqual(testGuid, result);                        
            _mockCarAdsService.VerifyAll();
            _mockEnquiryService.VerifyAll();
        }
    }
}
