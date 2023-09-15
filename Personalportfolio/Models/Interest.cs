using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personalportfolio.Models
{
    public class Interest
    {
        [Key]
        public int Id { get; set; }

        public string Desription { get; set; }

        [ForeignKey("UId")]
        public int UId { get; set; }
    }
}
