using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
namespace TheChat.Utility.Common
{

    public class EmailHelper
    {

        public bool SendEmail(EmailModel emailModel)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(emailModel.To);
                if (!string.IsNullOrEmpty(emailModel.CC))
                {
                    mail.CC.Add(emailModel.CC);
                }
                
                mail.From = new MailAddress(AppSettings.EmailFrom, AppSettings.EmailAlias, System.Text.Encoding.UTF8);
                mail.IsBodyHtml = true;
                mail.Subject = emailModel.Subject;
                //mail.Body = EmailBody.EmailMSGContent(emailModel.Message);
                mail.AlternateViews.Add(AddPintubeLogoHeader(EmailBody.EmailMSGContent(emailModel.Message)));
                mail.BodyEncoding = Encoding.UTF8;
                mail.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(AppSettings.EmailFrom, AppSettings.EmailPass);
                client.Port = AppSettings.EmailPort;
                client.Host = AppSettings.EmailHost;
                client.EnableSsl = AppSettings.EmailEnableSsl;
                client.Timeout = 2000000;
                client.Send(mail);
                mail.Dispose();
                return true;
            }
            catch
            {
                throw;
            }
        }


        public bool SendEmailWithImage(EmailModel emailModel, string id, string from, string path = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(emailModel.To);
                if (!string.IsNullOrEmpty(emailModel.CC))
                {
                    mail.Bcc.Add(emailModel.CC);
                }
                mail.From = new MailAddress(AppSettings.EmailFrom, AppSettings.EmailAlias, System.Text.Encoding.UTF8);
                mail.IsBodyHtml = true;
                mail.Subject = emailModel.Subject;
                mail.AlternateViews.Add(SetImageinCard(EmailBody.EmailMSGContent(emailModel.Message), id, from, path));
                mail.BodyEncoding = Encoding.UTF8;
                mail.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(AppSettings.EmailFrom, AppSettings.EmailPass);
                client.Port = AppSettings.EmailPort;
                client.Host = AppSettings.EmailHost;
                client.EnableSsl = AppSettings.EmailEnableSsl;
                client.Timeout = 2000000;
                client.Send(mail);
                mail.Dispose();
                return true;
            }
            catch
            {
                throw;
            }
        }

        private AlternateView SetImageinCard(string message, string id, string from,string path = null)
        {
            string _Path =  "";

            //if (from == MailFrom.ShareVisitingCard)
            //{
            //    _Path = "Documents/UserCard/" + id + "/VisitingCard" + id + ".png";
            //}
            //if (from == MailFrom.ShareRecommendationCard)
            //{
            //    _Path = "Documents/UserCard/" + id + "/Recommendation_" + id + ".png";
            //}
            //if (from == MailFrom.ShareJobCard)
            //{
            //    _Path = "Documents/JobCard/" + id + "/JobCard" + id + ".png";
            //}

            //if((from == MailFrom.BookOnetoOneMentor || from == MailFrom.BookOnetoOneMentee || from == MailFrom.PaymentConfirmation) && path != null)
            //{
            //    _Path = path;
            //}

            LinkedResource Img = new LinkedResource(_Path, "image/png");
            Img.ContentId = "pintubetalk";
            LinkedResource Logo = new LinkedResource("TheChatDocuments/pintube_logo.png", "image/png");
            Logo.ContentId = "namesappLogo";
            AlternateView AV =
            AlternateView.CreateAlternateViewFromString(message, null, MediaTypeNames.Text.Html);
            AV.LinkedResources.Add(Img);
            AV.LinkedResources.Add(Logo);
            return AV;
        }

        private AlternateView AddPintubeLogoHeader(string Message)
        {
            LinkedResource talkImage = new LinkedResource("TheChatDocuments/talk.png", "image/png");
            talkImage.ContentId = "pintubetalk";
            LinkedResource Img = new LinkedResource("TheChatDocuments/pintube_logo.png", "image/png");
            Img.ContentId = "namesappLogo";
            AlternateView AV =
            AlternateView.CreateAlternateViewFromString(Message, null, MediaTypeNames.Text.Html);
            AV.LinkedResources.Add(Img);
            if (Message.Contains("cid:pintubetalk"))
            {
                AV.LinkedResources.Add(talkImage);
            }
            return AV;
        }


    }




    public class EmailModel
    {
        public EmailModel(string to, string subject, string message,string cc = "")
        {

            To = to;
            CC = cc;
            Subject = subject;
            Message = message;
        }

        public string To
        {
            get;
        }

        public string CC
        {
            get;
        }
        public string Subject
        {
            get;
        }
        public string Message
        {
            get;
        }
    }
}
