//using System;
//using System.Collections.Generic;
//using System.Data;
		
//namespace EbSite.Modules.BBS.ModuleCore.DALInterface
//{
//    /// <summary>
//    /// ���ݷ�����toupiaobt��
//    /// </summary>
//    public partial interface IDataProvider
//    {
//        #region  ��Ա����
//        /// <summary>
//        /// �Ƿ���ڸü�¼
//        /// </summary>
//        bool toupiaobt_Exists(long id);
//        /// <summary>
//        /// ����һ������
//        /// </summary>
//        int toupiaobt_Add(Entity.toupiaobt model);
//        /// <summary>
//        /// ����һ������
//        /// </summary>
//        void toupiaobt_Update(Entity.toupiaobt model);
//        /// <summary>
//        /// ɾ��һ������
//        /// </summary>
//        void toupiaobt_Delete(long id);
//        /// <summary>
//        /// �õ�һ������ʵ��
//        /// </summary>
//        Entity.toupiaobt toupiaobt_GetEntity(long id);
//        /// <summary>
//        /// ��ȡͳ��
//        /// </summary>
//        int toupiaobt_GetCount(string strWhere);
//        /// <summary>
//        /// ���ǰ��������
//        /// </summary>
//        DataSet toupiaobt_GetList(int Top, string strWhere, string filedOrder);
//        /// <summary>
//        /// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
//        /// </summary>
//        List<Entity.toupiaobt> toupiaobt_GetListArray(string strWhere);
//        /// <summary>
//        /// ���ǰ��������
//        /// </summary>
//        List<Entity.toupiaobt> toupiaobt_GetListArray(int Top, string strWhere, string filedOrder);
//        /// <summary>
//        /// ��÷�ҳ����
//        /// </summary>
//        List<Entity.toupiaobt> toupiaobt_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);
//        /// <summary>
//        /// ����ʵ�������
//        /// </summary>
//        Entity.toupiaobt toupiaobt_ReaderBind(IDataReader dataReader);
//        #endregion  ��Ա����
//    }
//}

