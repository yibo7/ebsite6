using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base.DataProfile;

namespace EbSite.Modules.BBS.ModuleCore.DAL.MySql
{
    public partial class BBS
    {
        public void UpdatePost(int SetTop,int PostLab,int TitleFont,string TitleColor,string IDs,int ManagerUserId,string ManagerUserNiName,int classid)
        {
            
            StringBuilder strSql = new StringBuilder();
            string TableName = Base.AppStartInit.GetTableNameByClassID(classid);
            strSql.AppendFormat("update {0}{1} set ", Base.Host.Instance.GetSysTablePrefix, TableName);
            strSql.AppendFormat("Annex5='{0}',Annex6={1},AddTime='{2}'", TitleColor, ManagerUserId,DateTime.Now);
            StringBuilder tipsInfo = new StringBuilder();

            if (SetTop > -1)
            {
                if (SetTop == 100)
                {
                    strSql.Append(",Annex15=0,IsGood=0 ");
                    tipsInfo.AppendFormat("帖子由{0} 取消置顶 ", ManagerUserNiName);
                }
                else if (SetTop == 0)
                {
                    strSql.Append(",Annex15=0,IsGood=1 ");
                    tipsInfo.AppendFormat("帖子由{0} 执行分类置顶 ", ManagerUserNiName);
                }
                else if (SetTop == 1)
                {
                    strSql.Append(",Annex15=1,IsGood=1 ");
                    tipsInfo.AppendFormat("帖子由{0} 执行所有版块置顶 ", ManagerUserNiName);
                }
            }

            if (PostLab > -1)
            {
                strSql.AppendFormat(",Annex13={0} ", PostLab);
            }
            if (TitleFont > -1)
            {
                strSql.AppendFormat(",Annex8='{0}' ", TitleFont);
            }
            

            strSql.AppendFormat(",Annex10='{0}' ", tipsInfo);
            
            strSql.AppendFormat(" where id in({0}) ", IDs);
            DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }
    }
}