using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace OpenRA.ResourceCenter.Web.Pages
{
    public class SigninModel : PageModel
    {
        private readonly ILogger<MapsModel> _logger;

        public SigninModel(ILogger<MapsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
