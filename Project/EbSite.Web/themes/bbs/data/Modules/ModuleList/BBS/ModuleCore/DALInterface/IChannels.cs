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
//        int Channels_GetMaxId();

//        /// <summary>
//        /// �Ƿ���ڸü�¼
//        /// </summary>
//        bool Channels_Exists(int id);

//        /// <summary>
//        /// ����һ������
//        /// </summary>
//        int Channels_Add(Entity.Channels model);

//        /// <summary>
//        /// ����һ������
//        /// </summary>
//        void Channels_Update(Entity.Channels model);
		
//        /// <summary>
//        /// ��ȡͳ��
//        /// </summary>
//        int Channels_GetCount(string strWhere);

//        /// <summary>
//        /// ɾ��һ������
//        /// </summary>
//        void Channels_Delete(int id);

//        /// <summary>
//        /// �õ�һ������ʵ��
//        /// </summary>
//        Entity.Channels Channels_GetEntity(int id);

//        /// <summary>
//        /// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
//        /// </summary>
//        List<Entity.Channels> Channels_GetListArray(string strWhere);

//        /// <summary>
//        /// ���ǰ��������
//        /// </summary>
//        DataSet Channels_GetList(int Top,string strWhere,string filedOrder);
		
//        /// <summary>
//        /// ���ǰ��������
//        /// </summary>
//        List<Entity.Channels> Channels_GetListArray(int Top,string strWhere,string filedOrder);

//        /// <summary>
//        /// ��÷�ҳ����
//        /// </summary>
//        List<Entity.Channels> Channels_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

//        /// <summary>
//        /// ����ʵ�������
//        /// </summary>
//        Entity.Channels Channels_ReaderBind(IDataReader dataReader);

//        #endregion  ��Ա����
//    }
//}

