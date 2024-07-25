using Infraestructure.Contexts;
using Infraestructure.Interfaces;
using Infraestructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    /// <summary>
    /// Generic repository class providing basic CRUD operations for entities of a specific type using Entity Framework Core.
    /// This class is designed to be inherited by specific repositories for different entity types.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity the repository manages (e.g., User, Account).</typeparam>
    /// <typeparam name="TKey">The type of the entity's identifier (e.g., int for user ID).</typeparam>
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity where TKey : IConvertible
    {
        /// <summary>
        /// The injected DbContext instance for interacting with the database.
        /// </summary>
        private readonly FinAppContext _context;

        /// <summary>
        /// Gets a DbSet instance for the specified entity type from the DbContext.
        /// </summary>
        public DbSet<TEntity> Entities => _context.Set<TEntity>(); // Consider renaming "entity" to "Entities" for clarity

        /// <summary>
        /// Constructor for the GenericRepository class, injecting the DbContext dependency.
        /// </summary>
        /// <param name="context">The FinAppContext instance for database access.</param>
        public GenericRepository(FinAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all entities of the specified type asynchronously.
        /// </summary>
        /// <returns>An asynchronous task returning a collection of entities.</returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        /// <summary>
        /// Retrieves an entity with the specified ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>An asynchronous task returning the entity with the specified ID, or null if not found.</returns>
        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await _context.Set<TEntity>().FindAsync(Convert.ChangeType(id, typeof(TKey)));
        }

        /// <summary>
        /// Creates a new entity asynchronously and saves the changes to the database.
        /// </summary>
        /// <param name="entity">The entity object to be created.</param>
        /// <returns>An asynchronous task indicating the creation operation's success or failure.</returns>
        public async Task CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing entity asynchronously and saves the changes to the database.
        /// </summary>
        /// <param name="id">The ID of the entity to update.</param>
        /// <param name="entity">The updated entity object.</param>
        /// <returns>An asynchronous task indicating the update operation's success or failure.</returns>
        public async Task UpdateAsync(TKey id, TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes an entity with the specified ID asynchronously and saves the changes to the database.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <returns>An asynchronous task indicating the deletion operation's success or failure.</returns>
        public async Task DeleteAsync(TKey id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(Convert.ChangeType(id, typeof(TKey)));
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
