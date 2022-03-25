using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asiignment_22_02_2022.Data;
using Asiignment_22_02_2022.DataAccess;

namespace Asiignment_22_02_2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDataAccess<ComEmployee>Emp = new ComEmployeeDataAccess();
            IDataAccess<MyDatabase> dept = new MyDatabaseAccess();
            int a = 0;
            do
            {
                try
                {
                    Console.WriteLine("Press 1 to read EMployee\n"+"Press 2 to add Employee\n"+"Press 3 to update Employee\n"+"Press 4 to Delete Employee"+ "Press 5 to read Department\n" + "Press 6 to add Department\n" + "Press 7 to update Department\n" + "Press 8 to Delete Department\n" +"Press 9 to exit");
                    int key=Convert.ToInt32( Console.ReadLine());
                    switch(key)
                    {
                        case 1:
                            Emp.Read();
                            break;
                            case 2:
                            Emp.Add();
                            break;
                        case 3:
                            Emp.Update();
                            break;
                        case 4:
                            Emp.Delete();
                            break;
                                 case 5:
                            dept.Read();
                            break;
                        case 6:
                            dept.Add();
                            break;
                        case 7:
                            dept.Update();
                            break;
                        case 8:
                            dept.Delete();
                            break;
                        case 9:
                            a++;
                                break;
                    }


                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }while (a==0);
        }
    }
}
