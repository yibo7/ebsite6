using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace EbSite.Modules.BBS.Models
{
    [Serializable]
    public class PostModel
    {
        public long Id { get; set; }
        //[Display(Name = "客服名称")]
        //[Required(ErrorMessage = "客服名称不能为空")]
        //[StringLength(10, MinimumLength = 2, ErrorMessage = "客服名称必须是{2}到{1}个字符")]
        public string Title { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string Content { get; set; }
        //[Display(Name = "联系电话")]
        //[Required(ErrorMessage = "联系电话不能为空")]
        //[RegularExpression("^0(([1-9]\\d)|([3-9]\\d{2}))\\d{8}$", ErrorMessage = "请输入正确的电话,格式为01051659881")]
        public string Tags { get; set; }
        //[Display(Name = "手机号码")]
        //[Required(ErrorMessage = "客服名称不能为空")]
        //[StringLength(13, MinimumLength = 11, ErrorMessage = "请输入11位手机号码")]
        public bool IsEabled { get; set; }

        
        
    }
}