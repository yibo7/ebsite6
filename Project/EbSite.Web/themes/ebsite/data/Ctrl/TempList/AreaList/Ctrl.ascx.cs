using System;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using EbSite.Control;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.AreaList
{
    public partial class Ctrl : ModelCtrlBase
    {

        protected override void OnPreRender(EventArgs e)
        {

            if (!Page.ClientScript.IsClientScriptBlockRegistered("AreaSet"))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "AreaList", string.Concat("<SCRIPT language='javascript' src='", IISPath, "js/areabll.js'></SCRIPT>"));
            }
            base.OnPreRender(e);
        }
        public override void LoadData()
        {

            StringDictionary settings = GetSettings();
            if (settings.ContainsKey("drpArea1"))
            {
                string ParentID = settings["drpArea1"];
                if (!string.IsNullOrEmpty(ParentID))
                {
                    int iParentID = int.Parse(ParentID);
                    BindAreaList(1, iParentID);
                    DisplayNone(drpArea2);
                    DisplayNone(drpArea3);
                    DisplayNone(drpArea4);

                }
            }
        }
        private void DisplayNone(System.Web.UI.WebControls.DropDownList ddl)
        {
            ddl.Attributes.Add("style", "display:none");
        }
        private void BindAreaList(int Level,int ParentID)
        {
            if (Level==1)
            {
               
                drpArea1.DataSource = BLL.AreaInfo.Instance.GetListByParentID(ParentID);
                drpArea1.DataBind();
            }
            else if (Level == 2)
            {
                drpArea2.DataSource = BLL.AreaInfo.Instance.GetListByParentID(ParentID);
                drpArea2.DataBind();
                drpArea2.Visible = true;
            }
            else if (Level == 3)
            {
                drpArea3.DataSource = BLL.AreaInfo.Instance.GetListByParentID(ParentID);
                drpArea3.DataBind();
                drpArea3.Visible = true;
            }
            else if (Level == 4)
            {
                drpArea4.DataSource = BLL.AreaInfo.Instance.GetListByParentID(ParentID);
                drpArea4.DataBind();
                drpArea4.Visible = true;
            }
           
        }

        public override void SetValue(string sValue)
        {
            int iAreaID = Core.Utils.StrToInt(sValue, 0);
            if(iAreaID>0)
            {
                Entity.AreaInfo md = BLL.AreaInfo.Instance.GetEntity(iAreaID);
                int ParentID = 0;
                if (md.Level == 4)
                {
                    ParentID = md.HeadID;
                    BindAreaList(4, ParentID);

                    md = BLL.AreaInfo.Instance.GetEntity(ParentID);
                    ParentID = md.HeadID;
                    BindAreaList(3, ParentID);

                    md = BLL.AreaInfo.Instance.GetEntity(ParentID);
                    ParentID = md.HeadID;
                    BindAreaList(2, ParentID);

                    md = BLL.AreaInfo.Instance.GetEntity(ParentID);
                    ParentID = md.HeadID;
                    BindAreaList(1, ParentID);
                }
                else if (md.Level == 3)
                {
                    ParentID = md.HeadID;
                    BindAreaList(3, ParentID);

                    md = BLL.AreaInfo.Instance.GetEntity(ParentID);
                    ParentID = md.HeadID;
                    BindAreaList(2, ParentID);

                    md = BLL.AreaInfo.Instance.GetEntity(ParentID);
                    ParentID = md.HeadID;
                    BindAreaList(1, ParentID);

                }
                else if (md.Level == 2)
                {
                    ParentID = md.HeadID;
                    BindAreaList(2, ParentID);

                    md = BLL.AreaInfo.Instance.GetEntity(ParentID);
                    ParentID = md.HeadID;
                    BindAreaList(1, ParentID);

                }
                else if (md.Level == 1)
                {
                    ParentID = md.HeadID;
                    BindAreaList(1, ParentID);

                }
            }
            
        }

        public override string Name
        {
            get { return "AreaList"; }
        }

        public override string GetValue()
        {
            return hfValue.Value;
        }
    }
}