//using System;
//using System.Collections.Generic;
//using System.Data;
		
//namespace EbSite.Modules.BBS.ModuleCore.DALInterface
//{
//    /// <summary>
//    /// ���ݷ�����toupiao��
//    /// </summary>
//    public partial interface IDataProvider
//    {
//        #region  ��Ա����
//        /// <summary>
//        /// �Ƿ���ڸü�¼
//        /// </summary>
//        bool toupiao_Exists(long id);
//        /// <summary>
//        /// ����һ������
//        /// </summary>
//        int toupiao_Add(Entity.toupiao model);
//        /// <summary>
//        /// ����һ������
//        /// </summary>
//        void toupiao_Update(Entity.toupiao model);
//        /// <summary>
//        /// ɾ��һ������
//        /// </summary>
//        void toupiao_Delete(long id);
//        /// <summary>
//        /// �õ�һ������ʵ��
//        /// </summary>
//        Entity.toupiao toupiao_GetEntity(long id);
//        /// <summary>
//        /// ��ȡͳ��
//        /// </summary>
//        int toupiao_GetCount(string strWhere);
//        /// <summary>
//        /// ���ǰ��������
//        /// </summary>
//        DataSet toupiao_GetList(int Top, string strWhere, string filedOrder);
//        /// <summary>
//        /// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
//        /// </summary>
//        List<Entity.toupiao> toupiao_GetListArray(string strWhere);
//        /// <summary>
//        /// ���ǰ��������
//        /// </summary>
//        List<Entity.toupiao> toupiao_GetListArray(int Top, string strWhere, string filedOrder);
//        /// <summary>
//        /// ��÷�ҳ����
//        /// </summary>
//        List<Entity.toupiao> toupiao_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);
//        /// <summary>
//        /// ����ʵ�������
//        /// </summary>
//        Entity.toupiao toupiao_ReaderBind(IDataReader dataReader);
//        #endregion  ��Ա����
//    }
//}

