using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignemnt_14_feb_Serialization
{    
    internal class FileOperation
    {
        
        

            public void CalculateTax( IEnumerable <Employee> emps)
            {
                Operation file_operation = new Operation();
                var taxGroup = from e in emps
                               group e by e.Designation into desig
                               select new
                               {
                                   Designation = desig.Key,
                                   Records = desig.ToList()
                               };

                foreach (var item in taxGroup)
                {
                    foreach (var record in item.Records)
                    {
                        double HRA = 0;
                        double TS = 0;
                        double DA = 0;
                        double gross = 0;
                        double tax = 0;
                        int netSalary = 0;
                        if (record.Designation == "Manager")
                        {
                            HRA = (record.Salary * .1);
                            TS = (record.Salary * .15);
                            DA = (record.Salary * .15);
                        }
                        if (record.Designation == "Director")
                        {
                            HRA = (record.Salary * .2);
                            TS = (record.Salary * .3);
                            DA = (record.Salary * .4);
                        }
                        gross = HRA + TS + DA + record.Salary;

                        if (record.Salary > 500000 && record.Salary <= 1000000)
                        {
                            tax = gross * .2;
                        }
                        if (record.Salary > 1000000 && record.Salary <= 2000000)
                        {
                            tax = gross * .25;
                        }
                        if (record.Salary > 2000000)
                        {
                            tax = gross * .3;
                        }
                       
                        netSalary = (int)(gross - tax);
                        file_operation.CreateFile(record, HRA, TS, DA, gross, tax, netSalary);


                    }
                }
            }
            public static string NumberToWords(int number)
            {
                if (number == 0)
                    return "zero";
                if (number < 0)
                    return "minus " + NumberToWords(Math.Abs(number));
                string words = "";

                if ((number / 100000) > 0)
                {
                    words += NumberToWords(number / 100000) + " lacs ";
                    number %= 100000;
                }
                if ((number / 1000) > 0)
                {
                    words += NumberToWords(number / 1000) + " thousand ";
                    number %= 1000;
                }
                if ((number / 100) > 0)
                {
                    words += NumberToWords(number / 100) + " hundred ";
                    number %= 100;
                }
                if (number > 0)
                {
                    if (words != "")
                        words += "and ";
                    String[] unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                    String[] tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
                    if (number < 20)
                        words += unitsMap[number];
                    else
                    {
                        words += tensMap[number / 10];
                        if ((number % 10) > 0)
                            words += "-" + unitsMap[number % 10];
                    }
                }
                return words;
            }
        }
    }

