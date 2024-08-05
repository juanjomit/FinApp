using Business.Interfaces;
using Infraestructure.Model;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.Controllers
{
    /// <summary>
    /// Controller class for managing user data in the application.
    /// Inherits from the generic BaseController for common functionalities.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [RequireHttps]
    public class UsersController : BaseController<User, int>
    {

        #region Constructor

        /// <summary>
        /// Constructor for the UsersController, injecting the user service dependency.
        /// </summary>
        /// <param name="service">The user service instance for user-related operations.</param>
        public UsersController(IUserService service) : base(service)
        {
        }

        #endregion
        
    }
}
