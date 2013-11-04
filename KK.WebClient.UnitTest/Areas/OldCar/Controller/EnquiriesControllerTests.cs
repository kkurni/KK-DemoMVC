using System;
using System.Collections.Generic;
using System.Web.Mvc;
using KK.Domain.Models;
using KK.Domain.Services.Interfaces;
using KK.WebClient.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace KK.WebClient.Areas.oldCar.Controllers
{
    [TestClass]
    public class EnquiriesControllerTests
    {
        private EnquiriesController _controllerTotest;
        private Mock<ICarAdsService> _mockCarAdsService;
        private Mock<IEnquiryService> _mockEnquiryService;

        [TestInitialize]
        public void TestInit()
        {
            _mockCarAdsService = new Mock<ICarAdsService>();
            _mockEnquiryService = new Mock<IEnquiryService>();
            _controllerTotest = new EnquiriesController(_mockCarAdsService.Object, _mockEnquiryService.Object);

        }

        [TestMethod]
        public void Index_ShouldReturnCollectionOfEnquiries()
        {
            //Arrange
            var expectedData = new List<Enquiry> {new Enquiry()};
            _mockEnquiryService.Setup(t => t.GetAll()).Returns(expectedData);

            //Act
            var result = _controllerTotest.Index() as ViewResult;

            //Assert
            Assert.AreEqual(expectedData, result.Model);            
            _mockCarAdsService.VerifyAll();
        }

        [TestMethod]
        public void AddEnquiry_ShouldAddEnquiry()
        {
            //Arrange
            var enquiryToTest = new EnquiryViewModel()
                                {
                                    Name = "test",
                                    EmailAddress = "testEmail",
                                    CarAdsId = Guid.NewGuid()
                                };
            var expectedCarAds = new CarAds();
            _mockEnquiryService.Setup(t => t.AddEnquiry(It.IsAny<Enquiry>()));
            _mockCarAdsService.Setup(t => t.GetById(enquiryToTest.CarAdsId)).Returns(expectedCarAds);

            //Act
            var result = _controllerTotest.AddEnquiry(enquiryToTest) as ViewResult;

            //Assert
            var resultModel = result.Model as Enquiry;
            Assert.IsNotNull(resultModel);
            Assert.AreEqual(enquiryToTest.EmailAddress ,resultModel.EmailAddress);
            Assert.AreEqual(enquiryToTest.Name, resultModel.Name);
            Assert.AreEqual(expectedCarAds, resultModel.CarAds);
            _mockCarAdsService.VerifyAll();
            _mockEnquiryService.VerifyAll();
        }
    }
}
