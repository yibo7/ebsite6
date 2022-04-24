using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;

namespace EbSite.Base.Messaging
{
    abstract public class MSMQBase : IDisposable
    {

        protected MessageQueueTransactionType transactionType = MessageQueueTransactionType.Automatic;
        protected MessageQueue queue;
        protected TimeSpan timeout;
        abstract protected string QueuePath { get; }
        public MSMQBase(int timeoutSeconds)
        {
            queue = new MessageQueue(QueuePath);
            timeout = TimeSpan.FromSeconds(Convert.ToDouble(timeoutSeconds));

            // Performance optimization since we don't need these features
            queue.DefaultPropertiesToSend.AttachSenderId = false;
            queue.DefaultPropertiesToSend.UseAuthentication = false;
            queue.DefaultPropertiesToSend.UseEncryption = false;
            queue.DefaultPropertiesToSend.AcknowledgeType = AcknowledgeTypes.None;
            queue.DefaultPropertiesToSend.UseJournalQueue = false;
        }

        /// <summary>
        /// Derived classes call this from their own Receive methods but cast
        /// the return value to something meaningful.
        /// </summary>
        public virtual object Receive()
        {
            try
            {
                using (Message message = queue.Receive(timeout, transactionType))
                    return message;
            }
            catch (MessageQueueException mqex)
            {
                if (mqex.MessageQueueErrorCode == MessageQueueErrorCode.IOTimeout)
                    throw new TimeoutException();

                throw;
            }
        }

        /// <summary>
        /// Derived classes may call this from their own Send methods that
        /// accept meaningful objects.
        /// </summary>
        public virtual void Send(object msg)
        {
            queue.Send(msg, transactionType);
        }

        #region IDisposable Members
        public void Dispose()
        {
            queue.Dispose();
        }
        #endregion
    }
}
