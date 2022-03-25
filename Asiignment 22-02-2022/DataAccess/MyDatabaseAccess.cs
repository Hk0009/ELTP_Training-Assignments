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
    internal class MyDatabaseAccess:IDataAccess<MyDatabase>
    {
        SqlConnection Conn = new SqlConnection("Data Source=.;Initial Catalog=Mydatabase;Integrated Security=SSPI");
        public void Add()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Mydatabase", Conn);
            DataSet Ds = new DataSet();
            adapter.Fill(Ds,"Mydatabase");
            DataRow dr = Ds.Tables["Mydatabase"].NewRow();
            Console.WriteLine("Enter the DeptNo");
            dr["DeptNo"]=Console.ReadLine();
            dr["DeptName"] = Console.ReadLine();
            dr["Location"] = Console.ReadLine();
            dr["Capctay"]=Console.ReadLine();

            Ds.Tables["Mydatabase"].Rows.Add(dr);
            SqlCommandBuilder bldr = new SqlCommandBuilder(adapter);
            var result = adapter.Update(Ds, "Mydatabase");
            if (result == null)
            {
                Console.WriteLine("Add Faild");
            }
            else
            {
                Console.WriteLine("Add Success");
            }

        }
        public void Read()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Mydatabase", Conn);
            DataSet Ds = new DataSet();
            adapter.Fill(Ds, "Mydatabase");
            DataRowCollection dataRows = Ds.Tables["Mydatabase"].Rows;
            foreach (DataRow row in dataRows)
            {
                Console.WriteLine($"{row["DeptNo"]}     {row["DeptName"]}       {row["Location"]}       {row["Capctay"]}");
            }

        }
        public void Update()

        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Mydatabase", Conn);
            DataSet Ds = new DataSet();
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(Ds, "Mydatabase");
            Console.WriteLine("Enter the id no for updating");
            int id = Convert.ToInt32(Console.ReadLine());
            DataRow DrFind = Ds.Tables["Mydatabase"].Rows.Find(id);
            //  Update its Values
            Console.WriteLine("Enter Deptno you need to update");
            Console.WriteLine("enter DeptName");
            DrFind["DeptName"] = Console.ReadLine();
            Console.WriteLine("enter Location");
            DrFind["Location"] = Console.ReadLine();
            Console.WriteLine("enter Capacity");
            DrFind["Capctay"] = Console.ReadLine();
            // 6. Command Build and Update
            SqlCommandBuilder bldr2 = new SqlCommandBuilder(adapter);
            var result = adapter.Update(Ds, "Mydatabase");
            if (result == null)
            {
                Console.WriteLine("Update Failed");
            }
            else
            {
                Console.WriteLine("Update Successfully");
            }
        }
        public void Delete()
        {

            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Mydatabase", Conn);
            DataSet Ds = new DataSet();
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(Ds, "Mydatabase");
            Console.WriteLine("Enter the id no you need to delete");
            int id = Convert.ToInt32(Console.ReadLine());
            //1. Search Record BAsed on Primary Key
            DataRow DrFind = Ds.Tables["Mydatabase"].Rows.Find(id);
            // 2. Call Delete() method on the searched record
            DrFind.Delete();
            // 3. Command Build and Update
            SqlCommandBuilder bldr2 = new SqlCommandBuilder(adapter);
            var result = adapter.Update(Ds, "Mydatabase");
            if (result == null)
            {
                Console.WriteLine("Delete Failed");
            }
            else
            {
                Console.WriteLine("Delete Successfull");
            }
        }
    }
}
