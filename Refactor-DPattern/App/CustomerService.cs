using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace App
{
    public class CustomerService : ICustomerService
    {

        #region fields

        private readonly ICustomerDataRepository _customerDataRepository = default(ICustomerDataRepository);
        private readonly ICustomerBuilder _customerBuilder = default(ICustomerBuilder);


        #endregion

        #region private

        private bool IsCustomerValid(string firname, string surname, string email, DateTime dateOfBirth, int companyId)
        {
            if (string.IsNullOrEmpty(firname) || string.IsNullOrEmpty(surname))
            {
                return false;
            }

            if (!email.Contains("@") && !email.Contains("."))
            {
                return false;
            }

            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            if (age < 21)
            {
                return false;
            }
            return true;
        }

        private bool SaveCustomer(Customer customer)
        {
            if (customer!=null && customer.HasCreditLimit && customer.CreditLimit < 500)
            {
                return false;
            }

            _customerDataRepository.AddCustomer(customer);

            return true;
        }

        #endregion

        #region public

        public CustomerService(ICustomerDataRepository customerDataRepository,ICustomerBuilder customerBuilder)
        {
            _customerDataRepository = customerDataRepository;
            _customerBuilder = customerBuilder;

        }

        public bool AddCustomer(string firname, string surname, string email, DateTime dateOfBirth, int companyId)
        {
            if (IsCustomerValid(firname, surname, email, dateOfBirth, companyId))
            {
                var customer = _customerBuilder.BuildCustomer(firname, surname, email, dateOfBirth, companyId);
                return SaveCustomer(customer);
            }
            return false;

        }

        #endregion

    }
}
