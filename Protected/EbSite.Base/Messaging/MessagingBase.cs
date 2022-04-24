using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EbSite.Base.Messaging
{
    public interface MessagingBase<T>
    {
        
        T Receive();
        T Receive(int timeout);
        void Send(T orderMessage);
    }
}
