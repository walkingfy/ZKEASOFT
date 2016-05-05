﻿using Easy.CMS.Article.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy.CMS.Article.ViewModel
{
    public class ArticleDetailViewModel
    {
        public ArticleEntity Current { get; set; }
        public ArticleEntity Prev { get; set; }
        public ArticleEntity Next { get; set; }
    }
}