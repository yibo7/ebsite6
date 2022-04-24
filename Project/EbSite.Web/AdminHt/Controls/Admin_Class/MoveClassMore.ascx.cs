using System;
using System.Collections.Generic;

namespace EbSite.Web.AdminHt.Controls.Admin_Class
{
    public partial class MoveClassMore : EbSite.Base.ControlPage.UserControlBaseSave
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {



            }
        }
        public override string Permission
        {
            get
            {
                return "57";
            }
        }

        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override protected void InitModifyCtr()
        {
        }

        protected override void SaveModel()
        {
            string sSID = drpSoure.Value;
            string sTID = drpTarget.Value;

            if (sSID == sTID)
            {
                base.Tips("您所要移动的分类与目标分类相同，无法移动！", "您所要移动的分类与目标分类相同，无法移动！");
                return;
            }

            if (string.IsNullOrEmpty(sSID) || string.IsNullOrEmpty(sTID))
            {
                base.Tips("请选择好源分类与目标分类！", "请选择好源分类与目标分类！");
                return;
            }

            int iSoureClassID = int.Parse(sSID);
            int iTargetClassID = int.Parse(sTID);
            //验证是否 同一模型 2014-2-27 YHL
            if (EbSite.BLL.ClassConfigs.Instance.GetClassModelID(iSoureClassID) !=
                EbSite.BLL.ClassConfigs.Instance.GetClassModelID(iTargetClassID))
            {
                base.TipsAlert("请选择同一模型下的分类！");
                return;
            }
            bool IsToSub = (Equals(movetype.SelectedValue, "1"));
            BLL.NewsClass.MoveClass(iSoureClassID, iTargetClassID, IsToSub, base.GetSiteID);
            //yhl 2014-08-29 移动分类后 源分类要重新刷 父级分类ParentIDs
            List<Entity.NewsClass> lsSoure = BLL.NewsClass.GetChildClass(iSoureClassID, base.GetSiteID);
            foreach (var newsClass in lsSoure)
            {
                string pis = "";
                List<Entity.NewsClass> lsParent = BLL.NewsClass.GetParents(newsClass.ID);
                foreach (var @class in lsParent)
                {
                    pis += @class.ID + ",";
                }
                newsClass.ParentIDs = pis;
                BLL.NewsClass.Update(newsClass);
            }
            Response.Redirect(Request.RawUrl);
        }

    }
}