﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace OpenRA.ResourceCenter.Web.Pages
{
    public class FaqModel : PageModel
    {
        private readonly ILogger<MapsModel> _logger;

        public FaqModel(ILogger<MapsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
