using DataLayer.Entities;

namespace ViewModels.Blogs
{
    public class List : PrimaryKeyBase<Blog>
    {
        public string Title { get; set; } = string.Empty;
    }
}
