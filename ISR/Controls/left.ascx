<%@ Control Language="C#" AutoEventWireup="true" CodeFile="left.ascx.cs" Inherits="Controls_left" %>

<script type="text/JavaScript">
<!--
function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}
//-->
</script>

<table width="200" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <img src="image/frame/top2.jpg" alt="*" width="200" height="20"></td>
    </tr>
    <tr>
        <td>
            <img src="image/frame/home.jpg" alt="回首頁" width="200" height="55" border="0" usemap="#Map"></td>
    </tr>
    <tr>
        <td>
            <table width="200" border="0" align="right" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top">
                        <a href="free.aspx" title="左方區域" accesskey="L"><font class="free_r">:::</font></a></td>
                    <td background="image/frame/left2.jpg">
                        &nbsp;</td>
                    <td>
                        <a href="page1.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image15','','image/frame/btn1_on.jpg',1)"
                            onblur="MM_swapImgRestore()" onfocus="MM_swapImage('Image15','','image/frame/btn1_on.jpg',1)">
                            <img src="image/frame/btn1_off.jpg" alt="最新消息" name="Image15" width="145" height="35"
                                border="0" id="Image15" /></a></td>
                    <td background="image/frame/left3.jpg">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td width="20" valign="top">
                        &nbsp;</td>
                    <td width="25" background="image/frame/left2.jpg">
                        &nbsp;</td>
                    <td>
                        <a href="page2.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image8','','image/frame/btn9_on.jpg',1)"
                            onblur="MM_swapImgRestore()" onfocus="MM_swapImage('Image8','','image/frame/btn9_on.jpg',1)">
                            <img src="image/frame/btn9_off.jpg" alt="平台介紹" name="Image8" width="145" height="35"
                                border="0"></a></td>
                    <td width="10" background="image/frame/left3.jpg">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td width="20" valign="top">
                        &nbsp;</td>
                    <td width="25" background="image/frame/left2.jpg">
                        &nbsp;</td>
                    <td>
                        <a href="http://proj.tgpf.org.tw/riw/page6-1.asp" target="_blank" onfocus="MM_swapImage('Image7','','image/frame/btn2_on.jpg',1)"
                            onblur="MM_swapImgRestore()" onmouseover="MM_swapImage('Image7','','image/frame/btn2_on.jpg',1)"
                            onmouseout="MM_swapImgRestore()">
                            <img src="image/frame/btn2_off.jpg" alt="資源再生技術" name="Image7" width="145" height="35"
                                border="0"></a></td>
                    <td width="10" background="image/frame/left3.jpg">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td width="20" valign="top">
                        &nbsp;</td>
                    <td width="25" background="image/frame/left2.jpg">
                        &nbsp;</td>
                    <td>
                        <a href="page4.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image12','','image/frame/btn6_on.jpg',1)"
                            onblur="MM_swapImgRestore()" onfocus="MM_swapImage('Image12','','image/frame/btn6_on.jpg',1)">
                            <img src="image/frame/btn6_off.jpg" alt="會員註冊" name="Image12" width="145" height="35"
                                border="0"></a></td>
                    <td width="10" background="image/frame/left3.jpg">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td width="20" valign="top">
                        &nbsp;</td>
                    <td width="25" background="image/frame/left2.jpg">
                        &nbsp;</td>
                    <td>
                        <a href="page5.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image13','','image/frame/btn7_on.jpg',1)"
                            onblur="MM_swapImgRestore()" onfocus="MM_swapImage('Image13','','image/frame/btn7_on.jpg',1)">
                            <img src="image/frame/btn7_off.jpg" alt="會員登入" name="Image13" width="145" height="35"
                                border="0"></a></td>
                    <td width="10" background="image/frame/left3.jpg">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td width="20" valign="top">
                        &nbsp;</td>
                    <td width="25" background="image/frame/left2.jpg">
                        &nbsp;</td>
                    <td>
                        <a href="Member/Default.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image14','','image/frame/btn8_on.jpg',1)"
                            onblur="MM_swapImgRestore()" onfocus="MM_swapImage('Image14','','image/frame/btn8_on.jpg',1)">
                            <img src="image/frame/btn8_off.jpg" alt="會員專區" name="Image14" width="145" height="35"
                                border="0"></a></td>
                    <td width="10" background="image/frame/left3.jpg">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td width="20" valign="top">
                        &nbsp;</td>
                    <td width="25" background="image/frame/left2.jpg">
                        &nbsp;</td>
                    <td>
                        <a href="page7.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image9','','image/frame/btn3_on.jpg',1)"
                            onblur="MM_swapImgRestore()" onfocus="MM_swapImage('Image9','','image/frame/btn3_on.jpg',1)">
                            <img src="image/frame/btn3_off.jpg" alt="案例介紹" name="Image9" width="145" height="35"
                                border="0"></a></td>
                    <td width="10" background="image/frame/left3.jpg">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td valign="top">
                        &nbsp;</td>
                    <td background="image/frame/left2.jpg">
                        &nbsp;</td>
                    <td>
                        <a href="page8.aspx" onfocus="MM_swapImage('Image16','','image/frame/btn10_on.jpg',1)"
                            onblur="MM_swapImgRestore()" onmouseover="MM_swapImage('Image16','','image/frame/btn10_on.jpg',1)"
                            onmouseout="MM_swapImgRestore()">
                            <img src="image/frame/btn10_off.jpg" alt="媒合成果" name="Image16" width="145" height="35"
                                border="0" id="Image16" /></a></td>
                    <td background="image/frame/left3.jpg">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td width="20" valign="top">
                        &nbsp;</td>
                    <td width="25" background="image/frame/left2.jpg">
                        &nbsp;</td>
                    <td>
                        <a href="mailto:jerry@tgpf.org.tw" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image10','','image/frame/btn4_on.jpg',1)"
                            onblur="MM_swapImgRestore()" onfocus="MM_swapImage('Image10','','image/frame/btn4_on.jpg',1)">
                            <img src="image/frame/btn4_off.jpg" alt="聯絡我們" name="Image10" width="145" height="35"
                                border="0"></a></td>
                    <td width="10" background="image/frame/left3.jpg">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td width="20" valign="top">
                        &nbsp;</td>
                    <td width="25" background="image/frame/left2.jpg">
                        &nbsp;</td>
                    <td>
                        <a href="page10.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image11','','image/frame/btn5_on.jpg',1)"
                            onblur="MM_swapImgRestore()" onfocus="MM_swapImage('Image11','','image/frame/btn5_on.jpg',1)">
                            <img src="image/frame/btn5_off.jpg" alt="相關網站連接" name="Image11" width="145" height="35"
                                border="0"></a></td>
                    <td width="10" background="image/frame/left3.jpg">
                        &nbsp;</td>
                </tr>
                
                
            </table>
        </td>
    </tr>
    <tr>
        <td align="right">
            <img src="image/frame/left4.jpg" alt="*" width="180" height="20"></td>
    </tr>
    <tr>
        <td align="center" style="height:30px">
             到訪人數：<asp:Label ID="lblCounter" runat="server"></asp:Label></td>
    </tr>
    
</table>
<map name="Map" id="Map">
    <area shape="rect" coords="42,16,126,42" href="Default.aspx" alt="回首頁" />
</map>
