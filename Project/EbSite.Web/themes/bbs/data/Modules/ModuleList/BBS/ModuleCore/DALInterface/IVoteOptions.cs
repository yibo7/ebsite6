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
//        int VoteOptions_GetMaxId();

//        /// <summary>
//        /// �Ƿ���ڸü�¼
//        /// </summary>
//        bool VoteOptions_Exists(int id);

//        /// <summary>
//        /// ����һ������
//        /// </summary>
//        int VoteOptions_Add(Entity.VoteOptions model);

//        /// <summary>
//        /// ����һ������
//        /// </summary>
//        void VoteOptions_Update(Entity.VoteOptions model);
		
//        /// <summary>
//        /// ��ȡͳ��
//        /// </summary>
//        int VoteOptions_GetCount(string strWhere);

//        /// <summary>
//        /// ɾ��һ������
//        /// </summary>
//        void VoteOptions_Delete(int id);

//        /// <summary>
//        /// �õ�һ������ʵ��
//        /// </summary>
//        Entity.VoteOptions VoteOptions_GetEntity(int id);

//        /// <summary>
//        /// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
//        /// </summary>
//        List<Entity.VoteOptions> VoteOptions_GetListArray(string strWhere);

//        /// <summary>
//        /// ���ǰ��������
//        /// </summary>
//        DataSet VoteOptions_GetList(int Top,string strWhere,string filedOrder);
		
//        /// <summary>
//        /// ���ǰ��������
//        /// </summary>
//        List<Entity.VoteOptions> VoteOptions_GetListArray(int Top,string strWhere,string filedOrder);

//        /// <summary>
//        /// ��÷�ҳ����
//        /// </summary>
//        List<Entity.VoteOptions> VoteOptions_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

//        /// <summary>
//        /// ����ʵ�������
//        /// </summary>
//        Entity.VoteOptions VoteOptions_ReaderBind(IDataReader dataReader);

//        #endregion  ��Ա����
//    }
//}

