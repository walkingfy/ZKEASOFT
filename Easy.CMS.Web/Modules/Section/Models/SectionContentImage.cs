﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Easy.MetaData;
using Easy.Web.CMS;

namespace Easy.CMS.Section.Models
{
    [DataConfigure(typeof(SectionContentImageMetaData))]
    public class SectionContentImage : SectionContent
    {
        public string ImageSrc { get; set; }
        public string ImageAlt { get; set; }
        public string ImageTitle { get; set; }
        public string Href { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
    }

    class SectionContentImageMetaData : DataViewMetaData<SectionContentImage>
    {
        protected override bool IsIgnoreBase()
        {
            return true;
        }

        protected override void DataConfigure()
        {
            DataTable("SectionContentImage");
            DataConfig(m => m.ID).AsPrimaryKey();
            DataConfig(m => m.SectionWidgetId).Insert(true).Update(false);
            DataConfig(m => m.Title).Ignore();
            DataConfig(m => m.Description).Ignore();
            DataConfig(m => m.Status).Ignore();
        }

        protected override void ViewConfigure()
        {
            ViewConfig(m => m.ImageSrc).AsTextBox().Required().AddClass("select select-image").AddProperty("data-url", Urls.SelectImage);
            ViewConfig(m => m.Href).AsTextBox().AddClass("select").AddProperty("data-url", Urls.SelectPage);
        }
    }
}