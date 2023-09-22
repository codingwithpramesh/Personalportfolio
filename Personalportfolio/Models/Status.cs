using System.ComponentModel.DataAnnotations;

namespace Personalportfolio.Models
{
    public class Status
    {

        public int statuscode { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string message { get; set; }
    }
}
