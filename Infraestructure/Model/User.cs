using System.ComponentModel.DataAnnotations;

namespace Infraestructure.Model
{
    public class User : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string DocumentId { get; set; }
    }
}
