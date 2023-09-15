using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personalportfolio.Models
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }

        public string Company { get; set; }

        public string Position { get; set; }

        public DateTime JoinDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        [ForeignKey("UId")]
        public int UId { get; set; }
    }
}
