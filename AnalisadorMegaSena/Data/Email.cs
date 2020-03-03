using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace AnalisadorMegaSena.Data
{
    class Email
    {
        //==================
        // === VARIAVEIS ===
        //==================
        const string De = "lucas9.la2@gmail.com";
        const string Assunto = "Backup Sistema Mega Sena";
        const string Menssagem = "Segue em anexo os dados dos jogas da Mega Sena cadastrados no seu sistema.";
        const string senha = "161312lucas";
        string Para;
        string Cc = "lucas9.la2@gmail.com";        
        const bool arq = true;
        string localArq;
        public static string msg = "";

        //===================
        // === CONSTRUTOR ===
        //===================
        public Email(string Email,string ArquivoAdrees)
        {
            Para = Email;
            localArq = ArquivoAdrees;
        }

        //=====================
        // === ENVIAR EMAIL ===
        //=====================
        public bool Enviar()
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                MailMessage mail = new MailMessage();

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;                
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new System.Net.NetworkCredential(De, senha);

                mail.From = new MailAddress(De);
                mail.CC.Add(new MailAddress(Cc));                
                mail.Attachments.Add(new Attachment(localArq));
                mail.To.Add(new MailAddress(Para));
                mail.Subject = Assunto;
                mail.Body = Menssagem;                
                smtp.Send(mail);

                return true;
            }
            catch (Exception exc)
            {
                msg = exc.Message;
                return false;
            }
        }

    }
}
