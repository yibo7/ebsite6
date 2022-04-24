using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.Modules.Shop.ExtensionsCtrls.GoodsNumber
{
    public partial class Ctrl : ModelCtrlBase
    {
        public override void LoadData()
        {
            StringDictionary settings = GetSettings();

            if(!IsPostBack)
            {
                EbSite.Entity.NewsClass md = EbSite.BLL.NewsClass.GetModel(ClassID);
                GoodsNum.Text =md.Annex2+ GetRandomCode(5);//"YYT72623";
            }
        }
        public override string Name
        {
            get { return "GoodsNumber"; }
        }
        public override void SetValue(string sValue)
        {
            GoodsNum.CtrValue = sValue;
        }
        public override string GetValue()
        {
            return GoodsNum.CtrValue;
        }

        private  int ClassID
        {
            get
            {
                return Core.Utils.StrToInt(Request.QueryString["cid"], 0);
            }
        }
        private string GetRandomCode(int CodeCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9";
            string[] allCharArray = allChar.Split(',');
            string RandomCode = "";
            int temp = -1;

            Random rand = new Random();
            for (int i = 0; i < CodeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(temp * i * ((int)DateTime.Now.Ticks));
                }

                int t = rand.Next(10);

                while (temp == t)
                {
                    t = rand.Next(10);
                }

                temp = t;
                RandomCode += allCharArray[t];
            }

            return RandomCode;
        }
        
    }
}