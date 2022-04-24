using System.Collections;
using System.Collections.Specialized;
using System.Reflection;
using System.Web.Security;
using EbSite.BLL;
using EbSite.BLL.ModelBll;
using EbSite.Data.Interface;
using EbSite.Entity;

namespace EbSite.BLL.User
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// 实现了IComparable 才能在 List里使用Sort
    /// </summary>
    [Serializable]
    public class UserProfile : BusinessBase<UserProfile, int>, IComparable<UserProfile>, ModelEntityBase
    {
        //private static readonly EbSite.DbProviderCms.GetInstance().UserProfile_User.UserProfile dal = new DbProviderCms.GetInstance().UserProfile_User.UserProfile();
        #region 与实体相关的属性
        private static object _SyncRoot = new object();
        private static List<UserProfile> _UserProfiles;

        private int _userid;


        private string _username;
        private string _qq;
        private string _msn;
        private string _ico;
        private string _sex;
        private DateTime _birthday = DateTime.Now;
        private string _photo;
        private string _bloodtype;
        private string _country;
        private string _province;
        private string _city;
        private string _phone;
        private string _postcode;
        private string _address;
        private string _job;
        private string _edu;
        private string _school;
        private string _introduction;
        private Guid _UserModelID;

        private string _annex1;
        private string _annex2;
        private string _annex3;
        private string _annex4;
        private string _annex5;
        /// <summary>
        /// 
        /// </summary>
        public Guid UserModelID
        {
            set
            {

                _UserModelID = value;

            }
            get { return _UserModelID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UserID
        {
            set
            {

                _userid = value;

            }
            get { return _userid; }
        }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName
        {
            set
            {
                if (this._username != value)
                {
                    this.MarkChanged("username");
                }
                _username = value;

            }
            get { return _username; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string QQ
        {
            set
            {

                if (this._qq != value)
                {
                    this.MarkChanged("qq");
                }
                _qq = value;
            }
            get { return _qq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MSN
        {
            set
            {
                if (this._msn != value)
                {
                    this.MarkChanged("msn");
                }
                _msn = value;
            }
            get { return _msn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ICO
        {
            set
            {
                if (this._ico != value)
                {
                    this.MarkChanged("ico");
                }
                _ico = value;
            }
            get { return _ico; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Sex
        {
            set
            {
                if (this._sex != value)
                {
                    this.MarkChanged("sex");
                }
                _sex = value;
            }
            get { return _sex; }
        }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime BirthDay
        {
            set
            {
                if (this._birthday != value)
                {
                    this.MarkChanged("birthday");
                }
                _birthday = value;
            }
            get { return _birthday; }
        }
        /// <summary>
        /// 相处路径
        /// </summary>
        public string Photo
        {
            set
            {
                if (this._photo != value)
                {
                    this.MarkChanged("photo");
                }
                _photo = value;
            }
            get { return _photo; }
        }
        /// <summary>
        /// 血型
        /// </summary>
        public string Bloodtype
        {
            set
            {
                if (this._bloodtype != value)
                {
                    this.MarkChanged("bloodtype");
                }
                _bloodtype = value;
            }
            get { return _bloodtype; }
        }
        /// <summary>
        /// 国家
        /// </summary>
        public string Country
        {
            set
            {
                if (this._country != value)
                {
                    this.MarkChanged("country");
                }
                _country = value;
            }
            get { return _country; }
        }
        /// <summary>
        /// 省自治区
        /// </summary>
        public string Province
        {
            set
            {
                if (this._province != value)
                {
                    this.MarkChanged("province");
                }
                _province = value;
            }
            get { return _province; }
        }
        /// <summary>
        /// 城市
        /// </summary>
        public string City
        {
            set
            {
                if (this._city != value)
                {
                    this.MarkChanged("city");
                }
                _city = value;
            }
            get { return _city; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone
        {
            set
            {
                if (this._phone != value)
                {
                    this.MarkChanged("phone");
                }
                _phone = value;
            }
            get { return _phone; }
        }
        /// <summary>
        /// 邮编
        /// </summary>
        public string Postcode
        {
            set
            {
                if (this._postcode != value)
                {
                    this.MarkChanged("postcode");
                }
                _postcode = value;
            }
            get { return _postcode; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            set
            {
                if (this._address != value)
                {
                    this.MarkChanged("address");
                }
                _address = value;
            }
            get { return _address; }
        }
        /// <summary>
        /// 职业
        /// </summary>
        public string Job
        {
            set
            {
                if (this._job != value)
                {
                    this.MarkChanged("job");
                }
                _job = value;
            }
            get { return _job; }
        }
        /// <summary>
        /// 学历
        /// </summary>
        public string Edu
        {
            set
            {
                if (this._edu != value)
                {
                    this.MarkChanged("edu");
                }
                _edu = value;
            }
            get { return _edu; }
        }
        /// <summary>
        /// 学校
        /// </summary>
        public string School
        {
            set
            {
                if (this._school != value)
                {
                    this.MarkChanged("School");
                }
                _school = value;
            }
            get { return _school; }
        }
        /// <summary>
        /// 自我介绍
        /// </summary>
        public string Introduction
        {
            set
            {
                if (this._introduction != value)
                {
                    this.MarkChanged("Introduction");
                }
                _introduction = value;
            }
            get { return _introduction; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Annex1
        {
            set
            {
                if (this._annex1 != value)
                {
                    this.MarkChanged("annex1");
                }
                _annex1 = value;
            }
            get { return _annex1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Annex2
        {
            set
            {
                if (this._annex2 != value)
                {
                    this.MarkChanged("annex2");
                }
                _annex2 = value;
            }
            get { return _annex2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Annex3
        {
            set
            {
                if (this._annex3 != value)
                {
                    this.MarkChanged("annex3");
                }
                _annex3 = value;
            }
            get { return _annex3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Annex4
        {
            set
            {
                if (this._annex4 != value)
                {
                    this.MarkChanged("annex4");
                }
                _annex4 = value;
            }
            get { return _annex4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Annex5
        {
            set
            {
                if (this._annex5 != value)
                {
                    this.MarkChanged("annex5");
                }
                _annex5 = value;
            }
            get { return _annex5; }
        }
        #endregion

        #region 构造方法
        public UserProfile()
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
                DbProviderCms.GetInstance().UserProfile_DeleteUserProfile(this);
            Dispose();
        }



        /// <summary>
        /// 插入一条数据
        /// </summary>
        protected override void DataInsert()
        {
            if (IsNew)
            {
                DbProviderCms.GetInstance().UserProfile_InsertUserProfile(this);
                CusttomFiledsBLL<StringDictionary> cfb = ModelBll.CusstomFileds.HrefFactory.GetInstance(this.UserModelID, ModelType.YHMX, EbSite.Base.Host.Instance.GetSiteID);
                cfb.Save(this.UserID, GetCusttomFileds());
                //CusttomFiledsBLLUser.Instance.Save(this.UserID, GetCusttomFileds());
            }
                
        }
        /// <summary>
        /// 与GetMenu一样，从某个ID获取某个对象,只不过这个从数据库获取GetMenu 在内存里获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected override UserProfile DataSelect(int id)
        {
            return DbProviderCms.GetInstance().UserProfile_SelectUserProfile(id);
        }
        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        protected override void DataUpdate()
        {
            if (IsChanged)
            {
                DbProviderCms.GetInstance().UserProfile_UpdateUserProfile(this);
                CusttomFiledsBLL<StringDictionary> cfb = ModelBll.CusstomFileds.HrefFactory.GetInstance(this.UserModelID, ModelType.YHMX, EbSite.Base.Host.Instance.GetSiteID);
                cfb.Save(this.UserID, GetCusttomFileds());
                //CusttomFiledsBLLUser.Instance.Save(this.UserID, GetCusttomFileds());
            }
                
        }
        /// <summary>
        /// 注册一个用户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        //public static void RegUser(string username, string password, string email, out MembershipCreateStatus ms)
        //{
        //    bool isApproved = false;//!ConfigsControl.ConfigsEntity().IsAuditingNewUser;
        //    //MembershipCreateStatus status;

        //    Membership.CreateUser(username, password, email, null, null, isApproved, null, out ms);


        //}

        public static UserProfile GetUserProfile(int id)
        {
            return DbProviderCms.GetInstance().UserProfile_SelectUserProfile(id);
        }
        public static UserProfile GetUserProfile(string username,Guid UserModelID)
        {
            return DbProviderCms.GetInstance().UserProfile_SelectUserProfile(username, UserModelID);
        }
        #endregion

        /// <summary>
        /// 验证规则
        /// </summary>
        protected override void ValidationRules()
        {
            this.AddRule("UserName", "必须设置用户名称", string.IsNullOrEmpty(this.UserName));
        }

        /// <summary>
        /// 重写ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.UserName;
        }

        #region 实现IComparable接口,以便在List里可以使用Sort对orderid 进行排序
        /// <summary>
        /// 按orderid的降序来排序,实现这个方法，可以让List.Sort(),按这个比较大小来排序
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(UserProfile other)
        {

            return this.Id.CompareTo(other.Id);
        }

        #endregion

        private StringDictionary _CusttomFileds = new StringDictionary();
        public void AddCusttomFileds(string key, string Value)
        {
            this.MarkChanged("CusttomFileds");
            _CusttomFileds.Add(key, Value);
        }
        public StringDictionary GetCusttomFileds()
        {
            return _CusttomFileds;
        }
        public StringDictionary Fileds
        {
            get
            {
                if (this.UserID > 0)
                {
                    CusttomFiledsBLL<StringDictionary> cfb = ModelBll.CusstomFileds.HrefFactory.GetInstance(this.UserModelID, ModelType.YHMX, EbSite.Base.Host.Instance.GetSiteID);
                   _CusttomFileds =cfb.GetEntity(this.UserID);
                    //_CusttomFileds = CusttomFiledsBLLUser.Instance.GetEntity(this.UserID);
                }
                return _CusttomFileds;
            }
        }

    }



}

