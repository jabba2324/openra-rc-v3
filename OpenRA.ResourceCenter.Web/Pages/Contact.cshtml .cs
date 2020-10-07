using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OpenRA.ResourceCenter.Web.Dtos;
using OpenRA.ResourceCenter.Web.Providers;
using OpenRA.ResourceCenter.Web.Validators;

namespace OpenRA.ResourceCenter.Web.Pages
{
    public class ContactModel : PageModel
    {
        private readonly ISmtpClient _smtpClient;
        private readonly ILogger<MapsModel> _logger;
        private readonly EmailValidator _validator;

        [BindProperty]
        public Email Email { get; set; }

        public ContactModel(ILogger<MapsModel> logger, ISmtpClient smtpClient)
        {
            _logger = logger;
            _smtpClient = smtpClient;
            _validator = new EmailValidator();
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var result = await _validator.ValidateAsync(Email);

            if (result.IsValid)
            {
                await _smtpClient.SendEmail(Email.EmailAddress, Email.Subject, Email.Message);
                
                ViewData["FormMessage"] = "Message sent comrade!";
                ViewData["FormSuccess"] = result.IsValid;
            }
            else
            {
                ViewData["FormMessage"] = result.Errors.First().ErrorMessage;
                ViewData["FormSuccess"] = result.IsValid;
            }
            
            return Page();
        }
    }
}
