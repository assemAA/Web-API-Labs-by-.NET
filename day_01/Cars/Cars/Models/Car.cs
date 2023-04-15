using Cars.Validations;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Cars.Models
{
    public class Car
    {
        [RegularExpression("^[0-9]+$" , ErrorMessage = "id must be number")]
        public int id { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage ="car name is invalid")]
        public string name { get; set; }
        public double price { get; set; }
        [Required]
        [DateInPast(ErrorMessage ="production date mmust be in past")]
        public DateTime ProductionDate {get; set;}

        public string type { get; set; }    

    }
}
