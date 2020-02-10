using DataLayer.Entities;
using System;
using ViewModels.Interfaces;

namespace ViewModels.Blogs
{
    public class List : IViewOf<Blog>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
