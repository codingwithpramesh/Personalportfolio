using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personalportfolio.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

       

        public string Address { get; set; }

        public string Phone { get; set; }

        public string About { get; set; }


        [MaxLength]
        public string? Profilepic { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public List<SocialMedia> SocialMedia { get; set; }

        public List<Education> Education { get; set; }  

        public List<Interest> Interest { get; set; }

        public List<Experience> Experience { get; set; }

        public List<Awards> Awards { get; set; }

        public List<WorkFlow> WorkFlow { get; set; }

        public List<Tools> Tools { get; set; }

       

    }
}
