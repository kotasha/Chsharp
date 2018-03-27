using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App
{

    public class CustomerBuilder : ICustomerBuilder
    {
        #region fields

        ICompanyRepository _companyRepository= default(ICompanyRepository);
        ICreditProvider _creditProvider=default(ICreditProvider);

        #endregion

        #region private

        private Customer ProcessCustomer(string firname, string surname, string email, DateTime dateOfBirth, int companyId, Company company)
        {
            var _customer = new Customer() { Firstname = firname, Surname = surname, EmailAddress = email, DateOfBirth = dateOfBirth, Company = company };
            return _customer;
        }

        #endregion

        #region public

        public CustomerBuilder(ICompanyRepository companyRepository, ICreditProvider creditProvider)
        {
            _companyRepository = companyRepository;
            _creditProvider = creditProvider;
        }

        public Customer BuildCustomer(string firname, string surname, string email, DateTime dateOfBirth, int companyId)
        {
            var company = _companyRepository.GetById(companyId);
            var customer = ProcessCustomer(firname, surname, email, dateOfBirth, companyId, company);
            return _creditProvider.GetCreditLimit(customer);
        }

        #endregion
    }




}
