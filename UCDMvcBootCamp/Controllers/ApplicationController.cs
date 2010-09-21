using System.Web.Mvc;
using UCDArch.Web.Controller;

namespace UCDMvcBootCamp.Controllers
{
    [HandleError(Order = 100)]
    public class ApplicationController : SuperController { }
}
