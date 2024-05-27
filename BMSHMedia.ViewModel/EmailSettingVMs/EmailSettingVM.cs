using BMSHMedia.Model.Email;
using LinqKit;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace BMSHMedia.ViewModel.EmailSettingVMs
{
    public class EmailSettingVM : BaseCRUDVM<EmailSetting>
    {
        protected override void InitVM()
        {
            Entity = DC.Set<EmailSetting>().FirstOrDefault();
        }

        public override void DoAdd()
        {
            try
            {
                var old = DC.Set<EmailSetting>().ToList();
                if (old != null)
                {
                    foreach (var item in old)
                    {
                        DC.DeleteEntity(item);
                    }
                }

                DC.AddEntity(Entity);
                DC.SaveChanges();
            }
            catch (Exception ex)
            {
                MSD.AddModelError("", ex.Message);
            }
        }

        #region MyRegion
        public async Task SendEmail(string subject, string bodyText)
        {
            try
            {
                if (Entity == null)
                {
                    throw new Exception("EmailSetting is null");
                }

                string[] to;

                if (Entity.EmailTo.Contains(';'))
                {
                    to = Entity.EmailTo.Split(';');
                }
                else
                {
                    to = [Entity.EmailTo];
                }

                using var message = new MimeMessage();
                message.From.Add(new MailboxAddress(Entity.EmailFrom, Entity.EmailFrom));

                to.ForEach(item => {
                    message.To.Add(new MailboxAddress("", item));
                });

                message.Subject = subject;
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = bodyText;
                message.Body = bodyBuilder.ToMessageBody();

                using var client = new SmtpClient();
                await client.ConnectAsync(Entity.SmtpHost, Entity.SmtpPort, true);
                await client.AuthenticateAsync(Entity.Account, Entity.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                Wtm.DoLog(ex.Message, ActionLogTypesEnum.Exception, moduleName: nameof(EmailSettingVM));
            }
        }
        #endregion
    }
}
