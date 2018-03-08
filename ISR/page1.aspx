<%@ Page Language="C#" MasterPageFile="~/Template/default.master" AutoEventWireup="true"
    CodeFile="page1.aspx.cs" Inherits="News" %>

<asp:Content ID="ContentNews" ContentPlaceHolderID="Content" runat="Server">
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
                            <a href="free.aspx" title="中央區域" accesskey="C" class="free_r">:::</a><div align="center">
                            </div>
                        </td>
                        <td width="20">
                            <img src="image/icon/icon2.jpg" alt="*" width="13" height="10"></td>
                        <td class="qLink_font">
                            現在位置：<a href="Default.aspx">首頁</a> &gt;&gt; <a href="page1.aspx">最新消息</a></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="330">
                            <img src="image/frame/sub_title1.jpg" alt="*" width="330" height="55"></td>
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
            <td align="center">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="GridView" runat="server">
                        <asp:GridView ID="NewsGrid" runat="server" Width="90%" AutoGenerateColumns="False"
                            AllowPaging="true" CellPadding="4" ForeColor="#333333" GridLines="Both" BorderStyle="Double"
                            BorderColor="#663366" BorderWidth="1" OnPageIndexChanging="NewsGrid_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="序號" ShowHeader="False">
                                    <ItemTemplate>
                                        <div align="center">
                                            <%# Container.DataItemIndex + 1 %>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Width="6%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="主題">
                                    <ItemTemplate>
                                        <div align="left">
                                            <a href='page1.aspx?id=<%#Eval("Id")%>'>
                                                <%# Eval("Title")%>
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Width="81%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="公佈日期">
                                    <ItemTemplate>
                                        <asp:Label ID="Showdate" runat="server" Text='<%# Eval("Showdate", "{0:yyyyMMdd}")%>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="13%" />
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle BackColor="#F1E4EC" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#A996AF" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#A996AF" ForeColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <AlternatingRowStyle BackColor="#F9F2F7" />
                        </asp:GridView>
                    </asp:View>
                    <asp:View ID="EditView" runat="server">
                        <asp:DataList ID="NewsList" runat="server">
                            <ItemTemplate>
                                <table width="95%" height="37" border="0" align="center" cellpadding="8" cellspacing="1"
                                    bgcolor="#666600" class="mtable">
                                    <form action="" method="post" name="form1" id="form2">
                                        <tr bgcolor="#A2CAD2" height="57">
                                            <td height="30" colspan="2" bgcolor="#d2aaa2" class="font1213-1">
                                                <span class="title2">最新消息</span></td>
                                        </tr>
                                        <tr bgcolor="#E4F1E9">
                                            <td width="162" bgcolor="#f1e4ec" class="table_title1" align="left">
                                                訊息標題</td>
                                            <td width="555" bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                <asp:Label ID="Title1" runat="server" Text='<%# Bind("Title") %>'> </asp:Label>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#F2F9F4">
                                            <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                                訊息日期</td>
                                            <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                                <asp:Label ID="Showdate1" runat="server" Text='<%# Eval("Showdate", "{0:yyyyMMdd}")%>'> </asp:Label>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#E4F1E9">
                                            <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                                新聞摘要
                                            </td>
                                            <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                <asp:Label ID="Summary" runat="server" Text='<%# Bind("Summary") %>'> </asp:Label>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#E4F1E9">
                                            <td bgcolor="#F9F2F7" class="table_title1" align="left">
                                                相關連接
                                            </td>
                                            <td bgcolor="#F9F2F7" class="font1213-1" align="left">
                                                <a href='<%#Eval("Link")%>' target="_blank">
                                                    <%# Eval("Link")%>
                                                </a>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#E4F1E9">
                                            <td colspan="2" align="center" bgcolor="#F1E4EC" class="table_title1">
                                                <label>
                                                    <asp:Button ID="ExitBtn2" runat="server" Text="回查詢頁" OnClick="ExitBtn_Click" />
                                                </label>
                                            </td>
                                        </tr>
                                    </form>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>
