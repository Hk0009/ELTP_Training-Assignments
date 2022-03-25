// See https://aka.ms/new-console-template for more information
using test_03_11_2022.DataAccess;
using test_03_11_2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;



IDataAccess<Patient, int> deptdb = new patientDataaccess();
IDataAccess<PatientMedInfo, int> empdb = new patientmedinfodataaccess();
Patient patient = new Patient();    
PatientMedInfo MedInfo = new PatientMedInfo();   
report report = new report();
report.patientwisereport(patient, MedInfo, 10);

Console.WriteLine("Enter Dept name");
double Weight1 = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Enter Dept Number");
string? Bloodpressure1 = Console.ReadLine();
Console.WriteLine("Enter Capacity");
var sugar1 = Console.ReadLine();
Console.WriteLine("Enter Location ");
var cholestrol1 = Console.ReadLine();
Console.WriteLine();
System.DateTime AppointmentDate1 = int.Parse(Console.ReadLine());
var MedicineSubscribe1 = Console.ReadLine();
PatientMedInfo db = new()
{
    PatientWeight = Weight1,
    BloodPressure = Bloodpressure1,
    Sugar = sugar1,
    Cholestrol = cholestrol1,
    AppointmentDate = AppointmentDate1,
    MedicineSubscribe = MedicineSubscribe1,

};
var insertDept = await empdb.CreateAsync(db);
if (insertDept == null)
{
    Console.WriteLine("Fail");
}
else
{
    Console.WriteLine("Data Added sucessfully");
}
