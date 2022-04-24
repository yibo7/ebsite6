using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EbSite.Base.EntityAPI
{
    [Serializable]
    public class EmailPoolModel
    {
        public EmailModel mdEmailModel { get; set; }
        public EmailPoolModel(EmailModel _mdEmailModel)
        {
            mdEmailModel = _mdEmailModel;
        }
        public EmailPoolModel()
        {

        }
        public object SendEmail(object sender)
        {

            return 1;
        }
    }
}
