using System;

namespace MiniProject_1_2_2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            bool exit= true;
            char Input;
            do
            {
                Console.WriteLine("\n\nEnter 1 for Add Employee\n" +
                    "Enter 2 for search Employee\n"+
                    "Enter 3 for Update Employee\n"+
                    "Enter 4 for Delete Employee\n"+
                    "Enter 5 for Display by Department Name\n"+
                    "Enter 6 to Display by Designation Name\n"+
                    "Enter 7 to DisplayEmployee "+
                    "Enter 7 to Exit") ;
                int Num = int.Parse(Console.ReadLine());
                switch(Num)
                {
                    case 1:
                        client.AddEmployee();
                        break;
                    case 2:
                        client.SearchEmployee();
                        break;
                    case 3:
                        client.UpdateEmployee();
                        break;
                    case 4:
                        client.Deleteemployee();
                        break;
                    case 5:
                        client.Dept_Name();
                        break;
                    case 6:
                        client.Designation();
                        break;
                    case 7:
                        client.DisplayEmployee();
                        break;
                    case 8:
                        exit = false;
                        break;
                    default:
                       Console.WriteLine("Please select Valid Entry");
                        break;


                }
                Console.WriteLine("Enter Y or y to continue");
                Input = Convert.ToChar(Console.ReadLine());
            }

            
                while (Input == 'Y' || Input=='y' );
        }
    }
}
