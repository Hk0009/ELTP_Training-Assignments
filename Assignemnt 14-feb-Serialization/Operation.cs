using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Assignemnt_14_feb_Serialization
{
    
    internal class Operation
    {
        FileOperation operation = new FileOperation();
        string path = @"C:\Serialize";
        public void CreateFile(Employee emp, double HRA, double TA, double DA, double gross, double tax, int netSalary)
        {


               string filePath = $"{path}\\{emp.EmpNo}";

            FileStream fs = new FileStream(filePath, FileMode.CreateNew);
            BinaryFormatter formatter = new BinaryFormatter();
            byte[] content = new UTF8Encoding(true).GetBytes(
                               $"-------------------------Salary Slip--------------------------\n" +
                               $"| EmpNo: {emp.EmpNo}            EmpName: {emp.EmpName}       |\n" +
                               $"| DeptName: {emp.DeptName}   Designation: {emp.Designation}  |\n" +
                               $"|____________________________________________________________|\n" +
                               $"|Income (Rs.)                  | Deduction (Rs.)             |\n" +
                               $"|------------------------------------------------------------|\n" +
                               $"|Basic Salary: {emp.Salary}    |                             |\n" +
                               $"|HRA:         {HRA}            |                             |\n" +
                               $"|TA:           {TA}            |                             |\n" +
                               $"|DA:            {DA}           |                             |\n" +
                               $"|------------------------------------------------------------|\n" +
                               $"|Gross:                        |          {gross}            |\n" +
                               $"|------------------------------------------------------------|\n" +
                               $"|Total tax                     |  Tax: {tax}                 |\n" +
                               $"|------------------------------------------------------------|\n" +
                               $"|NetSalary:                    |      {netSalary}            |\n" +
                               $"|------------------------------------------------------------|\n" +
                               $"|NetSalary in Words:{FileOperation.NumberToWords(netSalary)}only|\n" +
                               $"--------------------------------------------------------------");

                formatter.Serialize(fs, content);
                fs.Close();
               
              
           

        }
    }
}
