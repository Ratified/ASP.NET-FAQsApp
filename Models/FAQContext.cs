using ASP.net_FAQQs_APP.Models;
using Microsoft.EntityFrameworkCore;
namespace ASP.net_FAQQs_APP.Models
{
    public class FAQContext:DbContext
    {
        public DbSet<FAQ> fAQs { get; set; }

        public FAQContext(DbContextOptions<FAQContext> options): base(options)
        {

        }
    }
}
