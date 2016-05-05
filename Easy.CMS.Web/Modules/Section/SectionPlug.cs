﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Easy.Web.CMS;
using Easy.Web.Route;

namespace Easy.CMS.Section
{
    public class ProductPlug : PluginBase
    {
        public override IEnumerable<RouteDescriptor> RegistRoute()
        {
            return null;
        }

        public override IEnumerable<AdminMenu> AdminMenu()
        {
            return null;
        }

        protected override void InitScript(Func<string, Web.Resource.ResourceHelper> script)
        {
            
        }

        protected override void InitStyle(Func<string, Web.Resource.ResourceHelper> style)
        {
            style("SectionAdmin").Include("~/Modules/Section/Content/Section.css");
        }
    }
}