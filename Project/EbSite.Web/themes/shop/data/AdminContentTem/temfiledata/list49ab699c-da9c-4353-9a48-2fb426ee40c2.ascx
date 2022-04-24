
<tr>   <td style="width:100px;">   <a href='<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("htmlname"),Eval("classid"))%>'target="_blank">
<img width="100" height="100" src="<%# Eval("smallpic") %>"></img>
</a>
</td>
<td style="width:260px;"> <a href='<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("htmlname"),Eval("classid"))%>'target="_blank"><%#Eval("newstitle")%></a>
                    </td>
                    <td><%#Eval("classname")%></td>
  <td><%#Eval("hits")%></td>
                    <td><%#Eval("dayhits")%></td>
                    <td><%#Eval("weekhits")%></td>
                   <td><%#Eval("monthhits")%></td>
                    <td><%#Eval("commentnum")%></td>
                    <td><%#Eval("Advs")%></td>
                    <td><%#Eval("favorablenum")%></td>
                     <td>
                   <%#Object.Equals(Eval("isgood").ToString(),"False")%>
                    </td>
                   <td>
 <span> <a href='<%#string.Format("?t=4&id={0}",Eval("id"))%>'>  修改</a></span>
 <span><asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' OnClientClick="javascript:return confirm('您确定要删除该项么?')"  CommandName="DeleteModel"  Text="删除">  
</asp:LinkButton>   </span>
 <span><asp:LinkButton ID="lbCopy" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="CopyModel" Text="复制"></asp:LinkButton></span>
<a href="<%=EbSite.Base.Host.Instance.GetModuleUrlForAdmin("cfccc599-4585-43ed-ba31-fdb50024714b", "ad96751e-8010-42f7-b2e4-4f30d10583fb") %>&iid=<%#Eval("id") %>&title=<%#Eval("newstitle") %>">商品费用选项</a>
<a href="<%=EbSite.Base.Host.Instance.GetModuleUrlForAdmin("cfccc599-4585-43ed-ba31-fdb50024714b", "007ec759-79e7-4234-a23e-5eba8e7d764c") %>&iid=<%#Eval("id") %>&title=<%#Eval("newstitle") %>">最佳组合</a>
<a href="<%=EbSite.Base.Host.Instance.GetModuleUrlForAdmin("cfccc599-4585-43ed-ba31-fdb50024714b", "f85678b7-6350-447d-a4b7-3e941d8bf612") %>&iid=<%#Eval("id") %>&title=<%#Eval("newstitle") %>">推荐配件</a>
<a href="<%=EbSite.Base.Host.Instance.GetModuleUrlForAdmin("cfccc599-4585-43ed-ba31-fdb50024714b", "0c5d8d33-a774-4f05-98ab-266e5573f8fd") %>&iid=<%#Eval("id") %>&title=<%#Eval("newstitle") %>">使用指南</a>
</td>
  <td> <input name="ebcheckboxname" value="<%#Eval("ID")%>" type="checkbox" /></td>
  </tr>



   
      
               