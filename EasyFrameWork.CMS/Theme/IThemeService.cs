﻿using Easy.RepositoryPattern;

namespace Easy.Web.CMS.Theme
{
    public interface IThemeService : IService<ThemeEntity>
    {
        void SetPreview(string id);
        void CancelPreview();
        ThemeEntity GetCurrentTheme();
        void ChangeTheme(string id);
    }
}