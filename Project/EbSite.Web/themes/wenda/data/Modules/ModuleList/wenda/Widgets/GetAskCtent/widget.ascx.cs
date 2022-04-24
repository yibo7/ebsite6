using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.BLL.User;
using EbSite.Modules.Wenda.Ajaxget;
using EbSite.Modules.Wenda.ModuleCore;
using EbSite.Modules.Wenda.ModuleCore.BLL;
using ExpandContent = EbSite.Modules.Wenda.ModuleCore.Entity.ExpandContent;

namespace EbSite.Modules.Wenda.Widgets.GetAskCtent
{
    public partial class widget : WidgetBase
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public override bool IsEditable
        {
            get
            {
                return true;
            }
        }

        public override string Name
        {
            get
            {
                return "GetAskCtent";
            }
        }

        protected string sInfo = "";
        public override void LoadData()
        {
            if (!IsPostBack)
            {
                  //<div class="jgquesinfo">
                  //      <li>快速知道您爱车的故障所在及解决方法。毕业于北京大学，从事汽车销售10年，可以快速知道您爱车的故障所在及快速知道您爱车的故障所在及解决方法。毕业于北京大学，从事汽车销售10年，可以快速知道您爱车的故障所在及解决方法。解决方法。</li>
                  //  </div>
                  //  <div class="jgbcwt">
                  //      <li style="color: #A0A19D; line-height: 25px;"><span>补充问题</span>：2012-10-23 18：30：23</li>
                  //      <li style="margin-left: 20px;">障所在及解决方法。毕业于北京大学 ，从事汽车销售10年.售10年，可以快速知道您爱车的故障所在及解决方法。</li>
                  //  </div>
                string str = "";
                string tempOne = "<div class=\"jgquesinfo\"><li>{0}</li> </div>";

                string tempTwo = "<div class=\"jgbcwt\"> <li style=\"color: #A0A19D; line-height: 25px;\"><span>补充问题</span>：{0}</li><li style=\"margin-left: 20px;\">{1}</li></div>";


                int AskID =int.Parse( Request.QueryString["id"]);
                EbSite.Entity.NewsContent md = Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(AskID);
                if (ConfigControl.Instance.IsUbb) //显示UBB
                {
                    str = string.Format(tempOne, EbSite.Core.UBB.Ubb2Html( md.ContentInfo));
                }
                else
                {
                    str = string.Format(tempOne, md.ContentInfo);
                }
                
              
                List<ModuleCore.Entity.ExpandContent> ls = ModuleCore.BLL.ExpandContent.Instance.GetListArray(0, "cid="+AskID, "id asc");
                if(ls.Count>0)
                {
                    foreach (ModuleCore.Entity.ExpandContent i in ls)
                    {
                        if (ConfigControl.Instance.IsUbb) //显示UBB
                        {
                            str += string.Format(tempTwo, i.TDate, EbSite.Core.UBB.Ubb2Html(i.Ctent));
                        }
                        else
                        {
                            str += string.Format(tempTwo, i.TDate, i.Ctent);
                        }
                        
                        
                    }
                }
                sInfo = str;
            }
        }
    

       
    }
}

