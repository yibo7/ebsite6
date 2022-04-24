using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Core.FSO;

namespace EbSite.BLL
{
    public class TagColor : Base.Datastore.XMLProviderBase<Entity.TagColorInfo>
    {
        public static readonly TagColor Instance = new TagColor();
        private TagColor()
        {
            string sPath = HttpContext.Current.Server.MapPath(IISPath + "datastore/TagColorInfo/");
            if (!FObject.IsExist(sPath, FsoMethod.Folder))
            {
                FObject.Create(sPath, FsoMethod.Folder);
            }
        }


        protected ArrayList ListArry = new ArrayList();
        /// <summary>
        /// 随机返回颜色
        /// </summary>
        /// <param name="randomNums">随机数的范围</param>
        /// <returns></returns>
        public string GetColor(int randomNums)
        {

            string color = "";
            List<Entity.TagColorInfo> ls = FillList();

            if (Equals(System.Web.HttpContext.Current.Session["LA"], null))
            {
                foreach (Entity.TagColorInfo tagColorInfo in ls)
                {
                    for (int i = 0; i < tagColorInfo.MaxShowNum; i++)
                    {
                        //  colormore += tagColorInfo.ColorName + ","; //颜色名称
                        ListArry.Add(tagColorInfo.ColorName);
                    }
                }
                System.Web.HttpContext.Current.Session["LA"] = ListArry;
            }

            //随机数
            Random rnd = new Random();
            int key = rnd.Next(0, randomNums);
            if (key > ListArry.Count - 1)
            {
                color = "0043BD";//默认颜色
            }
            else
            {
                color = ListArry[key].ToString();
                ListArry.RemoveAt(key);
                System.Web.HttpContext.Current.Session["LA"] = ListArry;
            }

            return color;
        }
    }
}
