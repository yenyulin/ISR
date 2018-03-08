<%@ Page Language="C#" MasterPageFile="~/Template/manager.master" AutoEventWireup="true"
    CodeFile="ApproveList.aspx.cs" Inherits="Manage_ApproveList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <table width="700px" border="0" align="center" cellpadding="4" cellspacing="1">
        <tr>
            <td align="center">
                <p align="center">
                    <b><font face="標楷體" size="5" color="#990000">審核會員申請資料</font></b></p>
            </td>
        </tr>
        <tr>
            <td align="center">
                <p align="center">
                    <b><font size="4" color="#990099">
                        <asp:Label ID="Msg" runat="server">
                        </asp:Label></font></b></p>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <br />
                <asp:Button ID="BackBtn" runat="server" Text="返回主畫面" OnClick="BackBtn_Click" />
                <asp:Button ID="ShowBtn2" runat="server" Text="顯示全部資料" OnClick="ShowBtn2_Click" />
                <asp:Button ID="ShowBtn1" runat="server" Text="顯示未審資料" OnClick="ShowBtn1_Click" />
                <font size="2" color="#6600FF">篩選單位名稱：
                    <asp:TextBox ID="qryText" runat="server" Columns="10"></asp:TextBox><font color="#FF00FF">(關鍵字)</font>
                    <asp:Button ID="SaveBtn" runat="server" Text="通過" OnClick="SaveBtn_Click" />
                    <asp:Button ID="DropBtn" runat="server" Text="駁回" OnClick="DropBtn_Click" OnClientClick="return confirm('確定刪除資料?');" />
            </td>
        </tr>
    </table>
    <br />
    <table width="80%" border="1" cellpadding="5" cellspacing="1" align="center" >
        <tr align="center" bgcolor="#003366">
            <td colspan="2">
                <font color="#FFFF00"><b>設定使用權限 <font color="#FF99FF">(點選名稱可查看詳細資料)</font><br>
                    <font color="#CCFFFF">＃ 審核通過後，本系統將馬上發送電子郵件通知啟用。 ＃</font></b></font>
            </td>
        </tr>
        <tr bgcolor="#CCFFFF" align="center">
            <td width="200">
                <font size="2"><font color="#000099">《<font color="#0000FF"><b><asp:LinkButton ID="SelectBtn" runat="server" 
                                    OnClick="SelectBtn_Click">全選</asp:LinkButton></b></font> 》<br>
                    《共 <font color="#ff0000">
                        <asp:Label ID="cnt" runat="server" ForeColor="red"> </asp:Label></font> 筆》</font></font>
                        <asp:HiddenField ID="selectState"  Value="N" runat="server"/>
            </td>
            <td  >
                <font size="2"><font color="#000099">審核通知信加註說明：</font>
                    <asp:TextBox ID="addText" runat="server" Columns="35" MaxLength="50"></asp:TextBox>           
                    <font color="#000099">(上限50個字)</font><br>
            </td>
        </tr>
    </table>
    <table width="95%" border="0" align="center" cellpadding="5" cellspacing="1">
        <tr>
            <td>
                <asp:Repeater ID="ApproveGrid" runat="server">
                    <HeaderTemplate>
                        <table width="100%" border="0" align="center" cellpadding="5" cellspacing="1" class="mtable">
                            <tr>
                                <td width="10%" align="center" bgcolor="#d2aaa2" class="title3">
                                    通過審核?</td>
                                <td width="10%" align="center" bgcolor="#d2aaa2" class="title3">
                                    帳號</td>
                                <td width="20%" align="center" bgcolor="#d2aaa2" class="title3">
                                    姓名</td>
                                <td width="30%" align="center" bgcolor="#d2aaa2" class="title3">
                                    單位名稱</td>
                                <td width="20%" align="center" bgcolor="#d2aaa2" class="title3">
                                    連絡電話</td>
                                <td width="10%" align="center" bgcolor="#d2aaa2" class="title3">
                                    E-Mail</td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="center" bgcolor="#f1e4ec" class="font1213-1">
                                <asp:CheckBox ID="PassCheckBox" runat="server" ToolTip='<%#Eval("Username")%>' Checked='<%#(Boolean.Parse(Eval("IsApproved").ToString()))? true:false%>' />
                            </td>
                            <td bgcolor="#f1e4ec" class="font1213-1">
                                <a href='ProfileView<%#Eval("Type")%>.aspx?username=<%#Eval("Username")%>' target="_blank">
                                    <%# Eval("Username")%>
                                </a>
                            </td>
                            <td bgcolor="#f1e4ec" class="font1213-1">
                                <asp:Label ID="Name1" runat="server" Text='<%# Eval("Name")  %>'>
                                </asp:Label>
                            </td>
                            <td bgcolor="#f1e4ec" class="font1213-1">
                                <asp:Label ID="Corp1" runat="server" Text='<%# Eval("Corp")  %>'>
                                </asp:Label>
                            </td>
                            <td bgcolor="#f1e4ec" class="font1213-1">
                                <asp:Label ID="Tel1" runat="server" Text='<%# Eval("Tel")  %>'>
                                </asp:Label>
                            </td>
                            <td bgcolor="#f1e4ec" class="font1213-1">
                                <asp:Label ID="Email1" runat="server" Text='<%# Eval("Email")  %>'>
                                </asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
