using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicOperationns.Models;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace ClinicOperationns.Logic
{
    
    public class Logic

    {
        ClinicManagementContext ctx;
        public Logic()
        {
            ctx = new ClinicManagementContext();    
        }

        public async void NewrPatientegestration()
        {
            int PatientNo,Amount;
            string PatientName, PatientMobileNo, BloodPressure, Cholestrol, sugar, MedicineSubscribed;
            DateTime Apdate,NextApDate;
            float patientWeight;
            int a = 0, b = 0, c = 0, d = 0, e = 0, f = 0, g = 0;
            do
            {

                Console.WriteLine("Enter Patient's Name");
                PatientName = Console.ReadLine();
                string regex = @"^[A-Z][a-z]";
                Regex rx = new Regex(regex);
                if (rx.IsMatch(PatientName))
                {
                    a++;
                }
                else
                {
                    Console.WriteLine("Enter Valid Name");
                }
            } while (a==0);

            do
            {
                Console.WriteLine("Enter Mobile Number");
                PatientMobileNo = Console.ReadLine();
                if (PatientMobileNo.Length == 10)
                {
                    b++;
                }
            } while (b==0);

            do
            {
                Console.WriteLine("Enter weight ");
                patientWeight = float.Parse(Console.ReadLine());
                if (patientWeight > 0)
                {
                    c++;
                }
                else
                {
                    Console.WriteLine("Weight cannot be negative\n");
                }

            } while (c==0);

            do
            {
                Console.WriteLine("Patients BP (high / low / Normal)");
                BloodPressure = Console.ReadLine().ToLower();
                if (BloodPressure== "high" || BloodPressure == "low" || BloodPressure == "normal")
                {
                    d++;
                }
                else
                {
                    Console.WriteLine("Blood Pressure can be high,low,normal\n");
                }

            } while (d==0);

            do
            {
                Console.WriteLine("Patients Cholestrol (CDL / HDL)");
                Cholestrol = Console.ReadLine().ToUpper();
                if (Cholestrol == "CDL" || Cholestrol == "HDL")
                {
                    e++;
                }
                else
                {
                    Console.WriteLine("Cholestrol can either be HDL or CDL\n");
                }

            } while (e == 0);
            do
            {
                Console.WriteLine("is patient diabetic (Yes or No)");
                sugar = Console.ReadLine().ToLower();
                if (sugar == "yes" || sugar == "no")
                {
                    f++;
                }
                else
                {
                    Console.WriteLine("Please enter yes or no");
                }
            } while (f==0);
            do
            {
                Console.WriteLine("Enter Amount");
                Amount=Convert.ToInt32(Console.ReadLine());
                if(Amount>0)
                {
                    g++;
                }
                else
                {
                    Console.WriteLine("Enter Amount again");
                }

            }while (g==0);
              
               
           
            

            Console.WriteLine("Medicine subscribed");
            MedicineSubscribed = Console.ReadLine();


           // Console.WriteLine("Current Date Appointment Date (Enter in format yyyy-mm-dd)");
            Apdate = DateTime.Now;
            Console.WriteLine("next Appointment Date (Enter in format yyyy-mm-dd)");
            NextApDate = Convert.ToDateTime(Console.ReadLine());

            Patient patient = new Patient()
            {
                PatientName = PatientName,
                PatientMobNo=PatientMobileNo,
                
                



            };
            await ctx.Patients.AddAsync(patient);
            await ctx.SaveChangesAsync();
            PatientMedInfo patientMedInfo = new PatientMedInfo()
            {
                PatientNo = patient.PatientNo,
                PatientWeight= patientWeight,
                BloodPressure=BloodPressure,
                Cholestrol=Cholestrol,
                Sugar=sugar,
                MedicineSubscribed=MedicineSubscribed,
                AppointmentDate=Apdate,
                NextAppointment=NextApDate, 
                Amount=Amount



            };
            await ctx.PatientMedInfos.AddAsync(patientMedInfo);
            await ctx.SaveChangesAsync();

        }

    }
}
