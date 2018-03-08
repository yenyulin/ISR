<%@ Page Language="C#" MasterPageFile="~/Template/default.master" AutoEventWireup="true"
    CodeFile="page4A.aspx.cs" Inherits="page4_A" %>

<asp:Content ID="ContentCreateUser1" ContentPlaceHolderID="Content" runat="Server">

    <script type="text/javascript">
                function   onSelectChanged1(sel)
                {                   
                    var   value   =   sel.value; 
                    var textbox = document.getElementById('<%=((TextBox)UserTemplate.ContentTemplateContainer.FindControl("TechOther")).ClientID%>')  ;         
                      if(value   ==   "V")
                        textbox.style.display = "block";                
                       else
                        textbox.style.display = "none";
                                     
                }
                function   onSelectChanged2(sel)
                {                   
                    var   value   =   sel.value; 
                    var textbox = document.getElementById('<%=((TextBox)UserTemplate.ContentTemplateContainer.FindControl("WasteOther")).ClientID%>')  ;         
                      if(value   ==   "U")
                        textbox.style.display = "block";                
                       else
                        textbox.style.display = "none";
                                     
                }                
    </script>

    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td style="height: 10px">
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
                            現在位置：<a href="#">首頁</a> &gt;&gt; <a href="#">會員註冊</a> &gt;&gt; <a href="page4A.aspx">
                                學研機構會員註冊</a></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="330">
                            <img src="image/frame/sub_title7.jpg" alt="*" width="330" height="55"></td>
                        <td width="431" background="image/frame/sub_2.jpg">
                            <table width="373" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="24%">
                                        <div align="center">
                                        </div>
                                    </td>
                                    <td width="10%">
                                        <div align="center">
                                            <img src="image/icon/arrow.gif" alt="*" width="19" height="20"></div>
                                    </td>
                                    <td width="66%" class="table_title1">
                                        <div align="right" class="subfunction_font">
                                            | <a href="page4A.aspx">學研機構會員註冊</a> | <a href="page4B.aspx">業者廠商會員註冊</a> |
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
                <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" OnCreatedUser="CreateUserWizard1_CreatedUser"
                    CreateUserButtonText="註冊完成" OnNextButtonClick="CreateUserWizard1_NextButtonClick">
                    <WizardSteps>
                        <asp:TemplatedWizardStep runat="server" StepType="Start" Title="註冊您的新帳戶" ID="UserTemplate">
                            <ContentTemplate>
                                <table width="760" height="37" border="0" align="center" cellpadding="8" cellspacing="1"
                                    bgcolor="#666600" class="mtable">
                                    <tr bgcolor="#a2cad2" height="57">
                                        <td colspan="2" bgcolor="#d2aaa2" class="font1213-1" style="height: 30px">
                                            <img src="image/icon/page_edit.png" alt="填寫相關資料" width="16" height="16" align="absMiddle">
                                            <span class="form_title1">請詳細填寫相關資料：(以利加速審核流程)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ※
                                                為必填欄位</span></td>
                                    </tr>
                                    <tr bgcolor="#e4f1e9" height="37">
                                        <td width="162" bgcolor="#f1e4ec" class="table_title1" align="left">
                                            <span class="style1">※</span> 帳號</td>
                                        <td width="555" bgcolor="#f1e4ec" class="font1213-1" align="left">
                                            <asp:TextBox ID="UserName" runat="server" Columns="8" MaxLength="8"></asp:TextBox>
                                            (<span class="style1">需為６～８碼英文字母、數字之組合</span>)
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                ErrorMessage="必須提供帳號。" ToolTip="必須提供帳號。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="UserName"
                                                ValidationExpression="^[a-zA-Z0-9]{6,8}$" runat="server" ErrorMessage="帳號需為6~8碼英文字母、數字之組合。"
                                                ToolTip="需為6~8碼英文字母、數字之組合。" SetFocusOnError="True" ValidationGroup="CreateUserWizard1">*</asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="UserName"
                                                ValidationExpression="((.*[0-9])(.*[A-Za-z]))|((.*[A-Za-z])(.*[0-9]))" runat="server"
                                                ErrorMessage="帳號至少有一個英文字母、數字。" ToolTip="至少有一個英文字母、數字。" SetFocusOnError="True"
                                                ValidationGroup="CreateUserWizard1">*</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr bgcolor="#f2f9f4" height="37">
                                        <td bgcolor="#f9f2f7" class="table_title1" align="left" style="height: 37px">
                                            <span class="style1">※</span> 密碼</td>
                                        <td bgcolor="#f9f2f7" class="font1213-1" align="left" style="height: 37px">
                                            密 碼
                                            <asp:TextBox ID="Password" runat="server" TextMode="Password" Columns="8" MaxLength="8" ></asp:TextBox>
                                            (<span class="style1">8碼數字</span>)
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                ErrorMessage="必須提供密碼。" ToolTip="必須提供密碼。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="Password"
                                                ValidationExpression="^[0-9]{8}$" runat="server" ErrorMessage="密碼需為8碼數字。" ToolTip="密碼需為8碼數字。"
                                                SetFocusOnError="True" ValidationGroup="CreateUserWizard1">*</asp:RegularExpressionValidator>
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
                                            <span class="style1">※</span> 學校系所 / 研究單位名稱
                                        </td>
                                        <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                            <asp:TextBox ID="Corp" runat="server" Columns="25"></asp:TextBox><asp:RequiredFieldValidator
                                                ID="CorpRequired" runat="server" ControlToValidate="Corp" ErrorMessage="必須提供單位名稱。"
                                                ToolTip="必須提供單位名稱。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr bgcolor="#f2f9f4">
                                        <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                            <span class="style1">※</span> 地址</td>
                                        <td bgcolor="#f9f2f7" class="font1213-1" align="left">
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
                                    <tr bgcolor="#e4f1e9">
                                        <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                            <span class="style1">※</span> 會員姓名</td>
                                        <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                            <asp:TextBox ID="Name" runat="server" Columns="10"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="NameRequired" runat="server" ControlToValidate="Name"
                                                ErrorMessage="必須提供會員姓名。" ToolTip="必須提供會員姓名。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr bgcolor="#f2f9f4">
                                        <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                            <span class="style1">※</span> 連絡電話</td>
                                        <td bgcolor="#f9f2f7" class="font1213-1" align="left">
                                            <asp:TextBox ID="Tel" runat="server" Columns="15" MaxLength="25"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="TelRequired" runat="server" ControlToValidate="Tel"
                                                ErrorMessage="必須提供連絡電話。" ToolTip="必須提供連絡電話。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr bgcolor="#e4f1e9">
                                        <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                            <span class="style1">※</span> 傳真</td>
                                        <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                            <asp:TextBox ID="Fax" runat="server" Columns="15" MaxLength="25"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="FaxRequired" runat="server" ControlToValidate="Fax"
                                                ErrorMessage="必須提供會員姓名。" ToolTip="必須提供會員姓名。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr bgcolor="#e4f1e9">
                                        <td bgcolor="#f9f2f7" class="table_title1" align="left">
                                            <span class="style1">※</span> 電子信箱
                                        </td>
                                        <td bgcolor="#f9f2f7" class="font1213-1" align="left">
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
                                        <td bgcolor="#f1e4ec" class="table_title1" align="left">
                                            <span class="style1">※</span> 單位屬性
                                        </td>
                                        <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                            <label>
                                                <asp:DropDownList ID="Kind" runat="server">
                                                    <asp:ListItem Value="">請選擇...</asp:ListItem>
                                                    <asp:ListItem Value="A">學術單位</asp:ListItem>
                                                    <asp:ListItem Value="B">研究單位</asp:ListItem>
                                                    <asp:ListItem Value="C">其他</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Kind"
                                                    ErrorMessage="單位屬性必填請選擇…以外的選單。" ToolTip="單位屬性必填請選擇…以外的選單。" ValidationGroup="CreateUserWizard1"
                                                    InitialValue="">*</asp:RequiredFieldValidator>
                                            </label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="color: red" colspan="2">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr bgcolor="#e4f1e9">
                                        <td colspan="2" bgcolor="#a996af" class="table_title1">
                                            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#663333"
                                                class="font1213-1">
                                                <tr>
                                                    <td colspan="7" bgcolor="#f1e4ec">
                                                        <div align="center" class="title2">
                                                            資源再生技術研發現況</div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td nowrap bgcolor="#f1e4ec" class="table_title1">
                                                        <div align="center">
                                                            <span class="style1">※</span> 再生技術名稱</div>
                                                    </td>
                                                    <td nowrap bgcolor="#f1e4ec" class="table_title1">
                                                        <div align="center">
                                                            <span class="style1">※</span> 再生技術方法</div>
                                                    </td>
                                                    <td nowrap bgcolor="#f1e4ec" class="table_title1">
                                                        <div align="center">
                                                            <span class="style1">※</span> 廢棄物種類</div>
                                                    </td>
                                                    <td nowrap bgcolor="#f1e4ec" class="table_title1">
                                                        <div align="center">
                                                            <span class="style1">※ </span>廢棄物名稱</div>
                                                    </td>
                                                    <td nowrap bgcolor="#f1e4ec" class="table_title1">
                                                        <div align="center">
                                                            再生產品名稱</div>
                                                    </td>
                                                    <td nowrap bgcolor="#f1e4ec" class="table_title1">
                                                        <div align="center">
                                                            <span class="style1">※ </span>研究情形</div>
                                                    </td>
                                                    <td nowrap bgcolor="#f1e4ec" class="table_title1">
                                                        <div align="center">
                                                            申請之相關專利</div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td bgcolor="#f9f2f7">
                                                        <asp:TextBox ID="TechName" runat="server" Columns="8"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="TechNameRequired" runat="server" ControlToValidate="TechName"
                                                            ErrorMessage="必須提供再生技術名稱。" ToolTip="必須提供再生技術名稱。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator></td>
                                                    <td bgcolor="#f9f2f7">
                                                        <div align="center">
                                                            <asp:DropDownList ID="TechItem" runat="server">
                                                                <asp:ListItem Value="">請選擇...</asp:ListItem>
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
                                                            <asp:TextBox ID="TechOther" runat="server" Columns="10" Style="display: none;"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TechItem"
                                                                ErrorMessage="再生技術方法必填請選擇…以外的選單。" ToolTip="再生技術方法必填請選擇…以外的選單。" ValidationGroup="CreateUserWizard1"
                                                                InitialValue="">*</asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td bgcolor="#f9f2f7">
                                                        <div align="center">
                                                            <asp:DropDownList ID="WasteItem" runat="server">
                                                                <asp:ListItem Value="">請選擇...</asp:ListItem>
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
                                                            <asp:TextBox ID="WasteOther" runat="server" Columns="10" Style="display: none;"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="WasteItem"
                                                                ErrorMessage="廢棄物種類必填請選擇…以外的選單。" ToolTip="廢棄物種類必填請選擇…以外的選單。" ValidationGroup="CreateUserWizard1"
                                                                InitialValue="">*</asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td bgcolor="#f9f2f7">
                                                        <asp:TextBox ID="WasteName" runat="server" Columns="6"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="WasteNameRequired" runat="server" ControlToValidate="WasteName"
                                                            ErrorMessage="必須提供廢棄物名稱。" ToolTip="必須提供廢棄物名稱。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td bgcolor="#f9f2f7">
                                                        <div align="center">
                                                            <label>
                                                                <asp:TextBox ID="ReuseName" runat="server" Columns="5"></asp:TextBox>
                                                            </label>
                                                        </div>
                                                    </td>
                                                    <td bgcolor="#f9f2f7">
                                                        <label>
                                                            <asp:DropDownList ID="ResearchItem" runat="server">
                                                                <asp:ListItem Value="">請選擇...</asp:ListItem>
                                                                <asp:ListItem Value="A">已完成</asp:ListItem>
                                                                <asp:ListItem Value="B">研發中</asp:ListItem>
                                                                <asp:ListItem Value="C">擬新增</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ResearchItem"
                                                                ErrorMessage="研究情形必填請選擇…以外的選單。" ToolTip="研究情形必填請選擇…以外的選單。" ValidationGroup="CreateUserWizard1"
                                                                InitialValue="">*</asp:RequiredFieldValidator>
                                                        </label>
                                                    </td>
                                                    <td bgcolor="#f9f2f7">
                                                        <div align="center">
                                                            <label>
                                                                <asp:TextBox ID="Patent" runat="server" Columns="5"></asp:TextBox>
                                                            </label>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td bgcolor="#f1e4ec" class="table_title1">
                                                        <span class="style1">※</span> 再生技術特點</td>
                                                    <td colspan="6" bgcolor="#f9f2f7" align="left">
                                                        &nbsp;
                                                        <asp:TextBox ID="TechAdv" runat="server" Rows="5" TextMode="MultiLine" Columns="70"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="TechAdvRequired" runat="server" ControlToValidate="TechAdv"
                                                            ErrorMessage="必須提供再生技術特點。" ToolTip="必須提供再生技術特點。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td bgcolor="#f1e4ec" class="table_title1">
                                                        <span class="style1">※</span> 再生技術簡介</td>
                                                    <td colspan="6" bgcolor="#f9f2f7" align="left">
                                                        &nbsp;
                                                        <asp:TextBox ID="TechDesc" runat="server" Rows="5" TextMode="MultiLine" Columns="70"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="TechDescRequired" runat="server" ControlToValidate="TechDesc"
                                                            ErrorMessage="必須提供再生技術簡介。" ToolTip="必須提供再生技術簡介。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr bgcolor="#e4f1e9">
                                        <td colspan="2" align="center" bgcolor="#f1e4ec" class="table_title1">
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <CustomNavigationTemplate>
                                <table border="0" cellspacing="5" style="width: 100%; height: 100%">
                                    <tr>
                                        <td align="center" colspan="0">
                                            <asp:Button ID="StartNextButton" runat="server" CommandName="MoveNext" Text="填寫完畢" tabindex= "1"  onkeypress=""
                                                ValidationGroup="CreateUserWizard1" />
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
                                            <img src="image/icon/page_edit.png" alt="填寫相關資料" width="16" height="16" align="absMiddle">
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
                                            <span class="style1">※</span> 學校系所 / 研究單位名稱
                                        </td>
                                        <td bgcolor="#f1e4ec" class="font1213-1" align="left">
                                            <asp:Label ID="Corp" runat="server">
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
                                    <tr bgcolor="#e4f1e9">
                                        <td colspan="2" bgcolor="#a996af" class="table_title1">
                                            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#663333"
                                                class="font1213-1">
                                                <tr>
                                                    <td colspan="7" bgcolor="#f1e4ec">
                                                        <div align="center" class="title2">
                                                            資源再生技術研發現況</div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td nowrap bgcolor="#f1e4ec" class="table_title1">
                                                        <div align="center">
                                                            <span class="style1">※</span> 再生技術名稱</div>
                                                    </td>
                                                    <td nowrap bgcolor="#f1e4ec" class="table_title1">
                                                        <div align="center">
                                                            <span class="style1">※</span> 再生技術方法</div>
                                                    </td>
                                                    <td nowrap bgcolor="#f1e4ec" class="table_title1">
                                                        <div align="center">
                                                            <span class="style1">※</span> 廢棄物種類</div>
                                                    </td>
                                                    <td nowrap bgcolor="#f1e4ec" class="table_title1">
                                                        <div align="center">
                                                            <span class="style1">※ </span>廢棄物名稱</div>
                                                    </td>
                                                    <td nowrap bgcolor="#f1e4ec" class="table_title1">
                                                        <div align="center">
                                                            <span class="style1">※ </span>再生產品名稱</div>
                                                    </td>
                                                    <td nowrap bgcolor="#f1e4ec" class="table_title1">
                                                        <div align="center">
                                                            <span class="style1">※ </span>研究情形</div>
                                                    </td>
                                                    <td nowrap bgcolor="#f1e4ec" class="table_title1">
                                                        <div align="center">
                                                            <span class="style1">※ </span>申請之相關專利</div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td bgcolor="#f9f2f7">
                                                        <div align="center">
                                                            <asp:Label ID="TechName" runat="server">
                                                            </asp:Label>
                                                        </div>
                                                    </td>
                                                    <td bgcolor="#f9f2f7">
                                                        <div align="center">
                                                            <asp:Label ID="TechItem" runat="server">
                                                            </asp:Label>
                                                        </div>
                                                    </td>
                                                    <td bgcolor="#f9f2f7">
                                                        <div align="center">
                                                            <asp:Label ID="WasteItem" runat="server">
                                                            </asp:Label>
                                                        </div>
                                                    </td>
                                                    <td bgcolor="#f9f2f7">
                                                        <div align="center">
                                                            <asp:Label ID="WasteName" runat="server">
                                                            </asp:Label>
                                                        </div>
                                                    </td>
                                                    <td bgcolor="#f9f2f7">
                                                        <div align="center">
                                                            <asp:Label ID="ReuseName" runat="server">
                                                            </asp:Label>
                                                        </div>
                                                    </td>
                                                    <td bgcolor="#f9f2f7">
                                                        <div align="center">
                                                            <asp:Label ID="ResearchItem" runat="server">
                                                            </asp:Label>
                                                        </div>
                                                    </td>
                                                    <td bgcolor="#f9f2f7">
                                                        <div align="center">
                                                            <asp:Label ID="Patent" runat="server">
                                                            </asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td bgcolor="#f1e4ec" class="table_title1">
                                                        <span class="style1">※</span> 再生技術特點</td>
                                                    <td colspan="6" bgcolor="#f9f2f7" align="left">
                                                        &nbsp;
                                                        <asp:Label ID="TechAdv" runat="server">
                                                        </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td bgcolor="#f1e4ec" class="table_title1">
                                                        <span class="style1">※</span> 再生技術簡介</td>
                                                    <td colspan="6" bgcolor="#f9f2f7" align="left">
                                                        &nbsp;<asp:Label ID="TechDesc" runat="server">
                                                        </asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr bgcolor="#e4f1e9">
                                        <td colspan="2" align="center" bgcolor="#f1e4ec" class="table_title1">
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
</asp:Content>