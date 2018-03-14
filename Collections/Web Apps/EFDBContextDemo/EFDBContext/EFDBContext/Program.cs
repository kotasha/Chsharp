using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFDBContext
{
    class Programs
    {
        static void Main(string[] args)
        {
            AddEntityDemo.AddEntity();
            AddEntityDemo.AddOneToOneEntity();
            AddEntityDemo.AddOneToManyEntity();
            AddEntityDemo.AddManyToManyEntity();

            UpdateDemo.UpdateEntity();
            UpdateDemo.UpdateOneToOneEntity();

            UpdateDemo.UpdateOneToManyEntity();
            UpdateDemo.UpdateManyToManyEntity();

            DeleteDemo.DeleteEntity();

            MiscDemo.FindEntityDemo();
            MiscDemo.GetPropertyValues();
            MiscDemo.SetValuesDemo();
            MiscDemo.ValidationErrorDemo();
            MiscDemo.DBContextGenricSetMethod();
            MiscDemo.LazyLoadingDemo();
            MiscDemo.ExplicitLoadingDemo();
            MiscDemo.QueryMethodDemo();
            MiscDemo.LocalDemo();
            MiscDemo.POCOProxyDemo();
            MiscDemo.RawSQLtoEntityTypeDemo();
            MiscDemo.RawSQLCommandDemo();
            
            MiscDemo.StoredProcedureDemo();

            Console.WriteLine("****DBContext demo completed successfully****");
            Console.Read();
            
        }
    }
}
