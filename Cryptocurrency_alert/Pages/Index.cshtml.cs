using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Cryptocurrency_alert.App_Start;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Analysis;
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
        [BindProperty]
        public List<string> IsChecked { get; set; }
        [BindProperty]
        public string mainCurrency { get; set; }

        public void OnPost()
        {

            Financial_data xd = new Financial_data();
          //  Console.WriteLine(EmailAddress);

         //   IsChecked.RemoveAll(t => t == "false");

         //   IsChecked.ForEach(Console.WriteLine);

         //   Console.WriteLine(mainCurrency);

            // var doc = new pdfDocument(); 
            // EmailSending(EmailAddress);
        }

        
        public void EmailSending(string address)
        {
            MailSending m = new MailSending();
            m.AssignContacts(aTo: address);
            m.AssignContent(@"Hi! Thank you for using my website," +
                "\n \n" +
                "--Wojciech Szlosek");
            m.SendMail();
        }

        
    }

}
