using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.Entity;

namespace EbSite.Modules.CQ.ModuleCore.Entity
{

    public class ChatMsg : IComparable<ChatMsg>
    {

        public ChatMsg()
        {
            this.id = Guid.NewGuid();
        }
        public Guid id { get; set; }

        /// <summary>
        /// 有可能是客服也可能是客户
        /// </summary>
        public string Sender { get; set; }
        /// <summary>
        /// 有可能是客服也可能是客户
        /// </summary>
        public string Recipient { get; set; }
      
        public string Msg { get; set; }
        /// <summary>
        /// 标记是否已经读取
        /// </summary>
        public bool IsRead { get; set; }
        /// <summary>
        /// 些条信息是否将客户端置为导购模式，只尖对客户端使用
        /// </summary>
        public int IsSetDG { get; set; }

        public int CompareTo(ChatMsg other)
        {

            return this.id.CompareTo(other.id);
        }
    }
}