//using System;
//using System.Collections.Generic;
//using System.Data;
		
//namespace EbSite.Data.Interface
//{
//	/// <summary>
//	/// ���ݷ�����EbSite��
//	/// </summary>
//	public partial interface IDataProviderCms
//    {
//		#region  ��Ա����

//		/// <summary>
//		/// �õ����ID
//		/// </summary>
//		int ClassSetConfig_GetMaxId();

//		/// <summary>
//		/// �Ƿ���ڸü�¼
//		/// </summary>
//		bool ClassSetConfig_Exists(int Id);

//		/// <summary>
//		/// ����һ������
//		/// </summary>
//		int ClassSetConfig_Add(Entity.ClassSetConfig model);

//		/// <summary>
//		/// ����һ������
//		/// </summary>
//		void ClassSetConfig_Update(Entity.ClassSetConfig model);
		
//		/// <summary>
//		/// ��ȡͳ��
//		/// </summary>
//		int ClassSetConfig_GetCount(string strWhere);

//		/// <summary>
//		/// ɾ��һ������
//		/// </summary>
//		void ClassSetConfig_Delete(int Id);

//		/// <summary>
//		/// �õ�һ������ʵ��
//		/// </summary>
//		Entity.ClassSetConfig ClassSetConfig_GetEntity(int Id);

//		/// <summary>
//		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
//		/// </summary>
//		List<Entity.ClassSetConfig> ClassSetConfig_GetListArray(string strWhere);

//		/// <summary>
//		/// ���ǰ��������
//		/// </summary>
//		DataSet ClassSetConfig_GetList(int Top,string strWhere,string filedOrder);
		
//		/// <summary>
//		/// ���ǰ��������
//		/// </summary>
//		List<Entity.ClassSetConfig> ClassSetConfig_GetListArray(int Top,string strWhere,string filedOrder);

//		/// <summary>
//		/// ��÷�ҳ����
//		/// </summary>
//		List<Entity.ClassSetConfig> ClassSetConfig_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

//		/// <summary>
//		/// ����ʵ�������
//		/// </summary>
//		Entity.ClassSetConfig ClassSetConfig_ReaderBind(IDataReader dataReader);

//	    void ClassSetConfig_UpdateConfigId(Entity.ClassSetConfig md);
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="ClassIds">�ö��ŷֿ�</param>
//        void ClassSetConfig_DeleteByClassIds(string ClassIds);

//        #endregion  ��Ա����
//    }
//}

