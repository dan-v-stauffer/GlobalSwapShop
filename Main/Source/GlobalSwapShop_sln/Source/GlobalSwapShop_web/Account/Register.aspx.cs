using GlobalSwapShop;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Register : GlobalPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Label lbl = (Label)Utilities.FindControl(this.RegisterUser.Controls, "lblSetPasswordLenErr");
        lbl.Text = String.Format(this.GetGlobalResourceObject("GlobalSwapShop", "SET_PASSWORD_LEN_ERR").ToString(), Membership.MinRequiredPasswordLength);

        RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];

        LinkButton upAvatarTrigger = (LinkButton)this.RegisterUser.
            FindControl("RegisterUserWizardStep").Controls[0].FindControl("upAvatarTrigger");

        ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(upAvatarTrigger);
       
        if (Session["registrationAvatar"] != null)
        {
            if (Session["registrationAvatar"].ToString() != "")
            {
                this.imgUserAvatar.ImageUrl = Session["registrationAvatar"].ToString();
                
            }
        }
    }


    protected void CaptchaCheck(Object sender, ServerValidateEventArgs args)
    {
        string captchaEntered = (string)args.Value;
        SupportControls._support_Captcha_CaptchaControl captcha =
            (SupportControls._support_Captcha_CaptchaControl)Utilities.FindControl(this.Controls, "captchaControlRegistration");

        args.IsValid = captcha.isValid;
    }

    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
        FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);


        MembershipUser newUser = Membership.GetUser(RegisterUser.UserName);
        Roles.AddUserToRole(newUser.UserName, "barter_premium"); 
        Guid newUserId = (Guid)newUser.ProviderUserKey;

        webAppCmd addUser = new webAppCmd("sp_web_addUser", System.Data.CommandType.StoredProcedure);

        addUser.Command.Parameters.Add(new SqlParameter("UserId", SqlDbType.UniqueIdentifier));
        addUser.Command.Parameters.Add(new SqlParameter("UserAvatar", SqlDbType.Image));
        addUser.Command.Parameters.Add(new SqlParameter("UserCountryCode", SqlDbType.NVarChar, 2));
        addUser.Command.Parameters.Add(new SqlParameter("UserPostCode", SqlDbType.NVarChar, 30));
        addUser.Command.Parameters.Add(new SqlParameter("error", SqlDbType.Int));
        addUser.Command.Parameters["error"].Direction = ParameterDirection.Output;

        addUser.Command.Parameters["UserId"].Value = newUserId;

        byte[] avatarBinary;
        try
        {
            avatarBinary = (byte[])HttpRuntime.Cache[Session["registrationAvatarBinaryID"].ToString()];
        }
        catch(Exception ex)
        {
            avatarBinary = null;
        }

        addUser.Command.Parameters["UserAvatar"].Value = avatarBinary;
        addUser.Command.Parameters["UserCountryCode"].Value = ((DropDownList) Utilities.FindControl(this.Controls, "Country")).SelectedValue;
        addUser.Command.Parameters["UserPostCode"].Value = ((TextBox)Utilities.FindControl(this.Controls, "PostCode")).Text;

        addUser.Command.ExecuteNonQuery();


        MailMessage message = new MailMessage(); 
        message.From = new MailAddress("webmaster@globalswapshop.com");
        message.To.Add(new MailAddress(newUser.Email)); 
        message.CC.Add(new MailAddress("dan.stauffer@att.net"));
        message.CC.Add(new MailAddress("tidowty@yahoo.com"));
        message.CC.Add(new MailAddress("hammond14@cox.net"));
        
        message.Subject = "GlobalSwapShop Auto-Email Test: Added user '" + newUser.UserName + "'"; 
        message.Body = "Hey! We just registered a user!! This email was automatically generated and sent through our globalshoop.com email account.";

        SmtpClient smtp = new SmtpClient("smtpout.secureserver.net", 80);
        smtp.Credentials = new System.Net.NetworkCredential("webmaster@globalswapshop.com", "barter!@#$1234"); 
        smtp.EnableSsl = false;
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp.Send(message); 


        string continueUrl = RegisterUser.ContinueDestinationPageUrl;
        if (String.IsNullOrEmpty(continueUrl))
        {
            continueUrl = "~/";
        }
        Response.Redirect(continueUrl);
    }



}
