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
//        int Votes_GetMaxId();

//        /// <summary>
//        /// �Ƿ���ڸü�¼
//        /// </summary>
//        bool Votes_Exists(int id);

//        /// <summary>
//        /// ����һ������
//        /// </summary>
//        int Votes_Add(Entity.Votes model);

//        /// <summary>
//        /// ����һ������
//        /// </summary>
//        void Votes_Update(Entity.Votes model);
		
//        /// <summary>
//        /// ��ȡͳ��
//        /// </summary>
//        int Votes_GetCount(string strWhere);

//        /// <summary>
//        /// ɾ��һ������
//        /// </summary>
//        void Votes_Delete(int id);

//        /// <summary>
//        /// �õ�һ������ʵ��
//        /// </summary>
//        Entity.Votes Votes_GetEntity(int id);

//        /// <summary>
//        /// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
//        /// </summary>
//        List<Entity.Votes> Votes_GetListArray(string strWhere);

//        /// <summary>
//        /// ���ǰ��������
//        /// </summary>
//        DataSet Votes_GetList(int Top,string strWhere,string filedOrder);
		
//        /// <summary>
//        /// ���ǰ��������
//        /// </summary>
//        List<Entity.Votes> Votes_GetListArray(int Top,string strWhere,string filedOrder);

//        /// <summary>
//        /// ��÷�ҳ����
//        /// </summary>
//        List<Entity.Votes> Votes_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

//        /// <summary>
//        /// ����ʵ�������
//        /// </summary>
//        Entity.Votes Votes_ReaderBind(IDataReader dataReader);

//        #endregion  ��Ա����
//    }
//}

