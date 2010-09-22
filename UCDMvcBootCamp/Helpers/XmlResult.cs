using System;
using System.Web.Mvc;
namespace UCDMvcBootCamp.Helpers
{
    public class XmlResult<T> : ActionResult
    {
        public T Model { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            var contentResult = new ContentResult {Content = Model.Serialize(), ContentType = "text/xml"};
            contentResult.ExecuteResult(context);
        }
    }
}