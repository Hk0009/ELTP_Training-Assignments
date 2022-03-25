using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment__Await__02_03_2022.DataAccess;
using Assignment__Await__02_03_2022.Models;
using System.Data;
using System.Data.SqlClient;

namespace Assignment__Await__02_03_2022.DataAccess
    {
    internal class CRUD : IDataAccess<ComEmployee, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        //Constructor the sql connection
        public CRUD()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=Mydatabase;Integrated Security=SSPI");
        }
      async  Task IDataAccess<ComEmployee, int>.Create(ComEmployee entity)
        {
            ComEmployee employee = new ComEmployee();
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = $"Insert into ComEmployee Values({entity.EmpNo}, '{entity.EmpName}', {entity.Salary},'{entity.Designation}',{entity.DeptNo},'{entity.Email}')";
                // Execute the Command Object
                int res =await Cmd.ExecuteNonQueryAsync();
                if (res == 0) // Some Error Occured
                {
                    Console.WriteLine("Cannot add data");
                }
                else
                {
                    // if successful store the entity into the department
                    Console.WriteLine("Sucessfully Added");
                }
            }
            catch (SqlException ex)
            {
               // Log.Logger.Error(ex.ToString());
                // return await Task.FromException<IDataAccess<ComEmployee,int>>(ex);   
            }
            finally // this will be executed irrespective of try or catch block
            {
                // if the Connection is still open the close it
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }
            //return employee;

        }
        async Task IDataAccess<ComEmployee, int>.Delete(int id)
        {
            ComEmployee employee = new ComEmployee();
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
            //return employee;
        }
        async Task IDataAccess<ComEmployee, int>.Update(int id, ComEmployee entity)
        {

            ComEmployee employee = new ComEmployee();
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

                    int res = Cmd.ExecuteNonQuery();

                    if (res == 0)
                    {
                        employee = null;
                    }
                    else
                    {
                        employee = new ComEmployee();
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
          //  return employee;



        
        
        }
       async Task< IEnumerable<ComEmployee>> IDataAccess<ComEmployee, int>.GetData()
        {
            List<ComEmployee> employee = new List<ComEmployee>();
            try
            {
                // Open
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "Select * from ComEmployee";
                SqlDataReader Reader = Cmd.ExecuteReader();

                // Iterate over the Reader for Department Rows
                while (Reader.Read())
                {
                    // Read each row using the Reader
                    // and add it into the departments list by storing
                    // each column value of the record into the Department object
                    employee.Add(
                          new ComEmployee()
                          {
                              EmpNo = Convert.ToInt32(Reader["EmpNo"]),
                              EmpName = Reader["EmpName"].ToString(),
                              Salary = Convert.ToInt32(Reader["Salary"]),
                              Designation = Reader["Designation"].ToString(),
                              Email = Reader["Email"].ToString(),
                              DeptNo = Convert.ToInt32(Reader["DeptNo"])
                          }
                        );
                }
                Reader.Close();
                // Close
                Conn.Close();
            }
            catch (SqlException ex)
            {


                throw ex;
            }
            finally // this will be executed irrespective of try or catch block
            {
                // if the Connection is still open the close it
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }
           return employee;


        }
    }
}

