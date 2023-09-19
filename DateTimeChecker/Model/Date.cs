using System.ComponentModel.DataAnnotations;


namespace DateTimeChecker.Model
{
    public class Date
    {   
        public string? Day { get; set; }

        public string? Month { get; set; }

        public string? Year { get; set; }

        public override string ToString()
        {
            return $"{Day}/{Month}/{Year}";
        }
    }
}
