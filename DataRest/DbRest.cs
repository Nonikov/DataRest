using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRest
{
    public static class DbRest
    {
        static SqlConnection connection;
        public static SqlCommand command;

        static DbRest() 
        {
            connection = new SqlConnection(new SqlConnectionStringBuilder
            {
                DataSource = " 172.20.10.4",
                //InitialCatalog = "DbRest",
                UserID = "sa",
                Password = "24513637",
                IntegratedSecurity = false
            }.ConnectionString);
            connection.Open();

            command = connection.CreateCommand();

            CreateDbRest();

            CreateTbProducts();
            CreateTbRecipes();
            CreateTbDishes();
            CreateTbProdConsumptions();
            CreateTbSALES();
            CreateTbPurchases();
        }

        private static void CreateDbRest()   
        {
            command.CommandText = "if db_id(N'DbRest') IS NULL Create database DbRest; USE DbRest";
            command.ExecuteNonQuery();
        }

        private static void CreateTbProducts()
        {
            string sql = "if object_id(N'dbo.DbRest',N'U') IS NULL CREATE TABLE Products (" +
                "Id smallint IDENTITY NOT NULL PRIMARY KEY, Name Varchar(20) NOT NULL, ProdType Varchar(20) NOT NULL)";
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        private static void CreateTbRecipes()
        {
            string sql = "if object_id(N'dbo.DbRest',N'U') IS NULL CREATE TABLE Recipes(Id smallint IDENTITY NOT NULL PRIMARY KEY, RecipeName varchar(20)  NOT NULL UNIQUE, RecipeText varchar(max) NOT NULL)";
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        private static void CreateTbDishes()
        {
           string sql = "if object_id(N'dbo.DbRest',N'U') IS NULL CREATE TABLE  Dishes (Id smallint IDENTITY NOT NULL PRIMARY KEY, DishName varchar(20) NOT NULL, RecipeId smallint FOREIGN KEY REFERENCES Recipes(Id), Portion int NOT NULL, TypeMeasure varchar(10) NOT NULL)";
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        private static void CreateTbProdConsumptions()
        {
            string sql = "if object_id(N'dbo.DbRest',N'U') IS NULL CREATE TABLE ProdConsumptions (Id smallint IDENTITY NOT NULL PRIMARY KEY, ProdId smallint NOT NULL FOREIGN KEY REFERENCES Products(Id), DisheId smallint NOT NULL FOREIGN KEY REFERENCES Dishes(Id), Quantity int NOT NULL, TypeMeasure varchar(10) NOT NULL)";
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        private static void CreateTbSALES()
        {
           string sql = "if object_id(N'dbo.DbRest',N'U') IS NULL CREATE TABLE  SALES (Id smallint IDENTITY NOT NULL PRIMARY KEY, DisheId smallint FOREIGN KEY REFERENCES Dishes(Id), Price money NOT NULL, DateSale SmallDateTime NOT NULL)";
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        private static void CreateTbPurchases()
        {
            string sql = "if object_id(N'dbo.DbRest',N'U') IS NULL CREATE TABLE Purchases(Id smallint IDENTITY NOT NULL PRIMARY KEY, ProdId smallint NOT NULL FOREIGN KEY REFERENCES Products(Id), DatePurchase SmallDateTime NOT NULL, Price money NOT NULL,Quantity int NOT NULL, TypeMeasure varchar(10) NOT NULL)";
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }


        public static void AddProduct(string name, string prodType)
        {
            command.CommandText = "INSERT INTO Products (Name, ProdType) values ('" + name + "', '" + prodType + "')";
            command.ExecuteNonQuery();
        }
    }
}
