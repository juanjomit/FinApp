using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Model
{
    public class UserAuth
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public int userId { get; set; }

        public virtual required User User { get; set; }
    }
}
