using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRest;

namespace DalRest
{
    public class Dal
    {
        public static void AddProduct(string name, string typeProduct)
        {
            DbRest.AddProduct(name, typeProduct);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dal.AddProduct("apple", "fruit");
        }
    }
}
