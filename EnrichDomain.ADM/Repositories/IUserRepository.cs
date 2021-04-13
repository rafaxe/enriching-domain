using EnrichDomain.ADM.Models;

namespace EnrichDomain.ADM.Repositories
{
    public interface IUserRepository
    {

        public User GetById(int userId);

        public void Save(User user);
    }
}
