using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using EbSite.Base.CusttomTable;
using EbSite.Base.EntityAPI;

namespace EbSite.Data.Interface
{
    public partial interface IDataProviderCms
    {
        ISettingsBehavior<List<DataFiled>> CusstomFiledContent();
    }
}
