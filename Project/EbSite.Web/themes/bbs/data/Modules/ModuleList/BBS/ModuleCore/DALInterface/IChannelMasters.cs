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
//        int ChannelMasters_GetMaxId();

//        /// <summary>
//        /// �Ƿ���ڸü�¼
//        /// </summary>
//        bool ChannelMasters_Exists(int id);

//        /// <summary>
//        /// ����һ������
//        /// </summary>
//        int ChannelMasters_Add(Entity.ChannelMasters model);

//        /// <summary>
//        /// ����һ������
//        /// </summary>
//        void ChannelMasters_Update(Entity.ChannelMasters model);
		
//        /// <summary>
//        /// ��ȡͳ��
//        /// </summary>
//        int ChannelMasters_GetCount(string strWhere);

//        /// <summary>
//        /// ɾ��һ������
//        /// </summary>
//        void ChannelMasters_Delete(int id);

//        /// <summary>
//        /// �õ�һ������ʵ��
//        /// </summary>
//        Entity.ChannelMasters ChannelMasters_GetEntity(int id);

//        /// <summary>
//        /// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
//        /// </summary>
//        List<Entity.ChannelMasters> ChannelMasters_GetListArray(string strWhere);

//        /// <summary>
//        /// ���ǰ��������
//        /// </summary>
//        DataSet ChannelMasters_GetList(int Top,string strWhere,string filedOrder);
		
//        /// <summary>
//        /// ���ǰ��������
//        /// </summary>
//        List<Entity.ChannelMasters> ChannelMasters_GetListArray(int Top,string strWhere,string filedOrder);

//        /// <summary>
//        /// ��÷�ҳ����
//        /// </summary>
//        List<Entity.ChannelMasters> ChannelMasters_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

//        /// <summary>
//        /// ����ʵ�������
//        /// </summary>
//        Entity.ChannelMasters ChannelMasters_ReaderBind(IDataReader dataReader);

//        #endregion  ��Ա����
//    }
//}

