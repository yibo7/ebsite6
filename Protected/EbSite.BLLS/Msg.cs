
using EbSite.Base.Static;
using EbSite.Core;
using EbSite.Data.Interface;
using EbSite.Data.User.Interface;

namespace EbSite.BLL
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// 实现了IComparable 才能在 List里使用Sort
    /// </summary>
    [Serializable]
    public class Msg : BusinessBase<Msg, int>, IComparable<Msg>
    {
        #region 与实体相关的属性
        private static object _SyncRoot = new object();
        private static List<Msg> _Msgs;
        private int _MsgType = -1;
        private string _sender;
        private string _recipient;
        private int _foldertype;
        private bool _isnew;
        private string _title;
        private DateTime _senddate;
        private string _msgcontent;
        private string _senderniname;
        private int _senderuserid;
        private int _recipientuserid;
        private string _EventPram;
        /// <summary>
        /// 事件订制附加参数,不用保存到数据库，只作为事件传递过程中使用
        /// </summary>
        public string EventPram
        {
            set
            {
                if (this._EventPram != value)
                {
                    this.MarkChanged("EventPram");
                }
                _EventPram = value;
            }
            get { return _EventPram; }
        }

        /// <summary>
        /// 发送者昵称
        /// </summary>
        public string SenderNiName
        {
            set
            {
                if (this._senderniname != value)
                {
                    this.MarkChanged("senderniname");
                }
                _senderniname = value;
            }
            get { return _senderniname; }
        }
        /// <summary>
        /// 发送者用户ID
        /// </summary>
        public int SenderUserID
        {
            set
            {
                if (this._senderuserid != value)
                {
                    this.MarkChanged("senderuserid");
                }
                _senderuserid = value;
            }
            get { return _senderuserid; }
        }
        /// <summary>
        /// 接收者用户ID
        /// </summary>
        public int RecipientUserID
        {
            set
            {
                if (this._recipientuserid != value)
                {
                    this.MarkChanged("recipientuserid");
                }
                _recipientuserid = value;
            }
            get { return _recipientuserid; }
        }

        /// <summary>
        /// 是一种对外定制短信的标记，默认为-1,表示非用户定制短信，如果大于1，那么用户可的事件前进行相应的处理
        /// </summary>
        public int MsgType
        {
            set
            {

                _MsgType = value;
            }
            get { return _MsgType; }
        }
        /// <summary>
        /// 发件人名称
        /// </summary>
        public string Sender
        {
            set
            {
                if (this._sender != value)
                {
                    this.MarkChanged("sender");
                }
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
                if (this._recipient != value)
                {
                    this.MarkChanged("recipient");
                }
                _recipient = value;
            }
            get { return _recipient; }
        }
        /// <summary>
        /// 收件箱类别，0为草稿箱，1为收件箱，2为发件箱
        /// </summary>
        public int FolderType
        {
            set
            {
                if (this._foldertype != value)
                {
                    this.MarkChanged("foldertype");
                }

                _foldertype = value;
            }
            get { return _foldertype; }
        }
        /// <summary>
        /// 是否已读
        /// </summary>
        public bool IsNewMsg
        {
            set
            {
                if (this._isnew != value)
                {
                    this.MarkChanged("isnew");
                }

                _isnew = value;
            }
            get { return _isnew; }
        }
        /// <summary>
        /// 短信标题
        /// </summary>
        public string Title
        {
            set
            {
                if (this._title != value)
                {
                    this.MarkChanged("title");
                }

                _title = value;
            }
            get { return _title; }
        }
        /// <summary>
        /// 发送日期
        /// </summary>
        public DateTime SendDate
        {
            set
            {
                if (this._senddate != value)
                {
                    this.MarkChanged("senddate");
                }
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
                if (this._msgcontent != value)
                {
                    this.MarkChanged("msgcontent");
                }
                _msgcontent = value;
            }
            get { return _msgcontent; }
        }

        #endregion

        const double CacheDuration = 60.0;
        private const string CacheMsg = "msg"; //private static readonly string[] MasterCacheKeyArray = { "Msg" };
       // private static CacheManager bllCache;
        #region 构造方法
        //static Msg()
        //{
        //    bllCache = new CacheManager(CacheDuration, MasterCacheKeyArray);
        //}


        #endregion

        #region 对数据的-增-删-查-改

        /// <summary>
        /// 删除某条数据及此数据的子记录
        /// </summary>
        protected override void DataDelete()
        {

            if (IsDeleted)
                DbProviderUser.GetInstance().Msg_DeleteMsg(this);
            //if (Msgs.Contains(this))
            //    Msgs.Remove(this);
            Dispose();
            EbSite.Base.Host.CacheApp.InvalidateCache(CacheMsg); // bllCache.InvalidateCache();
        }



        /// <summary>
        /// 插入一条数据
        /// </summary>
        protected override void DataInsert()
        {
            if (IsNew)
            {
                DbProviderUser.GetInstance().Msg_InsertMsg(this);

                //Msgs.Add(this);
                //Msgs.Sort();
               EbSite.Base.Host.CacheApp.InvalidateCache(CacheMsg); //bllCache.InvalidateCache();
            }

        }
        /// <summary>
        /// 与GetMenu一样，从某个ID获取某个对象,只不过这个从数据库获取GetMenu 在内存里获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected override Msg DataSelect(int id)
        {
            return DbProviderUser.GetInstance().Msg_SelectMsg(id);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        protected override void DataUpdate()
        {
            if (this.IsChanged)
            {
                if (IsChanged)
                    DbProviderUser.GetInstance().Msg_UpdateMsg(this);
              EbSite.Base.Host.CacheApp.InvalidateCache(CacheMsg);//  bllCache.InvalidateCache();

            }
        }


        /// <summary>
        /// 与DataSelect一样，从某个ID获取某个对象,只不过这个只从现在有缓存里获取
        /// DataSelect 从数据库获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Msg GetMsg(int id)
        {
           return DbProviderUser.GetInstance().Msg_SelectMsg(id);
        }
        /// <summary>
        /// 与GetMenu一样，从某个ID获取某个对象,只不过这个从数据库获取GetMenu 在内存里获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static void DeleteMsg(int id, int UserID)
        {
            DbProviderUser.GetInstance().Msg_DeleteMsg(id, UserID);
            _Msgs = null;
        }
        ///// <summary>
        ///// 获取某个用户的收件箱信息或发件箱
        ///// </summary>
        ///// <param name="UserName"></param>
        ///// <param name="IsRc">true 获取收件箱，false获取发件箱</param>
        ///// <returns></returns>
        //public static List<Msg> GetMsgs(string UserName, bool IsRecipient)
        //{
        //    List<Msg> msgs = new List<Msg>();

        //    foreach (Msg msg in Msgs)
        //    {
        //        if (IsRecipient)//获取某个用户的收件箱信息
        //        {
        //            if (Equals(msg.Recipient, UserName))
        //            {
        //                msgs.Add(msg);
        //            }
        //        }
        //        else//获取某个用户的发件箱信息
        //        {
        //            if (Equals(msg.Sender, UserName))
        //            {
        //                msgs.Add(msg);
        //            }
        //        }


        //    }
        //    return msgs;
        //}


        public  List<Msg> DsGetMsgs(string UserName, bool IsRecipient)
        {
            List<Msg> msgs = new List<Msg>();
            List<Msg> DsMsgs = DbProviderUser.GetInstance().Msg_FillMsg();
            //按_orderid降序来排序
            DsMsgs.Sort();
            foreach (Msg msg in DsMsgs)
            {
                if (IsRecipient)//获取某个用户的收件箱信息
                {
                    if (Equals(msg.Recipient, UserName))
                    {
                        msgs.Add(msg);
                    }
                }
                else//获取某个用户的发件箱信息
                {
                    if (Equals(msg.Sender, UserName))
                    {
                        msgs.Add(msg);
                    }
                }
            }
            return msgs;
        }

        public static List<Msg> GetListPages(int PageIndex, int PageSize, int UserID, bool IsNews, string oderby, out int RecordCount)
        {

            return DbProviderUser.GetInstance().Msg_GetListPages(PageIndex, PageSize, UserID, IsNews, oderby,
                                                                 out RecordCount);
        }
        ///// <summary>
        ///// 获取数据集(纯从数据库查询，未加入树形)
        ///// </summary>
        //public static List<Msg> Msgs
        //{
        //    get
        //    {
        //        if (_Msgs == null)
        //        {
        //            lock (_SyncRoot)
        //            {
        //                if (_Msgs == null)
        //                {
        //                    _Msgs = DbProviderUser.GetInstance().Msg_FillMsg();
        //                    //按_orderid降序来排序
        //                    _Msgs.Sort();


        //                }
        //            }
        //        }

        //        return _Msgs;
        //    }
        //}

        #endregion

        /// <summary>
        /// 验证规则
        /// </summary>
        protected override void ValidationRules()
        {
            this.AddRule("Title", "必须标题不能为空", string.IsNullOrEmpty(this.Title));
        }

        static public void Msg_SetToRead(int MsgID)
        {
            DbProviderUser.GetInstance().Msg_SetToRead(MsgID);
        }

        public static List<Msg> GetNewList(int top,int UserID)
        {
            return DbProviderUser.GetInstance().Msg_New(top, UserID);
        }

        /// <summary>
        /// 获取某个用户的最新短信条数
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="IsNews"></param>
        /// <returns></returns>
        static public int Msg_Count(int UserID, bool IsNews)
        {
            //int iCount =  DbProviderCms.GetInstance().Msg_Count(UserName, IsNews);
            int iCount = 0;
            string CacheKey = string.Concat("MsgCount-", UserID, IsNews);
            object obCount = EbSite.Base.Host.CacheApp.GetCacheItem<object>(CacheKey,CacheMsg); //  bllCache.GetCacheItem(CacheKey);

            if (Equals(obCount, null))
            {
                iCount = DbProviderUser.GetInstance().Msg_Count(UserID, IsNews);
                EbSite.Base.Host.CacheApp.AddCacheItem(CacheKey,iCount,CacheDuration,ETimeSpanModel.M, CacheMsg); //  bllCache.AddCacheItem(CacheKey, iCount);
            }

            return iCount;
        }

        /// <summary>
        /// 重写ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Title;
        }

        #region 实现IComparable接口,以便在List里可以使用Sort对orderid 进行排序
        /// <summary>
        /// 按orderid的降序来排序,实现这个方法，可以让List.Sort(),按这个比较大小来排序
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Msg other)
        {

            return this.Id.CompareTo(other.Id);
        }

        #endregion


        /// <summary>
        /// 批量删除,IDs用逗号分开ID
        /// </summary>
        /// <param name="IDs"></param>
        static public void DeleteInIDs(string IDs)
        {
            if (!string.IsNullOrEmpty(IDs))
                DbProviderUser.GetInstance().Msg_DeleteInIDs(IDs);
        }
    }



}

