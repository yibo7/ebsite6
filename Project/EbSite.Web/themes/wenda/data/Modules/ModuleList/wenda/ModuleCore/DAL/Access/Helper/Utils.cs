using System;
using System.Collections.Generic;
using System.Web;

namespace EbSite.Modules.Ask.ModuleCore.DAL.Access
{
    public partial class Ask: DALInterface.IDataProvider
    {
        public static  string sPre
        {
             get
            {
                if (!SettingInfo.Instance.GetBaseConfig.Instance.IsUserSysConn)
                {
                    return SettingInfo.Instance.GetBaseConfig.Instance.TablePrefix;
                }
                else
                {
                   
                    return Base.Host.Instance.GetSysTablePrefix;
                }
            }
        }
        public static readonly DataProfile.DBHelper DB = new DataProfile.DBHelper();

        #region IDataProvider Members

        public int Answers_GetMaxId()
        {
            throw new NotImplementedException();
        }

        public bool Answers_Exists(int id)
        {
            throw new NotImplementedException();
        }

        public int Answers_Add(Entity.Answers model)
        {
            throw new NotImplementedException();
        }

        public void Answers_Update(Entity.Answers model)
        {
            throw new NotImplementedException();
        }

        public int Answers_GetCount(string strWhere)
        {
            throw new NotImplementedException();
        }

        public void Answers_Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Entity.Answers Answers_GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public List<Entity.Answers> Answers_GetListArray(string strWhere)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet Answers_GetList(int Top, string strWhere, string filedOrder)
        {
            throw new NotImplementedException();
        }

        public List<Entity.Answers> Answers_GetListArray(int Top, string strWhere, string filedOrder)
        {
            throw new NotImplementedException();
        }

        public List<Entity.Answers> Answers_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            throw new NotImplementedException();
        }

        public Entity.Answers Answers_ReaderBind(System.Data.IDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        public int Comment_GetMaxId()
        {
            throw new NotImplementedException();
        }

        public bool Comment_Exists(int id)
        {
            throw new NotImplementedException();
        }

        public int Comment_Add(Entity.Comment model)
        {
            throw new NotImplementedException();
        }

        public void Comment_Update(Entity.Comment model)
        {
            throw new NotImplementedException();
        }

        public int Comment_GetCount(string strWhere)
        {
            throw new NotImplementedException();
        }

        public void Comment_Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Entity.Comment Comment_GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public List<Entity.Comment> Comment_GetListArray(string strWhere)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet Comment_GetList(int Top, string strWhere, string filedOrder)
        {
            throw new NotImplementedException();
        }

        public List<Entity.Comment> Comment_GetListArray(int Top, string strWhere, string filedOrder)
        {
            throw new NotImplementedException();
        }

        public List<Entity.Comment> Comment_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            throw new NotImplementedException();
        }

        public Entity.Comment Comment_ReaderBind(System.Data.IDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        public int Config_GetMaxId()
        {
            throw new NotImplementedException();
        }

        public bool Config_Exists(int id)
        {
            throw new NotImplementedException();
        }

        public int Config_Add(Entity.Config model)
        {
            throw new NotImplementedException();
        }

        public void Config_Update(Entity.Config model)
        {
            throw new NotImplementedException();
        }

        public int Config_GetCount(string strWhere)
        {
            throw new NotImplementedException();
        }

        public void Config_Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Entity.Config Config_GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public List<Entity.Config> Config_GetListArray(string strWhere)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet Config_GetList(int Top, string strWhere, string filedOrder)
        {
            throw new NotImplementedException();
        }

        public List<Entity.Config> Config_GetListArray(int Top, string strWhere, string filedOrder)
        {
            throw new NotImplementedException();
        }

        public List<Entity.Config> Config_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            throw new NotImplementedException();
        }

        public Entity.Config Config_ReaderBind(System.Data.IDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        public int UserHelp_GetMaxId()
        {
            throw new NotImplementedException();
        }

        public bool UserHelp_Exists(int id)
        {
            throw new NotImplementedException();
        }

        public int UserHelp_Add(Entity.UserHelp model)
        {
            throw new NotImplementedException();
        }

        public void UserHelp_Update(Entity.UserHelp model)
        {
            throw new NotImplementedException();
        }

        public int UserHelp_GetCount(string strWhere)
        {
            throw new NotImplementedException();
        }

        public void UserHelp_Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Entity.UserHelp UserHelp_GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public List<Entity.UserHelp> UserHelp_GetListArray(string strWhere)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet UserHelp_GetList(int Top, string strWhere, string filedOrder)
        {
            throw new NotImplementedException();
        }

        public List<Entity.UserHelp> UserHelp_GetListArray(int Top, string strWhere, string filedOrder)
        {
            throw new NotImplementedException();
        }

        public List<Entity.UserHelp> UserHelp_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            throw new NotImplementedException();
        }

        public Entity.UserHelp UserHelp_ReaderBind(System.Data.IDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}