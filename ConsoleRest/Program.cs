using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalRest;

namespace ConsoleRest
{
    class Program
    {
        static void Main(string[] args)
        {

            Facade facade = new Facade();

//facade.DropAllTables();

         //   facade.AddProductTypes("fru");
            //facade.AddMeasureType("ml");
            //facade.AddMeasureType("kg");
            //facade.AddProduct("orange", "fruit", "kg");
            //facade.AddPurchase("orange", 15, 2);


            //facade.AddDishe("borsh", "ml");

            //facade.AddConsumption("borsh", "orange", 5);

            //facade.AddSale("borsh", 25, 1);
            //facade.AddRecipe("borsh", "textOfRecipe");

            //    for (int i = 0; i < names.Length; i++)
            //    {
            //        Console.WriteLine(names[i]);
            //    }

           // Console.WriteLine(Convert.ToInt32(facade.GetSales().Rows[0].ItemArray[4]));
            Console.ReadLine();
        }
    }
}
