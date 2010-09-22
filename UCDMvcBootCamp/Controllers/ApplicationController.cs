using System.Web.Mvc;
using UCDArch.Web.Controller;
using UCDMvcBootCamp.Helpers;

namespace UCDMvcBootCamp.Controllers
{
    [HandleError(Order = 100)]
    public class ApplicationController : SuperController
    {
        protected XmlResult<T> Xml<T>(T toSerialize)
        {
            return new XmlResult<T>
            {
                Model = toSerialize
            };
        }
    }
}
