using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EbSite.Control
{
    
    [Serializable]
    public class TagsItemInfo
    {
        private string _Orther;
        private string _sText;
        private string _TagUrl;
        
        public TagsItemInfo()
        {
        }

        public TagsItemInfo(string sText,string sUrl)
        {
            _sText = sText;
            _TagUrl = sUrl;
        }
        public string Orther
        {
            get
            {
                return this._Orther;
            }
            set
            {
                this._Orther = value;
            }
        }

        public string sText
        {
            get
            {
                return this._sText;
            }
            set
            {
                this._sText = value;
            }
        }
        /// <summary>
        /// 连接地址，通过对比此地址是不是当前tag
        /// </summary>
        public string TagUrl
        {
            get
            {
                return this._TagUrl;
            }
            set
            {
                this._TagUrl = value;
            }
        }
        private string _TagOrtherUrl;
        /// <summary>
        /// 附加的目标连接地址,通过对比此地址是不是当前tag
        /// </summary>
        public string TagOrtherUrl
        {
            get
            {
                return this._TagOrtherUrl;
            }
            set
            {
                this._TagOrtherUrl = value;
            }
        }

        private bool _Enable = true;
        public bool Enable
        {
            get
            {
                return _Enable;
            }
            set
            {
                _Enable = value;
            }
        }
        
    }
   
    public class CustomTagsBase : WebControl
    {
        private bool _IsCloseTagsItem = false;
        public bool IsCloseTagsItem
        {
            get
            {
                return _IsCloseTagsItem;
            }
            set
            {
                _IsCloseTagsItem = value;
            }
        }

        protected List<TagsItemInfo> BindList()
        {
            if (!string.IsNullOrEmpty(this.Items))
            {
                string[] strArray = this.Items.Split(new char[] { '|' });
                foreach (string str in strArray)
                {
                    string[] strArray2 = str.Split(new char[] { '#' });
                    TagsItemInfo item = new TagsItemInfo();
                    if (strArray2.Length > 1)
                    {
                        item.sText = strArray2[0];
                        item.TagUrl = strArray2[1];
                        if (strArray2.Length == 3)
                        {
                            item.Orther = strArray2[2];
                        }
                    }
                    if (object.Equals(this.Taglist, null))
                    {
                        this.Taglist = new List<TagsItemInfo>();
                    }
                    this.Taglist.Add(item);
                }
            }
            return this.Taglist;
        }
        /// <summary>
        /// 获取当前url的样式
        /// </summary>
        /// <param name="sTarget"></param>
        /// <returns></returns>
        virtual protected string GetClass(string sTarget, string TagOrtherUrl)
        {
            string itemCss = this.ItemCss;
            //当前访问地址
            string str2 = HttpContext.Current.Request.RawUrl.Trim();
            int index = str2.IndexOf("&p=");
            if (index > -1)//比较忽略分页符
            {
                str2 = str2.Substring(0, index);
            }
            if (object.Equals(str2.ToLower(), sTarget.ToLower()))
            {
                itemCss = this.CurrentCss;
            }
            if (!string.IsNullOrEmpty(TagOrtherUrl))
            {
                if (object.Equals(str2.ToLower(), TagOrtherUrl.ToLower()))
                {
                    itemCss = this.CurrentCss;
                }
            }


            return itemCss;
        }
        public string CurrentCss
        {
            get
            {
                 
                return "active";
            } 
        }

        //active tab
        ////public string CurrentCss
        ////{
        ////    get
        ////    {
        ////        object obj2 = this.ViewState[this.ClientID + "CurrentCss"];
        ////        return ((obj2 == null) ? "TabCurrent" : obj2.ToString());
        ////    }
        ////    set
        ////    {
        ////        this.ViewState[this.ClientID + "CurrentCss"] = value;
        ////    }
        ////}

        public int Index
        {
            get
            {
                object obj2 = this.ViewState[this.ClientID + "Index"];
                return ((obj2 == null) ? 0 : int.Parse(obj2.ToString()));
            }
            set
            {
                this.ViewState[this.ClientID + "Index"] = value;
            }
        }
        public string ItemCss
        {
            get
            {
                
                return "tab";
            } 
        }
        //public string ItemCss
        //{
        //    get
        //    {
        //        object obj2 = this.ViewState[this.ClientID + "ItemCss"];
        //        return ((obj2 == null) ? "TabCustom" : obj2.ToString());
        //    }
        //    set
        //    {
        //        this.ViewState[this.ClientID + "ItemCss"] = value;
        //    }
        //}

        

        public string Items
        {
            get
            {
                object obj2 = this.ViewState[this.ClientID + "Items"];
                return ((obj2 == null) ? "" : obj2.ToString());
            }
            set
            {
                this.ViewState[this.ClientID + "Items"] = value;
            }
        }

        public List<TagsItemInfo> Taglist
        {
            get
            {
                object obj2 = this.ViewState[this.ClientID + "Taglist"];
                return (obj2 as List<TagsItemInfo>);
            }
            set
            {
                this.ViewState[this.ClientID + "Taglist"] = value;
            }
        }

        public string Title
        {
            get
            {
                object obj2 = this.ViewState[this.ClientID + "Title"];
                return ((obj2 == null) ? "" : obj2.ToString());
            }
            set
            {
                this.ViewState[this.ClientID + "Title"] = value;// string.Format("<div class=\"TabsTitle\" ><span><img align=\"left\" src=\"{1}images/menus/arrow1.png\"  />{0}</span></div>", value,Base.AppStartInit.IISPath);
            }
        }
    }

}