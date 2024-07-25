using Infraestructure.Model;

namespace Infraestructure.Interfaces
{
    /// <summary>
    /// Interface defining the UserRepository contract, extending the generic CRUD operations for User entities.
    /// This interface can be implemented by a concrete UserRepository class for user-specific data access functionalities.
    /// </summary>
    public interface IUserRepository : IGenericRepository<User, int>
    {
    }
}
