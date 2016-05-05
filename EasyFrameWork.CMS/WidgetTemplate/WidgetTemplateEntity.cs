﻿using Easy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easy.MetaData;
using Easy.Web.CMS.Widget;

namespace Easy.Web.CMS.WidgetTemplate
{
    [DataConfigure(typeof(WidgetTemplateMetaData))]
    public class WidgetTemplateEntity : EditorEntity
    {
        public long? ID { get; set; }
        public string GroupName { get; set; }

        public string PartialView { get; set; }
        public string AssemblyName { get; set; }
        public string ServiceTypeName { get; set; }

        public string ViewModelTypeName { get; set; }
        public int? Order { get; set; }

        public string FormView { get; set; }

        private void CopyToWidget(WidgetBase widget)
        {
            widget.AssemblyName = this.AssemblyName;
            widget.Description = this.Description;
            widget.PartialView = this.PartialView;
            widget.ViewModelTypeName = this.ViewModelTypeName;
            widget.WidgetName = this.Title;
            widget.ServiceTypeName = this.ServiceTypeName;
        }
        public WidgetBase CreateWidgetInstance()
        {
            var widget = Activator.CreateInstance(this.AssemblyName, this.ViewModelTypeName).Unwrap() as WidgetBase;
            CopyToWidget(widget);
            return widget;
        }
    }
    class WidgetTemplateMetaData : DataViewMetaData<WidgetTemplateEntity>
    {
        protected override void DataConfigure()
        {
            DataTable("CMS_WidgetTemplate");
            DataConfig(m => m.ID).AsIncreasePrimaryKey();
        }

        protected override void ViewConfigure()
        {

        }
    }

}
