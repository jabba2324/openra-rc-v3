using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace OpenRA.ResourceCenter.Web.Pages
{
    public class MapsModel : PageModel
    {
        private readonly ILogger<MapsModel> _logger;

        public MapsModel(ILogger<MapsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
