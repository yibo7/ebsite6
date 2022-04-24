using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EbSite.Entity
{
    [Serializable]
   public class ClientIpInfo
    {
        
        private int _ret;
       /// <summary>
       /// 返回是否成功 的结果。1：成功。0：失败
       /// </summary>
        public int Ret
        {
            get { return _ret; }
            set { _ret = value; }
        }
        private string _start;
       /// <summary>
       /// 这个段的开始IP（当前这个IP属于的段）
       /// </summary>
        public string Start
        {
            get { return _start; }
            set { _start = value; }
        }
        private string _end;
       /// <summary>
       /// 当个段IP的 结尾
       /// </summary>
        public string End
        {
            get { return _end; }
            set { _end = value; }
        }
        private string _country;
       /// <summary>
       /// 国家
       /// </summary>
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        private string _province;
      /// <summary>
      /// 省份
      /// </summary>
        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }
        private string _city;
       /// <summary>
       /// 城市 
       /// </summary>
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        private string _district;
       /// <summary>
        /// 获得区信息
       /// </summary>
        public string District
        {
            get { return _district; }
            set { _district = value; }
        }
        private string _isp;
       /// <summary>
        /// 获得ISP信息
       /// </summary>
        public string Isp
        {
            get { return _isp; }
            set { _isp = value; }
        }
        private string _type;
       /// <summary>
        /// 获得服务提供商类型
       /// </summary>
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _desc;
       /// <summary>
        /// 获取其他信息
       /// </summary>
        public string Desc
        {
            get { return _desc; }
            set { _desc = value; }
        }
    }
}
