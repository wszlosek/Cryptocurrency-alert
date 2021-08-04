using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cryptocurrency_alert.App_Start;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Cryptocurrency_alert.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }

        [BindProperty]
        public string EmailAddress { get; set; }
        public void OnPost()
        {
            EmailSending(EmailAddress);
        }

        public void EmailSending(string address)
        {
            MailSending m = new MailSending();
            m.AssignContacts(aTo: address);
            m.AssignContent();
            m.SendMail();
        }

    }

}
