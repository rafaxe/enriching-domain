using EnrichDomain.ADM.Models;

namespace EnrichDomain.Test.TestAdm
{
    public static class UserTestHelper
    {
        public static User CreateUser(int userId)
        {
            return new()
            {
                UserId = userId,
                IsActive = false,
                IsBlocked = false,
                Email = "john@gmail.com",
                UserName = "John123"
            };
        }

        public static User CreateActiveUser(int userId)
        {
            return new()
            {
                UserId = userId,
                IsActive = true,
                IsBlocked = false,
                Email = "john@gmail.com",
                UserName = "John123"
            };
        }

        public static User CreatBlockedUser(int userId)
        {
            return new()
            {
                UserId = userId,
                IsActive = false,
                IsBlocked = true,
                Email = "john@gmail.com",
                UserName = "John123"
            };
        }

        public static User CreateWrongEmailUser(int userId)
        {
            return new()
            {
                UserId = userId,
                IsActive = false,
                IsBlocked = false,
                Email = "john@wrongdomain.com",
                UserName = "John123"
            };
        }

        public static User CreateWrongUsername(int userId)
        {
            return new()
            {
                UserId = userId,
                IsActive = false,
                IsBlocked = false,
                Email = "john@gmail.com",
                UserName = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam augue enim, tincidunt sit amet maximus id, facilisis porta ante. Nulla eget pharetra nisi. Suspendisse eu tincidunt mauris. Pellentesque scelerisque tristique magna. Maecenas vel tortor ac dui finibus elementum. Aliquam mollis pellentesque odio, eget ultricies libero tincidunt non. Pellentesque sed iaculis sem, id ultricies purus. Mauris vehicula nulla nec metus sollicitudin, a elementum orci tristique. Donec a est porta, mollis metus ut, volutpat mi. In aliquam vestibulum nisl, non vestibulum mi"
            };
        }
    }
}
