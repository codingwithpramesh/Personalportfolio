using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personalportfolio.Models
{
    public class Awards
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Description { get; set; }

        
        public int UId { get; set; }
        [ForeignKey("UId")]
        public User User { get; set; }
    }
}
