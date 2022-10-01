using RealEstateOffice.Models;
using System.Linq;
using System.Web.Mvc;

namespace RealEstateOffice.Controllers
{
    public class AgentController : Controller
    {
        private readonly dbContext dbContext = new dbContext();

        [Authorize(Roles = "agents")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyAdvert(int id)
        {
            var advertlist = from s in dbContext.Adverts
                             where s.Agent.agent_id == id
                             select s;
            return View(advertlist);
        }

        [HttpGet]
        public ActionResult AddAdvert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdvert(Advert p)
        {
            int id = (int)Session["agent_id"];
            p.agent_id = id;
            dbContext.Adverts.Add(p);
            dbContext.SaveChanges();
            return RedirectToAction("AddAdvert");
        }

        public ActionResult DeleteAdvert(int id)
        {
            Advert advert = dbContext.Adverts.Find(id);
            dbContext.Adverts.Remove(advert);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Profile(int id)
        {
            return View("Profile", dbContext.Agents.Find(id));
        }

        [HttpPost]
        public ActionResult Profile(Agent p)
        {
            var available = dbContext.Agents.Find(p.agent_id);
            available.agent_username = p.agent_username;
            available.agent_password = p.agent_password;
            available.agent_company_name = p.agent_company_name;
            available.agent_company_mail = p.agent_company_mail;
            available.agent_company_address = p.agent_company_address;
            available.agent_company_phone = p.agent_company_phone;
            dbContext.SaveChanges();
            return RedirectToAction("Profile");
        }

        public ActionResult UpdateAdvert(int id)
        {
            return View("UpdateAdvert", dbContext.Adverts.Find(id));
        }

        [HttpPost]
        public ActionResult UpdateAdvert(Advert p)
        {
            var available = dbContext.Adverts.Find(p.advert_id);
            available.advert_name = p.advert_name;
            available.number_of_rooms = p.number_of_rooms;
            available.residance_age = p.residance_age;
            available.square_meters = p.square_meters;
            available.category = p.category;
            available.price = p.price;
            dbContext.SaveChanges();
            return RedirectToAction("UpdateAdvert");
        }
    }
}