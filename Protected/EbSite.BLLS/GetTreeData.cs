using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EbSite.BLL
{
   public class GetTreeData
    {
        public static readonly GetTreeData Instance = new GetTreeData(); 
        /// <summary>
        /// 获取所有树列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetTreeList(DataTable dt)
        {
            //DataTable dt = GetTreeList("").Tables[0];//(,0);



            //为构造树创建下列字段
            dt.Columns.Add("Depth", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Parent_Path", System.Type.GetType("System.String"));
            dt.Columns.Add("ChildCount", System.Type.GetType("System.Int32"));
            dt.Columns.Add("IsLast", System.Type.GetType("System.Int32"));
            dt.Columns.Add("ChildCollection", System.Type.GetType("System.String"));

            DataColumn[] keys = new DataColumn[2];
            keys[0] = dt.Columns["ID"];
            keys[1] = dt.Columns["OrderID"];
            dt.PrimaryKey = keys;
            //////////////////////////////////


            dt = TreeMake(dt, -1, 0, "");

            DataRow[] row = dt.Select("", "OrderID ASC");

            DataTable Dt = dt.Clone();
            DataRow Dr;

            foreach (DataRow dr in row)
            {
                Dr = Dt.NewRow();

                foreach (DataColumn col in dr.Table.Columns)
                {
                    Dr[col.ColumnName] = dr[col];
                }

                Dt.Rows.Add(Dr);
            }

            return Dt;
        }
        private int _SortID = 0;
        private string _ParentPath = "";
        private int _IsLast = 0;
        public DataTable TreeMake(DataTable dt, object Depth, object ParentID, object ParentPath)
        {
            DataRow[] rows = dt.Select("ParentID = " + ParentID, "OrderID ASC");//查找父节点
            
            int i = 0;

            foreach (DataRow dr in rows)
            {
                _SortID++;
                i++;

                if (object.Equals(ParentPath, null))
                {
                    _ParentPath = ParentPath.ToString() + ",";
                }
                else
                {
                    _ParentPath = ParentPath.ToString();
                }

                if (i == rows.Length)
                    _IsLast = 1;
                else
                    _IsLast = 0;
                DataRow[] row = dt.Select("ParentID = " + dr["ID"], ""); //查找子节点
                int _ChildCount = row.Length;
                foreach (DataRow r in row)
                {
                    //要这里可以 对所有继承属性进行处理
                    //if (Object.Equals(r["listStyle"], 0)) r["listStyle"] = dr["listStyle"];
                    //if (Object.Equals(r["cTempID"], 0)) r["cTempID"] = dr["cTempID"];
                    //if (Object.Equals(r["newsTempID"], 0)) r["newsTempID"] = dr["newsTempID"];
                    //if (!user.CheckValiable(r["headCode"])) r["headCode"] = dr["headCode"];
                    //if (!user.CheckValiable(r["pageCode"])) r["pageCode"] = dr["pageCode"];
                    //if (!user.CheckValiable(r["footCode"])) r["footCode"] = dr["footCode"];
                }
                // 为结构赋值
                dr["Depth"] = Convert.ToInt32(Depth) + 1;
                //dr["SortID"] = _SortID;
                dr["Parent_Path"] = _ParentPath + dr["ID"];
                dr["ChildCount"] = _ChildCount;
                dr["IsLast"] = _IsLast;
                dr["OrderID"] = _SortID;
                dr.AcceptChanges();
                dt.AcceptChanges();
                TreeMake(dt, dr["Depth"], dr["ID"], dr["Parent_Path"]);
            }

            return dt;
        }
        /// <summary>
        /// dataview 绑定时 获取显示树型菜单的分类前的图标位置
        /// </summary>
        /// <param name="child">子节数目</param>
        /// <param name="depth">深度</param>
        /// <param name="lastnode">是否为最后一个节点，将调用对应的图标</param>

        /// <returns></returns>
        public string InitTreeImg(string child, string depth, string lastnode)
        {
            if (string.IsNullOrEmpty(depth)) return "";
            string strResult = "";
            string sPatch = Base.AppStartInit.IISPath+ "Images/tree/";
            for (int i = 0; i < int.Parse(depth); i++)
            {
                strResult += "<img src=\"" + sPatch + "treeline.gif\" align=absmiddle>";
            }

            if (child == "0")
            {
                strResult += (lastnode == "1") ? "<img src=\"" + sPatch + "nochildnolast.gif\" align=absmiddle>" : "<img src=\"" + sPatch + "nochildlast.gif\" align=absmiddle>";
            }
            else
            {
                strResult += (lastnode == "1") ? "<img src=\"" + sPatch + "havechildnolast.gif\" align=absmiddle>" : "<img src=\"" + sPatch + "havechildlast.gif\" align=absmiddle>";
            }
            return strResult;
        }
    }
}
