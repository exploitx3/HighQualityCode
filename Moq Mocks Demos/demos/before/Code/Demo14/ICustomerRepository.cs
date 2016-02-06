using System.Collections.Generic;

namespace PluralSight.Moq.Code.Demo14
{
    public interface ICustomerRepository
    {
        void Save(Customer customer);
        IEnumerable<Customer> FetchAll();
    }
}