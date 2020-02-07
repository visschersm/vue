using DataLayer.Entities;
using ViewModels.Interfaces;

namespace ViewModels.Blogs
{
    public class Simple : IViewOf<Blog>
    {
        public string Title { get; set; } = string.Empty;
    }
}
