<%@ Page Language="C#" MasterPageFile="~/Template/manager.master" AutoEventWireup="true"
    CodeFile="MatchList.aspx.cs" Inherits="Manage_MatchList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <table width="700px" border="0" align="center" cellpadding="4" cellspacing="1">
        <tr>
            <td align="center">
                <p align="center">
                    <b><font face="標楷體" size="5" color="#990000">研發合作對象名單</font></b></p>
            </td>
        </tr>
        <tr>
            <td align="center" class="font1213-1">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="BackBtn_Click">返回主畫面</asp:LinkButton></td>
        </tr>
    </table>
     
    <div align="center">
        <asp:Panel ID="Panel1" runat="server" visile="fasle">
            <asp:Label ID="lblMessage" runat="server" Text="尚無研發合作對象名單" />
        </asp:Panel>
    </div>
    <table width="95%" cellpadding="0" cellspacing="0" border="0" align="center">
        <tr>
            <td align="center" class="font1213-1" width="20%">
                 總筆數：<font color="#FF0000"><b><asp:Label ID="cntTotal" runat="server" /></b></font> 
            </td>
            <td align="center" width="60%">
            <asp:Repeater ID="rptPages" runat="server">
        <HeaderTemplate>
            <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center">
                <tr>
                    <td align="center" class="font1213-1">
                       
            【
        </HeaderTemplate>
        <ItemTemplate>
            <asp:LinkButton ID="btnPage" CommandName="Page" CommandArgument="<%#Container.DataItem %>"
              runat="server"><%# Container.DataItem %>
            </asp:LinkButton>
        </ItemTemplate>
        <FooterTemplate>
            】 </td> </tr> </table>
        </FooterTemplate>
    </asp:Repeater>
            </td>
            <td align="right" class="font1213-1" width="20%">
                 頁次：第 <font color="#0000FF"><b>
                    <asp:Label ID="pageNow" runat="server" /></b></font> 頁 / 共 <font color="#0000FF"><b>
                        <asp:Label ID="pageTotal" runat="server" /></b></font> 頁 
            </td>
        </tr>
    </table>
    
    <br />
    <asp:Repeater ID="MatchGrid" runat="server">
        <HeaderTemplate>
            <table width="95%" border="0" align="center" cellpadding="5" cellspacing="1" class="mtable">
                <tr>
                    <td align="center" bgcolor="#d2aaa2" class="title3">
                        審核通過</td>
                    <td align="center" bgcolor="#d2aaa2" class="title3">
                        刪除名單</td>
                    <td align="center" bgcolor="#d2aaa2" class="title3">
                        序號</td>
                    <td align="center" bgcolor="#d2aaa2" class="title3">
                        學研界/業界</td>
                    <td align="center" bgcolor="#d2aaa2" class="title3">
                        姓名</td>
                    <td align="center" bgcolor="#d2aaa2" class="title3">
                        單位名稱</td>
                    <td align="center" bgcolor="#d2aaa2" class="title3">
                        聯絡電話</td>
                    <td align="center" bgcolor="#d2aaa2" class="title3">
                        廢棄物種類</td>
                    <td align="center" bgcolor="#d2aaa2" class="title3">
                        廢棄物名稱</td>
                    <td align="center" bgcolor="#d2aaa2" class="title3">
                        再生技術名稱</td>    
                    <td align="center" bgcolor="#d2aaa2" class="title3">
                        再生技術方法</td>                    
                    <td align="center" bgcolor="#d2aaa2" class="title3">
                        再生產品名稱</td>
                     <td align="center" bgcolor="#d2aaa2" class="title3">
                        刪除日期</td>    
                    <td align="center" bgcolor="#d2aaa2" class="title3">
                        系統配對日期</td>
                    <td align="center" bgcolor="#d2aaa2" class="title3">
                        審核通過日期</td>
                    <td align="center" bgcolor="#d2aaa2" class="title3">
                        媒合意願</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td rowspan="2" align="center" bgcolor="#f1e4ec" class="font1213-1">
                    <div align="center">
                        <asp:CheckBox ID="PassCheckBox" runat="server" Checked='<%#(Eval("Ischecked").ToString().Equals("Y"))? true:false%>'
                            Visible='<%#(Eval("Ischecked").ToString().Equals("Y"))? false:true%>' ToolTip='<%#Eval("Id")%>' />
                        <asp:Label ID="Pass1" runat="server" Text="Y" Visible='<%#(Eval("Ischecked").ToString().Equals("Y"))? true:false%>'>
                        </asp:Label>
                    </div>
                </td>
                <td rowspan="2" align="center" bgcolor="#f1e4ec" class="font1213-1">
                    <div align="center">
                        <asp:CheckBox ID="DropCheckBox" runat="server" ToolTip='<%#Eval("Id")%>' />
                    </div>
                </td>
                <td rowspan="2" bgcolor="#f1e4ec" class="font1213-1">
                    <div align="center">
                        <%# Container.ItemIndex + 1%>
                    </div>
                </td>
                <td bgcolor="#f1e4ec" class="font1213-1">
                    學研機構</td>
                <td bgcolor="#f1e4ec" class="font1213-1">
                    <a href='ProfileView1.aspx?username=<%#Eval("Username1")%>' target="_blank">
                        <%# Eval("Name1")  %>
                </td>
                <td bgcolor="#f1e4ec" class="font1213-1">
                    <asp:Label ID="Corp1" runat="server" Text='<%# Eval("Corp1")  %>'>
                    </asp:Label></td>
                <td bgcolor="#f1e4ec" class="font1213-1">
                    <asp:Label ID="Tel1" runat="server" Text='<%# Eval("Tel1")  %>'>
                    </asp:Label></td>
                <td bgcolor="#f1e4ec" class="font1213-1">
                    <asp:Label ID="Wasteitem1" runat="server" Text='<%# Eval("Wasteitem1")  %>'>
                    </asp:Label></td>
                <td bgcolor="#f1e4ec" class="font1213-1">
                    <asp:Label ID="Wastename1" runat="server" Text='<%# Eval("Wastename1")  %>'>
                    </asp:Label></td>
                <td bgcolor="#f1e4ec" class="font1213-1">
                <a href='TechView.aspx?id=<%#Eval("Rid1")%>' target="_blank">
                        <%# Eval("Techname1")%>
                     </td>    
                <td bgcolor="#f1e4ec" class="font1213-1">
                    <asp:Label ID="Techitem1" runat="server" Text='<%# Eval("Techitem1")  %>'>
                    </asp:Label></td>                
                <td bgcolor="#f1e4ec" class="font1213-1">
                    <asp:Label ID="Reusename1" runat="server" Text='<%# Eval("Reusename1")  %>'>
                    </asp:Label></td>
                <td bgcolor="#f1e4ec" class="font1213-1">
                    <asp:Label ID="Deletedate1" runat="server" Text='<%#((bool)Eval("Isdeleted1"))?Eval("Deletedate1", "{0:yyyyMMdd}") : ""%>'>
                    </asp:Label></td>    
                    
                <td rowspan="2" bgcolor="#f1e4ec" class="font1213-1">
                    <div align="center">
                        <asp:Label ID="Matchdate" runat="server" Text='<%# Eval("Matchdate", "{0:yyyyMMdd}")%>'>
                        </asp:Label></div>
                </td>
                <td rowspan="2" bgcolor="#f1e4ec" class="font1213-1">
                    <div align="center">
                        <asp:Label ID="Approveddate" runat="server" Text='<%#(Eval("Ischecked").ToString().Equals("A"))?"": Eval("Approveddate", "{0:yyyyMMdd}")%>'>
                        </asp:Label></div>
                </td>
                <td bgcolor="#f1e4ec" class="font1213-1" align="center">
                    <asp:Label ID="Isconfirm1" runat="server" Text='<%#(Eval("Isconfirm1").ToString().Equals("A"))?"": Eval("Isconfirm1")%>'>
                    </asp:Label>
                    <asp:Label ID="Confirmdate1" runat="server" Text='<%#(Eval("Isconfirm1").ToString().Equals("A"))?"": "("+Eval("Confirmdate1", "{0:yyyyMMdd}")+")"%>'>
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="#f9f2f7" class="font1213-1">
                    業者廠商</td>
                <td bgcolor="#f9f2f7" class="font1213-1">
                    <a href='ProfileView2.aspx?username=<%#Eval("Username2")%>' target="_blank">
                        <%# Eval("Name2")  %>
                    </a>
                </td>
                <td bgcolor="#f9f2f7" class="font1213-1">
                    <asp:Label ID="Corp2" runat="server" Text='<%# Eval("Corp2")  %>'>
                    </asp:Label></td>
                <td bgcolor="#f9f2f7" class="font1213-1">
                    <asp:Label ID="Tel2" runat="server" Text='<%# Eval("Tel2")  %>'>
                    </asp:Label></td>
                <td bgcolor="#f9f2f7" class="font1213-1">
                    <asp:Label ID="Wasteitem2" runat="server" Text='<%# Eval("Wasteitem2")  %>'>
                    </asp:Label></td>
                <td bgcolor="#f9f2f7" class="font1213-1">
                    <asp:Label ID="Wastename2" runat="server" Text='<%# Eval("Wastename2")  %>'>
                    </asp:Label></td>
                <td bgcolor="#f9f2f7" class="font1213-1">
                    <asp:Label ID="Techitem2" runat="server" Text='<%# Eval("Techname2")  %>'>
                    </asp:Label></td>
                <td bgcolor="#f9f2f7" class="font1213-1">
                    <asp:Label ID="Techname2" runat="server" Text='<%# Eval("Techitem2")  %>'>
                    </asp:Label></td>
                <td bgcolor="#f9f2f7" class="font1213-1">
                    <asp:Label ID="Reusename2" runat="server" Text='<%# Eval("Reusename2")  %>'>
                    </asp:Label></td>
                <td bgcolor="#f1e4ec" class="font1213-1">
                    <asp:Label ID="Deletedate2" runat="server" Text='<%#((bool)Eval("Isdeleted2"))? Eval("Deletedate2", "{0:yyyyMMdd}") : "" %>'>
                    </asp:Label></td>    
                <td bgcolor="#f9f2f7" class="font1213-1" align="center">
                    <asp:Label ID="Isconfirm2" runat="server" Text='<%#(Eval("Isconfirm2").ToString().Equals("A"))?"": Eval("Isconfirm2")%>'>
                    </asp:Label>
                    <asp:Label ID="Confirmdate2" runat="server" Text='<%#(Eval("Isconfirm2").ToString().Equals("A"))?"": "("+Eval("Confirmdate2", "{0:yyyyMMdd}"+")")%>'>
                    </asp:Label></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
            <table width="100%" border="0">
                <tr>
                    <td style="text-align: center">
                        <br />
                        <asp:Button ID="SaveBtn" runat="server" Text="確定修改" OnClick="SaveBtn_Click" />
                    </td>
                </tr>
            </table>
        </FooterTemplate>
    </asp:Repeater>
<br />    
</asp:Content>
