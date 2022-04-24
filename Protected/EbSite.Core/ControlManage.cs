
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace EbSite.Core
{
    public class ControlManage
    {
        /// <summary>
        /// 获取列表控件项的值,存放于 List<string>
        /// </summary>
        /// <param name="Items"></param>
        /// <returns></returns>
        static public List<string> GetItemsList(ListItemCollection Items)
        {
            List<string> lst = new List<string>();
            foreach (ListItem li in Items)
            {
                if(li.Selected)
                lst.Add(li.Value);
            }
            
            return lst;
        }
        /// <summary>
        /// 获取列表控件项的值,用逗号分开
        /// </summary>
        /// <param name="Items"></param>
        /// <returns></returns>
        static public string GetItemsListOfString(ListItemCollection Items)
        {
            List<string> lst = GetItemsList(Items);

            string[] aLi = lst.ToArray();

            string s = string.Join(",", aLi);

            return s;
         }
        /// <summary>
        /// 设置列表控件项的值
        /// </summary>
        /// <param name="Items">控件项对像</param>
        /// <param name="Values">每个项的值，存放在一个字符数组中</param>
        static public void SetItemsList(ListItemCollection Items,string[] Values)
        {
            foreach (ListItem li in Items)
            {
                li.Selected = Core.Strings.Validate.InArray(li.Value, Values);
            }
        }
        /// <summary>
        /// 设置列表控件项的值
        /// </summary>
        /// <param name="Items">控件项对像</param>
        /// <param name="Values">每个项的值，用逗号分开</param>
        static public void SetItemsList(ListItemCollection Items, string Values)
        {
            foreach (ListItem li in Items)
            {
                li.Selected = Core.Strings.Validate.InArray(li.Value, Values.Split(','));
            }
        }


    }

}
