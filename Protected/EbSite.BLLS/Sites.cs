using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.Static;
using EbSite.Core;
using EbSite.Core.FSO;

namespace EbSite.BLL
{
    public class Sites : EbSite.Base.Datastore.XMLProviderBaseInt<Entity.Sites>
    {
        //public static CacheManager CacheApp;
        const double cachetime = 120.0;//
        private const string cachesites = "sites"; //private static readonly string[] MasterCacheKeyArray = { "GlobalSiteCache" };

        public static readonly Sites Instance = new Sites();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return string.Concat(EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath, "Datastore/Sites/");
            }
        }
        private Sites()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);

            }

            //CacheApp = new CacheManager(CacheDuration, MasterCacheKeyArray);
        }
        public void DeleteSite(int id)
        {
            ThemesPC.Instance.ResetSiteID(id);
            base.Delete(id);
        }
        public int GetSiteIDBySiteFolder(string Folder)
        {
            if (string.IsNullOrEmpty(Folder)) return 1;
            string rawKey = string.Concat("GetSiteIDBySiteFolder-", Folder);
            string sSiteID = Host.CacheApp.GetCacheItem<string>(rawKey, cachesites); //base.GetCacheItem(rawKey) as string;
            int iSiteID = 1;
            if (string.IsNullOrEmpty(sSiteID))
            {
                List<EbSite.Entity.Sites> getsites = base.FillList();

                foreach (Entity.Sites getsite in getsites)
                {
                    if (getsite.SiteFolder.ToLower() == Folder.ToLower())
                    {
                        iSiteID = getsite.id;
                        Host.CacheApp.AddCacheItem(rawKey, iSiteID, cachetime, ETimeSpanModel.T, cachesites); // base.AddCacheItem(rawKey, iSiteID.ToString());
                    }
                }
            }
            else
            {
                iSiteID = Core.Utils.StrToInt(sSiteID, 1);
            }
            return iSiteID;
        }
        public new Entity.Sites GetEntityForMain
        {
            get
            {

               return GetEntity(1);
            }

        }

        public  Entity.Sites GetFirstEntity
        {
            get
            {
                KeyValuePair<Int32, Entity.Sites> pair = AppStartInit.Sites.First();
               return pair.Value;
            }
        }

        public new Entity.Sites GetEntity(int ID)
        {
           if(AppStartInit.Sites.ContainsKey(ID))
           {
               return AppStartInit.Sites[ID];
           }
           else
           {
                Log.Factory.GetInstance().InfoLog(string.Format("调用Sites.GetEntity(int id)时出错找不到当前站点,站点ID为:{0}", ID));
                return null;
            }
            
        }
        public List<EbSite.Entity.Sites> GetSitesTree(int iTop)
        {

            List<EbSite.Entity.Sites> getsites = base.FillList();
            List<Entity.Sites> getTree1 = new List<Entity.Sites>();
            foreach (EbSite.Entity.Sites tree in getsites)
            {
                if (tree.ParentID == 0)
                {
                    tree.SiteName = "╋" + tree.SiteName;
                    getTree1.Add(tree);
                    GetSubItem(tree.id, ref getTree1, "", getsites);
                }
            }
            return getTree1;
        }

        private void GetSubItem(int id, ref List<EbSite.Entity.Sites> NewClass, string blank, List<EbSite.Entity.Sites> OldClass)
        {
            foreach (EbSite.Entity.Sites tree in OldClass)
            {
                if (tree.ParentID == id)
                {
                    string str = blank + "─";
                    tree.SiteName = str + "『" + tree.SiteName + "』";
                    NewClass.Add(tree);
                    GetSubItem(tree.id, ref NewClass, str, OldClass);
                }
            }
        }
        /// <summary>
        /// 兼容旧版暂时保留
        /// </summary>
        /// <param name="siteid">站点ID</param>
        /// <returns></returns>
        public LinkType GetSiteLinkType(int siteid)
        {
            Entity.Sites md = GetEntityCache(siteid);
            if (md != null)
            {
                return (LinkType)md.LinkTypeContent;
            }
            return LinkType.AspxRewrite;
        }

        public LinkType GetLinkTypeClass(int siteid)
        {
            Entity.Sites md = GetEntityCache(siteid);
            if (md != null)
            {
                return (LinkType)md.LinkTypeClass;
            }
            return LinkType.AspxRewrite;
        }
        public LinkType GetLinkTypeContent(int siteid)
        {
            Entity.Sites md = GetEntityCache(siteid);
            if (md != null)
            {
                return (LinkType)md.LinkTypeContent;
            }
            return LinkType.AspxRewrite;
        }
        public LinkType GetLinkTypeSpecial(int siteid)
        {
            Entity.Sites md = GetEntityCache(siteid);
            if (md != null)
            {
                return (LinkType)md.LinkTypeSpecial;
            }
            return LinkType.AspxRewrite;
        }
        public LinkType GetLinkTypeTags(int siteid)
        {
            Entity.Sites md = GetEntityCache(siteid);
            if (md != null)
            {
                return (LinkType)md.LinkTypeTags;
            }
            return LinkType.AspxRewrite;
        }
        public LinkType GetLinkTypeOrther(int siteid)
        {
            Entity.Sites md = GetEntityCache(siteid);
            if (md != null)
            {
                return (LinkType)md.LinkTypeOrther;
            }
            return LinkType.AspxRewrite;
        }


       

        public EbSite.Entity.Sites GetEntityCache(int siteid)
        {
            return GetEntity(siteid);
            //string CacheKey = string.Concat("GetSiteCache-", siteid);
            //EbSite.Entity.Sites md = (Entity.Sites)CacheApp.GetCacheItem(CacheKey);

            //if (Equals(md, null))
            //{
            //    md = GetEntity(siteid);
            //    if (!Equals(md, null))
            //        CacheApp.AddCacheItem(CacheKey, md);
            //}
            //return md;
        }
        public int GetSiteIDByThemePath(string ThemePath)
        {
             string CacheKey = string.Concat("GetSiteIDByThemePath-", ThemePath);
            string obj = Host.CacheApp.GetCacheItem<string>(CacheKey,cachesites);
            if (string.IsNullOrEmpty(obj))
            {
                // int idd = 0;
                foreach (Entity.Sites md in FillList())
                {
                    if (md.PageTheme == ThemePath)
                    {
                        obj = md.id.ToString();
                        break;
                    }

                }
                //return idd;
                if (!string.IsNullOrEmpty(obj))
                    Host.CacheApp.AddCacheItem(CacheKey, obj, 1, ETimeSpanModel.T, cachesites);
            }

            if (!string.IsNullOrEmpty(obj))
                return int.Parse(obj);
            else
            {
                return 0;
            }
            /*
            string CacheKey = string.Concat("GetSiteIDByThemePath-", ThemePath);
            object obj = Host.CacheApp.GetCacheItem(CacheKey); //Core.Utils.StrToInt(Host.CacheApp.GetCacheItem(CacheKey).ToString(),0);
            if (Equals(obj, null))
            {
                // int idd = 0;
                foreach (Entity.Sites md in FillList())
                {
                    if (md.PageTheme == ThemePath)
                    {
                        obj = md.id;
                        break;
                    }

                }
                //return idd;
                if (!Equals(obj, null))
                    Host.CacheApp.AddCacheItem(CacheKey, obj);
            }

            if (!Equals(obj, null))
                return (int)obj;
            else
            {
                return 0;
            }
             * */


        }

        #region  杨欢乐添加 2011-12-01
        public List<Entity.Sites> GetTree_pic(int iTop)
        {
            List<Entity.Sites> getClass = BLL.Sites.Instance.FillList();
            List<Entity.Sites> getTree = new List<Entity.Sites>();


            string sPatch = string.Concat("<img src=\"", Base.AppStartInit.IISPath, "Images/tree/w1.gif\" align=absmiddle>");
            foreach (Entity.Sites tree in getClass)
            {
                //Entity.Menus mdTem = tree.Clone();
                if (tree.ParentID == 0)
                {

                    tree.SiteName = sPatch + string.Format("<b><font color=red>{0}</font></b><a name=\"a{1}\"></a>", tree.SiteName, tree.id);
                    getTree.Add(tree);
                    GetSubItem_pic(tree.id, ref getTree, "", getClass);
                }

            }
            return getTree;
        }
        /// <summary>
        /// 获取某个记录下的子记录，从而构建树形(递归调用)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="GetTree"></param>
        /// <param name="blank"></param>
        private void GetSubItem_pic(int id, ref List<Entity.Sites> NewClass, string blank, List<Entity.Sites> OldClass)
        {
            string sW3 = string.Concat("<img src=\"", Base.AppStartInit.IISPath, "Images/tree/w3.gif\" align=absmiddle>");
            string sW1 = string.Concat("<img src=\"", Base.AppStartInit.IISPath, "Images/tree/w1.gif\" align=absmiddle>");
            foreach (Entity.Sites mdModel in OldClass)
            {
                //Entity.Menus mdTem = mdModel.Clone();
                if (mdModel.ParentID == id)
                {
                    string str = blank;
                    str = string.Concat(str, sW3);
                    mdModel.SiteName = str + sW1 + mdModel.SiteName;
                    NewClass.Add(mdModel);
                    GetSubItem_pic(mdModel.id, ref NewClass, str, OldClass);
                }
            }
        }
        #endregion

    }
}
