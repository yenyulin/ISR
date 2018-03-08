<%@ Page Language="C#" MasterPageFile="~/Template/manager.master" AutoEventWireup="true"
    CodeFile="News.aspx.cs" Inherits="Manage_News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <table width="700px" border="0" align="center" cellpadding="4" cellspacing="1">
        <tr>
            <td align="center">
                <p align="center">
                    <b><font face="標楷體" size="5" color="#990000">最新消息更新</font></b></p>
            </td>
        </tr>
        <tr>
            <td align="center" class="font1213-1">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="BackBtn_Click">返回主畫面</asp:LinkButton></td>
        </tr>
    </table>
    <br />
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="GridView" runat="server">
            <table width="95%" border="0" align="center" cellpadding="5" cellspacing="1">
                <tr>
                    <td>
                        <asp:GridView ID="NewsGrid" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="false"
                            CellPadding="4" ForeColor="#333333" Font-Size="12px" GridLines="Both" BorderStyle="Double"
                            BorderColor="#663366" BorderWidth="1">
                            <Columns>
                                <asp:TemplateField HeaderText="序號" ShowHeader="False">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="訊息標題" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Title" runat="server" OnCommand="Name_Command" CommandArgument='<%#Eval("Id")%>'><%# Eval("Title")%></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="訊息日期" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:Label ID="Showdate" runat="server" Text='<%#Eval("Showdate", "{0:yyyyMMdd}")%> '></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="修改日期" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:Label ID="Createdate" runat="server" Text='<%#Eval("Createdate", "{0:yyyyMMdd}")%> '>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="是否上線" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:Label ID="Isonline" runat="server" Text='<%#(Eval("Isonline").ToString().Equals("Y"))?"Y":"N" %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="跑馬燈" ShowHeader="False">
                                    <ItemTemplate>
                                        <div align="center">
                                            <asp:Label ID="Isshow" runat="server" Text='<%#(Boolean.Parse(Eval("Isshow").ToString()))?"Y":"N" %>'>
                                            </asp:Label>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle BackColor="#f1e4ec" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#d2aaa2" Font-Bold="True" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <AlternatingRowStyle BackColor="#f9f2f7" />
                        </asp:GridView>
                        <table width="100%" border="0">
                            <tr>
                                <td style="text-align: center">
                                    <br />
                                    <asp:Button ID="NewBtn" runat="server" Text="新增訊息" OnClick="NewBtn_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="AppendView" runat="server">
            <table width="760" height="37" border="0" align="center" cellpadding="8" cellspacing="1"
                bgcolor="#666600" class="mtable">
                <form action="" method="post" name="form1" id="form1">
                    <tr bgcolor="#A2CAD2" height="57">
                        <td height="30" colspan="2" bgcolor="#d2aaa2" class="font1213-1">
                            <img src="../image/icon/page_edit.png" alt="填寫相關資料" width="16" height="16" align="absmiddle">
                            <span class="title2">新增訊息</span></td>
                    </tr>
                    <tr bgcolor="#E4F1E9" height="37">
                        <td width="162" bgcolor="#f1e4ec" class="table_title1">
                            <span class="style1">※</span>訊息標題</td>
                        <td width="555" bgcolor="#f1e4ec" class="font1213-1">
                            <asp:TextBox ID="Title1" runat="server" Columns="80"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Title1"
                                ErrorMessage="必須提供訊息標題。" ToolTip="必須提供訊息標題。" ValidationGroup="ValidationGroup1"> </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr bgcolor="#E4F1E9">
                        <td bgcolor="#f1e4ec" class="table_title1">
                            <span class="style1">※</span> 訊息日期
                        </td>
                        <td bgcolor="#f1e4ec" class="font1213-1">
                            <asp:TextBox ID="Showdate1" runat="server" Columns="10"></asp:TextBox>
                            <asp:ImageButton runat="Server" ID="Image2" ImageUrl="~/image/icon/calendar.gif" />
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="Showdate1"
                                Format="yyyy/M/d" PopupButtonID="Image2" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Showdate1"
                                ErrorMessage="必須提供訊息日期。" ToolTip="必須提供訊息日期。" ValidationGroup="ValidationGroup1"> </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr bgcolor="#E4F1E9">
                        <td bgcolor="#f1e4ec" class="table_title1">
                            <span class="style1">※</span> 新聞摘要
                        </td>
                        <td bgcolor="#f1e4ec" class="font1213-1">
                            <asp:TextBox ID="Summary1" runat="server" Rows="10" TextMode="MultiLine" Columns="60"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Summary1"
                                ErrorMessage="必須提供新聞摘要。" ToolTip="必須提供新聞摘要。" ValidationGroup="ValidationGroup1"> </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr bgcolor="#E4F1E9">
                        <td bgcolor="#F9F2F7" class="table_title1">
                            相關連接
                        </td>
                        <td bgcolor="#F9F2F7" class="font1213-1">
                            <asp:TextBox ID="Link1" runat="server" Columns="40"></asp:TextBox>
                        </td>
                    </tr>
                    <tr bgcolor="#F2F9F4">
                        <td bgcolor="#F1E4EC" class="table_title1">
                            <span class="style1">※</span> 是否上線
                        </td>
                        <td bgcolor="#F1E4EC" class="font1213-1">
                            <asp:RadioButtonList ID="IsOnLine1" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">是</asp:ListItem>
                                <asp:ListItem Value="N">否</asp:ListItem>
                                <asp:ListItem Value="D">刪除</asp:ListItem>
                            </asp:RadioButtonList><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                ControlToValidate="IsOnLine1" ErrorMessage="必須提供是否上線。" ToolTip="必須提供新聞摘要。" ValidationGroup="ValidationGroup1"> </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr bgcolor="#E4F1E9">
                        <td bgcolor="#F9F2F7" class="table_title1">
                            <span class="style1">※</span> 跑馬燈
                        </td>
                        <td bgcolor="#F9F2F7" class="font1213-1">
                            <asp:RadioButtonList ID="IsShow1" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">是</asp:ListItem>
                                <asp:ListItem Value="N">否</asp:ListItem>
                            </asp:RadioButtonList><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                ControlToValidate="IsShow1" ErrorMessage="必須提供跑馬燈。" ToolTip="必須提供跑馬燈。" ValidationGroup="ValidationGroup1"> </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr bgcolor="#E4F1E9">
                        <td colspan="2" align="center" bgcolor="#F1E4EC" class="table_title1">
                            <label>
                                <asp:Button ID="AppendBtn" runat="server" Text="儲存離開" Height="30px" OnClick="AppendBtn_Click"
                                    ValidationGroup="ValidationGroup1" />&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="ExitBtn" runat="server" Text="放棄離開" Height="30px" OnClick="ExitBtn_Click" />
                            </label>
                        </td>
                    </tr>
                </form>
            </table>
        </asp:View>
        <asp:View ID="EditView" runat="server">
            <table width="760" height="37" border="0" align="center" cellpadding="8" cellspacing="1"
                bgcolor="#666600" class="mtable">
                <form action="" method="post" name="form1" id="form2">
                    <tr bgcolor="#A2CAD2" height="57">
                        <td height="30" colspan="2" bgcolor="#d2aaa2" class="font1213-1">
                            <img src="../image/icon/page_edit.png" alt="填寫相關資料" width="16" height="16" align="absmiddle">
                            <span class="title2">新增訊息</span></td>
                    </tr>
                    <tr bgcolor="#E4F1E9" height="37">
                        <td width="162" bgcolor="#f1e4ec" class="table_title1">
                            <span class="style1">※</span>訊息標題</td>
                        <td width="555" bgcolor="#f1e4ec" class="font1213-1">
                            <asp:TextBox ID="Title2" runat="server" Columns="80"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Title2"
                                ErrorMessage="必須提供訊息標題。" ToolTip="必須提供訊息標題。" ValidationGroup="ValidationGroup2"> </asp:RequiredFieldValidator>
                            <asp:HiddenField ID="Id" runat="server" />
                        </td>
                    </tr>
                    <tr bgcolor="#E4F1E9">
                        <td bgcolor="#f1e4ec" class="table_title1">
                            <span class="style1">※</span> 訊息日期
                        </td>
                        <td bgcolor="#f1e4ec" class="font1213-1">
                            <asp:TextBox ID="Showdate2" runat="server" Columns="10"></asp:TextBox>
                            <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/image/icon/calendar.gif" />
                            <ajaxToolkit:CalendarExtender ID="calendarButtonExtender2" runat="server" TargetControlID="Showdate2"
                                Format="yyyy/M/d" PopupButtonID="Image1" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Showdate2"
                                ErrorMessage="必須提供訊息日期。" ToolTip="必須提供訊息日期。" ValidationGroup="ValidationGroup2"> </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr bgcolor="#E4F1E9">
                        <td bgcolor="#f1e4ec" class="table_title1">
                            <span class="style1">※</span> 新聞摘要
                        </td>
                        <td bgcolor="#f1e4ec" class="font1213-1">
                            <asp:TextBox ID="Summary2" runat="server" Rows="10" TextMode="MultiLine" Columns="60"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="TechAdvRequired" runat="server" ControlToValidate="Summary2"
                                ErrorMessage="必須提供新聞摘要。" ToolTip="必須提供新聞摘要。" ValidationGroup="ValidationGroup2"> </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr bgcolor="#E4F1E9">
                        <td bgcolor="#F9F2F7" class="table_title1">
                            <span class="style1">※</span> 相關連接
                        </td>
                        <td bgcolor="#F9F2F7" class="font1213-1">
                            <asp:TextBox ID="Link2" runat="server" Columns="40"></asp:TextBox>
                        </td>
                    </tr>
                    <tr bgcolor="#F2F9F4">
                        <td bgcolor="#F1E4EC" class="table_title1">
                            <span class="style1">※</span> 是否上線
                        </td>
                        <td bgcolor="#F1E4EC" class="font1213-1">
                            <asp:RadioButtonList ID="IsOnLine2" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">是</asp:ListItem>
                                <asp:ListItem Value="N">否</asp:ListItem>
                                <asp:ListItem Value="D">刪除</asp:ListItem>
                            </asp:RadioButtonList><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                ControlToValidate="IsOnLine2" ErrorMessage="必須提供是否上線。" ToolTip="必須提供新聞摘要。" ValidationGroup="ValidationGroup2"> </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr bgcolor="#E4F1E9">
                        <td bgcolor="#F9F2F7" class="table_title1">
                            <span class="style1">※</span> 跑馬燈
                        </td>
                        <td bgcolor="#F9F2F7" class="font1213-1">
                            <asp:RadioButtonList ID="IsShow2" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">是</asp:ListItem>
                                <asp:ListItem Value="N">否</asp:ListItem>
                            </asp:RadioButtonList><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                ControlToValidate="IsShow2" ErrorMessage="必須提供跑馬燈。" ToolTip="必須提供跑馬燈。" ValidationGroup="ValidationGroup2"> </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr bgcolor="#E4F1E9">
                        <td colspan="2" align="center" bgcolor="#F1E4EC" class="table_title1">
                            <label>
                                <asp:Button ID="ModifyBtn" runat="server" Text="確定修改" OnClick="ModifyBtn_Click" ValidationGroup="ValidationGroup2"
                                    Height="30px" />&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="ExitBtn2" runat="server" Text="放棄修改" OnClick="ExitBtn_Click" Height="30px" />
                            </label>
                        </td>
                    </tr>
                </form>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
