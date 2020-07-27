using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OpenRA.ResourceCenter.Web.Dtos;
using OpenRA.ResourceCenter.Web.Providers;

namespace OpenRA.ResourceCenter.Web.Pages
{
    public class ContactModel : PageModel
    {
        private readonly ISmtpClient _smtpClient;
        private readonly ILogger<MapsModel> _logger;

        [BindProperty]
        public Email Email { get; set; }
        
        public ContactModel(ILogger<MapsModel> logger, ISmtpClient smtpClient)
        {
            _logger = logger;
            _smtpClient = smtpClient;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _smtpClient.SendEmail(Email.EmailAddress, Email.Subject, Email.Message);
            return Page();
        }
    }
}
