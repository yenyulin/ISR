<%@ Page Language="C#" MasterPageFile="~/Template/manager.master" AutoEventWireup="true"
    CodeFile="MemberList.aspx.cs" Inherits="Manage_MemberList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <table width="700px" border="0" align="center" cellpadding="4" cellspacing="1">
        <tr>
            <td align="center">
                <p align="center">
                    <b><font face="標楷體" size="5" color="#990000">會員資料維護</font></b></p>
            </td>
        </tr>
        <tr>
            <td align="center" class="font1213-1">
                <img src="../image/icon/arrow.gif" width="16" alt="項目" /><asp:LinkButton ID="BackBtn"
                    runat="server" OnClick="BackBtn_Click">返回主畫面</asp:LinkButton>
                &nbsp;&nbsp;<img src="../image/icon/blueball.gif" width="16" alt="項目" /><a href="MemberAppend1.aspx">新增學研機構會員</a>
                &nbsp;&nbsp;<img src="../image/icon/blueball.gif" width="16" alt="項目" /><a href="MemberAppend2.aspx">新增業者廠商會員</a>
                &nbsp;&nbsp;<img src="../image/icon/blueball.gif" width="16" alt="項目" /><a href="MemberQuery.aspx">查詢會員</a>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr>
            </td>
        </tr>
    </table>
    <table width="95%" border="0" align="center" cellpadding="4" cellspacing="1">
        <tr>
            <td align="center" class="font1213-1">
                顯示方式：【
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton6_Click">全部會員資料</asp:LinkButton>
                ｜                
                <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">學研機構會員資料</asp:LinkButton>
                ｜
                <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click">業者廠商會員資料</asp:LinkButton>
                】
            </td>
        </tr>
        <tr>
            <td align="center" class="font1213-1">
                排序方式：【
                <asp:LinkButton ID="SortBtn1" runat="server" OnClick="SortBtn1_Click">編號</asp:LinkButton>
                ｜
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">已核准名單</asp:LinkButton>
                ｜
                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">尚未核准名單</asp:LinkButton>
                】
            </td>
        </tr>
        <tr>
            <td align="center">
                <div align="center" class="title2">
                    會員總數：<asp:Label ID="cnt" runat="server" ForeColor="red"> </asp:Label>
                </div>
            </td>
        </tr>
    </table>
    <table width="95%" border="0" align="center" cellpadding="5" cellspacing="1">
        <tr>
            <td>
                <asp:Panel ID="Panel3" runat="server" visile="true">
                    <div align="center">
                        <asp:Panel ID="Panel1" runat="server" visile="fasle">
                            <asp:Label ID="lblMessage" runat="server" Text="尚無學研機構資料" />
                        </asp:Panel>
                    </div>
                    <table width="600px" cellpadding="0" cellspacing="0" border="0" align="center">
                        <tr>
                            <td align="center" class="font1213-1" width="35%">
                                學研機構筆數：<font color="#FF0000"><b><asp:Label ID="cntTotal" runat="server" /></b></font>
                            </td>
                            <td align="center" width="30%">
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
                            <td align="right" class="font1213-1" width="35%">
                                頁次：第 <font color="#0000FF"><b>
                                    <asp:Label ID="pageNow" runat="server" /></b></font> 頁 / 共 <font color="#0000FF"><b>
                                        <asp:Label ID="pageTotal" runat="server" /></b></font> 頁
                            </td>
                        </tr>
                    </table>
                    <asp:Repeater ID="MemberGrid1" runat="server">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellpadding="1" cellspacing="1" class="mtable">
                                <tr>
                                    <td width="9%" align="center" bgcolor="#d2aaa2" class="title3">
                                        學研機構</td>
                                    <td width="6%" align="center" bgcolor="#d2aaa2" class="title3">
                                        序號</td>
                                    <td width="8%" align="center" bgcolor="#d2aaa2" class="title3">
                                        帳號/密碼</td>
                                    <td width="9%" align="center" bgcolor="#d2aaa2" class="title3">
                                        姓名</td>
                                    <td width="13%" align="center" bgcolor="#d2aaa2" class="title3">
                                        學校系所/研究單位名稱</td>
                                    <td width="9%" align="center" bgcolor="#d2aaa2" class="title3">
                                        單位屬性</td>
                                    <td width="9%" align="center" bgcolor="#d2aaa2" class="title3">
                                        聯絡電話</td>
                                    <td width="16%" align="center" bgcolor="#d2aaa2" class="title3">
                                        地址</td>
                                    <td width="6%" align="center" bgcolor="#d2aaa2" class="title3">
                                        e-mail</td>
                                    <td width="9%" align="center" bgcolor="#d2aaa2" class="title3">
                                        註冊日期</td>
                                    <td width="6%" align="center" bgcolor="#d2aaa2" class="title3">
                                        啟用與否</td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td align="center" bgcolor="#f1e4ec" class="font1213-1">
                                    <a href='Profile1.aspx?username=<%#Eval("Username")%>' target="_blank">【修 改】 </a>
                                    <br />
                                    <asp:LinkButton ID="DropBtn1" runat="server" OnCommand="DropBtn1_Command" CommandArgument='<%#Eval("Username")%>'
                                        OnClientClick="return confirm('確定刪除資料?');">【刪 除】</asp:LinkButton>
                                </td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <div align="center">
                                        <%# Container.ItemIndex + 1%>
                                    </div>
                                </td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <asp:Label ID="Username1" runat="server" Text='<%# Eval("Username")  %>'>
                                    </asp:Label>
                                    <br />
                                    (<asp:Label ID="Pwd1" runat="server" Text='<%# Eval("Pwd")  %>'>
                                    </asp:Label>)</td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <a href='ProfileView1.aspx?username=<%#Eval("Username")%>' target="_blank">
                                        <%# Eval("Name")  %>
                                    </a>
                                </td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <asp:Label ID="Corp1" runat="server" Text='<%# Eval("Corp")  %>'>
                                    </asp:Label></td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <asp:Label ID="Kind1" runat="server" Text='<%# Eval("Kind")  %>'>
                                    </asp:Label></td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <asp:Label ID="Tel1" runat="server" Text='<%# Eval("Tel")  %>'>
                                    </asp:Label></td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <asp:Label ID="Address1" runat="server" Text='<%# Eval("Address")  %>'>
                                    </asp:Label></td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <asp:Label ID="Email1" runat="server" Text='<%# Eval("Email")  %>'>
                                    </asp:Label></td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <asp:Label ID="CreateDate1" runat="server" Text='<%# Eval("CreateDate", "{0:yyyyMMdd}")%>  '>
                                    </asp:Label></td>
                                <td bgcolor="#f1e4ec" class="font1213-1" align="center">
                                    <asp:Label ID="IsApproved1" runat="server" Text='<%# (Boolean.Parse(Eval("IsApproved").ToString())) ? "Y" : "N" %>'>
                                    </asp:Label></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <br />
                </asp:Panel>
                <asp:Panel ID="Panel4" runat="server" visile="true">
                    <div align="center">
                        <asp:Panel ID="Panel2" runat="server" visile="fasle">
                            <asp:Label ID="Label2" runat="server" Text="尚無業者廠商資料" />
                        </asp:Panel>
                    </div>
                    <table width="600px" cellpadding="0" cellspacing="0" border="0" align="center">
                        <tr>
                            <td align="center" class="font1213-1" width="35%">
                                業者廠商筆數：<font color="#FF0000"><b><asp:Label ID="cntTotal2" runat="server" /></b></font>
                            </td>
                            <td align="center" width="30%">
                                <asp:Repeater ID="rptPages2" runat="server">
                                    <HeaderTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center">
                                            <tr>
                                                <td align="center" class="font1213-1">
                                        【
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnPage2" CommandName="Page" CommandArgument="<%#Container.DataItem %>"
                                            runat="server"><%# Container.DataItem %>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        】 </td> </tr> </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </td>
                            <td align="right" class="font1213-1" width="35%">
                                頁次：第 <font color="#0000FF"><b>
                                    <asp:Label ID="pageNow2" runat="server" /></b></font> 頁 / 共 <font color="#0000FF"><b>
                                        <asp:Label ID="pageTotal2" runat="server" /></b></font> 頁
                            </td>
                        </tr>
                    </table>
                    <asp:Repeater ID="MemberGrid2" runat="server">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellpadding="1" cellspacing="1" class="mtable">
                                <tr>
                                    <td width="9%" align="center" bgcolor="#d2aaa2" class="title3">
                                        學研機構</td>
                                    <td width="6%" align="center" bgcolor="#d2aaa2" class="title3">
                                        序號</td>
                                    <td width="8%" align="center" bgcolor="#d2aaa2" class="title3">
                                        帳號/密碼</td>
                                    <td width="9%" align="center" bgcolor="#d2aaa2" class="title3">
                                        姓名</td>
                                    <td width="13%" align="center" bgcolor="#d2aaa2" class="title3">
                                        學校系所/研究單位名稱</td>
                                    <td width="9%" align="center" bgcolor="#d2aaa2" class="title3">
                                        單位屬性</td>
                                    <td width="9%" align="center" bgcolor="#d2aaa2" class="title3">
                                        聯絡電話</td>
                                    <td width="16%" align="center" bgcolor="#d2aaa2" class="title3">
                                        地址</td>
                                    <td width="6%" align="center" bgcolor="#d2aaa2" class="title3">
                                        e-mail</td>
                                    <td width="9%" align="center" bgcolor="#d2aaa2" class="title3">
                                        註冊日期</td>
                                    <td width="6%" align="center" bgcolor="#d2aaa2" class="title3">
                                        啟用與否</td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td align="center" bgcolor="#f1e4ec" class="font1213-1">
                                    <a href='Profile2.aspx?username=<%#Eval("Username")%>' target="_blank">【修 改】 </a>
                                    <br />
                                    <asp:LinkButton ID="DropBtn2" runat="server" OnCommand="DropBtn2_Command" CommandArgument='<%#Eval("Username")%>'
                                        OnClientClick="return confirm('確定刪除資料?');">【刪 除】</asp:LinkButton>
                                </td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <div align="center">
                                        <%# Container.ItemIndex + 1%>
                                    </div>
                                </td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <asp:Label ID="Username2" runat="server" Text='<%# Eval("Username")  %>'>
                                    </asp:Label>
                                    <br />
                                    (<asp:Label ID="Pwd2" runat="server" Text='<%# Eval("Pwd")  %>'>
                                    </asp:Label>)</td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <a href='ProfileView2.aspx?username=<%#Eval("Username")%>' target="_blank">
                                        <%# Eval("Name")  %>
                                    </a>
                                </td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <asp:Label ID="Corp2" runat="server" Text='<%# Eval("Corp")  %>'>
                                    </asp:Label></td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <asp:Label ID="Kind2" runat="server" Text='<%# Eval("Kind")  %>'>
                                    </asp:Label></td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <asp:Label ID="Tel2" runat="server" Text='<%# Eval("Tel")  %>'>
                                    </asp:Label></td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <asp:Label ID="Address2" runat="server" Text='<%# Eval("Address")  %>'>
                                    </asp:Label></td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <asp:Label ID="Email2" runat="server" Text='<%# Eval("Email")  %>'>
                                    </asp:Label></td>
                                <td bgcolor="#f1e4ec" class="font1213-1">
                                    <asp:Label ID="CreateDate2" runat="server" Text='<%# Eval("CreateDate", "{0:yyyyMMdd}")%>  '>
                                    </asp:Label></td>
                                <td bgcolor="#f1e4ec" class="font1213-1" align="center">
                                    <asp:Label ID="IsApproved2" runat="server" Text='<%# (Boolean.Parse(Eval("IsApproved").ToString())) ? "Y" : "N" %>'>
                                    </asp:Label></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <br />
                </asp:Panel>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="type1" runat="server" />
     
</asp:Content>
