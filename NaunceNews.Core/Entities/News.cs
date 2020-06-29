namespace NaunceNews.Core.Entities
{
    public class News
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }

        public NewsPriority Priority { get; set; }
    }
}
