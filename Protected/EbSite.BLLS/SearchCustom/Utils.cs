
//using System.Data;
//using EbSite.Data.Interface;
//using EbSite.Entity.SearchCustom;

//namespace EbSite.BLL.SearchCustom
//{
//    public class Utils
//    {
//        public static DataSet SearchResult(int PageIndex, int iPageSize, SearchModel sm, ref int ResultCount)
//        {

//            return DbProviderCms.GetInstance().SearchCustom_GetListPages(PageIndex, iPageSize, sm, ref ResultCount, "");
//        }

//        public static DataSet SearchResult(int iTop, SearchModel sm, string OrderBy)
//        {
//            int iCoun = 0;
//            string sTop = "id desc";
//            if (OrderBy == "w")
//            {
//                sTop = "weekhits desc";
//            }
//            else if (OrderBy == "adv")
//            {
//                sTop = "advs desc";
//            }
//            else if (OrderBy == "d")
//            {
//                sTop = "dayhits desc";
//            }
//            else if (OrderBy == "m")
//            {
//                sTop = "monthhits desc";
//            }
//            else if (OrderBy == "ch")
//            {
//                sTop = "commentnum desc";
//            }
//            else if (OrderBy == "fh")
//            {
//                sTop = "favorablenum desc";
//            }
//            else if (OrderBy == "h") //总排行
//            {
//                sTop = "hits desc";
//            }
//            return DbProviderCms.GetInstance().SearchCustom_GetListPages(1, iTop, sm, ref iCoun, sTop);
//        }

//    }
//}
