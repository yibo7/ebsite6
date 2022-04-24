using System;
using System.Collections.Generic;
using System.Data;

namespace EbSite.Modules.Wenda.ModuleCore.DALInterface
{
    /// <summary>
    /// ���ݷ�����Ask��
    /// </summary>
    public partial interface IDataProvider
	{
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		int AskCache_GetMaxId();

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool AskCache_Exists(int id);

		/// <summary>
		/// ����һ������
		/// </summary>
		int AskCache_Add(Entity.AskCache model);

		/// <summary>
		/// ����һ������
		/// </summary>
		void AskCache_Update(Entity.AskCache model);
        /// <summary>
        /// ����һ������
        /// </summary>
        void AskCache_UpdateEx(Entity.AskCache model);
		
		/// <summary>
		/// ��ȡͳ��
		/// </summary>
		int AskCache_GetCount(string strWhere);

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void AskCache_Delete(int id);

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Entity.AskCache AskCache_GetEntity(int id);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Entity.AskCache AskCache_GetEntity(int keyid,int keytype);

		/// <summary>
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		List<Entity.AskCache> AskCache_GetListArray(string strWhere);

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		DataSet AskCache_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		List<Entity.AskCache> AskCache_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// ��÷�ҳ����
		/// </summary>
		List<Entity.AskCache> AskCache_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// ����ʵ�������
		/// </summary>
		Entity.AskCache AskCache_ReaderBind(IDataReader dataReader);

		#endregion  ��Ա����

        #region �Զ��巽��

        /// <summary>
        /// �ж��Ƿ����
        /// </summary>
        /// <param name="keyid">����ID</param>
        /// <param name="keytype">��������</param>
        /// <returns></returns>
        bool AskCache_IsTimeOut(int keyid,int keytype);
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        /// <param name="keyid">����ID</param>
        /// <param name="keytype">��������</param>
        bool AskCache_Exists(int keyid, int keytype);

        #endregion �Զ��巽��
    }
}

