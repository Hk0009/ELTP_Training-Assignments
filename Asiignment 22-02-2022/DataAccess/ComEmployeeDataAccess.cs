using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asiignment_22_02_2022.Data;
using System.Data;
using System.Data.SqlClient;


namespace Asiignment_22_02_2022.DataAccess
{
    internal class ComEmployeeDataAccess : IDataAccess<ComEmployee>
    {
       
             SqlConnection Conn = new SqlConnection("Data Source=.;Initial Catalog=MyDatabase;Integrated Security=SSPI");
               

        public void Add()
        {

            //Disconnected architecture refers to the mode of architecture
            //in Ado.net where the connectivity between the database and application is not maintained
            //for the full time. Connectivity within this mode is established only to read the data
            //from the database and finally to update the data within the database.
            //1 a.  Create the DataSet we need the 'DataAdapter'
            //this object is responsible for connection and writing select statement
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from ComEmployee",Conn);
            //1.b This object will create DataSet in Client's memory and 'fill' data in it by creating DataTable object in it
           DataSet ds = new DataSet();
            //1.c  A 'Fill()' method to fill received data from DB to DataSet
            adapter.Fill(ds,"ComEmployee");
            DataRow dr = ds.Tables["ComEmployee"].NewRow();
            Console.WriteLine("Enter the EMpNo");
            dr["EmpNo"] = Console.ReadLine();
            Console.WriteLine("Enter the EMpName");
            dr["EmpName"] = Console.ReadLine();
            Console.WriteLine("Enter the Salary");
            dr["Salary"] = Console.ReadLine();
            Console.WriteLine("Enter the Designation");
            dr["Designation"] = Console.ReadLine();
            Console.WriteLine("Enter the DeptNo");
            dr["DeptNo"] = Console.ReadLine();
            Console.WriteLine("Enter the Email");
            dr["Email"]=Console.ReadLine();
            // 1.d Add the Dr in Rows Collection of Employee Table in DataSet
            ds.Tables["ComEmployee"].Rows.Add(dr);
            //1.e to send updated commmand back to database we use builder
            //This accepts an Adapter object as inout parameter
            SqlCommandBuilder command = new SqlCommandBuilder(adapter);
            //1.f Invoke the 'Update()' method on the Adapter object to update data from DataSet to Corresponding table in Database
            var res = adapter.Update(ds,"ComEmployee");
            if(res==null)
            {
                Console.WriteLine("Add Failed");
            }
            else
            {
                Console.WriteLine("Add Successfully");
            }

        }
        public void Read()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from ComEmployee", Conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "ComEmployee");
            DataRowCollection dataRows = ds.Tables["ComEmployee"].Rows;
            foreach (DataRow row in dataRows)
            {
                Console.WriteLine($"{row["Empno"]}     {row["Empname"]}       {row["Salary"]}   {row["Designation"]}    {row["Deptno"]} {row["Email"]}");
            }

        }
        public void Update()

        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from ComEmployee", Conn);
            DataSet ds = new DataSet();

            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(ds, "ComEmployee");
            Console.WriteLine("Enter the id ");
            int id = Convert.ToInt32(Console.ReadLine());
            DataRow DrFind = ds.Tables["ComEmployee"].Rows.Find(id);
            Console.WriteLine("Enter ComEmployee name");

            DrFind["Empname"] = Console.ReadLine();
            Console.WriteLine("Enter ComEmployee Salary");
            
            DrFind["Salary"]=Console.ReadLine();
            Console.WriteLine("Enter ComEmployee name");

            DrFind["Designation"] = Console.ReadLine();
            Console.WriteLine("Enter ComEmployee name");

            DrFind["DeptNo"] = Console.ReadLine();
            Console.WriteLine("Enter ComEmployee Email");
            DrFind["Email"]=Console.ReadLine();


            SqlCommandBuilder command = new SqlCommandBuilder(adapter);
            var result =adapter.Update(ds, "ComEmployee");
            if (result == null)
            {
                Console.WriteLine("Update Faild");
            }
            else
            {
                Console.WriteLine("Update Success");
            }


        }
        public void Delete()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from ComEmployee", Conn);
            DataSet ds = new DataSet();
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(ds, "ComEmployee");
            Console.WriteLine("Enter the id you want to delete");
            int id = Convert.ToInt32(Console.ReadLine());
            DataRow DrFind=ds.Tables["ComEMployee"].Rows.Find(id);
            DrFind.Delete();
            SqlCommandBuilder command2 = new SqlCommandBuilder(adapter);
            var result = adapter.Update(ds, "ComEmployee");
            if (result == null)
            {
                Console.WriteLine("Delete Failed");
            }
            else
            {
                Console.WriteLine("Delete Success");
            }


        }
    }
}
