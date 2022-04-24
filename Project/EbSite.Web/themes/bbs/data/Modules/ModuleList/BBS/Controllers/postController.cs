//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace EbSite.Modules.BBS.Controllers
//{
//    [System.Web.Mvc.RoutePrefix("bbs/{SiteId}")]
//    public class postController :EbSite .Mvc.Controllers.CtlBase
//    {
//        public postController()
//        {
            
//        }
//        [Route("post/{classid}/")]
//        [HttpGet]
//        public ActionResult Post(int classid)
//        {
//            ViewBag.Title = "发表帖子";
//            string tem = base.GetPagesFileName("bbssavepost.cshtml");
//            return View(tem);
//        }
//	}
//}