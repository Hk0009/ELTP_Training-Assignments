using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantBilling.Models;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
namespace RestaurantBilling.Logic
{
    internal class Logic
    {
        RestaurantContext ctx;
        public Logic()
        {
            ctx = new RestaurantContext();  
        }
        string CustomerName, CustomerMobile;
        int CustomerId, DishId, Quantity, Total,input;
        int a = 0, b = 0, c = 0, d = 0, e = 0, f = 0, g = 0;

        public async void MakeNewOrder()
        {
            try
            {
                do
                {
                    Console.WriteLine("Enter Customer Name");
                    CustomerName=Console.ReadLine();
                    string regex = @"^[A-Z][a-z]";
                    Regex rx = new Regex(regex);
                    if (rx.IsMatch(CustomerName))
                    {
                        a++;
                    }
                    else
                    {
                        Console.WriteLine("Enter Valid Name Characters strting with upper case ");
                    }

                } while(a==0);

                do
                {
                    Console.WriteLine("Enter Customer MobileNo ");
                    CustomerMobile=Console.ReadLine();  
                    if(CustomerMobile.Length==10)
                    {
                        b++;
                    }
                    else
                    {
                        Console.WriteLine("Mobile No shoud contain atleast 10 digits");
                    }

                }while(b==0);
                Customerinfo customer = new Customerinfo()
                {
                    CustomerName = CustomerName,
                    CustomerMobile = CustomerMobile,
                };
                await ctx.Customerinfos.AddAsync(customer);
               

                Console.WriteLine("List of Dishes you can order");
                var Dish =  ctx.DishInfos.ToListAsync().Result;
                foreach(var res1 in Dish)
                {
                    Console.WriteLine($"DishId={res1.DishId} DishName={res1.DishName} Price={res1.Price}");
                }
                do
                {
                    Customerinfo customer1 = new Customerinfo();
                    Console.WriteLine("Enter Dish Id");
                    DishId = Convert.ToInt32(Console.ReadLine());
                    // Order order = new Order();
                    var search = await ctx.DishInfos.FindAsync(DishId);
                    int i = 0;
                   

                  
                    Console.WriteLine("Enter Quantity");
                    Quantity = Convert.ToInt32(Console.ReadLine());
                    Total = (int)Quantity * (int)search.Price;
                    Order order1 = new Order()
                    {
                        CustomerId = customer1.CustomerId,
                        Quantity=Quantity,
                        Toatal=Total,
                        DishId=DishId,

                };
                    await ctx.Orders.AddAsync(order1);
                   // await ctx.SaveChangesAsync();
                    Console.WriteLine("Enter y or Y to add more");

                  

                }while(input=='Y' || input=='y');
                Order order = new Order();
                Total = ctx.Orders.Where(x => x.CustomerId == order.CustomerId).Sum(x => (int)x.Toatal);
                BillInfo billInfo = new BillInfo()
                {
                    CustomerId=order.CustomerId,
                    Total=Total
                    

                };
              await ctx.BillInfos.AddAsync(billInfo);
              await ctx.SaveChangesAsync();
          







            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public  void getBill()
        {
            var bills = ctx.BillInfos.ToListAsync();
            Console.WriteLine("Get bill by Customer ID");
            int id = Convert.ToInt32(Console.ReadLine());
            var getbill = ctx.BillInfos.Where(x => x.CustomerId == id);
            foreach (var record in getbill)
            {
                Console.WriteLine($"{record.BillNo} {record.CustomerId}  {record.Total}");
            }

        }
       

    }
}
