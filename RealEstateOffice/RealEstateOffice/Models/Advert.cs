using System.ComponentModel.DataAnnotations;

namespace RealEstateOffice.Models
{
    public class Advert
    {
        [Key]
        public int advert_id { get; set; }
        public int? agent_id { get; set; }
        public virtual Agent Agent { get; set; }
        public string advert_name { get; set; }
        public string number_of_rooms { get; set; }
        public string residance_age { get; set; }
        public string square_meters { get; set; }
        public string category { get; set; }
        public string price { get; set; }
    }
}