using System.ComponentModel.DataAnnotations;


namespace DateTimeChecker.Model
{
    public class Date
    {
        [Required(ErrorMessage = "Day can not be blank")]
        [Range(maximum: 31, minimum: 1)]
        public string Day { get; set; }

        [Required(ErrorMessage = "Month can not be blank")]
        [Range(maximum: 12, minimum: 1)]
        public string Month { get; set; }

        [Required(ErrorMessage = "Year can not be blank")]
        [Range(maximum: 3000, minimum: 1000)]
        public string Year { get; set; }

        public override string ToString()
        {
            return $"{Day}/{Month}/{Year}";
        }
    }
}
