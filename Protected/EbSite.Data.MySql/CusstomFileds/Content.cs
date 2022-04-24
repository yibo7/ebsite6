using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using EbSite.Base.CusttomTable;
using EbSite.Base.DataProfile;
using EbSite.Base.EntityAPI;
using MySql.Data.MySqlClient;

namespace EbSite.Data.MySql.CusstomFileds
{
    public class Content : ISettingsBehavior<List<DataFiled>>
    {
        public bool SaveSettings(string TableName, string exId, List<DataFiled> settings)
        {
            bool key = false;
            if (!string.IsNullOrEmpty(exId))
            {
                if (Core.Utils.StrToInt(exId, 0) > 0 && settings.Count > 0)
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.AppendFormat("update {0}{1} set ", DataProviderCms.sPre, TableName);

                    foreach (DataFiled de in settings)
                    {
                        strSql.AppendFormat("{0}=?{0},", de.ColumName);
                    }
                    strSql = strSql.Remove(strSql.Length - 1, 1);
                    strSql.Append(" where id=?id ");

                    MySqlParameter[] parameters = new MySqlParameter[settings.Count+1];
                    for (int i = 0; i < settings.Count; i++)
                    {
                        string columnname = settings[i].ColumName;
                        int columntype = settings[i].CFiledConfigs.DataType;
                        int columnLength = settings[i].CFiledConfigs.DataTypeLen;

                        switch (columntype)
                        {
                            case 0://Base.EntityAPI.EDataFiledType.文本varchar
                                parameters[i] = new MySqlParameter("?" + columnname, MySqlDbType.VarChar, columnLength);
                                parameters[i].Value = settings[i].Value;
                                break;
                            case 1://Base.EntityAPI.EDataFiledType.内容longtext:
                                parameters[i] = new MySqlParameter("?" + columnname, MySqlDbType.LongText);
                                parameters[i].Value = settings[i].Value;
                                break;
                            case 2:// Base.EntityAPI.EDataFiledType.字符char:
                                parameters[i] = new MySqlParameter("?" + columnname, MySqlDbType.VarChar, columnLength);
                                parameters[i].Value = settings[i].Value;
                                break;
                            case 3://Base.EntityAPI.EDataFiledType.数字int:
                                parameters[i] = new MySqlParameter("?" + columnname, MySqlDbType.Int32, columnLength);
                                if (string.IsNullOrEmpty(settings[i].Value))
                                    settings[i].Value = "0";
                                parameters[i].Value =   settings[i].Value;
                                break;
                            case 4:// Base.EntityAPI.EDataFiledType.小数两位decimal:
                                parameters[i] = new MySqlParameter("?" + columnname, MySqlDbType.Decimal, columnLength);
                                if (string.IsNullOrEmpty(settings[i].Value))
                                    settings[i].Value = "0";
                                parameters[i].Value = settings[i].Value;
                                break;
                            case 5://Base.EntityAPI.EDataFiledType.时间datetime:
                                parameters[i] = new MySqlParameter("?" + columnname, MySqlDbType.DateTime);
                                if (string.IsNullOrEmpty(settings[i].Value))
                                    settings[i].Value = null;
                                parameters[i].Value = settings[i].Value;
                                break;
                            case 6://Base.EntityAPI.EDataFiledType.是否bit:
                                parameters[i] = new MySqlParameter("?" + columnname, MySqlDbType.Bit);
                                if (string.IsNullOrEmpty(settings[i].Value))
                                    settings[i].Value = null;
                                parameters[i].Value = settings[i].Value;
                                break;
                        }

                    }
                    parameters[settings.Count] = new MySqlParameter("?id", MySqlDbType.Int32, 4);

                    parameters[settings.Count].Value = Core.Utils.StrToInt(exId, 0);
                    int iTag = DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
                    if (iTag > 0)
                        key = true;
                }

            }

            //  settings[0].CFiledConfigs.

            //StringBuilder strSql = new StringBuilder();
            //StringBuilder strValues = new StringBuilder();
            //strSql.AppendFormat("insert into {0}{1}(", DataProviderCms.sPre, TableName);

            //foreach (DataFiled de in settings)
            //{
            //    strSql.Append(de.ColumName);
            //    strSql.Append(",");

            //    strValues.Append(de.Value);
            //    strValues.Append(",");
            //}
            //strSql.Append(" values (");

            //strSql.Append(strValues);

            //strSql.Append(")");

            //strSql.Append(";SELECT @@session.identity");

            //object obj = DbHelperCms.Instance.ExecuteScalar(CommandType.Text, strSql.ToString());

            //return true;
            return key;
        }


        public StringDictionary GetSettings(string TableName, string exId)
        {
            SerializableStringDictionary ssd = null;
            StringDictionary sd = new StringDictionary();


            return new StringDictionary();
        }
    }
}
