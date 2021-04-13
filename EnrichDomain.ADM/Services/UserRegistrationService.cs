using EnrichDomain.ADM.Models;
using EnrichDomain.ADM.Repositories;
using System;
using System.Reflection;

namespace EnrichDomain.ADM.Services
{
    public class UserRegistrationService
    {
        private const string MailDomain = "@gmail.com";

        private readonly IUserRepository _userRepository;

        public UserRegistrationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User RegisterUser(User user)
        {
            if (_userRepository.GetById(user.UserId) != null)
                throw new AmbiguousMatchException("UserAlreadyExists");

            ValidateUserEmailDomain(user.Email);
            ValidateUserName(user.UserName);

            user.IsActive = false;
            user.IsBlocked = false;

            _userRepository.Save(user);

            return user;
        }

        private static void ValidateUserEmailDomain(string email)
        {
            if (!email.EndsWith(MailDomain))
            {
                throw new ArgumentException("InvalidMailDomain");
            }
        }

        private static void ValidateUserName(string name)
        {
            if ((name.Length > 100))
            {
                throw new ArgumentException($"{name} too long");
            }
        }
    }
}