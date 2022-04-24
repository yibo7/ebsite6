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
		private string sFieldTopics = "id,ChannelID,ChannelName,TopicTitle,TopicContent,TopicDescription,ViewCount,ReplyCount,UserID,UserName,OrderTopFlag,OrderTopTime,OrderTopMasterUserID,OrderTopMasterUserName,RecommendFlag,RecommendTime,RecommendMasterUserID,RecommendMasterUserName,ReplyStatusFlag,ModifyStatusFlag,HasImageFlag,TopicImageUrl,IsBadCount,IsGoodCount,ConclusionFlag,AuditFlag,LatestReplyUserID,LatestReplyUserName,LatestRepliedTime,GoodFlag,GoodTime,GoodDescription,GoodImageUrl,GoodMasterUserID,GoodMasterUserName,SiteOrderTopFlag,SiteOrderTopTime,SiteOrderTopMasterUserID,SiteOrderTopMasterUserName,TopicFlag,ReferenceID,DeleteFlag,CreatedTime,CreatedIP,UpdatedTime,TitleBoldFlag,TitleBoldTime,TitleColorFlag,TitleColorCode,TitleColorTime,CompanyID,tag";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public long Topics_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}Topics",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Topics_Exists(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}Topics",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt,8)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Topics_Add(Entity.Topics model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}Topics(",sPre);
			strSql.Append("ChannelID,ChannelName,TopicTitle,TopicContent,TopicDescription,ViewCount,ReplyCount,UserID,UserName,OrderTopFlag,OrderTopTime,OrderTopMasterUserID,OrderTopMasterUserName,RecommendFlag,RecommendTime,RecommendMasterUserID,RecommendMasterUserName,ReplyStatusFlag,ModifyStatusFlag,HasImageFlag,TopicImageUrl,IsBadCount,IsGoodCount,ConclusionFlag,AuditFlag,LatestReplyUserID,LatestReplyUserName,LatestRepliedTime,GoodFlag,GoodTime,GoodDescription,GoodImageUrl,GoodMasterUserID,GoodMasterUserName,SiteOrderTopFlag,SiteOrderTopTime,SiteOrderTopMasterUserID,SiteOrderTopMasterUserName,TopicFlag,ReferenceID,DeleteFlag,CreatedTime,CreatedIP,UpdatedTime,TitleBoldFlag,TitleBoldTime,TitleColorFlag,TitleColorCode,TitleColorTime,CompanyID,tag)");
			strSql.Append(" values (");
			strSql.Append("@ChannelID,@ChannelName,@TopicTitle,@TopicContent,@TopicDescription,@ViewCount,@ReplyCount,@UserID,@UserName,@OrderTopFlag,@OrderTopTime,@OrderTopMasterUserID,@OrderTopMasterUserName,@RecommendFlag,@RecommendTime,@RecommendMasterUserID,@RecommendMasterUserName,@ReplyStatusFlag,@ModifyStatusFlag,@HasImageFlag,@TopicImageUrl,@IsBadCount,@IsGoodCount,@ConclusionFlag,@AuditFlag,@LatestReplyUserID,@LatestReplyUserName,@LatestRepliedTime,@GoodFlag,@GoodTime,@GoodDescription,@GoodImageUrl,@GoodMasterUserID,@GoodMasterUserName,@SiteOrderTopFlag,@SiteOrderTopTime,@SiteOrderTopMasterUserID,@SiteOrderTopMasterUserName,@TopicFlag,@ReferenceID,@DeleteFlag,@CreatedTime,@CreatedIP,@UpdatedTime,@TitleBoldFlag,@TitleBoldTime,@TitleColorFlag,@TitleColorCode,@TitleColorTime,@CompanyID,@tag)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					
					new SqlParameter("@ChannelID", SqlDbType.Int,4),
					new SqlParameter("@ChannelName", SqlDbType.VarChar,50),
					new SqlParameter("@TopicTitle", SqlDbType.VarChar,500),
					new SqlParameter("@TopicContent", SqlDbType.VarChar),
					new SqlParameter("@TopicDescription", SqlDbType.VarChar,5000),
					new SqlParameter("@ViewCount", SqlDbType.Int,4),
					new SqlParameter("@ReplyCount", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,200),
					new SqlParameter("@OrderTopFlag", SqlDbType.Int,4),
					new SqlParameter("@OrderTopTime", SqlDbType.DateTime),
					new SqlParameter("@OrderTopMasterUserID", SqlDbType.Int,4),
					new SqlParameter("@OrderTopMasterUserName", SqlDbType.VarChar,200),
					new SqlParameter("@RecommendFlag", SqlDbType.Int,4),
					new SqlParameter("@RecommendTime", SqlDbType.DateTime),
					new SqlParameter("@RecommendMasterUserID", SqlDbType.Int,4),
					new SqlParameter("@RecommendMasterUserName", SqlDbType.VarChar,200),
					new SqlParameter("@ReplyStatusFlag", SqlDbType.Int,4),
					new SqlParameter("@ModifyStatusFlag", SqlDbType.Int,4),
					new SqlParameter("@HasImageFlag", SqlDbType.Int,4),
					new SqlParameter("@TopicImageUrl", SqlDbType.VarChar,500),
					new SqlParameter("@IsBadCount", SqlDbType.Int,4),
					new SqlParameter("@IsGoodCount", SqlDbType.Int,4),
					new SqlParameter("@ConclusionFlag", SqlDbType.Int,4),
					new SqlParameter("@AuditFlag", SqlDbType.Int,4),
					new SqlParameter("@LatestReplyUserID", SqlDbType.Int,4),
					new SqlParameter("@LatestReplyUserName", SqlDbType.VarChar,50),
					new SqlParameter("@LatestRepliedTime", SqlDbType.DateTime),
					new SqlParameter("@GoodFlag", SqlDbType.Int,4),
					new SqlParameter("@GoodTime", SqlDbType.DateTime),
					new SqlParameter("@GoodDescription", SqlDbType.VarChar,5000),
					new SqlParameter("@GoodImageUrl", SqlDbType.VarChar,500),
					new SqlParameter("@GoodMasterUserID", SqlDbType.Int,4),
					new SqlParameter("@GoodMasterUserName", SqlDbType.VarChar,200),
					new SqlParameter("@SiteOrderTopFlag", SqlDbType.Int,4),
					new SqlParameter("@SiteOrderTopTime", SqlDbType.DateTime),
					new SqlParameter("@SiteOrderTopMasterUserID", SqlDbType.Int,4),
					new SqlParameter("@SiteOrderTopMasterUserName", SqlDbType.VarChar,200),
					new SqlParameter("@TopicFlag", SqlDbType.Int,4),
					new SqlParameter("@ReferenceID", SqlDbType.Int,4),
					new SqlParameter("@DeleteFlag", SqlDbType.Int,4),
					new SqlParameter("@CreatedTime", SqlDbType.DateTime),
					new SqlParameter("@CreatedIP", SqlDbType.VarChar,50),
					new SqlParameter("@UpdatedTime", SqlDbType.DateTime),
					new SqlParameter("@TitleBoldFlag", SqlDbType.Int,4),
					new SqlParameter("@TitleBoldTime", SqlDbType.DateTime),
					new SqlParameter("@TitleColorFlag", SqlDbType.Int,4),
					new SqlParameter("@TitleColorCode", SqlDbType.VarChar,50),
					new SqlParameter("@TitleColorTime", SqlDbType.DateTime),
					new SqlParameter("@CompanyID", SqlDbType.Int,4),
					new SqlParameter("@tag", SqlDbType.Int,4)};
		
			parameters[0].Value = model.ChannelID;
			parameters[1].Value = model.ChannelName;
			parameters[2].Value = model.TopicTitle;
			parameters[3].Value = model.TopicContent;
			parameters[4].Value = model.TopicDescription;
			parameters[5].Value = model.ViewCount;
			parameters[6].Value = model.ReplyCount;
			parameters[7].Value = model.UserID;
			parameters[8].Value = model.UserName;
			parameters[9].Value = model.OrderTopFlag;
			parameters[10].Value = model.OrderTopTime;
			parameters[11].Value = model.OrderTopMasterUserID;
			parameters[12].Value = model.OrderTopMasterUserName;
			parameters[13].Value = model.RecommendFlag;
			parameters[14].Value = model.RecommendTime;
			parameters[15].Value = model.RecommendMasterUserID;
			parameters[16].Value = model.RecommendMasterUserName;
			parameters[17].Value = model.ReplyStatusFlag;
			parameters[18].Value = model.ModifyStatusFlag;
			parameters[19].Value = model.HasImageFlag;
			parameters[20].Value = model.TopicImageUrl;
			parameters[21].Value = model.IsBadCount;
			parameters[22].Value = model.IsGoodCount;
			parameters[23].Value = model.ConclusionFlag;
			parameters[24].Value = model.AuditFlag;
			parameters[25].Value = model.LatestReplyUserID;
			parameters[26].Value = model.LatestReplyUserName;
			parameters[27].Value = model.LatestRepliedTime;
			parameters[28].Value = model.GoodFlag;
			parameters[29].Value = model.GoodTime;
			parameters[30].Value = model.GoodDescription;
			parameters[31].Value = model.GoodImageUrl;
			parameters[32].Value = model.GoodMasterUserID;
			parameters[33].Value = model.GoodMasterUserName;
			parameters[34].Value = model.SiteOrderTopFlag;
			parameters[35].Value = model.SiteOrderTopTime;
			parameters[36].Value = model.SiteOrderTopMasterUserID;
			parameters[37].Value = model.SiteOrderTopMasterUserName;
			parameters[38].Value = model.TopicFlag;
			parameters[39].Value = model.ReferenceID;
			parameters[40].Value = model.DeleteFlag;
			parameters[41].Value = model.CreatedTime;
			parameters[42].Value = model.CreatedIP;
			parameters[43].Value = model.UpdatedTime;
			parameters[44].Value = model.TitleBoldFlag;
			parameters[45].Value = model.TitleBoldTime;
			parameters[46].Value = model.TitleColorFlag;
			parameters[47].Value = model.TitleColorCode;
			parameters[48].Value = model.TitleColorTime;
			parameters[49].Value = model.CompanyID;
			parameters[50].Value = model.tag;

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
		public void Topics_Update(Entity.Topics model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}Topics set ",sPre);
			strSql.Append("ChannelID=@ChannelID,");
			strSql.Append("ChannelName=@ChannelName,");
			strSql.Append("TopicTitle=@TopicTitle,");
			strSql.Append("TopicContent=@TopicContent,");
			strSql.Append("TopicDescription=@TopicDescription,");
			strSql.Append("ViewCount=@ViewCount,");
			strSql.Append("ReplyCount=@ReplyCount,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("OrderTopFlag=@OrderTopFlag,");
			strSql.Append("OrderTopTime=@OrderTopTime,");
			strSql.Append("OrderTopMasterUserID=@OrderTopMasterUserID,");
			strSql.Append("OrderTopMasterUserName=@OrderTopMasterUserName,");
			strSql.Append("RecommendFlag=@RecommendFlag,");
			strSql.Append("RecommendTime=@RecommendTime,");
			strSql.Append("RecommendMasterUserID=@RecommendMasterUserID,");
			strSql.Append("RecommendMasterUserName=@RecommendMasterUserName,");
			strSql.Append("ReplyStatusFlag=@ReplyStatusFlag,");
			strSql.Append("ModifyStatusFlag=@ModifyStatusFlag,");
			strSql.Append("HasImageFlag=@HasImageFlag,");
			strSql.Append("TopicImageUrl=@TopicImageUrl,");
			strSql.Append("IsBadCount=@IsBadCount,");
			strSql.Append("IsGoodCount=@IsGoodCount,");
			strSql.Append("ConclusionFlag=@ConclusionFlag,");
			strSql.Append("AuditFlag=@AuditFlag,");
			strSql.Append("LatestReplyUserID=@LatestReplyUserID,");
			strSql.Append("LatestReplyUserName=@LatestReplyUserName,");
			strSql.Append("LatestRepliedTime=@LatestRepliedTime,");
			strSql.Append("GoodFlag=@GoodFlag,");
			strSql.Append("GoodTime=@GoodTime,");
			strSql.Append("GoodDescription=@GoodDescription,");
			strSql.Append("GoodImageUrl=@GoodImageUrl,");
			strSql.Append("GoodMasterUserID=@GoodMasterUserID,");
			strSql.Append("GoodMasterUserName=@GoodMasterUserName,");
			strSql.Append("SiteOrderTopFlag=@SiteOrderTopFlag,");
			strSql.Append("SiteOrderTopTime=@SiteOrderTopTime,");
			strSql.Append("SiteOrderTopMasterUserID=@SiteOrderTopMasterUserID,");
			strSql.Append("SiteOrderTopMasterUserName=@SiteOrderTopMasterUserName,");
			strSql.Append("TopicFlag=@TopicFlag,");
			strSql.Append("ReferenceID=@ReferenceID,");
			strSql.Append("DeleteFlag=@DeleteFlag,");
			strSql.Append("CreatedTime=@CreatedTime,");
			strSql.Append("CreatedIP=@CreatedIP,");
			strSql.Append("UpdatedTime=@UpdatedTime,");
			strSql.Append("TitleBoldFlag=@TitleBoldFlag,");
			strSql.Append("TitleBoldTime=@TitleBoldTime,");
			strSql.Append("TitleColorFlag=@TitleColorFlag,");
			strSql.Append("TitleColorCode=@TitleColorCode,");
			strSql.Append("TitleColorTime=@TitleColorTime,");
			strSql.Append("CompanyID=@CompanyID,");
			strSql.Append("tag=@tag");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt,8),
					new SqlParameter("@ChannelID", SqlDbType.Int,4),
					new SqlParameter("@ChannelName", SqlDbType.VarChar,50),
					new SqlParameter("@TopicTitle", SqlDbType.VarChar,500),
					new SqlParameter("@TopicContent", SqlDbType.VarChar),
					new SqlParameter("@TopicDescription", SqlDbType.VarChar,5000),
					new SqlParameter("@ViewCount", SqlDbType.Int,4),
					new SqlParameter("@ReplyCount", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,200),
					new SqlParameter("@OrderTopFlag", SqlDbType.Int,4),
					new SqlParameter("@OrderTopTime", SqlDbType.DateTime),
					new SqlParameter("@OrderTopMasterUserID", SqlDbType.Int,4),
					new SqlParameter("@OrderTopMasterUserName", SqlDbType.VarChar,200),
					new SqlParameter("@RecommendFlag", SqlDbType.Int,4),
					new SqlParameter("@RecommendTime", SqlDbType.DateTime),
					new SqlParameter("@RecommendMasterUserID", SqlDbType.Int,4),
					new SqlParameter("@RecommendMasterUserName", SqlDbType.VarChar,200),
					new SqlParameter("@ReplyStatusFlag", SqlDbType.Int,4),
					new SqlParameter("@ModifyStatusFlag", SqlDbType.Int,4),
					new SqlParameter("@HasImageFlag", SqlDbType.Int,4),
					new SqlParameter("@TopicImageUrl", SqlDbType.VarChar,500),
					new SqlParameter("@IsBadCount", SqlDbType.Int,4),
					new SqlParameter("@IsGoodCount", SqlDbType.Int,4),
					new SqlParameter("@ConclusionFlag", SqlDbType.Int,4),
					new SqlParameter("@AuditFlag", SqlDbType.Int,4),
					new SqlParameter("@LatestReplyUserID", SqlDbType.Int,4),
					new SqlParameter("@LatestReplyUserName", SqlDbType.VarChar,50),
					new SqlParameter("@LatestRepliedTime", SqlDbType.DateTime),
					new SqlParameter("@GoodFlag", SqlDbType.Int,4),
					new SqlParameter("@GoodTime", SqlDbType.DateTime),
					new SqlParameter("@GoodDescription", SqlDbType.VarChar,5000),
					new SqlParameter("@GoodImageUrl", SqlDbType.VarChar,500),
					new SqlParameter("@GoodMasterUserID", SqlDbType.Int,4),
					new SqlParameter("@GoodMasterUserName", SqlDbType.VarChar,200),
					new SqlParameter("@SiteOrderTopFlag", SqlDbType.Int,4),
					new SqlParameter("@SiteOrderTopTime", SqlDbType.DateTime),
					new SqlParameter("@SiteOrderTopMasterUserID", SqlDbType.Int,4),
					new SqlParameter("@SiteOrderTopMasterUserName", SqlDbType.VarChar,200),
					new SqlParameter("@TopicFlag", SqlDbType.Int,4),
					new SqlParameter("@ReferenceID", SqlDbType.Int,4),
					new SqlParameter("@DeleteFlag", SqlDbType.Int,4),
					new SqlParameter("@CreatedTime", SqlDbType.DateTime),
					new SqlParameter("@CreatedIP", SqlDbType.VarChar,50),
					new SqlParameter("@UpdatedTime", SqlDbType.DateTime),
					new SqlParameter("@TitleBoldFlag", SqlDbType.Int,4),
					new SqlParameter("@TitleBoldTime", SqlDbType.DateTime),
					new SqlParameter("@TitleColorFlag", SqlDbType.Int,4),
					new SqlParameter("@TitleColorCode", SqlDbType.VarChar,50),
					new SqlParameter("@TitleColorTime", SqlDbType.DateTime),
					new SqlParameter("@CompanyID", SqlDbType.Int,4),
					new SqlParameter("@tag", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.ChannelID;
			parameters[2].Value = model.ChannelName;
			parameters[3].Value = model.TopicTitle;
			parameters[4].Value = model.TopicContent;
			parameters[5].Value = model.TopicDescription;
			parameters[6].Value = model.ViewCount;
			parameters[7].Value = model.ReplyCount;
			parameters[8].Value = model.UserID;
			parameters[9].Value = model.UserName;
			parameters[10].Value = model.OrderTopFlag;
			parameters[11].Value = model.OrderTopTime;
			parameters[12].Value = model.OrderTopMasterUserID;
			parameters[13].Value = model.OrderTopMasterUserName;
			parameters[14].Value = model.RecommendFlag;
			parameters[15].Value = model.RecommendTime;
			parameters[16].Value = model.RecommendMasterUserID;
			parameters[17].Value = model.RecommendMasterUserName;
			parameters[18].Value = model.ReplyStatusFlag;
			parameters[19].Value = model.ModifyStatusFlag;
			parameters[20].Value = model.HasImageFlag;
			parameters[21].Value = model.TopicImageUrl;
			parameters[22].Value = model.IsBadCount;
			parameters[23].Value = model.IsGoodCount;
			parameters[24].Value = model.ConclusionFlag;
			parameters[25].Value = model.AuditFlag;
			parameters[26].Value = model.LatestReplyUserID;
			parameters[27].Value = model.LatestReplyUserName;
			parameters[28].Value = model.LatestRepliedTime;
			parameters[29].Value = model.GoodFlag;
			parameters[30].Value = model.GoodTime;
			parameters[31].Value = model.GoodDescription;
			parameters[32].Value = model.GoodImageUrl;
			parameters[33].Value = model.GoodMasterUserID;
			parameters[34].Value = model.GoodMasterUserName;
			parameters[35].Value = model.SiteOrderTopFlag;
			parameters[36].Value = model.SiteOrderTopTime;
			parameters[37].Value = model.SiteOrderTopMasterUserID;
			parameters[38].Value = model.SiteOrderTopMasterUserName;
			parameters[39].Value = model.TopicFlag;
			parameters[40].Value = model.ReferenceID;
			parameters[41].Value = model.DeleteFlag;
			parameters[42].Value = model.CreatedTime;
			parameters[43].Value = model.CreatedIP;
			parameters[44].Value = model.UpdatedTime;
			parameters[45].Value = model.TitleBoldFlag;
			parameters[46].Value = model.TitleBoldTime;
			parameters[47].Value = model.TitleColorFlag;
			parameters[48].Value = model.TitleColorCode;
			parameters[49].Value = model.TitleColorTime;
			parameters[50].Value = model.CompanyID;
			parameters[51].Value = model.tag;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Topics_Delete(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}Topics ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt,8)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.Topics Topics_GetEntity(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldTopics +"  from {0}Topics ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt,8)};
			parameters[0].Value = id;
			Entity.Topics model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= Topics_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int Topics_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}Topics ",sPre);
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
		public DataSet Topics_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldTopics );
			strSql.AppendFormat(" FROM {0}Topics ",sPre);
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
		public List<Entity.Topics> Topics_GetListArray(string strWhere)
		{
			return Topics_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.Topics> Topics_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldTopics );
			strSql.AppendFormat(" FROM {0}Topics ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.Topics> list = new List<Entity.Topics>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(Topics_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.Topics> Topics_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.Topics> list = new List<Entity.Topics>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"Topics", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(Topics_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.Topics Topics_ReaderBind(IDataReader dataReader)
		{
			Entity.Topics model=new Entity.Topics();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(long)ojb;
			}
			ojb = dataReader["ChannelID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ChannelID=(int)ojb;
			}
			model.ChannelName=dataReader["ChannelName"].ToString();
			model.TopicTitle=dataReader["TopicTitle"].ToString();
			model.TopicContent=dataReader["TopicContent"].ToString();
			model.TopicDescription=dataReader["TopicDescription"].ToString();
			ojb = dataReader["ViewCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ViewCount=(int)ojb;
			}
			ojb = dataReader["ReplyCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ReplyCount=(int)ojb;
			}
			ojb = dataReader["UserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserID=(int)ojb;
			}
			model.UserName=dataReader["UserName"].ToString();
			ojb = dataReader["OrderTopFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderTopFlag=(int)ojb;
			}
			ojb = dataReader["OrderTopTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderTopTime=(DateTime)ojb;
			}
			ojb = dataReader["OrderTopMasterUserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderTopMasterUserID=(int)ojb;
			}
			model.OrderTopMasterUserName=dataReader["OrderTopMasterUserName"].ToString();
			ojb = dataReader["RecommendFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.RecommendFlag=(int)ojb;
			}
			ojb = dataReader["RecommendTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.RecommendTime=(DateTime)ojb;
			}
			ojb = dataReader["RecommendMasterUserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.RecommendMasterUserID=(int)ojb;
			}
			model.RecommendMasterUserName=dataReader["RecommendMasterUserName"].ToString();
			ojb = dataReader["ReplyStatusFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ReplyStatusFlag=(int)ojb;
			}
			ojb = dataReader["ModifyStatusFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ModifyStatusFlag=(int)ojb;
			}
			ojb = dataReader["HasImageFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.HasImageFlag=(int)ojb;
			}
			model.TopicImageUrl=dataReader["TopicImageUrl"].ToString();
			ojb = dataReader["IsBadCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsBadCount=(int)ojb;
			}
			ojb = dataReader["IsGoodCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsGoodCount=(int)ojb;
			}
			ojb = dataReader["ConclusionFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ConclusionFlag=(int)ojb;
			}
			ojb = dataReader["AuditFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AuditFlag=(int)ojb;
			}
			ojb = dataReader["LatestReplyUserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LatestReplyUserID=(int)ojb;
			}
			model.LatestReplyUserName=dataReader["LatestReplyUserName"].ToString();
			ojb = dataReader["LatestRepliedTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LatestRepliedTime=(DateTime)ojb;
			}
			ojb = dataReader["GoodFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.GoodFlag=(int)ojb;
			}
			ojb = dataReader["GoodTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.GoodTime=(DateTime)ojb;
			}
			model.GoodDescription=dataReader["GoodDescription"].ToString();
			model.GoodImageUrl=dataReader["GoodImageUrl"].ToString();
			ojb = dataReader["GoodMasterUserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.GoodMasterUserID=(int)ojb;
			}
			model.GoodMasterUserName=dataReader["GoodMasterUserName"].ToString();
			ojb = dataReader["SiteOrderTopFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SiteOrderTopFlag=(int)ojb;
			}
			ojb = dataReader["SiteOrderTopTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SiteOrderTopTime=(DateTime)ojb;
			}
			ojb = dataReader["SiteOrderTopMasterUserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SiteOrderTopMasterUserID=(int)ojb;
			}
			model.SiteOrderTopMasterUserName=dataReader["SiteOrderTopMasterUserName"].ToString();
			ojb = dataReader["TopicFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TopicFlag=(int)ojb;
			}
			ojb = dataReader["ReferenceID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ReferenceID=(int)ojb;
			}
			ojb = dataReader["DeleteFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DeleteFlag=(int)ojb;
			}
			ojb = dataReader["CreatedTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CreatedTime=(DateTime)ojb;
			}
			model.CreatedIP=dataReader["CreatedIP"].ToString();
			ojb = dataReader["UpdatedTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UpdatedTime=(DateTime)ojb;
			}
			ojb = dataReader["TitleBoldFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TitleBoldFlag=(int)ojb;
			}
			ojb = dataReader["TitleBoldTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TitleBoldTime=(DateTime)ojb;
			}
			ojb = dataReader["TitleColorFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TitleColorFlag=(int)ojb;
			}
			model.TitleColorCode=dataReader["TitleColorCode"].ToString();
			ojb = dataReader["TitleColorTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TitleColorTime=(DateTime)ojb;
			}
			ojb = dataReader["CompanyID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CompanyID=(int)ojb;
			}
			ojb = dataReader["tag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.tag=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

