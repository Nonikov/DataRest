using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DalRest;

namespace DalRest.Test
{
    [TestClass]
    public class UnitTest1
    {
        Facade facade;

        // THE DATABASE MUST BE EMPTY (if not empty, drop it in the application)

        [TestInitialize]
        public void InitializeCurrentTest()
        {
            facade = new Facade();
        }

        [TestMethod]
        [Priority(0)]
        public void Test_Add_Get_ProductTypes()
        {
            string item = "vegetable";
            string expected = "vegetable";

            facade.AddProductTypes(item);
            string actual = (facade.GetProductTypes().Rows[0].ItemArray[0].ToString());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Priority(1)]
        public void Test_Add_Get_Measures()
        {
            string item = "kg";
            string expected = "kg";

            facade.AddMeasureType(item);

            string actual = (facade.GetMeasureType().Rows[0].ItemArray[0].ToString());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Priority(2)]
        public void Test_Add_Get_Products()
        {
            string item1 = "potato";
            string item2 = "vegetable";
            string item3 = "kg";
            string expected1 = "potato";
            string expected2 = "vegetable";
            string expected3 = "kg";

            facade.AddProduct(item1, item2, item3);
            string actual1 = (facade.GetProducts().Rows[0].ItemArray[0].ToString());
            string actual2 = (facade.GetProducts().Rows[0].ItemArray[1].ToString());
            string actual3 = (facade.GetProducts().Rows[0].ItemArray[2].ToString());

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
        }

        [TestMethod]
        [Priority(3)]
        public void Test_Add_Get_Purchases()
        {
            string item1 = "potato";
            int item2 = 15;
            int item3 = 200;
            string expected1 = "potato";
            double expected2 = 15;
            int expected3 = 200;

            facade.AddPurchase(item1, item2, item3);
            string actual1 = (facade.GetPurchases().Rows[0].ItemArray[1].ToString());
            double actual2 = (Convert.ToDouble(facade.GetPurchases().Rows[0].ItemArray[2]));
            int actual3 = (Convert.ToInt32(facade.GetPurchases().Rows[0].ItemArray[3]));

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
        }

        [TestMethod]
        [Priority(4)]
        public void Test_Add_Get_Dishes()
        {
            string item1 = "borsh";
            string item2 = "portion";
            string expected1 = "borsh";
            string expected2 = "portion";

            facade.AddMeasureType("portion");
            facade.AddDishe(item1, item2);
            string actual1 = (facade.GetDishes().Rows[0].ItemArray[1].ToString());
            string actual2 = (facade.GetDishes().Rows[0].ItemArray[3].ToString());

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }

        [TestMethod]
        [Priority(5)]
        public void Test_Add_Get_Consumptions()
        {
            string item1 = "borsh";
            string item2 = "potato";
            int item3 = 1;
            string expected1 = "borsh";
            string expected2 = "potato";
            int expected3 = 1;

            facade.AddConsumption(item1, item2, item3);
            string actual1 = (facade.GetConsumptiones().Rows[0].ItemArray[1].ToString());
            string actual2 = (facade.GetConsumptiones().Rows[0].ItemArray[2].ToString());
            int actual3 = (Convert.ToInt32(facade.GetConsumptiones().Rows[0].ItemArray[3]));

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
        }

        [TestMethod]
        [Priority(6)]
        public void Test_Add_Get_Sales()
        {
            string item1 = "borsh";
            int item2 = 25;
            int item3 = 1;
            string expected1 = "borsh";
            int expected2 = 25;
            int expected3 = 1;

            facade.AddSale(item1, item2, item3);
            string actual1 = (facade.GetSales().Rows[0].ItemArray[1].ToString());
            int actual2 = (Convert.ToInt32(facade.GetSales().Rows[0].ItemArray[2]));
            int actual3 = (Convert.ToInt32(facade.GetSales().Rows[0].ItemArray[3]));

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
        }


        [TestMethod]
        [Priority(7)]
        public void Test_Add_Get_Recipes()
        {
            string item1 = "borsh";
            string item2 = "textOfRecipe";
            string expected1 = "borsh";
            string expected2 = "textOfRecipe";

            facade.AddRecipe(item1, item2);
            string actual1 = (facade.GetRecipes().Rows[0].ItemArray[1].ToString());
            string actual2 = (facade.GetRecipes().Rows[0].ItemArray[2].ToString());

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }
    }
}
