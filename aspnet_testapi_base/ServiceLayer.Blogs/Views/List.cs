using DataLayer.Entities;
using System;
using ViewModels.Interfaces;

namespace ServiceLayer.Blogs.Views
{
    public class List : IViewOf<Blog>
    {
        public Guid Id { get; set; }
    }
}
