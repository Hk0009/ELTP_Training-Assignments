using ClinicSystem.Models;
using ClinicSystem.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;




// See https://aka.ms/new-console-template for more information
operations OP = new operations();
int a = 0;

do
{
    Console.WriteLine("1.Enter 1. new Patient and his medical info\n" +
        "2.Enter 2  to enter Old patients no and enter his new medical details\n" +
        "3.Enter 3 to view Patients Informaton\n " +
        "4.Enter 4 to view Daily collection\n" +
        "5. ENter 5 to clear the screen \n" +
        "6. Enter 6 to exit");
    int input = Convert.ToInt32(Console.ReadLine());
    switch (input)
    {
        case 1:
            OP.NewrPatientegestration();


            break;
        case 2:
            OP.checkPatientagainAsync();

            break;
        case 3:
            OP.ViewInformation();
            break;
        case 4:
            OP.DailyCollectionbydate();
            break;
        case 5:
            Console.Clear();
            break;
        case 6:
            a++;
            break;
        default:

            break;
    }



} while (a == 0);