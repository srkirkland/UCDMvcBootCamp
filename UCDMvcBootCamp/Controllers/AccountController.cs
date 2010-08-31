using System.Web.Mvc;
using System.Web.Security;
using UCDMvcBootCamp.Models;

namespace UCDMvcBootCamp.Controllers
{

    [HandleError]
    public class AccountController : Controller
    {
        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);

            return RedirectToAction("Index", "Home");
        }

        // **************************************
        // URL: /Account/LogOff
        // **************************************

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}
