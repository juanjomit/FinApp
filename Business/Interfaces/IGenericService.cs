using Infraestructure.Model;

namespace Business.Interfaces
{
    /// <summary>
    /// Interface defining the generic service contract for CRUD operations on entities of a specific type.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity the service manages (e.g., User, Account).</typeparam>
    /// <typeparam name="TKey">The type of the entity's identifier (e.g., int for user ID).</typeparam>
    public interface IGenericService<TEntity, TKey> where TEntity : BaseEntity where TKey : IConvertible
    {
        /// <summary>
        /// Retrieves all entities of the specified type asynchronously.
        /// </summary>
        /// <returns>An asynchronous task returning a collection of entities.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Retrieves an entity with the specified ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>An asynchronous task returning the entity with the specified ID, or null if not found.</returns>
        Task<TEntity> GetByIdAsync(TKey id);

        /// <summary>
        /// Creates a new entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity object to be created.</param>
        /// <returns>An asynchronous task indicating the creation operation's success or failure.</returns>
        Task CreateAsync(TEntity entity);

        /// <summary>
        /// Updates an existing entity asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to update.</param>
        /// <param name="entity">The updated entity object.</param>
        /// <returns>An asynchronous task indicating the update operation's success or failure.</returns>
        Task UpdateAsync(TKey id, TEntity entity);

        /// <summary>
        /// Deletes an entity with the specified ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <returns>An asynchronous task indicating the deletion operation's success or failure.</returns>
        Task DeleteAsync(TKey id);
    }
}
