using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personalportfolio.Models
{
    public class Title
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Experience { get; set; }

        public string? Education { get; set; }

        public string? TitleName { get; set; }

        public string? Skills { get; set; }

        public string? ProgrammingLanguage { get; set; }

        public string? workflows { get; set; }

        public string? Interest { get; set; }

        public string? Awards { get; set; }

        public int UId { get; set; }

        [ForeignKey("UId")]
        public User User { get; set; }


    }
}
