using RealEstateOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateOffice.Controllers
{
    
    public class AdminController : Controller
    {
        dbContext c = new dbContext();
        [Authorize(Roles = "admins")]
        public ActionResult Index()
        {
            var result = c.Admins.Count();
            var result2 = c.Agents.Count();
            var result3 = c.Adverts.Count();
            ViewBag.AdminCount = result;
            ViewBag.AgentCount = result2;
            ViewBag.AdvertCount = result3;
            return View();
        }

        public ActionResult AgentList()
        {
            List<Agent> agents = c.Agents.ToList();
            return View(agents);
        }

        public ActionResult DeleteAgent(int id)
        {
            Agent sagent = c.Agents.Find(id);
            c.Agents.Remove(sagent);
            c.SaveChanges();
            return RedirectToAction("AgentList");
        }

        public ActionResult DeleteAdvert(int id)
        {
            Advert sadvert = c.Adverts.Find(id);
            c.Adverts.Remove(sadvert);
            c.SaveChanges();
            return RedirectToAction("AdvertList");
        }

        public ActionResult AdminList()
        {
            List<Admin> admins = c.Admins.ToList();
            return View(admins);
        }

        public ActionResult AdvertList()
        {
            List<Advert> adverts = c.Adverts.ToList();
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
            c.Agents.Add(p);
            c.SaveChanges();
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
            c.Admins.Add(p);
            c.SaveChanges();
            return RedirectToAction("AddAdmin");
        }

        [HttpGet]
        public ActionResult Profile(int id)
        {
            return View("Profile", c.Admins.Find(id));

        }

        [HttpPost]
        public ActionResult Profile(Admin p)
        {
            var available = c.Admins.Find(p.admin_id);
            available.admin_name_surname = p.admin_name_surname;
            available.admin_password = p.admin_password;
            available.admin_mail = p.admin_mail;
            c.SaveChanges();
            return RedirectToAction("Profile");
        }
    }
}