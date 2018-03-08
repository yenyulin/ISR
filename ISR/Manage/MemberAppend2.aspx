<%@ Page Language="C#" MasterPageFile="~/Template/manager.master" AutoEventWireup="true"
    CodeFile="MemberAppend2.aspx.cs" Inherits="Manage_MemberAppend2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <div align="center">
        <table width="700px" border="0" align="center" cellpadding="4" cellspacing="1">
            <tr>
                <td align="center">
                    <p align="center">
                        <b><font face="標楷體" size="5" color="#990000">新增會員</font></b></p>
                </td>
            </tr>
        </table>
        <table width="700px" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td align="center" style="width: 802px">
                    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" OnCreatedUser="CreateUserWizard1_CreatedUser"
                        CreateUserButtonText="註冊完成" OnNextButtonClick="CreateUserWizard1_NextButtonClick">
                        <WizardSteps>
                            <asp:TemplatedWizardStep runat="server" StepType="Start" Title="註冊您的新帳戶" ID="UserTemplate">
                                <ContentTemplate>
                                    <table width="760" height="37" border="0" align="center" cellpadding="8" cellspacing="1"
                                        bgcolor="#666600" class="mtable" align="center">
                                        <tr bgcolor="#a2cad2" height="57">
                                            <td colspan="2" bgcolor="#d2aaa2" class="font1213-1" style="height: 30px">
                                                <img src="../image/icon/page_edit.png" alt="填寫相關資料" width="16" height="16" align="absMiddle">
                                                <span class="form_title1">請詳細填寫相關資料：(以利加速審核流程)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ※
                                                    為必填欄位</span></td>
                                        </tr>
                                        <tr bgcolor="#e4f1e9" height="37">
                                            <td width="162" bgcolor="#f1e4ec" class="table_title1" align="left">
                                                <span class="style1">※</span> 帳號</td>
                                            <td width="555" bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="UserName" runat="server" Columns="8" MaxLength="8" OnTextChanged="UserName_TextChanged"
                                                            AutoPostBack="true"></asp:TextBox>
                                                        <asp:Button ID="CheckBtn" runat="server" Text="比對" OnClick="CheckBtn_Click" />
                                                        (<span class="style1">需為６～８碼英文字母、數字之組合</span>)
                                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                            ErrorMessage="必須提供帳號。" ToolTip="必須提供帳號。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="UserName"
                                                            ValidationExpression="^[a-zA-Z0-9]{6,8}$" runat="server" ErrorMessage="需為６～８碼英文字母、數字之組合。"
                                                            ToolTip="需為６～８碼英文字母、數字之組合。" SetFocusOnError="True">*</asp:RegularExpressionValidator>
                                                        <asp:Label ID="CheckMsg" runat="server" ForeColor="blue">
                                                        </asp:Label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#f2f9f4" height="37">
                                            <td bgcolor="#f9f2f7" class="table_title1" align="left" style="height: 37px">
                                                <span class="style1">※</span> 密碼</td>
                                            <td bgcolor="#f9f2f7" class="font1213-1" align="left" style="height: 37px">
                                                密 碼
                                                <asp:TextBox ID="Password" runat="server" TextMode="Password" Columns="8" MaxLength="8"></asp:TextBox>
                                                (<span class="style1">8碼數字</span>)
                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                    ErrorMessage="必須提供密碼。" ToolTip="必須提供密碼。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                複驗密碼
                                                <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" Columns="8"
                                                    MaxLength="8"></asp:TextBox>
                                                (<span class="style1">8碼數字</span>)
                                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                                    ErrorMessage="必須提供確認密碼。" ToolTip="必須提供確認密碼。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                                    ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="密碼和確認密碼必須相符。"
                                                    ValidationGroup="CreateUserWizard1" ForeColor="red">*</asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#e4f1e9">
                                            <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                                <span class="style1">※</span> 公司 / 事業名稱
                                            </td>
                                            <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                <asp:TextBox ID="Corp" runat="server" Columns="25"></asp:TextBox><asp:RequiredFieldValidator
                                                    ID="CorpRequired" runat="server" ControlToValidate="Corp" ErrorMessage="必須提供單位名稱。"
                                                    ToolTip="必須提供單位名稱。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#f2f9f4">
                                            <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                                <span class="style1">※</span> 負責人姓名
                                            </td>
                                            <td bgcolor="#F9F2F7" class="font1213-1" align="left">
                                                <asp:TextBox ID="Owner" runat="server" Columns="10"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="OwnerRequired" runat="server" ControlToValidate="Owner"
                                                    ErrorMessage="必須提供負責人姓名。" ToolTip="必須提供負責人姓名。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr bgcolor="#f2f9f4">
                                            <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                                <span class="style1">※</span> 地址</td>
                                            <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                <span style="height: 27px">
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="cityList" runat="server" OnSelectedIndexChanged="cityList_SelectedIndexChanged"
                                                                AutoPostBack="true">
                                                                <asp:ListItem Value="ZZ">請選擇...</asp:ListItem>
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
                                                            <asp:TextBox ID="Address" runat="server" MaxLength="150" Columns="34"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="AddressRequired" runat="server" ValidationGroup="CreateUserWizard1"
                                                                ToolTip="必須提供地址。" ErrorMessage="必須提供地址。" ControlToValidate="Address">*</asp:RequiredFieldValidator>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#f2f9f4">
                                            <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                                <span class="style1">※</span> 會員姓名</td>
                                            <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                                <asp:TextBox ID="Name" runat="server" Columns="10"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="NameRequired" runat="server" ControlToValidate="Name"
                                                    ErrorMessage="必須提供會員姓名。" ToolTip="必須提供會員姓名。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#e4f1e9">
                                            <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                                <span class="style1">※</span> 連絡電話</td>
                                            <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                <asp:TextBox ID="Tel" runat="server" Columns="15" MaxLength="25"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="TelRequired" runat="server" ControlToValidate="Tel"
                                                    ErrorMessage="必須提供連絡電話。" ToolTip="必須提供連絡電話。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#f2f9f4">
                                            <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                                <span class="style1">※</span> 傳真</td>
                                            <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                                <asp:TextBox ID="Fax" runat="server" Columns="15" MaxLength="25"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="FaxRequired" runat="server" ControlToValidate="Fax"
                                                    ErrorMessage="必須提供會員姓名。" ToolTip="必須提供會員姓名。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#e4f1e9">
                                            <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                                <span class="style1">※</span> 電子信箱
                                            </td>
                                            <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                                    ErrorMessage="必須提供電子郵件。" ToolTip="必須提供電子郵件。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="Email"
                                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server"
                                                    ErrorMessage="電子郵件格式不正確。" ToolTip="電子郵件格式不正確。" SetFocusOnError="True"> 
                                                </asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#e4f1e9" height="37">
                                            <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                                <span class="style1">※</span> 單位屬性
                                            </td>
                                            <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                                <label>
                                                    <asp:DropDownList ID="Kind" runat="server">
                                                        <asp:ListItem Value="">請選擇...</asp:ListItem>
                                                        <asp:ListItem Value="A">公民營處(清)理機構</asp:ListItem>
                                                        <asp:ListItem Value="B">許可再利用機構</asp:ListItem>
                                                        <asp:ListItem Value="C">公告再利用機構</asp:ListItem>
                                                        <asp:ListItem Value="D">應回收廢棄物處理機構</asp:ListItem>
                                                        <asp:ListItem Value="E">其他</asp:ListItem>
                                                    </asp:DropDownList>
                                                </label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="color: red" colspan="2">
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                                <CustomNavigationTemplate>
                                    <table border="0" cellspacing="5" style="width: 100%; height: 100%">
                                        <tr>
                                            <td align="center" colspan="0">
                                                <asp:Button ID="StartNextButton" runat="server" CommandName="MoveNext" Text="填寫完畢"
                                                    ValidationGroup="CreateUserWizard1" />
                                                <asp:Button ID="BackBtn" runat="server" Text="返  回" OnClick="BackBtn_Click" />
                                                <asp:ValidationSummary ID="ValidationSummary4" runat="server" ShowMessageBox="True"
                                                    ShowSummary="False" ValidationGroup="CreateUserWizard1" />
                                            </td>
                                        </tr>
                                    </table>
                                </CustomNavigationTemplate>
                            </asp:TemplatedWizardStep>
                            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" Title="確認資料">
                                <ContentTemplate>
                                    <table width="760" height="37" border="0" align="center" cellpadding="8" cellspacing="1"
                                        bgcolor="#666600" class="mtable">
                                        <tr bgcolor="#a2cad2" height="57">
                                            <td colspan="2" bgcolor="#d2aaa2" class="font1213-1" style="height: 30px">
                                                <img src="../image/icon/page_edit.png" alt="填寫相關資料" width="16" height="16" align="absMiddle">
                                                <span class="form_title1">確認資料</span></td>
                                        </tr>
                                        <tr bgcolor="#e4f1e9">
                                            <td width="162" bgcolor="#f1e4ec" class="table_title1" align="left">
                                                <span class="style1">※</span> 帳號</td>
                                            <td width="555" bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                <asp:Label ID="UserNameView" runat="server">
                                                </asp:Label>
                                                <asp:TextBox ID="UserName" runat="server" Columns="8" Visible="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#f2f9f4">
                                            <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                                <span class="style1">※</span> 密碼</td>
                                            <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                                <asp:Label ID="PasswordView" runat="server">
                                                </asp:Label>
                                                <asp:TextBox ID="Password" runat="server" Columns="8" Visible="false"></asp:TextBox>
                                                <asp:TextBox ID="ConfirmPassword" runat="server" Columns="8" Visible="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#e4f1e9">
                                            <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                                <span class="style1">※</span> 公司 / 事業名稱
                                            </td>
                                            <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                <asp:Label ID="Corp" runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#e4f1e9">
                                            <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                                <span class="style1">※</span> 負責人姓名
                                            </td>
                                            <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                <asp:Label ID="Owner" runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#f2f9f4">
                                            <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                                <span class="style1">※</span> 地址</td>
                                            <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                                <asp:Label ID="Address" runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#e4f1e9">
                                            <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                                <span class="style1">※</span> 會員姓名</td>
                                            <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                <asp:Label ID="Name" runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#f2f9f4">
                                            <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                                <span class="style1">※</span> 連絡電話</td>
                                            <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                                <asp:Label ID="Tel" runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#e4f1e9">
                                            <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                                <span class="style1">※</span> 傳真</td>
                                            <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                <asp:Label ID="Fax" runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#e4f1e9">
                                            <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                                <span class="style1">※</span> 電子信箱
                                            </td>
                                            <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                                <asp:Label ID="EmailView" runat="server">
                                                </asp:Label>
                                                <asp:TextBox ID="Email" runat="server" Visible="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#e4f1e9" height="37">
                                            <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                                <span class="style1">※</span> 單位屬性
                                            </td>
                                            <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                                <asp:Label ID="Kind" runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                                <CustomNavigationTemplate>
                                    <table border="0" cellspacing="5" style="width: 100%; height: 100%">
                                        <tr>
                                            <td align="center" colspan="0">
                                                <asp:Button ID="StepPreviousButton" runat="server" CausesValidation="False" CommandName="MovePrevious"
                                                    Text="回上層修改" />
                                                <asp:Button ID="StepNextButton" runat="server" CommandName="MoveNext" Text="確認無誤送出" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </CustomNavigationTemplate>
                            </asp:CreateUserWizardStep>
                            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                                <ContentTemplate>
                                    <table width="760" height="37" border="0" align="center" cellpadding="8" cellspacing="1"
                                        bgcolor="#666600" class="mtable">
                                        <tr bgcolor="#a2cad2" height="57">
                                            <td height="30" bgcolor="#d2aaa2" class="font1213-1">
                                                完成</td>
                                        </tr>
                                        <tr bgcolor="#e4f1e9" height="77">
                                            <td bgcolor="#ffffff" class="table_title1" align="center">
                                                <asp:Label ID="Msg" runat="server">
                                                </asp:Label></td>
                                        </tr>
                                        <tr bgcolor="#f2f9f4">
                                            <td bgcolor="#f9f2f7" class="table_title1" align="center">
                                                <asp:Button ID="BackBtn2" runat="server" Text="返  回" OnClick="BackBtn_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:CompleteWizardStep>
                        </WizardSteps>
                    </asp:CreateUserWizard>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
