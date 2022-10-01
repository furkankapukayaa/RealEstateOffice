using System.ComponentModel.DataAnnotations;

namespace RealEstateOffice.Models
{
    public class Admin
    {
        [Key]
        public int admin_id { get; set; }
        public string admin_username { get; set; }
        public string admin_password { get; set; }
        public string admin_name_surname { get; set; }
        public string admin_mail { get; set; }
        public string role { get; set; }
    }
}