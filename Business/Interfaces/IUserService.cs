using Infraestructure.Model;

namespace Business.Interfaces
{
    /// <summary>
    /// Interface defining the UserService contract, extending the generic CRUD operations for User entities.
    /// This interface can be implemented by a concrete UserService class for user-specific functionalities.
    /// </summary>
    public interface IUserService : IGenericService<User, int>
    {
    }
}
