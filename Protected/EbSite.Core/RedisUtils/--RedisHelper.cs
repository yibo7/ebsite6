//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using EbSite.Base;
//using ServiceStack.Redis;
//using ServiceStack.Redis.Generic;

//namespace EbSite.Core.RedisUtils
//{
//    public class RedisHelper:IDisposable
//    { 
//        public RedisClient Redis;//缓存池
//        public RedisClient OnlyReadRedis;//只读缓存池
//        private PooledRedisClientManager prcm;
//        private static object _SyncRoot = new object();
//        //默认缓存过期时间单位秒
//        public int secondsTimeOut = 30 * 60;

//        /// <summary>
//        /// 缓冲池
//        /// </summary>
//        /// <param name="readWriteHosts"></param>
//        /// <param name="readOnlyHosts"></param>
//        /// <returns></returns>
//        public static PooledRedisClientManager CreateManager(string[] readWriteHosts, string[] readOnlyHosts)
//        {
//            return new PooledRedisClientManager(readWriteHosts, readOnlyHosts,
//            new RedisClientManagerConfig
//            {
//                MaxWritePoolSize = readWriteHosts.Length * 5,
//                MaxReadPoolSize = readOnlyHosts.Length * 5,
//                AutoStart = true,
//            });
//        }

//        public RedisHelper(string[] hostwrite, string[] hostread)
//        {
//            prcm = CreateManager(hostwrite, hostread);
//            OnlyReadRedis = prcm.GetReadOnlyClient() as RedisClient;
        
//            Redis = prcm.GetClient() as RedisClient;
//        }


//        /// <summary>
//        /// 构造函数
//        /// </summary>
//        /// <param name="openpool">是否开启缓冲池</param>
//      /// <param name="host">主机</param>
//      /// <param name="port">端口</param>
//        public RedisHelper(bool openpool, string host, int port)
//        {

//            if (openpool)
//            {
//                string hostport = string.Concat(host, ":", port);
//                prcm = CreateManager(new string[] { hostport }, new string[] { hostport });
//                Redis = prcm.GetClient() as RedisClient;
//            }
//            else
//            {
//                Redis = new RedisClient(host, port);

                 
//            }
//        }

//        #region Key/Value存储
//        /// <summary>
//        /// 设置缓存
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="key">缓存建</param>
//        /// <param name="t">缓存值</param>
//        /// <param name="timeout">过期时间，单位秒,-1：不过期，0：默认过期时间</param>
//        /// <returns></returns>
//        public bool Set<T>(string key, T t, int timeout = 0)
//        {
//            lock (_SyncRoot)
//            {
//                //key = KeyFormat(key);
//                if (timeout >= 0)
//                {
//                    if (timeout > 0)
//                    {
//                        secondsTimeOut = timeout;
//                    }
//                    Redis.Expire(key, secondsTimeOut);
//                }
//                //string sss = t.GetType().Name;
//                return Redis.Add<T>(key, t);
//            }
           
//        }
//        public bool Set<T>(string key, T t, DateTime timeout)
//        {
//            lock (_SyncRoot)
//            {
//                //string sss = t.GetType().Name;
//                //key = KeyFormat(key);
//                return Redis.Add<T>(key, t, timeout);
//            }
//        }

//        public bool Set(string key, object t, TimeSpan ts)
//        {
//            lock (_SyncRoot)
//            {
//                byte[] saved_content = EBSerializer.Serialize(t);

//                Redis.SetEx(key, (int)ts.TotalSeconds, saved_content);

//                return true;
//            }
//        }
//        /// <summary>
//        /// 获取
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="key"></param>
//        /// <returns></returns>
//        public T Get<T>(string key)
//        {
//            lock (_SyncRoot)
//            {
//                //key = KeyFormat(key);
//                return OnlyReadRedis.Get<T>(key);
//            }
//        }
//        public object Get(string key)
//        {
//            lock (_SyncRoot)
//            { 
//                byte[] saved_content = OnlyReadRedis.Get(key);
//                if (saved_content == null)
//                    return null;

//                return EBSerializer.DeSerialize(saved_content);
//            }
//        }
//        /// <summary>
//        /// 删除
//        /// </summary>
//        /// <param name="key"></param>
//        /// <returns></returns>
//        public bool Remove(string key)
//        {
//            lock (_SyncRoot)
//            {
//                //key = KeyFormat(key);
                
//                return Redis.Remove(key);
//            }
//        }

//        public bool Add<T>(string key, T t, int timeout)
//        {
//            lock (_SyncRoot)
//            {
//                //key = KeyFormat(key);
//                if (timeout >= 0)
//                {
//                    if (timeout > 0)
//                    {
//                        secondsTimeOut = timeout;
//                    }
//                    Redis.Expire(key, secondsTimeOut);
//                }
//                return Redis.Add<T>(key, t);
//            }
//        }

//        //private string KeyFormat(string key)
//        //{
//        //    return Utils.MD5(key);
//        //    //key = key.Replace(" ", "");
//        //    //key = key.Replace("'", "");

//        //    //return key;
//        //}

//        public List<string> GetAllKeys()
//        {
//           return OnlyReadRedis.GetAllKeys();
//        }

//        public void DeleteAll()
//        {
//              Redis.FlushAll();
//        }
//        #endregion

//        #region 链表操作
//        /// <summary>
//        /// 根据IEnumerable数据添加链表
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="listId"></param>
//        /// <param name="values"></param>
//        /// <param name="timeout"></param>
//        public void AddList<T>(string listId, IEnumerable<T> values, int timeout = 0)
//        {
//            Redis.Expire(listId,60);
//            IRedisTypedClient<T> iredisClient = Redis.As<T>();
//            if (timeout >= 0)
//            {
//                if (timeout > 0)
//                {
//                    secondsTimeOut = timeout;
//                }
//                Redis.Expire(listId, secondsTimeOut);
//            }
//            var redisList = iredisClient.Lists[listId];
//            redisList.AddRange(values);
//            iredisClient.Save();
//        }
//        /// <summary>
//        /// 添加单个实体到链表中
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="listId"></param>
//        /// <param name="Item"></param>
//        /// <param name="timeout"></param>
//        public void AddEntityToList<T>(string listId, T Item, int timeout = 0)
//        {
//            IRedisTypedClient<T> iredisClient = Redis.As<T>();
//            if (timeout >= 0)
//            {
//                if (timeout > 0)
//                {
//                    secondsTimeOut = timeout;
//                }
//                Redis.Expire(listId, secondsTimeOut);
//            }
//            var redisList = iredisClient.Lists[listId];
//            redisList.Add(Item);
//            iredisClient.Save();
//        }
//        /// <summary>
//        /// 获取链表
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="listId"></param>
//        /// <returns></returns>
//        public IEnumerable<T> GetList<T>(string listId)
//        {
//            IRedisTypedClient<T> iredisClient = Redis.As<T>();
//            return iredisClient.Lists[listId];
//        }
//        /// <summary>
//        /// 在链表中删除单个实体
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="listId"></param>
//        /// <param name="t"></param>
//        public void RemoveEntityFromList<T>(string listId, T t)
//        {
//            IRedisTypedClient<T> iredisClient = Redis.As<T>();
//            var redisList = iredisClient.Lists[listId];
//            redisList.RemoveValue(t);
//            iredisClient.Save();
//        }
//        /// <summary>
//        /// 根据lambada表达式删除符合条件的实体
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="listId"></param>
//        /// <param name="func"></param>
//        public void RemoveEntityFromList<T>(string listId, Func<T, bool> func)
//        {
//            using (IRedisTypedClient<T> iredisClient = Redis.As<T>())
//            {
//                var redisList = iredisClient.Lists[listId];
//                T value = redisList.Where(func).FirstOrDefault();
//                redisList.RemoveValue(value);
//                iredisClient.Save();

                
//            }
//        }

//        public void InvalidateCache(string sCategory)
//        {
//             //当缓存数据非常大的时候会导致redis非常慢
//            //using (IRedisClient r =prcm.GetClient()  )
//            //{

//            //    List<string> keys = r.SearchKeys(sCategory + ":*");
//            //    r.RemoveAll(keys);
//            //}
 
//        }
//        #endregion

//        //释放资源
//        public void Dispose()
//        {
//            if (Redis != null)
//            {
//                Redis.Dispose();
//                Redis = null;
//            }
//            GC.Collect();
//        }
//   }
//}

 

