<%@ Page Language="C#" MasterPageFile="~/Template/default.master" AutoEventWireup="true"
    CodeFile="page5.aspx.cs" Inherits="page5" %>

<asp:Content ID="ContentLogin" ContentPlaceHolderID="Content" runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <img src="image/frame/top3.jpg" alt="*" width="800" height="10"></td>
        </tr>
        <tr>
            <td height="25">
                <table width="90%" border="0" cellpadding="0" cellspacing="0" class="font1213-1">
                    <tr>
                        <td width="10">
                            <a href="free.aspx" title="中央區域" accesskey="C" class="free_r">:::</a><div
                                align="center">
                            </div>
                        </td>
                        <td width="20">
                            <img src="image/icon/icon2.jpg" alt="*" width="13" height="10"></td>
                        <td class="qLink_font">
                            現在位置：<a href="Default.aspx">首頁</a> &gt;&gt; <a href="page5.aspx">會員登入</a></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="330">
                            <img src="image/frame/sub_title8.jpg" alt="*" width="330" height="55"></td>
                        <td width="431" background="image/frame/sub_2.jpg">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 177px">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="GridView" runat="server">
                        <asp:Login ID="Login1" runat="server" BorderWidth="0px" Width="100%" OnLoggedIn="Login1_LoggedIn"
                            >
                            <LayoutTemplate>
                                <table width="300" border="0" align="center" cellpadding="1" cellspacing="1">
                                    <tr>
                                        <td align="center" style="color: red" colspan="2">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                </table>
                                <table width="300" border="0" align="center" cellpadding="1" cellspacing="1" class="mtable">
                                    <tr>
                                        <td height="30" colspan="2" align="center" bgcolor="#A996AF" class="title2">
                                            <img src="image/icon/page_edit.png" alt="*" width="16" height="16">&nbsp;會 員 登 入</td>
                                    </tr>
                                    <tr>
                                        <td width="137" height="35" align="right" bgcolor="#F1E4EC" class="title2">
                                            <strong>帳 號：</strong></td>
                                        <td width="248" bgcolor="#f1e4ec">
                                            &nbsp;
                                            <asp:TextBox ID="UserName" runat="server" style="width: 120px" ></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                ErrorMessage="必須提供帳號。" ToolTip="必須提供帳號。" ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="137" height="35" align="right" bgcolor="#F9F2F7" class="title2">
                                            <strong>密 碼：</strong></td>
                                        <td  width="248" bgcolor="#f9f2f7">
                                            &nbsp;
                                            <asp:TextBox ID="Password" runat="server" style="width: 120px" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                ErrorMessage="必須提供密碼。" ToolTip="必須提供密碼。" ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center" bgcolor="#A996AF">
                                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="登 入" tabindex= "1"  onkeypress="" ValidationGroup="ctl00$Login1" />
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="PasswordBtn" runat="server" Text="忘記密碼" OnClick="PasswordBtn_Click" onkeypress="" tabindex= "2"/>
                                            <asp:ValidationSummary ID="ValidationSummary4" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" ValidationGroup="ctl00$Login1" />
                                        </td>
                                    </tr>
                                </table>
                            </LayoutTemplate>
                        </asp:Login>
                       
                    </asp:View>
                    <asp:View ID="PasswordView1" runat="server">
                        <table width="300" border="0" align="center" cellpadding="1" cellspacing="1">
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Label ID="msg" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table width="300" border="0" align="center" cellpadding="1" cellspacing="1" class="mtable">
                            <tr>
                                <td height="30" colspan="2" align="center" bgcolor="#A996AF" class="title2">
                                    <img src="image/icon/page_edit.png" alt="*" width="16" height="16">&nbsp;忘 記 密 碼</td>
                            </tr>
                            <tr>
                                <td width="137" height="35" align="right" bgcolor="#f9f2f7" class="title2">
                                    <strong>帳 號：</strong></td>
                                <td width="248" bgcolor="#f9f2f7">
                                    &nbsp;
                                    <asp:TextBox ID="UserName2" runat="server" Columns="15"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName2"
                                        ErrorMessage="必須提供帳號。" ToolTip="必須提供帳號。" ValidationGroup="ValidationGroup1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="color: red" colspan="2">
                                    <asp:Literal ID="MsgText" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" bgcolor="#A996AF">
                                    <asp:Button ID="GetPasswordButton" runat="server" Text="查詢密碼" ValidationGroup="ValidationGroup1" 
                                        OnClick="GetPasswordButton_Click" tabindex= "1" />
                                    <asp:Button ID="BackBtn" runat="server" Text="重新登入" OnClick="BackBtn_Click" tabindex= "2"/>
                                    <asp:ValidationSummary ID="ValidationSummary4" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="ValidationGroup1" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>