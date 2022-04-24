using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using EbSite.Base;
using EbSite.Base.Modules;
using EbSite.Core.FSO;
using EbSite.Entity.Module;

namespace EbSite.BLL.ModulesBll
{

    /// <summary>
    /// 模块菜单数据处理业务层
    /// </summary>
    abstract public class ModuleMenu : Base.Datastore.XMLProviderBase<ModulePageInfo>
    {
        //virtual public void ResetMenu()
        //{
        //}

        /// <summary>
        /// 模块存放的路径
        /// </summary>
        protected string _sModulePath;
        public ModuleMenu(Guid ModuleID)
        {
            base.Id = ModuleID;
            _sModulePath = Modules.Instance.GetModelPath(ModuleID);
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(MenuPath);
            }
        }
        /// <summary>
        /// 菜单的相对保存路径
        /// </summary>
       abstract public string MenuPath{ get;}
        
        /// <summary>
        /// 存放数据文件的路径 如"DataStore/Menus_Admin.txt"
        /// </summary>
        //protected abstract string DataBaseFile{ get;}
        /// <summary>
        /// 路由文件名称
        /// </summary>
        protected abstract string PagePath { get; }
       
        ///// <summary>
        ///// 复位菜单－－公用　卸载模块时也要用
        ///// </summary>
        //public void DelPomission(Guid sModuleID)
        //{
        //    List<Entity.ResponQx> list = BLL.ResponQx.Instance.GetListArray("modulesId='" + sModuleID + "'");

        //    foreach (Entity.ResponQx menuse in list)
        //    {
        //        BLL.ResponQx.Instance.Delete(menuse.id);
        //    }
        //}
        virtual public void AddMenuToSysMemu(Guid menuid, string sMunuName, string ImageUrl, Guid ModulesID, Guid ParentID, string PageUrl,string ParentUrl,ThemeType tt)
        {
            
        }
        virtual public void AddModuleNameToSysMemu(Guid menuid, string sMunuName, string ImageUrl, Guid ModulesID, Guid ParentID)
        {
        }
        virtual public void DeleteByModuleID(Guid ModuleID)
        {
            
        }
        /// <summary>
        /// 重新生成菜单,将删除原来旧的菜单，重新生成
        /// </summary>
        /// <param name="pgCurrent"></param>
        public void ReMakeMenus(Page pgCurrent, List<MPage> lstMPage)
        {
            //如果已经存在先删除
            if (Core.FSO.FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                Core.FSO.FObject.Delete(SavePath, FsoMethod.Folder);

            }

            //先删除此模块下的所有菜单
            //BLL.Menus.Instance.DeleteByModuleID(base.Id);
            DeleteByModuleID(base.Id);

            //开始生成菜单
            string sModuleName = Modules.Instance.GetModelName(base.Id);

            List<ModulePageInfo> lstParent = InitMenus(pgCurrent, lstMPage);


           //添加到扩展功能菜单下

            string sImgUrl = IISPath + "images/Menus/category.png";
            AddModuleNameToSysMemu(base.Id, sModuleName, sImgUrl, base.Id, new Guid("eabb6dbe-018e-4a9c-870a-8e0311c72a2d"));
            foreach (ModulePageInfo pageInfo in lstParent)
            {
                sImgUrl = IISPath + "images/Menus/menuMake.png";
                AddMenuToSysMemu(pageInfo.id, pageInfo.PageName, sImgUrl, base.Id, base.Id, pageInfo.GetRealUrl(), pageInfo.FileName, (ThemeType)pageInfo.ThemesType);
            }


        }

        //public abstract List<MPage> GetMPages();
        //public void ReMakeMenus(Page pgCurrent)
        //{
        //    ReMakeMenus(pgCurrent, GetMPages());
        //}

        //public List<ModulePageInfo> InitMenus(Page pgCurrent)
        //{
        //    return InitMenus(pgCurrent, GetMPages());
        //}

        /// <summary>
        /// 由页面生成菜单项
        /// </summary>
        public List<ModulePageInfo> InitMenus(Page pgCurrent, List<MPage> lstMPage)
        {

            List<ModulePageInfo> lstParentMenus = new List<ModulePageInfo>();
            if (!Core.FSO.FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                //先创建文件夹
                Core.FSO.FObject.Create(SavePath, FsoMethod.Folder);

                foreach (MPage mPage in lstMPage)
                {
                    //添加父级菜单
                    string MpageName = mPage.GetType().Name;
                    ModulePageInfo mdParent = new ModulePageInfo();
                    mdParent.PageName = mPage.PageName;//页面名称
                    mdParent.FileName = string.Concat(_sModulePath, PagePath, "/", MpageName,".aspx"); //得到路由页面地址
                    mdParent.OrderID = mPage.OrderID;
                    mdParent.ParentID = Guid.Empty;
                    mdParent.HelpHtml = "";
                    mdParent.ModuleID = base.Id;
                    mdParent.ParentUrl = "";
                    mdParent.id = mPage.ModuleMenuID;
                    mdParent.ThemesType = (int)mPage.ThemesType;
                    

                    Add(mdParent);
                    lstParentMenus.Add(mdParent);


                    //添加子菜单
                    string sGetPagePath = string.Concat(_sModulePath, PagePath, "/Controls/", MpageName, "/");
                    FileInfo[] lst = Core.FSO.FObject.GetFileListByType(sGetPagePath, "ascx");
                    
                    foreach (FileInfo AscxFileName in lst)
                    {
                        Base.ControlPage.UserControlBase pg = (Base.ControlPage.UserControlBase)pgCurrent.LoadControl(string.Concat(sGetPagePath, AscxFileName));
                        ModulePageInfo mdSub = new ModulePageInfo();
                        mdSub.PageName = pg.PageName;
                        mdSub.FileName = AscxFileName.Name;
                        mdSub.OrderID = pg.OrderID;
                        mdSub.ParentID = mdParent.id;
                        mdSub.HelpHtml = "";
                        mdSub.ModuleID = base.Id;
                        mdSub.ParentUrl = mdParent.FileName;
                        mdSub.EnableTagLink = pg.EnableTagLink;
                        if (pg.ModuleMenuID != Guid.Empty) ////指定生成菜单ID
                        {
                            mdSub.id = pg.ModuleMenuID;
                        }
                        mdSub.Permission = pg.Permission;
                        mdSub.IsAddToAdminMenus = pg.IsAddToAdminMenus;
                        Add(mdSub);

                    }
                }

                #region old

                //string fileNameMunu = HttpContext.Current.Server.MapPath(string.Concat(_sModulePath, DataBaseFile));

                //if (File.Exists(fileNameMunu))
                //{
                //    string sContent = Core.FSO.FObject.ReadFile(fileNameMunu);

                //    Regex re = new Regex("\r\n");

                //    string[] PagesList = re.Split(sContent);
                //    int iIndex = 1;
                //    foreach (string sPageName in PagesList)
                //    {
                //        string[] aV = sPageName.Split('|');  //数据格式为 常用查询|CusttomQuery.aspx
                //        if (aV.Length > 1)
                //        {
                //            string fName = string.Concat(_sModulePath,PagePath, "/", aV[1]); //得到路由页面地址

                //            if (File.Exists(HttpContext.Current.Server.MapPath(fName)))
                //            {
                //                //添加父级菜单
                //                ModulePageInfo mdParent = new ModulePageInfo();
                //                mdParent.PageName = aV[0];//页面名称
                //                mdParent.FileName = fName; //得到路由页面地址
                //                mdParent.OrderID = iIndex;
                //                mdParent.ParentID = Guid.Empty;
                //                mdParent.HelpHtml = "";
                //                mdParent.ModuleID = base.Id;
                //                mdParent.ParentUrl = "";
                //                if (aV.Length==3) //指定生成菜单ID
                //                {
                //                    mdParent.id = new Guid(aV[2]);
                //                }
                //                Add(mdParent);
                //                lstParentMenus.Add(mdParent);
                //                iIndex++;

                //                //添加子菜单
                //                string sGetPagePath = string.Concat(_sModulePath, PagePath,"/Controls/", aV[1].Replace(".aspx", ""), "/");
                //                FileInfo[] lst = Core.FSO.FObject.GetFileListByType(sGetPagePath, "ascx");
                //                //List<ModulePageInfo> lstAscx = new List<ModulePageInfo>();
                //                foreach (FileInfo AscxFileName in lst)
                //                {
                //                    Base.ControlPage.UserControlBase pg = (Base.ControlPage.UserControlBase)pgCurrent.LoadControl(string.Concat(sGetPagePath, AscxFileName));
                //                    //if (pg.IsAddToAdminMenus)
                //                    //{
                //                        ModulePageInfo mdSub = new ModulePageInfo();
                //                        mdSub.PageName = pg.PageName;
                //                        mdSub.FileName = AscxFileName.Name;// string.Concat(mdParent.FileName, "?acx=", AscxFileName.Name.Replace(".ascx", ""));
                //                        mdSub.OrderID = pg.OrderID;
                //                        mdSub.ParentID = mdParent.id;
                //                        mdSub.HelpHtml = "";
                //                        mdSub.ModuleID = base.Id;
                //                        mdSub.ParentUrl = mdParent.FileName;
                //                        mdSub.EnableTagLink = pg.EnableTagLink;
                //                        if (pg.ModuleMenuID != Guid.Empty) ////指定生成菜单ID
                //                        {
                //                            mdSub.id = pg.ModuleMenuID;
                //                        }
                //                        mdSub.Permission = pg.Permission;
                //                        mdSub.IsAddToAdminMenus = pg.IsAddToAdminMenus;
                //                        Add(mdSub);
                //                    //}

                //                }

                //            }
                //        }
                //        else
                //        {
                //            if (iIndex == 1)
                //                Base.AppStartInit.TipsPageRender("出错了", "存在[" + DataBaseFile + "],但里面没有设置菜单:" + fileNameMunu, "");

                //        }

                //    }


                //}
                //else
                //{
                //    Base.AppStartInit.TipsPageRender("出错了", "找不到菜单列表文件[" + DataBaseFile + "]:" + fileNameMunu, "");
                //}
                #endregion

            }

            return lstParentMenus;
        }
        /// <summary>
        /// 获取子菜单
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        public List<ModulePageInfo> GetSubMenu(Guid ParentID)
        {
            string CacheKey = string.Concat("GetSubMenu-" , ParentID);
            List<ModulePageInfo> lp = base.GetCacheItem<List<ModulePageInfo>>(CacheKey);
            if (Equals(lp,null))
            {
                lp = new List<ModulePageInfo>();
                List<ModulePageInfo> lp2 = new List<ModulePageInfo>();
                foreach (ModulePageInfo mp in base.lstDataList)
                {
                    if (Equals(mp.ParentID, ParentID))
                    {
                        if (mp.IsAddToAdminMenus)
                            lp.Add(mp);
                        else
                        {
                            lp2.Add(mp);
                        }

                    }

                }
                lp.Sort();
                lp.AddRange(lp2);
                base.AddCacheItem(CacheKey, lp);
            }

            return lp ;

            //List<ModulePageInfo> lp = new List<ModulePageInfo>();
            //List<ModulePageInfo> lp2 = new List<ModulePageInfo>();
            //foreach (ModulePageInfo mp in base.lstDataList)
            //{
            //    if (Equals(mp.ParentID, ParentID))
            //    {
            //        if(mp.IsAddToAdminMenus)
            //        lp.Add(mp);
            //        else
            //        {
            //            lp2.Add(mp);
            //        }
                    
            //    }
                
            //}
            //lp.Sort();

            //lp.AddRange(lp2);

            //return lp;
        }
        //public List<ModulePageInfo> GetSubMenuToShow(Guid ParentID)
        //{
        //    List<ModulePageInfo> lp = new List<ModulePageInfo>();
        //    foreach (ModulePageInfo mp in base.lstDataList)
        //    {
        //        if (Equals(mp.ParentID, ParentID) && mp.IsAddToAdminMenus)
        //            lp.Add(mp);
        //    }
        //    lp.Sort();
        //    return lp;
        //}
        /// <summary>
        /// 获取低级菜单
        /// </summary>
        /// <returns></returns>
        public List<ModulePageInfo> GetParentMenu()
        {
            List<ModulePageInfo> lp = new List<ModulePageInfo>();
            foreach (ModulePageInfo mp in base.lstDataList)
            {
                if (Equals(mp.ParentID, Guid.Empty))
                    lp.Add(mp);
            }
            return lp;
        }
        /// <summary>
        /// 获取某个父级菜单的第一个子类真实地址
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public string GetFirstUrlByParentID(Guid pid)
        {
            List<ModulePageInfo> lst = GetSubMenu(pid);
            if (lst.Count > 0)
            {
                return lst[0].GetRealUrl();
            }
            else
            {
                Tips("出错了", "找不到当前父菜单下的子菜单");
            }
            return "";
        }


        public List<ModulePageInfo> GetTree_pic()
        {
            List<ModulePageInfo> getClass = lstDataList;
            List<ModulePageInfo> getTree = new List<ModulePageInfo>();
            getClass.Sort();
            //string sPatch1 = string.Concat("<img src=\"", Base.AppStartInit.IISPath, "Images/tree/w3.gif\" align=absmiddle>");
            string sPatch = string.Concat("<img src=\"", Base.AppStartInit.IISPath, "Images/tree/w1.gif\" align=absmiddle>");
            foreach (ModulePageInfo tree in getClass)
            {
                ModulePageInfo mdTem = tree.Clone(tree);
                if (mdTem.ParentID == Guid.Empty)
                {

                    mdTem.PageName = sPatch + string.Format("<b><font color=red>{0}</font></b><a name=\"a{1}\"></a>", mdTem.PageName, mdTem.id);
                    mdTem.PageName = mdTem.PageName;
                    getTree.Add(mdTem);
                    GetSubItem_pic(mdTem.id, ref getTree, "", getClass);
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
        private void GetSubItem_pic(Guid id, ref List<ModulePageInfo> NewClass, string blank, List<ModulePageInfo> OldClass)
        {
            string sW3 = string.Concat("<img src=\"", Base.AppStartInit.IISPath, "Images/tree/w3.gif\" align=absmiddle>");
            string sW1 = string.Concat("<img src=\"", Base.AppStartInit.IISPath, "Images/tree/w1.gif\" align=absmiddle>");
            foreach (ModulePageInfo mdModel in OldClass)
            {
                ModulePageInfo mdTem = mdModel.Clone(mdModel);
                if (mdTem.ParentID == id)
                {
                    string str = blank;
                    str = string.Concat(str, sW3);
                    mdTem.PageName = str + sW1 + mdTem.PageName;
                    mdTem.PageName = mdTem.PageName;
                    NewClass.Add(mdTem);
                    GetSubItem_pic(mdTem.id, ref NewClass, str, OldClass);
                }
            }
        }


        public List<ModulePageInfo> GetTree()
        {
            List<ModulePageInfo> getClass = lstDataList;
            List<ModulePageInfo> getTree = new List<ModulePageInfo>();
            getClass.Sort();

            foreach (ModulePageInfo tree in getClass)
            {
                ModulePageInfo mdTem = tree.Clone(tree);
                if (mdTem.ParentID == Guid.Empty)
                {

                    mdTem.PageName = mdTem.PageName;
                    getTree.Add(mdTem);
                    GetSubItem(mdTem.id, ref getTree, "", getClass);
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
        private void GetSubItem(Guid id, ref List<ModulePageInfo> NewClass, string blank, List<ModulePageInfo> OldClass)
        {
            foreach (ModulePageInfo mdModel in OldClass)
            {
                ModulePageInfo mdTem = mdModel.Clone(mdModel);
                if (mdTem.ParentID == id)
                {
                    string str = blank;
                    mdTem.PageName = mdTem.PageName;
                    NewClass.Add(mdTem);
                    GetSubItem_pic(mdTem.id, ref NewClass, str, OldClass);
                }
            }
        }
        
        /// <summary>
        /// 获取控件的存放目录，与访问的页面名称相同
        /// </summary>
        /// <param name="sPath">页面路径</param>
        /// <returns></returns>
        public static string GetControlFolderName(string sPath)
        {
            //string strFilePath = HttpContext.Current.Request.FilePath;
            string strFileName = Core.Strings.GetString.GetFileName(sPath);

            return strFileName.Substring(0, strFileName.Length - 5);
        }
        
    }

}
