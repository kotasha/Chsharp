using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using App;


namespace AppTest
{
    [TestClass]
    public class CustomerServiceTest
    {
        #region fields 

        private Company mockCompany = default(Company);
        private DateTime dob = default(DateTime);
        private Customer customer = default(Customer);
        #endregion

        #region private

        private ICustomerDataRepository GetMockCustomerDataAccess()
        {
            var mockRepository = new MockRepository(MockBehavior.Default);
            var _customerBuilder = mockRepository.Create<ICustomerDataRepository>();
            return _customerBuilder.Object;
        }
        private ICustomerBuilder GetMockCustomerbuilder()
        {
            var mockRepository = new MockRepository(MockBehavior.Default);
            var _customerBuilder = mockRepository.Create<ICustomerBuilder>();
            _customerBuilder.Setup(m => m.BuildCustomer(customer.Firstname, customer.Surname, customer.EmailAddress,customer.DateOfBirth, mockCompany.Id))
                .Returns(customer);
            return _customerBuilder.Object;
        }

        #endregion

        #region public

        public CustomerServiceTest()
        {
            mockCompany = new Company { Id = 1299, Name = "ImportantClient", Classification = Classification.Silver };
            dob = new DateTime(1989, 9, 9);
            customer = new Customer() { Id = 9, Company = mockCompany, DateOfBirth = dob, EmailAddress = "info@nwt.com", Firstname = "Sha", Surname = "Kota",
                HasCreditLimit = true,CreditLimit=2000 };
        }

        [TestMethod]
        public void ValidateCustomerTestwithInvalidData()
        {
            ICustomerService customerService = new CustomerService(GetMockCustomerDataAccess(), GetMockCustomerbuilder());
            customer.EmailAddress = "test";
            var actualResult = customerService.AddCustomer(customer.Firstname, customer.Surname, customer.EmailAddress, dob, mockCompany.Id);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(false, actualResult, "Invalid Save");
        }

        [TestMethod]
        public void SaveCustomerTest()
        {
            ICustomerService customerService = new CustomerService(GetMockCustomerDataAccess(), GetMockCustomerbuilder());
            var actualResult = customerService.AddCustomer(customer.Firstname, customer.Surname, customer.EmailAddress, dob, mockCompany.Id);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(true, actualResult, "Invalid Save");
        }

        #endregion



    }

  
}
