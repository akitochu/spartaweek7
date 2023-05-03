using System.Collections.Generic;

namespace NorthwindData.Services
{
    public interface ICustomerService
    {
        public List<Customer> GetCustomerList();
        public Customer GetCustomerById(string customerId);
        public void CreateCustomer(Customer c);
        public void SaveCustomerChanges();
        public void RemoveCustomer(Customer c);
    }
}
