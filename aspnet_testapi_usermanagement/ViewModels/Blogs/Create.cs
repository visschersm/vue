using DataLayer.Entities;
using System.ComponentModel.DataAnnotations;
using ViewModels.Interfaces;

namespace ViewModels.Blogs
{
    public class Create : ICreateView<Blog>
    {
        [Required]
        public string Title { get; set; } = null!;
    }
}
