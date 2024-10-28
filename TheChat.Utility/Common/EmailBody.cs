namespace TheChat.Utility.Common
{
    public static class EmailBody
    {

        public static string EmailMSGHeader()
        {
            return "<div style='background-color: rgb(242,242,242);padding: 25px;border-radius: 5px;'>" + Environment.NewLine +
                    "<table style='margin: auto;' width='100%' cellspacing='0' cellpadding='5' border='0'>" + Environment.NewLine +
                    "<thead><tr style='background-color: #161616;color:#fff;'><td style='text-align: center;' align='center'>" + Environment.NewLine +
                    "<a href='https://www.thechat.com' target='_blank'> <img src=cid:namesappLogo style='width: 50px;display: block;margin:10px auto 0px;height:50px;border-radius:50%;padding:10px;' alt='namesapp_logo'></a>" + Environment.NewLine +
                    "</td></tr><tr style='background-color:#161616;color:#fef7ed;'><td><p style='margin-bottom:5px;margin-top:0;padding:0px;color: #63c15b;font-family: Arial, sans-serif;font-size: 20.0px;text-align:center;display: block;font-weight: bold;font-family:arial black'>TheChat</p>" + Environment.NewLine +
                    "</td></tr></thead>";
        }

        public static string EmailMSGFooter()
        {
            return "<tfoot><tr style='background-color: #161616;color:#63c15b;'>" + Environment.NewLine +
                    "<td style='padding:0px;'><p style='margin:0;padding:5px;color: #63c15b;font-family: Arial, sans-serif;font-size: 12.0px;text-align:center;display: block;font-weight: bold;font-family:arial'>&copy; " + DateTime.Now.Year + " thechat.com, all rights reserved. </p>" + Environment.NewLine +
                    "</td></tr><tr><td style='text-align: center;padding-bottom: 0px;'>" + Environment.NewLine +
                    "</td></tr><tr><td style='text-align: center;padding:0px 5px;'>" + Environment.NewLine +
                    "<p style='margin:0;color: #333333;font-family: Arial, sans-serif;font-size: 12.0px;line-height: normal;'>You are receiving this e-mail from <a style='font-family: Arial, sans-serif;color: #6885a5;font-weight: bold;' target='_blank' href='https://www.thechat.com/'>www.thechat.com.</a> This is an automated email notification," + Environment.NewLine +
                    "Please do not reply to this email.</p>" + Environment.NewLine +
                    "</td></tr></tfoot></table></div>";
        }

        public static string EmailMSGSignature()
        {
            return "<tr><td style='padding-left: 10px;padding-right:10px;'><div style='margin-top:50px'></div><p style='color: rgb(51,51,51);font-family: Arial, sans-serif;font-size: 16.0px;line-height: normal;'><b>Thank you,</b></p>" + Environment.NewLine +
                    "<p style='color: rgb(51,51,51);font-family: Arial, sans-serif;font-size: 14.0px;line-height: normal;'>TheChat Team</p>" + Environment.NewLine +
                    "<p style='margin-bottom:15px;color: rgb(51,51,51);font-family: Arial, sans-serif;font-size: 14.0px;line-height: normal;'><a style='font-family: Arial, sans-serif;color: #6885a5;font-weight: bold;' href='https://www.thechat.com/' target='_blank'>www.thechat.com</a></p>" + Environment.NewLine +
                    "</td></tr></tbody>";
        }

        public static string EmailMSGContent(string Message)
        {
            string emailMSG = EmailMSGHeader();

            emailMSG += "<tbody style='background-color:#fff;'>";

            emailMSG += Message;

            emailMSG += EmailMSGSignature();

            emailMSG += EmailMSGFooter();

            return emailMSG;
        }


        public static string UserRegistration()
        {


            string _userRegistrationMSG = "<tr><td style='padding-left: 10px;padding-right:10px;'>" + Environment.NewLine +
                                          "<p style='margin-top:15px;margin-bottom:0px;color: rgb(51,51,51);font-family: Arial, sans-serif;font-size: 16.0px;line-height: 1.7;'>" + Environment.NewLine +
                                          "<b>Hi @Model.UserName@ ,</b></p>" + Environment.NewLine +
                                          "</td></tr><tr><td style='padding-left: 10px;padding-right:10px;'>" + Environment.NewLine +
                                          "<p style='margin:0px;color: rgb(51,51,51);margin:0;font-family: Arial, sans-serif;font-size: 14.0px;line-height: 1.5;'>Great News!!!</p>" + Environment.NewLine +
                                          "</td></tr><tr><td style='padding-left: 10px;padding-right:10px;'>" + Environment.NewLine +
                                          "<p style='margin:0px;color: rgb(51,51,51);margin:0;font-family: Arial, sans-serif;font-size: 14.0px;line-height: 1.5;'>You have successfully registered with us.</p>" + Environment.NewLine +
                                          "</td></tr><tr><td style='padding-left: 10px;padding-right:10px;'>" + Environment.NewLine +
                                          "<p style='margin:0px;color: rgb(51,51,51);margin:0;font-family: Arial, sans-serif;font-size: 14.0px;line-height: 1.5;'>To active your account, click on the below link - </p>" + Environment.NewLine +
                                          "</td></tr><tr><td style='padding-left: 10px;padding-right:10px;'>" + Environment.NewLine +
                                          "<p style='margin:0px;color: rgb(51,51,51);font-family: Arial, sans-serif;font-size: 14.0px;line-height: 1.5;'><a style='font-family: Arial, sans-serif;color: #6885a5;font-weight: bold;' target='_blank' href='@Model.ActiveURL@'>Click Here</a>.</p></td></tr>" + Environment.NewLine +
                                          "<tr><td style='padding-left: 10px;padding-right:10px;'><p style='margin:0px;color: rgb(51,51,51);font-family: Arial, sans-serif;font-size: 14.0px;line-height: 1.5;'>Thank you for joining thechat.com</p></td></tr>";

            return _userRegistrationMSG;


        }

        public static string ForgotPassword()
        {


            string _forgotPasswordMSG = "<tr><td style='padding-left: 10px;padding-right:10px;'>" + Environment.NewLine +
                                          "<p style='margin-top:15px;margin-bottom:0px;color: rgb(51,51,51);font-family: Arial, sans-serif;font-size: 16.0px;line-height: 1.7;'>" + Environment.NewLine +
                                          "<b>Hi @Model.UserName@ ,</b></p></td></tr>" + Environment.NewLine +
                                          "<tr><td style='padding-left: 10px;padding-right:10px;'>" + Environment.NewLine +
                                          "<p style='color: rgb(51,51,51);font-family: Arial, sans-serif;font-size: 14.0px;line-height: 1.5;'>We have received your request to reset your password .</p>" + Environment.NewLine +
                                          "</td></tr><tr><td style='padding-left: 10px;padding-right:10px;'>" + Environment.NewLine +
                                          "<p style='color: rgb(51,51,51);font-family: Arial, sans-serif;font-size: 14.0px;line-height: 1.5;'>Reset your password now by clicking on the link below .</p>" + Environment.NewLine +
                                          "</td></tr><tr><td style='padding-left: 10px;padding-right:10px;'>" + Environment.NewLine +
                                          "<p style='color: rgb(51,51,51);font-family: Arial, sans-serif;font-size: 14.0px;line-height: 1.5;'>Reset password <a style='font-family: Arial, sans-serif;color: #6885a5;font-weight: bold;' target='_blank' href='@Model.ResetPasswordLink@'>click here</a>.</p>" + Environment.NewLine +
                                          "</td></tr><tr><td style='padding-left: 10px;padding-right:10px;'>" + Environment.NewLine +
                                          "<p style='color: rgb(51,51,51);font-family: Arial, sans-serif;font-size: 14.0px;line-height: 1.5;'>If you did not request this, we recommend resetting your password. To reset your password, go to account details .</p></td></tr>";
            return _forgotPasswordMSG;


        }

        public static string UserActivate()
        {


            string _userActivateMSG = "<tr><td style='padding-left: 10px;padding-right:10px;'>" + Environment.NewLine +
                                          "<p style='margin-top:15px;margin-bottom:0px;color: rgb(51,51,51);font-family: Arial, sans-serif;font-size: 16.0px;line-height: 1.7;'>" + Environment.NewLine +
                                          "<b>Hi @Model.UserName@ ,</b></p></td></tr>" + Environment.NewLine +
                                          "<tr><td style='padding-left: 10px;padding-right:10px;'>" + Environment.NewLine +
                                          "<p style='margin:0;color: rgb(51,51,51);font-family: Arial, sans-serif;font-size: 14.0px;line-height: 1.5;'>Your verification code - @Model.RandomNumber@ </p></td></tr>" + Environment.NewLine +
                                          "<tr><td style='padding-left: 10px;padding-right:10px;'>" + Environment.NewLine +
                                          //"<p style='margin:0;color: rgb(51,51,51);font-family: Arial, sans-serif;font-size: 14.0px;line-height: 1.5;margin:0px;'>Reset your password <a style='font-family: Arial, sans-serif;color: #6885a5;font-weight: bold;' target='_blank' href='@Model.ForgotPasswordLink@'>Click Here</a></p>" + Environment.NewLine +
                                          "</td></tr><tr><td></td></tr>" + Environment.NewLine +
                                          "<tr><td style='padding-left: 10px;padding-right:10px;'>" + Environment.NewLine +
                                          "<p style='margin:0;color: rgb(51,51,51);font-family: Arial, sans-serif;font-size: 14.0px;line-height: 1.5;'>Your Sign in detail can be found in your account details once you logged on pintube.com .</p></td></tr>" + Environment.NewLine +
                                          "<tr><td style='padding-left: 10px;padding-right:10px;'>" + Environment.NewLine +
                                          "<p style='margin:0;color: rgb(51,51,51);font-family: Arial, sans-serif;font-size: 14.0px;line-height: 1.5;'>If you did not request this code, we recommend resetting your password. To reset your password, go to account details.</p></td></tr>";


            return _userActivateMSG;


        }





    }
}
