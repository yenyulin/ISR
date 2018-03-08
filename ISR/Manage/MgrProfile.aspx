<%@ Page Language="C#" MasterPageFile="~/Template/manager.master" AutoEventWireup="true"
    CodeFile="MgrProfile.aspx.cs" Inherits="Manage_MgrProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <table width="600px" border="0" align="center" cellpadding="5" cellspacing="1">
        <tr>
            <td align="center">
                <p align="center">
                    <b><font face="標楷體" size="5" color="#990000">基本資料維護</font></b></p>
            </td>
        </tr>
    </table>
    <table width="760" height="37" border="0" align="center" cellpadding="8" cellspacing="1"
        bgcolor="#666600" class="mtable">
        <tr bgcolor="#A2CAD2" height="57">
            <td height="30" colspan="2" bgcolor="#d2aaa2" class="font1213-1">
                <img src="../image/icon/page_edit.png" alt="填寫相關資料" width="16" height="16" align="absmiddle">
                <span class="form_title1">基本資料&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ※ 為必填欄位</span></td>
        </tr>
        <tr bgcolor="#E4F1E9" height="37">
            <td width="162" bgcolor="#f1e4ec" class="table_title1" align="left">
                <span class="style1">※</span> 帳號</td>
            <td width="555" bgcolor="#f1e4ec" class="font1213-1" align="left">
                <asp:Label ID="Username" runat="server">
                </asp:Label>
            </td>
        </tr>
        <tr bgcolor="#F2F9F4">
            <td bgcolor="#f9f2f7" class="table_title1" align="left">
                <span class="style1">※</span> 學校系所 / 研究單位名稱
            </td>
            <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                <asp:TextBox ID="Corp" runat="server" Columns="25"></asp:TextBox><asp:RequiredFieldValidator
                    ID="CorpRequired" runat="server" ControlToValidate="Corp" ErrorMessage="必須提供單位名稱。"
                    ToolTip="必須提供單位名稱。" ValidationGroup="ValidationGroup3">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr bgcolor="#E4F1E9">
            <td bgcolor="#f1e4ec" class="table_title1" align="left">
                <span class="style1">※</span> 地址</td>
            <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                <span style="height: 27px">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cityList" runat="server" OnSelectedIndexChanged="cityList_SelectedIndexChanged"
                                AutoPostBack="true">
                                <asp:ListItem Value="01">臺北市</asp:ListItem>
                                <asp:ListItem Value="02">基隆市</asp:ListItem>
                                <asp:ListItem Value="03">臺北縣</asp:ListItem>
                                <asp:ListItem Value="04">宜蘭縣</asp:ListItem>
                                <asp:ListItem Value="05">新竹市</asp:ListItem>
                                <asp:ListItem Value="06">新竹縣</asp:ListItem>
                                <asp:ListItem Value="07">桃園縣</asp:ListItem>
                                <asp:ListItem Value="08">苗栗縣</asp:ListItem>
                                <asp:ListItem Value="09">臺中市</asp:ListItem>
                                <asp:ListItem Value="10">臺中縣</asp:ListItem>
                                <asp:ListItem Value="11">彰化縣</asp:ListItem>
                                <asp:ListItem Value="12">南投縣</asp:ListItem>
                                <asp:ListItem Value="13">嘉義市</asp:ListItem>
                                <asp:ListItem Value="14">嘉義縣</asp:ListItem>
                                <asp:ListItem Value="15">雲林縣</asp:ListItem>
                                <asp:ListItem Value="16">臺南市</asp:ListItem>
                                <asp:ListItem Value="17">臺南縣</asp:ListItem>
                                <asp:ListItem Value="18">高雄市</asp:ListItem>
                                <asp:ListItem Value="19">南海諸島</asp:ListItem>
                                <asp:ListItem Value="20">高雄縣</asp:ListItem>
                                <asp:ListItem Value="21">澎湖縣</asp:ListItem>
                                <asp:ListItem Value="22">屏東縣</asp:ListItem>
                                <asp:ListItem Value="23">臺東縣</asp:ListItem>
                                <asp:ListItem Value="24">花蓮縣</asp:ListItem>
                                <asp:ListItem Value="25">金門縣</asp:ListItem>
                                <asp:ListItem Value="26">連江縣</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="zipList" runat="server">
                            </asp:DropDownList>
                            <asp:TextBox ID="Address" runat="server" Columns="34" MaxLength="150"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="AddressRequired" runat="server" ControlToValidate="Address"
                                ErrorMessage="必須提供地址。" ToolTip="必須提供地址。" ValidationGroup="ValidationGroup3">*</asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </span>
            </td>
        </tr>
        <tr bgcolor="#F2F9F4">
            <td bgcolor="#f9f2f7" class="table_title1" align="left">
                <span class="style1">※</span> 會員姓名</td>
            <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                <asp:TextBox ID="Name" runat="server" Columns="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NameRequired" runat="server" ControlToValidate="Name"
                    ErrorMessage="必須提供會員姓名。" ToolTip="必須提供會員姓名。" ValidationGroup="ValidationGroup3">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr bgcolor="#E4F1E9">
            <td bgcolor="#f1e4ec" class="table_title1" align="left">
                <span class="style1">※</span> 連絡電話</td>
            <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                <asp:TextBox ID="Tel" runat="server" Columns="15" MaxLength="25"></asp:TextBox>
                <asp:RequiredFieldValidator ID="TelRequired" runat="server" ControlToValidate="Tel"
                    ErrorMessage="必須提供連絡電話。" ToolTip="必須提供連絡電話。" ValidationGroup="ValidationGroup3">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr bgcolor="#F2F9F4">
            <td bgcolor="#f9f2f7" class="table_title1" align="left">
                <span class="style1">※</span> 傳真</td>
            <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                <asp:TextBox ID="Fax" runat="server" Columns="15" MaxLength="25"></asp:TextBox>
                <asp:RequiredFieldValidator ID="FaxRequired" runat="server" ControlToValidate="Fax"
                    ErrorMessage="必須提供會員姓名。" ToolTip="必須提供會員姓名。" ValidationGroup="ValidationGroup3">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr bgcolor="#E4F1E9">
            <td bgcolor="#f1e4ec" class="table_title1" align="left">
                <span class="style1">※</span> 電子信箱
            </td>
            <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                    ErrorMessage="必須提供電子郵件。" ToolTip="必須提供電子郵件。" ValidationGroup="ValidationGroup3">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="Email"
                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server"
                    ErrorMessage="電子郵件格式不正確。" ToolTip="電子郵件格式不正確。" SetFocusOnError="True"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr bgcolor="#F2F9F4" height="37">
            <td bgcolor="#f9f2f7" class="table_title1" align="left">
                <span class="style1">※</span> 單位屬性
            </td>
            <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                <label>
                    <asp:DropDownList ID="Kind" runat="server">
                        <asp:ListItem Value="A">學術單位</asp:ListItem>
                        <asp:ListItem Value="B">研究單位</asp:ListItem>
                        <asp:ListItem Value="C">其他</asp:ListItem>
                    </asp:DropDownList>
                </label>
            </td>
        </tr>
        <tr bgcolor="#E4F1E9">
            <td colspan="2" align="center" bgcolor="#F1E4EC" class="table_title1">
                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                <asp:Button ID="BtnUpdate2" runat="server" Text="確定修改" OnClick="BtnUpdate2_Click"
                    ValidationGroup="ValidationGroup3"  Height="30px"/>
                <asp:Button ID="BtnCancel2" runat="server" Text="放棄,返回主畫面" OnClick="BtnCancel2_Click" Height="30px"/>
            </td>
        </tr>
    </table>
</asp:Content>
