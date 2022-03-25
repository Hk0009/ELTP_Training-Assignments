using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_02_03_2022.Models;
using System.Data;
using System.Data.SqlClient;

namespace Assignment_02_03_2022.DataAccess
{
    internal class CRUDDEP : IDataAccess<Mydatabase, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        public CRUDDEP()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=Mydatabase;Integrated Security=SSPI");
        }
       async Task<Mydatabase> IDataAccess<Mydatabase, int>.CreateAsync(Mydatabase entity)
        {
            Mydatabase department = null;
            try
            {

                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = $"Insert into Mydatabase Values({entity.DeptNo}, '{entity.DeptName}', '{entity.Location}',{entity.Capacity})";
                // Execute the Command Object
                int res =await Cmd.ExecuteNonQueryAsync();
                if (res == 0) // Some Error Occured
                {
                    department = null;
                }
                else
                {
                    // if successful store the entity into the department
                    department = new Mydatabase();
                    department = entity;
                }
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
            return department;
        }
       async Task<Mydatabase> IDataAccess<Mydatabase, int>.DeleteAsync(int id)
        {
            Mydatabase department = new Mydatabase();
            try
            {

                Conn.Open();
                // Create paramerized query
                Cmd.CommandText = "Delete From Mydatabase where DeptNo=@DeptNo";

                SqlParameter pDeptNo = new SqlParameter();
                pDeptNo.ParameterName = "@DeptNo";
                pDeptNo.SqlDbType = SqlDbType.Int;
                pDeptNo.Direction = ParameterDirection.Input;
                pDeptNo.Value = id;



                // Add parameters into the Parameters Collection of the Command object
                Cmd.Parameters.Add(pDeptNo);

                // Call the execute method
                int res =await Cmd.ExecuteNonQueryAsync();

                if (res == 0)
                {
                    department = null;
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
            return department;
        }
        async Task<IEnumerable<Mydatabase>> IDataAccess<Mydatabase, int>.GetDataAsync()
        {
            List<Mydatabase> departments = new List<Mydatabase>();
            try
            {
                // Open
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "Select * from Mydatabase";
                SqlDataReader Reader =await Cmd.ExecuteReaderAsync();

                // Iterate over the Reader for Department Rows
                while (Reader.Read())
                {
                    // Read each row using the Reader
                    // and add it into the departments list by storing
                    // each column value of the record into the Department object
                    departments.Add(
                          new Mydatabase()
                          {
                              DeptNo = Convert.ToInt32(Reader["DeptNo"]),
                              DeptName = Reader["DeptName"].ToString(),
                              Location = Reader["Location"].ToString(),
                              Capacity = Convert.ToInt32(Reader["Capacity"])
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
            return departments;
        }
       async Task<Mydatabase> IDataAccess<Mydatabase, int>.GetDataAsync(int id)
        {
            Mydatabase department = new Mydatabase();
            try
            {
                Conn.Open();
                // We can also pass the Command Tetx and Commection Object to the Constrctor
                Cmd = new SqlCommand($"Select * from Mydatabase where DeptNo = {id}", Conn);
                SqlDataReader Reader =await Cmd.ExecuteReaderAsync();
                while (Reader.Read())
                {
                    department.DeptNo = Convert.ToInt32(Reader["DeptNo"]);
                    department.DeptName = Reader["DeptName"].ToString();
                    department.Location = Reader["Location"].ToString();
                    department.Capacity = Convert.ToInt32(Reader["Capacity"]);
                }
                Reader.Close();
            }
            catch (SqlException ex)
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
            return department;
        }
        async Task<Mydatabase> IDataAccess<Mydatabase, int>.UpdateAsync(int id, Mydatabase entity)
        {
            Mydatabase department = new Mydatabase();
            try
            {
                // check if id and the DeptNo value of the entity is same
                if (id == entity.DeptNo)
                {
                    Conn.Open();
                    // Create paramerized query
                    Cmd.CommandText = "Update Department Set DeptName=@DeptName, Location=@Location, Capacity=@Capacity where DeptNo=@DeptNo";

                    SqlParameter pDeptNo = new SqlParameter();
                    pDeptNo.ParameterName = "@DeptNo";
                    pDeptNo.SqlDbType = SqlDbType.Int;
                    pDeptNo.Direction = ParameterDirection.Input;
                    pDeptNo.Value = id;


                    SqlParameter pDeptName = new SqlParameter();
                    pDeptName.ParameterName = "@DeptName";
                    pDeptName.SqlDbType = SqlDbType.VarChar;
                    pDeptName.Size = 200;
                    pDeptName.Direction = ParameterDirection.Input;
                    pDeptName.Value = entity.DeptName;

                    SqlParameter pLocation = new SqlParameter();
                    pLocation.ParameterName = "@Location";
                    pLocation.SqlDbType = SqlDbType.VarChar;
                    pLocation.Size = 200;
                    pLocation.Direction = ParameterDirection.Input;
                    pLocation.Value = entity.Location;

                    SqlParameter pCapacity = new SqlParameter();
                    pCapacity.ParameterName = "@Capacity";
                    pCapacity.SqlDbType = SqlDbType.Int;
                    pCapacity.Direction = ParameterDirection.Input;
                    pCapacity.Value = entity.Capacity;

                    // Add parameters into the Parameters Collection of the Command object
                    Cmd.Parameters.Add(pDeptNo);
                    Cmd.Parameters.Add(pDeptName);
                    Cmd.Parameters.Add(pLocation);
                    Cmd.Parameters.Add(pCapacity);

                    // Call the execute method
                    int res =await Cmd.ExecuteNonQueryAsync();

                    if (res == 0)
                    {
                        department = null;
                    }
                    else
                    {
                        department = entity;
                    }
                }
                else
                {
                    throw new Exception($"the {id} and {entity.DeptNo} does not match");
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
            return department;
        }


    }
}
