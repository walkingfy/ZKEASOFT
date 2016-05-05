﻿using System;
using Easy.Extend;

namespace Easy.Web.CMS.Page
{
    public class PageExistException : Exception
    {
        public PageExistException(PageEntity page)
            : base("已存在Url为 {0} 的页面".FormatWith(page.Url))
        {

        }
    }
}