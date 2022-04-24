<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuestionsAdd.ascx.cs" Inherits="EbSite.Modules.Exam.AdminPages.Controls.Exam.QuestionsAdd" %>
 <%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 <asp:PlaceHolder ID="phCtrList" runat="server">
  <style>
      .type_check{ border: 1px solid #ccc;}
       .type_check .h td{background: #F2F2F2;padding-left: 10px;}
        .type_check .l td{background: #fff;}
       .type_check .l td textarea{ border: none;}
  </style>
<XS:CustomTagsBox ID="ctbTag" runat="server"></XS:CustomTagsBox>


   
   <div id="tg1">
       
       <table>
        
        <tr>
                <td>                    
                    隶属试卷：               
                </td>                
                <td>
                    <asp:Label ID="lbInation" runat="server" Text="Label"></asp:Label>
                </td>
               
            </tr>
          <tr>
                <td>                    
                    考题：               
                </td>                
                <td>
                    <XS:TextBoxVL ID="Questions"  TextMode="MultiLine"  height="100" IsAllowNull="false"   runat="server" Width="500"></XS:TextBoxVL>
                </td>
            </tr>
            <tr>
                <td>                    
                    答案解析：               
                </td>                
                <td>
                    <XS:TextBoxVL ID="Analysis"  TextMode="MultiLine"  height="200"     runat="server" Width="600"></XS:TextBoxVL>
                </td>
            </tr>
              <tr>
                <td>                    
                    排序权重：               
                </td>                
                <td>
                    <XS:TextBoxVL ID="OrderID" ValidateType="正整数"   IsAllowNull="false"  runat="server" Width="30">1</XS:TextBoxVL>
                </td>
               
            </tr>
            <tr>
                <td>                    
                    本题得分：               
                </td>                
                <td>
                    <XS:TextBoxVL ID="Score" ValidateType="匹配正浮点数"     IsAllowNull="false"  runat="server" Width="80">10.12</XS:TextBoxVL>
                </td>
               
            </tr>
              <tr>
                <td>                    
                    考题类别：               
                </td>                
                <td>
                    <asp:DropDownList ID="ClassID"   runat="server"></asp:DropDownList>
                </td>
               
            </tr>
           
    </table>

   </div>
   
   <div id="tg2">
       <div class="cQuestionsType">
          考题类型： <XS:RadioButtonList ID="QuestionsType" RepeatColumns="5" runat="server"  >
                        <asp:ListItem Selected="True" Text="为单选题"  Value="0"/>
                        <asp:ListItem Text="为多选题" Value="1"/>
                        <asp:ListItem Text="为填空题" Value="2"/>
                        <asp:ListItem Text="问答题"  Value="3"/>
                        <asp:ListItem Text="判断题"  Value="4"/>
                    </XS:RadioButtonList>
       </div>
       <table>
           
           
            <tr class="type_pd">
                <td>                    
                    答案(判断)：               
                </td>                
                <td>
                    <asp:RadioButtonList ID="rbAnswerJudge" RepeatColumns="2" runat="server">
                        <asp:ListItem Text="正确" Selected="True"  Value="1"/>
                        <asp:ListItem Text="错误"  Value="0"/>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr class="type_input">
                  <td>答案:</td>
                  <td><asp:TextBox ID="Blanks" runat="server" TextMode="MultiLine"  height="50" Width="500"></asp:TextBox>  </td>
            </tr>
            
       </table>
       
      <table class="type_check">
                              <tr class="h">
                                  <td>选项A:<asp:CheckBox ID="CheckBoxA" Text="是否正确题"  runat="server"  /></td>
                              </tr>
                              <tr class="l">
                                  <td>
                                       <XS:TextBoxVL ID="AnswerA"  TextMode="MultiLine"  height="50"     runat="server" Width="500"></XS:TextBoxVL>
                                  </td>
                              </tr>
                          </table>
                          
                          <table class="type_check">
                              <tr class="h">
                                  <td>选项B:<asp:CheckBox ID="CheckBoxB" Text="是否正确题"  runat="server"  /></td>
                              </tr>
                              <tr class="l">
                                  <td>
                                       <XS:TextBoxVL ID="AnswerB"  TextMode="MultiLine"  height="50"     runat="server" Width="500"></XS:TextBoxVL>
                                  </td>
                              </tr>
                          </table>
                          
                           <table class="type_check">
                              <tr class="h">
                                  <td>选项C:<asp:CheckBox ID="CheckBoxC" Text="是否正确题"  runat="server"  /></td>
                              </tr>
                              <tr class="l">
                                  <td>
                                       <XS:TextBoxVL ID="AnswerC"  TextMode="MultiLine"  height="50"     runat="server" Width="500"></XS:TextBoxVL>
                                  </td>
                              </tr>
                          </table>
                          
                           <table class="type_check">
                              <tr class="h">
                                  <td>选项D:<asp:CheckBox ID="CheckBoxD" Text="是否正确题"  runat="server"  /></td>
                              </tr>
                              <tr class="l">
                                  <td>
                                       <XS:TextBoxVL ID="AnswerD"  TextMode="MultiLine"  height="50"     runat="server" Width="500"></XS:TextBoxVL>
                                  </td>
                              </tr>
                          </table>
                          
                           <table class="type_check">
                              <tr class="h">
                                  <td>选项E:<asp:CheckBox ID="CheckBoxE" Text="是否正确题"  runat="server"  /></td>
                              </tr>
                              <tr class="l">
                                  <td>
                                       <XS:TextBoxVL ID="AnswerE"  TextMode="MultiLine"  height="50"     runat="server" Width="500"></XS:TextBoxVL>
                                  </td>
                              </tr>
                          </table>
                          <table class="type_check">
                              <tr class="h">
                                  <td>选项F:<asp:CheckBox ID="CheckBoxF" Text="是否正确题"  runat="server"  /></td>
                              </tr>
                              <tr class="l">
                                  <td>
                                       <XS:TextBoxVL ID="AnswerF"  TextMode="MultiLine"  height="50"     runat="server" Width="500"></XS:TextBoxVL>
                                  </td>
                              </tr>
                          </table>
                          <table class="type_check">
                              <tr class="h">
                                  <td>选项G:<asp:CheckBox ID="CheckBoxG" Text="是否正确题"  runat="server"  /></td>
                              </tr>
                              <tr class="l">
                                  <td>
                                       <XS:TextBoxVL ID="AnswerG"  TextMode="MultiLine"  height="50"     runat="server" Width="500"></XS:TextBoxVL>
                                  </td>
                              </tr>
                          </table>
   </div>

<asp:Literal ID="llTagEnd" runat="server"></asp:Literal>

<div style="text-align: center; padding: 10px;">
     <XS:Button ID="bntSave" runat="server" Text=" 提 交 数 据 "  />
</div>
</asp:PlaceHolder> 
 
 
 <script>
     jQuery(function ($) {

         QuestionsTypeChange();
          
         $(".cQuestionsType input").change(function () {
             QuestionsTypeChange();
         });
         var ob = $(".type_check");
         $('input:checkbox', ob).click(function () {
            if (ity == 0) {
                clearcheck();
                $(this).attr("checked", true);  
            }
         });
     });
     var ity = 0;
     function QuestionsTypeChange() {
         $(".type_input,.type_check,.type_pd").hide();

          ity = $('input:radio:checked').val();

         if (ity == 0 || ity == 1) {
             $(".type_check").show();
             clearcheck();
         }
         else if (ity == 2 || ity == 3) {

             $(".type_input").show();
         } 
         else if (ity == 4) {

             $(".type_pd").show();
         }
     }

     function  clearcheck() {
         var ob = $(".type_check");
         $('input:checkbox', ob).removeAttr("checked");
       
     }

</script>
    
      
         