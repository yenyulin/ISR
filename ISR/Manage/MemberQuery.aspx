<%@ Page Language="C#" MasterPageFile="~/Template/manager.master" AutoEventWireup="true"
    CodeFile="MemberQuery.aspx.cs" Inherits="Manage_MemberQuery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <table width="700px" border="0" align="center" cellpadding="4" cellspacing="1">
        <tr>
            <td align="center">
                <p align="center">
                    <b><font face="標楷體" size="5" color="#990000">查詢會員資料</font></b></p>
            </td>
        </tr>
    </table>
    <table width="700" border="0" cellpadding="3" cellspacing="0" align="center">
        <tr>
            <td width="700" colspan="4" align="center">
                <font size="2" color="#330099">查詢條件：(可以同時輸入一項或是多項查詢條件)</font></td>
        </tr>
        <tr>
            <td width="125" align="center" bgcolor="#3366CC">
                <font size="2" color="#FFCC00">帳號</font></td>
            <td width="225" bgcolor="#99CCCC">
                <asp:TextBox ID="a1" runat="server" Columns="10" /></td>
            <td width="125" align="center" bgcolor="#3366CC">
                <font size="2" color="#FFCC00">姓名<font color="#CCFF66">(關鍵字)</font></font></td>
            <td width="225" bgcolor="#99CCCC">
                <asp:TextBox ID="a2" runat="server" Columns="10" /></td>
        </tr>
        <tr>
            <td width="125" align="center" bgcolor="#3366CC">
                <font size="2" color="#FFCC00">單位名稱<font color="#CCFF66">(關鍵字)</font></font></td>
            <td width="225" bgcolor="#99CCCC">
                <asp:TextBox ID="a3" runat="server" Columns="10" /></td>
            <td width="125" align="center" bgcolor="#3366CC">
                <font size="2" color="#FFCC00">地址<font color="#CCFF66">(關鍵字)</font></font></td>
            <td width="225" bgcolor="#99CCCC">
                <asp:TextBox ID="a4" runat="server" Columns="10" /></td>
        </tr>
        <tr>
            <td width="125" align="center" bgcolor="#3366CC">
                <font size="2" color="#FFCC00">單位屬性</font></td>
            <td width="225" bgcolor="#99CCCC">
                <asp:DropDownList ID="a5" runat="server">
                    <asp:ListItem Value="Z">請選擇...</asp:ListItem>
                    <asp:ListItem Value="A">學術單位</asp:ListItem>
                    <asp:ListItem Value="B">研究單位</asp:ListItem>
                    <asp:ListItem Value="H">學研機構-其他</asp:ListItem>
                    <asp:ListItem Value="C">公民營處(清)理機構</asp:ListItem>
                    <asp:ListItem Value="D">許可再利用機構</asp:ListItem>
                    <asp:ListItem Value="E">公告再利用機構</asp:ListItem>
                    <asp:ListItem Value="F">應回收廢棄物處理機構</asp:ListItem>
                    <asp:ListItem Value="G">>業者廠商-其他</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td width="125" align="center" bgcolor="#3366CC">
                <font size="2" color="#FFCC00">負責人</font></td>
            <td width="225" bgcolor="#99CCCC">
                <asp:TextBox ID="a6" runat="server" Columns="10" /></td>
        </tr>
        <tr>
            <td width="700" colspan="4" align="center">
                <asp:Button ID="QryBtn" runat="server" Text="開始查詢" OnClick="QryBtn_Click" />
            </td>
        </tr>
        <tr>
            <td width="700" colspan="4" align="center">
                <asp:Button ID="BackBtn" runat="server" Text="回前畫面" OnClick="BackBtn_Click" />
            </td>
        </tr>
    </table>
    <table width="700" border="0" align="center"><tr><td width="700"><hr></td></tr></table>
    <table width="95%" border="0" align="center" cellpadding="5" cellspacing="1">
        <tr>
            <td>
                <asp:GridView ID="MemberGrid1" runat="server" Width="100%" AllowPaging="False" AutoGenerateColumns="False"
                    CellPadding="4" ForeColor="#333333" Font-Size="12px" BorderStyle="Double" BorderColor="#663366"
                    BorderWidth="1px">
                    <Columns>
                        <asp:TemplateField HeaderText="學研機構" ShowHeader="False">
                            <ItemTemplate>
                                <a href='Profile1.aspx?username=<%#Eval("Username")%>' target="_blank">【修改會員資料】 </a>
                                <br />
                                <asp:LinkButton ID="DropBtn1" runat="server" OnCommand="DropBtn1_Command" CommandArgument='<%#Eval("Username")%>'
                                    OnClientClick="return confirm('確定刪除資料?');">【刪除會員資料】</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="序號">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="3%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="帳號/密碼">
                            <ItemTemplate>
                                <asp:Label ID="Username1" runat="server" Text='<%# Eval("Username")  %>'>
                                </asp:Label>
                                <br />
                                (<asp:Label ID="Pwd1" runat="server" Text='<%# Eval("Pwd")  %>'>
                                </asp:Label>)
                            </ItemTemplate>
                            <ItemStyle Width="8%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="姓名">
                            <ItemTemplate>
                                <a href='ProfileView1.aspx?username=<%#Eval("Username")%>' target="_blank">
                                    <%# Eval("Name")  %>
                                </a>
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="學校系所/研究單位名稱">
                            <ItemTemplate>
                                <asp:Label ID="Corp1" runat="server" Text='<%# Eval("Corp")  %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單位屬性">
                            <ItemTemplate>
                                <asp:Label ID="Kind1" runat="server" Text='<%# Eval("Kind")  %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="9%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="聯絡電話">
                            <ItemTemplate>
                                <asp:Label ID="Tel1" runat="server" Text='<%# Eval("Tel")  %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="9%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="地址">
                            <ItemTemplate>
                                <asp:Label ID="Address1" runat="server" Text='<%# Eval("Address")  %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="25%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="E-mail">
                            <ItemTemplate>
                                <asp:Label ID="Email1" runat="server" Text='<%# Eval("Email")  %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="7%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="註冊日期">
                            <ItemTemplate>
                                <asp:Label ID="CreateDate1" runat="server" Text='<%# Eval("CreateDate", "{0:yyyyMMdd}")%>  '>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="9%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="啟用與否">
                            <ItemTemplate>
                                <asp:Label ID="IsApproved1" runat="server" Text='<%# (Boolean.Parse(Eval("IsApproved").ToString())) ? "Y" : "N" %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="9%" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="#F1E4EC" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#D2AAA2" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#D2AAA2" Font-Bold="True" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <AlternatingRowStyle BackColor="#F9F2F7" />
                </asp:GridView>
                <br />
                <asp:GridView ID="MemberGrid2" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
                    CellPadding="4" ForeColor="#333333" GridLines="Both" Font-Size="12px" BorderStyle="Double"
                    BorderColor="#663366" BorderWidth="1px">
                    <Columns>
                        <asp:TemplateField HeaderText="業者廠商" ShowHeader="False">
                            <ItemTemplate>
                                <a href='Profile2.aspx?username=<%#Eval("Username")%>' target="_blank">【修改會員資料】 </a>
                                <br />
                                <asp:LinkButton ID="DropBtn2" runat="server" OnCommand="DropBtn2_Command" CommandArgument='<%#Eval("UserId")%>'
                                    OnClientClick="return confirm('確定刪除資料?');">【刪除會員資料】</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="序號">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="3%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="帳號/密碼">
                            <ItemTemplate>
                                <asp:Label ID="Username2" runat="server" Text='<%# Eval("Username")  %>'>
                                </asp:Label>
                                <br />
                                (<asp:Label ID="Pwd2" runat="server" Text='<%# Eval("Pwd")  %>'>
                                </asp:Label>)
                            </ItemTemplate>
                            <ItemStyle Width="8%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="姓名">
                            <ItemTemplate>
                                <a href='ProfileView2.aspx?username=<%#Eval("Username")%>' target="_blank">
                                    <%# Eval("Name")  %>
                                </a>
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="公司/事業名稱">
                            <ItemTemplate>
                                <asp:Label ID="Corp2" runat="server" Text='<%# Eval("Corp")  %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單位屬性">
                            <ItemTemplate>
                                <asp:Label ID="Kind2" runat="server" Text='<%# Eval("Kind")  %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="9%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="聯絡電話">
                            <ItemTemplate>
                                <asp:Label ID="Tel2" runat="server" Text='<%# Eval("Tel")  %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="9%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="地址">
                            <ItemTemplate>
                                <asp:Label ID="Address2" runat="server" Text='<%# Eval("Address")  %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="25%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="E-mail">
                            <ItemTemplate>
                                <asp:Label ID="Email2" runat="server" Text='<%# Eval("Email")  %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="7%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="註冊日期">
                            <ItemTemplate>
                                <asp:Label ID="CreateDate2" runat="server" Text='<%# Eval("CreateDate", "{0:yyyyMMdd}")%>  '>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="9%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="啟用與否">
                            <ItemTemplate>
                                <asp:Label ID="IsApproved2" runat="server" Text='<%# (Boolean.Parse(Eval("IsApproved").ToString())) ? "Y" : "N" %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="9%" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="#f1e4ec" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#d2aaa2" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#d2aaa2" Font-Bold="True" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <AlternatingRowStyle BackColor="#f9f2f7" />
                </asp:GridView>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
