using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Men -> Kids
namespace UnityFactorySample
{
    public class DependencyInjection
    {
    }
    interface IBusinessLogic
    {
    }
    public class Kids : IBusinessLogic
    {
        private string Name;
        private int Age;

        public Kids(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }
        public override string ToString()
        {
            return "Kid Age:" + Age.ToString() + "Kid Name : " + Name;
        }
    }
}
