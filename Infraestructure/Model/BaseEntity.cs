using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Model
{
    /// <summary>
    /// Base class representing a common entity model for the application.
    /// This class defines properties shared by all entities in the system.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Unique identifier for the entity (primary key).
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The date and time the entity was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// The date and time the entity was last updated.
        /// </summary>
        public DateTime UpdatedDate { get; set; }
    }
}
