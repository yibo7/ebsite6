using System.Collections.Generic;
using EbSite.Base.EntityAPI;

namespace EbSite.Entity
{
   

    /// <summary>
        /// 一个报表设置对象
        /// </summary>
        public class ReportConfig
    {
        

        /// <summary>
        /// 报表名称
        /// </summary>
        /// <value>The name of the report.</value>
        public string ReportName { get; set; }
        /// <summary>
        /// 菜单展示图片相对路径
        /// </summary>
        /// <value>The icon path.</value>
        public string IcoPath { get; set; }
        /// <summary>
        /// 展示顺序
        /// </summary>
        /// <value>The order identifier.</value>
        public int OrderId { get; set; }

        /// <summary>
        /// 查询表单,可以配置多个表单，text:表单展示名称,value:表单控件ID
        /// </summary>
        /// <value>The CTRS.</value>
        public   List<ListItemSimple> Ctrs { get; set; }

        /// <summary>
        /// 查询报表的sql语句，可以根据表单ID,替换表单输入值，如:
        /// select *    from eb_newscontent  where b_dateline>UNIX_TIMESTAMP('表单控件ID1') and b_dateline<UNIX_TIMESTAMP('表单控件ID2')
        /// </summary>
        /// <value>The SQL.</value>
        public string QuerySql { get; set; }
        /// <summary>
        /// 默认打开页面载入结果集
        /// </summary>
        /// <value>The default SQL.</value>
        public string DefaultSql { get; set; }

        ///// <summary>
        ///// 设置报表输出项,text: 展示列名称, value:绑定字段名称
        ///// </summary>
        ///// <value>The table items.</value>
        //public List<ListItemSimple> TableItems { get; set; }

        /// <summary>
        /// 允许查看的权限Id
        /// </summary>
        /// <value>The permission identifier.</value>
        public string PermissionId { get; set; }

        /// <summary>
        /// 数据层提供程序，本系统对数据的读取分两种提供程序，cms数据库可以与用户数据库分离，这里0代表cms,1代表user,一般情况没有分离数据库，设置为0即可
        /// </summary>
        /// <value>The type of the dal.</value>
        public int DalType { get; set; }

        /// <summary>
        /// 打开页面，默认载入的数据提示
        /// </summary>
        /// <value>The default tips.</value>
        public string DefaultTips { get; set; }

        /// <summary>
        /// 展示类型,0为表格，1为线性图，2为柱形图，3为饼图
        /// </summary>
        /// <value>0为表格，1为线性图，2为柱形图，3为饼图.</value>
        public int ShowType { get; set; }
    }
}