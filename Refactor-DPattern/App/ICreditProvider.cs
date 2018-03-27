using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace App
{
    public interface ICreditProvider
    {
        Customer GetCreditLimit(Customer customer);
    }

}

