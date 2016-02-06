namespace PluralSight.Moq.Code.Demo17
{
    public interface ICustomerAddressFormatter
    {
        Address For(CustomerToCreateDto customerToCreate);
    }
}