using System.Threading.Tasks;

namespace OpenRA.ResourceCenter.Web.Providers
{
    public interface ISmtpClient
    {
        Task SendEmail(string subject, string message, string fromAddress);
    }
}