namespace PluralSight.Moq.Code.Demo17
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerAddressFormatter _customerAddressFormatter;

        public CustomerService(ICustomerRepository customerRepository, ICustomerAddressFormatter customerAddressFormatter)
        {
            _customerRepository = customerRepository;
            _customerAddressFormatter = customerAddressFormatter;
        }

        public void Create(CustomerToCreateDto customerToCreate)
        {
            var customer = new Customer(customerToCreate.Name);

            customer.Address = _customerAddressFormatter.For(customerToCreate);

            _customerRepository.Save(customer);
        }
    }
}