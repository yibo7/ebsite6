using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web;
using EbSite.Base;
using EbSite.Base.Configs.UserSetConfigs;
using EbSite.Base.EntityAPI;
using EbSite.BLL.ModelBll;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Base.Static;
using EbSite.Core;
using EbSite.Core.RSS;
using EbSite.Core.Strings;
using EbSite.Data.Interface;
using EbSite.Entity;
namespace EbSite.BLL
{
    /// <summary>
    /// 业务逻辑类NewsContent 的摘要说明。
    /// </summary>
    public class NewsContentSplitTable
    {
        const double cachetime = 10.0;// 
        //private CacheManager bllCache;
        private string TableName = "NewsContent";
        private  string cachecontent ;
        public NewsContentSplitTable(string tablename)
        {
            TableName = tablename;
            cachecontent=  string.Concat("nc-", tablename) ;
            //bllCache = new CacheManager(CacheDuration, MasterCacheKeyArray);
        }

        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public long GetMaxId()
        {
            return DbProviderCms.GetInstance().NewsContent_GetMaxId(TableName);
        }
        public bool Exists(string where)
        {
            return DbProviderCms.GetInstance().NewsContent_Exists(where, TableName);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID, int SiteID)
        {
            return DbProviderCms.GetInstance().NewsContent_Exists(string.Concat(" SiteId=", SiteID, " and ID=", ID), TableName);
        }
        public bool ExistsTitleAndClassID(string Title, int ClassID)
        {
            return DbProviderCms.GetInstance().NewsContent_Exists(string.Concat("newstitle='", Title, "' and classid=", ClassID), TableName);
        }
        ///// <summary>
        ///// 合并分类内容
        ///// </summary>
        ///// <param name="SID">源分类ID</param>
        ///// <param name="TID">目标分类ID</param>
        ///// <param name="TClassName">目标分类名称</param>
        //static public void MergeContent(int SID, int TID,string TClassName)
        //{
        //    DbProviderCms.GetInstance().NewsContent_MergeClass(SID, TID, TClassName);
        //}
        /// <summary>
        /// 返回上一条记录
        /// </summary>
        /// <param name="musicid">歌曲ID</param>
        /// <returns>第一个值是上一首ID，第二个值为下一首ID</returns>
        public Entity.NewsContent UpModel(long ContentID, string Fields, int SiteID)
        {
            string CacheKey = string.Concat("UpModel-", ContentID, "-", SiteID);
            Entity.NewsContent model = Host.CacheApp.GetCacheItem<Entity.NewsContent>(CacheKey,cachecontent); //as Entity.NewsContent;
            if (model == null)
            {
                //yhl 2012-03-27 添加 应该查同一个类别下的
                EbSite.Entity.NewsContent md = GetModel(ContentID, SiteID);

                List<Entity.NewsContent> lst = DbProviderCms.GetInstance().NewsContent_GetListArray(string.Concat(" ClassID =" + md.ClassID + " and id <", ContentID), 1, "id desc", Fields, SiteID, TableName);

                if (lst.Count > 0)
                {
                    model = lst[0];
                }
                if (!Equals(model, null))
                    Host.CacheApp.AddCacheItem(CacheKey, model, cachetime, ETimeSpanModel.M, cachecontent);
                    
            }

            return model;
        }
        /// <summary>
        /// 返回下一条记录
        /// </summary>
        /// <param name="musicid"></param>
        /// <returns></returns>
        public Entity.NewsContent NextModel(int ContentID, string Fields, int SiteID)
        {
            string CacheKey = string.Concat("NextModel-", ContentID, "-", SiteID);
            Entity.NewsContent model = Host.CacheApp.GetCacheItem<Entity.NewsContent>(CacheKey, cachecontent); //bllCache.GetCacheItem(CacheKey) as Entity.NewsContent;
            if (model == null)
            {
                //yhl 2012-03-27 添加 应该查同一个类别下的
                EbSite.Entity.NewsContent md = GetModel(ContentID, SiteID);
                List<Entity.NewsContent> lst = DbProviderCms.GetInstance().NewsContent_GetListArray(string.Concat("ClassID =" + md.ClassID + " and id >", ContentID), 1, "id asc", Fields, SiteID, TableName);

                if (lst.Count > 0)
                {
                    model = lst[0];
                }
                if (!Equals(model, null))
                    Host.CacheApp.AddCacheItem(CacheKey, model, cachetime, ETimeSpanModel.M, cachecontent);
                   
            }

            return model;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.NewsContent GetModel(long ID, int SiteID)
        {
            Entity.NewsContent mlNewsContent = DbProviderCms.GetInstance().NewsContent_GetModel(ID, TableName, SiteID);
            //string CacheKey = string.Concat("GetModel-", ID);
            //Entity.NewsContent mlNewsContent = Host.CacheApp.GetCacheItem<Entity.NewsContent>(CacheKey, cachecontent);// bllCache.GetCacheItem(rawKey) as Entity.NewsContent;
            //if (Equals(mlNewsContent, null))
            //{
            //    mlNewsContent = DbProviderCms.GetInstance().NewsContent_GetModel(ID, TableName, SiteID);
            //    if (mlNewsContent == null) return null;
            //       Host.CacheApp.AddCacheItem(CacheKey, mlNewsContent, cachetime, ETimeSpanModel.M, cachecontent);


            //}

            GetContentEntityEventArgs Args = new GetContentEntityEventArgs(mlNewsContent);
            Base.EBSiteEvents.OnGetContentEntityed(mlNewsContent, Args);

            return mlNewsContent;
        }
        public Entity.NewsContent GetModel(long ID, int ClassId, int SiteID)
        {
            string CacheKey = string.Concat("GetModel-", ID, "-", ClassId, "-", SiteID);
            Entity.NewsContent mlNewsContent = Host.CacheApp.GetCacheItem<Entity.NewsContent>(CacheKey, cachecontent);// bllCache.GetCacheItem(rawKey) as Entity.NewsContent;
            if (Equals(mlNewsContent, null))
            {
                mlNewsContent = DbProviderCms.GetInstance().NewsContent_GetModel(ID, TableName, ClassId, SiteID);
                if (mlNewsContent == null) return null;
                Host.CacheApp.AddCacheItem(CacheKey, mlNewsContent, cachetime, ETimeSpanModel.M, cachecontent);


            }

            GetContentEntityEventArgs Args = new GetContentEntityEventArgs(mlNewsContent);
            Base.EBSiteEvents.OnGetContentEntityed(mlNewsContent, Args);

            return mlNewsContent;
        }
        /// <summary>
        /// 不转入站点ID，只获取自带字段，不获取扩展字段
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Entity.NewsContent GetModelDefaultFiled(long ID,int SiteID)
        {
            return DbProviderCms.GetInstance().NewsContent_GetModel(ID, TableName, SiteID);
        }
        public Entity.NewsContent GetModelDefaultFiled(long ID)
        {
            return DbProviderCms.GetInstance().NewsContent_GetModel(ID, TableName, 0);
        }
        /// <summary>
        /// 添加一条内容的业务处理
        /// </summary>
        /// <param name="ThisModel">内容对象</param>
        /// <param name="ID">修改对象ID，如果是新添加内容，为-1</param>
        /// <param name="IsDownSmallPic">当缩略图为空时，是否检测内容里的图片，并下载第一张作为缩略图</param>
        /// <returns></returns>
        public long AddBLL(EbSite.Entity.NewsContent ThisModel, long ID, bool IsDownSmallPic, int SiteID, Guid ContentModuleId)
        {
            if (IsDownSmallPic)
            {
                if (string.IsNullOrEmpty(ThisModel.SmallPic.Trim())) //如果用户不上传缩略图,检测内容里有没有图片，如果有将获取第一张作为缩略图
                {
                    List<string> array = GetString.GetImgUrl(ThisModel.ContentInfo);

                    if (array.Count > 0)
                    {
                        string sSmallPic = array[0];
                        if (!string.IsNullOrEmpty(sSmallPic) && sSmallPic.IndexOf("http://") == -1)
                        {

                            //string sFileType = GetString.getFileType(sSmallPic);
                            //sSmallPic = HttpContext.Current.Server.MapPath(array[0].ToString());
                            //string sNewName = Path.GetRandomFileName().Replace(".", "");//某些情况下带点路径不兼用;
                            //string sSavePath = string.Concat(EbSite.Base.AppStartInit.UserUploadPath, "/SmallImg/", sNewName, sFileType);
                            //int iWidth = Base.Configs.PicConfigs.ConfigsControl.Instance.MiniatureWidth;
                            //int iHeith = Base.Configs.PicConfigs.ConfigsControl.Instance.MiniatureHeight;

                            //if (ImagesMake.GenThumbnail(sSmallPic, HttpContext.Current.Server.MapPath(sSavePath), iWidth, iHeith))
                            //    ThisModel.SmallPic = sSmallPic;

                            ThisModel.SmallPic = sSmallPic.Replace("ebbaseimg", "ebsmallimg");
                        }

                    }
                }
            }
            ThisModel.SiteID = SiteID;
            ThisModel.NumberTime = Core.SqlDateTimeInt.GetSecond(ThisModel.AddTime);
            //更新标签
            string sTags = ThisModel.TagIDs;
            string[] aTags = null;
            if (!string.IsNullOrEmpty(sTags)) aTags = sTags.Split(',');
            long newid = 0;
            if (ID > 0)
            {

                UpdateingContentEventArgs Args = new UpdateingContentEventArgs(ThisModel.ID, ThisModel.ClassID);
                Base.EBSiteEvents.OnContentUpdateing(ThisModel, Args);
                if (!Args.StopAdd) //是否有事件阻住添加
                {
                    ThisModel.ID = ID;
                    Update(ThisModel);
                    BLL.TagKey.UpdateTag(sTags, ID, ThisModel.ClassID, SiteID);
                    newid = ID;
                }
               
            }
            else
            {
                //添加前触发的事件
                AddingContentEventArgs Args = new AddingContentEventArgs(ThisModel.ID, ThisModel.ClassID);
                Base.EBSiteEvents.OnContentAdding(ThisModel, Args);
                if (!Args.StopAdd) //是否有事件阻住添加
                {
                    newid = Add(ThisModel);

                    //添加后触发的事件
                    AddedContentEventArgs Argsed = new AddedContentEventArgs(ThisModel.ID, ThisModel.NewsTitle, ThisModel.ClassID);
                    Base.EBSiteEvents.OnContentAdded(ThisModel, Argsed);

                    if (!Equals(aTags, null) && newid > 0) //添加标签的相关操作
                    {
                        //添加标签
                        BLL.TagKey.AddTags(aTags, newid, ThisModel.ClassID, SiteID, AppStartInit.UserID);

                    }
                }
            }
            StringDictionary sd = ThisModel.GetCusttomFileds();
            if (sd.Count > 0&& ContentModuleId!=Guid.Empty)
            {
                CusttomFiledsBLL<List<DataFiled>> cfb = ModelBll.CusstomFileds.HrefFactory.GetInstContent(ContentModuleId, SiteID);
                cfb.Save(newid, sd);
            }

            return newid;

        }
        public void InvalidateCache()
        {
            Host.CacheApp.InvalidateCache(cachecontent);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EbSite.Entity.NewsContent model)
        {
           // bllCache.InvalidateCache();
            Host.CacheApp.InvalidateCache(cachecontent);
            //应该是系统指定权限不用审核
            //2013-03-11 杨欢乐 解决 外部 传来 用户id .快速发帖时，不是当时用户，是随机用户。
            if (model.UserID > 0)
            {
                if (string.IsNullOrEmpty(model.UserName))
                    model.UserName = EbSite.Base.Host.Instance.GetUserUserName(model.UserID);

                if (string.IsNullOrEmpty(model.UserNiName))
                    model.UserNiName = EbSite.Base.Host.Instance.GetUserByID(model.UserID).NiName;

                //由外面定义是否要通过审核
                //model.IsAuditing = !Base.Host.Instance.GetIsAuditing();//EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.AuditingContent;
            }
            else
            {
                model.UserName = AppStartInit.UserName;
                model.UserNiName = AppStartInit.UserNiName;
                model.UserID = AppStartInit.UserID;

                model.IsAuditing = !Base.Host.Instance.GetIsAuditing();//!EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.AuditingContent;
            }

           


            #region 添加内容时 要获得积分
            //添加内容时 要获得积分 2011-12-31 杨欢乐添加
            EbSite.Base.EntityAPI.MembershipUserEb umd = EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(model.UserID);
            if (!Equals(umd, null))
            {
                int score = int.Parse(ConfigsControl.Instance.AddContentInCredit.ToString());
                umd.Credits += score;
                EbSite.BLL.User.MembershipUserEb.Instance.Update(umd);
            }

            #endregion
            AddingContentEventArgs Args = new AddingContentEventArgs(model.ID, model.ClassID);
            Base.EBSiteEvents.OnContentAdding(model, Args);
            if (!Args.StopAdd)
            {
                //return DbProviderCms.GetInstance().NewsContent_Add(model);
                int sid = DbProviderCms.GetInstance().NewsContent_Add(model, TableName);
                AddedContentEventArgs Argsed = new AddedContentEventArgs(model.ID, model.NewsTitle, model.ClassID);
                Base.EBSiteEvents.OnContentAdded(model, Argsed);
                return sid;

            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 批量添加音乐
        /// </summary>
        /// <param name="mblist"></param>
        /// <returns></returns>
        public int AddList(List<Entity.NewsContent> mblist)
        {
            int errCount = 0;
            foreach (EbSite.Entity.NewsContent list in mblist)
            {
                errCount = DbProviderCms.GetInstance().NewsContent_Add(list, TableName);
            }
            Host.CacheApp.InvalidateCache(cachecontent);//bllCache.InvalidateCache();

            return errCount;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(EbSite.Entity.NewsContent model)
        {
            model.NumberTime = Core.SqlDateTimeInt.GetSecond(model.AddTime);
            DbProviderCms.GetInstance().NewsContent_Update(model, TableName);
            Host.CacheApp.InvalidateCache(cachecontent);
        }


        public void Update(int id, string Col, string sValue)
        {
            DbProviderCms.GetInstance().NewsContent_Update(id, Col, sValue, TableName);
        }



        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(long ID,int SiteID)
        {

            DeleteingContentEventArgs Args = new DeleteingContentEventArgs(ID, TableName,SiteID);
            Base.EBSiteEvents.OnContentDeleteing(null, Args);
            if (!Args.StopDelete)
            {
                DbProviderCms.GetInstance().NewsContent_Delete(ID, TableName);
                EbSite.BLL.TagRelateNews.DeleteByRemove("", ID);
                //CusttomFiledsBLLContent.Instance.Delete(ID);
                Host.CacheApp.InvalidateCache(cachecontent); //bllCache.InvalidateCache();
            }

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(EbSite.Entity.NewsContent Model)
        {
            Delete(Model.ID,Model.SiteID);
            //DbProviderCms.GetInstance().NewsContent_Delete(Model.ID);
            Host.CacheApp.InvalidateCache(cachecontent);//bllCache.InvalidateCache();
        }
        /// <summary>
        /// 对点击数清零
        /// </summary>
        public void ResetHits(string Interval)
        {
            DbProviderCms.GetInstance().NewsContent_ResetHits(Interval, TableName);
        }
        /// <summary>
        /// 累加点击
        /// </summary>
        /// <param name="iMusicID">ID</param>
        public void AddHits(int iID, int iNum)
        {
            DbProviderCms.GetInstance().NewsContent_AddHits(iID, iNum, TableName);
        }
        /// <summary>
        /// 累加更新内容的评论条数
        /// </summary>
        /// <param name="iMusicID">ID</param>
        public void AddCommentNum(int iID, int iNum)
        {
            DbProviderCms.GetInstance().NewsContent_UpdateCommentNum(iID, iNum, TableName);
        }
        /// <summary>
        /// 累加更新内容的收藏用户人数
        /// </summary>
        public void AddFavorableNum(int iID, int iNum)
        {
            DbProviderCms.GetInstance().NewsContent_UpdateFavorableNum(iID, iNum, TableName);
        }
        public void MakeHtmlName(EbSite.Entity.NewsContent model)
        {
            string sRule = model.ContentHtmlNameRule;

            model.HtmlName = HtmlReNameRule.GetName(sRule, model.NewsTitle, "");

            Update(model);
        }
        public void UpdateAllRule(string sRule)
        {
            DbProviderCms.GetInstance().NewsContent_UpdateAllRule(sRule, TableName);
        }

        public void MakeHtmlName(int ClassID, int SiteID)
        {
            List<Entity.NewsContent> lst = GetListNewOfNewsClass(ClassID, 0, false, false, "", SiteID);
            foreach (EbSite.Entity.NewsContent content in lst)
            {
                MakeHtmlName(content);
            }
        }
        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<EbSite.Entity.NewsContent> GetListArray(string strWhere, int iTop, string OrderBy, string Fields, int SiteID)
        {
            string CacheKey = string.Concat("GetListArray-", strWhere, iTop, OrderBy, "-", SiteID);
            List<EbSite.Entity.NewsContent> mlNewsContent = Host.CacheApp.GetCacheItem <List<Entity.NewsContent>>(CacheKey, cachecontent);//bllCache.GetCacheItem(rawKey) as List<EbSite.Entity.NewsContent>;
            if (mlNewsContent == null)
            {
                mlNewsContent = DbProviderCms.GetInstance().NewsContent_GetListArray(strWhere, iTop, OrderBy, Fields, SiteID, TableName);
                Host.CacheApp.AddCacheItem(CacheKey, mlNewsContent, cachetime, ETimeSpanModel.M, cachecontent);// bllCache.AddCacheItem(rawKey, mlNewsContent);
            }

            return mlNewsContent;
        }

        public List<EbSite.Entity.NewsContent> GetListArrayNoCache(string strWhere, int iTop, string OrderBy,
            string Fields, int SiteID)
        {
            return GetListArrayNoCache(strWhere, iTop, OrderBy, Fields, SiteID, true);
        }

        /// <summary>
        ///没有缓存 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<EbSite.Entity.NewsContent> GetListArrayNoCache(string strWhere, int iTop, string OrderBy, string Fields, int SiteID, bool? IsAuditing)
        {
            return DbProviderCms.GetInstance().NewsContent_GetListArray(strWhere, iTop, OrderBy, Fields, SiteID, TableName, IsAuditing);

        }
        /// <summary>
        /// 获取数据列表-开始ID结束ID
        /// </summary>
        /// <param name="iStarID">开始ID</param>
        /// <param name="iEndID">结束ID</param>
        /// <param name="iTop">获取记录条数，为0时全部记录</param>
        /// <returns></returns>
        public DataSet GetListOfStarIDEndID(int iStarID, int iEndID, int iTop, int SiteID)
        {
            string sWhere = string.Concat("id>", iStarID, " and id<", iEndID);
            return DbProviderCms.GetInstance().NewsContent_GetListDataSet(sWhere, iTop, "id desc", SiteID, TableName);
        }
        /// <summary>
        /// 获得数据列表-最新歌曲
        /// </summary>
        public List<EbSite.Entity.NewsContent> GetListNew(int iTop, int SiteID)
        {
            return GetListArray("", iTop, "id desc", "", SiteID);
        }
        public List<EbSite.Entity.NewsContent> GetListByUser(int iTop, int iUserID, string OrderBy, bool IsImg, int SiteID)
        {

            string sWhere = string.Format("userid={0}", iUserID);

            if (IsImg) sWhere = string.Concat(sWhere, " and  smallpic<>'' ", "");


            string sTop = "id desc";
            if (OrderBy == "w")
            {
                sTop = "weekhits desc";
            }
            else if (OrderBy == "adv")
            {
                sTop = "advs desc";
            }
            else if (OrderBy == "d")
            {
                sTop = "dayhits desc";
            }
            else if (OrderBy == "m")
            {
                sTop = "monthhits desc";
            }
            else if (OrderBy == "ch")
            {
                sTop = "commentnum desc";
            }
            else if (OrderBy == "fh")
            {
                sTop = "favorablenum desc";
            }
            else if (OrderBy == "h") //总排行
            {
                sTop = "hits desc";
            }


            return GetListArray(sWhere, iTop, sTop, "", SiteID);
        }

        /// <summary>
        /// 获得最新-分类ID
        /// </summary>
        /// <param name="iClassid">分类ID</param>
        /// <param name="iTop">获取多少条</param>
        /// <param name="IsGetSub">是否获取子分类下的内容</param>
        /// <returns></returns>
        public List<Entity.NewsContent> GetListNewOfNewsClass(int iClassid, int iTop, bool IsGetSub, bool IsImg, string Fields, int SiteID)
        {
            string sWhere = "";
            if (iClassid < 1)
            {
                sWhere = "";
            }
            else
            {
                if (!IsGetSub)
                {
                    sWhere = string.Concat(" ClassID =", iClassid, "  ");
                }
                else
                {


                    //很占用内存，有等优化
                    string SubIds = EbSite.BLL.NewsClass.GetSubIDs(iClassid, SiteID);
                    if (!string.IsNullOrEmpty(SubIds)) SubIds = string.Concat(",", SubIds);

                    sWhere = string.Concat(" ClassID in(", iClassid, SubIds, ")  ");
                }

            }

            if (IsImg)
            {
                if (!string.IsNullOrEmpty(sWhere)) sWhere = string.Concat(sWhere, " and ");
                sWhere = string.Concat(sWhere, "   smallpic<>'' ");
            }
            return GetListArray(sWhere, iTop, " id desc", Fields, SiteID);
            //return DbProviderCms.GetInstance().NewsContent_GetListArray(sWhere, iTop, " id desc", Fields);

        }
        /// <summary>
        /// 推荐内容
        /// </summary>
        /// <param name="iTop">top</param>
        /// <param name="classid">分类ID，分类id小于1，那么全部数据</param>
        /// <returns></returns>
        public List<EbSite.Entity.NewsContent> GetGoodList(int iTop, int classid, int SiteID)
        {
            return DbProviderCms.GetInstance().NewsContent_GetGoodList(iTop, classid.ToString(), SiteID, TableName);
        }

        /// <summary>
        /// 获得数据列表-推荐
        /// </summary>
        public List<EbSite.Entity.NewsContent> GetListGood(int iTop, int iClassid, bool IsGetSub, bool IsImg, string Fields, int SiteID)
        {
            string CacheKey = string.Concat("GetListGood-", iTop, "-", iClassid, IsGetSub, "-", SiteID);
            List<EbSite.Entity.NewsContent> mlNewsContent = Host.CacheApp.GetCacheItem<List<EbSite.Entity.NewsContent>>(CacheKey, cachecontent);//bllCache.GetCacheItem(rawKey) as List<EbSite.Entity.NewsContent>;
            if (mlNewsContent == null)
            {
                //string sWhere = " IsGood=1 ";

                //if (iClassid >0)
                //{
                //    if (!IsGetSub)
                //    {
                //        sWhere = string.Concat(sWhere, " ClassID =", iClassid);
                //    }
                //    else
                //    {
                //        //很占用内存，有等优化
                //        string SubIds = EbSite.BLL.NewsClass.GetSubIDs(iClassid);
                //        if (!string.IsNullOrEmpty(SubIds)) SubIds = string.Concat(",", SubIds);

                //        sWhere = string.Concat(sWhere, " and ClassID in(", iClassid, SubIds, ")");
                //    }
                //}
                //if (IsImg) sWhere = string.Concat(sWhere, " and  smallpic<>'' ");

                mlNewsContent = DbProviderCms.GetInstance().GetListGood(iTop, iClassid, IsGetSub, IsImg, Fields, SiteID, TableName); ;

                Host.CacheApp.AddCacheItem(CacheKey, mlNewsContent, cachetime, ETimeSpanModel.M, cachecontent);
                
            }

            return mlNewsContent;
        }


        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<EbSite.Entity.NewsContent> GetListPages(int PageIndex, int PageSize, out int Count, int SiteID)
        {
            return DbProviderCms.GetInstance().NewsContent_GetListPages(PageIndex, PageSize, "", "", true, false, out Count, SiteID, TableName);
        }
        public List<EbSite.Entity.NewsContent> GetListPages(int PageIndex, int PageSize, string sWhere, out int Count, int SiteID)
        {
            return GetListPages(PageIndex, PageSize, sWhere, out Count, true, SiteID);
        }

        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<EbSite.Entity.NewsContent> GetListPages(int PageIndex, int PageSize, string sWhere, out int Count, bool? IsAllow, int SiteID)
        {

            return DbProviderCms.GetInstance().NewsContent_GetListPages(PageIndex, PageSize, sWhere, "id desc", IsAllow, false, out Count, SiteID, TableName);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<EbSite.Entity.NewsContent> GetListPages(int PageIndex, int PageSize, string sWhere, string orderby, out int Count, bool? IsAllow, int SiteID)
        {

            return DbProviderCms.GetInstance().NewsContent_GetListPages(PageIndex, PageSize, sWhere, orderby, IsAllow, false, out Count, SiteID, TableName);
        }
        /// <summary>
        /// 获得数据列表-分页根据分类ID
        /// </summary>
        public List<EbSite.Entity.NewsContent> GetListPagesOFClass(int PageSize, int PageCount, int iSclass, out int Count, int SiteID, int OrderBy)
        {
            return GetListPagesOFClass(PageSize, PageCount, iSclass, OrderBy, out Count, SiteID);
        }

        public List<Entity.NewsContent> GetListPages(int PageIndex, int PageSize, out int RecordCount, int iSpecialID, int iClassID, int iOrderByID, int SiteID, string OutWhere,int iAddDataToSpecialByID)
        {
            string sWhere = "";
            string sOrderBy = "NumberTime desc";
            bool IsAud = true;
            bool IsGood = false; //默认获取全部

            if (iSpecialID > 0) //查看某个专题下的记录
            {
                sWhere = DbProviderCms.GetInstance().GetContentsFromSpecialIDSqlWhere(iSpecialID, TableName);
                //string newsids = BLL.SpecialNews.GetNewsIDBySid(iSpecialID);
                //if (!string.IsNullOrEmpty(newsids))
                //{
                //    sWhere = " ID in( " + newsids + ")";


                //}
                //else
                //{
                //    sWhere = "ID in(0)";
                //}
            }
            else
            {
                if (iClassID > 0)
                {
                    sWhere = string.Format("ClassID={0}", iClassID);
                }
            }

            if (!string.IsNullOrEmpty(OutWhere))
            {
                if (!string.IsNullOrEmpty(sWhere))
                {
                    sWhere = string.Concat(OutWhere, " and ", OutWhere);
                }
                else
                {
                    sWhere = OutWhere;
                }
            }

             

            switch (iOrderByID)
            {
                case 0:  //已审核

                    IsAud = true;

                    break;
                case 1: //未审核
                    IsAud = false;
                    break;
                case 2: //推荐
                    IsGood = true;
                    break;
                case 3: //总排行
                    sOrderBy = "hits desc";
                    break;
                case 4: //日排行
                    sOrderBy = "dayhits desc";
                    break;
                case 5: //周排行
                    sOrderBy = "weekhits desc";
                    break;
                case 6://月排行
                    sOrderBy = "monthhits desc";
                    break;
                case 7://收藏最多
                    sOrderBy = "Advs desc";
                    break;
                case 8://好评最多
                    sOrderBy = "favorablenum desc";
                    break;
                case 9://好评最多
                    sOrderBy = "commentnum desc";
                    break;
            }
            //Log.Factory.GetInstance().InfoLog(sOrderBy);
            return DbProviderCms.GetInstance().NewsContent_GetListPages(PageIndex, PageSize, sWhere, "", sOrderBy, IsAud, IsGood, out RecordCount, SiteID, TableName, iAddDataToSpecialByID);
        }


        /// <summary>
        /// list.aspx页面用的分页办法
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="iSclass"></param>
        /// <param name="OrderBy"></param>
        /// <returns></returns>
        public List<EbSite.Entity.NewsContent> GetListForListPage(int PageIndex, int PageSize, int iSclass, int OrderBy, out int Count, int SiteID, HttpContext context)
        {
           
            //搜索前触发的事件
            ClassListLaodingEventArgs Args = new ClassListLaodingEventArgs(iSclass, "", context, SiteID, "");
            Base.EBSiteEvents.OnClassListLoading(null, Args);
            List<EbSite.Entity.NewsContent> list = new List<Entity.NewsContent>();
            if (string.IsNullOrEmpty(Args.Where) && string.IsNullOrEmpty(Args.OrderBy))
            {
                Count = GetCountOfClassid(iSclass, SiteID);//是不是多余的

                if (Count > 0)
                {
                    int iCount = 0;
                    list = GetListPagesOFClass(PageIndex, PageSize, iSclass, out iCount, SiteID, OrderBy);
                }
                else  //调用子分类数据
                {
                    string sWhere = string.Empty;
                    //很占用内存，有等优化
                    if (iSclass > 0)
                    {
                        //string SubIds = EbSite.BLL.NewsClass.GetSubIDs(iSclass, SiteID);
                        string SubIds = "";
                        List<EbSite.Entity.NewsClass> SubList = EbSite.BLL.NewsClass.GetSubIDs(iSclass, SiteID, out SubIds);

                        if (!string.IsNullOrEmpty(SubIds))
                        {
                            sWhere = string.Concat("  ClassID in(", SubIds, ")");

                            Count = GetCount(sWhere, SiteID);

                            if (Count > 0)
                            {
                                int iOutCount = 0; //暂时没用到
                                list = GetListPagesOFClass(PageIndex, PageSize, iSclass, OrderBy, sWhere, out iOutCount,
                                                           SiteID);
                            }
                        }
                    }
                    else
                    {
                        Count = GetCount(sWhere, SiteID);

                        if (Count > 0)
                        {
                            int iOutCount = 0; //暂时没用到
                            list = GetListPagesOFClass(PageIndex, PageSize, iSclass, OrderBy, sWhere, out iOutCount,
                                                       SiteID);
                        }
                    }


                }
            }
            else
            {
                //Count = BLL.NewsContent.GetCount(Args.Where, SiteID);
                //int PageIndex, int PageSize, string sWhere, out int Count, bool IsAllow, int SiteID
                // list = GetListPages(PageIndex, PageSize, Args.Where, out Count, true, SiteID);
                if (!string.IsNullOrEmpty(Args.OrderBy))
                    list = GetListPages(PageIndex, PageSize, Args.Where, Args.OrderBy, out Count, true, SiteID);
                else
                    list = GetListPages(PageIndex, PageSize, Args.Where, out Count, true, SiteID);
            }

            return list;
        }
        public List<EbSite.Entity.NewsContent> GetListPagesOFClass(int PageIndex, int PageSize, int iSclass, int OrderBy, out int Count, int SiteID)
        {
            string sWhere = "";
            if (iSclass > 0)
            {
                sWhere = string.Concat("ClassID=", iSclass);
            }
            return GetListPagesOFClass(PageIndex, PageSize, iSclass, OrderBy, sWhere, out Count, SiteID);
        }
        private List<EbSite.Entity.NewsContent> GetListPagesOFClass(int PageIndex, int PageSize, int iSclass, int OrderBy, string Where, out int Count, int SiteID)
        {
            return GetListPagesOFClass(PageIndex, PageSize, iSclass, OrderBy, Where, out Count, SiteID, "");
        }

        /// <summary>
        /// 获得数据列表-分页根据分类ID
        /// </summary>
        /// <param name="PageSize">当前页码</param>
        /// <param name="PageCount">每页显示多少条</param>
        /// <param name="iSclass">分类id</param>
        /// <param name="OrderBy">排序，0默认按ID排序，1按点击率排序，2按收藏排序，3按评论数排序，4好评或星级或顶一下排序，5按发布日期排序</param>
        /// <returns></returns>
        private List<EbSite.Entity.NewsContent> GetListPagesOFClass(int PageIndex, int PageSize, int iSclass, int OrderBy, string Where, out int Count, int SiteID, string OtherOrderby)
        {
            string sOrderBy = "ID desc"; //默认ID排序
            if (string.IsNullOrEmpty(OtherOrderby))
            {
                if (OrderBy == 1) //点击率排序
                {
                    sOrderBy = "Hits DESC";
                }
                else if (OrderBy == 2) //收藏排序
                {
                    sOrderBy = "Advs DESC";
                }
                else if (OrderBy == 3) //评论数排序
                {
                    sOrderBy = "CommentNum DESC";
                }
                else if (OrderBy == 4) //好评或星级或顶一下排序
                {
                    sOrderBy = "FavorableNum DESC";
                }
                else if (OrderBy == 5) //发布日期排序
                {
                    sOrderBy = "NumberTime DESC";
                }
            }
            else
            {
                sOrderBy = OtherOrderby;
            }



            return DbProviderCms.GetInstance().NewsContent_GetListPages(PageIndex, PageSize, Where, sOrderBy, true, false, out Count, SiteID, TableName);
        }
        /// <summary>
        /// 获取某个专题的数据-分页
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <param name="SpecialClassID"></param>
        /// <returns></returns>
        public List<EbSite.Entity.NewsContent> GetListPagesFromSpecialID(int PageIndex, int PageSize, int SpecialClassID, out int Count, int SiteID)
        {

            return DbProviderCms.GetInstance().NewsContent_GetListPagesFromSpecialID(PageIndex, PageSize, SpecialClassID, out Count, SiteID); ;
        }
        /// <summary>
        /// 获取某个专题的数据
        /// </summary>
        /// <param name="SpecialClassID"></param>
        /// <returns></returns>
        public List<EbSite.Entity.NewsContent> GetListFromSpecialID(int SpecialClassID, int top, bool IsGetSub, int SiteID)
        {
            return DbProviderCms.GetInstance().NewsContent_GetListFromSpecialID(SpecialClassID, top, IsGetSub, SiteID);
        }
        /// <summary>
        /// 获得数据列表-某个用户收藏的记录
        /// </summary>
        public List<EbSite.Entity.NewsContent> GetListByUserFav(string sUserName, int PageIndex, int PageSize, out int Count, int SiteID)
        {

            string sIDs = Favorite.GetContentIDsByUserName(sUserName);
            if (!string.IsNullOrEmpty(sIDs))
            {
                string sWhere = string.Concat(" id in(", sIDs, ")");
                return DbProviderCms.GetInstance().NewsContent_GetListPages(PageIndex, PageSize, sWhere, "", true, false, out Count, SiteID, TableName);
            }
            else
            {
                Count = 0;
                return null;

            }

        }
        public int GetCountByUser(int UserId, int ClassID, bool IsAuditing, int SiteID)
        {
            int iCount = 0;
            if (UserId>0)
            {
                StringBuilder sWhere = new StringBuilder();

                sWhere.AppendFormat("UserID={0}", UserId);

                if (ClassID > 0)
                {
                    sWhere.AppendFormat(" and classid={0}", ClassID);
                }


                iCount = DbProviderCms.GetInstance().NewsContent_GetCount(sWhere.ToString(), IsAuditing ? 1 : 0, SiteID, TableName);
            }

            return iCount;
        }
        public int GetCountByUser(string sUserName, int ClassID, bool IsAuditing, int SiteID)
        {
            int iCount = 0;
            if (!string.IsNullOrEmpty(sUserName))
            {
                StringBuilder sWhere = new StringBuilder();

                sWhere.AppendFormat("username='{0}'", sUserName);

                if (ClassID > 0)
                {
                    sWhere.AppendFormat(" and classid={0}", ClassID);
                }


                iCount = DbProviderCms.GetInstance().NewsContent_GetCount(sWhere.ToString(), IsAuditing ? 1 : 0, SiteID, TableName);
            }

            return iCount;
        }

        public List<EbSite.Entity.NewsContent> GetListPagesOFUser(int PageIndex, int PageSize, int UserID, out int Count, string OrderBy, int SiteID)
        {
            return GetListPagesOFClass(PageIndex, PageSize, string.Concat("UserID=", UserID), out Count, OrderBy, SiteID);
        }

        /// <summary>
        /// 获取某个用户添加的内容-分页
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public List<EbSite.Entity.NewsContent> GetListPagesOFUser(int PageIndex, int PageSize, string UserName, int ClassID, out int Count, string OrderBy, int SiteID)
        {
            List<EbSite.Entity.NewsContent> lst = new List<EbSite.Entity.NewsContent>();
            if (!string.IsNullOrEmpty(UserName))
            {
                string sWhere = string.Concat("username='", UserName, "'");

                if (ClassID > 0)
                {
                    sWhere += string.Concat(" and classid=", ClassID);
                }

                lst = GetListPagesOFClass(PageIndex, PageSize, sWhere, out Count, OrderBy, SiteID);
            }
            else
            {
                Count = 0;
            }

            return lst;
        }
        public List<EbSite.Entity.NewsContent> GetListPagesOFUser(int PageIndex, int PageSize, string UserName, int ClassID, out int Count, int SiteID)
        {
            return GetListPagesOFUser(PageIndex, PageSize, UserName, ClassID, out Count, "", SiteID);
        }

        public void AddClassFormClassName(int SiteID)
        {
            List<EbSite.Entity.NewsContent> lst = GetListArray("classid=0", 0, "", "", SiteID);
            foreach (Entity.NewsContent content in lst)
            {
                string sClassName = content.ClassName.Trim();

                List<Entity.NewsClass> cLst = NewsClass.GetListArr(string.Format("ClassName='{0}'", sClassName), SiteID);

                int classid = 0;
                if (cLst.Count > 0)
                {
                    classid = cLst[0].ID;
                }
                else
                {
                    Entity.NewsClass mdC = new Entity.NewsClass();
                    mdC.ClassName = sClassName;
                    classid = NewsClass.Add(mdC, SiteID);

                    //classid = NewsClass.Add(nc, SiteID);

                }
                content.ClassID = classid;
                Update(content);


            }
            //string sClassName = lst

        }
        public List<EbSite.Entity.NewsContent> GetListPagesOFClass(int PageIndex, int PageSize, string sWhere, out int Count, int SiteID)
        {
            return GetListPagesOFClass(PageIndex, PageSize, sWhere, out Count, "", SiteID);
        }

        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<EbSite.Entity.NewsContent> GetListPagesOFClass(int PageIndex, int PageSize, string sWhere, out int Count, string Orderby, int SiteID)
        {
            return DbProviderCms.GetInstance().NewsContentUn_GetListPages(PageIndex, PageSize, sWhere, "", true, false, out Count, SiteID, BLL.DataSettings.Content.Instance.GetConfigCurrent.ContentTables, Orderby);
        }

        /// <summary>
        /// 分页获取数据列表-指定音乐家族ID
        /// </summary>
        public List<EbSite.Entity.NewsContent> GetListPagesFromTagName(int PageIndex, int PageSize, string tag, out int Count, int SiteID)
        {

            int TagID = DbProviderCms.GetInstance().TagKey_GetTagIDByName(tag);
            return DbProviderCms.GetInstance().NewsContent_GetListPagesFromTagID(PageIndex, PageSize, TagID, out Count, SiteID);

        }

        /// <summary>
        /// 分页获取数据列表-指定标签ID
        /// </summary>
        public List<EbSite.Entity.NewsContent> GetListPagesFromTagID(int PageIndex, int PageSize, int tagID, out int Count, int SiteID)
        {

            return DbProviderCms.GetInstance().NewsContent_GetListPagesFromTagID(PageIndex, PageSize, tagID, out  Count, SiteID);
        }
        /// <summary>
        /// 获取某个标签对应下的内容记录数
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public int GetCountByTagID(int tid, int SiteID)
        {
            return DbProviderCms.GetInstance().NewsContent_GetCountByTagID(tid, SiteID, TableName);
        }

        /// <summary>
        /// 获得数据列表-排行榜 
        /// </summary>
        /// <param name="iClassID"></param>
        /// <param name="iTop"></param>
        /// <param name="OrderBy">为空,总点击排行榜，adv收藏排行,d今日点击排行,w本周点击排行，m本月点击排行，ch按评论最多排行，fh按好评(被顶)最多排行,n按好评(被顶)最多排行</param>
        /// <param name="IsGetSub"></param>
        /// <param name="IsImg"></param>
        /// <returns></returns>
        public List<EbSite.Entity.NewsContent> GetListHot(int iClassID, int iTop, string OrderBy, bool IsGetSub, bool IsImg, string Fields, int SiteID)
        {
            string sWhere = "";
            if (iClassID > 0)
            {


                if (!IsGetSub)
                {
                    sWhere = string.Concat("  ClassID =", iClassID);

                }
                else
                {
                    //很占用内存，有等优化
                    string SubIds = EbSite.BLL.NewsClass.GetSubIDs(iClassID, SiteID);
                    if (!string.IsNullOrEmpty(SubIds)) SubIds = string.Concat(",", SubIds);

                    sWhere = string.Concat("  ClassID in(", iClassID, SubIds, ")");

                }
                if (IsImg) sWhere = string.Concat(sWhere, " and  smallpic<>'' ", "");

            }


            string sTop = "hits desc";
            if (OrderBy == "w")
            {
                sTop = "weekhits desc";
            }
            else if (OrderBy == "adv")
            {
                sTop = "advs desc";
            }
            else if (OrderBy == "d")
            {
                sTop = "dayhits desc";
            }
            else if (OrderBy == "m")
            {
                sTop = "monthhits desc";
            }
            else if (OrderBy == "ch")
            {
                sTop = "commentnum desc";
            }
            else if (OrderBy == "fh")
            {
                sTop = "favorablenum desc";
            }
            else if (OrderBy == "n")
            {
                sTop = "id desc";
            }
            return GetListArray(sWhere, iTop, sTop, Fields, SiteID);

        }

        /// <summary>
        /// 获得数据列表-排行榜 
        /// </summary>
        /// <param name="iClassID"></param>
        /// <param name="iTop"></param>
        /// <param name="OrderBy">为空,总点击排行榜，adv收藏排行,d今日点击排行,w本周点击排行，m本月点击排行，ch按评论最多排行，fh按好评(被顶)最多排行</param>
        /// <param name="IsGetSub"></param>
        /// <param name="IsImg"></param>
        /// <returns></returns>
        public List<EbSite.Entity.NewsContent> GetListHotByKeyWord(string sKeyWord, int iTop, string OrderBy, bool IsImg, string Fields, int SiteID)
        {
            string sWhere = "";
            if (!string.IsNullOrEmpty(sKeyWord))
            {
                sWhere = string.Format("  newstitle  like '%{0}%' ", sKeyWord);
                if (IsImg) sWhere = string.Concat(sWhere, " and  smallpic<>'' ", "");

            }


            string sTop = "id desc";
            if (OrderBy == "w")
            {
                sTop = "weekhits desc";
            }
            else if (OrderBy == "adv")
            {
                sTop = "advs desc";
            }
            else if (OrderBy == "d")
            {
                sTop = "dayhits desc";
            }
            else if (OrderBy == "m")
            {
                sTop = "monthhits desc";
            }
            else if (OrderBy == "ch")
            {
                sTop = "commentnum desc";
            }
            else if (OrderBy == "fh")
            {
                sTop = "favorablenum desc";
            }
            else if (OrderBy == "h") //总排行
            {
                sTop = "hits desc";
            }

            return Un_GetListArray(sWhere, iTop, sTop, Fields, SiteID, BLL.DataSettings.Content.Instance.GetConfigCurrent.ContentTables);

        }


        /// <summary>
        ///  获得数据列表-根据歌手ID -分页
        /// </summary>
        public List<EbSite.Entity.NewsContent> GetListOfClassID(int PageIndex, int PageSize, int iClassID, out int Count, int SiteID)
        {
            return DbProviderCms.GetInstance().NewsContent_GetListPages(PageIndex, PageSize, string.Concat(" NewsClassID=", iClassID), "ID", true, false, out Count, SiteID, TableName);
        }

        /// <summary>
        /// 获取列表（根据classid,userid mh add）
        /// </summary>
        public List<EbSite.Entity.NewsContent> GetListOfClassID(int PageIndex, int PageSize, int iClassID, out int Count, int SiteID, int UserID)
        {
            string sqlStr = " ClassID={0} AND UserID={1} ";
            sqlStr = string.Format(sqlStr, iClassID, UserID);

            return DbProviderCms.GetInstance().NewsContent_GetListPages(PageIndex, PageSize, sqlStr, "ID", true, false, out Count, SiteID, TableName);
        }
        /// <summary>
        /// 获取所有未通过审核的内容
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        public List<EbSite.Entity.NewsContent> GetListNoAllow(int PageIndex, int PageSize, out int Count, int SiteID)
        {

            //Count = DbProviderCms.GetInstance().NewsContent_GetCount("", 0); ;//GetCount("IsAuditing=0");
            return DbProviderCms.GetInstance().NewsContent_GetListPages(PageIndex, PageSize, "", "", false, false, out Count, SiteID, TableName);
        }



        /// <summary>
        /// 获得数据列表-相关数据
        /// </summary>
        public List<EbSite.Entity.NewsContent> GetTagRelate(int top, int ContentId, string sFields, int SiteID)
        {
            return DbProviderCms.GetInstance().NewsContent_GetTagRelate(top, ContentId, sFields, SiteID, TableName);

        }

        public static string DefualtFileds = "id,newstitle,addtime,HtmlName,ClassName,classid,UserID,UserNiName,UserName,ContentInfo";
        /// <summary>
        /// 搜索-模糊匹配
        /// </summary>
        public List<EbSite.Entity.NewsContent> SearchContent(int PageIndex, int PageSize, string sKey, out int RecordCount, HttpContext context, int SiteID, out long time)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string sWhere = string.Concat(" newstitle like '%", sKey, "%' or classname = '", sKey, "' ");

            //搜索前触发的事件
            SearchEventArgs Args = new SearchEventArgs(sKey, sWhere, context, SiteID);
            Base.EBSiteEvents.OnSearching(null, Args);
            if (!string.IsNullOrEmpty(Args.Where)) //当外面传进来的事件为空时，将不搜索
            {
                sWhere = Args.Where;
                string Fields = DefualtFileds;
                //if (!string.IsNullOrEmpty(Base.Configs.SysConfigs.ConfigsControl.Instance.ContentFileds_So))
                //{
                //    Fields = string.Concat(Fields, ",", Base.Configs.SysConfigs.ConfigsControl.Instance.ContentFileds_So);
                //}
                if (!string.IsNullOrEmpty(BLL.DataSettings.Content.Instance.GetConfigCurrent.SearchFileds_So))
                {
                    //yhl 2014-2-7 查询字段有重复 联合查询报错
                    // Fields = string.Concat(Fields, ",", BLL.DataSettings.Content.Instance.GetConfigCurrent.SearchFileds_So);
                    Fields = string.Concat("id", ",", BLL.DataSettings.Content.Instance.GetConfigCurrent.SearchFileds_So);
                }

                string CacheKey = string.Concat(sWhere, PageIndex);
                string rawKeyCount = string.Concat("C-", CacheKey);
                int iRecordCount = -1;
                List<EbSite.Entity.NewsContent> mlNewsContent = Host.CacheApp.GetCacheItem<List<EbSite.Entity.NewsContent>>(CacheKey, cachecontent);// bllCache.GetCacheItem(rawKey) as List<EbSite.Entity.NewsContent>;
                if (mlNewsContent == null)
                {
                    //YHL 2014-2-4 当前可以搜索的表，在后台设置
                    Entity.DataSettingInfoForContent cf = BLL.DataSettings.Content.Instance.GetConfigCurrent;
                    mlNewsContent = DbProviderCms.GetInstance().NewsContentUn_GetListPages(PageIndex, PageSize, sWhere, Fields, true, false, out RecordCount, SiteID, cf.ContentTables, "");

                    //  mlNewsContent = DbProviderCms.GetInstance().NewsContent_GetListPages(PageIndex, PageSize, sWhere, Fields, "hits desc ", true, false, out RecordCount, SiteID, TableName);

                    Host.CacheApp.AddCacheItem(CacheKey, mlNewsContent, cachetime, ETimeSpanModel.M, cachecontent);
                    Host.CacheApp.AddCacheItem(rawKeyCount, RecordCount, cachetime, ETimeSpanModel.M, cachecontent);

                    //bllCache.AddCacheItem(rawKey, mlNewsContent);
                   // bllCache.AddCacheItem(rawKeyCount, RecordCount.ToString());
                }
                if (iRecordCount == -1)
                {
                    string sCount = Host.CacheApp.GetCacheItem<string>(rawKeyCount, cachecontent);//bllCache.GetCacheItem(rawKeyCount) as string;
                    if (!string.IsNullOrEmpty(sCount))
                    {
                        RecordCount = int.Parse(sCount);
                    }
                    else
                    {
                        RecordCount = GetCount(sWhere, SiteID);
                    }
                }
                else
                {
                    RecordCount = iRecordCount;
                }
                sw.Stop();
                time = sw.ElapsedMilliseconds;
                return mlNewsContent;
            }
            else
            {
                RecordCount = 0;
                sw.Stop();
                time = sw.ElapsedMilliseconds;
                return null;
            }


        }

        public int GetCountSearchByKey(string sKey, int SiteID)
        {
            //string sWhere = string.Format(" newstitle like '{0}%' or newstitle='{0}' or classname = '{0}'  ", sKey);

            string sWhere = string.Concat(" newstitle like '%", sKey, "%' ");
            string CacheKey = string.Concat("GetCount", sWhere);
            string iCount = Host.CacheApp.GetCacheItem<string>(CacheKey, cachecontent);//bllCache.GetCacheItem(rawKey) as string;
            if (iCount == null)
            {
                iCount = GetCount(sWhere, SiteID).ToString();
                Host.CacheApp.AddCacheItem(CacheKey, iCount, cachetime, ETimeSpanModel.M, cachecontent);
                //bllCache.AddCacheItem(rawKey, iCount);
            }
            return int.Parse(iCount);
        }

        public int GetCount(string strWhere, int SiteID)
        {

            return DbProviderCms.GetInstance().NewsContent_GetCount(strWhere, 1, SiteID, TableName);
        }
        /// <summary>
        /// 通过审核
        /// </summary>
        /// <param name="ID"></param>
        public void AllowContent(int ID, int SiteID)
        {
            Entity.NewsContent model = GetModel(ID, SiteID);

            model.IsAuditing = true;

            Update(model);
            //yhl 2013-08-15 2014-3-20
            AllowContentEventArgs Args = new AllowContentEventArgs(ID,model.ClassID,SiteID);
            Base.EBSiteEvents.OnAllowContent(null, Args);

        }
        /// <summary>
        /// 获取记录总数-根据分类ID
        /// </summary>
        /// <param name="singerid"></param>
        /// <returns></returns>
        public int GetCountOfClassid(int singerid, int SiteID)
        {
            if (singerid == 0)
            {
                return GetCount("", SiteID);
            }
            return GetCount(string.Concat(" classid=", singerid), SiteID);
        }
        /// <summary>
        /// 推荐歌曲或取消推荐歌曲
        /// </summary>
        /// <param name="iID"></param>
        public void UploadIsGood(int iID)
        {
            DbProviderCms.GetInstance().NewsContent_UploadIsGood(iID, TableName);
        }
        //static public void ContentToDefault()
        //{
        //    EbSite.Entity.NewsContent model = new Entity.NewsContent();


        //    model.IsGood = false;
        //    model.TagIDs = "";
        //    model.IsComment = true;
        //    model.IsAuditing = true;
        //    //model.ContentTemID = new Guid("89bd5515-638e-4187-b865-293549fc3a44");
        //    model.Advs = 0;
        //    model.CommentNum = 0;
        //    model.FavorableNum = 0;
        //    model.UserID = 1;
        //    model.UserNiName = Base.Configs.BaseCinfigs.ConfigsControl.Instance.FounderuID;
        //    model.UserName = Base.Configs.BaseCinfigs.ConfigsControl.Instance.FounderuID;
        //    model.SiteID = 0;

        //    DbProviderCms.GetInstance().NewsContent_ToDefault(model);
        //}
        public void ContentInitNum(int itype, int SiteID)
        {
            DbProviderCms.GetInstance().NewsContent_InitNum(itype, SiteID, TableName);
        }
        public void ContentInitClassName(int SiteID)
        {
            DbProviderCms.GetInstance().NewsContent_InitClassName(SiteID, TableName);
        }



        //public static void UpdateConfigsofContent(int iClassID, Guid ContentModelID, Guid ContentTemID, bool IsUpdateToSub, int SiteID)
        //{
        //    DbProviderCms.GetInstance().UpdateConfigsofContent(iClassID, ContentModelID, ContentTemID, IsUpdateToSub, SiteID);
        //}

        #endregion  成员方法
        /// <summary>
        /// 批量删除，多个用逗号分开
        /// </summary>
        /// <param name="IDS"></param>
        public void Delete(string IDS)
        {
            DbProviderCms.GetInstance().NewsContent_Delete(IDS, TableName);
        }

        /// <summary>
        /// 生成rss
        /// </summary>
        /// <param name="itop">获取记录条数</param>
        /// <param name="itype">数据类别，0为排行，1为推荐,2为最新</param>
        /// <param name="iclassid">分类ID，0为所有分类</param>
        /// <returns></returns>
        public string GetRss(int itop, int itype, int iclassid, int SiteID)
        {
            List<EbSite.Entity.NewsContent> lstContent = new List<Entity.NewsContent>();

            RssBuilder rss = new RssBuilder();
            rss.channel.Title = Base.Host.Instance.MainSite.SiteName;
            rss.channel.Link = Base.Host.Instance.MainSite.SiteName;
            rss.channel.Description = Base.Host.Instance.MainSite.SiteName;

            if (itype == 0) //排行
            {
                lstContent = GetListHot(iclassid, itop, "id", false, false, "id,newstitle,contentinfo,HtmlName,ClassID", SiteID);
            }
            else if (itype == 1)//推荐
            {
                lstContent = GetGoodList(itop, iclassid, SiteID);
            }
            else if (itype == 2)//最新
            {
                lstContent = GetListNewOfNewsClass(iclassid, itop, false, false, "id,newstitle,contentinfo,HtmlName,ClassID", SiteID);
            }

            foreach (Entity.NewsContent newsContent in lstContent)
            {
                RssItem item = new RssItem();
                item.Title = newsContent.NewsTitle;
                item.Link = string.Concat(Base.AppStartInit.DomainName,Base.Host.Instance.GetContentLink(newsContent.ID, newsContent.HtmlName, newsContent.ClassID));
                item.Description = Core.Strings.GetString.GetSubString(newsContent.ContentInfo, 100, "...");

                rss.channel.Items.Add(item);
            }

            return rss.OutXml;
        }

        /// <summary>
        /// 获取今天添加内容数
        /// </summary>
        public int GetCountByToday(int SiteID)
        {
            return DbProviderCms.GetInstance().NewsContent_GetCount("d", -1, SiteID, TableName);
        }
        /// <summary>
        /// 获取本周添加内容数
        /// </summary>
        public int GetCountByWeek(int SiteID)
        {
            return DbProviderCms.GetInstance().NewsContent_GetCount("w", -1, SiteID, TableName);
        }
        /// <summary>
        /// 获取本月添加内容数
        /// </summary>
        public int GetCountByMonth(int SiteID)
        {

            return DbProviderCms.GetInstance().NewsContent_GetCount("m", -1, SiteID, TableName);

        }
        /// <summary>
        /// 获取本季添加内容数
        /// </summary>
        public int GetCountByQuarter(int SiteID)
        {

            return DbProviderCms.GetInstance().NewsContent_GetCount("q", -1, SiteID, TableName);

        }
        /// <summary>
        /// 获取本年添加内容数
        /// </summary>
        public int GetCountByYear(int SiteID)
        {

            return DbProviderCms.GetInstance().NewsContent_GetCount("y", -1, SiteID, TableName);

        }
        /// <summary>
        /// 获取所有添加内容数
        /// </summary>
        public int GetCountAll(int SiteID)
        {

            return DbProviderCms.GetInstance().NewsContent_GetCount("", -1, SiteID, TableName);

        }


        #region 复制类内容 杨欢乐 2011-10-26
        public void GetCopyContent(int id, int SiteID)
        {

            Entity.NewsContent model = GetModel(id, SiteID);
            model.NewsTitle = "复制" + model.NewsTitle;
            model.hits = 0;//访问率(总)
            model.IsGood = false;
            model.dayHits = 0;//今日
            model.weekHits = 0;//访问率(本周)
            model.monthhits = 0;//访问率(本月)
            model.lasthitstime = DateTime.Now;
            model.TagIDs = "";
            model.AddTime = DateTime.Now;

            model.Advs = 0;//收藏 
            model.CommentNum = 0;//评论
            model.FavorableNum = 0; //好评 
            model.RandNum = Core.Utils.GetRandNum();
            model.NumberTime = Core.SqlDateTimeInt.GetSecond(model.AddTime);

            Add(model);

            //Entity.NewsContent NewModel = new Entity.NewsContent();


            //NewModel.SmallPic = model.SmallPic;

            //NewModel.TitleStyle = model.TitleStyle;
            //NewModel.ClassID = model.ClassID;

            //NewModel.ContentInfo = model.ContentInfo;

            //NewModel.OrderID = model.OrderID;
            //NewModel.HtmlName = model.HtmlName;
            //NewModel.ContentHtmlNameRule = model.ContentHtmlNameRule;
            //NewModel.MarkIsMakeHtml = model.MarkIsMakeHtml;
            //NewModel.IsComment = model.IsComment;

            //NewModel.IsAuditing = model.IsAuditing;
            //NewModel.Annex1 = model.Annex1;
            //NewModel.Annex2 = model.Annex2;
            //NewModel.Annex3 = model.Annex3;
            //NewModel.Annex4 = model.Annex4;
            //NewModel.Annex5 = model.Annex5;
            //NewModel.Annex6 = model.Annex6;
            //NewModel.Annex7 = model.Annex7;
            //NewModel.Annex8 = model.Annex8;
            //NewModel.Annex9 = model.Annex9;
            //NewModel.Annex10 = model.Annex10;

            //NewModel.Annex11 = model.Annex11;
            //NewModel.Annex12 = model.Annex12;
            //NewModel.Annex13 = model.Annex13;
            //NewModel.Annex14 = model.Annex14;
            //NewModel.Annex15 = model.Annex15;
            //NewModel.Annex16 = model.Annex16;
            //NewModel.Annex17 = model.Annex17;
            //NewModel.Annex18 = model.Annex18;

            //NewModel.Annex19 = model.Annex19;
            //NewModel.Annex20 = model.Annex20;
            //NewModel.Annex21 = model.Annex21;
            //NewModel.Annex22 = model.Annex22;
            //NewModel.Annex23 = model.Annex23;
            //NewModel.Annex24 = model.Annex24;
            //NewModel.Annex25 = model.Annex25;


            //NewModel.ContentTemID = model.ContentTemID;
            //model.Advs = 0;//收藏
            ////NewModel.ClassName = model.ClassName;
            //model.CommentNum = 0;//评论
            //model.FavorableNum = 0; //好评
            ////NewModel.UserID = model.UserID;
            ////NewModel.UserNiName = model.UserNiName;
            ////NewModel.UserName = model.UserName;
            ////NewModel.SiteID = model.SiteID;
            //model.RandNum = Core.Utils.GetRandNum();
            //model.NumberTime = Core.SqlDateTimeInt.GetSecond(model.AddTime);

            //Add(model);


        }
        #endregion
        /// <summary>
        /// 喜欢一条记录或不喜欢一条记录
        /// </summary>
        /// <param name="contentid">内容ID</param>
        /// <param name="itype">0,为不喜欢，1为喜欢</param>
        public void LikeOrNo(int contentid, int itype)
        {
            DbProviderCms.GetInstance().NewsContent_LikeOrNo(contentid, itype, TableName);
        }

        #region 欢乐 2013-01-10
        //public EbSite.Entity.NewsContent GetModel(string sField, string strWhere)
        //{
        //    return GetModelByFiledOfDefault(sField, strWhere);
        //}
        /// <summary>
        /// 得到一个对象实体，从缓存中。 只查自带字段
        /// </summary>
        public Entity.NewsContent GetModelByFiledOfDefault(string sField, string strWhere)
        {
            string CacheKey = "GetModel-" + sField + strWhere;
            Entity.NewsContent model = Host.CacheApp.GetCacheItem<Entity.NewsContent>(CacheKey, cachecontent);// bllCache.GetCacheItem(CacheKey) as Entity.NewsContent;
            if (model == null)
            {
                model = DbProviderCms.GetInstance().NewsContent_GetModel(sField, strWhere, TableName, 0);

                GetContentEntityEventArgs Args = new GetContentEntityEventArgs(model);
                Base.EBSiteEvents.OnGetContentEntityed(model, Args);

                if (!Equals(model, null))
                    Host.CacheApp.AddCacheItem(CacheKey, model, cachetime, ETimeSpanModel.M, cachecontent);//bllCache.AddCacheItem(CacheKey, model);
            }

            return model;
        }
        public Entity.NewsContent GetModelByCache(long id, int SiteID)
        {
            string CacheKey = string.Concat("GetModelByCache-", id);
            Entity.NewsContent model = Host.CacheApp.GetCacheItem<Entity.NewsContent>(CacheKey, cachecontent);//bllCache.GetCacheItem(CacheKey) as Entity.NewsContent;
            if (model == null)
            {
                model = DbProviderCms.GetInstance().NewsContent_GetModel(id, TableName, SiteID);

                if (!Equals(model, null))
                    Host.CacheApp.AddCacheItem(CacheKey, model, cachetime, ETimeSpanModel.M, cachecontent); //bllCache.AddCacheItem(CacheKey, model);
            }

            return model;
        }
        #endregion
        /// <summary>
        /// 随机同一分下，相关问题 。
        /// </summary>
        /// <param name="IsHaveImg">是否只调用图片内容</param>
        /// <param name="top">调用多少</param>
        /// <param name="ClassId">指定分类Id</param>
        /// <param name="siteid">当前站点</param>
        /// <param name="NoInId">不包含当前内容Id</param>
        /// <returns></returns>
        public List<Entity.NewsContent> Get_Related(bool IsHaveImg, int top, int ClassId, int siteid,long NoInId)
        {
            return DbProviderCms.GetInstance().NewsContent_Related(IsHaveImg, top, ClassId,siteid, NoInId, TableName);
            //string cachekey = string.Concat("GetRelatedContent", bid, top);
            //DataSet ds = EbSite.Base.Host.CacheApp.GetCacheItem(cachekey) as DataSet;
            //if (Equals(ds, null))
            //{
            //    ds = DbProviderCms.GetInstance().NewsContent_Related(bid, top, count, siteid);
            //    EbSite.Base.Host.CacheApp.AddCacheItem(cachekey, ds);
            //}
            //return ds;
        }

        public void Update(string Where, string Col, string sValue)
        {

            DbProviderCms.GetInstance().NewsContent_Update(Where, Col, sValue, TableName);
            Host.CacheApp.InvalidateCache(cachecontent); //bllCache.InvalidateCache();
        }

        public void DeleteOutSiteData(string siteids)
        {
            DbProviderCms.GetInstance().DeleteNewsContentOutSiteData(siteids, TableName);
        }

        /// <summary>
        /// 事务更新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Trans"></param>
        public void Update(EbSite.Entity.NewsContent model, DbTransaction Trans)
        {
            DbProviderCms.GetInstance().NewsContent_Update(model, Trans, TableName);
        }

        ///// <summary>
        ///// 按内容模板 查出所有分类 进一步查出分类下的产品
        ///// </summary>
        ///// <param name="ContentTemIDs"></param>
        ///// <param name="Fields"></param>
        ///// <param name="SiteID"></param>
        ///// <returns></returns>
        //public List<Entity.NewsContent> AllList(Guid[] ContentTemIDs, string Fields, int SiteID)
        //{
        //    string classIds = "";
        //    string TemIDs = "";
        //    if (ContentTemIDs != null && ContentTemIDs.Length > 0)
        //    {
        //        foreach (Guid param in ContentTemIDs)
        //        {
        //            TemIDs += "'" + param + "',";
        //        }
        //        if (TemIDs.Length > 0)
        //            TemIDs = TemIDs.Remove(TemIDs.Length - 1, 1);

        //    }
        //    List<Entity.ClassConfigs> lsit = BLL.ClassConfigs.Instance.GetListArray("ContentTemID in(" + TemIDs + ")");
        //    foreach (var classConfigse in lsit)
        //    {
        //        classIds += classConfigse.ClassID + ",";
        //    }
        //    if (classIds.Length > 0)
        //        classIds = classIds.Remove(classIds.Length - 1, 1);

        //    if (classIds.Length > 0)
        //    {
        //        List<Entity.NewsContent> ls = GetListArray("classid in(" + classIds + ")", 0, "", Fields, SiteID);
        //        return ls;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        //2014-2-12 所有扩展表的集合
        public List<EbSite.Entity.NewsContent> Un_GetListArray(string strWhere, int iTop, string oderby, string Fileds,
                                                            int SiteID, string TableNames)
        {
            return DbProviderCms.GetInstance()
                                .NewsContentUn_GetListArray(strWhere, iTop, oderby, Fileds, SiteID, TableNames);
        }

        public List<string> GetContentTitles(string sHtml)
        {
           return EbSite.Core.Strings.GetString.RegexFinds("\\[eba\\](.*?)\\[/eba\\]", sHtml, 1);
        }
        public List<Entity.ContentPageInfo> GetPageInfos(string sContent, ref string ShowInfo, long ContentID, int ClassID, int PageIndex, EbSite.Base.ThemeType eThemeType)
        {
            List<Entity.ContentPageInfo> cp = new List<ContentPageInfo>();
            if (!string.IsNullOrEmpty(sContent))
            {
                //将一遍文章分割成多个章节
                string[] sArr = GetString.SplitString(sContent, AppStartInit.ContentPageSplit);

                if (PageIndex > -1)
                {
                    if (PageIndex < sArr.Length)
                    {
                        ShowInfo = sArr[PageIndex];
                    }
                }

                int iPageI = 0;
                foreach (string s in sArr)
                {
                    //string[] aTitle = GetString.GetArrByBR(s);// isHtml ? GetString.GetArrByBR(s) : GetString.GetArrByWrap(s);

                    List<string> lstTitle = GetContentTitles(s);
                    string sTitle = string.Empty;
                    if (lstTitle.Count > 0)
                    {
                        sTitle = lstTitle[0]; // GetString.ClearHtml(lstTitle[0]);
                    }
                    else
                    {
                        sTitle = "未设标题";
                    }

                    ContentPageInfo cpi = new ContentPageInfo();
                    if (eThemeType == ThemeType.PC)
                    {
                        cpi.Href = Host.Instance.GetContentLinkPage(ContentID, ClassID, iPageI);
                    }
                    else if (eThemeType == ThemeType.MOBILE)
                    {
                        cpi.Href = Host.Instance.MGetContentLink(ContentID, ClassID, iPageI);
                    }
                    cpi.Title = sTitle;

                    cpi.IsCurrent = iPageI == PageIndex;

                    cp.Add(cpi);
                    iPageI++;
                }

                //if (!string.IsNullOrEmpty(ShowInfo))
                //{
                //    ShowInfo = isHtml ? ShowInfo : UBB.UBBToHtml(ShowInfo);
                //}


            }

            return cp;

        }

        //public List<Entity.ContentPageInfo> GetPageInfos(string sContent, ref string ShowInfo, long ContentID, int ClassID, int PageIndex, EbSite.Base.ThemeType eThemeType,bool isHtml)
        //{
        //    List<Entity.ContentPageInfo> cp = new List<ContentPageInfo>();
        //    if (!string.IsNullOrEmpty(sContent))
        //    {
        //        string[] sArr =  GetString.SplitString(sContent, AppStartInit.ContentPageSplit);
        //        if (PageIndex > -1)
        //        {
        //            if (PageIndex < sArr.Length)
        //            {
        //                ShowInfo = sArr[PageIndex];
        //            }
        //        }

        //        int iPageI = 0;
        //        foreach (string s in sArr)
        //        {
        //            string[] aT = isHtml? GetString.GetArrByBR(s):GetString.GetArrByWrap(s);  


        //            ContentPageInfo cpi = new ContentPageInfo();
        //            if (eThemeType == ThemeType.PC)
        //            {
        //                cpi.Href = Host.Instance.GetContentLinkPage(ContentID, ClassID, iPageI);
        //            }
        //            else if (eThemeType == ThemeType.MOBILE)
        //            {
        //                cpi.Href = Host.Instance.MGetContentLink(ContentID, ClassID, iPageI);
        //            }

        //            if (aT.Length > 0 && !string.IsNullOrEmpty(aT[0]))
        //            {
        //                cpi.Title = isHtml? GetString.ClearHtml(aT[0]) : Core.UBB.ClearUBB(aT[0]);
        //            }
        //            else
        //            {
        //                cpi.Title = "找不到标题";
        //            }
        //            cp.Add(cpi);
        //            iPageI++;
        //        }
        //        if (!string.IsNullOrEmpty(ShowInfo))
        //        {
        //            ShowInfo = isHtml? ShowInfo: UBB.UBBToHtml(ShowInfo);
        //        }


        //    }

        //    return cp;

        //}

        public long  GetMinId()
        {
            return DbProviderCms.GetInstance().NewsContent_GetMinId(TableName);
        }

        public EbSite.Entity.NewsContent GetNext(long Id)
        {
            return DbProviderCms.GetInstance().NewsContent_GetNext(TableName, Id);
        }

        //public List<EbSite.Entity.NewsContent> GetListHtmlNameReWrite(int SiteID)
            //{
            //    return DbProviderCms.GetInstance().NewsContent_GetListHtmlNameReWrite(TableName, SiteID);
            //}

        }


}

