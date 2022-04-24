//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Web;
//using STSdb4.Database;

//namespace EbSite.Core.STSdbUtils
//{
//    public class STSdbHelper
//    {
//        private static object _SyncRoot = new object();
//        private static IStorageEngine _GetDbInstance;
//        public static IStorageEngine DB
//        {
//            get
//            {

//                if (_GetDbInstance == null)
//                {
//                    lock (_SyncRoot)
//                    {
//                        if (_GetDbInstance == null)
//                        {
//                            string ddd = MongoDbName;
//                            _GetDbInstance = STSdb.FromFile(MongoDbName);

//                        }
//                    }
//                }
//                return _GetDbInstance;
//            }
//        }
//        private static string MongoDbName
//        {
//            get
//            {
//                if (!Equals(HttpContext.Current, null))
//                {
//                    return HttpContext.Current.Server.MapPath("~/Datastore/cache.dat");
//                }
//                else
//                {
//                    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Datastore\\cache.dat");
//                }
//            }

//        }
//        //static private string MongoDbName
//        //{
//        //    get { return "stsdb4.dat"; }
//        //}

//        public static void InsertOne<T, K>(string TableName, T entity) where T : STSdbEntityBase<K>
//        {
//            if (Equals(entity, null))
//                return;
//            ITable<K, T> table = DB.OpenXTable<K, T>(TableName);

//            table.InsertOrIgnore(entity.Id, entity);

//            DB.Commit();
//        }
//        public static void Inserts<T, K>(string TableName, List<T> lstEntitys) where T : STSdbEntityBase<K>
//        {
//            if (lstEntitys.Count > 0)
//            {
//                ITable<K, T> table = DB.OpenXTable<K, T>(TableName);
//                foreach (T entity in lstEntitys)
//                {
//                    table[entity.Id] = entity;
//                }

//                DB.Commit();
//            }


//        }
//        public static void Clear<T, K>(string TableName) where T : STSdbEntityBase<K>
//        {
//            ITable<K, T> table = DB.OpenXTable<K, T>(TableName);

//            table.Clear();
//        }
//        public static List<T> GetList<T, K>(string TableName) where T : STSdbEntityBase<K>
//        {
//            ITable<K, T> table = DB.OpenXTable<K, T>(TableName);



//            List<T> lst = new List<T>();
//            foreach (var t in table)
//            {
//                lst.Add(t.Value);
//            }

//            return lst;

//        }

//        public static void Update<T, K>(string TableName, T model) where T : STSdbEntityBase<K>
//        {
//            ITable<K, T> table = DB.OpenXTable<K, T>(TableName);
//            table[model.Id] = model;
//            DB.Commit();

//        }

//        public static T GetEntity<T, K>(string TableName, K key) where T : STSdbEntityBase<K>
//        {
//            ITable<K, T> table = DB.OpenXTable<K, T>(TableName);

//            return table.Find(key);

//        }

//        public static T GetEntityNull<T, K>(string TableName, K key) where T : STSdbEntityBase<K>
//        {
//            T model = null;
//            ITable<K, T> table = DB.OpenXTable<K, T>(TableName);

//            return table.TryGetOrDefault(key, model);

//        }
//        public static long GetCount<T, K>(string TableName) where T : STSdbEntityBase<K>
//        {
//            ITable<K, T> table = DB.OpenXTable<K, T>(TableName);

//            return table.Count();
//        }

//        public static void DeleteTable(string TableName)
//        {
//            DB.Delete(TableName);

//        }

//        public static void DeleteOne<T, K>(string TableName, K Id) where T : STSdbEntityBase<K>
//        {

//            ITable<K, T> table = DB.OpenXTable<K, T>(TableName);

//            table.Delete(Id);
//            DB.Commit();
//        }
//        public static bool Exists<T, K>(string TableName, K Id) where T : STSdbEntityBase<K>
//        {
//            ITable<K, T> table = DB.OpenXTable<K, T>(TableName);
//            return table.Exists(Id);
//        }



//        public static ITable<K, T> GetTable<T, K>(string TableName) where T : STSdbEntityBase<K>
//        {
//            return DB.OpenXTable<K, T>(TableName);
//        }

//    }
//}