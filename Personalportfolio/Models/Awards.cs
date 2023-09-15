using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personalportfolio.Models
{
    public class Awards
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        [ForeignKey("UId")]
        public int UId { get; set; }
    }
}
