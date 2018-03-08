<%@ Page Language="C#" MasterPageFile="~/Template/manager.master" AutoEventWireup="true"
    CodeFile="Case.aspx.cs" Inherits="Manage_Case" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <table width="700px" border="0" align="center" cellpadding="4" cellspacing="1">
        <tr>
            <td align="center">
                <p align="center">
                    <b><font face="標楷體" size="5" color="#990000">案例介紹管理</font></b></p>
            </td>
        </tr>
        <tr>
            <td align="center" class="font1213-1">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="BackBtn_Click">返回主畫面</asp:LinkButton></td>
        </tr>
    </table>
    <table width="95%" border="0" align="center" cellpadding="5" cellspacing="1">
        <tr>
            <td>
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="GridView" runat="server">
                        <div align="center">
                            <asp:Panel ID="Panel1" runat="server" visile="fasle">
                                <asp:Label ID="lblMessage" runat="server" Text="尚無案例介紹管理資料" />
                            </asp:Panel>
                        </div>
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
                        <br />
                        <asp:Repeater ID="CaseGrid" runat="server">
                            <HeaderTemplate>
                                <table width="100%" border="0" cellpadding="1" cellspacing="1" class="mtable">
                                    <tr>
                                        <td width="5%" align="center" bgcolor="#d2aaa2" class="title3">
                                            序號</td>
                                        <td width="60%" align="center" bgcolor="#d2aaa2" class="title3">
                                            案例名稱</td>
                                        <td width="17%" align="center" bgcolor="#d2aaa2" class="title3">
                                            案例類型</td>
                                        <td width="11%" align="center" bgcolor="#d2aaa2" class="title3">
                                            建檔時間</td>
                                        <td width="7%" align="center" bgcolor="#d2aaa2" class="title3">
                                            刪除</td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td bgcolor="#f1e4ec">
                                        <div align="center">
                                            <%# Container.ItemIndex + 1%>
                                        </div>
                                    </td>
                                    <td bgcolor="#f1e4ec">
                                        <asp:LinkButton ID="Name" runat="server" OnCommand="Name_Command" CommandArgument='<%#Eval("Id")%>'><%# Eval("Name")%></asp:LinkButton></td>
                                    <td align="center" bgcolor="#f1e4ec">
                                        <asp:Label ID="Type" runat="server" Text='<%#(Eval("Type").ToString().Equals("A"))?"研發補助案例":"再生實廠案例" %>'>
                                        </asp:Label>
                                    </td>
                                    <td align="center" bgcolor="#f1e4ec">
                                        <asp:Label ID="Createdate" runat="server" Text='<%# Eval("Createdate", "{0:yyyyMMdd}") %>'>
                                        </asp:Label>
                                    </td>
                                    <td align="center" bgcolor="#f1e4ec">
                                        <div align="center">
                                            <asp:CheckBox ID="DropCheckBox" runat="server" ToolTip='<%#Eval("Id")%>' />
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                                <table width="100%" border="0">
                                    <tr>
                                        <td style="text-align: center">
                                            <br />
                                            <asp:Button ID="NewBtn" runat="server" Text="新增案例" OnClick="NewBtn_Click" />
                                            <asp:Button ID="DropBtn" runat="server" Text="確定刪除" OnClientClick="if (confirm('確定刪除嗎？')==false) {return false;};__doPostBack('DropBtn','')"
                                                OnClick="DropBtn_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <asp:Panel ID="Panel2" runat="server" visile="fasle">
                            <table width="100%" border="0">
                                <tr>
                                    <td style="text-align: center">
                                        <br />
                                        <asp:Button ID="NewBtn" runat="server" Text="新增案例" OnClick="NewBtn_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </asp:View>
                    <asp:View ID="AppendView" runat="server">
                        <table width="760" height="37" border="0" align="center" cellpadding="8" cellspacing="1"
                            bgcolor="#666600" class="mtable">
                            <form action="" method="post" name="form1" id="form1">
                                <tr bgcolor="#A2CAD2" height="57">
                                    <td height="30" colspan="2" bgcolor="#d2aaa2" class="font1213-1">
                                        <img src="../image/icon/page_edit.png" alt="填寫相關資料" width="16" height="16" align="absmiddle">
                                        <span class="title3">新增案例</span></td>
                                </tr>
                                <tr bgcolor="#E4F1E9" height="37">
                                    <td width="162" bgcolor="#f1e4ec" class="table_title1">
                                        <span class="style1">※</span>案例名稱</td>
                                    <td width="555" bgcolor="#f1e4ec" class="font1213-1">
                                        <asp:TextBox ID="Name1" runat="server" Columns="80"></asp:TextBox><asp:RequiredFieldValidator
                                            ID="NameRequired" runat="server" ControlToValidate="Name1" ErrorMessage="必須提供案例名稱。"
                                            ToolTip="必須提供案例名稱。" ValidationGroup="ValidationGroup1"> </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr bgcolor="#F2F9F4" height="37">
                                    <td bgcolor="#f9f2f7" class="table_title1">
                                        <span class="style1">※</span> 案例類型</td>
                                    <td bgcolor="#f9f2f7" class="font1213-1">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="Type1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Type_SelectedIndexChanged">
                                                    <asp:ListItem Value="A">研發補助案例</asp:ListItem>
                                                    <asp:ListItem Value="B">再生實廠案例</asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr bgcolor="#E4F1E9">
                                    <td bgcolor="#f1e4ec" class="table_title1">
                                        <span class="style1">※</span> 廢棄物種類
                                    </td>
                                    <td bgcolor="#f1e4ec" class="font1213-1">
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="WasteItem1" runat="server" OnSelectedIndexChanged="WasteItem1_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                    <asp:ListItem Value="A">動物性廢棄物</asp:ListItem>
                                                    <asp:ListItem Value="B">植物性廢棄物</asp:ListItem>
                                                    <asp:ListItem Value="C">廢塑膠</asp:ListItem>
                                                    <asp:ListItem Value="D">廢橡膠</asp:ListItem>
                                                    <asp:ListItem Value="E">廢玻璃</asp:ListItem>
                                                    <asp:ListItem Value="F">廢混凝土</asp:ListItem>
                                                    <asp:ListItem Value="G">石材廢料</asp:ListItem>
                                                    <asp:ListItem Value="H">廢紙</asp:ListItem>
                                                    <asp:ListItem Value="I">廢木質</asp:ListItem>
                                                    <asp:ListItem Value="J">有機污泥</asp:ListItem>
                                                    <asp:ListItem Value="K">無機汙泥</asp:ListItem>
                                                    <asp:ListItem Value="L">灰渣</asp:ListItem>
                                                    <asp:ListItem Value="M">爐渣</asp:ListItem>
                                                    <asp:ListItem Value="N">金屬廢料</asp:ListItem>
                                                    <asp:ListItem Value="O">廢油</asp:ListItem>
                                                    <asp:ListItem Value="P">廢酸</asp:ListItem>
                                                    <asp:ListItem Value="Q">廢鹼</asp:ListItem>
                                                    <asp:ListItem Value="R">廢液</asp:ListItem>
                                                    <asp:ListItem Value="S">廢溶劑</asp:ListItem>
                                                    <asp:ListItem Value="T">廢電池</asp:ListItem>
                                                    <asp:ListItem Value="U">其他</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:TextBox ID="WasteOther1" runat="server" Visible="false" Width="120px"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr bgcolor="#E4F1E9">
                                    <td bgcolor="#F9F2F7" class="table_title1">
                                        <span class="style1">※</span> 廢棄物名稱
                                    </td>
                                    <td bgcolor="#F9F2F7" class="font1213-1">
                                        <asp:TextBox ID="WasteName1" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="WasteNameRequired" runat="server" ControlToValidate="WasteName1"
                                            ErrorMessage="必須提供廢棄物名稱。" ToolTip="必須提供廢棄物名稱。" ValidationGroup="ValidationGroup1"> </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr bgcolor="#F2F9F4">
                                    <td bgcolor="#F1E4EC" class="table_title1">
                                        <span class="style1">※</span> 再生技術名稱
                                    </td>
                                    <td bgcolor="#F1E4EC" class="font1213-1">
                                        <asp:TextBox ID="TechName1" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="TechNameRequired" runat="server" ControlToValidate="TechName1"
                                            ErrorMessage="必須提供再生技術名稱。" ToolTip="必須提供再生技術名稱。" ValidationGroup="ValidationGroup1"> </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr bgcolor="#E4F1E9">
                                    <td bgcolor="#F9F2F7" class="table_title1">
                                        <span class="style1">※</span> 再生技術方法
                                    </td>
                                    <td bgcolor="#F9F2F7" class="font1213-1">
                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="TechItem1" runat="server" OnSelectedIndexChanged="TechItem1_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                    <asp:ListItem Value="A">結晶、乾燥法</asp:ListItem>
                                                    <asp:ListItem Value="B">電漿法</asp:ListItem>
                                                    <asp:ListItem Value="C">萃取法</asp:ListItem>
                                                    <asp:ListItem Value="D">固化法</asp:ListItem>
                                                    <asp:ListItem Value="E">水解法</asp:ListItem>
                                                    <asp:ListItem Value="F">熱處理法</asp:ListItem>
                                                    <asp:ListItem Value="G">薄膜法</asp:ListItem>
                                                    <asp:ListItem Value="H">電解法</asp:ListItem>
                                                    <asp:ListItem Value="I">吸附法</asp:ListItem>
                                                    <asp:ListItem Value="J">熔融法</asp:ListItem>
                                                    <asp:ListItem Value="K">聚合法</asp:ListItem>
                                                    <asp:ListItem Value="L">破碎法</asp:ListItem>
                                                    <asp:ListItem Value="M">分選、浮選法</asp:ListItem>
                                                    <asp:ListItem Value="N">蒸餾法</asp:ListItem>
                                                    <asp:ListItem Value="O">氣提、吸收法</asp:ListItem>
                                                    <asp:ListItem Value="P">壓合、成型法</asp:ListItem>
                                                    <asp:ListItem Value="Q">冶煉、熔鍊法</asp:ListItem>
                                                    <asp:ListItem Value="R">堆肥法</asp:ListItem>
                                                    <asp:ListItem Value="S">沉降法</asp:ListItem>
                                                    <asp:ListItem Value="T">氧化、還原法</asp:ListItem>
                                                    <asp:ListItem Value="U">溶解、置換法</asp:ListItem>
                                                    <asp:ListItem Value="V">其他</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:TextBox ID="TechOther1" runat="server" Visible="false" Width="120px"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr bgcolor="#F2F9F4">
                                    <td bgcolor="#F1E4EC" class="table_title1">
                                        <span class="style1">※</span> 案例簡介
                                    </td>
                                    <td bgcolor="#F1E4EC" class="font1213-1">
                                        <asp:TextBox ID="CaseDesc1" runat="server" Rows="4" TextMode="MultiLine" Columns="70"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="TechAdvRequired" runat="server" ControlToValidate="CaseDesc1"
                                            ErrorMessage="必須提供案例簡介。" ToolTip="必須提供案例簡介。" ValidationGroup="ValidationGroup1"> </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr bgcolor="#E4F1E9">
                                    <td bgcolor="#F9F2F7" class="table_title1">
                                        <span class="style1">※</span> 研發補助項目
                                    </td>
                                    <td bgcolor="#F9F2F7" class="font1213-1">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="HelpDesc1" runat="server" Rows="8" TextMode="MultiLine" Columns="70"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="HelpDescRequired" runat="server" ControlToValidate="HelpDesc1"
                                                    ErrorMessage="必須提供研發補助項目。" ToolTip="必須提供研發補助項目。" ValidationGroup="ValidationGroup1"> </asp:RequiredFieldValidator>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr bgcolor="#F2F9F4">
                                    <td bgcolor="#F1E4EC" class="table_title1">
                                        <span class="style1">※</span> 資料來源
                                    </td>
                                    <td bgcolor="#F1E4EC" class="font1213-1">
                                        <asp:TextBox ID="Datasource1" runat="server" Rows="4" TextMode="MultiLine" Columns="70"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Datasource1"
                                            ErrorMessage="必須提供資料來源。" ToolTip="必須提供資料來源。" ValidationGroup="ValidationGroup1"> </asp:RequiredFieldValidator>
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
                                        <span class="title3">新增案例</span></td>
                                </tr>
                                <tr bgcolor="#E4F1E9" height="37">
                                    <td width="162" bgcolor="#f1e4ec" class="table_title1">
                                        <span class="style1">※</span>案例名稱</td>
                                    <td width="555" bgcolor="#f1e4ec" class="font1213-1">
                                        <asp:TextBox ID="Name2" runat="server" Columns="80"></asp:TextBox><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator1" runat="server" ControlToValidate="Name2" ErrorMessage="必須提供案例名稱。"
                                            ToolTip="必須提供案例名稱。" ValidationGroup="ValidationGroup2"> </asp:RequiredFieldValidator>
                                        <asp:HiddenField ID="Id" runat="server" />
                                    </td>
                                </tr>
                                <tr bgcolor="#F2F9F4">
                                    <td bgcolor="#f9f2f7" class="table_title1">
                                        <span class="style1">※</span> 案例類型</td>
                                    <td bgcolor="#f9f2f7" class="font1213-1">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="Type2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Type2_SelectedIndexChanged">
                                                    <asp:ListItem Value="A">研發補助案例</asp:ListItem>
                                                    <asp:ListItem Value="B">再生實廠案例</asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr bgcolor="#E4F1E9">
                                    <td bgcolor="#f1e4ec" class="table_title1">
                                        <span class="style1">※</span> 廢棄物種類
                                    </td>
                                    <td bgcolor="#f1e4ec" class="font1213-1">
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="WasteItem2" runat="server" OnSelectedIndexChanged="WasteItem2_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                    <asp:ListItem Value="A">動物性廢棄物</asp:ListItem>
                                                    <asp:ListItem Value="B">植物性廢棄物</asp:ListItem>
                                                    <asp:ListItem Value="C">廢塑膠</asp:ListItem>
                                                    <asp:ListItem Value="D">廢橡膠</asp:ListItem>
                                                    <asp:ListItem Value="E">廢玻璃</asp:ListItem>
                                                    <asp:ListItem Value="F">廢混凝土</asp:ListItem>
                                                    <asp:ListItem Value="G">石材廢料</asp:ListItem>
                                                    <asp:ListItem Value="H">廢紙</asp:ListItem>
                                                    <asp:ListItem Value="I">廢木質</asp:ListItem>
                                                    <asp:ListItem Value="J">有機污泥</asp:ListItem>
                                                    <asp:ListItem Value="K">無機汙泥</asp:ListItem>
                                                    <asp:ListItem Value="L">灰渣</asp:ListItem>
                                                    <asp:ListItem Value="M">爐渣</asp:ListItem>
                                                    <asp:ListItem Value="N">金屬廢料</asp:ListItem>
                                                    <asp:ListItem Value="O">廢油</asp:ListItem>
                                                    <asp:ListItem Value="P">廢酸</asp:ListItem>
                                                    <asp:ListItem Value="Q">廢鹼</asp:ListItem>
                                                    <asp:ListItem Value="R">廢液</asp:ListItem>
                                                    <asp:ListItem Value="S">廢溶劑</asp:ListItem>
                                                    <asp:ListItem Value="T">廢電池</asp:ListItem>
                                                    <asp:ListItem Value="U">其他</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:TextBox ID="WasteOther2" runat="server" Visible='false' Width="120px"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr bgcolor="#E4F1E9">
                                    <td bgcolor="#F9F2F7" class="table_title1">
                                        <span class="style1">※</span> 廢棄物名稱
                                    </td>
                                    <td bgcolor="#F9F2F7" class="font1213-1">
                                        <asp:TextBox ID="WasteName2" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="WasteName1"
                                            ErrorMessage="必須提供廢棄物名稱。" ToolTip="必須提供廢棄物名稱。" ValidationGroup="ValidationGroup2"> </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr bgcolor="#F2F9F4">
                                    <td bgcolor="#F1E4EC" class="table_title1">
                                        <span class="style1">※</span> 再生技術名稱
                                    </td>
                                    <td bgcolor="#F1E4EC" class="font1213-1">
                                        <asp:TextBox ID="TechName2" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TechName2"
                                            ErrorMessage="必須提供再生技術名稱。" ToolTip="必須提供再生技術名稱。" ValidationGroup="ValidationGroup2"> </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr bgcolor="#E4F1E9">
                                    <td bgcolor="#F9F2F7" class="table_title1">
                                        <span class="style1">※</span> 再生技術方法
                                    </td>
                                    <td bgcolor="#F9F2F7" class="font1213-1">
                                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="TechItem2" runat="server" OnSelectedIndexChanged="TechItem2_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                    <asp:ListItem Value="A">結晶、乾燥法</asp:ListItem>
                                                    <asp:ListItem Value="B">電漿法</asp:ListItem>
                                                    <asp:ListItem Value="C">萃取法</asp:ListItem>
                                                    <asp:ListItem Value="D">固化法</asp:ListItem>
                                                    <asp:ListItem Value="E">水解法</asp:ListItem>
                                                    <asp:ListItem Value="F">熱處理法</asp:ListItem>
                                                    <asp:ListItem Value="G">薄膜法</asp:ListItem>
                                                    <asp:ListItem Value="H">電解法</asp:ListItem>
                                                    <asp:ListItem Value="I">吸附法</asp:ListItem>
                                                    <asp:ListItem Value="J">熔融法</asp:ListItem>
                                                    <asp:ListItem Value="K">聚合法</asp:ListItem>
                                                    <asp:ListItem Value="L">破碎法</asp:ListItem>
                                                    <asp:ListItem Value="M">分選、浮選法</asp:ListItem>
                                                    <asp:ListItem Value="N">蒸餾法</asp:ListItem>
                                                    <asp:ListItem Value="O">氣提、吸收法</asp:ListItem>
                                                    <asp:ListItem Value="P">壓合、成型法</asp:ListItem>
                                                    <asp:ListItem Value="Q">冶煉、熔鍊法</asp:ListItem>
                                                    <asp:ListItem Value="R">堆肥法</asp:ListItem>
                                                    <asp:ListItem Value="S">沉降法</asp:ListItem>
                                                    <asp:ListItem Value="T">氧化、還原法</asp:ListItem>
                                                    <asp:ListItem Value="U">溶解、置換法</asp:ListItem>
                                                    <asp:ListItem Value="V">其他</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:TextBox ID="TechOther2" runat="server" Visible='false' Width="120px"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr bgcolor="#F2F9F4">
                                    <td bgcolor="#F1E4EC" class="table_title1">
                                        <span class="style1">※</span> 案例簡介
                                    </td>
                                    <td bgcolor="#F1E4EC" class="font1213-1">
                                        <asp:TextBox ID="CaseDesc2" runat="server" Rows="8" TextMode="MultiLine" Columns="70"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="CaseDesc2"
                                            ErrorMessage="必須提供案例簡介。" ToolTip="必須提供案例簡介。" ValidationGroup="ValidationGroup2"> </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr bgcolor="#E4F1E9">
                                    <td bgcolor="#F9F2F7" class="table_title1">
                                        <span class="style1">※</span> 研發補助項目
                                    </td>
                                    <td bgcolor="#F9F2F7" class="font1213-1">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="HelpDesc2" runat="server" Rows="4" TextMode="MultiLine" Columns="70"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="HelpDesc2"
                                                    ErrorMessage="必須提供研發補助項目。" ToolTip="必須提供研發補助項目。" ValidationGroup="ValidationGroup2"> </asp:RequiredFieldValidator>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr bgcolor="#F2F9F4">
                                    <td bgcolor="#F1E4EC" class="table_title1">
                                        <span class="style1">※</span> 資料來源
                                    </td>
                                    <td bgcolor="#F1E4EC" class="font1213-1">
                                        <asp:TextBox ID="Datasource2" runat="server" Rows="4" TextMode="MultiLine" Columns="70"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Datasource2"
                                            ErrorMessage="必須提供資料來源。" ToolTip="必須提供資料來源。" ValidationGroup="ValidationGroup2"> </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr bgcolor="#E4F1E9">
                                    <td colspan="2" align="center" bgcolor="#F1E4EC" class="table_title1">
                                        <label>
                                            <asp:Button ID="ModifyBtn" runat="server" Text="儲存離開" Height="30px" OnClick="ModifyBtn_Click"
                                                ValidationGroup="ValidationGroup2" />&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="ExitBtn2" runat="server" Text="放棄離開" Height="30px" OnClick="ExitBtn_Click" />
                                        </label>
                                    </td>
                                </tr>
                            </form>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>
