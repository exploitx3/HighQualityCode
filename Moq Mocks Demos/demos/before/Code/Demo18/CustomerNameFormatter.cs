namespace PluralSight.Moq.Code.Demo18
{
    public class CustomerNameFormatter
    {
        public string From(Customer customer)
        {
            var firstName = ParseBadWordsFrom(customer.FirstName);
            var lastName = ParseBadWordsFrom(customer.LastName);

            return string.Format("{0}, {1}", lastName, firstName);
        }

        protected virtual string ParseBadWordsFrom(string value)
        {
            return value.Replace("SAP", string.Empty);
        }
    }
}