using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labmid
{
    internal class Program
    {
        public class StudentClub
        {
            private double budget;
            public ClubRole president = new ClubRole();
            public ClubRole vicePresident = new ClubRole();
            public ClubRole generalSecratory = new ClubRole();
            public ClubRole financeSecratory = new ClubRole();
            public List<Society> societies = new List<Society>();
            public List<FundedSociety> f = new List<FundedSociety>();
            public List<NonfundedSociety> n = new List<NonfundedSociety>();
            public double Budget
            {
                get { return budget; }
                set
                {
                    budget = value;
                }
            }

            public void fundsociety()
            {
                foreach (var s in f)
                {
                    Console.WriteLine(s.name);


                }
                Console.WriteLine("Enter name of society");
                string name = Console.ReadLine();
                foreach (var s in f)
                {
                    if (name == s.name)
                    {
                        Console.WriteLine("Funds: ");
                        Double funds = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine(s.FundingAmount + funds);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }

            }
            public void dispensefunds()
            {
                int techbitfunds = 600;
                int literaryfunds = 500;
                int sportsfunds = 500;


            }
            public void registorSociety()
            {
                Console.WriteLine("1. funding society");
                Console.WriteLine("2. Non funding society");
                Console.Write("Choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Console.Write("Enter name of society: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter contact of the society: ");
                    string contact = Console.ReadLine();
                    Console.Write("fund: ");
                    double fund = Convert.ToDouble(Console.ReadLine());
                    f.Add(new FundedSociety(name, contact, fund));
                    societies.Add(new Society(name, contact));

                }


                else if (choice == 2)
                {
                    Console.Write("Enter name of society: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter contact of the society: ");
                    string contact = Console.ReadLine();
                    n.Add(new NonfundedSociety(name, contact));
                    societies.Add(new Society(name, contact));

                }
                else
                {
                    Console.WriteLine("Invalid input");
                }


            }
            public void displaySocieties()
            {
                foreach (var s in societies)
                {
                    Console.WriteLine($"Society name: {s.name}\nSociety Contact: {s.contact}");
                    Console.WriteLine();
                }

            }

        }
        public class Society
        {
            public string name;
            public string contact;

            public Society(string n, string c)
            {
                name = n;
                contact = c;
            }
            public List<string> activities = new List<string>();



            public void addActivity()
            {
                Console.Write("Event name: ");
                string events = Console.ReadLine();

            }
            public void listActivity()
            {
                foreach (var activity in activities)
                {
                    Console.WriteLine(activity);
                }

            }
        }
        public class FundedSociety : Society
        {

            private double fundingAmount;
            public double FundingAmount
            {
                get { return fundingAmount; }
                set
                {
                    fundingAmount = value;
                }
            }
            public FundedSociety(string n, string c, double famount) : base(n, c)
            {
                fundingAmount = famount;
                name = n;
                contact = c;

            }

        }
        public class NonfundedSociety : Society
        {
            public NonfundedSociety(string n, string c) : base(n, c)
            {
                name = n;
                contact = c;

            }

        }

        public class ClubRole
        {
            public string name;
            private string role;
            private string contactInfo;

            public string Role
            {
                get { return role; }
                set { role = value; }
            }
            public string ContactInfo
            {
                get { return contactInfo; }
                set
                {
                    contactInfo = value;
                }
            }

        }
        static void Main(string[] args)
        {
            StudentClub club = new StudentClub();
            Console.Write("President name: ");
            string p = Console.ReadLine();
            Console.Write("vicePresident: ");
            string v = Console.ReadLine();
            Console.Write("general secratory: ");
            string g = Console.ReadLine();
            Console.Write("finance secrartory: ");
            string f1 = Console.ReadLine();
            Console.WriteLine();



            bool exit = false;
            while (exit != true)
            {
                Console.WriteLine("      Student Club Management System");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("1. Register a new society");
                Console.WriteLine("2. Allocate Funding to society");
                Console.WriteLine("3. Register an event for a society");
                Console.WriteLine("4. Dispaly society funding information");
                Console.WriteLine("5. Display Events for a society");
                Console.WriteLine("6. Exit");
                Console.Write("Choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        club.registorSociety();
                        break;
                    case 2:
                        club.fundsociety();

                        break;
                    case 3:
                        club.displaySocieties();
                        Console.WriteLine("name: ");
                        string name = Console.ReadLine();
                        foreach (var s in club.societies)
                        {
                            if (name == s.name)
                            {
                                s.addActivity();
                            }
                            else
                            {
                                Console.WriteLine("INVALID INPUT");
                            }
                        }
                        break;
                    case 4:
                        club.displaySocieties();
                        Console.WriteLine("name: ");
                        string n1 = Console.ReadLine();
                        foreach (var s1 in club.f)
                        {
                            if (n1 == s1.name)
                            {
                                Console.WriteLine($"society name: {s1.name}\nfunds: {s1.FundingAmount}");
                            }
                            else
                            {
                                Console.WriteLine("INVALID INPUT");
                            }
                        }

                        break;
                    case 5:
                        club.displaySocieties();
                        Console.WriteLine("name: ");
                        string n = Console.ReadLine();
                        foreach (var s in club.societies)
                        {
                            if (n == s.name)
                            {
                                s.listActivity();
                            }
                            else
                            {
                                Console.WriteLine("INVALID INPUT");
                            }

                        }

                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("INVALID INPUT");
                        break;



                }

            }



        }
    }
}
