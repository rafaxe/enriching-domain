using System;
using System.ComponentModel;
using EnrichDomain.RDM.Models;
using NUnit.Framework;

namespace EnrichDomain.Test.TestRdm
{
    public class PersonRdmTest
    {
        [Test()]
        [DisplayName("The user after creation should not be active")]
        public void ShouldNotBeActiveAfterCreation()
        {
            var user = new User(1, Username.Create("John123"), Email.Create("john@gmail.com"));

            Assert.IsFalse(user.IsActive);
            Assert.IsFalse(user.IsBlocked);
            Assert.AreEqual("John123", user.UserName.ToString());
            Assert.AreEqual("john@gmail.com", user.Email.ToString());
        }

        [Test()]
        [DisplayName("The email address does not match the domain")]
        public void EmailDoesNotMatchTheDomain()
        {
            Assert.Throws
            (
                Is.TypeOf<ArgumentException>().And.Message.EqualTo("InvalidMailDomain"),
                () => Email.Create("john@wrongdomain.com")
            );
        }

        [Test()]
        [DisplayName("Username does not have length permission")]
        public void UsernameMustHaveAllowedLength()
        {
            const string longName = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam augue enim, tincidunt sit amet maximus id, facilisis porta ante. Nulla eget pharetra nisi. Suspendisse eu tincidunt mauris. Pellentesque scelerisque tristique magna. Maecenas vel tortor ac dui finibus elementum. Aliquam mollis pellentesque odio, eget ultricies libero tincidunt non. Pellentesque sed iaculis sem, id ultricies purus. Mauris vehicula nulla nec metus sollicitudin, a elementum orci tristique. Donec a est porta, mollis metus ut, volutpat mi. In aliquam vestibulum nisl, non vestibulum mi";

            Assert.Throws
            (
                Is.TypeOf<ArgumentException>().And.Message.EqualTo("UserNameTooLongException"),
                () => Username.Create(longName)
            );
        }

        [Test()]
        [DisplayName("User is already active")]
        public void UserIsAlreadyActive()
        {
            var user = new User(1, Username.Create("John123"), Email.Create("john@gmail.com"));
            user.ActiveUser();

            Assert.IsTrue(user.IsActive);
            Assert.Throws
            (
                Is.TypeOf<OperationCanceledException>().And.Message.EqualTo("UserAlreadyActive"),
                () => user.ActiveUser()
            );
        }

        [Test()]
        [DisplayName("User is already blocked")]
        public void UserIsAlreadyBlocked()
        {
            var user = new User(1, Username.Create("John123"), Email.Create("john@gmail.com"));
            user.BlockUser();

            Assert.IsTrue(user.IsBlocked);
            Assert.Throws
            (
                Is.TypeOf<OperationCanceledException>().And.Message.EqualTo("UserAlreadyBlocked"), 
                () => user.BlockUser()
            );
        }
    }
}