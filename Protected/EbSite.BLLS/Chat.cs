using System.Collections;
using System.Reflection;
using EbSite.Data.Interface;

namespace EbSite.BLL
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// 实现了IComparable 才能在 List里使用Sort
    /// </summary>
    [Serializable]
    public class Chat : IComparable<Chat>
    {

        #region 与实体相关的属性
        private static object _SyncRoot = new object();

        private static List<Chat> _Msgs;
        private Guid Id;
        private string _sender;
        private string _recipient;
        private DateTime _senddate;
        private string _msgcontent;
        private string _senderniname;
        private bool _IsRead = false;

        public int RecipientId { get; set; }
        public int SenderId { get; set; }
        public string RecipientNiName { get; set; }

        /// <summary>
        /// 发件人名称
        /// </summary>
        public string SenderNiName
        {
            set
            {

                _senderniname = value;
            }
            get { return _senderniname; }
        }

        /// <summary>
        /// 标记是否已经读取
        /// </summary>
        public bool IsRead
        {
            set
            {

                _IsRead = value;
            }
            get { return _IsRead; }
        }

        /// <summary>
        /// 发件人名称
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
        /// 收件人用户名
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
        /// 发送日期
        /// </summary>
        public DateTime SendDate
        {
            set
            {

                _senddate = value;
            }
            get { return _senddate; }
        }
        /// <summary>
        /// 短信内容
        /// </summary>
        public string MsgContent
        {
            set
            {
                _msgcontent = value;
            }
            get { return _msgcontent; }
        }

        #endregion

        #region 构造方法
        public Chat()
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
        public static void DeleteMsg(Chat md)
        {
            if (Msgs.Contains(md))
                Msgs.Remove(md);
        }

        public static void DeleteMsg(int SenderOnlineID)
        {
            List<Chat> Chats = new List<Chat>();
            foreach (Chat msg in Msgs)
            {
                if (!msg.IsRead && msg.SenderOnlineid == SenderOnlineID)
                {
                    Chats.Add(msg);
                }
            }
            foreach (Chat md in Chats)
            {
                md.DataDelete();
            }
        }

        /// <summary>
        /// 定时清除已经读取的信息
        /// </summary>
        /// <returns></returns>
        public static void DeleteMsgsOfRead()
        {
            List<Chat> Chats = new List<Chat>();
            foreach (Chat msg in Msgs)
            {
                if (msg.IsRead)
                {
                    Chats.Add(msg);
                }
            }
            foreach (Chat md in Chats)
            {
                md.DataDelete();
            }
        }

        private int _RecipientOnlineid;
        /// <summary>
        /// 接收用户的在线ID
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
        /// 发送用户的在线ID
        /// </summary>
        public int SenderOnlineid
        {
            set
            {

                _SenderOnlineid = value;
            }
            get { return _SenderOnlineid; }
        }
        /// <summary>
        /// 检测某个用户是否用新的聊天信息
        /// </summary>
        /// <param name="Recipient"></param>
        /// <returns></returns>
        public static Chat HaveNewChat(int Recipientonlineid)
        {
            //int onlineid = 0;
           
            foreach (Chat msg in Msgs)
            {
                if (Equals(msg.RecipientOnlineid, Recipientonlineid) && !msg.IsRead)
                {
                    //onlineid = msg.SenderOnlineid;
                    return msg;
                    //break;
                }
            }
            return null;

            //return onlineid;
        }
        /// <summary>
        /// 检测某个用户是否用新的聊天信息
        /// </summary>
        /// <param name="Recipient"></param>
        /// <returns></returns>
        //public static string HaveNewChat(string Recipient)
        //{
        //    string sUserName = string.Empty;

        //    foreach (Chat msg in Msgs)
        //    {
        //        if (Equals(msg.Recipient, Recipient) && !msg.IsRead)
        //        {
        //            sUserName = msg.Sender;
        //            break;
        //        }
        //    }


        //    return sUserName;
        //}
        /// <summary>
        /// 获取某个两人的对话信息
        /// </summary>
        /// <returns></returns>
        public static List<Chat> GetMsgs(int FriendId, int MyUserId)
        {
            //可以的定时器里定期删除
            DeleteMsgsOfRead();

            List<Chat> Chats = new List<Chat>();

            foreach (Chat msg in Msgs)
            {
                if (Equals(msg.SenderOnlineid, FriendId) && Equals(msg.RecipientOnlineid, MyUserId) && !msg.IsRead)
                {
                    msg.IsRead = true;
                    Chats.Add(msg);
                }
            }


            return Chats;
        }
        /// <summary>
        /// 获取数据集(纯从数据库查询，未加入树形)
        /// </summary>
        public static List<Chat> Msgs
        {
            get
            {
                if (_Msgs == null)
                {
                    lock (_SyncRoot)
                    {
                        if (_Msgs == null)
                        {
                            _Msgs = new List<Chat>();
                            //按_orderid降序来排序
                            _Msgs.Sort();


                        }
                    }
                }

                return _Msgs;
            }
        }


        /// <summary>
        /// 重写ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MsgContent;
        }

        #region 实现IComparable接口,以便在List里可以使用Sort对orderid 进行排序
        /// <summary>
        /// 按orderid的降序来排序,实现这个方法，可以让List.Sort(),按这个比较大小来排序
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Chat other)
        {

            return this.Id.CompareTo(other.Id);
        }

        #endregion



    }



}

