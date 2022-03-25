using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_8
{
    internal class File_operation
    {
        Employee_operation operation= new Employee_operation();
        string path = @"C:\Users\Coditas\source\repos\MiniProject-1-2-2022\Assignment 8\salary slip";
        public void CreateFile(Employee emp, double HRA, double TA, double DA, double gross, double tax,int netSalary,int Filename)
        {
           
            
            string filePath = $"{path}\\{Filename}";
            if (!File.Exists(filePath))
            {
                FileStream fs = File.Create(filePath);
                StreamWriter writer = new StreamWriter(fs);
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
                               $"|NetSalary in Words:{Employee_operation.NumberToWords(netSalary)}only|\n" +
                               $"--------------------------------------------------------------");


                fs.Write(content, 0, content.Length);
                fs.Close();
                fs.Dispose();
              
            }
            else
            {

                Console.WriteLine($"File path already exist  ");
               
            }
           
        }
    }
}