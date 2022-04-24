<div class="tbox">
      <div class="utitle">
        <div class="utitlei">
          <div class="title"><span class="title_t fLeft"><span class="title_t_i fLeft">
            <h2><a href="<%#EbSite.Base.Host.Instance.GetClassHref(Eval("ID"),Eval("htmlname"),0)%>"  style="color:#FFF"><%#Eval("classname")%></a></h2>
            </span></span>
            <div class="iterm fRight">
              <ul>
                <li><a href="<%#EbSite.Base.Host.Instance.GetClassHref(Eval("ID"),Eval("htmlname"),0)%>"><span>¸ü¶à...</span></a></li>
              </ul>
            </div>
          </div>
        </div>
      </div>
      <div class="ucontent">
        <div class="list-main clear" style=" height:150px;">
             <asp:PlaceHolder ID="phList" runat="server"></asp:PlaceHolder>
        </div>
      </div>
      <div class="title_buttom">
        <div class="title_buttom_i"></div>
      </div>
    </div>