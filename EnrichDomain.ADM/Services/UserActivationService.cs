using EnrichDomain.ADM.Models;
using EnrichDomain.ADM.Repositories;
using System;
using System.Collections.Generic;

namespace EnrichDomain.ADM.Services
{
    public class UserActivationService
    {

        private readonly IUserRepository _userRepository;

        public UserActivationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User ActivateUser(int userId)
        {
            var user = _userRepository.GetById(userId);

            if (user == null)
                throw new KeyNotFoundException("UserNotFound");

            ValidateIfUserIsActive(user);

            user.IsActive = true;
            _userRepository.Save(user);

            return user;
        }

        private static void ValidateIfUserIsActive(User user)
        {
            if (user.IsActive)
            {
                throw new OperationCanceledException("UserAlreadyActive");
            }
        }
    }
}