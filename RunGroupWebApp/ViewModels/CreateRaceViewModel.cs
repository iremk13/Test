using RunGroupWebApp.Data.Enum;
using RunGroupWebApp.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunGroupWebApp.ViewModels
{
    public class CreateRaceViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; } 
        public Address Address { get; set; }

        public int AddressID { get; set; }
        public RaceCategory RaceCategory { get; set; }
    }
}
