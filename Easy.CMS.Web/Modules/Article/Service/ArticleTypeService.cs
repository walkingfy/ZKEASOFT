﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Easy.Data;
using Easy.RepositoryPattern;
using Easy.CMS.Article.Models;
using Easy.Extend;

namespace Easy.CMS.Article.Service
{
    public class ArticleTypeService : ServiceBase<ArticleType>
    {
        private ArticleService _articleService;

        public override void Add(ArticleType item)
        {
            item.ParentID = item.ParentID ?? 0;
            base.Add(item);
        }

        public IEnumerable<ArticleType> GetChildren(long id)
        {
            return Get(m => m.ParentID == id);
        }

        public override int Delete(params object[] primaryKeys)
        {
            _articleService = _articleService ?? new ArticleService();
            var item = Get(primaryKeys);
            if (item != null)
            {
                GetChildren(item.ID ?? 0).Each(m =>
                {
                    _articleService.Delete(n => n.ArticleTypeID == m.ID);
                    Delete(m.ID);
                });
                _articleService.Delete(n => n.ArticleTypeID == item.ID);
            }
            return base.Delete(primaryKeys);
        }
    }
}