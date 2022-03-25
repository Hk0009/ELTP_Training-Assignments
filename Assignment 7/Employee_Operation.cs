using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    internal class Employee_Operation
    {
        public  void EmployeeAscending(ref Employees emps)
        {

            //printing empname  in ascending
            var res = from e in emps   
                      orderby e.EmpName
                      select e;
            foreach (var e in res)
            {
                Console.WriteLine($"{e.EmpName}");
            }

        }

        public void DeptCount(ref Employees emps)
        {
            var res1 = (from e in emps
                        group e by e.DeptName into deptgroup  // putting into the group
                        select new
                        {
                            DeptName = deptgroup.Key,  
                            DeptCount = deptgroup.Count()  // with the key refrence 
                        });
            foreach (var record in res1)
            {
                Console.WriteLine($"Group by ={record.DeptName} and count ={record.DeptCount}");
            }
        }
        static void printData(IEnumerable<Employee> emps)
        {
            foreach(var record in emps)
            {
                Console.WriteLine($"Employee name {record.EmpName}");
            }

        }
        public void DeptWiseSumSalary(ref Employees emps)
        {
            var res1 = (from e in emps
                        group e by e.DeptName into deptgroup
                        select new
                        {
                            DeptName = deptgroup.Key,
                            SumSalary = deptgroup.Sum(x => x.Salary),
                            Records = deptgroup.ToList()
                        });

            foreach (var record in res1)
            {
                Console.WriteLine($"Group Key = {record.DeptName} and Sum of Salary {record.SumSalary}");
                printData(record.Records);
            }
        }
        public void DeptWiseMaxSalary(ref Employees emps)
        {
            var res1 = (from e in emps
                        group e by e.DeptName into deptgroup
                        select new
                        {
                            DeptName = deptgroup.Key,
                            MaxSalary = deptgroup.Max(x => x.Salary)
                        });

            foreach (var record in res1)
            {
                Console.WriteLine($"Group Key = {record.DeptName} and Sum of Salary {record.MaxSalary}");
            }
        }
        public void DeptWiseMinSalary(ref Employees emps)
        {
            var res1 = (from e in emps
                        group e by e.DeptName into deptgroup
                        select new
                        {
                            DeptName = deptgroup.Key,
                            MinSalary = deptgroup.Min(x => x.Salary)
                        });

            foreach (var record in res1)
            {
                Console.WriteLine($"Group Key = {record.DeptName} and Sum of Salary {record.MinSalary}");
            }
        }
        public void DeptWiseAvgSalary(ref Employees emps)
        {
            var res1 = (from e in emps
                        group e by e.DeptName into deptgroup
                        select new
                        {
                            DeptName = deptgroup.Key,
                            AvgSalary = deptgroup.Average(x => x.Salary)
                        });

            foreach (var record in res1)
            {
                Console.WriteLine($"Group Key = {record.DeptName} and Sum of Salary {record.AvgSalary}");
            }
        }
        public void DesigWiseGroup(ref Employees emps)
        {
            var res1 = (from e in emps
                        group e by e.Designation into desiggroup
                        select new  // The Group Data is Stored in the Anonymous Type 
                        {
                            DesigName = desiggroup.Key, // Key aka the Property on WHich the Group is created
                            Records = desiggroup.ToList(),
                            // List of Records per Group
                        });

            foreach (var record in res1)
            {
                Console.WriteLine($"Group Key = {record.DesigName} ");

            }
        }
        public void DisplayEmployee(ref Employees emps)
        {
            var DisplEmp = emps.Where(e => e.Designation == "Manager" || e.Designation == "Director");


            foreach (var record in DisplEmp)
            {

                Console.WriteLine($" {record.EmpName} = {record.Designation}");

            }


        }
        public void SalaryRange(ref Employees emps)
        {
            var rangeSal = emps.Where(e => e.Salary >= 25000 && e.Salary <= 75000)
                               .Select(x => x);
            foreach (var record in rangeSal)
            {
                Console.WriteLine($"{record.EmpName}");
            }



        }
        public void secondMaxSalaryDeptWise(ref Employees emps)
        {
            var ref1 = (from e in emps
                        group e by e.DeptName into deptgroup
                        select new
                       
                        {
                            DeptName = deptgroup.Key,
                            //EmpName=deptgroup.Where(),
                            SecondmaxSalary = deptgroup.OrderByDescending(x => x.Salary).Select(x => x.Salary).Distinct().Take(2).Skip(2 - 1).FirstOrDefault(),
                            Records = deptgroup.ToList()

                        }); ;
            foreach (var record in ref1)
            {
                Console.WriteLine($"{record.DeptName} ={record.SecondmaxSalary}");
                
                foreach(var record2 in record.Records)
                {
                    if (record.SecondmaxSalary == record2.Salary)
                    {

                        Console.WriteLine($"Employename = { record2.EmpName}");
                    }
                }
            }
        }
        public void SecondMaxSalary(ref Employees emps)
        {
            var employeeList = emps;
            var rangeSal = emps.OrderByDescending(x => x.Salary).Select(x => x.Salary).Distinct().Take(2).Skip(2 - 1).FirstOrDefault();
            foreach (var record in emps)
            {
                if (record.Salary == rangeSal)
                {
                    Console.WriteLine($"{record.EmpName} = {record.Salary}");
                }
            }
        }
        public void _Tax(ref Employees emps)
        {

            var res1 = from e in emps
                       group e by e.DeptName;
            foreach (var group in res1)
            {
                Console.WriteLine($"----------------------------------{group.Key}--------------------------------");
                foreach (var temp in group)
                {

                    
                    double tax = 0;
                    if (temp.Salary >= 20000 && temp.Salary <= 40000)
                    {
                        tax = (temp.Salary * 0.05) / 100;
                        Console.WriteLine($"Tax to be paid by {temp.EmpName} of {temp.DeptName} having salary {temp.Salary}/- is {Math.Round(tax)}/- rupees");
                    }

                    if (temp.Salary > 40000 && temp.Salary <= 60000)
                    {
                        tax = (temp.Salary * 0.1) / 100;
                        Console.WriteLine($"Tax to be paid by {temp.EmpName} of {temp.DeptName} having salary {temp.Salary}/- is {Math.Round(tax)}/- rupees");
                    }

                    if (temp.Salary > 60000)
                    {
                        tax = (temp.Salary * 0.15) / 100;
                        Console.WriteLine($"Tax to be paid by {temp.EmpName} of {temp.DeptName} having salary {temp.Salary}/- is {Math.Round(tax)}/- rupees");
                    }

                    else
                    {
                        Console.WriteLine($"Tax to be paid by {temp.EmpName} of {temp.DeptName} having salary {temp.Salary}/- is {Math.Round(tax)}/- rupees");
                    }
                }
            }

        }
        public void Join(ref ModifiedEmployees emps, ref Departments dept)
        {
            var join = from s in emps
                       join s1 in dept
                       on s.DeptNo equals s1.DeptNo
                       select new
                       {
                           EmployeeNo = s.EmpNo,
                           EmpName = s.EmpName,
                           Designation = s.Designation,
                           Depatment = s.DeptName,
                           Location = s1.Location,
                           salary = s.Salary


                       };
            foreach (var record in join)
            {
                Console.WriteLine($"{record.EmployeeNo}  {record.EmpName}  {record.Designation} {record.Location} {record.Depatment}  {record.salary}");
            }
        }



    }
}
