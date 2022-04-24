using System;
using System.Collections.Generic;
using System.Data;

namespace EbSite.Data.Interface
{
	/// <summary>
	/// ���ݷ�����EbSite��
	/// </summary>
	public partial interface IDataProviderCms
    {
		#region  ��Ա����

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool spiderlog_Exists(long Id);

		/// <summary>
		/// ����һ������
		/// </summary>
		int spiderlog_Add(Entity.spiderlog model);

		/// <summary>
		/// ����һ������
		/// </summary>
		void spiderlog_Update(Entity.spiderlog model);
		
		/// <summary>
		/// ��ȡͳ��
		/// </summary>
		int spiderlog_GetCount(string strWhere);

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void spiderlog_Delete(long Id);

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Entity.spiderlog spiderlog_GetEntity(long Id);

		/// <summary>
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		List<Entity.spiderlog> spiderlog_GetListArray(string strWhere);

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		DataSet spiderlog_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		List<Entity.spiderlog> spiderlog_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// ��÷�ҳ����
		/// </summary>
		List<Entity.spiderlog> spiderlog_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// ����ʵ�������
		/// </summary>
		Entity.spiderlog spiderlog_ReaderBind(IDataReader dataReader);
        /// <summary>
        /// ͳ����������
        /// </summary>
        /// <param name="spiderid">The spiderid.</param>
        /// <param name="itype">����,1.�������ã�2�������ã�3ǰ7�����ã�4ǰ30������</param>
        /// <returns>System.Int32.</returns>
        int GetLogCount(int spiderid, int itype);

        /// <summary>
        /// �ܷ�Ƶ��
        /// </summary>
        /// <param name="sWhere">The s where.</param>
        /// <returns>System.Int32.</returns>
        List<Entity.ListItemModel> GetVisitSum(string sWhere,int iTop);
        /// <summary>
        /// ���ʱ�η���
        /// </summary>
        /// <param name="itype">�������ͣ�1Ϊ���죬2Ϊ���죬3Ϊ���7�죬4Ϊ���30��.</param>
        /// <returns>List&lt;Entity.ListItemModel&gt;.</returns>
        List<Entity.ListItemModel> GetVisitTime(int itype);
        #endregion  ��Ա����
    }
}

