using ASP.net_FAQQs_APP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP.net_FAQQs_APP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string topic = "", string category = "")
        {
            var faqs = GetFAQs();

            if (!string.IsNullOrEmpty(topic))
            {
                faqs = faqs.Where(f => f.Topic.Equals(topic, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(category))
            {
                faqs = faqs.Where(f => f.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(faqs);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private List<FAQ> GetFAQs()
        {
            return new List<FAQ>
            {
                new FAQ { Id = 1, Question = "What is Bootstrap?", Answer = "Bootstrap is a free and open-source CSS framework...", Topic = "Bootstrap", Category = "General" },
                new FAQ { Id = 2, Question = "What is C#?", Answer = "C# is a general-purpose, multi-paradigm programming language...", Topic = "C#", Category = "General" },
                new FAQ { Id = 3, Question = "What is Javascript?", Answer = "JavaScript is a programming language...", Topic = "Javascript", Category = "General" },
                new FAQ { Id = 4, Question = "When was Bootstrap First Released?", Answer = "In 2011.", Topic = "Bootstrap", Category = "History" },
                new FAQ { Id = 5, Question = "When was C# First Released?", Answer = "In 2002.", Topic = "C#", Category = "History" },
                new FAQ { Id = 6, Question = "When was Javascript First Released?", Answer = "In 1995.", Topic = "Javascript", Category = "History" }
            };
        }
    }
}