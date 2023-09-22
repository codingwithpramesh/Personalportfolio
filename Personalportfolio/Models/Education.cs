using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personalportfolio.Models
{
    public class Education
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required (ErrorMessage = "Enter School")]
        public string School { get; set; }

        [Required (ErrorMessage ="Enter Major")]
        public string major { get; set; }

        [Required(ErrorMessage ="Enter this field")]
        public DateTime JoinDate { get; set; }

        [Required(ErrorMessage = "Enter this field")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Enter Description")]
        public string Description { get; set; }

        public int UId { get; set; }

        [ForeignKey("UId")]
        public User? user { get; set; }
    }
}
