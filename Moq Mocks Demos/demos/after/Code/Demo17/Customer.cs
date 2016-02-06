namespace PluralSight.Moq.Code.Demo17
{
    public class Customer
    {
        public string Name { get; set; }
        public Address Address { get; set; }

        public Customer(string name)
        {
            Name = name;
        }
    }
}