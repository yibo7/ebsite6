using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EbSite.Base.Plugin.Manager
{
    public class PaymentUseingInfo
    {
        public PaymentUseingInfo(IPayment payment, string OrderName, string TotalPrice, string OrderNumber)
        {
            
            _Help = payment.Description;
            _PayLink = payment.GetPayStr(OrderName, TotalPrice, OrderNumber);
            _Name = payment.Description;
        }
        private string _Help { get; set; }
        private string _PayLink { get; set; }
        private string _Name { get; set; }

        public string Help { get { return _Help; } }
        public string PayLink { get { return _PayLink; } }
        public string Name { get { return _Name; } }
       
    }
}
