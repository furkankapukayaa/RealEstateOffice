using RealEstateOffice.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace RealEstateOffice.Controllers
{
    public class LoginController : Controller
    {
        private dbContext c = new dbContext();

        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin user)
        {
            var info = c.Admins.FirstOrDefault(x => x.admin_username == user.admin_username && x.admin_password == user.admin_password);
            if (info != null)
            {
                FormsAuthentication.SetAuthCookie(info.admin_username, false);
                Session["admin_id"] = info.admin_id;
                Session["admin_username"] = info.admin_username;
                Session["admin_name_surname"] = info.admin_name_surname;
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }

        public ActionResult AgentLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgentLogin(Agent user)
        {
            var info = c.Agents.FirstOrDefault(x => x.agent_username == user.agent_username && x.agent_password == user.agent_password);
            if (info != null)
            {
                FormsAuthentication.SetAuthCookie(info.agent_username, false);
                Session["agent_id"] = info.agent_id;
                Session["agent_username"] = info.agent_username;
                Session["agent_name_surname"] = info.agent_name_surname;
                Session["agent_company_name"] = info.agent_company_name;
                return RedirectToAction("Index", "Agent");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}