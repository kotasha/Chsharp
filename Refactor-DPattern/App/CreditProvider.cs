using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace App
{
    delegate void processClient();

    class CreditProvider : ICreditProvider
    {

        #region fields

        private readonly ICustomerCreditService _customerCreditService = default(ICustomerCreditService);
        private Customer _customer = default(Customer);
        private processClient _processClient = default(processClient);

        #endregion


        #region public

        public CreditProvider(ICustomerCreditService customerCreditService)
        {
            _customerCreditService = customerCreditService;
        }

        public Customer GetCreditLimit(Customer customer)
        {
            SetClientType(customer.Company.Name);
            _customer = customer;
            _processClient();
            return _customer;
        }

        #endregion


        #region private

        void SetClientType(string _companyName)
        {
            switch (_companyName)
            {
                case AppConstants.VeryImportantClient:
                    _processClient = ProcessVeryImportantClient;
                    break;
                case AppConstants.ImportantClient:
                    _processClient = ProcessImportantClient;
                    break;
                default:
                    _processClient = ProcessDefaultClient;
                    break;
            }
        }


        void ProcessVeryImportantClient()
        {
            _customer.HasCreditLimit = false;
        }
        void ProcessImportantClient()
        {
            _customer.HasCreditLimit = true;
            _customer.CreditLimit = GetCreditLimit() * AppConstants.DoubleCredit;
        }
        void ProcessDefaultClient()
        {
            _customer.HasCreditLimit = true;
            _customer.CreditLimit = GetCreditLimit();
        }
        int GetCreditLimit()
        {
            return _customerCreditService.GetCreditLimit(_customer.Firstname, _customer.Surname, _customer.DateOfBirth);
        }

        #endregion
    }
}
