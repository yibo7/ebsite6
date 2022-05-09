using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.Modules.BBS.ModuleCore.BLL
{
    /// <summary>
    /// ҵ���߼���TopicReplies ��ժҪ˵����
    /// </summary>
    public class TopicReplies  
    {
        public static readonly TopicReplies Instance = new TopicReplies();
        protected static DALInterface.IDataProvider dalHelper
        {
            get
            {
                return DAL.DataProfile.DalFactory.DalProvider;
            }
        }
        private TopicReplies()
        {
        }

        #region  ��Ա����

        /// <summary>
        /// �õ����ID
        /// </summary>
        public long GetMaxId(int classid)
        {
            return dalHelper.TopicReplies_GetMaxId(classid);
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(long id, int classid)
        {
            return dalHelper.TopicReplies_Exists(id, classid);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
         public long Add(Entity.TopicReplies model, int classid)
        {
             
            return dalHelper.TopicReplies_Add(model, classid);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
         public void Update(Entity.TopicReplies model, int classid)
        {
             
            dalHelper.TopicReplies_Update(model, classid);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
         public void Delete(long id, int classid)
        {
            

            dalHelper.TopicReplies_Delete(id, classid);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
         public Entity.TopicReplies GetEntity(long id, int classid)
        {
            return dalHelper.TopicReplies_GetEntity(id, classid);
            //string rawKey = string.Concat("GetEntity-", id);
            //Entity.TopicReplies etEntity = base.GetCacheItem(rawKey) as Entity.TopicReplies;
            //if (Equals(etEntity, null))
            //{
            //    etEntity = dalHelper.TopicReplies_GetEntity(id, classid);
            //    if (!Equals(etEntity, null))
            //        base.AddCacheItem(rawKey, etEntity);
            //}
            //return etEntity;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public int GetCount(string strWhere, int classid)
        {
            return dalHelper.TopicReplies_GetCount(strWhere, classid);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public int GetCountCache(string strWhere, int classid)
        {
            return GetCountCache(strWhere, classid);

            //string rawKey = string.Concat("GetCount-", strWhere);
            //string sCount = base.GetCacheItem(rawKey) as string;
            //if (string.IsNullOrEmpty(sCount))
            //{
            //    sCount = GetCountCache(strWhere, classid).ToString();
            //    if (!string.IsNullOrEmpty(sCount))
            //        base.AddCacheItem(rawKey, sCount);
            //}
            //if (!string.IsNullOrEmpty(sCount))
            //{
            //    return int.Parse(sCount);
            //}
            //return 0;
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public int GetCount(int classid)
        {
            return GetCountCache("", classid);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere, int classid)
        {
            return GetListCache(0, strWhere, "", classid);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(int classid)
        {
            return GetList("", classid);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder, int classid)
        {
            return dalHelper.TopicReplies_GetList(Top, strWhere, filedOrder, classid);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetListCache(int Top, string strWhere, string filedOrder, int classid)
        {
            return GetList(Top, strWhere, filedOrder, classid);
            //string rawKey = string.Concat("GetList-", strWhere, Top, filedOrder);
            //DataSet lstData = base.GetCacheItem(rawKey) as DataSet;
            //if (Equals(lstData, null))
            //{
            //    lstData = GetList(Top, strWhere, filedOrder, classid);
            //    if (!Equals(lstData, null))
            //        base.AddCacheItem(rawKey, lstData);
            //}
            //return lstData;
        }
        /// <summary>
        /// ��������б�
        /// </summary>
         public List<Entity.TopicReplies> GetListArray(int Top, string strWhere, string filedOrder, int classid)
        {
            return dalHelper.TopicReplies_GetListArray(Top, strWhere, filedOrder, classid);
        }
         /// <summary>
         /// ��������б�
         /// </summary>
         public List<Entity.TopicReplies> GetListArrayCache(int Top, string strWhere, string filedOrder, int classid)
         {
             return GetListArray(Top, strWhere, filedOrder, classid);

             //string rawKey = string.Concat("GetListArray-", strWhere, Top, filedOrder);
             //List<Entity.TopicReplies> lstData = base.GetCacheItem(rawKey) as List<Entity.TopicReplies>;
             //if (Equals(lstData, null))
             //{
             //    //�ӻ�����ã������¼�
             //    lstData = base.GetListArrayEv(Top, strWhere, filedOrder);
             //    if (!Equals(lstData, null))
             //        base.AddCacheItem(rawKey, lstData);
             //}
             //return lstData;
         }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Entity.TopicReplies> GetListArray(int Top, string filedOrder, int classid)
        {
            return GetListArrayCache(Top, "", filedOrder, classid);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Entity.TopicReplies> GetListArray(string strWhere, int classid)
        {
            return GetListArrayCache(0, strWhere, "", classid);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Entity.TopicReplies> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount, int classid)
        {
            return dalHelper.TopicReplies_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount, classid);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Entity.TopicReplies> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount, int classid)
        {
            return GetListPages( PageIndex,  PageSize,  strWhere,  Fileds,  oderby, out  RecordCount,  classid);
             
        }
        /// <summary>
        /// ��������б�-��ҳ
        /// </summary>
        public List<Entity.TopicReplies> GetListPages(int PageIndex, int PageSize, out int RecordCount, int classid)
        {
            return GetListPagesCache(PageIndex, PageSize, "", "", "", out  RecordCount, classid);
        }
        /// <summary>
        /// ��������б�-��ҳ
        /// </summary>
        public List<Entity.TopicReplies> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount, int classid)
        {
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount, classid);
        }
        /// <summary>
        /// ��������б�-��ҳ
        /// </summary>
        public List<Entity.TopicReplies> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, int classid)
        {
            int iCount = 0;
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount, classid);
        }
        /// <summary>
        /// ����-��ҳ
        /// </summary>
        public List<Entity.TopicReplies> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName, int classid)
        {
            string strWhere = "";
            if (!string.IsNullOrEmpty(sKeyWord)) strWhere = string.Format("{0} like '%{1}%'", ColumnName, sKeyWord);
            if (string.IsNullOrEmpty(strWhere))
            {
                RecordCount = 0;
                return null;
            }
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount, classid);
        }
     
        #endregion  ��Ա����

        #region  �Զ��巽��

        public int TopicReplies_Copy(string TableName)
        {
            return dalHelper.TopicReplies_Copy(TableName);
        }

        public List<Entity.TopicReplies> GetListPagesByPostID(int PageIndex, int PageSize, out int RecordCount, long ContentID, int classid)
        {
            return dalHelper.TopicReplies_GetListPages(PageIndex, PageSize, string.Concat("TopicID=", ContentID), "", " id asc ", out  RecordCount, classid);
        }

        public List<Entity.TopicReplies> GetListArrayByTopicId(long TopicId, int classid)
        {
            string sWhere = string.Format("TopicID='{0}'", TopicId);
            return GetListArray(sWhere, classid);
        }
        public List<Entity.TopicReplies> GetListPageByCls(int PageIndex, int PageSize, out int RecordCount, string cls, string getWhere, int classid)
        {
            string sWhere = "";
            if (string.IsNullOrEmpty(cls)) //ȫ������Ϊû��ɾ����
            {
                sWhere = string.Format("DeleteFlag!='{0}'", "1");
            }
            else if (string.Equals(cls, "1"))//û����˵�����
            {
                sWhere = string.Format("DeleteFlag='{0}'", "1");
            }
           
            if (!string.IsNullOrEmpty(getWhere))
            {
                if (!string.IsNullOrEmpty(sWhere))
                {
                    sWhere = sWhere + " and " + getWhere;
                }
                else
                {
                    sWhere = getWhere;
                }
            }
            return GetListPagesCache(PageIndex, PageSize, sWhere.Trim(), "", "", out RecordCount, classid);

        }
        /// <summary>
        /// �ظ�һ������
        /// </summary>
        /// <param name="postid">����ID</param>
        /// <param name="c">�ظ�����</param>
        /// <param name="rc">��������id</param>
        /// <param name="allcount">��ǰ�ظ�������</param>
        /// <param name="site">��ǰվ��ID</param>
        /// <returns></returns>
        public string AddHf(int postid, string c, string rc, int allcount, int site, int endpageindex, out bool isok, int classid)
        {

            if (!string.IsNullOrEmpty(c) && c.Length > 2)
            {

                ModuleCore.Entity.TopicReplies md = new Entity.TopicReplies();

                //string rcContent = string.Empty;

                //if (rcid>0)
                //{

                //    Entity.TopicReplies mdReference = GetEntity(rcid);
                //    rcContent = Core.Strings.GetString.CutLen(mdReference.ReplyContent,50);
                //}


                md.AuditFlag = 1;
                md.CreatedIP = Core.Utils.GetClientIP();
                md.CreatedTime = DateTime.Now;
                md.DeleteFlag = 0;
                md.IsBadCount = 0;
                md.IsGoodCount = 0;
                md.ReferenceContent = rc;
                md.ReferenceFlag = string.IsNullOrEmpty(rc) ? 0 : 1;
                md.ReplyContent = c;
                md.TopicID = postid;
                md.UpdatedTime = md.CreatedTime;

                Entity.imitateuser mdimitateuser = imitateuser.Instance.GetRandByUserID(EbSite.Base.Host.Instance.UserID);
                if (!Equals(mdimitateuser, null)) //ģ�ⷢ��
                {
                    if (mdimitateuser.UserID > 0)
                    {
                        md.UserID = mdimitateuser.ImitateUserID;
                        md.UserName = mdimitateuser.ImitateUserRealName;
                    }

                }
                else
                {
                    md.UserID = EbSite.Base.Host.Instance.UserID;
                    md.UserName = EbSite.Base.AppStartInit.UserNiName;
                }


                Add(md, classid);

                EbSite.Entity.NewsContent mdContent = EbSite.Base.AppStartInit.GetNewsContentInst(classid).GetModel(postid, site);
                //Ĭ�ϳ�ʼ����ǰ�û�Ϊ���ظ���
                mdContent.Annex2 = md.UserName; //���ظ�������
                mdContent.Annex3 = md.UserID.ToString();//���ظ���ID
                mdContent.AddTime = DateTime.Now;//���ظ�ʱ��
                mdContent.CommentNum = allcount + 1;

                EbSite.Base.AppStartInit.GetNewsContentInst(classid).Update(mdContent);
                BBSClass.UpdateCountAddOne(mdContent.ClassID, false, mdContent.ID, mdContent.NewsTitle, md.UserID,
                                           md.UserName);

                isok = true;

                return GetLinks.ContentPage(postid, endpageindex, site, classid);
            }
            else
            {
                isok = false;
                return EbSite.Base.Host.Instance.GetTips("�����������벻Ҫ��ˮ��лл��");
            }

        }
        public void EditeReply(long id, string ContentHtml, int classid)
        {

            dalHelper.EditeReply(id, ContentHtml, classid);
        }

        #endregion  �Զ��巽��

        #region PostContent

        public void UpdatePost(int SetTop, int PostLab, int TitleFont, string TitleColor, string IDs, int ManagerUserId, string ManagerUserNiName, int classid)
        {
            dalHelper.UpdatePost(SetTop, PostLab, TitleFont, TitleColor, IDs, ManagerUserId, ManagerUserNiName, classid);
        }
         
        #endregion
        public void Update(int id, string Col, string sValue, int classid)
        {
            dalHelper.TopicReplies_Update(id, Col, sValue, classid);
        }

        public void SetPostToDel(int id, int classid)
        {
            Update(id, "DeleteFlag", "1", classid);
             
        }
        public void SetPostToHY(int id, int classid)
        {
            Update(id, "DeleteFlag", "0", classid);
             
        }


    }
}

