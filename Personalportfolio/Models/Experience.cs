using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personalportfolio.Models
{
    public class Experience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string Company { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string Position { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public DateTime JoinDate { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string Description { get; set; }

       
        public int UId { get; set; }

        [ForeignKey("UId")]
         public User? User { get; set; }
    }
}
