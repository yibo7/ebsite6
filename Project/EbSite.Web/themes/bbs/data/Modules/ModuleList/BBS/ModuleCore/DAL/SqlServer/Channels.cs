using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Modules.BBS.ModuleCore.DAL.SqlServer
{
	/// <summary>
	/// 数据访问类BBS。
	/// </summary>
	public partial class BBS
	{
        private string sFieldChannels = "id,ChannelName,ChannelDescription,ChannelImageUrl,OrderFlag,CreatedTime,UpdatedTime,TopicCount,ReplyCount,PostCount,TodayPostCount,SatisticsTime,ChannelFlag,ReadFlag,WriteFlag,ChannelLinkFlag,ChannelLinkUrl,LatestBBSTopicID,LatestBBSTopicTitle,LatestBBSTopicUserID,LatestBBSTopicUserName,LatestBBSTopicRepliedTime,CompanyID,ParentID";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int Channels_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}Channels",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Channels_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}Channels",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Channels_Add(Entity.Channels model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}Channels(",sPre);
            strSql.Append("ChannelName,ChannelDescription,ChannelImageUrl,OrderFlag,CreatedTime,UpdatedTime,TopicCount,ReplyCount,PostCount,TodayPostCount,SatisticsTime,ChannelFlag,ReadFlag,WriteFlag,ChannelLinkFlag,ChannelLinkUrl,LatestBBSTopicID,LatestBBSTopicTitle,LatestBBSTopicUserID,LatestBBSTopicUserName,LatestBBSTopicRepliedTime,CompanyID,ParentID)");
			strSql.Append(" values (");
            strSql.Append("@ChannelName,@ChannelDescription,@ChannelImageUrl,@OrderFlag,@CreatedTime,@UpdatedTime,@TopicCount,@ReplyCount,@PostCount,@TodayPostCount,@SatisticsTime,@ChannelFlag,@ReadFlag,@WriteFlag,@ChannelLinkFlag,@ChannelLinkUrl,@LatestBBSTopicID,@LatestBBSTopicTitle,@LatestBBSTopicUserID,@LatestBBSTopicUserName,@LatestBBSTopicRepliedTime,@CompanyID,@ParentID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					
					new SqlParameter("@ChannelName", SqlDbType.VarChar,50),
					new SqlParameter("@ChannelDescription", SqlDbType.VarChar,8000),
					new SqlParameter("@ChannelImageUrl", SqlDbType.VarChar,500),
					new SqlParameter("@OrderFlag", SqlDbType.Int,4),
					new SqlParameter("@CreatedTime", SqlDbType.DateTime),
					new SqlParameter("@UpdatedTime", SqlDbType.DateTime),
					new SqlParameter("@TopicCount", SqlDbType.Int,4),
					new SqlParameter("@ReplyCount", SqlDbType.Int,4),
					new SqlParameter("@PostCount", SqlDbType.Int,4),
					new SqlParameter("@TodayPostCount", SqlDbType.Int,4),
					new SqlParameter("@SatisticsTime", SqlDbType.DateTime),
					new SqlParameter("@ChannelFlag", SqlDbType.Int,4),
					new SqlParameter("@ReadFlag", SqlDbType.Int,4),
					new SqlParameter("@WriteFlag", SqlDbType.Int,4),
					new SqlParameter("@ChannelLinkFlag", SqlDbType.Int,4),
					new SqlParameter("@ChannelLinkUrl", SqlDbType.VarChar,200),
					new SqlParameter("@LatestBBSTopicID", SqlDbType.Int,4),
					new SqlParameter("@LatestBBSTopicTitle", SqlDbType.VarChar,500),
					new SqlParameter("@LatestBBSTopicUserID", SqlDbType.Int,4),
					new SqlParameter("@LatestBBSTopicUserName", SqlDbType.VarChar,50),
					new SqlParameter("@LatestBBSTopicRepliedTime", SqlDbType.DateTime),
					new SqlParameter("@CompanyID", SqlDbType.Int,4),
                    new SqlParameter("@ParentID",SqlDbType.Int,4) };
			
			parameters[0].Value = model.ChannelName;
			parameters[1].Value = model.ChannelDescription;
			parameters[2].Value = model.ChannelImageUrl;
			parameters[3].Value = model.OrderFlag;
			parameters[4].Value = model.CreatedTime;
			parameters[5].Value = model.UpdatedTime;
			parameters[6].Value = model.TopicCount;
			parameters[7].Value = model.ReplyCount;
			parameters[8].Value = model.PostCount;
			parameters[9].Value = model.TodayPostCount;
			parameters[10].Value = model.SatisticsTime;
			parameters[11].Value = model.ChannelFlag;
			parameters[12].Value = model.ReadFlag;
			parameters[13].Value = model.WriteFlag;
			parameters[14].Value = model.ChannelLinkFlag;
			parameters[15].Value = model.ChannelLinkUrl;
			parameters[16].Value = model.LatestBBSTopicID;
			parameters[17].Value = model.LatestBBSTopicTitle;
			parameters[18].Value = model.LatestBBSTopicUserID;
			parameters[19].Value = model.LatestBBSTopicUserName;
			parameters[20].Value = model.LatestBBSTopicRepliedTime;
			parameters[21].Value = model.CompanyID;
		    parameters[22].Value = model.ParentID;

			object obj = DB.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
			return 0;		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Channels_Update(Entity.Channels model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}Channels set ",sPre);
			strSql.Append("ChannelName=@ChannelName,");
			strSql.Append("ChannelDescription=@ChannelDescription,");
			strSql.Append("ChannelImageUrl=@ChannelImageUrl,");
			strSql.Append("OrderFlag=@OrderFlag,");
			strSql.Append("CreatedTime=@CreatedTime,");
			strSql.Append("UpdatedTime=@UpdatedTime,");
			strSql.Append("TopicCount=@TopicCount,");
			strSql.Append("ReplyCount=@ReplyCount,");
			strSql.Append("PostCount=@PostCount,");
			strSql.Append("TodayPostCount=@TodayPostCount,");
			strSql.Append("SatisticsTime=@SatisticsTime,");
			strSql.Append("ChannelFlag=@ChannelFlag,");
			strSql.Append("ReadFlag=@ReadFlag,");
			strSql.Append("WriteFlag=@WriteFlag,");
			strSql.Append("ChannelLinkFlag=@ChannelLinkFlag,");
			strSql.Append("ChannelLinkUrl=@ChannelLinkUrl,");
			strSql.Append("LatestBBSTopicID=@LatestBBSTopicID,");
			strSql.Append("LatestBBSTopicTitle=@LatestBBSTopicTitle,");
			strSql.Append("LatestBBSTopicUserID=@LatestBBSTopicUserID,");
			strSql.Append("LatestBBSTopicUserName=@LatestBBSTopicUserName,");
			strSql.Append("LatestBBSTopicRepliedTime=@LatestBBSTopicRepliedTime,");
			strSql.Append("CompanyID=@CompanyID,");
		    strSql.Append("ParentID=@ParentID");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@ChannelName", SqlDbType.VarChar,50),
					new SqlParameter("@ChannelDescription", SqlDbType.VarChar,8000),
					new SqlParameter("@ChannelImageUrl", SqlDbType.VarChar,500),
					new SqlParameter("@OrderFlag", SqlDbType.Int,4),
					new SqlParameter("@CreatedTime", SqlDbType.DateTime),
					new SqlParameter("@UpdatedTime", SqlDbType.DateTime),
					new SqlParameter("@TopicCount", SqlDbType.Int,4),
					new SqlParameter("@ReplyCount", SqlDbType.Int,4),
					new SqlParameter("@PostCount", SqlDbType.Int,4),
					new SqlParameter("@TodayPostCount", SqlDbType.Int,4),
					new SqlParameter("@SatisticsTime", SqlDbType.DateTime),
					new SqlParameter("@ChannelFlag", SqlDbType.Int,4),
					new SqlParameter("@ReadFlag", SqlDbType.Int,4),
					new SqlParameter("@WriteFlag", SqlDbType.Int,4),
					new SqlParameter("@ChannelLinkFlag", SqlDbType.Int,4),
					new SqlParameter("@ChannelLinkUrl", SqlDbType.VarChar,200),
					new SqlParameter("@LatestBBSTopicID", SqlDbType.Int,4),
					new SqlParameter("@LatestBBSTopicTitle", SqlDbType.VarChar,500),
					new SqlParameter("@LatestBBSTopicUserID", SqlDbType.Int,4),
					new SqlParameter("@LatestBBSTopicUserName", SqlDbType.VarChar,50),
					new SqlParameter("@LatestBBSTopicRepliedTime", SqlDbType.DateTime),
					new SqlParameter("@CompanyID", SqlDbType.Int,4),
                    new SqlParameter("@ParentID",SqlDbType.Int,4) };
			parameters[0].Value = model.id;
			parameters[1].Value = model.ChannelName;
			parameters[2].Value = model.ChannelDescription;
			parameters[3].Value = model.ChannelImageUrl;
			parameters[4].Value = model.OrderFlag;
			parameters[5].Value = model.CreatedTime;
			parameters[6].Value = model.UpdatedTime;
			parameters[7].Value = model.TopicCount;
			parameters[8].Value = model.ReplyCount;
			parameters[9].Value = model.PostCount;
			parameters[10].Value = model.TodayPostCount;
			parameters[11].Value = model.SatisticsTime;
			parameters[12].Value = model.ChannelFlag;
			parameters[13].Value = model.ReadFlag;
			parameters[14].Value = model.WriteFlag;
			parameters[15].Value = model.ChannelLinkFlag;
			parameters[16].Value = model.ChannelLinkUrl;
			parameters[17].Value = model.LatestBBSTopicID;
			parameters[18].Value = model.LatestBBSTopicTitle;
			parameters[19].Value = model.LatestBBSTopicUserID;
			parameters[20].Value = model.LatestBBSTopicUserName;
			parameters[21].Value = model.LatestBBSTopicRepliedTime;
			parameters[22].Value = model.CompanyID;
		    parameters[23].Value = model.ParentID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Channels_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}Channels ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.Channels Channels_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldChannels +"  from {0}Channels ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;
			Entity.Channels model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= Channels_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int Channels_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}Channels ",sPre);
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			int iCount = 0;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text,strSql.ToString()))
			{
				while (dataReader.Read())
				{
					iCount = int.Parse(dataReader[0].ToString());
				}
			}
			return iCount;
		}


		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet Channels_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldChannels );
			strSql.AppendFormat(" FROM {0}Channels ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			return DB.ExecuteDataset(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<Entity.Channels> Channels_GetListArray(string strWhere)
		{
			return Channels_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.Channels> Channels_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldChannels );
			strSql.AppendFormat(" FROM {0}Channels ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.Channels> list = new List<Entity.Channels>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(Channels_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.Channels> Channels_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.Channels> list = new List<Entity.Channels>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"Channels", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(Channels_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.Channels Channels_ReaderBind(IDataReader dataReader)
		{
			Entity.Channels model=new Entity.Channels();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.ChannelName=dataReader["ChannelName"].ToString();
			model.ChannelDescription=dataReader["ChannelDescription"].ToString();
			model.ChannelImageUrl=dataReader["ChannelImageUrl"].ToString();
			ojb = dataReader["OrderFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderFlag=(int)ojb;
			}
			ojb = dataReader["CreatedTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CreatedTime=(DateTime)ojb;
			}
			ojb = dataReader["UpdatedTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UpdatedTime=(DateTime)ojb;
			}
			ojb = dataReader["TopicCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TopicCount=(int)ojb;
			}
			ojb = dataReader["ReplyCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ReplyCount=(int)ojb;
			}
			ojb = dataReader["PostCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PostCount=(int)ojb;
			}
			ojb = dataReader["TodayPostCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TodayPostCount=(int)ojb;
			}
			ojb = dataReader["SatisticsTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SatisticsTime=(DateTime)ojb;
			}
			ojb = dataReader["ChannelFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ChannelFlag=(int)ojb;
			}
			ojb = dataReader["ReadFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ReadFlag=(int)ojb;
			}
			ojb = dataReader["WriteFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.WriteFlag=(int)ojb;
			}
			ojb = dataReader["ChannelLinkFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ChannelLinkFlag=(int)ojb;
			}
			model.ChannelLinkUrl=dataReader["ChannelLinkUrl"].ToString();
			ojb = dataReader["LatestBBSTopicID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LatestBBSTopicID=(int)ojb;
			}
			model.LatestBBSTopicTitle=dataReader["LatestBBSTopicTitle"].ToString();
			ojb = dataReader["LatestBBSTopicUserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LatestBBSTopicUserID=(int)ojb;
			}
			model.LatestBBSTopicUserName=dataReader["LatestBBSTopicUserName"].ToString();
			ojb = dataReader["LatestBBSTopicRepliedTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LatestBBSTopicRepliedTime=(DateTime)ojb;
			}
			ojb = dataReader["CompanyID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CompanyID=(int)ojb;
			}
		    ojb = dataReader["ParentID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ParentID = (int)ojb;
            }
			return model;
		}

		#endregion  成员方法
	}
}

