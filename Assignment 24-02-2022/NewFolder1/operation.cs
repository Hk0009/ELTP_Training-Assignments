using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Assignment_24_02_2022.NewFolder1
{
    internal class operation
    {
        List<Employee> employee = new List<Employee>();
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Mydatabase;Integrated Security=SSPI");
       public List<Employee>  WriteDataToFile(Employee emp)
        {
            try
            {
                string path = @"C:\MyDir\new";
                string filePath = $"{path}\\{emp.EmpNo}.txt";
                if (File.Exists(filePath))
                {
                    Console.WriteLine($"Specified File {filePath} is Already exists");
                    Thread.CurrentThread.Abort();

                }
                else
                {
                    FileStream f = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(f);
                    writer.WriteLine($" Empno :{emp.EmpNo}, Name:{ emp.EmpName}, Salary:{emp.Salary}, Designation:{emp.Designation}, DeptNo:{emp.DeptNo}, Email:{emp.Email}");
                    writer.Close();
                    f.Close();
                    Console.WriteLine("______*_______");

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error = {ex.Message}");
            }
            return employee;



        }
        public void Read(int EmpNo)
        {
            try
            {
                string path = @"C:\MyDir\new";
                string filePath = $"{path}\\{EmpNo}.txt";
                if (File.Exists(filePath))
                {
                    FileStream fs1 = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    StreamReader reader = new StreamReader(fs1);
                    string data = reader.ReadToEnd();
                    reader.Close();
                    Console.WriteLine($"Data from file = \n {data}");
                    fs1.Close();
                    Console.WriteLine("----*---");
                }
                else
                {
                    Console.WriteLine("File Not Exists");
                    Thread.CurrentThread.Abort();
                }
            }
            catch (Exception ex)
            {


                Console.WriteLine($"Error = {ex.Message}");
            }
        }
       public List<Employee> WriteDataToDb(Employee emp)
        {
            try
            {
                Employee employee = new Employee();
                employee= emp;  
               //conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from ComEmployee", conn);
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                //AcceptData(emp);
                //1.b This object will create DataSet in Client's memory and 'fill' data in it by creating DataTable object in it
                DataSet ds = new DataSet();
                //1.c  A 'Fill()' method to fill received data from DB to DataSet
                adapter.Fill(ds, "ComEmployee");
                DataRow dr = ds.Tables["ComEmployee"].NewRow();
                

                dr["EmpNo"] =emp.EmpNo;
               
                dr["EmpName"] =emp.EmpName;
               
                dr["Salary"] =emp.Salary;
               
                dr["Designation"] = emp.Designation;
               
                dr["DeptNo"] = emp.DeptNo;
              
                dr["Email"] = emp.Email;
                // 1.d Add the Dr in Rows Collection of Employee Table in DataSet
                ds.Tables["ComEmployee"].Rows.Add(dr);
                //1.e to send updated commmand back to database we use builder
                //This accepts an Adapter object as inout parameter
                SqlCommandBuilder command = new SqlCommandBuilder(adapter);
                //1.f Invoke the 'Update()' method on the Adapter object to update data from DataSet to Corresponding table in Database
                var res = adapter.Update(ds, "ComEmployee");
                if (res == null)
                {
                    Console.WriteLine("Add Failed");
                }
                else
                {
                    Console.WriteLine("Add Successfully");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error alert = {ex.Message}");
                Thread.CurrentThread.Abort();   
            }
            return employee;
        }
         List<Employee> AcceptData(Employee emp)
        {
            
           // Employee emp = new Employee();
            Console.WriteLine("Enter Employee Number");
            emp.EmpNo=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee Name");
            emp.EmpName =Console.ReadLine();
            Console.WriteLine("Enter Employee Designation");
            emp.Designation = Console.ReadLine();
            Console.WriteLine("Enter Employee Salary");
            emp.Salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee DeptNo");
            emp.DeptNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee Email");
            emp.Email =Console.ReadLine();
           
            return employee;
            


        }
       public List<Employee> ReadDb(Employee emp, int id)
        {
            try
            {
               SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Mydatabase;Integrated Security=SSPI");
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from ComEmployee", conn);
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                DataSet ds = new DataSet();
                adapter.Fill(ds, "ComEmployee");
                DataRow row = ds.Tables["ComEmployee"].Rows.Find(id);
                
                
                    Console.WriteLine($"{row["Empno"]}     {row["Empname"]}       {row["Salary"]}   {row["Designation"]}    {row["Deptno"]} {row["Email"]}");
                
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error={ex.Message}");
            }
            return employee;
        }
       
        public void thread1()
        {
            Employee emp = new Employee();  
            Console.WriteLine("THreading");
            AcceptData(emp);
           
            Thread t1 = new Thread(() => WriteDataToFile(emp));
            Thread t2 = new Thread(() => WriteDataToDb(emp));
            // 3. start thread
            t1.Start();
           // t2.Priority = ThreadPriority.Highest;
            t2.Start();
            //Console.ReadLine();
        }
        public void thread2()
        {
            Employee emp = new Employee();
            Console.WriteLine("Enter the file name you want to read");
            int input =Convert.ToInt32(Console.ReadLine());
            Thread t3 = new Thread(() => Read(input));
            Thread t4 = new Thread(() => ReadDb(emp,input));  
            t3.Start();
            t4.Start();
           
        }
        public void ParalelInvoke()
        {
            Employee emp = new Employee();
            Parallel.Invoke(() =>
            {
                thread1();
                thread2();
            });
        }






    }


}
