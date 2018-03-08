<%@ Page Language="C#" MasterPageFile="~/Template/default.master" AutoEventWireup="true"
    CodeFile="page8.aspx.cs" Inherits="page8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
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
                            現在位置：<a href="Default.aspx">首頁</a> &gt;&gt; <a href="page8.aspx">媒合成果</a></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="330">
                            <img src="image/frame/sub_title10.jpg" alt="*" width="330" height="55"></td>
                        <td width="431" background="image/frame/sub_2.jpg">
                            <table width="375" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="28%">
                                        <div align="center">
                                        </div>
                                    </td>
                                    <td width="9%">
                                        <div align="center">
                                            <img src="image/icon/arrow.gif" alt="*" width="19" height="20"></div>
                                    </td>
                                    <td width="63%" class="table_title1">
                                        <div align="right" class="subfunction_font">
                                            <div align="left">
                                                |
                                                <asp:LinkButton ID="Btn97" runat="server" CommandArgument="97" OnCommand="Btn_Command">97</asp:LinkButton>
                                                |
                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument="96" OnCommand="Btn_Command">96</asp:LinkButton>
                                                |
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <asp:Repeater ID="ExpGrid" runat="server">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center" class="title2">
                        <asp:Label ID="Year1" runat="server" Text='<%# Eval("Year")  %>'></asp:Label>年</td>
                </tr>
                <tr>
                    <td align="center">
                        <table width="95%" border="0" cellpadding="1" cellspacing="1" class="mtable">
                            <tr>
                                <td width="84" align="center" bgcolor="#A996AF" class="form_title1">
                                    業者廠商
                                </td>
                                <td bgcolor="#f1e4ec" style="width: 45%">
                                    <asp:Label ID="Name1A" runat="server" Text='<%# Eval("Name1A")  %>'></asp:Label></td>
                                <td bgcolor="#f9f2f7" style="width: 45%">
                                    <asp:Label ID="Name2A" runat="server" Text='<%# Eval("Name2A")  %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td width="84" align="center" bgcolor="#A996AF" class="form_title1">
                                    學研機構
                                </td>
                                <td bgcolor="#f1e4ec">
                                    <asp:Label ID="Name1B" runat="server" Text='<%# Eval("Name1B")  %>'></asp:Label></td>
                                <td bgcolor="#f9f2f7">
                                    <asp:Label ID="Name2B" runat="server" Text='<%# Eval("Name2B")  %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td width="84" align="center" bgcolor="#A996AF" class="form_title1">
                                    計畫名稱
                                </td>
                                <td bgcolor="#f1e4ec">
                                    <asp:Label ID="Title1" runat="server" Text='<%# Eval("Title1")  %>'></asp:Label></td>
                                <td bgcolor="#f9f2f7">
                                    <asp:Label ID="Title2" runat="server" Text='<%# Eval("Title2")  %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td width="84" align="center" bgcolor="#A996AF" class="form_title1">
                                    申請計畫
                                </td>
                                <td bgcolor="#f1e4ec">
                                    <asp:Label ID="Project1" runat="server" Text='<%# Eval("Project1")  %>'></asp:Label></td>
                                <td bgcolor="#f9f2f7">
                                    <asp:Label ID="Project2" runat="server" Text='<%# Eval("Project2")  %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td width="84" align="center" bgcolor="#A996AF" class="form_title1">
                                    申請金額
                                </td>
                                <td bgcolor="#f1e4ec">
                                    <asp:Label ID="Amt1" runat="server" Text='<%# Eval("Amt1")  %>'></asp:Label></td>
                                <td bgcolor="#f9f2f7">
                                    <asp:Label ID="Amt2" runat="server" Text='<%# Eval("Amt2")  %>'></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        &nbsp;</td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>
    </table>
</asp:Content>

