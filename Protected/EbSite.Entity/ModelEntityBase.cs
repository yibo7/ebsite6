using System;
using System.Collections.Specialized;
using EbSite.BLL.ModelBll;

namespace EbSite.Entity
{
   public interface   ModelEntityBase
    {

      void AddCusttomFileds(string key, string Value);
       StringDictionary GetCusttomFileds();
       StringDictionary Fileds{ get;}


        
    }
}

