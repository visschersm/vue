using System;
using ViewModels.Interfaces;

namespace DataLayer.Entities
{
    public class Blog : IId<int>
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
