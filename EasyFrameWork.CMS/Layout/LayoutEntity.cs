﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Easy.Extend;
using Easy.MetaData;
using Easy.Web.CMS.Zone;
using Easy.Models;
using Easy.Web.CMS.Page;
using Easy.Web.CMS.Theme;
using Easy.Web.CMS.Widget;

namespace Easy.Web.CMS.Layout
{
    [DataConfigure(typeof(LayoutEntityMetaData))]
    public class LayoutEntity : EditorEntity, IImage
    {
        public const string DefaultThumbnial = "~/Modules/Common/Content/Images/demoLayout.jpg";
        public string ID { get; set; }

        public string LayoutName { get; set; }
        public string ContainerClass { get; set; }
        public string Script { get; set; }
        public string Style { get; set; }
        public ZoneCollection Zones { get; set; }
        public ZoneWidgetCollection ZoneWidgets { get; set; }
        public LayoutHtmlCollection Html { get; set; }

        public PageEntity Page { get; set; }

        public string ImageUrl { get; set; }
        public string ImageThumbUrl { get; set; }

        public ThemeEntity CurrentTheme { get; set; }

    }

    class LayoutEntityMetaData : DataViewMetaData<LayoutEntity>
    {
        protected override void DataConfigure()
        {
            DataTable("CMS_Layout");
            DataConfig(m => m.ID).AsPrimaryKey();
        }

        protected override void ViewConfigure()
        {
            ViewConfig(m => m.ID).AsHidden();
            ViewConfig(m => m.ContainerClass).AsHidden();
            ViewConfig(m => m.Title).AsHidden();
            ViewConfig(m => m.LayoutName).AsTextBox().Required();
           

            ViewConfig(m => m.ImageThumbUrl).AsTextBox().AddClass("select select-image").AddProperty("data-url", Urls.SelectImage);
            ViewConfig(m => m.ImageUrl).AsTextBox().AddClass("select select-image").AddProperty("data-url", Urls.SelectImage);
        }
    }

}
