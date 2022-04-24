using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ServiceStack.Redis;
using ServiceStack.Redis.Support;

namespace EbSite.Core.RedisUtils
{
    public class RedisHelper
    {
        private static object _SyncRoot = new object();
        private static XSSerializer _dbSerialize;
        /// <summary>
        /// 可以在外面改变序列方法
        /// </summary>
        virtual public XSSerializer dbSerialize
        {
            get
            {
                if (_dbSerialize == null)
                {
                    lock (_SyncRoot)
                    {
                        if (_dbSerialize == null)
                        {
                            _dbSerialize = new XSSerializer();
                        }
                    }
                }
                return _dbSerialize;
            }

        }
        

        public RedisHelper(string[] aRedisHostList,int iRedisMaxReadPool=10,int iRedisMaxWritePool=10)
        {

            // 初始化Redis的连接池 静态化的Redis连接池，将来这里可能会很复杂，根据KEY的不同来找不同的服务器集群
            Hashtable ht = new Hashtable();

            Dictionary<string, string> RedisHostList = new Dictionary<string, string>();
            //RedisHostList.Add("s1", "192.168.3.14");
            //RedisHostList.Add("s2", "192.168.3.14");
        

            for (int i = 0; i < aRedisHostList.Length; i++)
            {
                RedisHostList.Add("xsrds" + Convert.ToInt32(i + 1), aRedisHostList[i]);
            }


            foreach (KeyValuePair<string, string> host in RedisHostList)
            {
                string this_key_space = host.Key;
                string this_host_ip = host.Value;

                ServiceStack.Redis.RedisClientManagerConfig PoolConfig = new RedisClientManagerConfig();
                PoolConfig.MaxReadPoolSize = iRedisMaxReadPool;
                PoolConfig.MaxWritePoolSize = iRedisMaxWritePool;

                PooledRedisClientManager this_client = new PooledRedisClientManager(new string[] { this_host_ip }, new string[] { this_host_ip }, PoolConfig);

                ht.Add(this_key_space, this_client);
            }

            REDIS_CLIENT_POOL = ht;
        }
        /// <summary>
        /// 静态化的Redis连接池，将来这里可能会很复杂，根据KEY的不同来找不同的服务器集群c
        /// </summary>
        public  Hashtable REDIS_CLIENT_POOL;
         


        /// <summary>
        /// 从当前的池子里为一个keyspace找一个客户端
        /// </summary>
        /// <param name="key_space"></param>
        /// <returns></returns>
        private  RedisNativeClient GetNativeClientForKeySpace(string key_space)
        {
            PooledRedisClientManager this_client = (PooledRedisClientManager)REDIS_CLIENT_POOL[key_space];

            return (RedisNativeClient)(this_client.GetClient());
        }



        /// <summary>
        /// 将一个字符串中的空格和冒号转义，并trim，然后返回，null会返回空字符串
        /// </summary>
        /// <param name="instr"></param>
        /// <returns></returns>
        public  string NormalizeRedisStr(string instr)
        {
            if (instr == null)
                return "";

            return instr.Trim().Replace(" ", "_").Replace(":", "_");

        }

        //******************************以上是有关连接池的部分**********************************//

        /// <summary>
        /// 调用Redis的Lpush，向一个队列插入一条数据
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <returns></returns>
        public  long LTLPushObj(string key_space, string key_id, object push_obj)
        {
            if (key_id == null || key_space == null)
                return 0;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                return RNC.LPush(redis_key, dbSerialize.Serialize(push_obj));
            }
        }
        /// <summary>
        /// 调用Redis的LPop,从一个队列中取数据
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <returns></returns>
        public  object LTLPopObj(string key_space, string key_id)
        {
            if (key_id == null || key_space == null)
                return 0;
            string redis_key = key_space + ":" + key_id;
            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {

                byte[] pop_result = RNC.LPop(redis_key);
                if (pop_result == null)
                    return null;
                return dbSerialize.DeSerialize(pop_result);
            }
        }
        /// <summary>
        /// 调用Redis的LIndex,从一个队列中取指定索引的 数据 
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <returns></returns>
        public  object LTLIndexObj(string key_space, string key_id, int Indexes)
        {
            if (key_id == null || key_space == null)
                return 0;
            string redis_key = key_space + ":" + key_id;
            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {

                byte[] pop_result = RNC.LIndex(redis_key, Indexes);
                if (pop_result == null)
                    return null;
                return dbSerialize.DeSerialize(pop_result);
            }
        }

        /// <summary>
        /// 调用Redis的Rpush，向一个队列插入一条数据
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <returns></returns>
        public  long LTRPushObj(string key_space, string key_id, object push_obj)
        {
            if (key_id == null || key_space == null)
                return 0;

            string redis_key = key_space + ":" + key_id;

            byte[] d = dbSerialize.Serialize(push_obj);
            int h = d.Length;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                return RNC.RPush(redis_key, dbSerialize.Serialize(push_obj));
            }
        }

        /// <summary>
        /// 获取一个列表的长度
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <returns></returns>
        public  long LTLLen(string key_space, string key_id)
        {
            if (key_id == null || key_space == null)
                return 0;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                return RNC.LLen(redis_key);
            }
        }


        /// <summary>
        /// 获取一个列表中的某一些值
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public  ArrayList LTLRangeObj(string key_space, string key_id, int start, int end)
        {
            if (key_id == null || key_space == null)
                return null;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                byte[][] range_result = RNC.LRange(redis_key, start, end);

                if (range_result == null)
                    return null;

                ArrayList al_return = new ArrayList();

                for (int i = 0; i < range_result.Length; i++)
                    al_return.Add(dbSerialize.DeSerialize(range_result[i]));

                return al_return;
            }
        }

        /// <summary>
        /// 调用Redis的RPop，从一个队列中取数据
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <returns></returns>
        public  object LTRPopObj(string key_space, string key_id)
        {
            if (key_id == null || key_space == null)
                return 0;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                byte[] pop_result = RNC.RPop(redis_key);
                if (pop_result == null)
                    return null;

                return dbSerialize.DeSerialize(pop_result);
            }
        }

        /// <summary>
        /// 给一个Zset增加一个对象和分数，如果不存在就添加，返回1表示成功，0表示不成功 
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <returns></returns>
        public  long LTZAdd(string key_space, string key_id, double member_val, string member_key)
        {
            if (key_id == null || key_space == null || member_key == null)
                return 0;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                return RNC.ZAdd(redis_key, member_val, Encoding.UTF8.GetBytes(member_key));
            }
        }

        /// <summary>
        /// 从一个Zset里删除一个
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <returns></returns>
        public  long LTZRem(string key_space, string key_id, string member_key)
        {
            if (key_id == null || key_space == null)
                return 0;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                return RNC.ZRem(redis_key, Encoding.UTF8.GetBytes(member_key));
            }
        }

        /// <summary>
        /// 获取一个Zset对象内元素的数目
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <param name="member_val"></param>
        /// <param name="member_key"></param>
        /// <returns></returns>
        public  long LTZCard(string key_space, string key_id)
        {
            if (key_id == null || key_space == null)
                return 0;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                return RNC.ZCard(redis_key);
            }
        }



        /// <summary>
        /// 删除一个Zset里特定排名的元素，0表示最小的元素，-1表示最大的元素
        /// 从min开始到max结束，包括min和max本身，返回值是删除的数目
        /// </summary>
        /// <returns></returns>
        public  long LTZRemRangeByRank(string key_space, string key_id, int min, int max)
        {
            if (key_id == null || key_space == null)
                return 0;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                return RNC.ZRemRangeByRank(redis_key, min, max);
            }
        }


        /// <summary>
        /// 返回一个Zset在排序范围min-max的结果0表示最小的元素，-1表示最大的元素
        /// 从min开始到max结束，包括min和max本身，返回一个arraylist，memberkey都是string
        /// direction是ASC表示正向，从小到大，DESC（或任何一个不是ASC的值）表示逆向，从大到小
        /// with_score表示是否带着score
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public  string[] LTZRangeByScore(string key_space, string key_id, double min, double max, string direction, bool with_score)
        {
            if (key_id == null || key_space == null)
                return null;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                byte[][] range_result;

                if (with_score)
                    range_result = direction == "ASC" ? RNC.ZRangeByScoreWithScores(redis_key, min, max, null, null) : RNC.ZRevRangeByScoreWithScores(redis_key, min, max, null, null);
                else
                    range_result = direction == "ASC" ? RNC.ZRangeByScore(redis_key, min, max, null, null) : RNC.ZRevRangeByScore(redis_key, min, max, null, null);

                if (range_result == null)
                    return null;

                List<string> str_result = new List<string>(range_result.Length);

                for (int i = 0; i < range_result.Length; i++)
                    str_result.Add(Encoding.UTF8.GetString(range_result[i]));

                return str_result.ToArray();
            }
        }

        /// <summary>
        /// 返回一个Zset在排序范围min-max的结果0表示最小的元素，-1表示最大的元素
        /// 从min开始到max结束，包括min和max本身，返回一个arraylist，memberkey都是string
        /// direction是ASC表示正向，从小到大，DESC（或任何一个不是ASC的值）表示逆向，从大到小
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public  string[] LTZRangeByScore(string key_space, string key_id, double min, double max, string direction)
        {
            return LTZRangeByScore(key_space, key_id, min, max, direction, false);//缺省不带score

        }


        /// <summary>
        /// 返回一个Zset在排序范围min-max的结果0表示最小的元素，-1表示最大的元素
        /// 从min开始到max结束，包括min和max本身，返回一个arraylist，memberkey都是string
        /// direction是ASC表示正向，从小到大，DESC（或任何一个不是ASC的值）表示逆向，从大到小
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public  ArrayList LTZRange(string key_space, string key_id, int min, int max, string direction, bool with_score)
        {
            if (key_id == null || key_space == null)
                return null;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                byte[][] range_result;
                if (with_score)
                    range_result = direction == "ASC" ? RNC.ZRangeWithScores(redis_key, min, max) : RNC.ZRevRangeWithScores(redis_key, min, max);
                else
                    range_result = direction == "ASC" ? RNC.ZRange(redis_key, min, max) : RNC.ZRevRange(redis_key, min, max);

                if (range_result == null)
                    return null;

                ArrayList al = new ArrayList(range_result.Length);
                for (int i = 0; i < range_result.Length; i++)
                    al.Add(Encoding.UTF8.GetString(range_result[i]));

                return al;
            }
        }

        /// <summary>
        /// 返回一个Zset在排序范围min-max的结果0表示最小的元素，-1表示最大的元素
        /// 从min开始到max结束，包括min和max本身，返回一个arraylist，memberkey都是string
        /// direction是ASC表示正向，从小到大，DESC（或任何一个不是ASC的值）表示逆向，从大到小
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public  ArrayList LTZRange(string key_space, string key_id, int min, int max, string direction)
        {
            return LTZRange(key_space, key_id, min, max, direction, false);//缺省木有
        }


        /// <summary>
        /// 给一个Zset的一个对象增加分数，如果不存在就添加，返回增加后的值，member_key就用string吧，反正都是bytes
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <returns></returns>
        public  double LTZIncrBy(string key_space, string key_id, double member_val, string member_key)
        {
            if (key_id == null || key_space == null || member_key == null)
                return 0;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                return RNC.ZIncrBy(redis_key, member_val, Encoding.UTF8.GetBytes(member_key));
            }
        }


        /// <summary>
        /// ZUnionStore的包装
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="dest_key"></param>
        /// <param name="src_key_list"></param>
        /// <returns></returns>
        public  long LTZUnionStore(string key_space, string dest_key, string[] src_key_list)
        {

            string redis_key = key_space + ":" + dest_key;
            string[] new_key_list = new string[src_key_list.Length];
            for (int i = 0; i < new_key_list.Length; i++)
                new_key_list[i] = key_space + ":" + src_key_list[i];

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                return RNC.ZUnionStore(redis_key, new_key_list);
            }

        }


        //******************************以下是有关哈希的部分************************************//

        /// <summary>
        /// 判断一个哈希表中某个key是否存在
        /// 如果哈希表不存在或者key不存在都返回false，都存在则返回1
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <param name="hash_key"></param>
        /// <returns></returns>
        public  bool LTHashExists(string key_space, string key_id, string hash_key)
        {
            if (key_id == null || key_space == null || hash_key == null)
                return false;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                long rt = RNC.HExists(redis_key, Encoding.UTF8.GetBytes(hash_key));
                return (rt == 1);
            }
        }

        /// <summary>
        /// 获得一个哈希表的长度，如果哈希表不存在会返回0，如果类型不对会可能会抛异常。
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <returns></returns>
        public  long LTHashLen(string key_space, string key_id)
        {
            if (key_id == null || key_space == null)
                return 0;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                return RNC.HLen(redis_key);
            }

        }

        /// <summary>
        /// 检查一个哈希键是否存在，互斥方式的，如果不存在就保存
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <param name="hash_key"></param>
        /// <returns></returns>
        public  long LTHashSetNX(string key_space, string key_id, object hash_key, object hash_value)
        {
            if (key_id == null || key_space == null || hash_key == null)
                return 0;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                return RNC.HSetNX(redis_key, dbSerialize.Serialize(hash_key), dbSerialize.Serialize(hash_value));
            }
        }

        /// <summary>
        /// 获取Hash表中部分key和值
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <returns></returns>
        public  Hashtable LTHashGetMultipleObj(string key_space, string key_id, string[] key_list)
        {
            if (key_id == null || key_space == null)
                return null;

            string redis_key = key_space + ":" + key_id;

            byte[][] key_list_bytearray = new byte[key_list.Length][];
            for (int i = 0; i < key_list.Length; i++)
                key_list_bytearray[i] = Encoding.UTF8.GetBytes(key_list[i]);

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                byte[][] hash_result = RNC.HMGet(redis_key, key_list_bytearray);
                if (hash_result == null)
                    return null;

                Hashtable ht_result = new Hashtable();

                for (int i = 0; i < hash_result.Length; i++)
                {
                    if (hash_result[i] == null || i > key_list.Length) //这个得考虑木有的情况了 
                        continue;

                    object this_value = dbSerialize.DeSerialize(hash_result[i]);
                    ht_result.Add(key_list[i], this_value);
                }

                return ht_result;
            }
        }


        /// <summary>
        /// 删除Hash表里的一个独立的对象
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <param name="hash_key"></param>
        /// <returns></returns>
        public  bool LTHashDelKey(string key_space, string key_id, string hash_key)
        {
            if (key_id == null || key_space == null || key_id == null)
                return false;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                RNC.HDel(redis_key, Encoding.UTF8.GetBytes(hash_key));
                return true;
            }
        }


        /// <summary>
        /// 获得一个完整哈希
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <returns></returns>
        public  Hashtable LTHashGetAll(string key_space, string key_id)
        {
            if (key_id == null || key_space == null)
                return null;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                byte[][] hash_result = RNC.HGetAll(redis_key);
                if (hash_result == null)
                    return null;

                Hashtable ht_result = new Hashtable();

                for (int i = 0; i < hash_result.Length; i += 2)
                {
                    string this_key = Encoding.UTF8.GetString(hash_result[i]);
                    string this_value = Encoding.UTF8.GetString(hash_result[i + 1]);
                    ht_result.Add(this_key, this_value);
                }

                return ht_result;
            }
        }

        /// <summary>
        /// 设置一个哈希表里的字符串，key,value等字符串都不能为空
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="obj_id"></param>
        /// <param name="obj_string"></param>
        /// <returns></returns>
        public  bool LTHashSet(string key_space, string key_id, string key_string, string value_string)
        {
            if (key_id == null || key_space == null || key_string == null || value_string == null)
                return false;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                RNC.HSet(redis_key, Encoding.UTF8.GetBytes(key_string), Encoding.UTF8.GetBytes(value_string));
                return true;
            }
        }


        /// <summary>
        /// 获得一个哈希里的字符串对象
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="obj_id"></param>
        /// <returns></returns>
        public  string LTHashGet(string key_space, string key_id, string hash_key)
        {
            if (key_id == null || key_space == null || hash_key == null)
                return null;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {

                byte[] hash_value = RNC.HGet(redis_key, Encoding.UTF8.GetBytes(hash_key));

                if (hash_value == null)
                    return null;

                return Encoding.UTF8.GetString(hash_value);
            }
        }


        /// <summary>
        /// 获取一个被单个object序列化后存储在redis里的hash表
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <returns></returns>
        public  Hashtable LTHashGetAllObj(string key_space, string key_id)
        {
            if (key_id == null || key_space == null)
                return null;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                byte[][] hash_result = RNC.HGetAll(redis_key);
                if (hash_result == null)
                    return null;

                Hashtable ht_result = new Hashtable();

                for (int i = 0; i < hash_result.Length; i += 2)
                {
                    string this_key = Encoding.UTF8.GetString(hash_result[i]);
                    object this_value = dbSerialize.DeSerialize(hash_result[i + 1]);
                    ht_result.Add(this_key, this_value);
                }

                return ht_result;
            }
        }
        /// <summary>
        /// 获取一个被单个object序列化后存储在redis里的hash表
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <returns></returns>
        public  Hashtable LTHashGetAllObj_CanReturnNull(string key_space, string key_id)
        {
            if (key_id == null || key_space == null)
                return null;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                byte[][] hash_result = RNC.HGetAll(redis_key);
                if (hash_result == null)
                    return null;
                if (hash_result.Length == 0)
                    return null;
                Hashtable ht_result = new Hashtable();

                for (int i = 0; i < hash_result.Length; i += 2)
                {
                    string this_key = Encoding.UTF8.GetString(hash_result[i]);
                    object this_value = dbSerialize.DeSerialize(hash_result[i + 1]);
                    ht_result.Add(this_key, this_value);
                }

                return ht_result;
            }
        }

        /// <summary>
        /// 获取Redis Hash表里的一个对象
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <param name="hash_key"></param>
        /// <returns></returns>
        public  object LTHashGetSingleObj(string key_space, string key_id, string hash_key)
        {
            if (key_id == null || key_space == null || hash_key == null)
                return null;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                byte[] hash_obj = RNC.HGet(redis_key, Encoding.UTF8.GetBytes(hash_key));
                if (hash_obj == null)
                    return null;

                return dbSerialize.DeSerialize(hash_obj);

            }
        }


        /// <summary>
        /// 给Hash表保存一个独立的对象，如果key存在就覆盖，不存在就写入
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <param name="hash_key"></param>
        /// <param name="hash_obj"></param>
        /// <returns></returns>
        public  bool LTHashSaveSingleObj(string key_space, string key_id, string hash_key, object hash_obj)
        {

            if (key_id == null || key_space == null || key_id == null || hash_obj == null)
                return false;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                long rt = RNC.HSet(redis_key, Encoding.UTF8.GetBytes(hash_key), dbSerialize.Serialize(hash_obj));
                return rt == 1;
            }
        }
        /// <summary>
        /// 给Hash表保存一个独立的对象，如果key存在就覆盖，不存在就写入 - add by robin (Redis新对象写入返回1，老对象更新返回0，返回bool，逻辑不正确)
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <param name="hash_key"></param>
        /// <param name="hash_obj"></param>
        /// <returns></returns>
        public  long LTHashSaveOrUpdateSingleObj(string key_space, string key_id, string hash_key, object hash_obj)
        {
            if (key_id == null || key_space == null || key_id == null || hash_obj == null)
            {
                return -1;
            }
            string redis_key = key_space + ":" + key_id;
            long rt = -1;
            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                rt = RNC.HSet(redis_key, Encoding.UTF8.GetBytes(hash_key), dbSerialize.Serialize(hash_obj));
            }
            return rt;
        }


        /// <summary>
        /// 给Hash表保存一个独立的对象，如果key存在就覆盖，不存在就写入
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <param name="hash_key"></param>
        /// <param name="hash_obj"></param>
        /// <returns></returns>
        public  bool LTHashSaveSingleObjNX(string key_space, string key_id, string hash_key, object hash_obj)
        {

            if (key_id == null || key_space == null || key_id == null || hash_obj == null)
                return false;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                long rt = RNC.HSetNX(redis_key, Encoding.UTF8.GetBytes(hash_key), dbSerialize.Serialize(hash_obj));
                return rt == 1;
            }
        }

        /// <summary>
        /// 保存一个Hash表所有的对象并且设置过期时间
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <param name="ht"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        public  int LTHashSaveAllObj(string key_space, string key_id, Hashtable ht, TimeSpan ts)
        {
            int rt = LTHashSaveAllObj(key_space, key_id, ht);
            if (rt == 0)
                return rt;

            LTExpireKey(key_space, key_id, ts);

            return rt;
        }

        /// <summary>
        /// 把一个哈希表里的所有对象序列化保存成一个redis hash
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <param name="ht"></param>
        /// <returns></returns>
        public  int LTHashSaveAllObj(string key_space, string key_id, Hashtable ht)
        {
            if (key_id == null || key_space == null)
                return 0;

            int total_count = 0;
            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                foreach (DictionaryEntry de in ht)
                {
                    string key_string = de.Key.ToString(); //只考虑string类型的key
                    object value_obj = de.Value;

                    RNC.HSet(redis_key, Encoding.UTF8.GetBytes(key_string), dbSerialize.Serialize(value_obj));

                    total_count++;
                }

            }

            return total_count;
        }


        /// <summary>
        /// 把一个哈希表里的所有对象序列化保存成一个redis hash
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <param name="ht"></param>
        /// <returns></returns>
        public  long LTHashIncBy(string key_space, string key_id, string hash_key, int num)
        {
            if (key_id == null || key_space == null)
                return 0;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                return RNC.HIncrby(redis_key, Encoding.UTF8.GetBytes(hash_key), num);
            }

        }




        /// <summary>
        /// 获取一个Set的数目
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <returns></returns>
        public  long LTGetSetNum(string key_space, string key_id)
        {
            if (key_id == null || key_space == null)
                return 0;


            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                return RNC.SCard(redis_key);
            }
        }

        /// <summary>
        /// 在某个Key_Space里把一个key改名
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="old_key"></param>
        /// <param name="new_key"></param>
        /// <returns></returns>
        public  bool LTRenameKey(string key_space, string old_key, string new_key)
        {
            if (old_key == null || new_key == null || key_space == null)
                return false;

            string old_redis_key = key_space + ":" + old_key;
            string new_redis_key = key_space + ":" + new_key;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                RNC.Rename(old_redis_key, new_redis_key);
                return true;
            }
        }



        /// <summary>
        /// 判断一个key是否存在 
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <returns></returns>
        public  bool LTExistsKey(string key_space, string key_id)
        {
            if (key_id == null || key_space == null)
                return false;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                long rt = RNC.Exists(redis_key);
                return (rt == 1);
            }
        }


        /// <summary>
        /// 获得符合一个Pattern的Key列表
        /// 返回key_space:后面的部分
        /// </summary>
        /// <param name="key_pattern"></param>
        /// <returns></returns>
        public  string[] LTKeys(string key_space, string key_pattern)
        {
            if (key_pattern == null || key_space == null)
                return null;

            string redis_key_pattern = key_space + ":" + key_pattern;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                byte[][] key_result = RNC.Keys(redis_key_pattern);
                if (key_result == null)
                    return null;

                List<string> str_result = new List<string>(key_result.Length);
                int start_length = key_space.Length + 1;

                for (int i = 0; i < key_result.Length; i++)
                {
                    string this_key = Encoding.UTF8.GetString(key_result[i]);
                    str_result.Add(this_key.Substring(start_length));
                }

                return str_result.ToArray();
            }
        }


        /// <summary>
        /// 得到一个Key的类型
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public  string LTType(string key_space, string key_id)
        {
            if (key_id == null || key_space == null)
                return null;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                return RNC.Type(redis_key);
            }


        }


        /// <summary>
        /// 设置一个字符串，字符串不能为空，可以为空字符串？
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="obj_id"></param>
        /// <param name="obj_string"></param>
        /// <returns></returns>
        public  bool LTSetString(string key_space, string key_id, string key_string)
        {
            if (key_id == null || key_space == null || key_string == null)
                return false;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                RNC.Set(redis_key, Encoding.UTF8.GetBytes(key_string));
                return true;
            }
        }

        /// <summary>
        /// 获得一个字符串，如果key不存在会抛出异常
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <param name="key_string"></param>
        /// <returns></returns>
        public  string LTGetString(string key_space, string key_id)
        {
            if (key_id == null || key_space == null)
                return null;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                byte[] b_result = RNC.Get(redis_key);
                if (b_result == null)
                    return null;
                else
                    return Encoding.UTF8.GetString(b_result);
            }
        }



        /// <summary>
        /// 给一个命名为obj_id的Sets增加数字
        /// 数字就单独处理吧
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="obj_string"></param>
        /// <returns></returns>
        public  long LTIncr(string key_space, string obj_id)
        {
            if (obj_id == null || key_space == null)
                return 0;

            string redis_key = key_space + ":" + obj_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                return RNC.Incr(redis_key);
            }
        }

        /// <summary>
        /// 给某个field增加N
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="obj_id"></param>
        /// <returns></returns>
        public  long LTIncBy(string key_space, string obj_id, int n)
        {
            if (obj_id == null || key_space == null)
                return 0;

            string redis_key = key_space + ":" + obj_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                return RNC.IncrBy(redis_key, n);
            }
        }

        /// <summary>
        /// 获取一个以原生方式存储在redis里的hash表
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <returns></returns>
        public  Hashtable LTSMembers(string key_space, string key_id)
        {
            if (key_id == null || key_space == null)
                return null;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                byte[][] hash_result = RNC.SMembers(redis_key);
                if (hash_result == null)
                    return null;

                Hashtable ht_result = new Hashtable();

                for (int i = 0; i < hash_result.Length; i++)
                {
                    object this_key_obj = dbSerialize.DeSerialize(hash_result[i]);
                    ht_result.Add(this_key_obj, 0);
                }

                return ht_result;
            }
        }

        /// <summary>
        /// 给一个命名为obj_id的Sets增加一个字符串类对象
        /// 因为set就是用来做相比较的，所以不用放对象了
        /// 返回1表示增加成功，0表示已经存在
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="obj_string"></param>
        /// <returns></returns>
        public  long LTSetsAdd(string key_space, string obj_id, object obj_body)
        {
            if (obj_id == null || key_space == null)
                return 0;

            string redis_key = key_space + ":" + obj_id;

            byte[] saved_content = dbSerialize.Serialize(obj_body);

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                return RNC.SAdd(redis_key, saved_content);
            }
        }
        /// <summary>
        /// 判断set是否包含某个成员
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="obj_id"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public  bool LTSetsIsExistMember(string key_space, string obj_id, object member)
        {
            if (member == null || key_space == null)
            {
                return false;
            }
            string redis_key = key_space + ":" + obj_id;
            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                byte[] content = dbSerialize.Serialize(member);
                return RNC.SIsMember(redis_key, content) == 1;
            }
        }

        /// <summary>
        /// Sinter的函数包装
        /// 返回null表示无结果 
        /// </summary>
        /// <param name="key_space"></param>
        public  object[] LTSetsInter(string key_space, string[] key_list)
        {
            if (key_list == null || key_list.Length == 0)
                return null;

            string[] new_key_list = new string[key_list.Length];
            for (int i = 0; i < new_key_list.Length; i++)
                new_key_list[i] = key_space + ":" + key_list[i];

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                byte[][] barray = RNC.SInter(new_key_list);
                if (barray.Length == 0)
                    return null;

                object[] objarray = new object[barray.Length];

                for (int i = 0; i < objarray.Length; i++)
                    objarray[i] = dbSerialize.DeSerialize(barray[i]);

                return objarray;
            }
        }

        /// <summary>
        /// Sunion的函数包装
        /// 返回null表示无结果 
        /// </summary>
        /// <param name="key_space"></param>
        public  object[] LTSetsUnion(string key_space, string[] key_list)
        {
            if (key_list == null || key_list.Length == 0)
                return null;

            string[] new_key_list = new string[key_list.Length];
            for (int i = 0; i < new_key_list.Length; i++)
                new_key_list[i] = key_space + ":" + key_list[i];

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                byte[][] barray = RNC.SUnion(new_key_list);
                if (barray.Length == 0)
                    return null;

                object[] objarray = new object[barray.Length];

                for (int i = 0; i < objarray.Length; i++)
                    objarray[i] = dbSerialize.DeSerialize(barray[i]);

                return objarray;
            }
        }


        ///自定义的序列化对象，这个跟标准的redis string不同，前面加了个类型

        /// <summary>
        /// 获得一个对象
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="obj_id"></param>
        /// <returns></returns>
        public  object LTGetObj(string key_space, string obj_id)
        {
            if (obj_id == null || key_space == null)
                return false;

            string redis_key = key_space + ":" + obj_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {

                byte[] saved_content = RNC.Get(redis_key);

                if (saved_content == null)
                    return null;

                return dbSerialize.DeSerialize(saved_content);
            }
        }


        /// <summary>
        /// 保存一个对象，永久的，不缓冲的
        /// 返回true保存成功
        /// 返回false保存失败
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="obj_id"></param>
        /// <param name="obj_body"></param>
        /// <returns></returns>
        public  bool LTSaveObj(string key_space, string obj_id, object obj_body)
        {

            if (obj_id == null || key_space == null)
                return false;

            string redis_key = key_space + ":" + obj_id;

            byte[] saved_content = dbSerialize.Serialize(obj_body);

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                RNC.Set(redis_key, saved_content);
            }

            return true;
        }


        /// <summary>
        /// 将对象保存在keyspace:下的缓冲里，缓冲时间是ts
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="obj_id"></param>
        /// <param name="obj_body"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        public  bool LTSaveObj(string key_space, string obj_id, object obj_body, TimeSpan ts)
        {
            if (obj_id == null || key_space == null)
                return false;

            string redis_key = key_space + ":" + obj_id;

            byte[] saved_content = dbSerialize.Serialize(obj_body);

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {

                RNC.SetEx(redis_key, (int)ts.TotalSeconds, saved_content);
            }

            return true;
        }

        /// <summary>
        /// append(若key存在，则在末尾加value。否则就和set一样)一个字符串，字符串不能为空，可以为空字符串？
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="obj_id"></param>
        /// <param name="obj_string"></param>
        /// <returns></returns>
        public  bool LTAppendString(string key_space, string key_id, string key_string)
        {
            if (key_id == null || key_space == null || key_string == null)
                return false;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                RNC.Append(redis_key, Encoding.UTF8.GetBytes(key_string));
                return true;
            }
        }


        /// <summary>
        /// 清除一个对象
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="obj_id"></param>
        /// <returns></returns>
        public  bool LTDelKey(string key_space, string obj_id)
        {
            if (obj_id == null || key_space == null)
                return false;

            string redis_key = key_space + ":" + obj_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                RNC.Del(redis_key);
            }

            return true;
        }


        /// <summary>
        /// 设置一个Key的过期时间
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="obj_id"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        public  bool LTExpireKey(string key_space, string obj_id, TimeSpan ts)
        {
            if (obj_id == null || key_space == null)
                return false;

            string redis_key = key_space + ":" + obj_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                RNC.Expire(redis_key, Convert.ToInt32(ts.TotalSeconds));
            }

            return true;
        }

        /// <summary>
        /// 设置一个key的过期时间，minutes
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="obj_id"></param>
        /// <param name="expire_minutes"></param>
        /// <returns></returns>
        public  bool LTExpireKey(string key_space, string obj_id, int expire_minutes)
        {
            return LTExpireKey(key_space, obj_id, new TimeSpan(0, expire_minutes, 0));
        }

        /// <summary>
        /// 调用Redis的Rpush，向一个队列插入一条数据(byte[])
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <returns></returns>
        public  long LTRPushBytes(string key_space, string key_id, byte[] push_obj)
        {
            if (key_id == null || key_space == null)
                return 0;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                return RNC.RPush(redis_key, push_obj);
            }
        }

        /// <summary>
        /// 获取一个列表中的某一些byte[][]
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="key_id"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public  byte[][] LTLRangeBytes(string key_space, string key_id, int start, int end)
        {
            if (key_id == null || key_space == null)
                return null;

            string redis_key = key_space + ":" + key_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                byte[][] range_result = RNC.LRange(redis_key, start, end);

                if (range_result == null)
                    return null;
                return range_result;
            }
        }

        /// <summary>
        /// 将byte[]直接set入redis
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="obj_id"></param>
        /// <param name="obj"></param>
        /// <returns></returns>

        public  bool LTSaveByte(string key_space, string obj_id, byte[] obj)
        {

            if (obj_id == null || key_space == null)
                return false;

            string redis_key = key_space + ":" + obj_id;

            //byte[] saved_content = LetaoSerializer.Serialize(obj_body);

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                RNC.Set(redis_key, obj);
            }

            return true;
        }

        /// <summary>
        /// get一个未反序列化的值
        /// </summary>
        /// <param name="key_space"></param>
        /// <param name="obj_id"></param>
        /// <returns></returns>
        public  byte[] LTGetByte(string key_space, string obj_id)
        {
            if (obj_id == null || key_space == null)
                return null;

            string redis_key = key_space + ":" + obj_id;

            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {

                byte[] saved_content = RNC.Get(redis_key);

                if (saved_content == null)
                    return null;

                return saved_content;// LetaoSerializer.DeSerialize(saved_content);
            }
        }

        public  Dictionary<string, string> GetRedisInfo(string key_space)
        {
            if (string.IsNullOrEmpty(key_space))
            {
                return null;
            }
            using (RedisNativeClient RNC = GetNativeClientForKeySpace(key_space))
            {
                return RNC.Info;
            }
        }

    }
}