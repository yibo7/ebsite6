using System;
using System.Collections.Specialized;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.Static;
using EbSite.Core;
namespace EbSite.BLL
{
    /// <summary>
    /// 业务逻辑类MenusForUser 的摘要说明。
    /// </summary>
    public class MenusForUser : Base.BLL.BllBase<Entity.MenusForUser, Guid>
    {
        public static readonly MenusForUser Instance = new MenusForUser();
        private MenusForUser()
        {
        }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid id)
        {
            return dal.MenusForUser_Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        override public Guid Add(Entity.MenusForUser model)
        {
            if (model.id == Guid.Empty)
                model.id = Guid.NewGuid();

            model.OrderID = GetMaxOrderID(model.ParentID) + 1;
            dal.MenusForUser_Add(model);
            base.InvalidateCache();
            return model.id;
        }
        public int GetMaxOrderID(Guid iParentClassID)
        {
            return dal.MenusForUser_GetMaxOrderID(iParentClassID);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        override public void Update(Entity.MenusForUser model)
        {
            dal.MenusForUser_Update(model);
            base.InvalidateCache();
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        override public void Delete(Guid id)
        {

            dal.MenusForUser_Delete(id);
            base.InvalidateCache();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        override public Entity.MenusForUser GetEntity(Guid id)
        {

            return dal.MenusForUser_GetEntity(id);
        }

        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //override public Entity.MenusForUser GetEntityStrID(Guid id)
        //{

        //    return  GetEntity(id);
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.MenusForUser_GetCount(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public int GetCount()
        {
            return GetCount("");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return GetListCache(0, strWhere, "");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList()
        {
            return GetList("");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.MenusForUser_GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListCache(int Top, string strWhere, string filedOrder)
        {
            return GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.MenusForUser> GetListArray(int Top, string strWhere, string filedOrder)
        {
            return dal.MenusForUser_GetListArray(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.MenusForUser> GetListArrayCache(int Top, string strWhere, string filedOrder, bool IsCache)
        {

            if (string.IsNullOrEmpty(filedOrder))
                filedOrder = "orderid";
            if (IsCache)
            {
                string rawKey = string.Concat("GetListArray-", strWhere, Top, filedOrder);
                List<Entity.MenusForUser> lstData = base.GetCacheItem<List<Entity.MenusForUser>>(rawKey);
                if (Equals(lstData, null))
                {
                    //从基类调用，激活事件
                    lstData = base.GetListArrayEv(Top, strWhere, filedOrder);
                    if (!Equals(lstData, null))
                        base.AddCacheItem(rawKey, lstData);
                }
                return lstData;
            }
            else
            {
                return base.GetListArrayEv(Top, strWhere, filedOrder);
            }

            //return base.GetListArrayEv(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.MenusForUser> GetListArray(int Top, string filedOrder)
        {
            return GetListArrayCache(Top, "", filedOrder, true);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.MenusForUser> GetListArray(string strWhere)
        {
            return GetListArrayCache(0, strWhere, "", true);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.MenusForUser> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            return dal.MenusForUser_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.MenusForUser> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.MenusForUser> lstData = base.GetListPagesEv(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
            return lstData;
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.MenusForUser> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, "", "", "", out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.MenusForUser> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.MenusForUser> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
        {
            int iCount = 0;
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
        }
        /// <summary>
        /// 搜索-分页
        /// </summary>
        public List<Entity.MenusForUser> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
        {
            string strWhere = "";
            if (!string.IsNullOrEmpty(sKeyWord)) strWhere = string.Format("{0} like '%{1}%'", ColumnName, sKeyWord);
            if (string.IsNullOrEmpty(strWhere))
            {
                RecordCount = 0;
                return null;
            }
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
        }
        /// <summary>
        /// 修改时获取当前实例，并载入控件到Grid
        /// </summary>
        public void InitModifyCtr(string id, PlaceHolder ph)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Guid ThisId = new Guid(id);
                Entity.MenusForUser mdEt = GetEntity(ThisId);
                foreach (System.Web.UI.Control uc in ph.Controls)
                {
                    if (Equals(uc.ID, null)) continue;
                    string sValue = "";
                    if (Equals(uc.ID.ToLower(), "id".ToLower()))
                    {
                        sValue = mdEt.id.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "MenuName".ToLower()))
                    {
                        sValue = mdEt.MenuName.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ImageUrl".ToLower()))
                    {
                        sValue = mdEt.ImageUrl.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "OrderID".ToLower()))
                    {
                        sValue = mdEt.OrderID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ParentID".ToLower()))
                    {
                        sValue = mdEt.ParentID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Target".ToLower()))
                    {
                        sValue = mdEt.Target.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ModuleMenuID".ToLower()))
                    {
                        sValue = mdEt.ModuleMenuID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "PageUrl".ToLower()))
                    {
                        sValue = mdEt.PageUrl.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "IsLeftParent".ToLower()))
                    {
                        sValue = mdEt.IsLeftParent.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ModulesID".ToLower()))
                    {
                        sValue = mdEt.ModulesID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "AddTime".ToLower()))
                    {
                        sValue = mdEt.AddTime.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "MenuType".ToLower()))
                    {
                        sValue = mdEt.MenuType.ToString();
                    }
                    Utils.SetValueFromControl(uc, sValue);
                }
            }
        }
        /// <summary>
        /// 获取控件里的数据映射到一个实体，接着保存这个实例到数据
        /// </summary>
        public void SaveEntityFromCtr(PlaceHolder ph)
        {
            SaveEntityFromCtr(ph, null);
        }
        /// <summary>
        /// 获取控件里的数据映射到一个实体，接着保存这个实例到数据
        /// </summary>
        public void SaveEntityFromCtr(PlaceHolder ph, List<Base.BLL.OtherColumn> lstOtherColumn)
        {
            Entity.MenusForUser mdEntity = GetEntityFromCtr(ph);
            if (!Equals(lstOtherColumn, null) && lstOtherColumn.Count > 0)
            {
                foreach (Base.BLL.OtherColumn column in lstOtherColumn)
                {
                    if (Equals(column.ColumnName.ToLower(), "id".ToLower()))
                    {
                        mdEntity.id = new Guid(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "MenuName".ToLower()))
                    {
                        mdEntity.MenuName = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ImageUrl".ToLower()))
                    {
                        mdEntity.ImageUrl = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "OrderID".ToLower()))
                    {
                        mdEntity.OrderID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ParentID".ToLower()))
                    {
                        mdEntity.ParentID = new Guid(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Target".ToLower()))
                    {
                        mdEntity.Target = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ModuleMenuID".ToLower()))
                    {
                        mdEntity.ModuleMenuID = new Guid(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "PageUrl".ToLower()))
                    {
                        mdEntity.PageUrl = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "IsLeftParent".ToLower()))
                    {
                        mdEntity.IsLeftParent = bool.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ModulesID".ToLower()))
                    {
                        mdEntity.ModulesID = new Guid(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "AddTime".ToLower()))
                    {
                        mdEntity.AddTime = DateTime.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "MenuType".ToLower()))
                    {
                        mdEntity.MenuType = (ThemeType)int.Parse(column.ColumnValue);
                    }
                }
            }
            if (!mdEntity.IsNew)
            {
                Update(mdEntity);
            }
            else
            {
                Add(mdEntity);
            }
        }
        /// <summary>
        /// 从Grid中获取一个实例
        /// </summary>
        public Entity.MenusForUser GetEntityFromCtr(PlaceHolder ph)
        {
            Entity.MenusForUser mdEt = new Entity.MenusForUser();
            string sKeyID;
            if (GetIDFromCtr(ph, out sKeyID))
            {
                mdEt = GetEntity(new Guid(sKeyID));
            }
            foreach (System.Web.UI.Control uc in ph.Controls)
            {
                if (Equals(uc.ID, null)) continue;
                string sValue = Utils.GetValueFromControl(uc);
                if (Equals(uc.ID.ToLower(), "id".ToLower()))
                {
                    mdEt.id = new Guid(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "MenuName".ToLower()))
                {
                    mdEt.MenuName = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "ImageUrl".ToLower()))
                {
                    mdEt.ImageUrl = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "OrderID".ToLower()))
                {
                    mdEt.OrderID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "ParentID".ToLower()))
                {
                    mdEt.ParentID = new Guid(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "Target".ToLower()))
                {
                    mdEt.Target = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "ModuleMenuID".ToLower()))
                {
                    mdEt.ModuleMenuID = new Guid(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "PageUrl".ToLower()))
                {
                    mdEt.PageUrl = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "IsLeftParent".ToLower()))
                {
                    mdEt.IsLeftParent = bool.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "ModulesID".ToLower()))
                {
                    mdEt.ModulesID = new Guid(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "AddTime".ToLower()))
                {
                    mdEt.AddTime = DateTime.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "MenuType".ToLower()))
                {
                    mdEt.MenuType = (ThemeType)int.Parse(sValue);
                }
            }
            return mdEt;
        }

        #endregion  成员方法

        #region  自定义方法
        /// <summary>
        /// 获取用户菜单（当前用户组没有访问权限将不列出）
        /// </summary>
        /// <param name="ParentID">父ID</param>
        /// <param name="MenuType">菜单类型，0为PC版,1为移动版</param>
        /// <returns></returns>
        public List<Entity.MenusForUser> GetMenusByParentID(Guid ParentID, ThemeType MenuType)
        {
            int rids = EbSite.Base.Host.Instance.RoleID;
            string CacheKey =string.Concat("GetMenusByParentID_" , rids);

            List<Entity.MenusForUser> lstSubs = Host.CacheApp.GetCacheItem<List<Entity.MenusForUser>>(CacheKey, "MenusForUser");
            if (Equals(lstSubs, null))
            {
                lstSubs = new List<Entity.MenusForUser>();
                BLL.MenusForUserRole mfu = new MenusForUserRole();
                List<Entity.MenusForUser> lst = GetListArray(0, "");
                //List<Entity.MenusForUser> lstSubs = new List<Entity.MenusForUser>();
                foreach (Entity.MenusForUser menusForUser in lst)
                {
                    if (menusForUser.ParentID.Equals(ParentID) && menusForUser.MenuType == MenuType)
                    {
                        if (mfu.IsHave(rids, menusForUser.id))
                        {
                            lstSubs.Add(menusForUser);
                        }
                    }
                }

                if (lstSubs.Count > 0)
                {
                    Host.CacheApp.AddCacheItem(CacheKey, lstSubs, 30, ETimeSpanModel.T, "MenusForUser");
                }
               
            }

            return lstSubs;
           
        }

        public List<Entity.MenusForUser> GetTree_pic(int iTop)
        {
            List<Entity.MenusForUser> getClass = GetListArrayCache(iTop, "", "", false);
            List<Entity.MenusForUser> getTree = new List<Entity.MenusForUser>();

            string sPatch = string.Concat("<img src=\"", Base.AppStartInit.IISPath, "Images/tree/w1.gif\" align=absmiddle>");
            foreach (Entity.MenusForUser tree in getClass)
            {
                //Entity.Menus mdTem = tree.Clone();
                if (tree.ParentID == Guid.Empty)
                {

                    tree.MenuName = sPatch + string.Format("<b><font color=red>{0}</font></b><a name=\"a{1}\"></a>", tree.MenuName, tree.id);
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
        private void GetSubItem_pic(Guid id, ref List<Entity.MenusForUser> NewClass, string blank, List<Entity.MenusForUser> OldClass)
        {
            string sW3 = string.Concat("<img src=\"", Base.AppStartInit.IISPath, "Images/tree/w3.gif\" align=absmiddle>");
            string sW1 = string.Concat("<img src=\"", Base.AppStartInit.IISPath, "Images/tree/w1.gif\" align=absmiddle>");
            foreach (Entity.MenusForUser mdModel in OldClass)
            {
                if (mdModel.ParentID == id)
                {
                    string str = blank;
                    str = string.Concat(str, sW3);
                    mdModel.MenuName = str + sW1 + mdModel.MenuName;
                    NewClass.Add(mdModel);
                    GetSubItem_pic(mdModel.id, ref NewClass, str, OldClass);
                }
            }
        }
        public List<Entity.MenusForUser> GetTree(int iTop)
        {

            List<Entity.MenusForUser> getClass = GetListArrayCache(iTop, "", "", false);
            List<Entity.MenusForUser> getTree = new List<Entity.MenusForUser>();

            foreach (Entity.MenusForUser tree in getClass)
            {
                if (tree.ParentID == Guid.Empty)
                {
                    tree.MenuName = "╋" + tree.MenuName;
                    getTree.Add(tree);
                    GetSubItem(tree.id, ref getTree, "├", getClass);
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
        private void GetSubItem(Guid id, ref List<Entity.MenusForUser> NewClass, string blank, List<Entity.MenusForUser> OldClass)
        {
            foreach (Entity.MenusForUser mdModel in OldClass)
            {
                if (mdModel.ParentID == id)
                {

                    string str = blank + "─";
                    mdModel.MenuName = str + "『" + mdModel.MenuName + "』";
                    NewClass.Add(mdModel);
                    GetSubItem(mdModel.id, ref NewClass, str, OldClass);
                }

            }
        }



        /// <summary>
        /// 移动分类
        /// </summary>
        /// <param name="SoureClassID">源分类ID</param>
        /// <param name="TargetClassID">目标分类ID</param>
        /// <param name="IsAsChildnode">是否作为目标分类的子分类</param>
        public void MoveClass(Guid SoureClassID, Guid TargetClassID, bool IsAsChildnode)
        {
            Entity.MenusForUser md = GetEntity(TargetClassID);

            if (md.ParentID == SoureClassID)
            {
                //Tips("出错了", "父分类不能移到子分类下，如果您有这样的需求请先将子分类移出，再做移动！");
                Core.Strings.cJavascripts.MessageShowBack("父分类不能移到子分类下，如果您有这样的需求请先将子分类移出，再做移动！");
                return;
            }
            base.InvalidateCache();
            dal.MenusForUser_Move(SoureClassID, TargetClassID, IsAsChildnode);
        }
        /// <summary>
        /// 重新调整排序ID
        /// </summary>
        public void ResetOrderID_Start()
        {
            List<Entity.MenusForUser> aIDs = GetSubMenusByParentID(Guid.Empty);
            ResetOrderID(aIDs);

        }
        private List<Entity.MenusForUser> GetSubMenusByParentID(Guid gParentID)
        {
            string sWhere = string.Format("ParentID='{0}'", gParentID);
            List<Entity.MenusForUser> lst = GetListArray(sWhere);
            List<Entity.MenusForUser> lstID = new List<Entity.MenusForUser>();
            foreach (Entity.MenusForUser menu in lst)
            {
                if (Equals(menu.ParentID, gParentID))
                {
                    lstID.Add(menu);
                }
            }
            return lstID;
        }
        private void ResetOrderID(List<Entity.MenusForUser> iIDS)
        {
            if (iIDS.Count > 0)
            {
                for (int i = 0; i < iIDS.Count; i++)
                {
                    Entity.MenusForUser iCurrentID = iIDS[i];

                    iCurrentID.OrderID = i + 1;

                    iCurrentID.Update();

                    //DbProviderCms.GetInstance().NewsClass_UpdateOrderID(iCurrentID, (i + 1));

                    List<Entity.MenusForUser> aSubIDs = GetSubMenusByParentID(iCurrentID.id);

                    ResetOrderID(aSubIDs);
                }
            }

        }

        public string GetLinkFormReWritePath(string ReWritePath)
        {

            //模块菜单ID
            string sMemuID = HttpContext.Current.Request["mukey"];
            string sUrl = "";
            List<Entity.MenusForUser> lst = GetListArray("");//需要重构，提高性能
            foreach (Entity.MenusForUser menu in lst)
            {
                if (menu.Target.ToLower().Equals(ReWritePath))
                {
                    sUrl = string.Format("{0}?muid={1}&mid={2}", menu.PageUrl, string.IsNullOrEmpty(sMemuID) ? menu.ModuleMenuID.ToString() : sMemuID, menu.ModulesID);
                    break;
                }
            }

            if (HttpContext.Current.Request.QueryString.HasKeys())
            {
                NameValueCollection nvc = HttpContext.Current.Request.QueryString;

                sUrl = string.Concat(sUrl, "&", nvc);
            }
            return sUrl;
        }

        public void DeleteByModulID(Guid mid)
        {
            dal.MenusForUser_DeleteByModulID(mid);

            //要同时删除与此菜单关联的显示权限(未实现)

        }
        public string GetUrlByID(Guid ParentID, Guid SubID, bool IsEX)
        {
            Entity.MenusForUser md = GetEntity(ParentID);
            if (md != null)
            {
                return string.Concat(md.Url, "?mukey=", SubID);
            }
            else
            {
                if (IsEX)
                    throw new Exception("找不到当前菜单:" + ParentID + ",请确认是否已经安装此模块并将此菜单添加用户菜单,常见可能没有安装EbSite.Modules.UserBaseInfo基础用户模块!");
                else
                {

                    return EbSite.Base.Host.Instance.GetTipsUrl(6);
                }
            }
        }

        //public string GetUrlByID(Guid ParentID, Guid SubID)
        //{
        //    return GetUrlByID(ParentID, SubID, true);
        //}
        /// <summary>
        /// 获取个人网站创建页面
        /// </summary>
        public string GetSpaceSettingUrl
        {
            get
            { 
                return GetUrlByID(new Guid("fd7ba88c-ee87-4865-8ff5-6f9c871a9cbb"), new Guid("af371bdd-f674-4077-a9ed-e2896fb4c857"),true);
            }
        }


        #endregion  自定义方法


    }
}

