namespace PluralSight.Moq.Code.Demo13
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMailingRepository _mailingRepository;

        public CustomerService(
            ICustomerRepository customerRepository, 
            IMailingRepository mailingRepository)
        {
            _customerRepository = customerRepository;
            _mailingRepository = mailingRepository;

            _customerRepository.NotifySalesTeam += NotifySalesTeam;
        }

        private void NotifySalesTeam(object sender, NotifySalesTeamEventArgs e)
        {
            _mailingRepository.NewCustomerMessage(e.Name);
        }

        public void Create(CustomerToCreateDto customerToCreate)
        {
            var customer = new Customer(customerToCreate.Name);

            _customerRepository.Save(customer);
        }
    }
}