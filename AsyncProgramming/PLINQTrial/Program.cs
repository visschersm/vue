using System.Collections.Generic;
using System.Linq;

namespace PLINQTrial
{
    class Program
    {
        public class Person
        {
            public string Firstname { get; set; } = "Firstname";
            public string Lastname { get; set; } = "Lastname";
        };

        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 500; ++i)
            {
                persons.Add(new Person());
            }

            persons.AsParallel().
        }
    }
}
