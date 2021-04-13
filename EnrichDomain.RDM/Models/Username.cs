using System;

namespace EnrichDomain.RDM.Models
{
    public class Username
    {
        private const int MaxUsernameLength = 100;
        private readonly string _username;

        private Username(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException(username);

            CheckUsernameLength(username);
            _username = username;
        }

        public static Username Create(string userName)
        {
            return new(userName);
        }

        private static void CheckUsernameLength(string name)
        {
            if ((name.Length > MaxUsernameLength))
            {
                throw new ArgumentException("UserNameTooLongException");
            }
        }

        public override string ToString()
        {
            return _username;
        }
    }
}
