using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_24_02_2022.NewFolder1;

namespace Assignment_24_02_2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            operation op = new operation();
            Employee employee = new Employee();
            int a = 0;
            
           do
            {
                try
                {
                    Console.WriteLine("Enter 1 to run WrteData to Database and Write data to file\n" +
                            "Enter 2 to run ReadFrom File and Read from table\n" +
                            "Enter 3 to invoke\n"+"Enter 4 to ClearScreen\n"+"Enter 5 to Exit" );

                    int input = int.Parse(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            op.thread1();
                            break;
                        case 2:
                            op.thread2();
                            break;
                        case 4:
                            Console.Clear();
                            break;
                        case 3:
                            op.ParalelInvoke();
                            break;
                        case 5:
                            a++;
                            break;


                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"Error = {ex.Message}");
                }

            }while(a==0);

        }
    }
}
