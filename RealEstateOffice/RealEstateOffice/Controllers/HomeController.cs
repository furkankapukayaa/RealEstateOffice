using RealEstateOffice.Models;
using System.Linq;
using System.Web.Mvc;

namespace RealEstateOffice.Controllers
{
    public class HomeController : Controller
    {
        private readonly dbContext dbContext = new dbContext();
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
            var values = from d in dbContext.Adverts select d;
            if (!string.IsNullOrEmpty(searchName))
            {
                values = values.Where(m => m.advert_name.Contains(searchName));
            }
            return View(values.ToList());
        }

        public ActionResult AdvertDetail(int id)
        {
            var advertdetail = from s in dbContext.Adverts
                               where s.advert_id == id
                               select s;
            return View(advertdetail);
        }
    }
}