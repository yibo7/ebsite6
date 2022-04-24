using System;
using System.Collections.Generic;
using System.Data;
		
namespace EbSite.Modules.BBS.ModuleCore.DALInterface
{
	/// <summary>
	/// ���ݷ�����BBS��
	/// </summary>
	public partial interface IDataProvider
	{
		#region  ��Ա����
        int TopicReplies_Copy(string tablename);
		/// <summary>
		/// �õ����ID
		/// </summary>
		long TopicReplies_GetMaxId(int classid);

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
        bool TopicReplies_Exists(long id, int classid);

		/// <summary>
		/// ����һ������
		/// </summary>
        long TopicReplies_Add(Entity.TopicReplies model, int classid);

		/// <summary>
		/// ����һ������
		/// </summary>
        void TopicReplies_Update(Entity.TopicReplies model, int classid);
		
		/// <summary>
		/// ��ȡͳ��
		/// </summary>
        int TopicReplies_GetCount(string strWhere, int classid);

		/// <summary>
		/// ɾ��һ������
		/// </summary>
        void TopicReplies_Delete(long id, int classid);

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        Entity.TopicReplies TopicReplies_GetEntity(long id, int classid);

		/// <summary>
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
        List<Entity.TopicReplies> TopicReplies_GetListArray(string strWhere, int classid);

		/// <summary>
		/// ���ǰ��������
		/// </summary>
        DataSet TopicReplies_GetList(int Top, string strWhere, string filedOrder, int classid);
		
		/// <summary>
		/// ���ǰ��������
		/// </summary>
        List<Entity.TopicReplies> TopicReplies_GetListArray(int Top, string strWhere, string filedOrder, int classid);

		/// <summary>
		/// ��÷�ҳ����
		/// </summary>
        List<Entity.TopicReplies> TopicReplies_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount, int classid);

		/// <summary>
		/// ����ʵ�������
		/// </summary>
		Entity.TopicReplies TopicReplies_ReaderBind(IDataReader dataReader);

        void EditeReply(long id, string ContentHtml, int classid);

	    void UpdatePost(int SetTop, int PostLab, int TitleFont, string TitleColor, string IDs, int ManagerUserId,
                        string ManagerUserNiName, int classid);

        void TopicReplies_Update(int id, string Col, string sValue, int classid);

	    #endregion  ��Ա����
	}
}

