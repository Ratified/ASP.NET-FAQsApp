namespace ASP.net_FAQQs_APP.Models
{
    public class Category
    {
        public string CategoryId { get; set; } // Primary key
        public string Name { get; set; } = string.Empty;
        public ICollection<FAQ> FAQs { get; set; } // Navigation property

        // Constructor to initialize the navigation property
        public Category()
        {
            FAQs = new List<FAQ>();
        }
    }
}
