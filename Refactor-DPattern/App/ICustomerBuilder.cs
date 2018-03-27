using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace App
{
    public interface ICustomerBuilder
    {
        Customer BuildCustomer(string firname, string surname, string email, DateTime dateOfBirth, int companyId);
    }

}

