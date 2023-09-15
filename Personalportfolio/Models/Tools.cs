using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personalportfolio.Models
{
    public class Tools
    {
        [Key]
        public int Id { get; set; }

        public string Icon { get; set; }

        [ForeignKey("UId")]
        public int UId { get; set; }
    }
}
