using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personalportfolio.Models
{
    public class SocialMedia
    {
        [Key]
        public int Id { get; set; }

        public string Icon { get; set; }

        public string Link { get; set; }

        [ForeignKey("UId")]
        public int UId { get; set; }
    }
}
