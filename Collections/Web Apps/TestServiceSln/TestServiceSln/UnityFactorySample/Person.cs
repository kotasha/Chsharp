using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace UnityFactorySample
{
    public class Person : IPerson
    {
        public Person()
        {
        }
        string name;
        string teamName;  

        public string PlayerName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string TeamName
        {
            get
            {
                return teamName;
            }
            set
            {
                teamName = value;
            }
        }

        public void DisplayDetails()
        {
            Console.WriteLine("Player Name = \t" + name + " \tPlayer Team Name = \t" + teamName);
            //Console.WriteLine(p.PlayerName);

        }
    }
    public interface IPerson
    {
        string PlayerName
        {
            get;
            set;
        }
        string TeamName
        {
            get;
            set;
        }
        void DisplayDetails();
    }
    public class Player : IPerson
    {
        private string Name;
        private string Team;
        //public Player()
        //{
        //}
        //public Player(string name, string team)
        //    : base()
        //{
        //    this.Name = name;
        //    this.Team = team;
        //}
        public string PlayerName
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }

        public string TeamName
        {
            get
            {
                return Team;
            }
            set
            {
                Team = value;
            }
        }

        public void DisplayDetails()
        {
            Console.Write("Player : " + Name + " Team : " + Team);
        }
    }
    
}
