using EnrichDomain.ADM.Repositories;
using EnrichDomain.ADM.Services;
using Moq;
using NUnit.Framework;
using System;
using System.ComponentModel;

namespace EnrichDomain.Test.TestAdm
{
    public class UserActivationServiceTest
    {
        private Mock<IUserRepository> _mockRepository;
        private UserActivationService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IUserRepository>();

            _service = new UserActivationService
            (
                _mockRepository.Object
            );
        }

        [Test()]
        [DisplayName("The user after creation should be active")]
        public void ShouldBeActiveAfterCreation()
        {

            _mockRepository
                .Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(UserTestHelper.CreateUser(1));

            var user = _service.ActivateUser(1);

            Assert.IsTrue(user.IsActive);
            Assert.IsFalse(user.IsBlocked);
            Assert.AreEqual("John123", user.UserName);
            Assert.AreEqual("john@gmail.com", user.Email);
        }

        [Test()]
        [DisplayName("The user is already active")]
        public void UserAlreadyActive()
        {
            _mockRepository
                .Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(UserTestHelper.CreateActiveUser(1));

            Assert.Throws(Is.TypeOf<OperationCanceledException>().And.Message.EqualTo("UserAlreadyActive"), () => _service.ActivateUser(1));
        }
    }
}