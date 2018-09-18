using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GedditWeb.Helpers
{
    public static class HtmlHelperExtension
    {

        public static MvcHtmlString Test(this HtmlHelper helper)
        {
            TagBuilder tags = new TagBuilder("");



            return MvcHtmlString.Create(tags.ToString());
        }
    }
}