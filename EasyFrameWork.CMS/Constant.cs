﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easy.Web.CMS
{
    public class ViewDataKeys
    {
        public const string Zones = "ViewDataKey_Zones";
        public const string Layouts = "ViewDataKey_Layouts";
        public const string ArticleCategory = "ViewDataKey_ArticleType";
        public const string ProductCategory = "ViewDataKey_ProductCategory";
    }
    public class ReView
    {
        public const string QueryKey = "ViewType";
        public const string Review = "Review";
    }

    public class CacheTrigger
    {
        public const string WidgetChanged = "WidgetChanged";
    }

    public class Urls
    {
        public const string SelectPage = "/admin/page/select";
        public const string SelectImage = "/admin/Media/Select";
    }

    public enum MediaType
    {
        Folder = 1,
        Image = 2,
        Video = 3,
        Zip = 4,
        Pdf = 5,
        Txt = 6,
        Doc = 7,
        Excel = 8,
        Ppt = 9,
        Other = 100
    }

    public static class FileExtensions
    {
        public static List<string> Video
        {
            get { return new List<string> { ".mp4", ".avi", ".rmvb" }; }
        }
        public static List<string> Zip
        {
            get { return new List<string> { ".rar", ".zip", ".7z" }; }
        }
        public static List<string> Pdf
        {
            get { return new List<string> { ".pdf" }; }
        }
        public static List<string> Txt
        {
            get { return new List<string> { ".txt" }; }
        }
        public static List<string> Doc
        {
            get { return new List<string> { ".doc",".docx" }; }
        }
        public static List<string> Excel
        {
            get { return new List<string> { ".xls", ".xlsx" }; }
        }
        public static List<string> Ppt
        {
            get { return new List<string> { ".ppt", ".pptx" }; }
        }
    }
}
