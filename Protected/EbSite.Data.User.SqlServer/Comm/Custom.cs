using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using System.Data.Common;
using EbSite.Base.DataProfile;//请先添加引用
namespace EbSite.Data.User.SqlServer
{
	
/// <summary>
	/// 数据访问类Links。
	/// </summary>
    public partial class DataProviderUser : Interface.IDataProviderUser
	{
        public static readonly string sPre = Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefixUser;
	}
}

