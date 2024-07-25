using Business.Interfaces; 
using Infraestructure.Model; 
using Microsoft.AspNetCore.Mvc; 

namespace FinApp.Controllers
{
    /// <summary>
    /// Base controller class providing common functionalities for API endpoints.
    /// This class is intended to be inherited by specific controllers for different entity types.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity the controller manages (e.g., User, Account).</typeparam>
    /// <typeparam name="TKey">The type of the entity's identifier (e.g., int for user ID).</typeparam>
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TEntity, TKey> : ControllerBase
        where TEntity : BaseEntity 
        where TKey : IConvertible 
    {
        /// <summary>
        /// The injected generic service for CRUD operations on the specified entity type.
        /// </summary>
        protected readonly IGenericService<TEntity, TKey> _service;

        /// <summary>
        /// Constructor for the base controller, injecting the generic service dependency.
        /// </summary>
        /// <param name="service">The generic service instance for the specific entity type.</param>
        public BaseController(IGenericService<TEntity, TKey> service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves all entities of the specified type asynchronously.
        /// </summary>
        /// <returns>An asynchronous task returning a collection of entities.</returns>
        [HttpGet]
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _service.GetAllAsync();
        }

        /// <summary>
        /// Retrieves an entity with the specified ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>An asynchronous task returning an IActionResult based on the retrieved entity.</returns>
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetByIdAsync(TKey id)
        {
            var entity = await _service.GetByIdAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        /// <summary>
        /// Creates a new entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity object to be created.</param>
        /// <returns>An asynchronous task returning an IActionResult based on the creation operation.</returns>
        [HttpPost]
        public virtual async Task<IActionResult> CreateAsync([FromBody] TEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.CreateAsync(entity);

            return Ok(); 
        }

        /// <summary>
        /// Updates an existing entity asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to update.</param>
        /// <param name="entity">The updated entity object.</param>
        /// <returns>An asynchronous task returning an IActionResult based on the update operation.</returns>
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> UpdateAsync(TKey id, [FromBody] TEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.UpdateAsync(id, entity);

            return Ok();
        }

        /// <summary>
        /// Deletes an entity with the specified ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <returns>An asynchronous task returning an IActionResult based on the deletion operation.</returns>
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync(TKey id)
        {
            await _service.DeleteAsync(id);

            return NotFound(); 
        }
    }
}

