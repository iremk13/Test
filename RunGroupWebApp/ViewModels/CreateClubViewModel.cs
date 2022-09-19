using RunGroupWebApp.Data.Enum;
using RunGroupWebApp.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunGroupWebApp.ViewModels
{
    public class CreateClubViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public ClubCategory ClubCategory { get; set; }

        public int AddressID { get; set; }

        public string Url { get; set; }
        public Address Address { get; set; }
     
    }
}
