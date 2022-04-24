using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Core.FSO;
using EbSite.Modules.CQ.ModuleCore.Entity;

namespace EbSite.Modules.CQ.ModuleCore.BLL
{
    public class VoteItem: EbSite.Base.Datastore.XMLProviderBase<VoteItemInfo>
    {
        public static readonly VoteItem Instance = new VoteItem();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(VoteSaveUrl);
            }
        }

        private readonly string VoteSaveUrl = string.Concat(SettingInfo.Instance.GetBaseConfig.Instance.ModulePath, "DataStore/VoteItemInfo/");
        private VoteItem()
        {

            string sPath = HttpContext.Current.Server.MapPath(VoteSaveUrl);
            if(!FObject.IsExist(sPath,FsoMethod.Folder))
            {
                FObject.Create(sPath,FsoMethod.Folder);
            }
        }

        public List<Entity.VoteItemInfo> GetListByVoteID(Guid voteid, out int PostCont)
        {
            List<Entity.VoteItemInfo>  lst = new List<Entity.VoteItemInfo>(); ;
            if(voteid!=Guid.Empty)
            {
                PostCont = 0;
                foreach (Entity.VoteItemInfo voteItem in base.FillList())
                {
                    if (voteItem.VoteID == voteid)
                    {
                        PostCont += voteItem.PostCount;
                        lst.Add(voteItem);
                    }

                }
              
            }
            else
            {
                PostCont = 0;
                foreach (Entity.VoteItemInfo voteItem in base.FillList())
                {
                    PostCont += voteItem.PostCount;
                    lst.Add(voteItem);

                }
            }

            

            return lst;
            
        }

    }
}