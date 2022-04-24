using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Modules.CQ.ModuleCore.Entity;

namespace EbSite.Modules.CQ.ModuleCore.BLL
{
    public class ChatBll
    {
        private static object _SyncRoot = new object();
        private static List<Customer> _Customers;
        private static List<ChatMsg> _Msgs;
        public static readonly ChatBll Instance = new ChatBll();


        #region  聊天
        private void MsgDelete(ChatMsg msg)
        {

            if (Msgs.Contains(msg))
                Msgs.Remove(msg);
        }
        /// <summary>
        /// 定时清除已经读取的信息
        /// </summary>
        /// <returns></returns>
        public  void DeleteMsgsOfRead()
        {
            List<ChatMsg> Chats = new List<ChatMsg>();
            foreach (ChatMsg msg in Msgs)
            {
                if (msg.IsRead)
                {
                    Chats.Add(msg);
                }
            }
            foreach (ChatMsg md in Chats)
            {
                MsgDelete(md);
            }
        }
        public void AddMsg(ChatMsg md)
        {
            if (!Msgs.Contains(md))
                    Msgs.Add(md);
        }
      /// <summary>
      /// 获取某个客服对应客户聊天记录列表(未读取)
      /// </summary>
        /// <param name="Sender">发送者 有可能是客服也可能是客户</param>
        /// <param name="Recipient">接收者 有可能是客服也可能是客户</param>
      /// <returns></returns>
        public List<ChatMsg> GetMsgs(string Sender, string Recipient)
        {
            ////可以的定时器里定期删除
            DeleteMsgsOfRead();

            List<ChatMsg> Chats = new List<ChatMsg>();

            foreach (ChatMsg msg in Msgs)
            {
                if (Equals(msg.Sender, Sender) && Equals(msg.Recipient, Recipient) && !msg.IsRead)
                {
                    msg.IsRead = true;
                    Chats.Add(msg);
                }
            }


            return Chats;
        }
        #endregion


        public string GetCustomerUserName()
        {
            return string.IsNullOrEmpty(EbSite.Base.Host.Instance.UserName) ? EbSite.Base.Host.Instance.GetGuestName(EbSite.Base.Host.Instance.OnlineID) : EbSite.Base.Host.Instance.UserName;
        }
        public  void AddCustomers(int sid)
        {
            string cid = GetCustomerUserName();
            bool ishave = Customers.Exists(d => d.ServiceID == sid && d.CustomerUserName == cid);

            if(!ishave)
            {
                Customer md = new Customer();
                md.ServiceID = sid;
                md.CustomerUserName = cid;
                md.CustomerUserID = EbSite.Base.Host.Instance.UserID;
                md.CustomerNiName = EbSite.Base.AppStartInit.UserNiName;
                md.CustomerIp = EbSite.Core.Utils.GetClientIP();
                md.LastDateTime = DateTime.Now;
                md.IsOnline = true;
                Customers.Add(md);
            }
        }

        public Customer GetCustomer(int sid, string CustomerUserName)
        {
            foreach (Customer customer in Customers)
            {
                if (customer.ServiceID == sid && customer.CustomerUserName == CustomerUserName)
                {
                    return customer;
                }
            }
            return null;
        }
        public void DeleteCustomer(int sid)
        {
            string cid = GetCustomerUserName();
            //Core.Utils.TestDebug(cid);
            DeleteCustomer(sid, cid);
        }
        public void DeleteCustomer(int sid, string cid)
        {
            Customer md = GetCustomer(sid, cid);

            if (!Equals(md, null))
            {
                Customers.Remove(md);
            }
        }

        public List<Customer> CustomersOnline(int suid)
        {
            List<Customer> lst = new List<Customer>();
            foreach (Customer customer in Customers)
            {
                if(customer.ServiceID==suid)
                {
                    lst.Add(customer);
                    //long span = EbSite.Core.Strings.cConvert.DateDiff("minute", customer.LastDateTime, DateTime.Now);
                    //if (span < 1)
                    //{
                    //    lst.Add(customer);
                    //}
                    //else //清理过期用户
                    //{
                    //    Customers.Remove(customer);
                    //}
                    
                }
            }
            return lst;
        }
        public static List<Customer> Customers
        {
            get
            {
                if (_Customers == null)
                {
                    lock (_SyncRoot)
                    {
                        if (_Customers == null)
                        {
                            _Customers = new List<Customer>();
                            //按_orderid降序来排序
                            _Customers.Sort();


                        }
                    }
                }

                return _Customers;
            }
        }
        public static List<ChatMsg> Msgs
        {
            get
            {
                if (_Msgs == null)
                {
                    lock (_SyncRoot)
                    {
                        if (_Msgs == null)
                        {
                            _Msgs = new List<ChatMsg>();
                            //按_orderid降序来排序
                            _Msgs.Sort();


                        }
                    }
                }

                return _Msgs;
            }
        }


    }
}