using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personalportfolio.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }
    }

}
