using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Microsoft.Extensions.Options;
using OpenRA.ResourceCenter.Web.Options;

namespace OpenRA.ResourceCenter.Web.Providers
{
    public class SmtpClient : ISmtpClient
    {
        private readonly IAmazonSimpleEmailService _smtpClient;
        private readonly string _adminEamilAddress;
        
        public SmtpClient(IAmazonSimpleEmailService smtpClient, IOptions<AdminOptions> adminOptions)
        {
            _smtpClient = smtpClient;
            _adminEamilAddress = adminOptions.Value.AdminEmailAddress;
        }

        public async Task SendEmail(string fromAddress, string subject, string message)
        {
            var sendRequest = new SendEmailRequest
            {
                Source = fromAddress,
                Destination = new Destination
                {
                    ToAddresses =
                        new List<string> { _adminEamilAddress }
                },
                Message = new Message
                {
                    Subject = new Content(subject),
                    Body = new Body
                    {
                        Text = new Content
                        {
                            Charset = "UTF-8",
                            Data = message
                        }
                    }
                }
            };
            
            var response = await _smtpClient.SendEmailAsync(sendRequest);
        }
        
    }
}