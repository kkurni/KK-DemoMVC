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
    public class EnquiryServiceTest
    {
        private EnquiryService _serviceToTest;
        private Mock<IEnquiryRepository> _mockRepository;

        [TestInitialize]
        public void TestInit()
        {
            _mockRepository = new Mock<IEnquiryRepository>();
            _serviceToTest = new EnquiryService(_mockRepository.Object);
        }

        [TestMethod]
        public void GetAll_ShouldCallRepository()
        {
            //Arrange
            _mockRepository.Setup(t => t.GetAll()).Returns(new List<Enquiry>() {new Enquiry()});

            //Act
            var results =_serviceToTest.GetAll();

            //Assert
            Assert.AreEqual(1, results.Count);
            _mockRepository.VerifyAll();
        }

        [TestMethod]
        public void AddEnquiry_ShouldCallRepository()
        {
            //Arrange
            var testEnquiry = new Enquiry{Name="test", EmailAddress="test@test.com"};
            var testGuid = Guid.NewGuid();
            _mockRepository.Setup(t => t.AddEnquiry(testEnquiry)).Returns(testGuid);

            //Act
            var result = _serviceToTest.AddEnquiry(testEnquiry);

            //Assert
            Assert.AreEqual(testGuid, result);
            _mockRepository.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void AddEnquiry_WithEmptyEmail_ShouldThrowException()
        {
            //Arrange
            var testEnquiry = new Enquiry { Name = "test", EmailAddress = "" };
            var testGuid = Guid.NewGuid();
            _mockRepository.Setup(t => t.AddEnquiry(testEnquiry)).Returns(testGuid);

            //Act
            _serviceToTest.AddEnquiry(testEnquiry);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void AddEnquiry_WithEmptyName_ShouldThrowException()
        {
            //Arrange
            var testEnquiry = new Enquiry { Name = "", EmailAddress = "asd@asd.com" };
            var testGuid = Guid.NewGuid();
            _mockRepository.Setup(t => t.AddEnquiry(testEnquiry)).Returns(testGuid);

            //Act
            _serviceToTest.AddEnquiry(testEnquiry);
        }
    }
}
