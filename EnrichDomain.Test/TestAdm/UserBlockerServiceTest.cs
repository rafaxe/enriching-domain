using EnrichDomain.ADM.Repositories;
using EnrichDomain.ADM.Services;
using Moq;
using NUnit.Framework;
using System;
using System.ComponentModel;

namespace EnrichDomain.Test.TestAdm
{
    public class UserBlockerServiceTest
    {
        private Mock<IUserRepository> _mockRepository;
        private UserBlockerService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IUserRepository>();

            _service = new UserBlockerService
            (
                _mockRepository.Object
            );
        }

        [Test()]
        [DisplayName("The user should be blocked")]
        public void UserShouldBeBlocked()
        {
            _mockRepository
                .Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(UserTestHelper.CreateUser(1));

            var user = _service.Block(1);

            Assert.IsFalse(user.IsActive);
            Assert.IsTrue(user.IsBlocked);

            Assert.AreEqual("John123", user.UserName);
            Assert.AreEqual("john@gmail.com", user.Email);
        }

        [Test()]
        [DisplayName("User is already blocked")]
        public void UserIsAlreadyBlocked()
        {
            _mockRepository
                .Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(UserTestHelper.CreatBlockedUser(1));

            Assert.Throws(Is.TypeOf<OperationCanceledException>().And.Message.EqualTo("UserAlreadyBlocked"), () => _service.Block(1));
        }
    }
}