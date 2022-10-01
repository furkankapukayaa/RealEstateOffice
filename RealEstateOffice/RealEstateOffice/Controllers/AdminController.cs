using RealEstateOffice.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RealEstateOffice.Controllers
{
    public class AdminController : Controller
    {
        private readonly dbContext dbContext = new dbContext();

        [Authorize(Roles = "admins")]
        public ActionResult Index()
        {
            ViewBag.AdminCount = dbContext.Admins.Count();
            ViewBag.AgentCount = dbContext.Agents.Count();
            ViewBag.AdvertCount = dbContext.Adverts.Count();
            return View();
        }

        public ActionResult AgentList()
        {
            List<Agent> agents = dbContext.Agents.ToList();
            return View(agents);
        }

        public ActionResult DeleteAgent(int id)
        {
            Agent sagent = dbContext.Agents.Find(id);
            dbContext.Agents.Remove(sagent);
            dbContext.SaveChanges();
            return RedirectToAction("AgentList");
        }

        public ActionResult DeleteAdvert(int id)
        {
            Advert sadvert = dbContext.Adverts.Find(id);
            dbContext.Adverts.Remove(sadvert);
            dbContext.SaveChanges();
            return RedirectToAction("AdvertList");
        }

        public ActionResult AdminList()
        {
            List<Admin> admins = dbContext.Admins.ToList();
            return View(admins);
        }

        public ActionResult AdvertList()
        {
            List<Advert> adverts = dbContext.Adverts.ToList();
            return View(adverts);
        }

        [HttpGet]
        public ActionResult AddAgent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAgent(Agent p)
        {
            p.role = "agents";
            dbContext.Agents.Add(p);
            dbContext.SaveChanges();
            return RedirectToAction("AddAgent");
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            p.role = "admins";
            dbContext.Admins.Add(p);
            dbContext.SaveChanges();
            return RedirectToAction("AddAdmin");
        }

        [HttpGet]
        public ActionResult Profile(int id)
        {
            return View("Profile", dbContext.Admins.Find(id));
        }

        [HttpPost]
        public ActionResult Profile(Admin p)
        {
            var available = dbContext.Admins.Find(p.admin_id);
            available.admin_name_surname = p.admin_name_surname;
            available.admin_password = p.admin_password;
            available.admin_mail = p.admin_mail;
            dbContext.SaveChanges();
            return RedirectToAction("Profile");
        }
    }
}