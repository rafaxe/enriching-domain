using EnrichDomain.RDM.Models;

namespace EnrichDomain.RDM.Repositories
{
    public interface IUserRepository
    {

        public User GetById(int userId);

        public void Save(User user);
    }
}
