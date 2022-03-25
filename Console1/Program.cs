using ClinicOperationns.Models;
using ClinicOperationns.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;




// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Logic data = new Logic();   
int a = 0;

do
{
    Console.WriteLine("1.Enter Patient and his medical info" +
        "2.For Patient wise report" +
        "3.Update Patient Information" +
        "4.Update Medical info" +
        "5.Delete meical info through ID" +
        "6.Delete patient info through ID");
    int input = Convert.ToInt32(Console.ReadLine());
    switch(input)
    {
        case 1:
            data.NewrPatientegestration();

    break;
case 2:
    break;
case 3:
    break;
default:

    break;
}
   


} while (a == 0);