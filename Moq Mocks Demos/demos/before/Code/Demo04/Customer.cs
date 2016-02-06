namespace PluralSight.Moq.Code.Demo04
{
    public class Customer
    {
        public string Name { get; set; }
        public MailingAddress MailingAddress { get; set; }

        public Customer(string name)
        {
            Name = name;
        }
    }
}