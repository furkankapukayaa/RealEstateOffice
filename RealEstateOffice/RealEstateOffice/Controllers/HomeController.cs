using RealEstateOffice.Models;
using System.Linq;
using System.Web.Mvc;

namespace RealEstateOffice.Controllers
{
    public class HomeController : Controller
    {
        private dbContext c = new dbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult AdvertList(string searchName)
        {
            var values = from d in c.Adverts select d;
            if (!string.IsNullOrEmpty(searchName))
            {
                values = values.Where(m => m.advert_name.Contains(searchName));
            }
            return View(values.ToList());

            //List<Advert> adverts = c.Adverts.ToList();
            //return View(adverts);
        }

        public ActionResult AdvertDetail(int id)
        {
            var advertdetail = from s in c.Adverts
                               where s.advert_id == id
                               select s;
            return View(advertdetail);
        }
    }
}