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
//        int Voters_GetMaxId();

//        /// <summary>
//        /// �Ƿ���ڸü�¼
//        /// </summary>
//        bool Voters_Exists(int id);

//        /// <summary>
//        /// ����һ������
//        /// </summary>
//        int Voters_Add(Entity.Voters model);

//        /// <summary>
//        /// ����һ������
//        /// </summary>
//        void Voters_Update(Entity.Voters model);
		
//        /// <summary>
//        /// ��ȡͳ��
//        /// </summary>
//        int Voters_GetCount(string strWhere);

//        /// <summary>
//        /// ɾ��һ������
//        /// </summary>
//        void Voters_Delete(int id);

//        /// <summary>
//        /// �õ�һ������ʵ��
//        /// </summary>
//        Entity.Voters Voters_GetEntity(int id);

//        /// <summary>
//        /// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
//        /// </summary>
//        List<Entity.Voters> Voters_GetListArray(string strWhere);

//        /// <summary>
//        /// ���ǰ��������
//        /// </summary>
//        DataSet Voters_GetList(int Top,string strWhere,string filedOrder);
		
//        /// <summary>
//        /// ���ǰ��������
//        /// </summary>
//        List<Entity.Voters> Voters_GetListArray(int Top,string strWhere,string filedOrder);

//        /// <summary>
//        /// ��÷�ҳ����
//        /// </summary>
//        List<Entity.Voters> Voters_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

//        /// <summary>
//        /// ����ʵ�������
//        /// </summary>
//        Entity.Voters Voters_ReaderBind(IDataReader dataReader);

//        #endregion  ��Ա����
//    }
//}

