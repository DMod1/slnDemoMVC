using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace DemoMVC.HtmlHelpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString Submit(this HtmlHelper<dynamic> sender, string value)
        {
            var writer = new HtmlTextWriter(new StringWriter());
 
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "submit");
            writer.AddAttribute(HtmlTextWriterAttribute.Value, value);
            writer.RenderBeginTag(HtmlTextWriterTag.Input);
            writer.RenderEndTag();
 
            return new MvcHtmlString(writer.InnerWriter.ToString());
        }

        public static MvcHtmlString Image(this HtmlHelper<dynamic> sender, string pathImage, string error)
        {
            var writer = new HtmlTextWriter(new StringWriter());

            //writer.AddAttribute(HtmlTextWriterAttribute.Type, "submit");
            writer.AddAttribute(HtmlTextWriterAttribute.Src, pathImage);
            writer.AddAttribute(HtmlTextWriterAttribute.Alt, error);
            writer.RenderBeginTag(HtmlTextWriterTag.Img);
            writer.RenderEndTag();

            return new MvcHtmlString(writer.InnerWriter.ToString());
        }
    }
}