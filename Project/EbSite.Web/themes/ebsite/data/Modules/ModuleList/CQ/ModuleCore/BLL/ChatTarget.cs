using System.Collections;
using System.Reflection;
using EbSite.Data.Interface;

namespace EbSite.Modules.CQ.ModuleCore.BLL
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// 实现了IComparable 才能在 List里使用Sort
    /// </summary>
    [Serializable]
    public class ChatTarget : IComparable<ChatTarget>
    {

        #region 与实体相关的属性
        private static object _SyncRoot = new object();

        private static List<ChatTarget> _Msgs;
        private Guid Id;
        private string _sender;
        private string _recipient;
        private DateTime _senddate;

        /// <summary>
        /// 用户名称
        /// </summary>
        public string Sender
        {
            set
            {

                _sender = value;
            }
            get { return _sender; }
        }
        /// <summary>
        ///客服名称
        /// </summary>
        public string Recipient
        {
            set
            {

                _recipient = value;
            }
            get { return _recipient; }
        }

        /// <summary>
        /// 操作日期
        /// </summary>
        public DateTime SendDate
        {
            set
            {

                _senddate = value;
            }
            get { return _senddate; }
        }
        private int _RecipientOnlineid;
        /// <summary>
        ///客服ID
        /// </summary>
        public int RecipientOnlineid
        {
            set
            {
                _RecipientOnlineid = value;
            }
            get { return _RecipientOnlineid; }
        }
        private int _SenderOnlineid;
        /// <summary>
        /// 用户ID
        /// </summary>
        public int SenderOnlineid
        {
            set
            {
                _SenderOnlineid = value;
            }
            get { return _SenderOnlineid; }
        }

        #endregion

        #region 构造方法
        public ChatTarget()
        {
            this.Id = Guid.NewGuid();
        }
        /// <summary>
        /// 删除某条数据及此数据的子记录
        /// </summary>
        protected void DataDelete()
        {

            if (Msgs.Contains(this))
                Msgs.Remove(this);
            //Dispose();
        }
        /// <summary>
        /// 删除某条数据及此数据的子记录
        /// </summary>
        public void Save()
        {
            if (!Msgs.Contains(this))
                Msgs.Add(this);
        }

        #endregion
        /// <summary>
        /// 添加一条信息到缓存
        /// </summary>
        /// <param name="md"></param>
        //public static void AddMsg(Chat md)
        //{
        //    if (!_Msgs.Contains(md))
        //        _Msgs.Add(md);
        //}
        /// <summary>
        /// 从缓存里删除一条信息
        /// </summary>
        /// <param name="md"></param>
        public static void DeleteMsg(ChatTarget md)
        {
            if (Msgs.Contains(md))
                Msgs.Remove(md);
        }

      
        /// <summary>
        /// 检测某个用户是否用新的聊天信息
        /// </summary>
        /// <param name="Recipient"></param>
        /// <returns></returns>
        public static int HaveNewChat(int Recipientonlineid)
        {
            int onlineid = 0;

            foreach (ChatTarget msg in Msgs)
            {
                if (Equals(msg.RecipientOnlineid, Recipientonlineid))
                {
                    onlineid = msg.SenderOnlineid;
                    break;
                }
            }


            return onlineid;
        }

        /// <summary>
        /// 获取客服 聊天的用户列表
        /// </summary>
        /// <param name="Recipient">收件人</param>
        /// <returns></returns>
        public static List<ChatTarget> GetMsgs( string Recipient)
        {
            List<ChatTarget> Chats = new List<ChatTarget>();

            foreach (ChatTarget msg in Msgs)
            {
                if ( Equals(msg.Recipient, Recipient))
                {
                    Chats.Add(msg);
                }
            }

            return Chats;
        }
        /// <summary>
        /// 获取数据集(纯从数据库查询，未加入树形)
        /// </summary>
        public static List<ChatTarget> Msgs
        {
            get
            {
                if (_Msgs == null)
                {
                    lock (_SyncRoot)
                    {
                        if (_Msgs == null)
                        {
                            _Msgs = new List<ChatTarget>();
                            //按_orderid降序来排序
                            _Msgs.Sort();
                        }
                    }
                }

                return _Msgs;
            }
        }

        #region 实现IComparable接口,以便在List里可以使用Sort对orderid 进行排序
        /// <summary>
        /// 按orderid的降序来排序,实现这个方法，可以让List.Sort(),按这个比较大小来排序
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(ChatTarget other)
        {
            return this.Id.CompareTo(other.Id);
        }
        #endregion



    }



}

