namespace PluralSight.Moq.Code.Demo01
{
    public class Customer
    {
        public string Name { get; set; }
        public string City { get; set; }

        public Customer(string name, string city)
        {
            Name = name;
            City = city;
        }
    }
}