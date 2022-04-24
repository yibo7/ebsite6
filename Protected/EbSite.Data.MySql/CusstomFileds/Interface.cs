using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using EbSite.Base.CusttomTable;
using EbSite.Base.EntityAPI;
using EbSite.Data.MySql.CusstomFileds;

namespace EbSite.Data.MySql
{
    public partial class DataProviderCms : Interface.IDataProviderCms
    {
        public ISettingsBehavior<List<DataFiled>> CusstomFiledContent()
        {
            return new Content();
        }
    }
}
