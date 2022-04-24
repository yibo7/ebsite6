<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AskConfig.ascx.cs" Inherits="EbSite.Modules.Wenda.AdminPages.Controls.AskConfig.AskConfig" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="admin_toobar">
    <fieldset>
        <legend>修改系统配置</legend>
        <div style="padding-left: 10px;">
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td height="25" width="30%" align="right">
                        热门问题判断数(条数) ：
                    </td>
                    <td height="25" width="*" align="left">
                        <XS:TextBoxVl id="AnswerNum" runat="server" Width="200px">
                        </XS:TextBoxVl>
                    </td>
                </tr>
               <tr>
                    <td height="25" width="30%" align="right">
                        内容页右侧缓存的在数 ：
                    </td>
                    <td height="25" width="*" align="left">
                        <XS:TextBoxVl id="CacheDays" runat="server" Width="200px">
                        </XS:TextBoxVl>
                    </td>
                </tr>
             
                <tr>
                    <td height="25" width="30%" align="right">
                        回答问题的期限(天) ：
                    </td>
                    <td height="25" width="*" align="left">
                        <XS:TextBoxVl id="AnswerDays" runat="server" Width="200px">
                        </XS:TextBoxVl>
                    </td>
                </tr>
                 <tr>
                    <td height="25" width="30%" align="right">
                        回答一个新问题得相应的分数 ：
                    </td>
                    <td height="25" width="*" align="left">
                        <XS:TextBoxVl id="AnswerScore" runat="server" Width="200px">
                        </XS:TextBoxVl>
                    </td>
                    
                </tr>
             
                 <tr>
                    <td height="25" width="30%" align="right">
                        过期问题扣除相应的分数：
                    </td>
                    <td height="25" width="*" align="left">
                        
                         <XS:TextBoxVl id="OutTimeScore" runat="server" Width="200px">
                        </XS:TextBoxVl>
                    
                    </td>
                    
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">
                        回答问题的最少汉字个数：
                    </td>
                    <td height="25" width="*" align="left">
                        
                         <XS:TextBoxVl id="AskWordCount" runat="server" Width="200px">
                        </XS:TextBoxVl>
                    
                    </td>
                    
                </tr>
                 <tr>
                    <td height="25" width="30%" align="right">
                        收藏的级别的最少积分：
                    </td>
                    <td height="25" width="*" align="left">
                        
                         <XS:TextBoxVl id="FavLevelScore" runat="server" Width="200px">
                        </XS:TextBoxVl>
                    
                    </td>
                    
                </tr>
                  <tr>
                    <td height="25" width="30%" align="right">
                        举报的级别的最少积分：
                    </td>
                    <td height="25" width="*" align="left">
                        
                         <XS:TextBoxVl id="JuBaoScore" runat="server" Width="200px">
                        </XS:TextBoxVl>
                    
                    </td>
                    
                </tr>
                    <tr>
                    <td height="25" width="30%" align="right">
                        追加悬赏分后，可以延长关闭的天数：
                    </td>
                    <td height="25" width="*" align="left">
                        
                         <XS:TextBoxVl id="Days" runat="server" Width="200px">
                        </XS:TextBoxVl>
                    
                    </td>
                    
                </tr>
                  <tr>
                    <td height="25" width="30%" align="right">
                       追加悬赏分的限线：
                    </td>
                    <td height="25" width="*" align="left">
                        
                         <XS:TextBoxVl id="Score" runat="server" Width="200px"  HintInfo="系统会将问题在所在分类的“待解决问题”列表中显示为最新，类似于新提出的问题">
                        </XS:TextBoxVl>
                    
                    </td>
                    
                </tr>
                    <tr>
                    <td height="25" width="30%" align="right">
                       匿名发表 扣除的分数：
                    </td>
                    <td height="25" width="*" align="left">
                        
                         <XS:TextBoxVl id="NiMingScore" runat="server" Width="200px">
                        </XS:TextBoxVl>
                    
                    </td>
                    
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">
                       是否 匿名回答问题：
                    </td>
                    <td height="25" width="*" align="left">
                        
                        <XS:CheckBox ID="NiMingAnswer"  HintInfo="是否允许 匿名回答问题。 打钩是允许匿名。" runat="server" />
                    
                    </td>
                    
                </tr>
                 <tr>
                    <td height="25" width="30%" align="right">
                       是否开启UBB：
                    </td>
                    <td height="25" width="*" align="left">
                        
                        <XS:CheckBox ID="IsUbb"  HintInfo="是否开启UBB。 打钩是开启。" runat="server" />
                    
                    </td>
                    
                </tr>
                 <tr>
                    <td height="25" width="30%" align="right">
                       发帖时间 间隔：
                    </td>
                    <td height="25" width="*" align="left">
                        
                      <XS:TextBoxVl ID="tbTimeJg" runat="server"  ValidateType="匹配正整数" Width="50" ></XS:TextBoxVl>分钟
                    
                    </td>
                    
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <XS:Button ID="bntSave" runat="server" Text="保存配置" />
                       
                    </td>
                </tr>
            </table>
            <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />

        </div>
    </fieldset>
</div>
