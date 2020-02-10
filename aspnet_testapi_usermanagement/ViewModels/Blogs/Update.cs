using DataLayer.Entities;
using ViewModels.Interfaces;

namespace ViewModels.Blogs
{
    public class Update : IUpdateView<Blog>
    {
        public string Title { get; set; } = null!;
    }
}
