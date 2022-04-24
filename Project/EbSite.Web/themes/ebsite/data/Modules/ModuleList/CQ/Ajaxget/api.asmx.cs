using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using EbSite.Base;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Base.EntityAPI;
using EbSite.Base.EntityCustom;
using EbSite.Base.Json;
using EbSite.BLL;
using EbSite.Modules.CQ.ModuleCore;
using EbSite.Modules.CQ.ModuleCore.BLL;
using EbSite.Modules.CQ.ModuleCore.Configs;
using EbSite.Modules.CQ.ModuleCore.Entity;
using System.Text.RegularExpressions;
using System.IO;

namespace EbSite.Modules.CQ.Ajaxget
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class api : WebServiceBase
    {
        [WebMethod]
        public List<TreeItem> GetOrderBoxClassList(string pid)
        {
            if (IsAllow(false))
            {
                List<TreeItem> lstOK = new List<TreeItem>();
                List<ModuleCore.Entity.CustomItemsInfo> lst = CustomItems.Instance.GetListByParentID(int.Parse(pid)).ToList();
                if (lst.Count>0)
                {
                    foreach (CustomItemsInfo itemsInfo in lst)
                    {
                        lstOK.Add(new TreeItem(itemsInfo.id, itemsInfo.ItemName, itemsInfo.ParentID));
                    }
                    
                }
                return lstOK;
            }
            return null;
        }

     /// <summary>
        /// 获取分类列表，从父ID
     /// </summary>
     /// <param name="pid"></param>
     /// <param name="st">数据源模式</param>
        /// <param name="type">请求类型1.数据来源于上一步客户选择下拉ID,2.数据来源于指定父ID</param>
     /// <returns></returns>
        [WebMethod]
        public List<TreeItem> GetEbClassList(string pid, int st, int type, int stepid)
        {
            if (IsAllow(false))
            {

                List<TreeItem> lstOK = new List<TreeItem>();
                if (st == 1)
                {

                    OrderBoxGetEbClassListEventArgs Args = new OrderBoxGetEbClassListEventArgs(pid, type, stepid);
                    Utils.OnOrderBoxGetEbClassList(null, Args);

                    if (!Args.IsStop)
                    {

                        string strSql = string.Concat("parentid=", pid);
                        if (pid.IndexOf(',') > 0)
                        {
                            strSql = string.Concat("parentid in(", pid, ")");
                        }
                        List<EbSite.Entity.NewsClass> lst = EbSite.BLL.NewsClass.GetListArr("ID,ClassName,ParentID", strSql, 0, "", 1);
                        foreach (EbSite.Entity.NewsClass info in lst)
                        {
                            lstOK.Add(new TreeItem(info.ID, info.ClassName, info.ParentID));
                           
                        }

                    }
                    else
                    {
                        return Args.CustomList;
                    }

                    
                }
                else
                {
                    List<ModuleCore.Entity.CustomItemsInfo> lst = CustomItems.Instance.GetListByParentID(int.Parse(pid)).ToList();
                    if (lst.Count > 0)
                    {
                        foreach (CustomItemsInfo itemsInfo in lst)
                        {
                            lstOK.Add(new TreeItem(itemsInfo.id, itemsInfo.ItemName, itemsInfo.ParentID));
                        }

                    }
                }


                return lstOK;



            }
            else
            {
                return null;
            }

        }

        #region 聊天
        [WebMethod]
        public List<ListItemModel> GetServicerOnline()
        {
            List<ListItemModel> lst = new List<ListItemModel>();

            List<ModuleCore.Entity.ServiceInfo> lstServ = Service.Instance.FillList();

            foreach (ServiceInfo serviceInfo in lstServ)
            {
                ListItemModel md = new ListItemModel(serviceInfo.id.ToString(), serviceInfo.IsOnline ? "1" : "0");
                lst.Add(md);
            }

            return lst;
        }


        [WebMethod]
        public void AddMsg(string s, string r, string m, int dg)
        {
            ChatMsg md = new ChatMsg();
            md.IsRead = false;
            md.Msg = m;
            md.Recipient = r;
            md.Sender = s;
            md.IsSetDG = dg;
            ChatBll.Instance.AddMsg(md);
        }

        [WebMethod]
        public List<ChatMsg> GetMsg(string s, string r)
        {
            return ChatBll.Instance.GetMsgs(s, r);
        }

        #endregion

        #region 客户操作
        [WebMethod]
        public int CustomersIsLeave(int suid, string cid)
        {
            List<Customer> lst = ChatBll.Instance.CustomersOnline(suid);
            foreach (Customer customer in lst)
            {
                if (customer.CustomerUserName == cid)
                    return 0;
            }
            return 1;
        }

        /// <summary>
        /// 获取某个客服下的在线客户
        /// </summary>
        /// <param name="suid">客服ID</param>
        /// <returns></returns>
        [WebMethod]
        public List<Customer> CustomersOnline(int suid, string rand)
        {
            return ChatBll.Instance.CustomersOnline(suid);
        }
        [WebMethod]
        public int CountCustomersOnline(int suid)
        {
            return ChatBll.Instance.CustomersOnline(suid).Count;
        }
        [WebMethod]
        public void SetOffLine(int suid,int stepid)
        {
            ChatBll.Instance.DeleteCustomer(suid);

            //更新跳出率
            if (stepid > 0)
            {
                OrderBoxInfo md = OrderBox.Instance.GetEntity(stepid);
                md.CloseNum = md.CloseNum + 1;
                OrderBox.Instance.Update(md);
            }
        }
        [WebMethod]
        public void SetOffLine2(int suid,string cid)
        {

            ChatBll.Instance.DeleteCustomer(suid, cid);
        }
        /// <summary>
        /// 向某个客服下添加客户
        /// </summary>
        /// <param name="suid"></param>
        [WebMethod]
        public void AddCustomer(int suid)
        {
            ChatBll.Instance.AddCustomers(suid);
        }

        #endregion
        /// <summary>
        /// 随机获取一个空闲的客服,没有返回0
        /// </summary>
        /// <param name="thisid">当前客服的ID</param>
        /// <returns></returns>
        [WebMethod]
        public int ServerForFree(int thisid)
        {
            return ModuleCore.BLL.Service.Instance.ServerForFree(thisid);
           
        }
        #region 客服操作
        /// <summary>
        /// 获取客服
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [WebMethod]
        public JsonResponse<ServiceModel> GetChatUser(int uid)
        {
            ServiceInfo md = ModuleCore.BLL.Service.Instance.GetEntity(uid);
            ServiceModel mdjs = new ServiceModel(md);


            return new JsonResponse<ServiceModel> { Success = true, Message = "调用成功", Data = mdjs };
        }
        //[WebMethod]
        //public void UpdateServicerLastTime(int suid)
        //{
        //    ServiceInfo md = Service.Instance.GetEntity(suid);
        //    md.LastDateTime = DateTime.Now;
        //    Service.Instance.Update(md);
        //}

        /// <summary>
        /// 设置某个客服为离线
        /// </summary>
        /// <param name="suid"></param>
        [WebMethod]
        public void ServiceOffLine(int suid)
        {
            ServiceInfo mdServer = ModuleCore.BLL.Service.Instance.GetEntity(suid);
            mdServer.IsOnline = false;
            //更新在线状态
            ModuleCore.BLL.Service.Instance.Update(mdServer);
        }
        #endregion

        #region 定单宝下单
        /// <summary>
        /// 
        /// </summary>
        /// <param name="suid"></param>
        /// <param name="suname"></param>
        /// <param name="columvals">步骤ID{#-#}分类名称{#-#}分类ID{#-#}关联字段   如 1#-#宝马#--#363#-#carsystem{\n}2#-#宝马X6#--#569#-#carmodel</param>
        [WebMethod]
        public string AddOrderBox(int suid, string suname, string columvals)
        {
            string ordernum = "";
            List<CustomOrderInfo> lst = new List<CustomOrderInfo>();
            if (!string.IsNullOrEmpty(columvals))
            {
                Guid ct = Guid.NewGuid();
                ordernum = OrderNum;
                string[] arryStep = Core.Strings.GetString.SplitString(columvals, "{---}"); //columvals.Split(new char[4] { '{', '\\', '!', '}' });
                foreach (string sStep in arryStep)
                {
                    string[] arryCtent = Core.Strings.GetString.SplitString(sStep, "{#-#}");
                    if (arryCtent.Length > 0)
                    {
                        CustomOrderInfo md = new CustomOrderInfo();
                        md.ServiceID = suid;
                        md.ServiceName = suname;
                        md.StepsID = arryCtent[0];
                        md.ClassName = arryCtent[1];
                        if (string.IsNullOrEmpty(arryCtent[2]))
                        {
                            md.ClassID = 0;
                        }
                        else
                        {
                            md.ClassID = Core.Utils.StrToInt(arryCtent[2], 0);
                        }
                        md.TimeStamp = ct;
                        md.OpDateTime = DateTime.Now;
                        md.OrderNum = ordernum;
                        md.UserID = base.UserID();
                        md.FieldName = arryCtent[3];
                        md.Ip = EbSite.Core.Utils.GetClientIP();//获取客户端IP地址
                        lst.Add(md);
                        if (SvConfigsControl.Instance.IsSaveOrder)
                        {
                            ModuleCore.BLL.CustomOrder.Instance.Add(md);
                        }
                    }
                    

                }

                //for (int i = 0; i < arryStep.Length; i = i + 3)
                //{
                //    string[] arryCtent = arryStep[i].Split(new char[3] { '#', '-', '#' });
                //    if (arryCtent.Length > 7)
                //    {
                //        CustomOrderInfo md = new CustomOrderInfo();
                //        md.ServiceID = suid;
                //        md.ServiceName = suname;
                //        md.StepsID = arryCtent[0];
                //        md.ClassName = arryCtent[3];
                //        if (arryCtent[6] == "")
                //        {
                //            md.ClassID = 0;
                //        }
                //        else
                //        {
                //            md.ClassID = Core.Utils.StrToInt(arryCtent[6], -1);
                //        }
                //        md.TimeStamp = ct;
                //        md.OpDateTime = DateTime.Now;
                //        md.OrderNum = ordernum;
                //        md.UserID = base.UserID();
                //        md.FieldName = arryCtent[9];
                //        md.Ip = EbSite.Core.Utils.GetClientIP();//获取客户端IP地址
                //        lst.Add(md);
                //        if (SvConfigsControl.Instance.IsSaveOrder)
                //        {
                //            ModuleCore.BLL.CustomOrder.Instance.Add(md);
                //        }
                //    }
                //}
            }
            OrderBoxEventArgs Args = new OrderBoxEventArgs(lst);
            Base.EBSiteEvents.OnOrderBoxAdding(ordernum, Args);
            return ordernum;


            //string ordernum = "";
            //List<CustomOrderInfo> lst = new List<CustomOrderInfo>();
            //if (!string.IsNullOrEmpty(columvals))
            //{
            //    Guid ct = Guid.NewGuid();
            //    ordernum = OrderNum;
            //    string[] arryStep = columvals.Split(new char[4] { '{', '\\', '!', '}' });
            //    for (int i = 0; i < arryStep.Length; i = i + 3)
            //    {
            //        string[] arryCtent = arryStep[i].Split(new char[3] { '#', '-', '#' });
            //        if (arryCtent.Length > 7)
            //        {
            //            CustomOrderInfo md = new CustomOrderInfo();
            //            md.ServiceID = suid;
            //            md.ServiceName = suname;
            //            md.StepsID = arryCtent[0];
            //            md.ClassName = arryCtent[3];
            //            if (arryCtent[6] == "")
            //            {
            //                md.ClassID = 0;
            //            }
            //            else
            //            {
            //                md.ClassID = Core.Utils.StrToInt(arryCtent[6], -1);
            //            }
            //            md.TimeStamp = ct;
            //            md.OpDateTime = DateTime.Now;
            //            md.OrderNum = ordernum;
            //            md.UserID = base.UserID();
            //            md.FieldName = arryCtent[9];
            //            md.Ip = EbSite.Core.Utils.GetClientIP();//获取客户端IP地址
            //            lst.Add(md);
            //            if (SvConfigsControl.Instance.IsSaveOrder)
            //            {
            //                ModuleCore.BLL.CustomOrder.Instance.Add(md);
            //            }
            //        }
            //    }
            //}
            //OrderBoxEventArgs Args = new OrderBoxEventArgs(lst);
            //Base.EBSiteEvents.OnOrderBoxAdding(ordernum, Args);
            //return ordernum;
        }

        /// <summary>
        /// 生成订单编号
        /// </summary>
        public string OrderNum
        {
            get
            {
                //生成机制待修改
                //DateTime dt = DateTime.Now;
                //string ordernum = string.Format("{0}{1}{2}{3}{4}{5}{6}", dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
                //return ordernum;
                DateTime dt_s = DateTime.Now;
                DateTime dt_end = new DateTime(dt_s.Year, dt_s.Month, dt_s.Day, dt_s.Hour, dt_s.Minute, dt_s.Second, dt_s.Millisecond);
                DateTime dt_begin = new DateTime(2011, 1, 1, 0, 0, 0, 0);
                return dt_end.Subtract(dt_begin).TotalMilliseconds.ToString();
            }
        }
        #endregion

        #region 投诉或建意
        /// <summary>
        /// 投诉或建意
        /// </summary>
        /// <param name="suid">客服ID</param>
        /// <param name="suname">客服名称</param>
        /// <param name="typeid">投诉1  建意2</param>
        /// <param name="ctent">内容</param>
        /// <param name="starnum">打分</param>
        /// <returns></returns>
        [WebMethod(Description = "投诉或建意")]
        public bool ComplanAdd(int suid, string suname, int typeid, string ctent, int starnum)
        {
            bool key = true;
            if (!string.IsNullOrEmpty(ctent))
            {
                ModuleCore.Entity.ComplainInfo md = new ComplainInfo();
                md.Ctent = ctent;
                md.OpDateTime = DateTime.Now;
                md.ServiceID = suid;
                md.ServiceName = suname;
                md.TypeID = typeid;
                md.TypeName = (Equals(typeid, 1) ? "投诉" : "建意");
                int id = ModuleCore.BLL.Complaincs.Instance.Add(md);
                //if (id > 0)
                //    key = true;
            }
            ModuleCore.Entity.ServiceInfo model = ModuleCore.BLL.Service.Instance.GetEntity(suid);
            if (starnum == 1)
            {
                model.StarOne = model.StarOne + 1;
            }
            else if (starnum == 2)
            {
                model.StarTwo = model.StarTwo + 1;
            }
            else if (starnum == 3)
            {
                model.StarThree = model.StarThree + 1;
            }
            else if (starnum == 4)
            {
                model.StarFour = model.StarFour + 1;
            }
            else if (starnum == 5)
            {
                model.StarFive = model.StarFive + 1;
            }
            ModuleCore.BLL.Service.Instance.Update(model);

            return key;
        }



        #endregion

        #region 用户订单操作

        [WebMethod(Description = "判断是否登录")]
        public int IsLogin()
        {
            return base.UserID();
        }
        [WebMethod(Description = "获取未登录的URL")]
        public string GetNoLoginURL()
        {
            return EbSite.Base.Host.Instance.GetClassHref(12465, 1);

        }

        #endregion 用户订单操作

        #region 聊天记录操作

        [WebMethod]
        public int SaveChatRecord(string strJson)
        {
            int result = 0;
            if (!string.IsNullOrEmpty(strJson) && !strJson.Equals("[]"))
            {
                //判断是否符合
                if (strJson.IndexOf("},{") > 0)
                {
                    //替换特殊字符串
                    string formatJson = strJson.Replace("[", "").Replace("]", "").Replace("|", "#-SHUXIAN-#").Replace("},{", "}|{");
                    string[] jsonArr = formatJson.Split('|');
                    foreach (string str in jsonArr)
                    {
                        //还原特殊字符串
                        string tmpStr = str.Replace("#-SHUXIAN-#", "|");
                        //Json转换成对象
                        EbSite.Entity.Tool_ChatList md = JsonToObject<EbSite.Entity.Tool_ChatList>(tmpStr);
                        if (string.IsNullOrEmpty(md.UserNiName))
                        {
                            md.UserNiName =md.UserName;
                            if (md.UserName.IndexOf("游客-") > -1)
                            {
                                md.UserID=Core.Utils.StrToInt(md.UserName.Replace("游客-", ""),-1);
                            }
                        }
                        //添加到数据库中
                        EbSite.BLL.Tool_ChatList.Instance.Add(md);
                        result = 1;
                    }
                }
                else
                {
                    string formatJson = strJson.Replace("[", "").Replace("]", "");
                    EbSite.Entity.Tool_ChatList md = JsonToObject<EbSite.Entity.Tool_ChatList>(formatJson);
                    EbSite.BLL.Tool_ChatList.Instance.Add(md);
                    result = 1;
                }
            }
            return result;
        }
        public T JsonToObject<T>(string content) where T : new()
        {
            var restResponse = new RestSharp.RestResponse { Content = content };
            var d = new RestSharp.Deserializers.JsonDeserializer();
            var payload = d.Deserialize<T>(restResponse);
            return payload;
        }

        #endregion 聊天记录操作
        [WebMethod]
        public int IsServiceOff(int suid, string cid)
        {
            Customer md =    ChatBll.Instance.GetCustomer(suid, cid);

            return Equals(md, null) ? 1 : 0;
        }

        #region  随机得到一个在线的客服ID 或不在线的ID
         [WebMethod]
        public int RandServerID()
        {
            List<EbSite.Modules.CQ.ModuleCore.Entity.ServiceInfo> ls = EbSite.Modules.CQ.ModuleCore.BLL.Service.Instance.FillList();

            List<EbSite.Modules.CQ.ModuleCore.Entity.ServiceInfo> onlinenls;
            List<EbSite.Modules.CQ.ModuleCore.Entity.ServiceInfo> nonls;
            onlinenls = (from i in ls where i.IsOnline == true orderby Guid.NewGuid() select i).Take(1).ToList();
            if (onlinenls.Count>0)
            {
                return onlinenls[0].id;
            }
            else
            {
                nonls = (from i in ls where i.IsOnline == false orderby Guid.NewGuid() select i).Take(1).ToList();
                if(nonls.Count>0)
                {
                    return nonls[0].id;
                }
            }
            return 0;
        }
        #endregion

        #region 留言
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msgct"></param>
        /// <param name="customid"></param>
        /// <returns></returns>
        [WebMethod]
        public bool AddMsgCt(string msgct,int customid)
        {
             EbSite.BLL.Msg msg = new Msg();
            msg.RecipientUserID = customid;
            msg.SenderUserID = base.UserID();
            if(string.IsNullOrEmpty(base.UserName()))
            {
                EbSite.Entity.ClientIpInfo md = Core.Utils.GetAreaIDByIP(Core.Utils.GetClientIP());
                msg.SenderNiName =string.Concat( md.Province,md.City);
            }
            else
            {
                msg.SenderNiName = base.UserName();
            }

            msg.MsgContent = msgct;
            msg.Title = Core.Utils.GetClientIP() ;
            msg.SendDate = DateTime.Now;
            msg.IsNewMsg = false;
            msg.FolderType = 1;//收件
            string us =EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(customid).UserName;
            msg.Recipient = us;
            msg.Sender = msg.SenderNiName;
            msg.Save();
            return true;
        }
        #endregion
    }
}
