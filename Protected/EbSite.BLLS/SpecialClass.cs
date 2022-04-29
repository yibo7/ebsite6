using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EbSite.Base;
using EbSite.Base.Static;
using EbSite.Core;
using EbSite.Data.Interface;
using EbSite.Entity;
namespace EbSite.BLL
{
    /// <summary>
    /// 业务逻辑类ListClass 的摘要说明。
    /// </summary>
    public class SpecialClass
    {
        //private static readonly EbSite.DbProviderCms.GetInstance().SpecialClass_SpecialClass dal = new EbSite.DbProviderCms.GetInstance().SpecialClass_SpecialClass();

        private const double cachetime = 60.0;

        private const string CacheSpecialClass = "specialclass";
            // private static readonly string[] MasterCacheKeyArray = { "SpecialClass" };

        // private static CacheManager bllCache;
        //static SpecialClass()
        //{
        //    if (Equals(bllCache, null))
        //    {
        //        bllCache = new CacheManager(CacheDuration, MasterCacheKeyArray);
        //    }
        //}

        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public static int GetMaxId()
        {
            return DbProviderCms.GetInstance().SpecialClass_GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(int id)
        {
            return DbProviderCms.GetInstance().SpecialClass_Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(EbSite.Entity.SpecialClass model, int SiteID)
        {

            model.Orderid = DbProviderCms.GetInstance().SpecialClass_GetMaxOrderID(model.ParentID, SiteID) + 1;
            model.SiteID = SiteID;
            Host.CacheApp.InvalidateCache(CacheSpecialClass); // bllCache.InvalidateCache();
            return DbProviderCms.GetInstance().SpecialClass_Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void Update(EbSite.Entity.SpecialClass model)
        {
            DbProviderCms.GetInstance().SpecialClass_Update(model);
            Host.CacheApp.InvalidateCache(CacheSpecialClass); //bllCache.InvalidateCache();
        }

        /// <summary>
        /// 合并专题，连同专题下的子专题数据一起
        /// </summary>
        /// <param name="SoureSpecialID"></param>
        /// <param name="TargetSpecailID"></param>
        public static void MergeSpecail(int SoureSpecialID, int TargetSpecailID, int SiteID)
        {
            if (SoureSpecialID == TargetSpecailID)
            {
                Core.Strings.cJavascripts.MessageShowBack("源专题不能与目标专题相同");
                return;
            }
            Entity.SpecialClass md = GetModelByCache(TargetSpecailID);

            if (md.ParentID == SoureSpecialID)
            {
                Core.Strings.cJavascripts.MessageShowBack("不能将父专题数据合并到子专题，如果您有这样的需求请先将子专题移出，再做合并！");
                return;
            }

            string IDs = GetSubIDs(SoureSpecialID, SiteID);

            if (!string.IsNullOrEmpty(IDs))
            {
                IDs = string.Concat(SoureSpecialID, ",", IDs);
            }
            else
            {
                IDs = SoureSpecialID.ToString();
            }


            DbProviderCms.GetInstance().SpecialNews_MergeSpecail(IDs, TargetSpecailID);

            string[] aID = IDs.Split(',');
            foreach (string id in aID)
            {
                if (!string.IsNullOrEmpty(id))
                {
                    int sid = int.Parse(id);

                    Delete(sid, SiteID);
                }

            }

            //DbProviderCms.GetInstance().SpecialClass_Delete(string.Concat(IDs,0));

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void Delete(EbSite.Entity.SpecialClass model, int SiteID)
        {

            Delete(model.id, SiteID);
            Host.CacheApp.InvalidateCache(CacheSpecialClass); //bllCache.InvalidateCache();
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //static public  int GetCount(int jzid)
        //{
        //    DbProviderCms.GetInstance().SpecialClass_GetCount("classid=" + jzid);
        //}
        //static public  void DeleteAll(int id)
        //{
        //    //删除当前分类下的子分类
        //    string sAllIDs =GetSubIDs(id);
        //    if (sAllIDs.Length > 0)
        //    {
        //       string[] aAllIDs = string.Concat(sAllIDs, ",", id).Split(',');
        //       foreach (string sID in aAllIDs)
        //        {
        //            Delete(int.Parse(sID));
        //        }
        //    }
        //    else
        //    {
        //        Delete(id);
        //    }
        //}

        /// <summary>
        /// 获取某个分类下的所有子分类ID,用逗号分开
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        public static string GetSubIDs(int ParentID, int SiteID)
        {
            string CacheKey = string.Concat("GetSubIDs-", ParentID, "-", SiteID);
            string sIDs = Host.CacheApp.GetCacheItem<string>(CacheKey, CacheSpecialClass);
                //bllCache.GetCacheItem(CacheKey) as string;
            if (string.IsNullOrEmpty(sIDs))
            {
                StringBuilder sb = new StringBuilder();

                GetSubID(ParentID, ref sb, SiteID);

                if (sb.Length > 1)
                    sb.Remove(sb.Length - 1, 1);


                sIDs = sb.ToString();

                if (!string.IsNullOrEmpty(sIDs))
                    Host.CacheApp.AddCacheItem(CacheKey, sIDs, cachetime, ETimeSpanModel.M, CacheSpecialClass);
                        // bllCache.AddCacheItem(CacheKey, sIDs);
            }

            return sIDs;
        }

        public static List<EbSite.Entity.SpecialClass> GetSub(int ParentID, int SiteID)
        {
            return GetSub(0, ParentID, SiteID);

        }

        public static List<EbSite.Entity.SpecialClass> GetSub(int top, int ParentID, int SiteID)
        {
            return DbProviderCms.GetInstance().SpecialClass_GetListArray(" ParentID=" + ParentID, top, "", SiteID);

        }

        private static void GetSubID(int ParentID, ref StringBuilder sb, int SiteID)
        {
            List<EbSite.Entity.SpecialClass> lst =
                DbProviderCms.GetInstance().SpecialClass_GetListArray(" ParentID=" + ParentID, 0, "", SiteID);
            foreach (EbSite.Entity.SpecialClass newsClass in lst)
            {
                sb.Append(newsClass.id);
                sb.Append(",");
                GetSubID(newsClass.id, ref sb, SiteID);
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void Delete(int SpecailID, int SiteID)
        {


            //Entity.SpecialClass mdSpecial = GetModelByCache(id);

            //DbProviderCms.GetInstance().SpecialClass_Delete(id);//同时删除与专题相关的专题内容

            //DbProviderCms.GetInstance().SpecialClass_DeleteClassUpdateOrderID(mdSpecial.Orderid, mdSpecial.ParentID);

            //获取当前分类下的所有子分类ID
            string sAllIDs = GetSubIDs(SpecailID, SiteID);


            if (sAllIDs.Length > 0) //如果有子分类
            {
                sAllIDs = string.Concat(sAllIDs, ",", SpecailID);
                string[] aIDs = sAllIDs.Split(',');
                foreach (string aID in aIDs)
                {
                    //更新排序ID比当前分类大的排序ID-1，orderid补位
                    Entity.SpecialClass mdClass = BLL.SpecialClass.GetModelByCache(int.Parse(aID));
                    DbProviderCms.GetInstance()
                        .SpecialClass_DeleteClassUpdateOrderID(mdClass.Orderid, mdClass.ParentID, SiteID);
                }
            }
            else //如果没有子分类
            {
                sAllIDs = SpecailID.ToString();
                //更新排序ID比当前分类大的排序ID-1，orderid补位
                Entity.SpecialClass mdClass = BLL.SpecialClass.GetModelByCache(SpecailID);
                DbProviderCms.GetInstance()
                    .SpecialClass_DeleteClassUpdateOrderID(mdClass.Orderid, mdClass.ParentID, SiteID);

            }
            //删除当前分类及其下的子分类，删除的同时删除与其相关内容，数据层实现
            DbProviderCms.GetInstance().SpecialClass_Delete(sAllIDs);

            Host.CacheApp.InvalidateCache(CacheSpecialClass);
            //bllCache.InvalidateCache();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Entity.SpecialClass GetModel(int id)
        {
            return DbProviderCms.GetInstance().SpecialClass_GetModel(id);
        }

        public static List<EbSite.Entity.SpecialClass> GetParentSpecial(int iTop, int SiteID)
        {
            string CacheKey = string.Concat("GetParentSpecial-", iTop, "-", SiteID);
            List<EbSite.Entity.SpecialClass> lstMD =
                Host.CacheApp.GetCacheItem<List<EbSite.Entity.SpecialClass>>(CacheKey, CacheSpecialClass);
                // bllCache.GetCacheItem(CacheKey) as List<EbSite.Entity.SpecialClass>;
            if (Equals(lstMD, null))
            {
                lstMD = DbProviderCms.GetInstance()
                    .SpecialClass_GetListArray("ParentID=0 ", iTop, " orderid,-id", SiteID);
                if (!Equals(lstMD, null))
                    Host.CacheApp.AddCacheItem(CacheKey, lstMD, cachetime, ETimeSpanModel.M, CacheSpecialClass);
                        //bllCache.AddCacheItem(CacheKey, lstMD);
            }
            return lstMD;
            //return DbProviderCms.GetInstance().NewsClass_GetListArray("ParentID=0 ", iTop, " orderid,-id");
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public static Entity.SpecialClass GetModelByCache(int ID)
        {
            string CacheKey = "SpecialClass-" + ID;
            Entity.SpecialClass model = Host.CacheApp.GetCacheItem<Entity.SpecialClass>(CacheKey, CacheSpecialClass);
                //bllCache.GetCacheItem(CacheKey) as Entity.SpecialClass;
            if (model == null)
            {
                model = DbProviderCms.GetInstance().SpecialClass_GetModel(ID);
                Host.CacheApp.AddCacheItem(CacheKey, model, cachetime, ETimeSpanModel.M, CacheSpecialClass);
                    //bllCache.AddCacheItem(CacheKey, model);
            }

            return model;
        }


        
        public static List<Entity.SpecialClass> GetListPages(int PageIndex, int PageSize, string strWhere,
            out int RecordCount, int SiteID)
        {
            RecordCount = DbProviderCms.GetInstance().SpecialClass_GetCount(strWhere, SiteID);
            return DbProviderCms.GetInstance()
                .SpecialClass_GetListPages(PageIndex, PageSize, strWhere, "id desc", SiteID);
        }

        public static List<EbSite.Entity.SpecialClass> GetTree(int iTop, int SiteID)
        {
            List<EbSite.Entity.SpecialClass> getClass = DbProviderCms.GetInstance()
                .SpecialClass_GetListArray("", iTop, "orderid asc", SiteID);
            List<EbSite.Entity.SpecialClass> getTree = new List<EbSite.Entity.SpecialClass>();
            //int i = 0;
            foreach (EbSite.Entity.SpecialClass tree in getClass)
            {
                //if(i>500)break; //由于树形一般用户下拉列表，这里最多只能列出500个分类
                if (tree.ParentID == 0)
                {

                    tree.SpecialName = "╋" + tree.SpecialName;
                    getTree.Add(tree);
                    GetSubItem(tree.id, ref getTree, "├", getClass);
                }
                //i++;
            }
            return getTree;
        }

        public static List<EbSite.Entity.SpecialClass> GetTree_pic(int PageIndex, int iPageSize, out int iCount,
            int SiteID)
        {
            List<EbSite.Entity.SpecialClass> Menus = GetTree_pic(0, SiteID);

            iCount = Menus.Count;

            int start = iPageSize*(PageIndex - 1);

            if (start <= Menus.Count - 1)
            {
                int size = iPageSize;
                if (start + size > Menus.Count)
                    size = Menus.Count - start;

                return Menus.GetRange(start, size);
            }
            return null;

        }


        public static List<EbSite.Entity.SpecialClass> GetTree_pic(int iTop, int SiteID)
        {
            List<EbSite.Entity.SpecialClass> getClass = DbProviderCms.GetInstance()
                .SpecialClass_GetListArray("", iTop, "", SiteID);
            List<EbSite.Entity.SpecialClass> getTree = new List<EbSite.Entity.SpecialClass>();
            //int i = 0;
            string sPatch1 = string.Concat("<img src=\"", Base.AppStartInit.IISPath,
                "Images/tree/w3.gif\" align=absmiddle>");
            string sPatch = string.Concat("<img src=\"", Base.AppStartInit.IISPath,
                "Images/tree/w1.gif\" align=absmiddle>");
            foreach (EbSite.Entity.SpecialClass tree in getClass)
            {
                //if(i>500)break; //由于树形一般用户下拉列表，这里最多只能列出500个分类
                if (tree.ParentID == 0)
                {

                    tree.SpecialName = sPatch + tree.SpecialName;
                    getTree.Add(tree);
                    GetSubItem_pic(tree.id, ref getTree, "", getClass);
                }
                //i++;
            }
            return getTree;
        }

        /// <summary>
        /// 获取某个记录下的子记录，从而构建树形(递归调用)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="GetTree"></param>
        /// <param name="blank"></param>
        private static void GetSubItem_pic(int id, ref List<EbSite.Entity.SpecialClass> NewClass, string blank,
            List<EbSite.Entity.SpecialClass> OldClass)
        {
            string sW3 = string.Concat("<img src=\"", Base.AppStartInit.IISPath, "Images/tree/w3.gif\" align=absmiddle>");
            string sW1 = string.Concat("<img src=\"", Base.AppStartInit.IISPath, "Images/tree/w1.gif\" align=absmiddle>");
            foreach (EbSite.Entity.SpecialClass tree in OldClass)
            {

                if (tree.ParentID == id)
                {
                    string str = blank;
                    str = string.Concat(str, sW3);
                    //if (GetSubCount(tree.id) > 0)
                    //{
                    //    str = string.Concat(str, sW1);
                    //}
                    //else
                    //{
                    //    str = string.Concat(str, sW3); 
                    //}
                    //ContentClass tr = tree.Clone();

                    tree.SpecialName = str + sW1 + tree.SpecialName;
                    NewClass.Add(tree);
                    GetSubItem_pic(tree.id, ref NewClass, str, OldClass);
                }
            }
        }

        /// <summary>
        /// 获取某个分类下的子分类个数
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        public static int GetSubCount(int ParentID, int SiteID)
        {


            return DbProviderCms.GetInstance().SpecialClass_GetCount(string.Concat("ParentID=", ParentID), SiteID);
        }

        public static int GetCount(int SiteID)
        {


            return DbProviderCms.GetInstance().SpecialClass_GetCount("", SiteID);
        }

        public static List<EbSite.Entity.SpecialClass> GetTree(int SiteID)
        {
            return GetTree(0, SiteID);
        }

        /// <summary>
        /// 获取某个记录下的子记录，从而构建树形(递归调用)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="GetTree"></param>
        /// <param name="blank"></param>
        private static void GetSubItem(int id, ref List<EbSite.Entity.SpecialClass> NewClass, string blank,
            List<EbSite.Entity.SpecialClass> OldClass)
        {
            foreach (EbSite.Entity.SpecialClass tree in OldClass)
            {

                if (tree.ParentID == id)
                {
                    //ContentClass tr = tree.Clone();
                    string str = blank + "─";
                    tree.SpecialName = str + "『" + tree.SpecialName + "』";
                    NewClass.Add(tree);
                    GetSubItem(tree.id, ref NewClass, str, OldClass);
                }
            }
        }

        /// <summary>
        /// 获取某个记录下的子记录，从而构建树形(递归调用)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="GetTree"></param>
        /// <param name="blank"></param>
        public static List<EbSite.Entity.SpecialClass> SearcSpecial(string SpecialName, int Top, int SiteID)
        {
            List<EbSite.Entity.SpecialClass> getClass = DbProviderCms.GetInstance()
                .SpecialClass_GetListArray("", Top, "", SiteID);
            List<EbSite.Entity.SpecialClass> lstRz = new List<Entity.SpecialClass>();
            foreach (EbSite.Entity.SpecialClass tree in getClass)
            {

                if (tree.SpecialName == SpecialName.Trim())
                {
                    lstRz.Add(tree);
                }
            }
            return lstRz;
        }

        public static List<EbSite.Entity.SpecialClass> GetListArr(string sWhere, int SiteID)
        {
            return DbProviderCms.GetInstance().SpecialClass_GetListArray(sWhere, 0, "id,-orderid", SiteID);
        }
        public static List<EbSite.Entity.SpecialClass> GetListArr(int  iTop, int SiteID)
        {
            return DbProviderCms.GetInstance().SpecialClass_GetListArray("", iTop, "id,-orderid", SiteID);
        }

        public static List<EbSite.Entity.SpecialClass> GetListArr(int SiteID)
        {
            return DbProviderCms.GetInstance().SpecialClass_GetListArray("", 0, "id,-orderid", SiteID);
        }

        /// <summary>
        /// Gets the list arr.
        /// </summary>
        /// <param name="iTop">The i top.</param>
        /// <param name="DataType">数据类型，0所有,1有图片的专题,2有专题介绍的专题,3有图片且有专题介绍的专题,4有归属文章的专题.</param>
        /// <param name="OrderType">排序方式,0最新添加越靠前,1排序ID越大越靠前,2排序ID越大越靠后.</param>
        /// <param name="SiteID">The site identifier.</param>
        /// <returns>List&lt;EbSite.Entity.SpecialClass&gt;.</returns>
        public static List<EbSite.Entity.SpecialClass> GetListArr(int iTop, int DataType,int OrderType,int SiteID)
        {
            string sWhere = "";
            if (DataType == 1)
            {
                sWhere = "TitleType<>''";
            }
            else if (DataType == 2)
            {
                sWhere = "Info<>''";
            }
            else if (DataType == 3)
            {
                sWhere = "Info<>'' AND TitleType<>''";
            } 
            else if (DataType == 4)
            {
                sWhere = string.Format("ID IN(SELECT DISTINCT SpecialClassID  FROM {0}specialnews)", Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix) ;
            }


            string sOrderBy = "id desc";
            if (OrderType == 1)
            {
                sOrderBy = "orderid desc";
            }
            else if (OrderType == 2)
            {
                sOrderBy = "orderid asc";
            }

            return DbProviderCms.GetInstance().SpecialClass_GetListArray(sWhere, iTop, sOrderBy, SiteID);
        }

        /// <summary>
        /// Gets the list in automatic i ds.
        /// </summary>
        /// <param name="ID">分类ID.</param>
        /// <param name="DataType">数据类型，0所有,1有图片的专题,2有专题介绍的专题,3有图片且有专题介绍的专题,4有归属文章的专题.</param>
        /// <param name="OrderType">排序方式,0最新添加越靠前,1排序ID越大越靠前,2排序ID越大越靠后.</param>
        /// <param name="SiteID">The site identifier.</param>
        /// <returns>List&lt;EbSite.Entity.SpecialClass&gt;.</returns>
        public static List<EbSite.Entity.SpecialClass> GetListInAutoClassId(int ID, int DataType, int OrderType,int iTop, int SiteID)
        {
            //这样的方法其实应该放到数据层，赶时间暂时这样
            string sWhere = string.Format("ID IN(SELECT DISTINCT SpecialClassID  FROM {0}specialnews WHERE classid={1})", Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix, ID);
            if (DataType == 1)
            {
                sWhere = " AND TitleType<>''";
            }
            else if (DataType == 2)
            {
                sWhere = " AND Info<>''";
            }
            else if (DataType == 3)
            {
                sWhere = " AND Info<>'' AND TitleType<>''";
            }
             


            string sOrderBy = "id desc";
            if (OrderType == 1)
            {
                sOrderBy = "orderid desc";
            }
            else if (OrderType == 2)
            {
                sOrderBy = "orderid asc";
            }

            return DbProviderCms.GetInstance().SpecialClass_GetListArray(sWhere, iTop, sOrderBy, SiteID);
        }

        static public List<EbSite.Entity.SpecialClass> GetListByContentId(long ContentId, int ClassId, int DataType, int OrderType, int iTop, int SiteID)
        {
            //这样的方法其实应该放到数据层，赶时间暂时这样
            string sWhere = string.Format("ID IN(SELECT DISTINCT SpecialClassID  FROM {0}specialnews WHERE classid={1} AND NewsId={2})", Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix, ClassId, ContentId);
            if (DataType == 1)
            {
                sWhere = string.Concat(sWhere, " AND TitleType<>''") ;
            }
            else if (DataType == 2)
            {
                sWhere = string.Concat(sWhere, " AND Info<>''");
            }
            else if (DataType == 3)
            {
                sWhere = string.Concat(sWhere, " AND Info<>'' AND TitleType<>''");
            }



            string sOrderBy = "id desc";
            if (OrderType == 1)
            {
                sOrderBy = "orderid desc";
            }
            else if (OrderType == 2)
            {
                sOrderBy = "orderid asc";
            }
            //EbSite.Log.Factory.GetInstance().InfoLog(sWhere);
            return DbProviderCms.GetInstance().SpecialClass_GetListArray(sWhere, iTop, sOrderBy, SiteID);

            //return DbProviderCms.GetInstance().SpecialClass_GetListByContentId(ContentId, ClassId, Top);
        }

        /// <summary>
        /// Gets the list in i ds.
        /// </summary>
        /// <param name="IDs">The i ds.</param>
        /// <param name="DataType">数据类型，0所有,1有图片的专题,2有专题介绍的专题,3有图片且有专题介绍的专题,4有归属文章的专题.</param>
        /// <param name="OrderType">排序方式,0最新添加越靠前,1排序ID越大越靠前,2排序ID越大越靠后.</param>
        /// <param name="SiteID">The site identifier.</param>
        /// <returns>List&lt;EbSite.Entity.SpecialClass&gt;.</returns>
        public static List<EbSite.Entity.SpecialClass> GetListInIDs(string IDs, int DataType, int OrderType, int SiteID)
        {
            string sWhere = string.Concat(" ID in(", IDs, ")");
            if (DataType == 1)
            {
                sWhere = string.Concat(sWhere," AND TitleType<>''");
            }
            else if (DataType == 2)
            {
                sWhere = string.Concat(sWhere, " AND Info<>''");
            }
            else if (DataType == 3)
            {
                sWhere = string.Concat(sWhere, " AND Info<>'' AND TitleType<>''");
            }
         
            //else if (DataType == 4)
            //{
            //    sWhere = string.Format("ID IN(SELECT DISTINCT SpecialClassID  FROM {0}specialnews)", Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix);
            //}


            string sOrderBy = "id desc";
            if (OrderType == 1)
            {
                sOrderBy = "orderid desc";
            }
            else if (OrderType == 2)
            {
                sOrderBy = "orderid asc";
            }

            return DbProviderCms.GetInstance().SpecialClass_GetListArray(sWhere, 0, sOrderBy, SiteID);
        }

        /// <summary>
        /// 返回不包家族的分类
        /// </summary>
        /// <returns></returns>
        public static List<EbSite.Entity.SpecialClass> GetTags(int iTop, int SiteID)
        {
            List<EbSite.Entity.SpecialClass> lst = GetListArr(SiteID); //先取出家族的数据

            StringBuilder sbIDs = new StringBuilder();

            foreach (EbSite.Entity.SpecialClass md in lst)
            {
                sbIDs.Append(md.id);
                sbIDs.Append(",");

            }
            sbIDs.Remove(sbIDs.Length - 1, 1);
            return DbProviderCms.GetInstance()
                .SpecialClass_GetListArray("id not in(" + sbIDs.ToString() + ")", iTop, "id,-orderid", SiteID);
        }

        public static void MakeHtmlName(int SiteID)
        {
            List<EbSite.Entity.SpecialClass> lst = GetListArr(SiteID);
            foreach (EbSite.Entity.SpecialClass sp in lst)
            {
                MakeHtmlName(sp);
            }
        }

        public static void UpdateRuleToAllSpecial(string NewRule, int SiteID)
        {
            List<EbSite.Entity.SpecialClass> lst = GetListArr(SiteID);
            foreach (EbSite.Entity.SpecialClass sp in lst)
            {
                sp.ClassHtmlNameRule = NewRule;
                Update(sp);
            }
        }

        public static void MakeHtmlName(EbSite.Entity.SpecialClass model)
        {
            string sRule = model.ClassHtmlNameRule;

            model.HtmlName = HtmlReNameRule.GetName(sRule, model.SpecialName, "");

            Update(model);
        }

        public static void SpecialClassMove(int SoureClassID, int TargetClassID, bool IsAsChildnode, int SiteID)
        {

            Entity.SpecialClass md = GetModelByCache(TargetClassID);

            if (md.ParentID == SoureClassID)
            {
                Core.Strings.cJavascripts.MessageShowBack("父专题不能移到子专题下，如果您有这样的需求请先将子专题移出，再做移动！");
                return;
            }
            DbProviderCms.GetInstance().SpecialClass_Move(SoureClassID, TargetClassID, IsAsChildnode, SiteID);
        }

        /// <summary>
        /// 重新调整排序ID
        /// </summary>
        public static void ResetOrderID_Start(int SiteID)
        {
            List<int> aIDs = DbProviderCms.GetInstance().SpecialClass_GetSubID(0);
            ResetOrderID(aIDs, SiteID);

        }

        private static void ResetOrderID(List<int> iIDS, int SiteID)
        {
            if (iIDS.Count > 0)
            {
                for (int i = 0; i < iIDS.Count; i++)
                {
                    int iCurrentID = iIDS[i];
                    DbProviderCms.GetInstance().SpecialClass_UpdateOrderID(iCurrentID, (i + 1), SiteID);

                    List<int> aSubIDs = DbProviderCms.GetInstance().SpecialClass_GetSubID(iCurrentID);

                    ResetOrderID(aSubIDs, SiteID);
                }
            }
        }

        #region 复制类内容 杨欢乐 2011-10-26

        public static Entity.SpecialClass GetCopyClass(int id, int SiteID)
        {

            Entity.SpecialClass model = GetModel(id);
            Entity.SpecialClass NewModel = new Entity.SpecialClass();

            NewModel.SpecialName = "复制" + model.SpecialName;
            NewModel.Orderid = model.Orderid;
            NewModel.Titletype = model.Titletype;
            NewModel.Outlink = model.Outlink;
            NewModel.HtmlName = model.HtmlName;
            NewModel.ClassHtmlNameRule = model.ClassHtmlNameRule;
            NewModel.SpecialTemID = model.SpecialTemID;
            NewModel.SeoTitle = model.SeoTitle;
            NewModel.SeoKeyWord = model.SeoKeyWord;
            NewModel.SeoDescription = model.SeoDescription;
            NewModel.ParentID = model.ParentID;
            NewModel.RelateClassIDs = model.RelateClassIDs;
            NewModel.SiteID = model.SiteID;
            NewModel.SpecialTemIDMobile = model.SpecialTemIDMobile;
            int sid = Add(NewModel, SiteID);
            NewModel.id = sid;
            return NewModel;
        }

        #endregion



        #region 取得父类的递归分类

        public static List<EbSite.Entity.SpecialClass> SpecialClass_GetParents(int ClassID, string Orderby)
        {
            if (ClassID > 0)
            {
                string CacheKey = string.Concat("specialGetParents-", ClassID);
                List<EbSite.Entity.SpecialClass> models =
                    Host.CacheApp.GetCacheItem<List<EbSite.Entity.SpecialClass>>(CacheKey, CacheSpecialClass);
                    // bllCache.GetCacheItem(CacheKey) as List<EbSite.Entity.SpecialClass>;
                if (models == null)
                {
                    models = DbProviderCms.GetInstance().SpecialClass_GetParents(ClassID, Orderby);
                    if (!Equals(models, null))
                        Host.CacheApp.AddCacheItem(CacheKey, models, cachetime, ETimeSpanModel.M, CacheSpecialClass);
                            //bllCache.AddCacheItem(CacheKey, models);
                }

                return models;
            }

            else
            {
                return new List<Entity.SpecialClass>();
            }
        }

        #endregion

        private static void UpdateClassSubNum(int ClassID)
        {

        }

        public static void SpecialClass_Update(string Where, string Col, string sValue)
        {
            DbProviderCms.GetInstance().SpecialClass_Update(Where, Col, sValue);
        }

        public static List<EbSite.Entity.SpecialClass> GetListArrByParentID(int Pid, int SiteID)
        {
            return DbProviderCms.GetInstance()
                .SpecialClass_GetListArray(string.Concat("ParentID=", Pid), 0, "id,-orderid", SiteID);

        }

        #endregion  成员方法

       

        static public List<EbSite.Entity.SpecialClass> GetListHtmlNameReWrite()
        {
            return DbProviderCms.GetInstance().SpecialClass_GetListHtmlNameReWrite();
        }

    }
}

