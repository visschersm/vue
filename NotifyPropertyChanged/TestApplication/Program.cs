using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace TestApplication
{
    public class PropertyChangeTracker<TEntity> where TEntity : class
    {
        TEntity m_entity = null;
        HashSet<PropertyInfo> ChangedProperties = new HashSet<PropertyInfo>();

        public PropertyChangeTracker(TEntity entity)
        {
            m_entity = entity;
        }

        public void Set<TValue>(Expression<Func<TEntity, TValue>> expression, TValue value)
        {
            var Member = (expression.Body as MemberExpression).Member as PropertyInfo;

            ChangedProperties.Add(Member);

            Member.SetValue(m_entity, value);
        }

        public PropertyInfo[] GetChangedProperties()
        {
            return ChangedProperties.ToArray();
        }
    }

    class SomeType : INotifyPropertyChanged
    {
        public SomeType()
        {

        }

        // props
        private string name;
        public string Name
        {
            get => name;
            set => SetField(ref name, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    class Program
    {
        static List<SomeType> Data = new List<SomeType>
        {
            new SomeType {Name = "Name_1" },
            new SomeType {Name = "Name_2" },
            new SomeType {Name = "Name_3" },
        };

        static void Main(string[] args)
        {
            //SomeType foo = new SomeType();
            //
            //PropertyChangeTracker<SomeType> fooTracker = new PropertyChangeTracker<SomeType>(foo);
            //fooTracker.Set(e => e.Name, "Hello");
            //
            //var changedProperties = fooTracker.GetChangedProperties();
            //
            //changedProperties.Select(p => p.Name
            //foo.PropertyChanged += Foo_PropertyChanged;
            //foo.Name = "Hello";

            var element = Data.ToArray().Single(x => x.Name == "Name_1");
            PropertyChangeTracker<SomeType> elementTracker = new PropertyChangeTracker<SomeType>(element);
            elementTracker.Set(e => e.Name, "OtherName");

            var changedProperties = elementTracker.GetChangedProperties();

            foreach (var property in changedProperties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(element);

                property.SetValue(element, propertyValue);
            }
        }

        static bool isDirty = false;
        private static void Foo_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            isDirty = true;
        }
    }
}
