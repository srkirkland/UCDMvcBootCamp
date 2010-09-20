using System;
using System.Web.Mvc;

namespace UCDMvcBootCamp.Controllers
{
    public class DynamicController : Controller
    {
        //
        // GET: /Dynamic/
        public ActionResult Index(string text)
        {
            ViewData["text"] = text;

            return View();
        }

        [HttpPost]
        public ActionResult GoTo(string gotoUrl)
        {
            return Redirect(gotoUrl);
        }
    }
}
