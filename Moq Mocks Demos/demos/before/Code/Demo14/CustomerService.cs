namespace PluralSight.Moq.Code.Demo14
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Create(CustomerToCreateDto customerToCreate)
        {
            var customer = new Customer(customerToCreate.Name);

            _customerRepository.Save(customer);
            _customerRepository.FetchAll();
        }
    }
}