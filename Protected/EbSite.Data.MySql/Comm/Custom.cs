using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;
using System.Collections.Generic;
using System.Data.Common;
using EbSite.Base.DataProfile;//请先添加引用
namespace EbSite.Data.MySql
{
	
/// <summary>
	/// 数据访问类Links。
	/// </summary>
    public partial class DataProviderCms : Interface.IDataProviderCms
	{
        public static readonly string sPre = Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix;
	}
}

