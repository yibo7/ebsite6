//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using MongoDB.Bson;
//using MongoDB.Driver;
//using MongoDB.Driver.Builders;

//namespace EbSite.Core.MDB
//{
//    abstract public class MongoDBHelper
//    {
//        abstract protected string DbServer { get; }
//        abstract protected string DbName { get; }
        
//        private string MongoDbServer
//        {
//            get { return string.Concat("mongodb://", DbServer); }
//        }

//        private string MongoDbName
//        {
//            get { return DbName; }
//        }

//        #region 新增

//        public  SafeModeResult InsertOne<T>(string collectionName, T entity)
//        {
//            return InsertOne<T>(MongoDbServer, MongoDbName, collectionName, entity);
//        }

//        public  SafeModeResult InsertOne<T>(string connectionString, string databaseName, string collectionName, T entity)
//        {
//            SafeModeResult result = new SafeModeResult();

//            if (null == entity)
//            {
//                return null;
//            }

//            MongoServer server = MongoServer.Create(connectionString);

//            //获取数据库或者创建数据库（不存在的话）。
//            MongoDatabase database = server.GetDatabase(databaseName);



//            using (server.RequestStart(database))//开始连接数据库。
//            {
//                MongoCollection<BsonDocument> myCollection = database.GetCollection<BsonDocument>(collectionName);
//                result = myCollection.Insert(entity);
//            }

//            return result;
//        }

//        //public  IEnumerable<SafeModeResult> InsertAll<T>(string collectionName, IEnumerable<T> entitys)
//        //{
//        //    return InsertAll<T>(MongoDbServer, MongoDbName, collectionName, entitys);
//        //}

//        //public  IEnumerable<SafeModeResult> InsertAll<T>(string connectionString, string databaseName, string collectionName, IEnumerable<T> entitys)
//        //{
//        //    IEnumerable<SafeModeResult> result = null;

//        //    if (null == entitys)
//        //    {
//        //        return null;
//        //    }

//        //    MongoServer server = MongoServer.Create(connectionString);

//        //    //获取数据库或者创建数据库（不存在的话）。
//        //    MongoDatabase database = server.GetDatabase(databaseName);



//        //    using (server.RequestStart(database))//开始连接数据库。
//        //    {
//        //        MongoCollection<BsonDocument> myCollection = database.GetCollection<BsonDocument>(collectionName);
//        //        result = myCollection.InsertBatch(entitys);
//        //    }

//        //    return result;
//        //}

//        #endregion


//        #region 修改

//        public  SafeModeResult UpdateOne<T>(string collectionName, T entity)
//        {
//            return UpdateOne<T>(MongoDbServer, MongoDbName, collectionName, entity);
//        }

//        public  SafeModeResult UpdateOne<T>(string connectionString, string databaseName, string collectionName, T entity)
//        {
//            MongoServer server = MongoServer.Create(connectionString);

//            //获取数据库或者创建数据库（不存在的话）。
//            MongoDatabase database = server.GetDatabase(databaseName);

//            SafeModeResult result;

//            using (server.RequestStart(database))//开始连接数据库。
//            {
//                MongoCollection<BsonDocument> myCollection = database.GetCollection<BsonDocument>(collectionName);

//                result = myCollection.Save(entity);

//            }

//            return result;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="collectionName"></param>
//        /// <param name="query">条件查询。 调用示例：Query.Matches("Title", "感冒") 或者 Query.EQ("Title", "感冒") 或者Query.And(Query.Matches("Title", "感冒"),Query.EQ("Author", "yanc")) 等等</param>
//        /// <param name="update">更新设置。调用示例：Update.Set("Title", "yanc") 或者 Update.Set("Title", "yanc").Set("Author", "yanc2") 等等</param>
//        /// <returns></returns>
//        public  SafeModeResult UpdateAll<T>(string collectionName, IMongoQuery query, IMongoUpdate update)
//        {
//            return UpdateAll<T>(MongoDbServer, MongoDbName, collectionName, query, update);
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="connectionString"></param>
//        /// <param name="databaseName"></param>
//        /// <param name="collectionName"></param>
//        /// <param name="query">条件查询。 调用示例：Query.Matches("Title", "感冒") 或者 Query.EQ("Title", "感冒") 或者Query.And(Query.Matches("Title", "感冒"),Query.EQ("Author", "yanc")) 等等</param>
//        /// <param name="update">更新设置。调用示例：Update.Set("Title", "yanc") 或者 Update.Set("Title", "yanc").Set("Author", "yanc2") 等等</param>
//        /// <returns></returns>
//        public  SafeModeResult UpdateAll<T>(string connectionString, string databaseName, string collectionName, IMongoQuery query, IMongoUpdate update)
//        {
//            SafeModeResult result;

//            if (null == query || null == update)
//            {
//                return null;
//            }


//            MongoServer server = MongoServer.Create(connectionString);

//            //获取数据库或者创建数据库（不存在的话）。
//            MongoDatabase database = server.GetDatabase(databaseName);



//            using (server.RequestStart(database))//开始连接数据库。
//            {
//                MongoCollection<BsonDocument> myCollection = database.GetCollection<BsonDocument>(collectionName);

//                result = myCollection.Update(query, update, UpdateFlags.Multi);
//            }

//            return result;
//        }

//        #endregion


//        #region 删除

//        public  SafeModeResult Delete(string collectionName, string _id)
//        {
//            return Delete(MongoDbServer, MongoDbName, collectionName, _id);
//        }

//        public  SafeModeResult Delete(string connectionString, string databaseName, string collectionName, string _id)
//        {
//            SafeModeResult result;
//            ObjectId id;
//            if (!ObjectId.TryParse(_id, out id))
//            {
//                return null;
//            }



//            MongoServer server = MongoServer.Create(connectionString);

//            //获取数据库或者创建数据库（不存在的话）。
//            MongoDatabase database = server.GetDatabase(databaseName);



//            using (server.RequestStart(database))//开始连接数据库。
//            {
//                MongoCollection<BsonDocument> myCollection = database.GetCollection<BsonDocument>(collectionName);

//                result = myCollection.Remove(Query.EQ("_id", id));
//            }

//            return result;

//        }

//        public  SafeModeResult DeleteAll(string collectionName)
//        {
//            return DeleteAll(MongoDbServer, MongoDbName, collectionName, null);
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="collectionName"></param>
//        /// <param name="query">条件查询。 调用示例：Query.Matches("Title", "感冒") 或者 Query.EQ("Title", "感冒") 或者Query.And(Query.Matches("Title", "感冒"),Query.EQ("Author", "yanc")) 等等</param>
//        /// <returns></returns>
//        public  SafeModeResult DeleteAll(string collectionName, IMongoQuery query)
//        {
//            return DeleteAll(MongoDbServer, MongoDbName, collectionName, query);
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="connectionString"></param>
//        /// <param name="databaseName"></param>
//        /// <param name="collectionName"></param>
//        /// <param name="query">条件查询。 调用示例：Query.Matches("Title", "感冒") 或者 Query.EQ("Title", "感冒") 或者Query.And(Query.Matches("Title", "感冒"),Query.EQ("Author", "yanc")) 等等</param>
//        /// <returns></returns>
//        public  SafeModeResult DeleteAll(string connectionString, string databaseName, string collectionName, IMongoQuery query)
//        {
//            MongoServer server = MongoServer.Create(connectionString);

//            //获取数据库或者创建数据库（不存在的话）。
//            MongoDatabase database = server.GetDatabase(databaseName);

//            SafeModeResult result;

//            using (server.RequestStart(database))//开始连接数据库。
//            {
//                MongoCollection<BsonDocument> myCollection = database.GetCollection<BsonDocument>(collectionName);

//                if (null == query)
//                {
//                    result = myCollection.RemoveAll();
//                }
//                else
//                {
//                    result = myCollection.Remove(query);
//                }
//            }

//            return result;

//        }

//        #endregion


//        #region 获取单条信息

//        public  T GetOne<T>(string collectionName, string _id)
//        {
//            return MongoDBHelper.GetOne<T>(MongoDbServer, MongoDbName, collectionName, _id);
//        }

//        public static T GetOne<T>(string connectionString, string databaseName, string collectionName, string _id)
//        {
//            T result = default(T);
//            ObjectId id;
//            if (!ObjectId.TryParse(_id, out id))
//            {
//                return default(T);
//            }

//            MongoServer server = MongoServer.Create(connectionString);

//            //获取数据库或者创建数据库（不存在的话）。
//            MongoDatabase database = server.GetDatabase(databaseName);



//            using (server.RequestStart(database))//开始连接数据库。
//            {
//                MongoCollection<BsonDocument> myCollection = database.GetCollection<BsonDocument>(collectionName);


//                result = myCollection.FindOneAs<T>(Query.EQ("_id", id));
//            }

//            return result;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="collectionName"></param>
//        /// <param name="query">条件查询。 调用示例：Query.Matches("Title", "感冒") 或者 Query.EQ("Title", "感冒") 或者Query.And(Query.Matches("Title", "感冒"),Query.EQ("Author", "yanc")) 等等</param>
//        /// <returns></returns>
//        public  T GetOne<T>(string collectionName, IMongoQuery query)
//        {
//            return GetOne<T>(MongoDbServer, MongoDbName, collectionName, query);
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="connectionString"></param>
//        /// <param name="databaseName"></param>
//        /// <param name="collectionName"></param>
//        /// <param name="query">条件查询。 调用示例：Query.Matches("Title", "感冒") 或者 Query.EQ("Title", "感冒") 或者Query.And(Query.Matches("Title", "感冒"),Query.EQ("Author", "yanc")) 等等</param>
//        /// <returns></returns>
//        public  T GetOne<T>(string connectionString, string databaseName, string collectionName, IMongoQuery query)
//        {
//            MongoServer server = MongoServer.Create(connectionString);

//            //获取数据库或者创建数据库（不存在的话）。
//            MongoDatabase database = server.GetDatabase(databaseName);

//            T result = default(T);

//            using (server.RequestStart(database))//开始连接数据库。
//            {
//                MongoCollection<BsonDocument> myCollection = database.GetCollection<BsonDocument>(collectionName);

//                if (null == query)
//                {
//                    result = myCollection.FindOneAs<T>();
//                }
//                else
//                {
//                    result = myCollection.FindOneAs<T>(query);
//                }
//            }

//            return result;
//        }

//        #endregion


//        #region 获取多个

//        public  List<T> GetAll<T>(string collectionName)
//        {
//            return GetAll<T>(MongoDbServer, MongoDbName, collectionName);
//        }

//        /// <summary>
//        /// 如果不清楚具体的数量，一般不要用这个函数。
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="collectionName"></param>
//        /// <returns></returns>
//        public  List<T> GetAll<T>(string connectionString, string databaseName, string collectionName)
//        {
//            MongoServer server = MongoServer.Create(connectionString);

//            //获取数据库或者创建数据库（不存在的话）。
//            MongoDatabase database = server.GetDatabase(databaseName);

//            List<T> result = new List<T>();

//            using (server.RequestStart(database))//开始连接数据库。
//            {
//                MongoCollection<BsonDocument> myCollection = database.GetCollection<BsonDocument>(collectionName);

//                foreach (T entity in myCollection.FindAllAs<T>())
//                {
//                    result.Add(entity);
//                }
//            }

//            return result;
//        }
//        public  List<T> GetAll<T>(string collectionName, IMongoQuery query, IMongoSortBy sortBy, int PageSize, int PageIndex, out long DataCount, params string[] fields)
//        {
//            return GetAll<T>(MongoDbServer, MongoDbName, collectionName, query, sortBy, PageSize, PageIndex,
//                             out DataCount, fields);
//        }
//        public  List<T> GetAll<T>(string collectionName, IMongoQuery query, IMongoSortBy sortBy, int PageSize, int PageIndex, out long DataCount)
//        {
//            return GetAll<T>(MongoDbServer, MongoDbName, collectionName, query, sortBy, PageSize, PageIndex,
//                             out DataCount, null);
//        }
//        public  List<T> GetAll<T>(string collectionName, IMongoQuery query, int PageSize, int PageIndex, out long DataCount)
//        {
//            return GetAll<T>(MongoDbServer, MongoDbName, collectionName, query, null, PageSize, PageIndex,
//                             out DataCount, null);
//        }
//        public  List<T> GetAll<T>(string collectionName, IMongoQuery query, int PageSize, int PageIndex, out long DataCount, params string[] fields)
//        {
//            return GetAll<T>(MongoDbServer, MongoDbName, collectionName, query, null, PageSize, PageIndex,
//                             out DataCount, fields);
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="connectionString"></param>
//        /// <param name="databaseName"></param>
//        /// <param name="collectionName"></param>
//        /// <param name="query">条件查询。 调用示例：Query.Matches("Title", "感冒") 或者 Query.EQ("Title", "感冒") 或者Query.And(Query.Matches("Title", "感冒"),Query.EQ("Author", "yanc")) 等等</param>
//        /// <param name="pagerInfo"></param>
//        /// <param name="sortBy">排序用的。调用示例：SortBy.Descending("Title") 或者 SortBy.Descending("Title").Ascending("Author")等等</param>
//        /// <param name="fields">只返回所需要的字段的数据。调用示例："Title" 或者 new string[] { "Title", "Author" }等等</param>
//        /// <returns></returns>
//        public  List<T> GetAll<T>(string connectionString, string databaseName, string collectionName, IMongoQuery query, IMongoSortBy sortBy, int PageSize, int PageIndex, out long DataCount, params string[] fields)
//        {
//            MongoServer server = MongoServer.Create(connectionString);

//            //获取数据库或者创建数据库（不存在的话）。
//            MongoDatabase database = server.GetDatabase(databaseName);

//            List<T> result = new List<T>();

//            using (server.RequestStart(database))//开始连接数据库。
//            {
//                MongoCollection<BsonDocument> myCollection = database.GetCollection<BsonDocument>(collectionName);

//                MongoCursor<T> myCursor;

//                if (null == query)
//                {
//                    myCursor = myCollection.FindAllAs<T>();
//                    //DataCount = myCursor.Count();
//                }
//                else
//                {
//                    myCursor = myCollection.FindAs<T>(query);
//                    //DataCount = myCursor.Count();
//                }

//                if (null != sortBy)
//                {
//                    myCursor.SetSortOrder(sortBy);
//                }

//                if (null != fields)
//                {
//                    myCursor.SetFields(fields);
//                }

//                foreach (T entity in myCursor.SetSkip((PageIndex - 1) * PageSize).SetLimit(PageSize))//.SetSkip(100).SetLimit(10)是指读取第一百条后的10条数据。
//                {
//                    result.Add(entity);
//                }
//                DataCount = myCursor.Count();

//            }

//            return result;
//        }
//        public  List<T> GetAll<T>(string collectionName, IMongoQuery query, IMongoSortBy sortBy, int Top, params string[] fields)
//        {
//            MongoServer server = MongoServer.Create(MongoDbServer);

//            //获取数据库或者创建数据库（不存在的话）。
//            MongoDatabase database = server.GetDatabase(MongoDbName);

//            List<T> result = new List<T>();

//            using (server.RequestStart(database))//开始连接数据库。
//            {
//                MongoCollection<BsonDocument> myCollection = database.GetCollection<BsonDocument>(collectionName);

//                MongoCursor<T> myCursor;

//                if (null == query)
//                {
//                    myCursor = myCollection.FindAllAs<T>();

//                }
//                else
//                {
//                    myCursor = myCollection.FindAs<T>(query);

//                }

//                if (null != sortBy)
//                {
//                    myCursor.SetSortOrder(sortBy);
//                }

//                if (null != fields)
//                {
//                    myCursor.SetFields(fields);
//                }

//                foreach (T entity in myCursor.SetLimit(Top))//.SetSkip(100).SetLimit(10)是指读取第一百条后的10条数据。
//                {
//                    result.Add(entity);
//                }


//            }

//            return result;
//        }
//        #endregion


//        #region 索引
//        public  void CreateIndex(string collectionName, params string[] keyNames)
//        {
//            CreateIndex(MongoDbServer, MongoDbName, collectionName, keyNames);
//        }

//        public  void CreateIndex(string connectionString, string databaseName, string collectionName, params string[] keyNames)
//        {
//            SafeModeResult result = new SafeModeResult();

//            if (null == keyNames)
//            {
//                return;
//            }

//            MongoServer server = MongoServer.Create(connectionString);

//            //获取数据库或者创建数据库（不存在的话）。
//            MongoDatabase database = server.GetDatabase(databaseName);



//            using (server.RequestStart(database))//开始连接数据库。
//            {
//                MongoCollection<BsonDocument> myCollection = database.GetCollection<BsonDocument>(collectionName);
//                if (!myCollection.IndexExists(keyNames))
//                {
//                    myCollection.EnsureIndex(keyNames);
//                }
//            }

//        }
//        #endregion
//    }
//}
