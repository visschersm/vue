using DataLayer.Entities;

namespace ViewModels.Blogs
{
    public class Full : PrimaryKeyBase<Blog>
    {
        public string Title { get; set; } = string.Empty;
    }
}
