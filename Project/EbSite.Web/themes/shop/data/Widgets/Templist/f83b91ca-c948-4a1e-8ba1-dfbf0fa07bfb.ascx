<!--请在这里输入模板内容!-->

 <ul>               
    <li class="headImg">
          <div style="v-align: center; margin: 20px;">
            <img id="AvatarBig" src='..<%#  Eval("AvatarSmall")%>'; width="80"   />                        
              </div>
             </li>
                          <li>昵称：<%# Eval("niname")%></li>
                          <li>级别：<%# EbSite.BLL.UserLevel.Instance.GetUserLevelForScore( Eval("Credits").ToString()).LevelName%></li>
                          <li>积分：<%# Eval("Credits")%></li>
                          <li>注册时间：<%# String.Format("{0:d}",Convert.ToDateTime( Eval("CreateDate").ToString()))%></li>
   </ul>