
using System.Web.Security;
using EbSite.Base.EntityAPI;
using EbSite.Base.PageLink;
using EbSite.Base.Static;
using EbSite.BLL.GetLink;
using EbSite.Core;
using EbSite.Data.Interface;

namespace EbSite.BLL.User
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// 实现了IComparable 才能在 List里使用Sort
    /// </summary>
    [Serializable]
    public class UserGroupProfile : BusinessBase<UserGroupProfile, int>, IComparable<UserGroupProfile>
    {
        //private static readonly EbSite.DbProviderCms.GetInstance().UserGroupProfile_User.UserGroupProfile dal = new DbProviderCms.GetInstance().UserGroupProfile_User.UserGroupProfile();
        #region 与实体相关的属性
        private static object _SyncRoot = new object();
        private static List<UserGroupProfile> _UserGroupProfiles;

        //private int _groupid; 
        private string _groupname;
        private int _creditshigher;
        private int _creditslower;
        private string _ManageIndexMaster;
        private bool _issys;
        private Guid _usermodelid;
        private string _oldgroupname;

        private string _allowaddclass;
        private int _allowaddcontentnum = 0;
        private bool _isauditingmember;

        private bool _isallowdelete;
        private bool _isallowmodify;

        private bool _isauditingcontent;

        private string _manageindex;
        private string _WebSiteIndex;
        /// <summary>
        /// 用户主页
        /// </summary>
        public string WebSiteUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(_WebSiteIndex))
                {
                    Entity.MenusForUser md = BLL.MenusForUser.Instance.GetEntity(new Guid(_manageindex));
                    if (md != null)
                    {
                        return md.Url;
                    }
                    else
                    {


                        //return string.Concat(HrefFactory.GetInstance(EbSite.Base.Host.Instance.GetSiteID).UhomeRw,"?uid=",Id);

                        return string.Concat(GetBaseLinks.Get(Base.Host.Instance.GetSiteID).UhomeRw, "?uid=", Id);
                    }
                }
                else
                {
                    //return string.Concat(HrefFactory.GetInstance(EbSite.Base.Host.Instance.GetSiteID).UhomeRw, "?uid=", Id);
                    return string.Concat(GetBaseLinks.Get(Base.Host.Instance.GetSiteID).UhomeRw, "?uid=", Id);
                }
            }
        }
        //public string GetMenuUrlForThisGroup
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(_manageindex))
        //        {

        //            Entity.MenusForUser md = BLL.MenusForUser.Instance.GetEntity(new Guid(_manageindex));
        //            if (md != null)
        //            {
        //                return md.Url;
        //            }
        //            else
        //            {
        //                return string.Empty;
        //            }

        //        }
        //        else
        //        {
        //            return string.Empty;
        //        }
        //    }
        //}
        ///// <summary>
        ///// 登录成功后，定向到的页面
        ///// </summary>
        //public string UccUrl
        //{
        //    get
        //    {
        //        return GetBaseLinks.Get(Base.Host.Instance.GetSiteID).UccIndexRw;
        //        //if (!string.IsNullOrEmpty(GetMenuUrlForThisGroup))
        //        //{
        //        //    return GetMenuUrlForThisGroup;

        //        //    //Entity.MenusForUser md = BLL.MenusForUser.Instance.GetEntity(new Guid(_manageindex));
        //        //    //if (md != null)
        //        //    //{
        //        //    //    return md.Url;
        //        //    //}
        //        //    //else
        //        //    //{
        //        //    //    return Core.GetLink.HrefFactory.Instance.UccIndexRw;
        //        //    //}

        //        //}
        //        //else
        //        //{

        //        //    //return HrefFactory.GetInstance(EbSite.Base.Host.Instance.GetSiteID).UccIndexRw;
        //        //    return GetBaseLinks.Get(Base.Host.Instance.GetSiteID).UccIndexRw;
        //        //}
        //    }
        //}
        /// <summary>
        /// 此用户组的用户登录成功后定向到的页面地址 保存的是用户菜单ID
        /// </summary>
        public string ManageIndex
        {
            set
            {
                if (this._manageindex != value)
                {
                    this.MarkChanged("manageindex");
                }
                _manageindex = value;
            }
            get
            {
                return _manageindex;
            }
        }
        /// <summary>
        /// 用户自助网站首页 保存的是用户菜单ID 为空时为默认
        /// </summary>
        public string WebSiteIndex
        {
            set
            {
                if (this._WebSiteIndex != value)
                {
                    this.MarkChanged("WebSiteIndex");
                }
                _WebSiteIndex = value;
            }
            get
            {
                return _WebSiteIndex;
            }
        }
        /// <summary>
        /// 当前组下，用户添加的内容是否要通过审核后才能显示出
        /// </summary>
        public bool IsAuditingContent
        {
            set
            {
                if (this._isauditingcontent != value)
                {
                    this.MarkChanged("isauditingcontent");
                }

                _isauditingcontent = value;
            }
            get { return _isauditingcontent; }
        }

        /// <summary>
        /// 是否允许删除内容
        /// </summary>
        public bool IsAllowDelete
        {
            set
            {
                if (this._isallowdelete != value)
                {
                    this.MarkChanged("isallowdelete");
                }

                _isallowdelete = value;
            }
            get { return _isallowdelete; }
        }
        /// <summary>
        /// 是否允许修改内容
        /// </summary>
        public bool IsAllowModify
        {
            set
            {
                if (this._isallowmodify != value)
                {
                    this.MarkChanged("isallowmodify");
                }
                _isallowmodify = value;
            }
            get { return _isallowmodify; }
        }
        /// <summary>
        /// 此用户组的用户可以添加内容的分类ID，用户逗号分开
        /// </summary>
        public string AllowAddClass
        {
            set
            {
                if (this._allowaddclass != value)
                {
                    this.MarkChanged("allowaddclass");
                }
                _allowaddclass = value;
            }
            get { return _allowaddclass; }
        }
        /// <summary>
        /// 允许添加内容的数据 0 为无限制
        /// </summary>
        public int AllowAddContentNum
        {
            set
            {
                if (this._allowaddcontentnum != value)
                {
                    this.MarkChanged("allowaddcontentnum");
                }
                _allowaddcontentnum = value;
            }
            get { return _allowaddcontentnum; }
        }
        /// <summary>
        /// 此用户组下的用户注册是否要经过审核
        /// </summary>
        public bool IsAuditingMember
        {
            set
            {
                if (this._isauditingmember != value)
                {
                    this.MarkChanged("isauditingmember");
                }
                _isauditingmember = value;
            }
            get { return _isauditingmember; }
        }

        /// <summary>
        /// 用户组的名称
        /// </summary>
        public string GroupName
        {
            set
            {
                if (this._groupname != value)
                {
                    this.MarkChanged("groupname");
                }
                //保留原来名称，以更新时删除原来系统自带数据
                _oldgroupname = this._groupname;
                _groupname = value;
            }
            get { return _groupname; }
        }
       
        /// <summary>
        /// 积分上限
        /// </summary>
        public int CreditShigher
        {
            set
            {
                if (this._creditshigher != value)
                {
                    this.MarkChanged("creditshigher");
                }
                _creditshigher = value;
            }
            get { return _creditshigher; }
        }
        /// <summary>
        /// 积分下限
        /// </summary>
        public int CreditSlower
        {
            set
            {
                if (this._creditslower != value)
                {
                    this.MarkChanged("creditslower");
                }
                _creditslower = value;
            }
            get { return _creditslower; }
        }
        /// <summary>
        /// 母板页
        /// </summary>
        public string ManageIndexMaster
        {
            set
            {
                if (this._ManageIndexMaster != value)
                {
                    this.MarkChanged("ManageIndexMaster");
                }
                _ManageIndexMaster = value;
            }
            get { return _ManageIndexMaster; }
        }
        /// <summary>
        /// 是否系统默认用户组,如果是，不可以删除
        /// </summary>
        public bool IsSys
        {
            set
            {
                if (this._issys != value)
                {
                    this.MarkChanged("issys");
                }
                _issys = value;
            }
            get { return _issys; }
        }
        /// <summary>
        /// 与此用户组关联的用户模型ID,从此ID可以找到对应的用户模型表名称
        /// </summary>
        public Guid UserModelID
        {
            set
            {
                if (this._usermodelid != value)
                {
                    this.MarkChanged("usermodelid");
                }
                _usermodelid = value;
            }
            get { return _usermodelid; }
        }
        #endregion

        #region 构造方法
        public UserGroupProfile()
        {
            //base.Id = Guid.NewGuid();
        }


        #endregion

        #region 对数据的-增-删-查-改

        /// <summary>
        /// 删除某条数据及此数据的子记录
        /// </summary>
        protected override void DataDelete()
        {

            if (IsDeleted)
            {
                DbProviderCms.GetInstance().UserGroupProfile_DeleteUserGroupProfile(this);
                //同时删除.net自带的
                //2014-3-24 yhl
               // Roles.DeleteRole(this.GroupName);
                if (UserGroupProfiles.Contains(this))
                    UserGroupProfiles.Remove(this);
            }

            Dispose();
        }



        /// <summary>
        /// 插入一条数据
        /// </summary>
        protected override void DataInsert()
        {
            if (IsNew)
            {
                //添加到属性表
                DbProviderCms.GetInstance().UserGroupProfile_InsertUserGroupProfile(this);
                //同时添加到系统Roles表
                //2014-3-24 yhl 注释
               // Roles.CreateRole(this.GroupName);

                UserGroupProfiles.Add(this);
                UserGroupProfiles.Sort();

            }

        }
        /// <summary>
        /// 与GetMenu一样，从某个ID获取某个对象,只不过这个从数据库获取GetMenu 在内存里获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected override UserGroupProfile DataSelect(int id)
        {
            return DbProviderCms.GetInstance().UserGroupProfile_SelectUserGroupProfile(id);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        protected override void DataUpdate()
        {
            if (this.IsChanged)
            {
                if (IsChanged)
                {
                    DbProviderCms.GetInstance().UserGroupProfile_UpdateUserGroupProfile(this);
                    //由于Roles没有更新办法，只能用删除与添加来实现
                    if (_oldgroupname != this.GroupName)
                    {
                        Roles.DeleteRole(_oldgroupname);
                        Roles.CreateRole(this.GroupName);
                    }

                }


            }
        }
        public static UserGroupProfile GetUserGroupProfile(string GroupName)
        {

            foreach (UserGroupProfile tree in UserGroupProfiles)
            {
                if (tree.GroupName == GroupName)
                {
                    return tree;
                }
            }
            return null;

            //return DbProviderCms.GetInstance().UserGroupProfile_SelectUserGroupProfile(GroupName);
        }
        ///// <summary>
        ///// 获取 用户组对象
        ///// </summary>
        ///// <returns></returns>
        //public static UserGroupProfile GetCurrentFirstGroupProfile
        //{
        //    get
        //    {
        //       UserGroupProfile lst = GetRoleProfilesByUserName(EbSite.Base.AppStartInit.UserName);
        //        if (!Equals(lst,null))
        //        {
        //            return lst;
        //        }
        //        else
        //        {
        //            return new UserGroupProfile();
        //        }
        //    }

        //}

        /// <summary>
        /// 与DataSelect一样，从某个ID获取某个对象,只不过这个只从现在有缓存里获取
        /// DataSelect 从数据库获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static UserGroupProfile GetUserGroupProfile(int id)
        {
            foreach (UserGroupProfile tree in UserGroupProfiles)
            {
                if (tree.Id == id)
                {
                    return tree;
                }
            }
            return null;
        }
        /// <summary>
        /// 用户组ID加密,使用系统配置密钥,主要用于外部制作不同用户组下的注册页面传入标志
        /// </summary>
        /// <param name="sGroupID"></param>
        /// <returns></returns>
        public static string GroupIDEncode(string sGroupID)
        {
            return DES.Encode(sGroupID, Base.Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey);
        }
        /// <summary>
        /// 用户组ID解密,使用系统配置密钥,主要用于外部制作不同用户组下的注册页面传入标志
        /// </summary>
        /// <param name="sGroupID"></param>
        /// <returns></returns>
        public static int GroupIDDecode(string sGroupID)
        {
            string sID = DES.Decode(sGroupID, Base.Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey);

            return Utils.StrToInt(sID);

        }
        /// <summary>
        /// 由用户组名称 获取用户组ID
        /// </summary>
        /// <param name="GroupName"></param>
        /// <returns></returns>
        public static int GetRoleIDByUserName(string GroupName)
        {
            int iId = 0;
            foreach (UserGroupProfile rosle in UserGroupProfiles)
            {
                if (rosle.GroupName.Trim().Equals(GroupName.Trim()))
                {
                    iId = rosle.Id;
                    break;
                }
            }
            return iId;
        }
        ///// <summary>
        ///// 通过 用户名 得到用户组id
        ///// </summary>
        ///// <param name="UserName"></param>
        ///// <returns></returns>
        //public static int GetRoleIDsByUserName(string UserName)
        //{
        //    //string[] CurrentRosles = Roles.GetRolesForUser(UserName);

        //    //List<int> lst = new List<int>();

        //    //foreach (string rosle in CurrentRosles)
        //    //{
        //    //    foreach (UserGroupProfile model in UserGroupProfiles)
        //    //    {
        //    //        if (model.GroupName.Trim() == rosle.Trim())
        //    //        {
        //    //            lst.Add(model.Id);
        //    //        }
        //    //    }
        //    //}

        //    //return lst;
        //    int GroupId = BLL.User.MembershipUserEb.Instance.GetUserGroupId(UserName);
        //    return GroupId;
        //}
        ///// <summary>
        ///// 获取某个用户所属的用户组明细信息
        ///// </summary>
        ///// <param name="UserName"></param>
        ///// <returns></returns>
        //public static BLL.User.UserGroupProfile GetRoleProfilesByUserName(string UserName)
        //{
        //    //  string[] CurrentRosles = Roles.GetRolesForUser(UserName);
        //    int GroupId = BLL.User.MembershipUserEb.Instance.GetUserGroupId(UserName);
        //    UserGroupProfile GroupModel = new UserGroupProfile();
        //    foreach (UserGroupProfile model in UserGroupProfiles)
        //    {
        //        if (model.Id == GroupId)
        //        {
        //            GroupModel = model;
        //        }
        //    }
        //    return GroupModel;

        //}
        public static List<UserGroupProfile> SearchUserGroups(string GroupName)
        {
            List<UserGroupProfile> Groups = new List<UserGroupProfile>();
            foreach (UserGroupProfile groupProfile in UserGroupProfiles)
            {
                if (groupProfile.GroupName.IndexOf(GroupName) > -1)
                {
                    Groups.Add(groupProfile);
                }
            }
            return Groups;
        }
        ///// <summary>
        ///// 获取数据集(纯从数据库查询，未加入树形)
        ///// </summary>
        public static List<UserGroupProfile> UserGroupProfiles
        {
            get
            {
                if (_UserGroupProfiles == null)
                {
                    lock (_SyncRoot)
                    {
                        if (_UserGroupProfiles == null)
                        {
                            _UserGroupProfiles = DbProviderCms.GetInstance().UserGroupProfile_FillUserGroupProfiles();
                            //按_orderid降序来排序
                            _UserGroupProfiles.Sort();


                        }
                    }
                }

                return _UserGroupProfiles;
            }
        }

        #endregion

        /// <summary>
        /// 验证规则
        /// </summary>
        protected override void ValidationRules()
        {
            this.AddRule("GroupName", "必须设置用户组名称", string.IsNullOrEmpty(this.GroupName));
        }

        /// <summary>
        /// 重写ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GroupName;
        }

        #region 实现IComparable接口,以便在List里可以使用Sort对orderid 进行排序
        /// <summary>
        /// 按orderid的降序来排序,实现这个方法，可以让List.Sort(),按这个比较大小来排序
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(UserGroupProfile other)
        {

            return this.Id.CompareTo(other.Id);
        }

        #endregion

        static public UserGroupProfileShort GroupShortByUserID(object uid)
        {
            int iuid = Core.Utils.StrToInt(uid.ToString(), 0);
            if (iuid > 0)
            {
                string CacheKey = string.Concat("GroupShortByUserID-", uid);
                UserGroupProfileShort model = EbSite.Base.Host.CacheRawApp.GetCacheItem<UserGroupProfileShort>(CacheKey, "gus");// as UserGroupProfileShort;
                if (Equals(model, null))
                {
                    model = DbProviderCms.GetInstance().UserGroupProfile_GroupShortByUserID(uid);
                    if (!Equals(model, null) && !string.IsNullOrEmpty(model.GroupName))
                        EbSite.Base.Host.CacheRawApp.AddCacheItem(CacheKey, model, 15, ETimeSpanModel.FZ, "gus");
                }
                return model;
            }

            return null;

        }

        public static string UserInfoPageNameByUserID(object uid)
        {
            UserGroupProfileShort md = GroupShortByUserID(uid);

            return md.WebSiteIndex;
        }
        public static string ManageIndexPageNameByUserID(object uid)
        {
            int iuid = Core.Utils.StrToInt(uid.ToString(), 0);
            if (iuid > 0)
            {
                UserGroupProfileShort md = GroupShortByUserID(uid);
                if (!Equals(md, null) && !string.IsNullOrEmpty(md.ManageIndex))
                    return md.ManageIndex.Trim();
            }
            return "uccindex.aspx";
        }

        public static string ManageIndexMasterNameByUserID(object uid)
        {
            int iuid = Core.Utils.StrToInt(uid.ToString(), 0);
            if (iuid > 0)
            {
                UserGroupProfileShort md = GroupShortByUserID(uid);
                if (!Equals(md, null) && !string.IsNullOrEmpty(md.ManageIndexMaster))
                    return md.ManageIndexMaster.Trim();
            }
            return "UserPagesTem.Master";

            

           
        }


       static public bool IsExist(string GroupName)
       {
           return DbProviderCms.GetInstance().UserGroupProfile_IsExist(GroupName);
       }
    }



}

