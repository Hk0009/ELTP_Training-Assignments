using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Assignment__Await__02_03_2022.Models;

namespace Assignment__Await__02_03_2022.DataAccess
{
    internal class CrudDepartment : IDataAccess<Mydatabase,int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        //Constructor the sql connection
        public CrudDepartment()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=Mydatabase;Integrated Security=SSPI");
        }
         async Task<IEnumerable<Mydatabase>> IDataAccess<Mydatabase,int>.GetData()
        {
            List<Mydatabase> mydatabase = new List<Mydatabase>();
            try
            {
                
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "Select * from Mydatabase";
                var deptData = await Cmd.ExecuteReaderAsync();
                //var r = EmpData;
                while (deptData.Read())
                {
                    mydatabase.Add(new Mydatabase()
                    {
                        DeptNo = Convert.ToInt32(deptData["DeptNo"]),
                        DeptName = deptData["DeptName"].ToString(),
                        Capacty = Convert.ToInt32(deptData["Capacity"]),
                        Location = deptData["Location"].ToString(),


                    });
                }
                deptData.Close();
                Conn.Close();
                //return Task.FromResult(depts).Result;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error occured {ex.Message}");
               // return null;
            }
            finally // this will be executed irrespective of try or catch block
            {
                // if the Connection is still open the close it
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }
            return mydatabase;

        }

         async Task  IDataAccess<Mydatabase,int>.Create(Mydatabase entity)
        {

            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = $"Insert into Mydatabase Values({entity.DeptNo}, '{entity.DeptName}', '{entity.Location}', {entity.Capacty}  )";
                int res = await Cmd.ExecuteNonQueryAsync(); //executes the sql query and returns number of rows affected
                if (res == 0)
                {
                    Console.WriteLine("Department cannot be added\n");
                }
                else
                {
                    Console.WriteLine("Department added sucessfully");
                }
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
            //  return employee;
        }

        async Task IDataAccess<Mydatabase,int>.Update(int id, Mydatabase entity)
        {
            Mydatabase dept = new Mydatabase();
            try
            {
                if (id == entity.DeptNo)
                {
                    Conn.Open();
                    Cmd = new SqlCommand();
                    Cmd.Connection = Conn;
                    Cmd.CommandText = "Update Mydatabase Set  DeptName=@DeptName, Location=@Location, Capctay7=@pCapacty where DeptNo=@DeptNo";

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
                    pLocation.Size = 100;
                    pLocation.Direction = ParameterDirection.Input;
                    pLocation.Value = entity.Location;

                    SqlParameter pCapacty = new SqlParameter();
                    pCapacty.ParameterName = "@pCapacty";
                    pCapacty.SqlDbType = SqlDbType.Int;
                    pCapacty.Direction = ParameterDirection.Input;
                    pCapacty.Value = entity.Capacty;


                    Cmd.Parameters.Add(pDeptNo);
                    Cmd.Parameters.Add(pDeptName);
                    Cmd.Parameters.Add(pLocation);
                    Cmd.Parameters.Add(pCapacty);

                    int res = await Cmd.ExecuteNonQueryAsync();
                    if (res == 0)
                    {
                        Console.WriteLine("couldn't update department");
                    }
                    else
                    {
                        Console.WriteLine("department updated sucessfully");
                    }
                }
                else
                {
                    throw new Exception($"the {id} and {entity.DeptNo} does not match");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"{ex.Message}");
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

        }

        async Task IDataAccess<Mydatabase, int>.Delete(int id)
        {
            Mydatabase dept = new Mydatabase();
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "Delete From Mydatabase10088 where DeptNo=@DeptNo";
                SqlParameter pDeptNo = new SqlParameter();
                pDeptNo.ParameterName = "@DeptNo";
                pDeptNo.SqlDbType = SqlDbType.Int;
                pDeptNo.Direction = ParameterDirection.Input;
                pDeptNo.Value = id;
                Cmd.Parameters.Add(pDeptNo);
                int res = await Cmd.ExecuteNonQueryAsync();

                Conn.Close();
                //return res;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"{ex.Message}");
                //return 0;
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
               // return 0;
                throw ex;
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
