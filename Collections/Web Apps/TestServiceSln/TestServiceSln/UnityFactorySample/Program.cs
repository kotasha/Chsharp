using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityFactorySample
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IPerson person = Factory.CreateInstance();
                person.PlayerName = "Me";
                person.TeamName = "india";
                
                person.DisplayDetails();
                string t = Console.ReadLine();
            }
            catch (Exception objEx)
            {
            }
        }
    }
}
