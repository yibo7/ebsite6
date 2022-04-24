using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.Text;

namespace EbSite.BLL.Messaging
{
    public class Remark : Base.Messaging.MSMQBase, Base.Messaging.MessagingBase<Entity.Remark>
    {
         public readonly static Remark Instance = new Remark();

        private static int queueTimeout = 20;
        public Remark()
            : base(queueTimeout)
        {
            // 使用二进制格式，将一个对象（或连接的对象的整个图形）序列化成“消息队列”消息体或从“消息队列”消息体反序列化一个对象。
            queue.Formatter = new BinaryMessageFormatter();
        }

       override protected string QueuePath
        {
            get { return "FormatName:DIRECT=OS:MachineName\\Private$\\EbRemark"; }
            
        }
        public new Entity.Remark Receive()
        {
            // 指定消息队列事务的类型。
            /*
             None	操作将不是事务性的。
            Automatic	用于 Microsoft Transaction Server (MTS) 或 COM+ 1.0 服务的事务类型。 如果已有 MTS 事务上下文，将在发送或接收消息时使用它。
            Single	用于单个内部事务的事务类型。
             */
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (Entity.Remark)((Message)base.Receive()).Body;
        }

        public Entity.Remark Receive(int timeout)
        {
            base.timeout = TimeSpan.FromSeconds(Convert.ToDouble(timeout));
            return Receive();
        }
        /// <summary>
        /// 添加一条评论到消息队列
        /// </summary>
        /// <param name="orderMessage">评论实体</param>
        public void Send(Entity.Remark orderMessage)
        {
            // 指定消息队列事务的类型 Single	用于单个内部事务的事务类型。
            base.transactionType = MessageQueueTransactionType.Single;
            base.Send(orderMessage);
        }
    }
}
