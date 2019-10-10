using System;
using System.Runtime.CompilerServices;

namespace Xylem.Xdm.Database.Attributes
{
    /// <summary>
    /// Attribute that specifies from which the changes should be logged.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class TrackChangesAttribute : Attribute
    {
        public string Name { get; private set; }
        public bool Indent { get; set; } = false;

        public TrackChangesAttribute([CallerMemberName] string name = null)
            : base()
        {
            Name = name;
        }
    }
}
