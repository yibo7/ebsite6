//using System;
//using System.Collections.Generic;
//using System.Data;
//using EbSite.Modules.Wenda.ModuleCore.DAL.MySQL;

//namespace EbSite.Modules.Wenda.ModuleCore.DALInterface
//{
//    /// <summary>
//    /// ���ݷ�����Ask��
//    /// </summary>
//    public partial interface IDataProvider
//    {
//        #region  ��Ա����

//        /// <summary>
//        /// ��÷�ҳ����
//        /// </summary>
//        List<Entity.class_article> class_article_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount);

//        /// <summary>
//        /// ����ʵ�������
//        /// </summary>
//        Entity.class_article class_article_ReaderBind(IDataReader dataReader);

//        /// <summary>
//        /// ����һ������
//        /// </summary>
//        int class_article_Add(Entity.class_article model);


//        /// <summary>
//        /// ����һ������
//        /// </summary>
//        void class_article_Update(Entity.class_article model);

//        DataSet GetClassArticleRandomContentIDS(int Top, string swhere, string ids);

//        DataSet GetNewsClassArticleContent(int PageIndex, int PageSize);

//        #endregion  ��Ա����


//    }
//}

