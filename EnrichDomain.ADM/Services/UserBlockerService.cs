using EnrichDomain.ADM.Models;
using EnrichDomain.ADM.Repositories;
using System;
using System.Collections.Generic;

namespace EnrichDomain.ADM.Services
{
    public class UserBlockerService
    {

        private readonly IUserRepository _userRepository;

        public UserBlockerService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Block(int userId)
        {
            var user = _userRepository.GetById(userId);

            if (user == null)
                throw new KeyNotFoundException("UserNotFound");

            ValidateIfUserIsAlreadyBlocked(user);

            user.IsBlocked = true;
            _userRepository.Save(user);

            return user;
        }

        private void ValidateIfUserIsAlreadyBlocked(User user)
        {
            if (user.IsBlocked)
            {
                throw new OperationCanceledException("UserAlreadyBlocked");
            }
        }
    }
}
