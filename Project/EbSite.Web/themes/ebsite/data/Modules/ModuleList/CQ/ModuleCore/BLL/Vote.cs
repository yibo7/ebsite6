using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Core.FSO;
using EbSite.Modules.CQ.ModuleCore.Entity;

namespace EbSite.Modules.CQ.ModuleCore.BLL
{
    public class Vote : EbSite.Base.Datastore.XMLProviderBase<VoteInfo>
    {
        public static readonly Vote Instance = new Vote();
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

        private readonly string VoteSaveUrl = string.Concat(SettingInfo.Instance.GetBaseConfig.Instance.ModulePath, "DataStore/VoteInfo/");
        private Vote()
        {

            string sPath = HttpContext.Current.Server.MapPath(VoteSaveUrl);
            if(!FObject.IsExist(sPath,FsoMethod.Folder))
            {
                FObject.Create(sPath,FsoMethod.Folder);
            }
        }

        public int BaseCSSWidth = 200;
        public List<Entity.VoteItem> GetItems(Guid VoteID)
        {
            
                int PostCont = 0;
                List<Entity.VoteItemInfo> lst = VoteItem.Instance.GetListByVoteID(VoteID, out PostCont);
                List<Entity.VoteItem> lstRZ =new List<Entity.VoteItem>();
               
                foreach (VoteItemInfo itemInfo in lst)
                {
                    
                    Entity.VoteItem MD = new Entity.VoteItem(PostCont, BaseCSSWidth);
                    MD.id = itemInfo.id;
                    MD.ItemName = itemInfo.ItemName;
                    MD.PostCount = itemInfo.PostCount;
                    MD.VoteID = itemInfo.VoteID;
                    lstRZ.Add(MD);
                }

                return lstRZ;

            
        }

    }
}