//using System;
//using System.Collections.Generic;
//using System.Data;
		
//namespace EbSite.Modules.BBS.ModuleCore.DALInterface
//{
//    /// <summary>
//    /// ���ݷ�����BBS��
//    /// </summary>
//    public partial interface IDataProvider
//    {
//        #region  ��Ա����

//        /// <summary>
//        /// �õ����ID
//        /// </summary>
//        long Topics_GetMaxId();

//        /// <summary>
//        /// �Ƿ���ڸü�¼
//        /// </summary>
//        bool Topics_Exists(long id);

//        /// <summary>
//        /// ����һ������
//        /// </summary>
//        long Topics_Add(Entity.Topics model);

//        /// <summary>
//        /// ����һ������
//        /// </summary>
//        void Topics_Update(Entity.Topics model);
		
//        /// <summary>
//        /// ��ȡͳ��
//        /// </summary>
//        int Topics_GetCount(string strWhere);

//        /// <summary>
//        /// ɾ��һ������
//        /// </summary>
//        void Topics_Delete(long id);

//        /// <summary>
//        /// �õ�һ������ʵ��
//        /// </summary>
//        Entity.Topics Topics_GetEntity(long id);

//        /// <summary>
//        /// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
//        /// </summary>
//        List<Entity.Topics> Topics_GetListArray(string strWhere);

//        /// <summary>
//        /// ���ǰ��������
//        /// </summary>
//        DataSet Topics_GetList(int Top,string strWhere,string filedOrder);
		
//        /// <summary>
//        /// ���ǰ��������
//        /// </summary>
//        List<Entity.Topics> Topics_GetListArray(int Top,string strWhere,string filedOrder);

//        /// <summary>
//        /// ��÷�ҳ����
//        /// </summary>
//        List<Entity.Topics> Topics_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

//        /// <summary>
//        /// ����ʵ�������
//        /// </summary>
//        Entity.Topics Topics_ReaderBind(IDataReader dataReader);

//        #endregion  ��Ա����
//    }
//}

