using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


//ProcessValuesUponTypeOlder(v);

//ProcessValuesUponTypeOlder(str);

//ProcessValuesUponTypeNew(v);
//ProcessValuesUponTypeNew(str);

// Lets declare a COmplex List

List<object> objectist = new List<object>()
{
    10.687,20.686,30.098,40.9887,10.5,20.3,30.09,5.098,40.7,
    1,2,3,4,5,6,7,8,9,10,
    'A', 'B', 'C', 'D', "Mahesh", "Tejas",
    new List<int> {90,80,70,60 },
    new List<string>{ "Amitabh","Rushi","Sashi","Raj" },
   new List<Employee>{
            (new Employee() { EmpNo = 101, EmpName = "Mahesh", DeptName = "IT", Salary = 1100000, Designation = "Manager" }),
            (new Employee() { EmpNo = 102, EmpName = "Tejas", DeptName = "HR", Salary = 12000, Designation = "Intern" }),
(new Employee() { EmpNo = 103, EmpName = "Nandu", DeptName = "SL", Salary = 13000, Designation = "Director" }),
(new Employee() { EmpNo = 104, EmpName = "Anil", DeptName = "IT", Salary = 14000, Designation = "Clerk" }),
(new Employee() { EmpNo = 105, EmpName = "Jaywant", DeptName = "HR", Salary = 10000, Designation = "Staff" }),
(new Employee() { EmpNo = 106, EmpName = "Abhay", DeptName = "SL", Salary = 9000, Designation = "Emgineer" }),
(new Employee() { EmpNo = 107, EmpName = "Anil", DeptName = "IT", Salary = 8000, Designation = "Manager" }),
(new Employee() { EmpNo = 108, EmpName = "Shyam", DeptName = "HR", Salary = 7000, Designation = "Engineer" }),
(new Employee() { EmpNo = 109, EmpName = "Vikram", DeptName = "SL", Salary = 6000, Designation = "Intern" }),
(new Employee() { EmpNo = 110, EmpName = "Suprotim1", DeptName = "IT", Salary = 5000, Designation = "Manager" }),
(new Employee() { EmpNo = 111, EmpName = "Mahesh1", DeptName = "IT", Salary = 21000, Designation = "Manager" }),
(new Employee() { EmpNo = 112, EmpName = "Tejas1", DeptName = "HR", Salary = 22000, Designation = "Intern" }),
(new Employee() { EmpNo = 113, EmpName = "Nandu1", DeptName = "SL", Salary = 23000, Designation = "Director" }),
(new Employee() { EmpNo = 114, EmpName = "Anil1", DeptName = "IT", Salary = 24000, Designation = "Clerk" }),
(new Employee() { EmpNo = 115, EmpName = "Jaywant1", DeptName = "HR", Salary = 20000, Designation = "Staff" }),
(new Employee() { EmpNo = 116, EmpName = "Abhay1", DeptName = "SL", Salary = 29000, Designation = "Emgineer" })

   },
   new List<DateTime>{
        new DateTime(2012,1,1),
        new DateTime(2013,1,1),
        new DateTime(2014,1,1),
        new DateTime(2015,1,1),
        new DateTime(2016,1,1),
        new DateTime(2017,1,1),
        new DateTime(2018,1,1),
        new DateTime(2019,1,1),
        new DateTime(2020,1,1),
        new DateTime(2021,1,1),
        new DateTime(2022,1,1), }
};
//List<object[]> data = new List<object[]>();

Console.WriteLine();


//List<string> addstr = new List<string>();
//List<Employee> emp = new List<Employee>();
//List<DateTime> dateTimes = new List<DateTime>();








ProcessCollection(objectist, out List<int> addint, out List<DateTime> date, out List<string> addstr, out List<Employee> emp);
foreach(var item in emp)
{
    Console.WriteLine($"{item.DeptName}");
}
foreach(var item in emp)
{

}
/*foreach(var item in addint)
{
    Console.WriteLine(item.ToString());
}*/

static void ProcessCollection(  List<object> values, out List<int> addint, out List<DateTime> date,    out List<string> addstr ,out List<Employee> emp)
{
   date = new List<DateTime>();
    addint = new List<int>();
    addstr = new List<string>();
   // Employee emp = new Employee();
    emp = new List<Employee>();
    Console.WriteLine("Pocessing a collection");
    int sumIntList = 0;
    //List<Employee> emplist ;
    string concatStringList = string.Empty;
    int justSum = 0;
    foreach (object val in values)
    {
        switch(val)
        { 
   
            case IEnumerable<int> intList:
                foreach (var item in intList)
                {
                    addint.Add(item);   
                }
                //Console.WriteLine($"SUm of all numbers in LIst is = {sumIntList}");
                break;
            case IEnumerable<string> strList:
                foreach (var item in strList)
                {
                    addstr.Add(item);
                }
               // Console.WriteLine($"Concatination {concatStringList}");
                break;
            case IEnumerable<Employee> empList:
              
                 // List<Employee> list = new List<Employee>();
                foreach(Employee emp1 in empList)
                {
                  emp.Add(emp1);   
                }
                break;
            //Console.WriteLine()
            case IEnumerable<DateTime> date1:
                foreach(DateTime dat1 in date1)
                {
                    date.Add(dat1); 
                }

                break; 
          
           /* default:
                Console.WriteLine("Finally.....");
                break;*/
        }
    }
}
public record Employee
{
    public int EmpNo { get; set; }
    public string EmpName { get; set; }
    public string DeptName { get; set; }
    public int Salary { get; set; }


    public string Designation { get; set; }
}