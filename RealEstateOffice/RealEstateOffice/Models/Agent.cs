using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstateOffice.Models
{
    public class Agent
    {
        [Key]
        public int agent_id { get; set; }
        public ICollection<Advert> adverts { get; set; }
        public string agent_username { get; set; }
        public string agent_password { get; set; }
        public string agent_name_surname { get; set; }
        public string agent_company_name { get; set; }
        public string agent_company_mail { get; set; }
        public string agent_company_address { get; set; }
        public string agent_company_phone { get; set; }
        public string role { get; set; }
    }
}