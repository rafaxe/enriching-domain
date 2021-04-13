using System;

namespace EnrichDomain.RDM.Models
{
    public class User
    {
        public int UserId { get; }
        public Username UserName { get; }
        public Email Email { get; }
        public bool IsActive { get; private set; }
        public bool IsBlocked { get; private set; }


        public User(int userId, Username userName, Email email)
        {
            UserId = userId;
            UserName = userName;
            Email = email;
            IsActive = false;
            IsBlocked = false;
        }

        public void ActiveUser()
        {
            if (IsActive)
                throw new OperationCanceledException("UserAlreadyActive");

            IsActive = true;
        }

        public void BlockUser()
        {
            if (IsBlocked)
                throw new OperationCanceledException("UserAlreadyBlocked");

            IsBlocked = true;
        }
    }
}
