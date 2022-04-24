using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base;
using EbSite.Base.Configs.ContentSet;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.BLL
{
    public class ThemesPC : ThemesBase
    {
        public static readonly ThemesPC Instance = new ThemesPC();
        override protected ThemeType eThemeType 
        { 
            get { return ThemeType.PC; } 
        }
        override public string ThemesVpath
        {
            get
            {
                return string.Concat(IISPath, ThemesFolder);
            }
        }

        private  string ThemesFolder
        {
            get
            {
                return ThemesUtils.GetThemesFolder(ThemeType.PC);
            }
        }
        public override string FilePathName
        {
            get
            {
                return string.Concat("/", ThemesFolder, "/");
            }
        }
        /// <summary>
        /// 获取还没有被使用的皮肤
        /// </summary>
        public  List<Entity.Themes> GetThemeNoUsed
        {
            get
            {
                List<Entity.Themes> pcList = base.FillList();
                List<Entity.Themes> newList = (from li in pcList
                                            where (li.SiteID == 0)
                                            select li
                                                      ).ToList();

                return newList;
            }
        }
        public void ResetSiteID(int siteid)
        {
            foreach (Entity.Themes md in base.FillList())
            {
                if(md.SiteID==siteid)
                {
                    md.SiteID = 0;
                    base.Update(md);
                    break;
                }
            }
           
           
        }
        /// <summary>
        /// 安装皮肤后需要重置一些数据
        /// </summary>
        /// <param name="siteid"></param>
        /// <param name="themepath"></param>
        public void ResetSiteID(int siteid, string themepath)
        {

            foreach (Entity.Themes md in base.FillList())
            {
                if (md.ThemePath == themepath)
                {
                    md.SiteID = siteid;
                    base.Update(md);
                    break;
                }
            }


        }

        override protected void UpdateConfigs(string ThemePath)
        {
         
            CurrentSite.PageTheme = ThemePath;
            EbSite.BLL.Sites.Instance.Update(CurrentSite);

            MakeDefaultTemData(ThemePath);
        }
        public void MakeDefaultTemData(string sThemes)
        {
            TemplatesPC bllTem = TempFactory.GetInstance(sThemes);
            if (bllTem.TemplatesList().Count == 0) //如果当前皮肤下的模板数据为空，说明这是新模板，所以要添加默认模板数据
            {

                string sfIndexName = string.Concat(IISPath, "themes/", sThemes, "/pages/", "index.aspx");
                string sfListName = string.Concat(IISPath, "themes/", sThemes, "/pages/", "list.aspx");
                string sfContentName = string.Concat(IISPath, "themes/", sThemes, "/pages/", "content.aspx");
                string sfSpecialName = string.Concat(IISPath, "themes/", sThemes, "/pages/", "special.aspx");

                string indexTemPath = HttpContext.Current.Server.MapPath(sfIndexName);   //首页
                string listTemPath = HttpContext.Current.Server.MapPath(sfListName);     //分类
                string contentTemPath = HttpContext.Current.Server.MapPath(sfContentName);  //内容
                string specialTemPath = HttpContext.Current.Server.MapPath(sfSpecialName);  //专题
                Guid newid;
                if (System.IO.File.Exists(indexTemPath))
                {

                    Entity.Templates mdNC = new EbSite.Entity.Templates(ThemesFolder);

                    mdNC.TemName = "默认首页模板";
                    mdNC.TemType = 0;
                    mdNC.IsNoSysTem = true;
                    mdNC.Themes = sThemes;
                    mdNC.AddDate = DateTime.Now;

                    mdNC.TempFileName = "index.aspx";
                    newid = Guid.NewGuid();
                    mdNC.ID = newid;

                    bllTem.Add(mdNC);
                    //EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.IndexTemID = newid;
                    //EbSite.Base.Configs.SysConfigs.ConfigsControl.SaveConfig();
                }
                if (System.IO.File.Exists(listTemPath))
                {

                    Entity.Templates mdNC = new EbSite.Entity.Templates(ThemesFolder);

                    mdNC.TemName = "分类模版默认";
                    mdNC.TemType = 1;
                    mdNC.IsNoSysTem = true;
                    mdNC.Themes = sThemes;
                    mdNC.AddDate = DateTime.Now;
                    mdNC.TempFileName = "list.aspx";
                    mdNC.ID = Guid.NewGuid();
                    bllTem.Add(mdNC);
                }
                if (System.IO.File.Exists(contentTemPath))
                {

                    Entity.Templates mdNC = new EbSite.Entity.Templates(ThemesFolder);

                    mdNC.TemName = "默认内容模板";
                    mdNC.TemType = 2;
                    mdNC.IsNoSysTem = true;
                    mdNC.Themes = sThemes;
                    mdNC.AddDate = DateTime.Now;
                    mdNC.TempFileName = "content.aspx";
                    mdNC.ID = Guid.NewGuid();
                    bllTem.Add(mdNC);
                }
                if (System.IO.File.Exists(specialTemPath))
                {

                    Entity.Templates mdNC = new EbSite.Entity.Templates(ThemesFolder);

                    mdNC.TemName = "默认专题模板";
                    mdNC.TemType = 3;
                    mdNC.IsNoSysTem = true;
                    mdNC.Themes = sThemes;
                    mdNC.AddDate = DateTime.Now;
                    mdNC.TempFileName = "special.aspx";
                    mdNC.ID = Guid.NewGuid();
                    bllTem.Add(mdNC);
                }


            }
            else
            {
                foreach (var list in bllTem.TemplatesList())
                {
                    if (list.Themes == sThemes && list.TemType == 0)
                    {
                        //EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.IndexTemID = list.ID;
                        //EbSite.Base.Configs.SysConfigs.ConfigsControl.SaveConfig();
                        break;
                    }
                }

            }
        }

        /// <summary>
        /// 重写数据的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(string.Concat(IISPath, "datastore/Themes/PC/"));
            }
        }
    }
}
