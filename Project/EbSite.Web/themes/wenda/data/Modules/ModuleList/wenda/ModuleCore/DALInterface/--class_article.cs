//using System;
//using System.Collections.Generic;
//using System.Data;
//using EbSite.Modules.Wenda.ModuleCore.DAL.MySQL;

//namespace EbSite.Modules.Wenda.ModuleCore.DALInterface
//{
//    /// <summary>
//    /// 数据访问类Ask。
//    /// </summary>
//    public partial interface IDataProvider
//    {
//        #region  成员方法

//        /// <summary>
//        /// 获得分页数据
//        /// </summary>
//        List<Entity.class_article> class_article_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount);

//        /// <summary>
//        /// 对象实体绑定数据
//        /// </summary>
//        Entity.class_article class_article_ReaderBind(IDataReader dataReader);

//        /// <summary>
//        /// 增加一条数据
//        /// </summary>
//        int class_article_Add(Entity.class_article model);


//        /// <summary>
//        /// 更新一条数据
//        /// </summary>
//        void class_article_Update(Entity.class_article model);

//        DataSet GetClassArticleRandomContentIDS(int Top, string swhere, string ids);

//        DataSet GetNewsClassArticleContent(int PageIndex, int PageSize);

//        #endregion  成员方法


//    }
//}

