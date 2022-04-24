
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using EbSite.Base;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Base.Static;
using EbSite.BLL.ModelBll;
using EbSite.Core; 
using EbSite.Core.RSS;
using EbSite.Data.Interface;
namespace EbSite.BLL
{
    /// <summary>
    /// 业务逻辑类NewsClass 的摘要说明。
    /// </summary>
    public class NewsClass
    {
        //const double CacheDuration = 60.0;
        //private static readonly string[] MasterCacheKeyArray = { "NewsClassCache" };
        //private static CacheManager bllCache;
        //private static CacheBase bllCache;
        private  const string cacheclass = "newsclass";
        static NewsClass()
        {
            //bllCache = CacheInstance.GetCacheObj(60.0, "newsclass", ETimeSpanModel.秒);
            //bllCache = new CacheManager(CacheDuration, MasterCacheKeyArray);
        }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        static public int GetMaxId()
        {
            return DbProviderCms.GetInstance().NewsClass_GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        static public bool Exists(int SClassid)
        {
            return DbProviderCms.GetInstance().NewsClass_Exists(SClassid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        static public int Add(EbSite.Entity.NewsClass model, int SiteID)
        {
            
            model.UserName = AppStartInit.UserName;
            model.UserNiName = AppStartInit.UserNiName;
            model.UserID = AppStartInit.UserID;
            model.IsAuditing = !Base.Configs.SysConfigs.ConfigsControl.Instance.AuditingContent;
            model.OrderID = BLL.NewsClass.GetMaxOrderID(model.ParentID, SiteID) + 1;
            model.SiteID = SiteID;
            model.RandNum = Core.Utils.GetRandNum();

            //yhl 2014-8-29 添加Parentids
            string pis = "";
            if (model.ParentID != 0)
            {
                List<Entity.NewsClass> lsParent = BLL.NewsClass.GetParents(model.ParentID);
                foreach (var @class in lsParent)
                {
                    pis += @class.ID + ",";
                }
            }
            model.ParentIDs = pis;

            //添加前触发的事件
            AddingClassEventArgs Args = new AddingClassEventArgs(model.ID);
            Base.EBSiteEvents.OnClassAdding(model, Args);
           
            if (!Args.StopAdd)
            {
                Host.CacheApp.InvalidateCache(cacheclass);
                
                int cid = DbProviderCms.GetInstance().NewsClass_Add(model);
                model.ID = cid;
                //添加后触发的事件
                AddedClassEventArgs Argsed = new AddedClassEventArgs(model.ID, model);
                Base.EBSiteEvents.OnClassAdded(model, Argsed);

                return cid;
            }
            else
            {
                return -1;
            }

        }


        static public int AddBLL(EbSite.Entity.NewsClass ThisModel, bool blConfigsToSub, string OldClassName, int SiteID,Guid iClassModelId)
        {
            int newid = 0;
            if (ThisModel.ID > 0) //修改分类
            {
                newid = ThisModel.ID;
                if (ThisModel.ID == ThisModel.ParentID)
                {
                    EbSite.Base.Host.Instance.Tips("出错了", "父分类为能为其本身!");
                    return 0;
                }

                Update(ThisModel);

                if (!Equals(OldClassName, ThisModel.ClassName)) //如果修改了分类名称，那么要同时更新内容表的ClassName字段
                {
                    //未完成
                }

                //if (blConfigsToSub)//将相关配置更新到子分类
                //{
                //    //模板
                //    BLL.NewsClass.UpdateTemToSubClass_Class(ThisModel, SiteID);
                //    BLL.NewsClass.UpdateTemToSubClass_Content(ThisModel, SiteID);

                //    //静态页面的命名规则
                //    BLL.NewsClass.UpdateRuleToSub_Class(ThisModel, SiteID);
                //    BLL.NewsClass.UpdateRuleToSub_Content(ThisModel, SiteID);
                //    //模型
                //    BLL.NewsClass.UpdateModelToSubClass(ThisModel);

                //}
            }

            else    //添加一级分类
            {
                ThisModel.OrderID = BLL.NewsClass.GetMaxOrderID(ThisModel.ParentID, SiteID) + 1;
                newid = Add(ThisModel, SiteID);
            }

            StringDictionary sd =   ThisModel.GetCusttomFileds();
            if (sd.Count > 0)
            {
                Guid _GetClassModelID = BLL.ClassConfigs.Instance.GetClassModelID(newid);
                CusttomFiledsBLL<StringDictionary> cfb = ModelBll.CusstomFileds.HrefFactory.GetInstance(_GetClassModelID, ModelType.FLMX, SiteID);
                cfb.Save(newid, sd);
            }

            if (ThisModel.ParentID == 0)
            {
                BLL.ClassConfigs.Instance.AddClassToDefault(newid, iClassModelId);
            }
            else
            {
                BLL.ClassConfigs.Instance.AddSubClassToParentConfig(ThisModel.ParentID, newid);
            }

            return newid;
            
        }
        /// <summary>
        /// 初始终化添加分类时的分类实体配置 父ID大于0时，获取继承父分类设置
        /// </summary>
        /// <param name="ThisModel"></param>
        /// <returns></returns>
        public static void InitDefaultConfigs(ref  EbSite.Entity.NewsClass ThisModel)
        {
            //cm.ClassHtmlNameRule = rnHtmlName.Text.Trim();
            //cm.HtmlName = HtmlReNameRule.GetName(rnHtmlName.Text.Trim(), cm.ClassName);//从当前规则转换文件名

            //cm.ContentHtmlName = rnHtmlContent.Text.Trim();

            //cm.PageSize = int.Parse(this.PageSize.Text.Trim());
            //cm.ListTemID = new Guid(this.ListTemID.SelectedValue);
            //cm.ClassModelID = new Guid(this.ClassModelID.SelectedValue);
            //cm.ClassTemID = new Guid(this.ClassTemID.SelectedValue);
            //cm.ContentTemID = new Guid(this.ContentTemID.SelectedValue);
            //cm.ContentModelID = new Guid(this.ContentModelID.SelectedValue);

            //cm.IsCanAddSub = this.IsCanAddSub.Checked;
            //cm.IsCanAddContent = this.IsCanAddContent.Checked;


            ////子分类设置
            //cm.SubClassAddName = this.SubClassAddName.Text.Trim();//子分类添加名称
            //cm.SubClassTemID = new Guid(SubClassTemID.SelectedValue);//子分类模板ID
            //cm.SubClassModelID = new Guid(SubClassModelID.SelectedValue);//子分类模型ID
            //cm.SubIsCanAddSub = SubIsCanAddSub.Checked;
            //cm.SubIsCanAddContent = SubIsCanAddContent.Checked;
            //cm.SubDefaultContentTemID = new Guid(SubDefaultContentTemID.SelectedValue);//子分类内容模板ID
            //cm.SubDefaultContentModelID = new Guid(SubDefaultContentModelID.SelectedValue);//子分类内容模型ID

            //cm.ModuleID = new Guid(BingModule.SelectedValue);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        static public void Update(EbSite.Entity.NewsClass model)
        {
            DbProviderCms.GetInstance().NewsClass_Update(model);
            Host.CacheApp.InvalidateCache(cacheclass);

            //更新后触发的事件
            UpdatedClassEventArgs Argsed = new UpdatedClassEventArgs(model.ID, model);
            Base.EBSiteEvents.OnClassUpdated(model, Argsed);
        }
        /// <summary>
        /// 生成一个实体的静态页面名称
        /// </summary>
        /// <param name="model"></param>
        static public void MakeHtmlName(EbSite.Entity.NewsClass model)
        {

            //Entity.ClassConfigs mdConfigs = BLL.ClassConfigs.Instance.GeClassConfigsByClassID(model.ID);
            //string sRule = mdConfigs.ClassHtmlNameRule;
            //string sRule = model.ClassHtmlNameRule;

            string sRule = BLL.ClassConfigs.Instance.GetClassHtmlNameRule(model.ID);

            model.HtmlName = HtmlReNameRule.GetName(sRule, model.ClassName.Trim(), "");

            Update(model);
        }
        static public void MakeHtmlName(int ClassID, int SiteID)
        {
            List<EbSite.Entity.NewsClass> lst;
            if (ClassID > 0)
            {
                string sSubIDs = GetSubIDs(ClassID, SiteID);
                if (sSubIDs.Length > 0)
                {
                    lst = GetListByIDs(sSubIDs, SiteID);
                }
                else
                {
                    lst = BLL.NewsClass.GetListArr("id=" + ClassID, SiteID);
                }
            }
            else
            {
                lst = BLL.NewsClass.GetListArr("", SiteID);
            }
            foreach (EbSite.Entity.NewsClass newsClass in lst)
            {
                BLL.NewsClass.MakeHtmlName(newsClass);
            }
        }

        #region 将相关配置更新到子分类

        ///// <summary>
        ///// 更新模板到子分类-分类
        ///// </summary>
        ///// <param name="Parent">当前分类</param>
        //static public void UpdateTemToSubClass_Class(EbSite.Entity.NewsClass Parent, int SiteID)
        //{

        //    string sSubIDs = GetSubIDs(Parent.ID, SiteID);
        //    if (sSubIDs.Length > 0) DbProviderCms.GetInstance().NewsClass_UpdateConfigsToSub(Parent, 4, sSubIDs);
        //}
        ///// <summary>
        ///// 更新模板到子分类-内容
        ///// </summary>
        ///// <param name="Parent">当前分类</param>
        //static public void UpdateTemToSubClass_Content(EbSite.Entity.NewsClass Parent, int SiteID)
        //{

        //    string sSubIDs = GetSubIDs(Parent.ID, SiteID);
        //    if (sSubIDs.Length > 0) DbProviderCms.GetInstance().NewsClass_UpdateConfigsToSub(Parent, 5, sSubIDs);
        //}
        ///// <summary>
        ///// 更新内容html命名规则到当前分类的子分类-分类
        ///// </summary>
        ///// <param name="Parent">当前分类</param>
        //static public void UpdateRuleToSub_Class(EbSite.Entity.NewsClass Parent, int SiteID)
        //{

        //    string sSubIDs = GetSubIDs(Parent.ID, SiteID);
        //    if (sSubIDs.Length > 0) DbProviderCms.GetInstance().NewsClass_UpdateConfigsToSub(Parent, 1, sSubIDs);
        //}
        ///// <summary>
        ///// 更新内容html命名规则到当前分类的子分类-内容
        ///// </summary>
        ///// <param name="Parent">当前分类</param>
        //static public void UpdateRuleToSub_Content(EbSite.Entity.NewsClass Parent, int SiteID)
        //{

        //    string sSubIDs = GetSubIDs(Parent.ID, SiteID);
        //    if (sSubIDs.Length > 0) DbProviderCms.GetInstance().NewsClass_UpdateConfigsToSub(Parent, 2, sSubIDs);
        //}
        ///// <summary>
        ///// 更新html命名规则到所有分类
        ///// </summary>
        ///// <param name="Parent"></param>
        //static public void UpdateRuleToAllClass_Class(EbSite.Entity.NewsClass Parent)
        //{
        //    DbProviderCms.GetInstance().NewsClass_UpdateConfigsToSub(Parent, 1, "");
        //}
        ///// <summary>
        ///// 更新html命名规则到所有分类
        ///// </summary>
        ///// <param name="Parent"></param>
        //static public void UpdateRuleToAllClass_Content(EbSite.Entity.NewsClass Parent)
        //{
        //    DbProviderCms.GetInstance().NewsClass_UpdateConfigsToSub(Parent, 2, "");
        //}
        ///// <summary>
        ///// 更新所有子分类的内容模型,加构上分类本身没有模型，只能用上级设置的模型,这里只设置内容模型
        ///// </summary>
        ///// <param name="Parent"></param>
        //static public void UpdateModelToSubClass(EbSite.Entity.NewsClass Parent)
        //{
        //    DbProviderCms.GetInstance().NewsClass_UpdateConfigsToSub(Parent, 3, "");
        //}
        #endregion

        /// <summary>
        /// 删除一条数据
        /// </summary>
        static public void Delete(int SClassid, int SiteID)
        {

            DeleteingClassEventArgs Args = new DeleteingClassEventArgs(SClassid);
            Base.EBSiteEvents.OnClassDeleteing(null, Args);
            if (!Args.StopDelete)
            {
                //先删除分类下所有内容 再删除分类，不能先删除分类再删除内容,接着更新排序ID比当前分类大的排序ID-1
                //已经在数据层实现
                //List<EbSite.Entity.NewsContent> lst = NewsContent.GetListNewOfNewsClass(SClassid, 0,false,false,"id");

                //foreach (EbSite.Entity.NewsContent content in lst)
                //{
                //    NewsContent.Delete(content.ID);
                //}

                //获取当前分类下的所有子分类ID
                string sAllIDs = GetSubIDs(SClassid, SiteID);


                if (sAllIDs.Length > 0)  //如果有子分类
                {
                    sAllIDs = string.Concat(sAllIDs, ",", SClassid);
                    string[] aIDs = sAllIDs.Split(',');
                    foreach (string aID in aIDs)
                    {
                        //更新排序ID比当前分类大的排序ID-1，orderid补位
                        Entity.NewsClass mdClass = BLL.NewsClass.GetModelByCache(int.Parse(aID));
                        DbProviderCms.GetInstance().NewsClass_DeleteClassUpdateOrderID(mdClass.OrderID, mdClass.ParentID, SiteID);
                    }
                }
                else //如果没有子分类
                {
                    sAllIDs = SClassid.ToString();
                    //更新排序ID比当前分类大的排序ID-1，orderid补位
                    Entity.NewsClass mdClass = BLL.NewsClass.GetModelByCache(SClassid);
                    DbProviderCms.GetInstance().NewsClass_DeleteClassUpdateOrderID(mdClass.OrderID, mdClass.ParentID, SiteID);

                }

                //删除当前分类及其下的子分类，删除的同时删除与其相关内容，数据层实现
                DbProviderCms.GetInstance().NewsClass_Delete(sAllIDs);

                if(!string.IsNullOrEmpty(sAllIDs))
                    ClassSetConfig.Instance.DeleteByClassIds(sAllIDs);

                Host.CacheApp.InvalidateCache(cacheclass);

                //添加后触发的事件
                DeletedClassEventArgs Argsed = new DeletedClassEventArgs(SClassid);
                Base.EBSiteEvents.OnClassDeleted(null, Argsed);
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        static public Entity.NewsClass GetModel(int SClassid)
        {

            return GetModelByCache(SClassid);

            //return DbProviderCms.GetInstance().NewsClass_GetModel(SClassid);
        }

        private const int cachetime = 60;
        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        static public Entity.NewsClass GetModelByCache(int SClassid)
        {

            string CacheKey = "NewsClass-" + SClassid;
            Entity.NewsClass model = Host.CacheApp.GetCacheItem<Entity.NewsClass>(CacheKey,cacheclass);
            if (model == null)
            {
                model = DbProviderCms.GetInstance().NewsClass_GetModel(SClassid);

                GetClassEntityEventArgs Args = new GetClassEntityEventArgs(model);
                Base.EBSiteEvents.OnGetClassEntityed(model, Args);

                if (!Equals(model, null))
                    Host.CacheApp.AddCacheItem(CacheKey, model, cachetime, ETimeSpanModel.M, cacheclass);
            }

            return model;
             
        }

        /// <summary>
        /// 获取子分类
        /// </summary>
        /// <param name="ParentID">父分类ID</param>
        /// <param name="top">前几条</param>
        /// <param name="Order">n最新数据，a总排行，w本周排行，m本月排行,其他为实际传入的字段名称</param>
        /// <returns></returns>
        static public List<EbSite.Entity.NewsClass> GetSubClass(int ParentID, int top, string Order, int SiteID)
        {

            string sWhere = "";
            if (ParentID > 0) sWhere = string.Concat(" ParentID=", ParentID);
            string sTop = "";
            if (Order == "w")
            {
                sTop = "weekhits desc ";
            }
            else if (Order == "d")
            {
                sTop = "dayHits  desc ";
            }
            else if (Order == "m")
            {
                sTop = "monthhits desc ";
            }
            else if (Order == "a")
            {
                sTop = "hits desc ";
            }
            else if (Order == "n")
            {
                sTop = "id desc ";
            }
            else if (Order == "z")
            {
                sTop = "orderid ";
            }
            else
            {
                sTop = Order;
            }
            string CacheKey = string.Concat("lstMD-", sWhere, top, sTop, "-", SiteID);
            List<EbSite.Entity.NewsClass> lstMD = Host.CacheApp.GetCacheItem<List<EbSite.Entity.NewsClass>>(CacheKey,cacheclass);// as List<EbSite.Entity.NewsClass>;
            if (Equals(lstMD, null))
            {
                lstMD = DbProviderCms.GetInstance().NewsClass_GetListArray(sWhere, top, sTop, SiteID);
                if (!Equals(lstMD, null))
                    Host.CacheApp.AddCacheItem(CacheKey, lstMD, cachetime, ETimeSpanModel.M, cacheclass);
            }


            return lstMD;
        }
        static public List<EbSite.Entity.NewsClass> GetSubClassNoCache(int ParentID, int top, int SiteID)
        {

            return DbProviderCms.GetInstance().NewsClass_GetListArray(string.Concat("ParentID=", ParentID), top, " orderid,-id", SiteID);
        }
        static public List<EbSite.Entity.NewsClass> GetSubClass(int ParentID, int top, int SiteID)
        {
            return GetSubClass(ParentID, top, "", "", SiteID);
        }

        static public List<EbSite.Entity.NewsClass> GetSubClass(int ParentID, int top, string sWhere, string sOrderBy, int SiteID)
        {
            if (string.IsNullOrEmpty(sWhere))
            {
                sWhere = string.Concat("ParentID=", ParentID);
            }

            if (string.IsNullOrEmpty(sOrderBy))
                sOrderBy = " orderid,-id";
            return DbProviderCms.GetInstance().NewsClass_GetListArray(sWhere, top, sOrderBy, SiteID);

            //string CacheKey = string.Concat("lstsubMD-", ParentID, top, "-", SiteID, sWhere, sOrderBy);
            //List<EbSite.Entity.NewsClass> lstMD = bllCache.GetCacheItem(CacheKey) as List<EbSite.Entity.NewsClass>;
            //if (Equals(lstMD, null))
            //{
            //    if (string.IsNullOrEmpty(sWhere))
            //    {
            //        sWhere = string.Concat("ParentID=", ParentID);
            //    }

            //    if (string.IsNullOrEmpty(sOrderBy))
            //        sOrderBy = " orderid,-id";

            //    lstMD = DbProviderCms.GetInstance().NewsClass_GetListArray(sWhere, top, sOrderBy, SiteID);
            //    if (!Equals(lstMD, null))
            //        bllCache.AddCacheItem(CacheKey, lstMD);
            //}

            //return lstMD;
        }



        static public List<EbSite.Entity.NewsClass> GetSubClass(string ParentIDs, int top, int SiteID)
        {

            string CacheKey = string.Concat("lstsubMDPs-", ParentIDs, top, "-", SiteID);
            List<EbSite.Entity.NewsClass> lstMD = Host.CacheApp.GetCacheItem<List<EbSite.Entity.NewsClass>>(CacheKey, cacheclass);// as List<EbSite.Entity.NewsClass>;
            if (Equals(lstMD, null))
            {
                lstMD = DbProviderCms.GetInstance().NewsClass_GetListArray(string.Concat("ParentID in(", ParentIDs, ")"), top, " Annex2", SiteID);
                if (!Equals(lstMD, null))
                    Host.CacheApp.AddCacheItem(CacheKey, lstMD, cachetime, ETimeSpanModel.M, cacheclass);
            }

            return lstMD;
        }
        /// <summary>
        /// 获取某个分类下的子分类个数
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        static public int GetCount(int ParentID, int SiteID)
        {


            return DbProviderCms.GetInstance().NewsClass_GetCount(string.Concat("ParentID=", ParentID), SiteID);
        }
        static public List<EbSite.Entity.NewsClass> GetListPages_SubClass(int PageIndex, int PageSize, int ParentID, out int iCount, int SiteID)
        {
            iCount = GetCount(ParentID, SiteID);
            //orderid asc 有bug，不能分页

            //string strWhere = " Annex8='{0}' AND ParentID={1} ";
            string strWhere = " ParentID={0} ";
            strWhere = string.Format(strWhere, ParentID);
            return DbProviderCms.GetInstance().NewsClass_GetListPages(PageIndex, PageSize, strWhere, "orderid asc,id desc", SiteID);
            //return DbProviderCms.GetInstance().NewsClass_GetListPages(PageIndex, PageSize, string.Concat("ParentID=", ParentID,"Annex8=",0), "orderid asc,id desc");

        }


        static public List<EbSite.Entity.NewsClass> GetOrderListPages_SubClass(int PageIndex, int PageSize, int ParentID, out int iCount, int SiteID)
        {
            iCount = GetCount(ParentID, SiteID);
            //orderid asc 有bug，不能分页
            //return DbProviderCms.GetInstance().NewsClass_GetListPages(PageIndex, PageSize, string.Concat("ParentID=", ParentID,"Annex8=",0), "orderid asc,id desc");
            //string strWhere = " ParentID={0} AND Annex8='{1}' ";
            string strWhere = " ParentID={0}";
            strWhere = string.Format(strWhere, ParentID, 0);
            return DbProviderCms.GetInstance().NewsClass_GetListPages(PageIndex, PageSize, strWhere, "orderid asc,id desc", SiteID);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        static public List<Entity.NewsClass> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount, int SiteID)
        {
            RecordCount = DbProviderCms.GetInstance().NewsClass_GetCount(strWhere, SiteID);
            return DbProviderCms.GetInstance().NewsClass_GetListPages(PageIndex, PageSize, strWhere, "orderid asc,id desc", SiteID);
        }
        //static public List<EbSite.Entity.NewsClass> SearchClass(string sKeyWord)
        //{
        //    if (string.IsNullOrEmpty(sKeyWord)) return null;

        //    return GetListArr(" classname like '%" + sKeyWord + "%'");
        //}

        static public List<EbSite.Entity.NewsClass> GetListArr(string strWhere, int iTop, int SiteID)
        {
            return DbProviderCms.GetInstance().NewsClass_GetListArray(strWhere, iTop, "orderid asc,id desc", SiteID);
        }
        static public List<EbSite.Entity.NewsClass> GetListArr(string strWhere, int SiteID)
        {
            return DbProviderCms.GetInstance().NewsClass_GetListArray(strWhere, 0, "orderid asc,id desc", SiteID);
        }
        static public List<EbSite.Entity.NewsClass> GetListArr(string strWhere, string oderby, int SiteID)
        {
            return DbProviderCms.GetInstance().NewsClass_GetListArray(strWhere, 0, oderby, SiteID);
        }

       static public List<EbSite.Entity.NewsClass> GetListHtmlNameReWrite()
        {
            return DbProviderCms.GetInstance().NewsClass_GetListHtmlNameReWrite();
        }

        static public List<EbSite.Entity.NewsClass> GetListArr(string sField, string strWhere, int iTop, string oderby, int SiteID)
        {

            return DbProviderCms.GetInstance().NewsClass_GetListArray(sField, strWhere, iTop, oderby, SiteID);
        }

        static public List<EbSite.Entity.NewsClass> GetListByIDs(string sClassIDs, int SiteID)
        {
            string CacheKey = string.Concat("lstbyids-", sClassIDs, "-", SiteID);
            List<EbSite.Entity.NewsClass> lstMD = Host.CacheApp.GetCacheItem<List<EbSite.Entity.NewsClass>>(CacheKey,cacheclass);// as List<EbSite.Entity.NewsClass>;
            if (Equals(lstMD, null))
            {
                lstMD = DbProviderCms.GetInstance().NewsClass_GetListArray(string.Concat(" id in(", sClassIDs, ") "), 0, " charindex(','+rtrim(cast(id as   varchar(10)))+',','," + sClassIDs + ",')", SiteID);
                if (!Equals(lstMD, null))
                    Host.CacheApp.AddCacheItem(CacheKey, lstMD, cachetime, ETimeSpanModel.M, cacheclass);
            }

            return lstMD;


        }
        /// <summary>
        /// yhl 2013-11-21
        /// </summary>
        /// <param name="ParentID"></param>
        /// <param name="SiteID"></param>
        /// <param name="SubIDs"></param>
        /// <returns></returns>
        static public List<EbSite.Entity.NewsClass> GetSubIDs(int ParentID, int SiteID, out string SubIDs)
        {
            return DbProviderCms.GetInstance().NewsClassGetSubIDs(ParentID, SiteID, out SubIDs);
        }
        /// <summary>
        /// 获取某个分类下的所有子分类ID,用逗号分开
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        static public string GetSubIDs(int ParentID, int SiteID)
        {
            string CacheKey = string.Concat("GetSubIDs-", ParentID, "-", SiteID);
            string sIDs = Host.CacheApp.GetCacheItem<string>(CacheKey, cacheclass);// as string;
            if (string.IsNullOrEmpty(sIDs))
            {
                StringBuilder sb = new StringBuilder();

                GetSubID(ParentID, ref sb, SiteID);

                if (sb.Length > 1)
                    sb.Remove(sb.Length - 1, 1);


                sIDs = sb.ToString();

                if (!string.IsNullOrEmpty(sIDs))
                    Host.CacheApp.AddCacheItem(CacheKey, sIDs, cachetime, ETimeSpanModel.M, cacheclass);
            }
            return sIDs;
        }

        static public List<EbSite.Entity.NewsClass> GetParentList(int SiteId)
        {
            return DbProviderCms.GetInstance().NewsClass_GetListArray("ParentID=0", SiteId);
        }
        static private void GetSubID(int ParentID, ref StringBuilder sb, int SiteID)
        {
            List<EbSite.Entity.NewsClass> lst = DbProviderCms.GetInstance().NewsClass_GetListArray(" ParentID=" + ParentID, SiteID);
            foreach (EbSite.Entity.NewsClass newsClass in lst)
            {
                sb.Append(newsClass.ID);
                sb.Append(",");
                GetSubID(newsClass.ID, ref sb, SiteID);
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <returns></returns>
        static public List<EbSite.Entity.NewsClass> GetListArr(int SiteID)
        {
            return GetListArr("", SiteID);
        }
        /// <summary>
        /// 获取一级分类数据集
        /// </summary>
        /// <param name="iTop">为0,全部获取</param>
        /// <returns></returns>
        static public List<EbSite.Entity.NewsClass> GetParentClass(int iTop, int SiteID)
        {
            string CacheKey = string.Concat("GetParentClass-", iTop, "-", SiteID);
            List<EbSite.Entity.NewsClass> lstMD = Host.CacheApp.GetCacheItem<List<EbSite.Entity.NewsClass>>(CacheKey,cacheclass);// as List<EbSite.Entity.NewsClass>;
            if (Equals(lstMD, null))
            {
                lstMD = DbProviderCms.GetInstance().NewsClass_GetListArray("ParentID=0 ", iTop, " orderid", SiteID);
                if (!Equals(lstMD, null))
                    Host.CacheApp.AddCacheItem(CacheKey, lstMD, cachetime, ETimeSpanModel.M, cacheclass);
            }
            return lstMD;
            
        }
        static public List<EbSite.Entity.NewsClass> GetParentClass(int iTop, string sWhere, string sOrderBy, int SiteID)
        {
            string CacheKey = string.Concat("GetParentClass-", iTop, "-", SiteID);
            List<EbSite.Entity.NewsClass> lstMD = Host.CacheApp.GetCacheItem<List<EbSite.Entity.NewsClass>>(CacheKey,cacheclass);// as List<EbSite.Entity.NewsClass>;
            if (Equals(lstMD, null))
            {
                if (string.IsNullOrEmpty(sWhere))
                {
                    sWhere = "ParentID=0 ";
                }
                if (string.IsNullOrEmpty(sOrderBy))
                {
                    sOrderBy = " orderid ";
                }

                lstMD = DbProviderCms.GetInstance().NewsClass_GetListArray(sWhere, iTop, sOrderBy, SiteID);
                if (!Equals(lstMD, null))
                    Host.CacheApp.AddCacheItem(CacheKey, lstMD, cachetime, ETimeSpanModel.M, cacheclass);
            }
            return lstMD;
            //return DbProviderCms.GetInstance().NewsClass_GetListArray("ParentID=0 ", iTop, " orderid,-id");
        }
        /// <summary>
        /// 为了配合分类导航重载的方法,加入首页用 杨欢乐添加 一级分类
        /// </summary>
        static public List<EbSite.Entity.NewsClass> GetParentClass(int iTop, Entity.NewsClass mdOrther, int SiteID)
        {
            string CacheKey = string.Concat("GetParentClass-", iTop, "-", SiteID);
            List<EbSite.Entity.NewsClass> lstMD = Host.CacheApp.GetCacheItem<List<EbSite.Entity.NewsClass>>(CacheKey,cacheclass);// as List<EbSite.Entity.NewsClass>;
            if (Equals(lstMD, null))
            {
                lstMD = DbProviderCms.GetInstance().NewsClass_GetListArray("ParentID=0 ", iTop, " orderid", SiteID);
                if (!Equals(lstMD, null))
                    lstMD.Insert(0, mdOrther);
                Host.CacheApp.AddCacheItem(CacheKey, lstMD, cachetime, ETimeSpanModel.M, cacheclass);
            }
            return lstMD;
            //return DbProviderCms.GetInstance().NewsClass_GetListArray("ParentID=0 ", iTop, " orderid,-id");
        }
        //为了配合分类导航重载的方法,加入首页用
        static public List<EbSite.Entity.NewsClass> GetClassInIDs(string IDs, Entity.NewsClass mdOrther, int SiteID)
        {
            string CacheKey = string.Concat("GetClassInIDs-", IDs, "-", SiteID);
            List<EbSite.Entity.NewsClass> lstMD = Host.CacheApp.GetCacheItem<List<EbSite.Entity.NewsClass>>(CacheKey,cacheclass);// as List<EbSite.Entity.NewsClass>;
            if (Equals(lstMD, null))
            {
                lstMD = DbProviderCms.GetInstance().GetClassInIDs(IDs, SiteID);
                if (!Equals(lstMD, null))
                {
                    if (mdOrther != null)
                        lstMD.Insert(0, mdOrther);

                    Host.CacheApp.AddCacheItem(CacheKey, lstMD, cachetime, ETimeSpanModel.M, cacheclass);
                }

            }
            return lstMD;
        }

        static public List<EbSite.Entity.NewsClass> GetClassInIDs(string IDs, int SiteID)
        {

            return GetClassInIDs(IDs, null, SiteID);

        }
        public static List<EbSite.Entity.NewsClass> GetContentClassesTree(int iTop, int SiteID)
        {
            List<EbSite.Entity.NewsClass> getClass = DbProviderCms.GetInstance().NewsClass_GetListArray("", iTop, "orderid", SiteID);
            List<EbSite.Entity.NewsClass> getTree = new List<EbSite.Entity.NewsClass>();
            //int i = 0;
            foreach (EbSite.Entity.NewsClass tree in getClass)
            {
                //if(i>500)break; //由于树形一般用户下拉列表，这里最多只能列出500个分类
                if (tree.ParentID == 0)
                {
                    tree.ClassName = "╋" + tree.ClassName;
                    getTree.Add(tree);
                    GetSubItem(tree.ID, ref getTree, "├", getClass);
                }
                //i++;
            }
            return getTree;
        }

        public static List<EbSite.Entity.NewsClass> GetContentClassesTree(int SiteID)
        {
            int AllCount = DbProviderCms.GetInstance().NewsClass_GetCount("", SiteID);

            if (AllCount < 500)
            {
                List<EbSite.Entity.NewsClass> getClass = GetListArr(SiteID);
                List<EbSite.Entity.NewsClass> getTree = new List<EbSite.Entity.NewsClass>();
                //int i = 0;
                foreach (EbSite.Entity.NewsClass tree in getClass)
                {
                    //if(i>500)break; //由于树形一般用户下拉列表，这里最多只能列出500个分类
                    if (tree.ParentID == 0)
                    {
                        tree.ClassName = "╋" + tree.ClassName;
                        getTree.Add(tree);
                        GetSubItem(tree.ID, ref getTree, "├", getClass);
                    }
                    //i++;
                }
                return getTree;
            }
            else
            {
                return GetParentClass(500, SiteID);
            }

        }
        /// <summary>
        /// 获取某个记录下的子记录，从而构建树形(递归调用)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="GetTree"></param>
        /// <param name="blank"></param>
        private static void GetSubItem(int id, ref List<EbSite.Entity.NewsClass> NewClass, string blank, List<EbSite.Entity.NewsClass> OldClass)
        {
            foreach (EbSite.Entity.NewsClass tree in OldClass)
            {

                if (tree.ParentID == id)
                {
                    //ContentClass tr = tree.Clone();
                    string str = blank + "─";
                    tree.ClassName = str + "『" + tree.ClassName + "』";
                    NewClass.Add(tree);
                    GetSubItem(tree.ID, ref NewClass, str, OldClass);
                }
            }
        }

        static public int GetMaxOrderID(int iParentClassID, int SiteID)
        {
            return DbProviderCms.GetInstance().NewsClass_GetMaxOrderID(iParentClassID, SiteID);
        }
        ///// <summary>
        ///// 向下移动分类
        ///// </summary>
        ///// <param name="classid"></param>
        //static public void DownClassOrderID(int classid)
        //{
        //    DbProviderCms.GetInstance().NewsClass_DownClassOrderID(classid);
        //    bllCache.InvalidateCache();
        //}
        ///// <summary>
        ///// 向上移动分类
        ///// </summary>
        ///// <param name="classid"></param>
        //static public void UpClassOrderID(int classid)
        //{
        //    DbProviderCms.GetInstance().NewsClass_UpClassOrderID(classid);
        //    bllCache.InvalidateCache();
        //}

        static public void AddCommentNum(int iID, int iNum)
        {
            DbProviderCms.GetInstance().NewsClass_UpdateCommentNum(iID, iNum);
        }
        static public void AddFavorableNum(int iID, int iNum)
        {
            DbProviderCms.GetInstance().NewsClass_UpdateFavorableNum(iID, iNum);
        }
        static public void AddHits(int iID, int iNum)
        {
            DbProviderCms.GetInstance().NewsClass_AddHits(iID, iNum);
        }
        static public void ResetHits(string Interval)
        {
            DbProviderCms.GetInstance().NewsClass_ResetHits(Interval);
        }
        //public static EbSite.Entity.NewsClass GetADefaultConfig(int SiteID)
        //{
        //    EbSite.Entity.NewsClass model = new Entity.NewsClass();

        //    model.OrderID = 0;
        //    model.ContentHtmlName = Base.Configs.HtmlConfigs.ConfigsControl.Instance.ContentHtmlRule;
        //    model.ClassHtmlNameRule = Base.Configs.HtmlConfigs.ConfigsControl.Instance.ClassHtmlRule;
        //    model.IsCanAddContent = true;
        //    model.ContentModelID = new Guid("c7b51594-5ae8-4534-a5a4-5aca5eb9c7a2");
        //    model.ContentTemID = new Guid("89bd5515-638e-4187-b865-293549fc3a44");
        //    model.ClassTemID = new Guid("c148a4e8-b8f6-4c76-aaca-69dca808bb98");
        //    model.ClassModelID = new Guid("cfd5666c-0bd5-4beb-884b-75d23e7ca158");
        //    model.SubClassAddName = "";
        //    model.SubClassTemID = new Guid("c148a4e8-b8f6-4c76-aaca-69dca808bb98");
        //    model.SubClassModelID = new Guid("cfd5666c-0bd5-4beb-884b-75d23e7ca158");
        //    model.SubDefaultContentModelID = new Guid("c7b51594-5ae8-4534-a5a4-5aca5eb9c7a2");
        //    model.SubDefaultContentTemID = new Guid("89bd5515-638e-4187-b865-293549fc3a44");
        //    model.SubIsCanAddSub = true;
        //    model.SubIsCanAddContent = true;
        //    model.IsCanAddSub = true;
        //    model.ListTemID = new Guid("00000000-0000-0000-0000-000000000000");
        //    model.CommentNum = 0;
        //    model.FavorableNum = 0;
        //    model.UserID = 1;
        //    model.UserName = Base.Configs.BaseCinfigs.ConfigsControl.Instance.FounderuID;
        //    model.UserNiName = Base.Configs.BaseCinfigs.ConfigsControl.Instance.FounderuID;
        //    model.SiteID = SiteID;


        //    return model;
        //}
        //public static void ClassToDefault(int SiteID)
        //{
        //    DbProviderCms.GetInstance().NewsClass_ToDefault(GetADefaultConfig(SiteID));
        //}
        public static void ClassInitNum(int itype)
        {
            DbProviderCms.GetInstance().NewsClass_InitNum(itype);
        }
        /// <summary>
        /// 重新调整排序ID
        /// </summary>
        public static void ResetOrderID_Start(int SiteID)
        {
            List<int> aIDs = DbProviderCms.GetInstance().NewsClass_GetSubID(0);
            ResetOrderID(aIDs, SiteID);

        }
        /// <summary>
        /// 移动分类
        /// </summary>
        /// <param name="SoureClassID">源分类ID</param>
        /// <param name="TargetClassID">目标分类ID</param>
        /// <param name="IsAsChildnode">是否作为目标分类的子分类</param>
        static public void MoveClass(int SoureClassID, int TargetClassID, bool IsAsChildnode, int SiteID)
        {
            Entity.NewsClass md = GetModelByCache(TargetClassID);

            if (md.ParentID == SoureClassID)
            {
                Core.Strings.cJavascripts.MessageShowBack("父分类不能移到子分类下，如果您有这样的需求请先将子分类移出，再做移动！");
                return;
            }

            DbProviderCms.GetInstance().NewsClass_Move(SoureClassID, TargetClassID, IsAsChildnode, SiteID);
        }

        private static void ResetOrderID(List<int> iIDS, int SiteID)
        {
            if (iIDS.Count > 0)
            {
                for (int i = 0; i < iIDS.Count; i++)
                {
                    int iCurrentID = iIDS[i];
                    DbProviderCms.GetInstance().NewsClass_UpdateOrderID(iCurrentID, (i + 1), SiteID);

                    List<int> aSubIDs = DbProviderCms.GetInstance().NewsClass_GetSubID(iCurrentID);

                    ResetOrderID(aSubIDs, SiteID);
                }
            }
        }

        //static public void UpdateConfigsofClassAndSub(int iClassID, Guid ClassTempID, Guid ClassModelID, Guid ContentModelID, Guid ContentTemID, bool IsUpdateToSub, int SiteID)
        //{
        //    DbProviderCms.GetInstance().UpdateConfigsofClassAndSub(iClassID, ClassTempID, ClassModelID, ContentModelID, ContentTemID, IsUpdateToSub, SiteID);
        //}
        /// <summary>
        /// 合并分类，及数据
        /// </summary>
        /// <param name="iSID">源分类ID</param>
        /// <param name="iTID">目标分类ID</param>
        static public void MergeClass(int iSID, int iTID, string sTClassName, int SiteID, string NewContentTableName)
        {

            if (iSID == iTID)
            {
                Core.Strings.cJavascripts.MessageShowBack("源专题不能与目标专题相同");
                return;
            }
            Entity.NewsClass md = GetModelByCache(iTID);

            if (md.ParentID == iSID)
            {
                Core.Strings.cJavascripts.MessageShowBack("不能将父专题数据合并到子专题，如果您有这样的需求请先将子专题移出，再做合并！");
                return;
            }

            string IDs = GetSubIDs(iSID, SiteID);

            if (!string.IsNullOrEmpty(IDs))
            {
                IDs = string.Concat(iSID, ",", IDs);
            }
            else
            {
                IDs = iSID.ToString();
            }


            DbProviderCms.GetInstance().NewsContent_MergeClass(IDs, iTID, sTClassName, NewContentTableName);
            string[] aID = IDs.Split(',');
            foreach (string id in aID)
            {
                if (!string.IsNullOrEmpty(id))
                {
                    int sid = int.Parse(id);

                    Delete(sid, SiteID);
                }

            }

            //Entity.NewsClass md = GetModelByCache(iTID);

            //if (md.ParentID == iSID)
            //{
            //    Core.Strings.cJavascripts.MessageShowBack("不能将父分类数据合并到子分类，如果您有这样的需求请先将子分类移出，再做合并！");
            //    return;
            //}
            //string IDs = GetSubIDs(iSID);
            //    IDs = string.Concat(IDs, ",", iSID);

            //    string[] aID = IDs.Split(',');
            //    foreach (string id in aID)
            //    {
            //        if(!string.IsNullOrEmpty(id))
            //        {
            //            int cid = int.Parse(id);
            //            NewsContent.MergeContent(cid, iTID, sTClassName);
            //            Delete(cid);
            //        }

            //    }




        }

        public static List<EbSite.Entity.NewsClass> GetTree_pic(int iTop, int SiteID)
        {
            return GetTree_pic("", iTop, SiteID);
        }

        public static List<EbSite.Entity.NewsClass> GetTree_pic(string strWhere, int iTop, int SiteID)
        {

            List<EbSite.Entity.NewsClass> getClass = DbProviderCms.GetInstance().NewsClass_GetListArray(strWhere, iTop, "orderid", SiteID);
            List<EbSite.Entity.NewsClass> getTree = new List<EbSite.Entity.NewsClass>();
            //int i = 0;
            string sPatch1 = string.Concat("<img src=\"", EbSite.Base.AppStartInit.IISPath, "Images/tree/w3.gif\" align=absmiddle>");
            string sPatch = string.Concat("<img src=\"", EbSite.Base.AppStartInit.IISPath, "Images/tree/w1.gif\" align=absmiddle>");
            foreach (EbSite.Entity.NewsClass tree in getClass)
            {
                //if(i>500)break; //由于树形一般用户下拉列表，这里最多只能列出500个分类
                if (tree.ParentID == 0)
                {

                    tree.ClassName = sPatch + tree.ClassName;
                    getTree.Add(tree);
                    GetSubItem_pic(tree.ID, ref getTree, "", getClass);
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
        private static void GetSubItem_pic(int id, ref List<EbSite.Entity.NewsClass> NewClass, string blank, List<EbSite.Entity.NewsClass> OldClass)
        {
            string sW3 = string.Concat("<img src=\"", EbSite.Base.AppStartInit.IISPath, "Images/tree/w3.gif\" align=absmiddle>");
            string sW1 = string.Concat("<img src=\"", EbSite.Base.AppStartInit.IISPath, "Images/tree/w1.gif\" align=absmiddle>");
            foreach (EbSite.Entity.NewsClass tree in OldClass)
            {

                if (tree.ParentID == id)
                {
                    string str = blank;
                    str = string.Concat(str, sW3);
                    tree.ClassName = str + sW1 + tree.ClassName;
                    NewClass.Add(tree);
                    GetSubItem_pic(tree.ID, ref NewClass, str, OldClass);
                }
            }
        }

        #endregion  成员方法

        /// <summary>
        /// 获取今天添加分类数
        /// </summary>
        static public int GetCountByToday(int SiteID)
        {

            return DbProviderCms.GetInstance().NewsClass_GetCount("d", SiteID);


        }
        /// <summary>
        /// 获取本周添加分类数
        /// </summary>
        static public int GetCountByWeek(int SiteID)
        {

            return DbProviderCms.GetInstance().NewsClass_GetCount("w", SiteID);


        }
        /// <summary>
        /// 获取本月添加分类数
        /// </summary>
        static public int GetCountByMonth(int SiteID)
        {

            return DbProviderCms.GetInstance().NewsClass_GetCount("m", SiteID);


        }
        /// <summary>
        /// 获取本季添加分类数
        /// </summary>
        static public int GetCountByQuarter(int SiteID)
        {

            return DbProviderCms.GetInstance().NewsClass_GetCount("q", SiteID);


        }
        /// <summary>
        /// 获取本年添加分类数
        /// </summary>
        static public int GetCountByYear(int SiteID)
        {

            return DbProviderCms.GetInstance().NewsClass_GetCount("y", SiteID);


        }
        /// <summary>
        /// 获取所有添加内容数
        /// </summary>
        static public int GetCountAll(int SiteID)
        {

            return DbProviderCms.GetInstance().NewsClass_GetCount("", SiteID);


        }

        #region 复制类内容 杨欢乐 2011-10-26
        public static Entity.NewsClass GetCopyClass(int id)
        {

            Entity.NewsClass model = GetModel(id);
            Entity.NewsClass NewModel = new Entity.NewsClass();

            NewModel.ClassName = "复制" + model.ClassName;
            //NewModel.OrderID = model.OrderID-1;
            NewModel.ParentID = model.ParentID;
            NewModel.HtmlName = model.HtmlName;
            NewModel.Info = model.Info;
            NewModel.TitleStyle = model.TitleStyle;
            //NewModel.ContentHtmlName = model.ContentHtmlName;
            //NewModel.ClassHtmlNameRule = model.ClassHtmlNameRule;
            NewModel.SeoTitle = model.SeoTitle;
            NewModel.dayHits = model.dayHits;
            NewModel.weekHits = model.weekHits;
            NewModel.monthhits = model.monthhits;
            NewModel.lasthitstime = model.lasthitstime;
            NewModel.hits = model.hits;
            NewModel.SeoKeyWord = model.SeoKeyWord;
            NewModel.SeoDescription = model.SeoDescription;
            NewModel.OutLike = model.OutLike;
            //NewModel.IsCanAddContent = model.IsCanAddContent;
            //NewModel.ContentModelID = model.ContentModelID;
            //NewModel.ContentTemID = model.ContentTemID;
            //NewModel.ClassTemID = model.ClassTemID;
            //NewModel.ClassModelID = model.ClassModelID;
            NewModel.Annex1 = model.Annex1;
            NewModel.Annex2 = model.Annex2;
            NewModel.Annex3 = model.Annex3;
            NewModel.Annex4 = model.Annex4;
            NewModel.Annex5 = model.Annex5;
            NewModel.Annex6 = model.Annex6;
            NewModel.Annex7 = model.Annex7;
            NewModel.Annex8 = model.Annex8;
            NewModel.Annex9 = model.Annex9;
            NewModel.Annex10 = model.Annex10;

            NewModel.Annex11 = model.Annex11;
            NewModel.Annex12 = model.Annex12;
            NewModel.Annex13 = model.Annex13;
            NewModel.Annex14 = model.Annex14;
            NewModel.Annex15 = model.Annex15;
            NewModel.Annex16 = model.Annex16;
            NewModel.Annex17 = model.Annex17;

            //NewModel.SubClassAddName = model.SubClassAddName;
            //NewModel.SubClassTemID = model.SubClassTemID;
            //NewModel.SubClassModelID = model.SubClassModelID;
            //NewModel.SubDefaultContentModelID = model.SubDefaultContentModelID;
            //NewModel.SubDefaultContentTemID = model.SubDefaultContentTemID;
            //NewModel.SubIsCanAddSub = model.SubIsCanAddSub;
            //NewModel.SubIsCanAddContent = model.SubIsCanAddContent;
            //NewModel.IsCanAddSub = model.IsCanAddSub;
            //NewModel.ListTemID = model.ListTemID;
            NewModel.CommentNum = model.CommentNum;
            NewModel.FavorableNum = model.FavorableNum;
            NewModel.UserID = model.UserID;
            NewModel.UserName = model.UserName;
            NewModel.UserNiName = model.UserNiName;
            NewModel.AddTime = model.AddTime;
            //NewModel.PageSize = model.PageSize;
            //NewModel.ModuleID = model.ModuleID;
            NewModel.IsUserTheme = model.IsUserTheme;
            NewModel.IsAuditing = model.IsAuditing;
            NewModel.SiteID = model.SiteID;
            NewModel.RandNum = model.RandNum;
            NewModel.NumberTime = model.NumberTime;
            NewModel.ParentIDs = model.ParentIDs;
            int cid = Add(NewModel, NewModel.SiteID);

            NewModel.ID = cid;
            return NewModel;

            //要同时复制分类设置，未完成

        }
        #endregion

        static public List<EbSite.Entity.NewsClass> GetParents(int ClassID)
        {
            if (ClassID > 0)
            {
                string CacheKey = string.Concat("GetParents-", ClassID);
                List<EbSite.Entity.NewsClass> models = Host.CacheApp.GetCacheItem<List<EbSite.Entity.NewsClass>>(CacheKey,cacheclass);// as List<EbSite.Entity.NewsClass>;
                if (models == null)
                {
                    models = DbProviderCms.GetInstance().GetParents(ClassID, "");
                    if (!Equals(models, null))
                        Host.CacheApp.AddCacheItem(CacheKey, models, cachetime, ETimeSpanModel.M, cacheclass);
                }

                return models;
            }

            else
            {
                return new List<Entity.NewsClass>();
            }
        }

        //static public List<EbSite.Entity.NewsClass> GetParents(string sFiles, int ParentID)
        //{
        //    return DbProviderCms.GetInstance().GetParents(sFiles, ParentID);
        //}
        #region 获取导航
        public static string GetNav(string Nav, int ClassId, bool IsAddIndex, int GetSiteID, int FilterClassID)
        {

            string CacheKey = string.Concat("NewsClassGetNav-", ClassId, Nav, ClassId, IsAddIndex, GetSiteID);
            string str = Host.CacheApp.GetCacheItem<string>(CacheKey,cacheclass);// as string;
            if (str == null)
            {
                str = GetNavStr(Nav, ClassId, IsAddIndex, GetSiteID, FilterClassID);
                if (!string.IsNullOrEmpty(str))
                    Host.CacheApp.AddCacheItem(CacheKey, str, cachetime, ETimeSpanModel.M, cacheclass);
            }

            return str;

        }
        //public static string GetNav(string Nav, Entity.NewsClass Model, bool IsAddCurrentModel, int GetSiteID)
        //{
        //    string CacheKey = string.Concat("NewsClassGetNav-", Model.ID, Nav, Model.ParentID, IsAddCurrentModel, GetSiteID);
        //    string str = bllCache.GetCacheItem(CacheKey) as string;
        //    if (str == null)
        //    {
        //        str = GetNavStr(Nav, Model, IsAddCurrentModel, GetSiteID);
        //        if (!string.IsNullOrEmpty(str))
        //            bllCache.AddCacheItem(CacheKey, str);
        //    }

        //    return str;

        //}

        /// <summary>
        /// --用户
        /// </summary>
        /// <param name="Nav"></param>
        /// <param name="ClassID"></param>
        /// <param name="IsAddIndex">是否显示站点名称</param>
        /// <param name="GetSiteID"></param>
        /// <param name="FilterClassID">过滤掉的分类ID</param>
        /// <returns></returns>
        static private string GetNavStr(string Nav, int ClassID, bool IsAddIndex, int GetSiteID, int FilterClassID)
        {
            StringBuilder sbLink = new StringBuilder();
            List<Entity.NewsClass> lst = GetParents(ClassID);

            if (IsAddIndex)
            {
                sbLink.AppendFormat("<span ><a title='{1}' href='{0}' >{1}</a></span>{2}",
                BLL.GetLink.LinkOrther.Instance.GetInstance(GetSiteID).GetMainIndexHref(), EbSite.BLL.Sites.Instance.GetEntity(GetSiteID).SiteName, Nav
                   );
            }

            //int iCount = lst.Count;
            //int iEndCount = lst.Count-1;
            //for (int i = 0; i < iCount; i++)
            //{
            //    Entity.NewsClass newsClass = lst[i];
            //    sbLink.AppendFormat("<a title='{1}' href='{0}' ><span style='font-size:14px;'>{1}</span></a>",
            //       BLL.GetLink.LinkClass.Instance.GetInstance(GetSiteID).GetClassHref(newsClass.ID, newsClass.HtmlName, 1),
            //       newsClass.ClassName
            //       );
            //    if (i < iEndCount)
            //    {
            //        sbLink.Append(Nav);
            //    }

            //}

            for (int i = lst.Count - 1; i >= 0; i--)
            {
                Entity.NewsClass newsClass = lst[i];
                //if (newsClass.IsCanAddContent)
                //{
                //    sbLink.AppendFormat("<span><a title='{1}' href='{0}' >{1}</a></span>",
                //   BLL.GetLink.LinkClass.Instance.GetInstance(GetSiteID).GetClassHref(newsClass.ID, newsClass.HtmlName, 1),
                //   newsClass.ClassName
                //   );
                //}
                //else
                //{
                //    sbLink.AppendFormat("<span><a href='#' title='{0}' >{0}</a></span>", newsClass.ClassName);
                //}
                if (newsClass.ID != FilterClassID)
                {
                    sbLink.AppendFormat("<span><a title='{1}' href='{0}' >{1}</a></span>",
                                        BLL.GetLink.LinkClass.Instance.GetInstance(GetSiteID)
                                           .GetClassHref(newsClass.ID, newsClass.HtmlName, 1),
                                        newsClass.ClassName
                        );

                    if (i > 0)
                        sbLink.Append(Nav);
                }
            }

            return sbLink.ToString();
        }

        public static string GetNavAdmin(string Url, int ParentID)
        {
            string CacheKey = string.Concat("GetNavAdmin-", ParentID);
            string str = Host.CacheApp.GetCacheItem<string>(CacheKey,cacheclass);// as string;
            if (str == null)
            {
                str = GetNavStrAdmin(Url, ParentID);

                if (!string.IsNullOrEmpty(str))
                    Host.CacheApp.AddCacheItem(CacheKey, str, cachetime, ETimeSpanModel.M, cacheclass);
            }

            return str;
        }

        /// <summary>
        /// 后台管理的
        /// </summary>
        /// <param name="Nav"></param>
        /// <param name="Model"></param>
        /// <param name="IsAddCurrentModel"></param>
        /// <param name="GetSiteID"></param>
        /// <returns></returns>
        static private string GetNavStrAdmin(string Url, int ParentID)
        {
            StringBuilder sbLink = new StringBuilder();

            List<Entity.NewsClass> lst = GetParents(ParentID);
            sbLink.AppendFormat("<a   href='{0}' >一级分类</a>", Url);
            for (int i = lst.Count - 1; i >= 0; i--)
            {
                sbLink.AppendFormat(">>");
                Entity.NewsClass newsClass = lst[i];
                sbLink.AppendFormat("<a   href='{0}&pid={2}' >{1}</a>",
                   Url,
                   newsClass.ClassName, newsClass.ID
                   );
            }

            return sbLink.ToString();
        }
        #endregion

        #region 欢乐 2013-01-10
        static public EbSite.Entity.NewsClass GetModel(string sField, string strWhere)
        {
            return GetModelByCache(sField, strWhere);

        }
        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        static public Entity.NewsClass GetModelByCache(string sField, string strWhere)
        {
            string CacheKey = "NewsClass-" + sField + strWhere.Replace(" ","").Replace("\'","");
            Entity.NewsClass model = Host.CacheApp.GetCacheItem<Entity.NewsClass>(CacheKey,cacheclass);// as Entity.NewsClass;
            if (model == null)
            {
                model = DbProviderCms.GetInstance().NewsClass_GetModel(sField, strWhere);

                GetClassEntityEventArgs Args = new GetClassEntityEventArgs(model);
                Base.EBSiteEvents.OnGetClassEntityed(model, Args);

                if (!Equals(model, null))
                    Host.CacheApp.AddCacheItem(CacheKey, model, cachetime, ETimeSpanModel.M, cacheclass);
            }

            return model;
        }
        #endregion

        //static public Guid GetTemID(int ClassID)
        //{
        //    return DbProviderCms.GetInstance().NewsClass_TemID(ClassID);
        //}

        static public void Update(string Where, string Col, string sValue)
        {
            DbProviderCms.GetInstance().NewsClass_Update(Where, Col, sValue);
            Host.CacheApp.InvalidateCache(cacheclass);
        }

        public static void SetSubSiteToMainUpdateSiteID(int MainSiteID, int SubSiteID)
        {
            DbProviderCms.GetInstance().SetSubSiteToMainUpdateSiteID(MainSiteID, SubSiteID);
            Host.CacheApp.InvalidateCache(cacheclass);
        }

        public static void DeleteOutSiteData(string siteids)
        {
            DbProviderCms.GetInstance().DeleteNewsClassOutSiteData(siteids);
        }
        #region 2014-2-13 后台 分类管理-》分类列表
        //YHL 2014-2-13 后台 分类管理-》分类列表 
        static public List<EbSite.Entity.NewsClass> GetModelIdListPages(int PageIndex, int PageSize, int ParentID,

                                                                              out int RecordCount, int SiteID, Guid ModelID)
        {
            string strWhere = string.Concat("ParentID=", ParentID) ;

            return DbProviderCms.GetInstance().NewsClass_ModelIDGetListPages(PageIndex, PageSize, strWhere, "a.orderid asc,a.id desc", SiteID, out RecordCount, ModelID);

            //string strWhere = "";
            //if (ParentID == 0)
            //{
            //    strWhere = "  classmodelid='{0}'";
            //    strWhere = string.Format(strWhere, ModelID);
            //    return DbProviderCms.GetInstance().NewsClass_ModelIDGetListPages(PageIndex, PageSize, strWhere, "a.orderid asc,a.id desc", SiteID, out  RecordCount);
            //}
            //else
            //{
            //    return GetListPages_SubClass(PageIndex, PageSize, ParentID, out RecordCount, SiteID);
            //}
        }
        #endregion

        #region 2014-2-13 后台 分类管理-》分类列表 树型格式的数据源
        //2014-2-13 后台 分类管理-》分类列表 树型格式的数据源
        public static List<EbSite.Entity.NewsClass> GetTreeModelID_pic(int iTop, int SiteID, Guid ModelID)
        {
            //string strWhere = string.Format(" classmodelid='{0}'", ModelID);
            List<EbSite.Entity.NewsClass> getClass =  DbProviderCms.GetInstance().NewsClass_ModelIDGetListArray("", "", iTop, "orderid desc", SiteID, ModelID);
            // 2014-4-1 之前是先查出当前模型下的分类，一级分类都配置了configclass 子类很多没有配置，configclass 会在系统启动时放到内存中去，此数据量不可过大。
            // 由于先通过模型查 导致 数据不完整。后采用 通过模型只查 一级类，然后递归子类去。这样结果 页面很卡。
            //现在 是把当前站点中的所有分类都查出来，去和 父类去匹配去。
            //List<EbSite.Entity.NewsClass> getClassAll = GetListArr(SiteID);

            List<EbSite.Entity.NewsClass> getTree = new List<EbSite.Entity.NewsClass>();

            string sPatch1 = string.Concat("<img src=\"", EbSite.Base.AppStartInit.IISPath, "Images/tree/w3.gif\" align=absmiddle>");
            string sPatch = string.Concat("<img src=\"", EbSite.Base.AppStartInit.IISPath, "Images/tree/w1.gif\" align=absmiddle>");
            foreach (EbSite.Entity.NewsClass tree in getClass)
            {
                //if(i>500)break; //由于树形一般用户下拉列表，这里最多只能列出500个分类
                if (tree.ParentID == 0)
                {

                    tree.ClassName = sPatch + tree.ClassName;
                    getTree.Add(tree);
                    GetModelIDSubItem_pic(tree.ID, ref getTree, "", SiteID, getClass);
                }
                //i++;
            }
            return getTree;
        }

        private static void GetModelIDSubItem_pic(int id, ref List<EbSite.Entity.NewsClass> NewClass, string blank, int SiteID, List<EbSite.Entity.NewsClass> getClassAll)
        {
            string sW3 = string.Concat("<img src=\"", EbSite.Base.AppStartInit.IISPath, "Images/tree/w3.gif\" align=absmiddle>");
            string sW1 = string.Concat("<img src=\"", EbSite.Base.AppStartInit.IISPath, "Images/tree/w1.gif\" align=absmiddle>");


            // List<EbSite.Entity.NewsClass> OldClass= EbSite.BLL.NewsClass.GetSubClass(id, 0, SiteID);
            foreach (EbSite.Entity.NewsClass tree in getClassAll)
            {

                if (tree.ParentID == id)
                {
                    string str = blank;
                    str = string.Concat(str, sW3);
                    tree.ClassName = str + sW1 + tree.ClassName;
                    NewClass.Add(tree);
                    GetModelIDSubItem_pic(tree.ID, ref NewClass, str, SiteID, getClassAll);
                }
            }
        }
        #endregion

        #region 2014-2-13  用于 前台类页面 没有传cid时 查 当前模型下的 所有一级分类 子类 前台用Repeater 嵌套
        //2014-2-13  用于 前台类页面 没有传cid时 查 当前模型下的 所有一级分类 子类 前台用Repeater 嵌套
        static public List<EbSite.Entity.NewsClass> GetModelIdParentClass(int iTop, string sWhere, string sOrderBy, int SiteID, Guid ModelId)
        {
            string CacheKey = string.Concat("GetModelIdParentClass-", iTop, "-", SiteID);
            List<EbSite.Entity.NewsClass> lstMD = Host.CacheApp.GetCacheItem<List<EbSite.Entity.NewsClass>>(CacheKey, cacheclass);// as List<EbSite.Entity.NewsClass>;
            if (Equals(lstMD, null))
            {
                if (string.IsNullOrEmpty(sWhere))
                {
                    sWhere = "a.ParentID=0";//string.Format("ParentID=0 and classmodelid='{0}'", ModelId);
                }
                if (string.IsNullOrEmpty(sOrderBy))
                {
                    sOrderBy = " orderid desc";
                }

                lstMD = DbProviderCms.GetInstance().NewsClass_ModelIDGetListArray("", sWhere, iTop, sOrderBy, SiteID, ModelId);
                if (!Equals(lstMD, null))
                    Host.CacheApp.AddCacheItem(CacheKey, lstMD, cachetime, ETimeSpanModel.M, cacheclass);
            }
            return lstMD;

        }
        #endregion

        #region 2014-4-1 通过模型Guid 查出父子tree 树形的数据源

        public static List<EbSite.Entity.NewsClass> GetTreeModelID(int iTop, int SiteID, Guid ModelID)
        {
            //string strWhere = string.Format(" classmodelid='{0}'", ModelID);
            List<EbSite.Entity.NewsClass> getClass = DbProviderCms.GetInstance().NewsClass_ModelIDGetListArray("", "", iTop, "orderid", SiteID, ModelID);
            List<EbSite.Entity.NewsClass> getClassAll = GetListArr(SiteID);

            List<EbSite.Entity.NewsClass> getTree = new List<EbSite.Entity.NewsClass>();


            foreach (EbSite.Entity.NewsClass tree in getClass)
            {
                //if(i>500)break; //由于树形一般用户下拉列表，这里最多只能列出500个分类
                if (tree.ParentID == 0)
                {

                    tree.ClassName = "╋" + tree.ClassName;
                    getTree.Add(tree);
                    GetModelIDSubItem(tree.ID, ref getTree, "├", SiteID, getClassAll);
                }
                //i++;
            }
            return getTree;
        }

        private static void GetModelIDSubItem(int id, ref List<EbSite.Entity.NewsClass> NewClass, string blank, int SiteID, List<EbSite.Entity.NewsClass> getClassAll)
        {

            foreach (EbSite.Entity.NewsClass tree in getClassAll)
            {

                if (tree.ParentID == id)
                {
                    string str = blank + "─";
                    tree.ClassName = str + "『" + tree.ClassName + "』";
                    NewClass.Add(tree);
                    GetModelIDSubItem_pic(tree.ID, ref NewClass, str, SiteID, getClassAll);
                }
            }
        }
        #endregion
        /// <summary>
        /// 获取当前 分类下的所有子分类
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        static   public List<int> GetChildIDClass(int ParentID,int SiteID)
         {
           return  DbProviderCms.GetInstance().GetChildIDClass(ParentID, SiteID);
         }
      static   public List<Entity.NewsClass> GetChildClass(int ParentID, int SiteID)
         {
             return DbProviderCms.GetInstance().GetChildClass(ParentID,SiteID);
         }
        static public List<Entity.NewsClass> GetNotConfigParent(int SiteId)
        {
            return DbProviderCms.GetInstance().NewsClass_GetNotConfig(string.Format("ParentID=0 And SiteId={0}", SiteId));
        }
        static public List<Entity.NewsClass> GetNotConfigIds(string ids)
        {
            return DbProviderCms.GetInstance().NewsClass_GetNotConfig("id in("+ ids + ")");
        }




    }
}
 