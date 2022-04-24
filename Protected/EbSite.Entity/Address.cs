using System;
namespace EbSite.Entity
{
    [Serializable]
    public class AddressJson 
    {
        public AddressJson()
        {
        }

        public AddressJson(Address md)
        {
            this.id = md.id;
            this._userid = md.UserID;
            this._userrealname = md.UserRealName;
            this._phone = md.Phone;
            this._mobile = md.Mobile;
            this._email = md.Email;
            this._postcode = md.PostCode;
            this._areaid = md.AreaID;
            this._addressinfo = md.AddressInfo;
            this._istemadress = md.IsTemAdress;
            this._adddateime = md.AddDateime;
          
        }
        public int id { get; set; }
        #region Model
        private int _userid;
        private string _userrealname;
        private string _phone;
        private string _mobile;
        private string _email;
        /// <summary>
        /// 用户Email
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _postcode;
        private int _areaid;
        private string _addressinfo;
        private int _istemadress;
        private DateTime _adddateime;
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        public string UserRealName
        {
            set { _userrealname = value; }
            get { return _userrealname; }
        }
        /// <summary>
        /// 座机
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string PostCode
        {
            set { _postcode = value; }
            get { return _postcode; }
        }
        /// <summary>
        /// 地区ID
        /// </summary>
        public int AreaID
        {
            set { _areaid = value; }
            get { return _areaid; }
        }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string AddressInfo
        {
            set { _addressinfo = value; }
            get { return _addressinfo; }
        }
        /// <summary>
        /// 是临时地址,在没有登录的情况下添加的地址为临时地址,结合时间，定期清理,0为否，1为是
        /// </summary>
        public int IsTemAdress
        {
            set { _istemadress = value; }
            get { return _istemadress; }
        }
        /// <summary>
        /// 添加日期
        /// </summary>
        public DateTime AddDateime
        {
            set { _adddateime = value; }
            get { return _adddateime; }
        }
        #endregion Model

    }
	/// <summary>
	/// 实体类Address 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Address: Base.Entity.EntityBase<Address,int>
	{
		public Address()
		{
			
		}

        #region Model
        private int _userid;
        private string _userrealname;
        private string _phone;
        private string _mobile;
        private string _email;
        /// <summary>
        /// 用户Email
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _postcode;
        private int _areaid;
        private string _areaname = "";
        private int _countryid;
        private string _countryname = "";
        private int _provinceid;
        private string _provincename = "";
        private int _cityid;
        private string _cityname = "";
        private string _addressinfo;
        private int _istemadress;
        private DateTime _adddateime;
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        public string UserRealName
        {
            set { _userrealname = value; }
            get { return _userrealname; }
        }
        /// <summary>
        /// 座机
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string PostCode
        {
            set { _postcode = value; }
            get { return _postcode; }
        }
        /// <summary>
        /// 地区ID
        /// </summary>
        public int AreaID
        {
            set { _areaid = value; }
            get { return _areaid; }
        }
        /// <summary>
        /// 地区名称
        /// </summary>
        public string AreaName
        {
            set { _areaname = value; }
            get { return _areaname; }
        }
        /// <summary>
        /// 国家ID
        /// </summary>
        public int CountryID
        {
            set { _countryid = value; }
            get { return _countryid; }
        }
        /// <summary>
        /// 国家名称 --没使用的字段，所以暂时用来保存当前区域的低级区域ID,用逗号分开
        /// </summary>
        public string CountryName
        {
            set { _countryname = value; }
            get { return _countryname; }
        }
        /// <summary>
        /// 省份ID
        /// </summary>
        public int ProvinceID
        {
            set { _provinceid = value; }
            get { return _provinceid; }
        }
        /// <summary>
        /// 省份名称
        /// </summary>
        public string ProvinceName
        {
            set { _provincename = value; }
            get { return _provincename; }
        }
        /// <summary>
        /// 城市ID
        /// </summary>
        public int CityID
        {
            set { _cityid = value; }
            get { return _cityid; }
        }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName
        {
            set { _cityname = value; }
            get { return _cityname; }
        }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string AddressInfo
        {
            set { _addressinfo = value; }
            get { return _addressinfo; }
        }
        /// <summary>
        /// 是临时地址,在没有登录的情况下添加的地址为临时地址,结合时间，定期清理,0为否，1为是
        /// </summary>
        public int IsTemAdress
        {
            set { _istemadress = value; }
            get { return _istemadress; }
        }
        /// <summary>
        /// 添加日期
        /// </summary>
        public DateTime AddDateime
        {
            set { _adddateime = value; }
            get { return _adddateime; }
        }
        #endregion Model

	}
}

