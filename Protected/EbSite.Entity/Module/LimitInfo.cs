using System;
using System.Collections.Generic;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.Entity.Module
{
     [Serializable]
    public class LimitInfo : XmlEntityBase<Guid>
    {
         private int _LimitID;
         private string _LimitName;
         /// <summary>
         /// 权限ID
         /// </summary>
         public int  LimitID
         {
             get
             {
                 return _LimitID;
             }
             set
             {
                 _LimitID = value;
             }
         }
         /// <summary>
         /// 权限名称
         /// </summary>
         public string  LimitName
         {
             get
             {
                 return _LimitName;
             }
             set
             {
                 _LimitName = value;
             }
         }
    }
}
