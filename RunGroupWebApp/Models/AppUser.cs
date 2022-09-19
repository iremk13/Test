using System.ComponentModel.DataAnnotations;

namespace RunGroupWebApp.Models
{
    public class AppUser 
    {
        [Key]
        public string ID { get; set; }
        public int? Pace { get; set; }

        public int? Mileage { get; set; }
        public Address? Address { get; set; }

        public ICollection<Club> Clubs { get; set; }
        public ICollection<Races> Races { get; set; }
    }
}
