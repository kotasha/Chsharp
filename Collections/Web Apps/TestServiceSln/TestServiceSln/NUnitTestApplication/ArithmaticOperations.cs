using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTestApplication
{
    public class ArithmaticOperations
    {
        //private int upper = default(int);
        //private int lower = default(int);

        public int Divide(int i, int j)
        {
            try
            {
                return i / j;
            }
            catch (ArithmeticException ex)
            {
                throw ex;
            }
        }
        public List<int> GetList()
        {
            List<int> _list = new List<int>();
            _list.Add(1);
            _list.Add(2);
            _list.Add(3);

            return _list;
        }
        public List<Person> GetPersons()
        {
            List<Person> _listPerson = new List<Person>(){
                new Person{Name="Person1",Gender="Male"},
            new Person{Name="Person2",Gender="Male"}};

            return _listPerson;
        }
        public Person GetPerson()
        {
            Person per = new Person { Name = "Person1", Gender = "Male" };

            return per;
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public string Gender { get; set; }
    }

}
