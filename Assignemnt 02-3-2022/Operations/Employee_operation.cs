using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Assignemnt_02_3_2022.Data;

namespace Assignemnt_02_3_2022.Operations
{
    internal class Employee_operation
    {
        

        SqlConnection Conn;
        SqlCommand Cmd;
        public Employee_operation()
        {
            Conn = new SqlConnection("Data Source =.; Initial Catalog = Mydatabase; Integrated Security = SSPI");
            // cmd = new SqlCommand(); 
          //  Conn.Open();
        }
        public async Task addsync(Employee entity)
        {
            try
            {
                
               // SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = Mydatabase; Integrated Security = SSPI");
               Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = $"Insert into ComEmployee Values({entity.EmpNo}, '{entity.EmpName}', {entity.Salary},'{entity.Designation}',{entity.DeptNo},'{entity.Email}')";
                // Execute the Command Object
                int res = await Cmd.ExecuteNonQueryAsync();
                if (res == 0) // Some Error Occured
                {
                    Console.WriteLine("Cannot be added");
                }
                else
                {
                    // if successful store the entity into the department
                    Console.WriteLine("Added");
                }
            }
            catch (SqlException ex)
            {

                Task.FromException(ex);
            }
            finally // this will be executed irrespective of try or catch block
            {
                // if the Connection is still open the close it
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }
          //  return entity;  
        }
        public async Task<ListDeptEmploy> getdata()
        {
           List<Employee> employees = new List<Employee>();
            Conn.Open();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = "Select * From ComEmployee";
            var deptreader = await Cmd.ExecuteReaderAsync();
            while (deptreader.Read())
            {
                employees.Add(new Employee()
                {
                    EmpNo = Convert.ToInt32(deptreader["EmpNo"]),
                    EmpName = deptreader["EmpName"].ToString()
                });
            }
            deptreader.Close();
            Conn.Close();
            return new ListDeptEmploy() { Employees=employees}; 
        }
        //public void Despose()
        //{
        //    conn.Dispose();
        //    GC.SuppressFinalize(this);  
        //}
        public async  Task deleteAsync(int id)
        {
            //ComEmployee employee = new ComEmployee();
            Employee employee = new Employee();
            try
            {
                Conn.Open();
                Cmd.CommandText = $"Delete * from ComEmployee where DeptNo=@DeptNo";
                SqlParameter pDeptNo = new SqlParameter();
                pDeptNo.ParameterName = "@DeptNo";
                pDeptNo.SqlDbType = SqlDbType.Int;
                pDeptNo.Direction = ParameterDirection.Input;
                pDeptNo.Value = id;



                // Add parameters into the Parameters Collection of the Command object
                Cmd.Parameters.Add(pDeptNo);
                int res =await Cmd.ExecuteNonQueryAsync();
                if (res == 0)
                {
                    employee = null;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }
           // return employee;
        }
      public  async Task  updateAsync(int id,Employee entity)
        {
            Employee employee = new Employee();
            try
            {
                // check if id and the DeptNo value of the entity is same
                if (id == entity.EmpNo)
                {
                    Conn.Open();
                    // Create paramerized query
                    Cmd = new SqlCommand();
                    Cmd.Connection = Conn;
                    Cmd.CommandText = "Update ComEmployee Set EmpName=@EmpName, Salary=@Salary, Designation=@Designation , Email = @Email, DeptNo =@DeptNo where EmpNo=@EmpNo";
                    // Call the execute method

                    SqlParameter pEmpNo = new SqlParameter();
                    pEmpNo.ParameterName = "@Empno";
                    pEmpNo.SqlDbType = SqlDbType.Int;
                    pEmpNo.Direction = ParameterDirection.Input;
                    pEmpNo.Value = id;
                    SqlParameter pEmpName = new SqlParameter();
                    pEmpName.ParameterName = "@Empname";
                    pEmpName.SqlDbType = SqlDbType.VarChar;
                    pEmpName.Size = 200;
                    pEmpName.Direction = ParameterDirection.Input;
                    pEmpName.Value = entity.EmpName;
                    SqlParameter pDesignation = new SqlParameter();
                    pDesignation.ParameterName = "@Designation";
                    pDesignation.SqlDbType = SqlDbType.VarChar;
                    pDesignation.Size = 200;
                    pDesignation.Direction = ParameterDirection.Input;
                    pDesignation.Value = entity.Designation;
                    SqlParameter pSalary = new SqlParameter();
                    pSalary.ParameterName = "@Salary";
                    pSalary.SqlDbType = SqlDbType.Int;
                    pSalary.Direction = ParameterDirection.Input;
                    pSalary.Value = entity.Salary;
                    SqlParameter pDeptNo = new SqlParameter();
                    pDeptNo.ParameterName = "@DeptNo";
                    pDeptNo.SqlDbType = SqlDbType.Int;
                    pDeptNo.Direction = ParameterDirection.Input;
                    pDeptNo.Value = entity.DeptNo;
                    SqlParameter pEmail = new SqlParameter();
                    pEmail.ParameterName = "@Email";
                    pEmail.SqlDbType = SqlDbType.VarChar;
                    pEmail.Size = 200;
                    pEmail.Direction = ParameterDirection.Input;
                    pEmail.Value = entity.Email;

                    Cmd.Parameters.Add(pEmpNo);
                    Cmd.Parameters.Add(pEmpName);
                    Cmd.Parameters.Add(pSalary);
                    Cmd.Parameters.Add(pDesignation);
                    Cmd.Parameters.Add(pDeptNo);
                    Cmd.Parameters.Add(pEmail);

                    int res =await Cmd.ExecuteNonQueryAsync();

                    if (res == 0)
                    {
                        employee = null;
                    }
                    else
                    {
                        employee = new Employee();
                        employee = entity;
                    }
                }
                else
                {
                    throw new Exception($"the {id} and {entity.EmpNo} does not match");
                }
            }
            // for one try there can be multiple catch
            // make sure that the specific catch appears before 
            // the general catch (i.e. Exception class)
            catch (SqlException ex)
            {
                _ = Task.FromException(ex);
            }
            catch (Exception ex)
            {
                _ = Task.FromException(ex);  
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }

        }
        
    }


}

