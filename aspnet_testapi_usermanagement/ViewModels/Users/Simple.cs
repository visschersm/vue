using DataLayer.Entities.Entities;
using System;
using ViewModels.Interfaces;

namespace ViewModels.Users
{
    public class Simple : IViewOf<User>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
    }
}
