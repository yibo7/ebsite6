using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using EbSite.Base.Static;

namespace EbSite.BLL
{
    /// <summary>
    /// 业务逻辑类Menus 的摘要说明。
    /// </summary>
    public class Menus : Base.BLL.BllBase<Entity.Menus, Guid>
    {

        public static readonly Menus Instance = new Menus();
        private Menus()
        {
        }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid id)
        {
            return dal.Menus_Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        override public Guid Add(Entity.Menus model)
        {
            base.InvalidateCache();
            if (model.id==Guid.Empty)
                model.id = Guid.NewGuid();

            model.OrderID = GetMaxOrderID(model.ParentID) + 1;

            dal.Menus_Add(model);
            
            return Guid.Empty;

        }

        public int GetMaxOrderID(Guid iParentClassID)
        {
            return dal.Menus_GetMaxOrderID(iParentClassID);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        override public void Update(Entity.Menus model)
        {
            base.InvalidateCache();
            dal.Menus_Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        override public void Delete(Guid id)
        {
            base.InvalidateCache();

            dal.Menus_Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        override public Entity.Menus GetEntity(Guid id)
        {

            string rawKey = string.Concat("GetEntity-", id);
            Entity.Menus etEntity = base.GetCacheItem<Entity.Menus>(rawKey);
            if (Equals(etEntity, null))
            {
                etEntity = dal.Menus_GetEntity(id);
                if (!Equals(etEntity, null))
                    base.AddCacheItem(rawKey, etEntity);
            }
            return etEntity;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.Menus_GetCount(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public int GetCountCache(string strWhere)
        {
            string rawKey = string.Concat("GetCount-", strWhere);
            string sCount = base.GetCacheItem<string>(rawKey) ;
            if (string.IsNullOrEmpty(sCount))
            {
                sCount = GetCount(strWhere).ToString();
                if (!string.IsNullOrEmpty(sCount))
                    base.AddCacheItem(rawKey, sCount);
            }
            if (!string.IsNullOrEmpty(sCount))
            {
                return int.Parse(sCount);
            }
            return 0;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public int GetCount()
        {
            return GetCountCache("");
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
            return dal.Menus_GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
      
        public DataSet GetListCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetListCache-", strWhere, Top, filedOrder);
            byte[] ibyte = base.GetCacheItem<byte[]>(rawKey);
            DataSet lstData = null;
            if (Equals(ibyte, null))
            {
                lstData = GetList(Top, strWhere, filedOrder);
                ibyte = EbSite.Core.DataSetHelper.GetBinaryFormatDataSet(lstData);
                if (!Equals(ibyte, null))
                    base.AddCacheItem(rawKey, ibyte);
            }
            else
            {
                lstData = Core.DataSetHelper.RetrieveDataSet(ibyte);
            }
            return lstData;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.Menus> GetListArray(int Top, string strWhere, string filedOrder)
        {
            string CacheKey = string.Concat("GetListArray-", Top, strWhere, filedOrder);
            List<Entity.Menus> mds = base.GetCacheItem<List<Entity.Menus>>(CacheKey);
            if (mds == null)
            {
                mds = dal.Menus_GetListArray(Top, strWhere, filedOrder);
                if (!Equals(mds, null))
                    base.AddCacheItem(CacheKey, mds);
            }
            return mds;
            //return dal.Menus_GetListArray(Top, strWhere, filedOrder);
        }
        public List<Entity.Menus> GetListArrayCache(int Top, string strWhere, string filedOrder)
        {
            return GetListArrayCache(Top, strWhere, filedOrder, true);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Menus> GetListArrayCache(int Top, string strWhere, string filedOrder, bool IsCache)
        {
            if (string.IsNullOrEmpty(filedOrder))
                filedOrder = "orderid";
            if (IsCache)
            {
                string rawKey = string.Concat("GetListArrayCache-", strWhere, Top, filedOrder);
                List<Entity.Menus> lstData = base.GetCacheItem<List<Entity.Menus>>(rawKey);
                if (Equals(lstData, null))
                {
                    //从基类调用，激活事件
                    lstData = dal.Menus_GetListArray(Top, strWhere, filedOrder);
                    if (!Equals(lstData, null))
                        base.AddCacheItem(rawKey, lstData);
                }
                return lstData;
            }
            else
            {
                return dal.Menus_GetListArray(Top, strWhere, filedOrder);
            }

            

            //return base.GetListArrayEv(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Menus> GetListArray(int Top)
        {
            return GetListArrayCache(Top, "", "OrderID asc",false);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Menus> GetListArray(string strWhere)
        {
            return GetListArrayCache(0, strWhere, "OrderID asc",false);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.Menus> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            return dal.Menus_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Menus> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            string rawKey = string.Concat("GlPages-", PageIndex, PageSize, strWhere, Fileds, oderby);
            string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.Menus> lstData = base.GetCacheItem<List<Entity.Menus>>(rawKey);
            int iRecordCount = -1;
            if (Equals(lstData, null))
            {
                //从基类调用，激活事件
                lstData = base.GetListPagesEv(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
                if (!Equals(lstData, null))
                {
                    base.AddCacheItem(rawKey, lstData);
                    base.AddCacheItem(rawKeyCount, RecordCount.ToString());
                }
            }
            if (iRecordCount == -1)
            {
                string sCount = base.GetCacheItem<string>(rawKeyCount);
                if (!string.IsNullOrEmpty(sCount))
                {
                    RecordCount = int.Parse(sCount);
                }
                else
                {
                    RecordCount = GetCountCache(strWhere);
                }
            }
            else
            {
                RecordCount = iRecordCount;
            }
            return lstData;
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.Menus> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, "", "", "", out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.Menus> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.Menus> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
        {
            int iCount = 0;
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
        }
        /// <summary>
        /// 搜索-分页
        /// </summary>
        public List<Entity.Menus> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
        /// 修改时获取当前实例，并载入控件到PlaceHolder
        /// </summary>
        public void InitModifyCtr(string id, PlaceHolder ph)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Guid ThisId = new Guid(id);
                Entity.Menus mdEt = GetEntity(ThisId);
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
                    else if (Equals(uc.ID.ToLower(), "PermissionID".ToLower()))
                    {
                        sValue = mdEt.PermissionID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Target".ToLower()))
                    {
                        sValue = mdEt.Target.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "CtrPath".ToLower()))
                    {
                        sValue = mdEt.CtrPath.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "PageUrl".ToLower()))
                    {
                        sValue = mdEt.PageUrl.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "AddTime".ToLower()))
                    {
                        sValue = mdEt.AddTime.ToString();
                    }
                   
                    else if (Equals(uc.ID.ToLower(), "IsLeftParent".ToLower()))
                    {
                        sValue = mdEt.IsLeftParent.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ModulesID".ToLower()))
                    {
                        sValue = mdEt.ModulesID.ToString();
                    }

                    else if (Equals(uc.ID.ToLower(), "help".ToLower()))
                    {
                        sValue = mdEt.help.ToString();
                    }
                    SetValueFromControl(uc, sValue);
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
            Entity.Menus mdEntity = GetEntityFromCtr(ph);
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
                    else if (Equals(column.ColumnName.ToLower(), "PermissionID".ToLower()))
                    {
                        mdEntity.PermissionID = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Target".ToLower()))
                    {
                        mdEntity.Target = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "CtrPath".ToLower()))
                    {
                        mdEntity.CtrPath = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "PageUrl".ToLower()))
                    {
                        mdEntity.PageUrl = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "AddTime".ToLower()))
                    {
                        mdEntity.AddTime = DateTime.Parse(column.ColumnValue);
                    }
                    
                    else if (Equals(column.ColumnName.ToLower(), "IsLeftParent".ToLower()))
                    {
                        mdEntity.IsLeftParent = bool.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ModulesID".ToLower()))
                    {
                        mdEntity.ModulesID = new Guid(column.ColumnValue);
                    }

                    else if (Equals(column.ColumnName.ToLower(), "help".ToLower()))
                    {
                        mdEntity.help = column.ColumnValue;
                    }
                }
            }
            if (mdEntity.id != Guid.Empty)
            {
                Update(mdEntity);
            }
            else
            {
                Add(mdEntity);
            }
        }
        /// <summary>
        /// 从PlaceHolder中获取一个实例
        /// </summary>
        public Entity.Menus GetEntityFromCtr(PlaceHolder ph)
        {
            Entity.Menus mdEt = new Entity.Menus();
            string sKeyID;
            if (GetIDFromCtr(ph, out sKeyID))
            {
                mdEt = GetEntity(new Guid(sKeyID));
            }
            foreach (System.Web.UI.Control uc in ph.Controls)
            {
                if (Equals(uc.ID, null)) continue;
                string sValue = GetValueFromControl(uc);
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
                else if (Equals(uc.ID.ToLower(), "PermissionID".ToLower()))
                {
                    mdEt.PermissionID = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "Target".ToLower()))
                {
                    mdEt.Target = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "CtrPath".ToLower()))
                {
                    mdEt.CtrPath = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "PageUrl".ToLower()))
                {
                    mdEt.PageUrl = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "AddTime".ToLower()))
                {
                    mdEt.AddTime = DateTime.Parse(sValue);
                }
                
                else if (Equals(uc.ID.ToLower(), "IsLeftParent".ToLower()))
                {
                    mdEt.IsLeftParent = bool.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "ModulesID".ToLower()))
                {
                    mdEt.ModulesID = new Guid(sValue);
                }

                else if (Equals(uc.ID.ToLower(), "help".ToLower()))
                {
                    mdEt.help = sValue;
                }
            }
            return mdEt;
        }

        #endregion  成员方法

        #region  自定义方法

        public List<Entity.Menus> GetMenusByParentID(Guid ParentID,string UserName)
        {
           
             List<Entity.Menus> listNew = new List<Entity.Menus>();
            List<Entity.Menus> list = GetMenusByParentID(ParentID);
            foreach (var md in list)
            {
                if (!string.IsNullOrEmpty(md.PermissionID))
                {
                    if (AdminPrincipal.IsHaveLimit(md.PermissionID, UserName))
                    {
                        listNew.Add(md);
                    }
                }
                else
                {
                    listNew.Add(md);
                }
                
            }
            return listNew;
        }
        public List<Entity.Menus> GetMenusByParentID(Guid ParentID)
        {
            int iSiteId = EbSite.Base.Host.Instance.GetSiteID;
            string CacheKey = string.Concat("GetMenusByParentID-", ParentID, iSiteId);
      
            List<Entity.Menus> mds =EbSite.Base.Host.CacheRawApp.GetCacheItem<List<Entity.Menus>>(CacheKey,"ebmenus") ;
      
            if (mds == null)
            {
          
                mds = dal.Menus_GetListByParentID(ParentID, iSiteId);
             
                if (!Equals(mds, null))
                    EbSite.Base.Host.CacheRawApp.AddCacheItem(CacheKey,mds,60,ETimeSpanModel.FZ, "ebmenus"); //base.AddCacheItem(CacheKey, mds);
                
            }

          
            return mds;

            //return dal.Menus_GetListByParentID(ParentID, EbSite.Base.Host.Instance.CurrentSite.id);

        }

        //public List<Entity.Menus> GetMenusByParentID(Guid ParentID)
        //{
        //    // List<Entity.Menus> lst = GetListArrayCache(0, string.Format("ParentID='{0}'", ParentID), "orderid asc");
        //    List<Entity.Menus> lst = GetListArray(0, string.Format("ParentID='{0}'", ParentID), "orderid");

        //    List<Entity.Menus> lstNew = new List<Entity.Menus>();

           

        //    }

        //    return lstNew;
        //}

        public List<Entity.Menus> GetMenusByUser(Guid ParentID)
        {

            List<Entity.Menus> lst = GetListArray(0, string.Format("ParentID='{0}'", ParentID), "orderid asc");

            List<Entity.Menus> lstNew = new List<Entity.Menus>();

            foreach (Entity.Menus menuse in lst)
            {
                //对菜单的权限控制
                //if (BLL.Username.Instance.IsHavePermission(menuse.PermissionID))
                //{

                //    lstNew.Add(menuse);
                //}


            }

            return lstNew;
        }
        public List<Entity.Menus> GetTree_pic(int iTop)
        {
            List<Entity.Menus> getClass = GetListArrayCache(iTop, "", "", false);
            List<Entity.Menus> getTree = new List<Entity.Menus>();


            string sPatch = string.Concat("<img src=\"", Base.AppStartInit.IISPath, "Images/tree/w1.gif\" align=absmiddle>");
            foreach (Entity.Menus tree in getClass)
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
        private void GetSubItem_pic(Guid id, ref List<Entity.Menus> NewClass, string blank, List<Entity.Menus> OldClass)
        {
            string sW3 = string.Concat("<img src=\"", Base.AppStartInit.IISPath, "Images/tree/w3.gif\" align=absmiddle>");
            string sW1 = string.Concat("<img src=\"", Base.AppStartInit.IISPath, "Images/tree/w1.gif\" align=absmiddle>");
            foreach (Entity.Menus mdModel in OldClass)
            {
                //Entity.Menus mdTem = mdModel.Clone();
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
        public List<Entity.Menus> GetTree(int iTop)
        {

            List<Entity.Menus> getClass = GetListArrayCache(iTop, "", "", false);
            List<Entity.Menus> getTree = new List<Entity.Menus>();

            foreach (Entity.Menus tree in getClass)
            {
                if (tree.ParentID == Guid.Empty)
                {
                    tree.MenuName = "╋" + tree.MenuName;
                    getTree.Add(tree);
                    GetSubItem(tree.id, ref getTree, "├", getClass);
                }

            }
            return getTree;

            //string rawKey = string.Concat("GetTree-", iTop);
            //List<Entity.Menus> getTree = base.GetCacheItem(rawKey) as List<Entity.Menus>;
            //if (Equals(getTree, null))
            //{
            //    List<Entity.Menus> getClass = GetListArray(iTop);

            //    getTree = new List<Entity.Menus>();
            //    foreach (Entity.Menus mdModel in getClass)
            //    {
            //        //Entity.Menus mdTem = mdModel.Clone();
            //        if (mdModel.ParentID == Guid.Empty)
            //        {
            //            mdModel.MenuName = "╋" + mdModel.MenuName;
            //            getTree.Add(mdModel);
            //            GetSubItem(mdTem.id, ref getTree, "├", getClass);
            //        }

            //    }
            //    base.AddCacheItem(rawKey, getClass);
            //}

            //return getTree;// getTree;
        }
        /// <summary>
        /// 获取某个记录下的子记录，从而构建树形(递归调用)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="GetTree"></param>
        /// <param name="blank"></param>
        private void GetSubItem(Guid id, ref List<Entity.Menus> NewClass, string blank, List<Entity.Menus> OldClass)
        {
            foreach (Entity.Menus mdModel in OldClass)
            {
                if (mdModel.ParentID == id)
                {

                    string str = blank + "─";
                    mdModel.MenuName = str + "『" + mdModel.MenuName + "』";
                    NewClass.Add(mdModel);
                    GetSubItem(mdModel.id, ref NewClass, str, OldClass);
                }

                //Entity.Menus mdTem = mdModel.Clone();
                //if (mdTem.ParentID == id)
                //{

                //    string str = blank + "─";
                //    mdTem.MenuName = str + "『" + mdTem.MenuName + "』";
                //    NewClass.Add(mdTem);
                //    GetSubItem(mdTem.id, ref NewClass, str, OldClass);
                //}
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
            Entity.Menus md = GetEntity(TargetClassID);

            if (md.ParentID == SoureClassID)
            {
                //Tips("出错了", "父分类不能移到子分类下，如果您有这样的需求请先将子分类移出，再做移动！");
                Core.Strings.cJavascripts.MessageShowBack("父分类不能移到子分类下，如果您有这样的需求请先将子分类移出，再做移动！");
                return;
            }
            base.InvalidateCache();
            dal.Menus_Move(SoureClassID, TargetClassID, IsAsChildnode);
        }
        /// <summary>
        /// 重新调整排序ID
        /// </summary>
        public void ResetOrderID_Start()
        {
            List<Entity.Menus> aIDs = GetSubMenusByParentID(Guid.Empty);
            ResetOrderID(aIDs);

        }
        private List<Entity.Menus> GetSubMenusByParentID(Guid gParentID)
        {
            string sWhere = string.Format("ParentID='{0}'", gParentID);
            List<Entity.Menus> lst = GetListArray(sWhere);
            List<Entity.Menus> lstID = new List<Entity.Menus>();
            foreach (Entity.Menus menu in lst)
            {
                if (Equals(menu.ParentID, gParentID))
                {
                    lstID.Add(menu);
                }
            }
            return lstID;
        }
        private void ResetOrderID(List<Entity.Menus> iIDS)
        {
            if (iIDS.Count > 0)
            {
                for (int i = 0; i < iIDS.Count; i++)
                {
                    Entity.Menus iCurrentID = iIDS[i];

                    iCurrentID.OrderID = i + 1;

                    iCurrentID.Update();

                    //DbProviderCms.GetInstance().NewsClass_UpdateOrderID(iCurrentID, (i + 1));

                    List<Entity.Menus> aSubIDs = GetSubMenusByParentID(iCurrentID.id);

                    ResetOrderID(aSubIDs);
                }
            }
        }

        public void  DeleteByModuleID(Guid ModuleID)
        {
            dal.Menus_DeleteByModuleID(ModuleID);
        }
        #endregion
    }
        
}
       