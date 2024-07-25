using Infraestructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Contexts
{
    /// <summary>
    /// DbContext class representing the FinApp database context.
    /// This class defines the connection to the database and provides access to its entities as DbSets.
    /// </summary>
    public class FinAppContext : DbContext
    {
        /// <summary>
        /// Constructor for the FinAppContext class, injecting the DbContextOptions.
        /// </summary>
        /// <param name="contextOptions">The DbContextOptions instance configured for the FinApp database.</param>
        public FinAppContext(DbContextOptions<FinAppContext> contextOptions)
            : base(contextOptions)
        {
            // Additional configuration for the DbContext can be placed here (e.g., model mapping)
        }

        /// <summary>
        /// DbSet representing the Users table in the database.
        /// This property provides access to User entities for CRUD operations.
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}
