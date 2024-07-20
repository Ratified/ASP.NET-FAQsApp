namespace ASP.net_FAQQs_APP.Models
{
    public class Topic
    {
        public string TopicId { get; set; } // Primary key
        public string Name { get; set; } = string.Empty;
        public ICollection<FAQ> FAQs { get; set; } // Navigation property

        // Constructor to initialize the navigation property
        public Topic()
        {
            FAQs = new List<FAQ>();
        }
    }
}
