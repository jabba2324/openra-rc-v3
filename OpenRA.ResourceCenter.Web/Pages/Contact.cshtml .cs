using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OpenRA.ResourceCenter.Web.Pages;

namespace OpenRA.ResourceCenter.WebrceCenter.Web.Pages
{
    public class ContactModel : PageModel
    {
        private readonly ILogger<MapsModel> _logger;

        public ContactModel(ILogger<MapsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
