using Infraestructure.Contexts;
using Infraestructure.Interfaces;
using Infraestructure.Model;

namespace Infraestructure.Repositories
{
    /// <summary>
    /// Concrete implementation of the UserRepository interface, inheriting from GenericRepository.
    /// This class provides user-specific data access functionalities using Entity Framework Core.
    /// </summary>
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        /// <summary>
        /// Constructor for the UserRepository class, injecting the FinAppContext dependency.
        /// </summary>
        /// <param name="context">The FinAppContext instance for database access.</param>
        public UserRepository(FinAppContext context) : base(context)
        {
        }
    }
}
