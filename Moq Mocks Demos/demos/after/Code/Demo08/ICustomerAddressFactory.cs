namespace PluralSight.Moq.Code.Demo08
{
    public interface ICustomerAddressFactory
    {
        Address From(CustomerToCreateDto customerToCreate);
    }
}