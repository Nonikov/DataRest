using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRest;

namespace DalRest
{
    public class Facade
    {
        private DbRest dbRest = new DbRest();
        SqlCommand command = DbRest.command;

        public void DropAllTables()
        {
            dbRest.DropAllTables();
        }

        // ProductTypes
        public void AddProductTypes(string type)
        {
            command.CommandText = "EXEC sp_AddProductTypes '" + type + "'";
            command.ExecuteNonQuery();
        }

        public DataTable GetProductTypes() 
        {
            command.CommandText = "sp_GetProductTypes";
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable;
        }

        // Measures
        public void AddMeasureType(string type)
        {
            command.CommandText = "EXEC sp_AddMeasureTypes '" + type + "'";
            command.ExecuteNonQuery();
        }

        public DataTable GetMeasureType()   
        {
            command.CommandText = "sp_GetMeasuresTypes";
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable;
        }

        // Products
        public void AddProduct(string name, string productTypes, string measure)
        {
            command.CommandText = "EXEC sp_AddProduct '" + name + "', '" + productTypes + "', '" + measure + "'";
            command.ExecuteNonQuery();
        }

        public DataTable GetProducts()    
        {
            command.CommandText = "sp_GetProducts";
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable;
        }

        // Purchases
        public void AddPurchase(string name, int price, int quantity)
        {
            command.CommandText = "EXEC sp_AddPurchase'" + name + "', '" + price + "', '" + quantity + "'";
            command.ExecuteNonQuery();
        }

        public DataTable GetPurchases()
        {
            command.CommandText = "sp_GetPurchases";
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable;
        }

        // Dishes
        public void AddDishe(string name, string measureType)       
        {
            command.CommandText = "EXEC sp_AddDish'" + name + "', '" + measureType + "'";
            command.ExecuteNonQuery();
        }

        public DataTable GetDishes()    
        {
            command.CommandText = "sp_GetDishes";
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable;
        }

        // ProdConsumptions
        public void AddConsumption(string disheName, string prodName, int quantity)
        {
            command.CommandText = "EXEC sp_AddConsumption'" + disheName + "', '" + prodName + "', '" + quantity + "'";
            command.ExecuteNonQuery();
        }

        public DataTable GetConsumptiones()
        {
            command.CommandText = "sp_GetConsumptions";
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable;
        }

        // Sales
        public void AddSale(string dishName, int price, int quantity)   
        {
            command.CommandText = "EXEC sp_AddSale'" + dishName + "', '" + price + "', '" + quantity + "'";
            command.ExecuteNonQuery();
        }

        public DataTable GetSales()
        {
            command.CommandText = "sp_GetSales";
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable;
        }

        // Recipes
        public void AddRecipe(string recipeName, string recipeText)
        {
            command.CommandText = "EXEC sp_AddRecipe'" + recipeName + "', '" + recipeText + "'";
            command.ExecuteNonQuery();
        }

        public DataTable GetRecipes()
        {
            command.CommandText = "sp_GetRecipes";
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable;
        }


    }
}
