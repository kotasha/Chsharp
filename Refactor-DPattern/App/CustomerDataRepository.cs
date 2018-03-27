namespace App
{
    public class CustomerDataRepository : ICustomerDataRepository
    {
        public void AddCustomer(Customer customer)
        {
            CustomerDataAccess.AddCustomer(customer);
        }
    }
}