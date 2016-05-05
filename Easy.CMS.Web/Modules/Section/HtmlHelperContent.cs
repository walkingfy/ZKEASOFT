﻿using System.Web.Mvc;
using System.Web.Mvc.Html;
using Easy.CMS.Section.Models;

namespace Easy.CMS.Section
{
    public static class HtmlHelperContent
    {
        public static void RenderContent(this HtmlHelper html, SectionContent content)
        {
            if (content != null && content.SectionContentType.HasValue)
            {
                html.RenderPartial("SectionPartial." + ((SectionContent.Types)content.SectionContentType), content);
            }
        }

        public static void RenderEditContent(this HtmlHelper html, SectionContent content)
        {
            if (content != null && content.SectionContentType.HasValue)
            {
                html.RenderPartial("SectionPartial." + ((SectionContent.Types)content.SectionContentType + ".Edit"), content);
            }
        }
    }
}