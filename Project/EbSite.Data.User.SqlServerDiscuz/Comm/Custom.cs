using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using System.Data.Common;
using EbSite.Data.Profile;//�����������
namespace EbSite.Data.User.SqlServerDiscuz
{
	
/// <summary>
	/// ���ݷ�����Links��
	/// </summary>
    public partial class DataProviderUser : Interface.IDataProviderUser
	{
        public static readonly string sPre = EbSite.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefixUser;
	}
}

