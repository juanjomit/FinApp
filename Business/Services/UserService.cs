using Business.Interfaces;
using Infraestructure.Interfaces;
using Infraestructure.Model;

namespace Business.Services
{
    /// <summary>
    /// Service class responsible for managing user data in the application.
    /// This service provides user-specific functionalities on top of the generic CRUD operations offered by GenericService.
    /// </summary>
    public class UserService : GenericService<User, int>, IUserService
    {

        #region Constructor

        /// <summary>
        /// Constructor for the UserService class, injecting the user repository dependency.
        /// </summary>
        /// <param name="repository">The injected user repository instance.</param>
        public UserService(IUserRepository repository) : base(repository)
        {
        }

        #endregion
    }
}
