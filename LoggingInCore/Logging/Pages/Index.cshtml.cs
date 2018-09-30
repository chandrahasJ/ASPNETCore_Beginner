using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Logging.Pages
{
    public class IndexModel : PageModel
    {
        public ILogger<IndexModel> logger;
        public IndexModel(ILogger<IndexModel> _logger)
        {
            logger = _logger;
        }
        public void OnGet()
        {
            logger.LogCritical("OnGet Called");
            logger.LogInformation("We are having fun with logging");
        }
    }
}
