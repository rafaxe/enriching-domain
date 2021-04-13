namespace EnrichDomain.ADM.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public bool IsBlocked { get; set; }

        public bool IsActive { get; set; }
    }
}
