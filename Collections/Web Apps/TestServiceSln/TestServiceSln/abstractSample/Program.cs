using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace abstractSample
{
    public delegate void MyDel();

    public class Program
    {
        public event MyDel myEvent;

        abstract class Position
        {
            public abstract string Title { get; }
            public void Display()
            {
                Console.WriteLine(Title);
            }
        }
        [Serializable()]
        public class MyXml
        {
            [XmlElement("Manager")]
            public List<Manager> _manager { get; set; }
        }

        [Serializable()]
        [XmlRoot]
        public class Manager 
        {
            [XmlElement]
            public string Title
            {
                get
                {
                    return "Manager";
                }
            }
            [XmlElement]
            public string Name { get; set; }
        }

        class Clerk : Position
        {
            public override string Title
            {
                get
                {
                    return "Clerk";
                }
            }
        }

        class Programmer : Position
        {
            public override string Title
            {
                get
                {
                    return "Programmer";
                }
            }
        }

        static class Factory
        {
            /// <summary>
            /// Decides which class to instantiate.
            /// </summary>
            public static Position Get(int id)
            {
                switch (id)
                {
                    case 0:
                        //return new Position();
                    case 1:
                    case 2:
                        return new Clerk();
                    case 3:
                    default:
                        return new Programmer();
                }
            }
        }


        public static void Main(string[] args)
        {
            Manager mgr = new Manager();
            mgr.Name="Emp1";

            MyXml _listEmp = new MyXml();

            List<Manager> _mgrList = new List<Manager>(){
                new Manager{Name="shashank"},
                new Manager{Name="shashanka"},
                new Manager{Name="Lakshmipathi"}};
            _listEmp._manager = _mgrList;

            XmlSerializer serialize = new XmlSerializer(typeof(MyXml));

            string filename = @"D:\Code\ManagerList.xml";
           
            //if(!Directory.Exists(
            if (!File.Exists(filename))
                File.Create(filename);
            using (TextWriter writer = new StreamWriter(filename, false))
            {
                serialize.Serialize(writer, _listEmp);
            }
            using (MultipleInheritence obj = new MultipleInheritence())
            {
            }
            List<string> mylist = new List<string> { "mohan", "kota" };
            List<string> mylist2 = new List<string> { "mohan", "shashank" };
            //using (TextReader reader = new StreamReader(@"D:\Books\EngagementPackageHelperCore.dll"))
            //{

            //    Assembly obj = Assembly.LoadFile(@"D:\Books\EngagementPackageHelperCore.dll");

            //    Type[] lstTypes = obj.GetTypes();
            //    Type myObj = obj.GetType();
            //    var my = obj.CreateInstance(myObj.Name);

            //    foreach (Type t in lstTypes)
            //    {
            //        MethodInfo[] methods = t.GetMethods();

            //        foreach (MethodInfo mi in methods)
            //            Console.WriteLine("Assembly {0} contains method : {1}", t.Name, mi.Name);

            //        FieldInfo[] fields = t.GetFields();

            //        foreach (FieldInfo fi in fields)
            //            Console.WriteLine("Assembly {0} contains method : {1}", t.Name, fi.Name);

            //    }

            var identity = from q in mylist
                           join q2 in mylist2 on q.OfType<string>() equals q2.OfType<string>()
                           group q by q.StartsWith("m") into g
                           select new { ID = q.ToString(), Name = q2.ToString() };

            foreach (var item in identity)
            {
                Console.WriteLine(string.Format("ID : {0} Name : {1}", item.ID, item.Name));
            }

            //for (int i = 0; i <= 3; i++)
            //{
            //    Position position = Factory.Get(i);
            //    { position.Display(); }
            //}

            Console.Read();

        }
    }
}
