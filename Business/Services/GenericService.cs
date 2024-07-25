using Business.Interfaces;
using Infraestructure.Interfaces;
using Infraestructure.Model;

namespace Business.Services
{
    /// <summary>
    /// Generic service class providing basic CRUD operations for entities of a specific type.
    /// This class is designed to be inherited by specific services for different entity types.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity the service manages (e.g., User, Account).</typeparam>
    /// <typeparam name="TKey">The type of the entity's identifier (e.g., int for user ID).</typeparam>
    public class GenericService<TEntity, TKey> : IGenericService<TEntity, TKey> where TEntity : BaseEntity where TKey : IConvertible
    {
        /// <summary>
        /// The injected generic repository for CRUD operations on the specified entity type.
        /// </summary>
        protected readonly IGenericRepository<TEntity, TKey> _repository;

        /// <summary>
        /// Constructor for the GenericService class, injecting the generic repository dependency.
        /// </summary>
        /// <param name="repository">The generic repository instance for the specific entity type.</param>
        public GenericService(IGenericRepository<TEntity, TKey> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves all entities of the specified type asynchronously.
        /// </summary>
        /// <returns>An asynchronous task returning a collection of entities.</returns>
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        /// <summary>
        /// Retrieves an entity with the specified ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>An asynchronous task returning the entity with the specified ID, or null if not found.</returns>
        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await _repository.GetByIdAsync(id);
        }

        /// <summary>
        /// Creates a new entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity object to be created.</param>
        /// <returns>An asynchronous task indicating the creation operation's success or failure.</returns>
        public virtual async Task CreateAsync(TEntity entity)
        {
            await _repository.CreateAsync(entity);
        }

        /// <summary>
        /// Updates an existing entity asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to update.</param>
        /// <param name="entity">The updated entity object.</param>
        /// <returns>An asynchronous task indicating the update operation's success or failure.</returns>
        public virtual async Task UpdateAsync(TKey id, TEntity entity)
        {
            await _repository.UpdateAsync(id, entity);
        }

        /// <summary>
        /// Deletes an entity with the specified ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <returns>An asynchronous task indicating the deletion operation's success or failure.</returns>
        public virtual async Task DeleteAsync(TKey id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
