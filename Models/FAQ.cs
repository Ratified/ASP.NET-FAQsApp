namespace ASP.net_FAQQs_APP.Models
{
    public class FAQ
    {
        public int Id { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public string Topic { get; set; } = string.Empty; 
        public string Category { get; set; } = string.Empty; 
    }
}
