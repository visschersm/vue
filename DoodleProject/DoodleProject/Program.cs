using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DoodleProject
{
    class Program
    {
        public class Person
        {
            public string Name { get; set; }
            public string Lastname { get; set; }
            public int Age { get; set; }
        }

        static void Main(string[] args)
        {
            Foo<Person> foo = new Foo<Person>();

            foo.GetData(x => x.Name == "Mark");
            foo.GetData<PersonView>(x => x.Name == "Mark");
            foo.GetData(x => x.Name == "Mark", "Name");
            foo.GetData3(x => x.Name == "Mark", (Person x) => { x.Name, true});
        }

        public class OrderObject<T>
        {
            public OrderObject(Expression<Func<T, object>> keySelector, bool descending = false)
            {
            }

            public bool Descending { get; }
        }

        public class Foo<TEntity>
        {
            public IEnumerable<TEntity> GetData(Expression<Func<TEntity, bool>> where)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<TEntity> GetData(Expression<Func<TEntity, bool>> where, string orderBy)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<TEntity> GetData(Expression<Func<TEntity, bool>> where, OrderObject<TEntity> orderBy)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<TEntity> GetData(Expression<Func<TEntity, bool>> where, List<OrderObject<TEntity>> orderByList)
            {
                throw new NotImplementedException();
            }

            internal void GetData2(Expression<Func<TEntity, bool>> where, Func<TEntity, object> property, bool descending)
            {
                throw new NotImplementedException();
            }

            internal void GetData3(Func<object, bool> p1, Func<Person, object> p2)
            {
                throw new NotImplementedException();
            }
        }
    }
}
