using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Crud.Models;
using Crud.DataAccess;

namespace Crud.DataAccess
{
    internal class Report : IDataAccess2<ComEmployee, string>
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        public Report()
        {
           Conn = new SqlConnection("Data Source=LocalHost;Initial Catalog=Mydatabase;Integrated Security=SSPI");  
           // Cmd = new SqlCommand(); 


        }
        List<EmployeeDepartment> EmpDept = new List<EmployeeDepartment>();
        void IDataAccess2<ComEmployee,string>.GetallEmployeebyDeptName(string id)
        {
            //ComEmployee employee = new ComEmployee();
            
            try
            {
                Conn.Open();
               
                // Conn = new SqlConnection("Data Source=LocalHost;Initial Catalog=Mydatabase;Integrated Security=SSPI");
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = $"Select Mydatabase.DeptNo , DeptName, EmpName, EmpNo, Salary, Designation  , Capctay , Location, Email From Mydatabase Left Join ComEmployee on Mydatabase.DeptNo=ComEmployee.DeptNo";
                
                SqlDataReader Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                    EmpDept.Add(
                    new EmployeeDepartment()
                    {
                        EmpNo = Convert.ToInt32(Reader["EmpNo"]),
                        EmpName = Reader["EmpName"].ToString(),
                        Salary = Convert.ToInt32(Reader["Salary"]),
                        Designation = Reader["Designation"].ToString(),
                        DeptNo = Convert.ToInt32(Reader["DeptNo"]),
                        Email = Reader["Email"].ToString(),
                        Location = Reader["Location"].ToString(),
                        DeptName = Reader["DeptName"].ToString(),
                        Capacty = Convert.ToInt32(Reader["DeptNo"])

                    });
                Reader.Close();
                Conn.Close();
                var EmpployeesByDeptName = EmpDept.Where(e => e.DeptName == id)
                            .Select(e => e);
                foreach (var Emp in EmpployeesByDeptName)
                {

                    Console.WriteLine($"\t{Emp.EmpName} is from department {Emp.DeptName}");

                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        void IDataAccess2<ComEmployee, string>.GetallEmployeeMaxSalary(string id)
        {
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = $"Select Mydatabase.DeptNo , DeptName, EmpName, EmpNo, Salary, Designation  , Capctay , Location, Email From Mydatabase Left Join ComEmployee on Mydatabase.DeptNo=ComEmployee.DeptNo";

                SqlDataReader Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                    EmpDept.Add(
                    new EmployeeDepartment()
                    {
                        EmpNo = Convert.ToInt32(Reader["EmpNo"]),
                        EmpName = Reader["EmpName"].ToString(),
                        Salary = Convert.ToInt32(Reader["Salary"]),
                        Designation = Reader["Designation"].ToString(),
                        DeptNo = Convert.ToInt32(Reader["DeptNo"]),
                        Email = Reader["Email"].ToString(),
                        Location = Reader["Location"].ToString(),
                        DeptName = Reader["DeptName"].ToString(),
                        Capacty = Convert.ToInt32(Reader["DeptNo"])

                    });
                Reader.Close();
                Conn.Close();
                var res1 = (from e in EmpDept
                            group e by e.DeptName into deptgroup
                            select new
                            {
                                DeptName = deptgroup.Key,
                                MaxSalary = deptgroup.Max(x => x.Salary),
                                Records = deptgroup.ToList()
                            });

                foreach (var record in res1)
                {
                    if (record.DeptName == id)
                    {
                        Console.WriteLine($"Group Key = {record.DeptName} ");
                        foreach (var item in record.Records)
                        {
                            if (record.MaxSalary == item.Salary)
                            {
                                Console.WriteLine($"EMpname= {item.EmpName} max salary= {record.MaxSalary} ");
                            }
                        }
                    }
                }





            }
            catch (Exception ex)
            {

            }

        }
        void IDataAccess2<ComEmployee, string>.GetSumSalaryByDeptName(string id)
        {
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = $"Select Mydatabase.DeptNo , DeptName, EmpName, EmpNo, Salary, Designation  , Capctay , Location, Email From Mydatabase Left Join ComEmployee on Mydatabase.DeptNo=ComEmployee.DeptNo";

                SqlDataReader Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                    EmpDept.Add(
                    new EmployeeDepartment()
                    {
                        EmpNo = Convert.ToInt32(Reader["EmpNo"]),
                        EmpName = Reader["EmpName"].ToString(),
                        Salary = Convert.ToInt32(Reader["Salary"]),
                        Designation = Reader["Designation"].ToString(),
                        DeptNo = Convert.ToInt32(Reader["DeptNo"]),
                        Email = Reader["Email"].ToString(),
                        Location = Reader["Location"].ToString(),
                        DeptName = Reader["DeptName"].ToString(),
                        Capacty = Convert.ToInt32(Reader["DeptNo"])

                    });
                Reader.Close();
                Conn.Close();
                var res1 = (from e in EmpDept
                            group e by e.DeptName into deptgroup
                            select new
                            {
                                DeptName = deptgroup.Key,
                                SumSalary = deptgroup.Sum(x => x.Salary),
                                Records = deptgroup.ToList()
                            });

                foreach (var record in res1)
                {
                    if (record.DeptName == id)
                    {
                        Console.WriteLine($"Group Key = {record.DeptName} SumSalary = {record.SumSalary}");
                        
                    }
                }


            }
            catch (Exception ex) 
            {
            }
        }
        void IDataAccess2<ComEmployee, string>.GetAllEmployeeByLocation(string id)
        {
            try
            {

                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = $"Select Mydatabase.DeptNo , DeptName, EmpName, EmpNo, Salary, Designation  , Capctay , Location, Email From Mydatabase Left Join ComEmployee on Mydatabase.DeptNo=ComEmployee.DeptNo";

                SqlDataReader Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                    EmpDept.Add(
                    new EmployeeDepartment()
                    {
                        EmpNo = Convert.ToInt32(Reader["EmpNo"]),
                        EmpName = Reader["EmpName"].ToString(),
                        Salary = Convert.ToInt32(Reader["Salary"]),
                        Designation = Reader["Designation"].ToString(),
                        DeptNo = Convert.ToInt32(Reader["DeptNo"]),
                        Email = Reader["Email"].ToString(),
                        Location = Reader["Location"].ToString(),
                        DeptName = Reader["DeptName"].ToString(),
                        Capacty = Convert.ToInt32(Reader["DeptNo"])

                    });
                Reader.Close();
                Conn.Close();
                var res1 = (from e in EmpDept
                            group e by e.Location into deptgroup
                            select new
                            {
                                Location = deptgroup.Key,
                                //MaxSalary = deptgroup.Max(x => x.Salary),
                                Records = deptgroup.ToList()
                            });

                foreach (var record in res1)
                {
                    if (record.Location == id)
                    {
                        Console.WriteLine($"Group Key = {record.Location} ");
                        foreach (var item in record.Records)
                        {
                            if (record.Location==item.Location)
                            {
                                Console.WriteLine($"EMpname= {item.EmpName} max salary= {record.Location} ");
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }

        }
    }
}
