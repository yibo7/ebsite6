<!--������������ģ������!-->

 <ul>               
    <li class="headImg">
          <div style="v-align: center; margin: 20px;">
            <img id="AvatarBig" src='..<%#  Eval("AvatarSmall")%>'; width="80"   />                        
              </div>
             </li>
                          <li>�ǳƣ�<%# Eval("niname")%></li>
                          <li>����<%# EbSite.BLL.UserLevel.Instance.GetUserLevelForScore( Eval("Credits").ToString()).LevelName%></li>
                          <li>���֣�<%# Eval("Credits")%></li>
                          <li>ע��ʱ�䣺<%# String.Format("{0:d}",Convert.ToDateTime( Eval("CreateDate").ToString()))%></li>
   </ul>