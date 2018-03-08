<%@ Page Language="C#" MasterPageFile="~/Template/member.master" AutoEventWireup="true"
    CodeFile="page6A1.aspx.cs" Inherits="Member_page6A" %>

<asp:Content ID="ContentCreateUser2" ContentPlaceHolderID="Content" runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <img src="../image/frame/top3.jpg" alt="*" width="800" height="10"></td>
        </tr>
        <tr>
            <td height="25">
                <table width="90%" border="0" cellpadding="0" cellspacing="0" class="font1213-1">
                    <tr>
                        <td width="10">
                            <a href="../free.aspx" title="中央區域" accesskey="C"><font class="free_r">:::</font></a><div
                                align="center">
                            </div>
                        </td>
                        <td width="20">
                            <img src="../image/icon/icon2.jpg" alt="*" width="13" height="10"></td>
                        <td class="qLink_font">
                            現在位置：<a href="Default.aspx">首頁</a> &gt;&gt; <a href="page6A1.aspx">會員專區 &gt;&gt; 研發合作對象
                            </a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="330">
                            <img src="../image/frame/sub_title9.jpg" alt="*" width="330" height="55"></td>
                        <td width="431" background="../image/frame/sub_2.jpg">
                            <table width="375" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="28%">
                                        <div align="center">
                                        </div>
                                    </td>
                                    <td width="9%">
                                        <div align="center">
                                            <img src="../image/icon/arrow.gif" alt="*" width="19" height="20"></div>
                                    </td>
                                    <td width="63%" class="table_title1">
                                        <div align="right" class="subfunction_font">
                                            | <a href="page6A1.aspx">研發合作對象</a> | <a href="page6B1.aspx">供需資訊</a> | <a href="page6C1.aspx">
                                                會員資料</a> |
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
        <tr>
            <td align="center">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="GridView" runat="server">
                        <br />
                        <asp:Panel ID="Panel1" runat="server" visile="fasle">
                            <asp:Label ID="lblMessage" runat="server" Text="尚無研發合作對象 " />
                        </asp:Panel>
                        <asp:Panel ID="Panel2" runat="server" visile="fasle">
                            <table width="600px" cellpadding="0" cellspacing="0" border="0" align="center">
                                <tr>
                                    <td align="center" class="font1213-1" width="35%">
                                        總筆數：<font color="#FF0000"><b><asp:Label ID="cntTotal" runat="server" /></b></font>
                                    </td>
                                    <td align="center" width="30%">
                                        <asp:Repeater ID="rptPages" runat="server">
                                            <HeaderTemplate>
                                                <table width="100px" cellpadding="0" cellspacing="0" border="0" align="center">
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
                            <asp:Repeater ID="MatchGrid" runat="server">
                                <HeaderTemplate>
                                    <table width="760" border="0" align="center" cellpadding="1" cellspacing="1" bgcolor="#999999"
                                        class="mtable">
                                        <tr>
                                            <td rowspan="2" align="center" bgcolor="#A996AF" class="form_title1">
                                                序號</td>
                                            <td colspan="2" align="center" bgcolor="#A996AF" class="form_title1">
                                                媒合意願</td>
                                            <td rowspan="2" align="center" bgcolor="#A996AF" class="form_title1">
                                                學研界 / 業界
                                            </td>
                                            <td rowspan="2" align="center" bgcolor="#A996AF" class="form_title1">
                                                廢棄物種類</td>
                                            <td rowspan="2" align="center" bgcolor="#A996AF" class="form_title1">
                                                廢棄物名稱</td>
                                            <td rowspan="2" align="center" bgcolor="#A996AF" class="form_title1">
                                                再生技術名稱</td>
                                            <td rowspan="2" align="center" bgcolor="#A996AF" class="form_title1">
                                                再生技術方法</td>
                                            <td rowspan="2" align="center" bgcolor="#A996AF" class="form_title1">
                                                再生產品名稱</td>
                                            <td rowspan="2" align="center" bgcolor="#A996AF" class="form_title1">
                                                登錄日期</td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#A996AF" class="form_title1">
                                                <div align="center">
                                                    進一步瞭解</div>
                                            </td>
                                            <td bgcolor="#A996AF" class="form_title1">
                                                <div align="center">
                                                    刪除配對項目</div>
                                            </td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td rowspan="2" bgcolor="#F1E4EC" class="font1213-1">
                                            <div align="center">
                                                <%# Container.ItemIndex + 1%>
                                            </div>
                                        </td>
                                        <td rowspan="2" bgcolor="#F9F2F7" class="font1213-1">
                                            <div align="center">
                                                <div align="center">
                                                    <asp:CheckBox ID="PassCheckBox" runat="server" Checked='<%#(Eval("Isconfirm1").ToString().Equals("Y"))? true:false%>'
                                                        Visible='<%#(Eval("Isconfirm1").ToString().Equals("Y"))? false:true%>' ToolTip='<%#Eval("Id")%>' />
                                                    <asp:Label ID="Pass1" runat="server" Text="Y" Visible='<%#(Eval("Isconfirm1").ToString().Equals("Y"))? true:false%>'>
                                                    </asp:Label>
                                                </div>
                                            </div>
                                        </td>
                                        <td rowspan="2" bgcolor="#F1E4EC" class="font1213-1">
                                            <div align="center">
                                                <asp:CheckBox ID="DropCheckBox" runat="server" ToolTip='<%#Eval("Id")%>' />
                                            </div>
                                        </td>
                                        <td bgcolor="#F1E4EC" class="font1213-1">
                                            <div align="center">
                                                學研機構</div>
                                        </td>
                                        <td bgcolor="#f1e4ec" class="font1213-1">
                                            <asp:Label ID="Wasteitem1" runat="server" Text='<%# Eval("Wasteitem1")  %>'>
                                            </asp:Label></td>
                                        <td bgcolor="#f1e4ec" class="font1213-1">
                                            <asp:Label ID="Wastename1" runat="server" Text='<%# Eval("Wastename1")  %>'>
                                            </asp:Label></td>
                                        <td bgcolor="#f1e4ec" class="font1213-1">
                                            <asp:LinkButton ID="TechName" runat="server" OnCommand="TechNameBtn1_Command" CommandArgument='<%#Eval("Rid1")%>'><%# Eval("TechName1")%></asp:LinkButton>
                                        </td>
                                        <td bgcolor="#f1e4ec" class="font1213-1">
                                            <asp:Label ID="Techitem1" runat="server" Text='<%# Eval("Techitem1")  %>'>
                                            </asp:Label></td>
                                        <td bgcolor="#f1e4ec" class="font1213-1">
                                            <asp:Label ID="Reusename1" runat="server" Text='<%# Eval("Reusename1")  %>'>
                                            </asp:Label></td>
                                        <td bgcolor="#F1E4EC" class="font1213-1">
                                            <asp:Label ID="CreateDate1" runat="server" Text='<%# Eval("Createdate1", "{0:yyyyMMdd}")%>'>
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#F9F2F7" class="font1213-1">
                                            <div align="center">
                                                業者廠商</div>
                                        </td>
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
                                        <td bgcolor="#f9f2f7" class="font1213-1">
                                            <asp:Label ID="CreateDate2" runat="server" Text='<%# Eval("Createdate2", "{0:yyyyMMdd}")%>'>
                                            </asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                    <br />
                                    <div align="center">
                                        <asp:Button ID="SaveBtn" runat="server" Text="確  定" OnClick="SaveBtn_Click" />
                                        <asp:Button ID="BackBtn" runat="server" Text="返回主畫面" OnClick="BackBtn_Click" />
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>
                        </asp:Panel>
                        <br />
                    </asp:View>
                    <asp:View ID="ResultView" runat="server">
                        <table width="760" border="0" cellpadding="1" cellspacing="1" class="mtable">
                            <tr>
                                <td height="50" class="title3">
                                    &nbsp;
                                    <div align="center">
                                        <asp:Label ID="TechItem3" runat="server"></asp:Label>再生技術簡介及特點&nbsp;</div>
                                </td>
                            </tr>
                            <tr>
                                <td height="30" class="font1213-1">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td height="30" class="title3" align="left">
                                    &nbsp;<span class="title3">技術特點：</span></td>
                            </tr>
                            <tr>
                                <td height="30" class="font1213-1" align="left">
                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="TechAdv3" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td height="30" class="font1213-1" align="left">
                                    &nbsp;<span class="title3">技術簡介：</span></td>
                            </tr>
                            <tr>
                                <td height="30" class="font1213-1" align="left">
                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="TechDesc3" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                        <br />
                        <table width="100%" border="0" cellpadding="1" cellspacing="1">
                            <tr>
                                <td align="center">
                                    <asp:Button ID="BackBtn" runat="server" Text="返 回" OnClick="BackBtn2_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>
