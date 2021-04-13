using EnrichDomain.ADM.Repositories;
using EnrichDomain.ADM.Services;
using Moq;
using NUnit.Framework;
using System;
using System.ComponentModel;

namespace EnrichDomain.Test.TestAdm
{
    public class UserRegistrationServiceTest
    {
        private Mock<IUserRepository> _mockRepository;
        private UserRegistrationService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IUserRepository>();

            _service = new UserRegistrationService
            (
                _mockRepository.Object
            );
        }

        [Test()]
        [DisplayName("The user must be created")]
        public void MustBeCreated()
        {
            var user = _service.RegisterUser(UserTestHelper.CreateUser(1));

            Assert.IsFalse(user.IsActive);
            Assert.IsFalse(user.IsBlocked);

            Assert.AreEqual("John123", user.UserName);
            Assert.AreEqual("john@gmail.com", user.Email);
        }

        [Test()]
        [DisplayName("The email address does not match the domain")]
        public void EmailDoesNotMatchTheDomain()
        {
            Assert.Throws(Is.TypeOf<ArgumentException>().And.Message.EqualTo("InvalidMailDomain"), () => _service.RegisterUser(UserTestHelper.CreateWrongEmailUser(1)));
        }

        [Test()]
        [DisplayName("Username does not have length permission")]
        public void UsernameDoesNotHaveAllowedLength()
        {
            var user = UserTestHelper.CreateWrongUsername(1);
            Assert.Throws(Is.TypeOf<ArgumentException>().And.Message.EqualTo($"{user.UserName} too long"), () => _service.RegisterUser(UserTestHelper.CreateWrongUsername(1)));
        }
    }
}