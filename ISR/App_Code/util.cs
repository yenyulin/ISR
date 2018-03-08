using System;
using System.Collections.Generic;
using System.Web;
using System.Net.Mail;

/// <summary>
/// util 的摘要描述
/// </summary>
public class util
{
	public util()
	{
		//
		// TODO: 在這裡新增建構函式邏輯
		//
	}

    /// <summary>
    /// 發送Email
    /// </summary>
    /// <param name="ip"></param>
    /// <returns></returns>
    public bool SendMail(string strFrame, string strTo, string strSubject, string strBody,string strCC)
    {
        bool isSend = true;
        try
        {
            MailAddress maFrom = new MailAddress(strFrame);
            MailAddress maTo = new MailAddress(strTo);
            //MailAddress maFrom = new MailAddress("ervice1@dyfood.com.tw");
            //MailAddress maTo = new MailAddress("demon74527@gmail.com");
            MailMessage mm = new MailMessage(maFrom, maTo);
            mm.Subject = strSubject;
            mm.SubjectEncoding = System.Text.Encoding.UTF8;
            mm.Body = strBody;
            mm.BodyEncoding = System.Text.Encoding.UTF8;
            mm.IsBodyHtml = true;
            if (strCC.Length > 0)
            {
                //strCC = "demon74527@gmail.com";
                mm.CC.Add(strCC);   
            }

            SmtpClient sc = new SmtpClient("smtp.tgpf.org.tw"); 
            sc.Credentials = new System.Net.NetworkCredential("recycling@tgpf.org.tw", "IDB.riw@2018");

            //SmtpClient sc = new SmtpClient("smtp.gmail.com");
            //sc.Credentials = new System.Net.NetworkCredential("service1@dyfood.com.tw", "dyfood2012");
            sc.Port = 587;
            //sc.Port = 465;
            sc.EnableSsl = true;
            
            sc.Send(mm);
        }
        catch (Exception ex)
        {
            isSend = false;
            throw ex;
        }
        return isSend;
    }
}