﻿using System.Web;
using System.Web.Mvc;

namespace You.Web
{
    /// <summary>
    /// 主题管理
    /// </summary>
    public static class ThemeManager
    {
        public static void Config()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new ThemeViewEngine());
        }

        public static string ThemePath
        {
            get
            {
                return "/Themes/";
            }
        }

        public static string Theme
        {
            get
            {
                //应该从数据库中读取
                return HttpContext.Current.Request.Params["theme"] ?? "default";
            }
        }

        public static string Style
        {
            get
            {
                //应该从数据库中读取
                return HttpContext.Current.Request.Params["style"] ?? "default";
            }
        }

        public static string ThemeContent(this UrlHelper urlHelper, string url)
        {
            if (Theme == "default")
            {
                return urlHelper.Content(url);
            }
            return urlHelper.Content(url.Insert(1, ThemePath + Theme));
        }
    }
}