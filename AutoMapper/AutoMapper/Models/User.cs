namespace AutoMapperTest.Models
{
    public class User
    {
        public User(int id, string firstName, string lastName, string emailAddress)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
        }

        public int Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string EmailAddress { get; }
    }
}
