using BloggAPI.Models;

namespace BloggAPI.ViewModels
{
    public class BloggViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public BloggViewModel(Blogg blogg)
        {
            Id = blogg.Id.ToString();
            Title = blogg.Title;
            
        }
    }
    
}
