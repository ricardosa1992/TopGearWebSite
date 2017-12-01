using System;
using System.Net.Mail;
using System.Net.Mime;

namespace Trabalho20172.Utils
{
    public class Email
    {
        public static bool EnviarEmail(string EmailDestinatario, string EmailCopy, string CorpoEmail, string Assunto)
        {
            //Envia o e-mail
            try
            {
                //Setando os parâmetros do envio
                MailMessage mail = new MailMessage();
                mail.Subject = Assunto;
                mail.Body = CorpoEmail;
                mail.IsBodyHtml = true;

                if (!string.IsNullOrEmpty(EmailDestinatario))
                {
                    mail.To.Add(EmailDestinatario);

                }
                mail.From = new MailAddress("TesteEmailSox@gmail.com","TopGear Rental Car");
                AlternateView view = AlternateView.CreateAlternateViewFromString(CorpoEmail, null, MediaTypeNames.Text.Html);
                mail.AlternateViews.Add(view);
                
                //Configurando o Servidor de Envio
                SmtpClient smtp = new SmtpClient();
                //smtp.Host = "smtp.gmail.com";
                //smtp.Port = 587;
                //smtp.EnableSsl = true;
                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = new System.Net.NetworkCredential("TesteEmailSox@gmail.com", "19929121");
                
                smtp.Send(mail);

                return true;
            }
            catch (Exception erro)
            {
                return false;
            }

        }

    }
}