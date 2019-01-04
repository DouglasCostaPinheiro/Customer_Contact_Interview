using Customer_Contact.Models;
using Domain;
using System.Linq;
using System.Web.Mvc;

namespace Customer_Contact.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        // GET: Customer
        [Authorize(Roles = "Administrator")]
        public ActionResult ListAdmin()
        {
            FillViewBag();

            return View("List");
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult ListAdmin(CustomerSearchModel model)
        {
            FillViewBag();

            ViewBag.Customers = CustomerDomain.ListCustomers(model.Name, model.GenderId, model.CityId, model.RegionId, model.LastPurchaseStart, model.LastPuchaseEnd, model.ClassificationId, model.SellerId).Select(c => (CustomerListModel)c);

            return View("List");
        }

        private void FillViewBag()
        {
            ViewBag.Genders = GenderDomain.ListGenders().Select(g => new SelectListItem() { Text = g.Name, Value = g.Id.ToString() });
            ViewBag.Cities = CityDomain.ListCities().Select(g => new SelectListItem() { Text = g.Name, Value = g.Id.ToString() });
            ViewBag.Regions = RegionDomain.ListRegions().Select(g => new SelectListItem() { Text = g.Name, Value = g.Id.ToString() });
            ViewBag.Classifications = ClassificationDomain.ListClassifications().Select(g => new SelectListItem() { Text = g.Name, Value = g.Id.ToString() });
            ViewBag.Sellers = UserDomain.ListUsers().Select(g => new SelectListItem() { Text = g.Login, Value = g.Id.ToString() });
        }

        [Authorize(Roles = "Seller")]
        public ActionResult ListSeller()
        {
            FillViewBag();

            return View("List");
        }

        [Authorize(Roles = "Seller")]
        [HttpPost]
        public ActionResult ListSeller(CustomerSearchModel model)
        {
            FillViewBag();

            ViewBag.Customers = CustomerDomain.ListCustomers(model.Name, model.GenderId, model.CityId, model.RegionId, model.LastPurchaseStart, model.LastPuchaseEnd, model.ClassificationId, int.Parse(User.Identity.Name)).Select(c => (CustomerListModel)c);

            return View("List");
        }
    }
}