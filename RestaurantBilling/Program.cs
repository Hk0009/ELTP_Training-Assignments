using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantBilling.Models;
using RestaurantBilling.Logic;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

int i = 0;
Logic logic = new Logic();

do
{
    Console.WriteLine("1.Enter 1 to insert Data \n "+
        "2.ENter 2 to get bill by id");
    Console.WriteLine("Enter choice");
    int input = Convert.ToInt32(Console.ReadLine());
    switch(input)
    {
        case 1:
      logic.MakeNewOrder();
        break;
        case 2:
      logic.getBill();
        break;
        case 3:
            i++;
            break;

        
    }


} while (i==0);