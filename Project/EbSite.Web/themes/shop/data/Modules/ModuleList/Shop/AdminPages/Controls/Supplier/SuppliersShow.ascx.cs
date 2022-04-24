using System;
using EbSite.Base.Modules;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.AdminPages.Controls.Supplier
{
    public partial class SuppliersShow : MPUCBaseShow<ModuleCore.Entity.Supplier>
	{
        public override string PageName
        {
            get
            {
                return "供货商查看";
            }
        }
		/// <summary>
		/// 权限全部
		/// </summary>
		public override string Permission
		{
			get
			{
				return "33";
			}
		}
		/// <summary>
		/// 重写删除
		/// </summary>
		protected override  void Delete()
		{
			Model.Delete();
		}
		/// <summary>
		/// 重写Load事件
		/// </summary>
		protected override ModuleCore.Entity.Supplier LoadModel()
		{
            ModuleCore.Entity.Supplier md = new ModuleCore.Entity.Supplier(int.Parse(GetKeyID));
            if (Equals(md, null)) md = new ModuleCore.Entity.Supplier();//防止删除后的页面出错
			return md;
		}
	}
}
