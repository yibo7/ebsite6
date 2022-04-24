using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using EbSite.BLL.Tem;
using EbSite.Base;
using EbSite.Base.Configs.ContentSet;
using EbSite.Core.FSO; 
using EbSite.Entity;

namespace EbSite.BLL
{
    abstract public class ThemesBase : EbSite.Base.Datastore.XMLProviderBase<Entity.Themes>
    {
        abstract protected ThemeType eThemeType { get; }
        public EbSite.Entity.Sites CurrentSite
        {
            get
            {
                return Host.Instance.CurrentSite;
            }
        }
        abstract public string  ThemesVpath { get; }
        protected abstract void UpdateConfigs(string ThemePath);
        protected ThemesBase()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }
        private string GetMapPath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(ThemesVpath);
            }
        }
        //public Entity.Themes GetCurrentUsedTheme
        //{
        //    get
        //    {
        //        List<Entity.Themes> lst = base.FillList().Where(d => d.IsUsed == true).ToList();
        //        Entity.Themes md = null;
        //        if(lst.Count>0)
        //        {
        //            md =  lst[0];

        //            if(lst.Count>1) //这种可能性不大
        //            {
        //                for (int i = 1; i < lst.Count; i++)
        //                {
        //                    Entity.Themes mdOd = lst[i];
        //                    mdOd.IsUsed = false;
        //                    base.Update(mdOd);
        //                }
        //            }
        //        }
        //        return md;
        //    }
        //}
        //public void SetUsed(Guid ThemeID)
        //{
        //    Entity.Themes md = GetEntity(ThemeID);
            
        //        if (md != null)
        //        {
        //            Entity.Themes mdOle = GetCurrentUsedTheme;
        //            if (mdOle!=null)
        //            {
        //                mdOle.IsUsed = false;
        //                base.Update(mdOle);
        //            }
                 
        //        }
            
        //    if(md!=null)
        //    {
        //        md.IsUsed = true;
        //        base.Update(md);
        //        UpdateConfigs(md.ThemePath);
                
        //    }
           
           
        //}


        public List<Entity.Themes> InitThemes()
        {
            List<string> lst = Core.Utils.GetFolder(GetMapPath);
            List<Entity.Themes> lstThemes = new List<Entity.Themes>();

             List < Entity.Themes > lstCurrent =   base.FillList();

            //先删除当前已经不存在的皮肤数据
             foreach (Entity.Themes themes in lstCurrent)
            {
                string sThemePath = string.Concat(GetMapPath, "\\", themes.ThemePath);
                if(!Core.FSO.FObject.IsExist(sThemePath,FsoMethod.Folder))
                {
                    Delete(themes.id);
                }

            }
            //遍历皮肤下的所有目录(皮肤名称)
            foreach (string ThemePath in lst)
            {
                Entity.Themes md = new Entity.Themes();

                //md.ThemesName = ThemePath;
                md.ThemePath = ThemePath;
                md.FullPath = string.Concat(ThemesVpath, "/", ThemePath, "/");
                bool isHave = lstCurrent.Exists(d => d.ThemePath == md.ThemePath);
                //如果不存在当前皮肤，要重新生成一遍数据
                if (!isHave)
                {
                    //目前只保存一个标题
                    //string sTitle = string.Concat(GetMapPath, "\\", ThemePath, "\\configs.config");
                    string sPathCSS = string.Concat(GetMapPath, "\\", ThemePath, "\\css");
                    string sPathPages = string.Concat(GetMapPath, "\\", ThemePath, "\\pages");

                    string sAdminPathCSS = string.Concat(GetMapPath, "\\", ThemePath, "\\css.css");//后台管理皮肤结构不一样，所以也要做一个这样的判断

                    if ((FObject.IsExist(sPathCSS, FsoMethod.Folder) && FObject.IsExist(sPathPages, FsoMethod.Folder)) || FObject.IsExist(sAdminPathCSS, FsoMethod.File))
                    {
                       

                        int iID =  BLL.Sites.Instance.GetSiteIDByThemePath(ThemePath);
                        md.SiteID = iID;
                        md.AddDate = DateTime.Now;
                        lstThemes.Add(md);
                        base.Add(md);
                        //同时要将皮肤下的一些数据文件(TemData/incsetupdata  TemData/temsetupdata)修改过来
                        TemplateInc IncBll = new TemplateInc(ThemePath, eThemeType);
                        List<EbSite.Entity.Templates> IncsList = IncBll.IncsList;
                        foreach (Templates inc in IncsList)
                        {
                            inc.Themes = ThemePath;
                            IncBll.Update(inc);
                        }
                        XMLProvider bllTemplates = new XMLProvider(ThemePath, eThemeType);
                        List<EbSite.Entity.Templates> lstTemplates = bllTemplates.FillTemps();
                        foreach (Templates template in lstTemplates)
                        {
                            template.Themes = ThemePath;
                            bllTemplates.UpdateTemp(template);
                        }


                    }
                    
                }

                //UpdateConfigs(md.ThemePath);
                
            }

            return lstThemes;

        }
        //public void MakeThemeImg(string sSavePath,string sUrl)
        //{
         
         
        //   MakeWebToImg mwti = new MakeWebToImg();

        //   mwti.Url = sUrl;
        //    mwti.SavePath = sSavePath;
        //    mwti.Make();

        //}

        //public abstract void MakeThemeImg(Guid ThemeID);

       // public abstract void CopyData(Guid ThemeID);
        abstract public string FilePathName { get; }//"/themes/"
        virtual public void CopyData(Guid ThemeID)
        {
            Entity.Themes ThemeOld = GetEntity(ThemeID);
            Entity.Themes ThemeNew = new Entity.Themes();
            ThemeNew.ThemePath = string.Concat("cp_", ThemeOld.ThemePath);
            //ThemeNew.ThemesName = string.Concat("复制_", ThemeOld.ThemesName);
            ThemeNew.AddDate = DateTime.Now;
            ThemeNew.FullPath = FilePathName + ThemeNew.ThemePath + "/";
            ThemeNew.IndexUrl = ThemeNew.FullPath + "pages/index.aspx";
            ThemeNew.SmallImg = ThemeNew.FullPath + "SmallImg.jpg";
            ThemeNew.BigImg = ThemeNew.FullPath + "BigImg.jpg";

            //先要检测文件夹是否存在
            if (Core.FSO.FObject.IsExist(System.Web.HttpContext.Current.Server.MapPath(ThemeNew.FullPath), FsoMethod.Folder))
            {

            }
            else
            {
                base.Add(ThemeNew);
                string oldPath = System.Web.HttpContext.Current.Server.MapPath(ThemeOld.FullPath);
                string newPath = System.Web.HttpContext.Current.Server.MapPath(ThemeNew.FullPath);
                EbSite.Core.FSO.FObject.CopyDirectory(oldPath, newPath);

                //string filepath = string.Concat(newPath, "configs.config");
                //EbSite.Core.FSO.FObject.WriteFile(filepath, ThemeNew.ThemesName, false);

            }
        }
        

    }
}
