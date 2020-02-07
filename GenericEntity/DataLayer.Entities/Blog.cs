using DataLayer.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Blog : IId<int>
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
