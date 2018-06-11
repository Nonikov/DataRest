using System;
using System.Data.SqlClient;


namespace DataRest
{
    public class DbRest
    {
        private static SqlConnection connection;
        public static SqlCommand command;

        public DbRest()
        {
            connection = new SqlConnection(new SqlConnectionStringBuilder
            {
                DataSource = " 192.168.1.104",
                UserID = "sa",
                Password = "24513637",
                IntegratedSecurity = false
            }.ConnectionString);
            connection.Open();

            command = connection.CreateCommand();

            CreateDbRest();

            CreateTbMeasures();
            CreateTbProductTypes();
            CreateTbProducts();
            CreateTbDishes();
            CreateTbRecipes();
            CreateTbProdConsumptions();
            CreateTbSales();
            CreateTbPurchases();
            AddStoredProcedures();

            AppDomain.CurrentDomain.ProcessExit += (object sender, EventArgs e) => connection.Close();
        }

        #region DeployingDb

        private void CreateDbRest()
        {
            command.CommandText = "if db_id(N'DbRest') IS NULL Create database DbRest; USE DbRest";
            command.ExecuteNonQuery();
        }

        private void CreateTbProducts()
        {
            string sql = "if object_id(N'dbo.Products',N'U') IS NULL CREATE TABLE Products" +
                "(Id smallint IDENTITY NOT NULL PRIMARY KEY," +
                " Name Varchar(20) NOT NULL UNIQUE, ProdType Varchar(20) NOT NULL FOREIGN KEY REFERENCES ProductTypes(ProdType), " +
                "MeasureType varchar(10) NOT NULL FOREIGN KEY REFERENCES Measures(MeasureType))";
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        private void CreateTbProductTypes()
        {
            string sql = "if object_id(N'dbo.ProductTypes',N'U') IS NULL CREATE TABLE ProductTypes" +
                "(ProdType varchar(20) NOT NULL PRIMARY KEY)";
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        private void CreateTbRecipes()
        {
            string sql = "if object_id(N'Recipes',N'U') IS NULL CREATE TABLE Recipes" +
                "(Id smallint IDENTITY NOT NULL PRIMARY KEY, " +
                "RecipeName varchar(20)  NOT NULL UNIQUE FOREIGN KEY REFERENCES Dishes(Name) ," +
                " RecipeText varchar(max) NOT NULL)";
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        private void CreateTbMeasures()
        {
            string sql = "if object_id(N'dbo.Measures',N'U') IS NULL CREATE TABLE Measures" +
                "(MeasureType varchar(10) NOT NULL PRIMARY KEY)";
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        private void CreateTbDishes()
        {
            string sql = "if object_id(N'dbo.Dishes',N'U') IS NULL CREATE TABLE  Dishes " +
                 "(Id smallint IDENTITY NOT NULL PRIMARY KEY," +
                 "Name varchar(20) NOT NULL UNIQUE, " +
                 "RecipeId smallint, " +
                 "MeasureType varchar(10) NOT NULL FOREIGN KEY REFERENCES Measures(MeasureType))";
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        private void CreateTbProdConsumptions()
        {
            string sql = "if object_id(N'dbo.ProdConsumptions',N'U') IS NULL CREATE TABLE ProdConsumptions" +
                " (Id smallint IDENTITY NOT NULL PRIMARY KEY," +
                " DisheName varchar(20) NOT NULL FOREIGN KEY REFERENCES Dishes(Name), " +
                "ProdName Varchar(20) NOT NULL UNIQUE FOREIGN KEY REFERENCES Products(Name),  " +
                "Quantity float NOT NULL)";
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        private void CreateTbSales()
        {
            string sql = "if object_id(N'dbo.SALES',N'U') IS NULL CREATE TABLE  Sales" +
                 " (Id smallint IDENTITY NOT NULL PRIMARY KEY, " +
                 "DishName varchar(20) FOREIGN KEY REFERENCES Dishes(Name), " +
                 "Price money NOT NULL, Quantity int NOT NULL, " +
                 "DateSales SmallDateTime DEFAULT CURRENT_TIMESTAMP)";
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        private void CreateTbPurchases()
        {
            string sql = "if object_id(N'dbo.Purchases',N'U') IS NULL CREATE TABLE Purchases " +
                "(Id smallint IDENTITY NOT NULL PRIMARY KEY," +
                " ProdName Varchar(20) NOT NULL FOREIGN KEY REFERENCES Products(Name), " +
                "DatePurchase SmallDateTime DEFAULT CURRENT_TIMESTAMP, " +
                "Price money NOT NULL," +
                " Quantity int NOT NULL)";
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        #endregion

        public void DropAllTables()
        {
            command.CommandText = "DROP TABLE Sales; DROP TABLE Purchases; DROP TABLE ProdConsumptions; DROP TABLE Products; " +
                " DROP TABLE Recipes; DROP TABLE Dishes; DROP TABLE ProductTypes; DROP TABLE Measures;";
            command.ExecuteNonQuery();
        }

        private void AddStoredProcedures()
        {
            // Stored Procedures of the table ProductTypes
            command.CommandText = "IF EXISTS (SELECT type_desc, type FROM sys.procedures WITH(NOLOCK) " +
                "WHERE NAME = 'sp_AddProductTypes' AND type = 'P') " +
                "DROP PROCEDURE dbo.sp_AddProductTypes";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE PROC sp_AddProductTypes @ProdType varchar(20) " +
                "AS BEGIN INSERT INTO ProductTypes(ProdType) values (@ProdType) END;";
            command.ExecuteNonQuery();

            command.CommandText = "IF EXISTS (SELECT type_desc, type FROM sys.procedures WITH(NOLOCK) " +
                "WHERE NAME = 'sp_GetProductTypes' AND type = 'P') " +
                "DROP PROCEDURE dbo.sp_GetProductTypes";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE PROC sp_GetProductTypes AS SELECT * FROM ProductTypes";
            command.ExecuteNonQuery();

            // Stored Procedures of the table MeasureTypes
            command.CommandText = "IF EXISTS (SELECT type_desc, type FROM sys.procedures WITH(NOLOCK) " +
                "WHERE NAME = 'sp_AddMeasureTypes' AND type = 'P') " +
                "DROP PROCEDURE dbo.sp_AddMeasureTypes";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE PROC sp_AddMeasureTypes @MeasureType varchar(10) " +
                "AS BEGIN INSERT INTO Measures (MeasureType) values (@MeasureType) END;";
            command.ExecuteNonQuery();

            command.CommandText = "IF EXISTS (SELECT type_desc, type FROM sys.procedures WITH(NOLOCK) " +
                "WHERE NAME = 'sp_GetMeasuresTypes' AND type = 'P') " +
                "DROP PROCEDURE dbo.sp_GetMeasuresTypes";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE PROC sp_GetMeasuresTypes AS SELECT * FROM Measures";
            command.ExecuteNonQuery();

            // Stored Procedures of the table Products
            command.CommandText = "IF EXISTS (SELECT type_desc, type FROM sys.procedures WITH(NOLOCK) " +
                "WHERE NAME = 'sp_AddProduct' AND type = 'P') " +
                "DROP PROCEDURE dbo.sp_AddProduct";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE PROC sp_AddProduct @Name varchar(20), @ProdType varchar(20), @MeasureType varchar(10) " +
                "AS BEGIN INSERT INTO Products (Name, ProdType, MeasureType) values (@Name, @ProdType, @MeasureType) END;";
            command.ExecuteNonQuery();

            command.CommandText = "IF EXISTS (SELECT type_desc, type FROM sys.procedures WITH(NOLOCK)" +
                " WHERE NAME = 'sp_GetProducts' AND type = 'P') " +
                "DROP PROCEDURE dbo.sp_GetProducts";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE PROC sp_GetProducts AS SELECT Name, ProdType, MeasureType FROM Products";
            command.ExecuteNonQuery();

            //Stored Procedures of the table Purchases
            command.CommandText = "IF EXISTS (SELECT type_desc, type FROM sys.procedures WITH(NOLOCK) " +
                "WHERE NAME = 'sp_AddPurchase' AND type = 'P') " +
                "DROP PROCEDURE dbo.sp_AddPurchase";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE PROC sp_AddPurchase @ProdName Varchar(20), @Price money, @Quantity int " +
                "AS BEGIN INSERT INTO Purchases (ProdName, Price, Quantity) values (@ProdName, @Price, @Quantity) END;";
            command.ExecuteNonQuery();

            command.CommandText = "IF EXISTS (SELECT type_desc, type FROM sys.procedures WITH(NOLOCK) " +
                "WHERE NAME = 'sp_GetPurchases' AND type = 'P') " +
                "DROP PROCEDURE dbo.sp_GetPurchases";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE PROC sp_GetPurchases " +
                "AS SELECT Purchases.Id, Purchases.ProdName, Purchases.Price, Purchases.Quantity, Products.MeasureType as Measure " +
                "FROM Purchases, Products WHERE Purchases.ProdName = Products.Name";
            command.ExecuteNonQuery();

            //Stored Procedures of the table Dishes
            command.CommandText = "IF EXISTS (SELECT type_desc, type FROM sys.procedures WITH(NOLOCK) " +
                "WHERE NAME = 'sp_AddDish' AND type = 'P') " +
                "DROP PROCEDURE dbo.sp_AddDish";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE PROC sp_AddDish @Name varchar(20), @MeasureType varchar(10) " +
                "AS BEGIN INSERT INTO Dishes (Name, MeasureType) values (@Name, @MeasureType) END;";
            command.ExecuteNonQuery();

            command.CommandText = "IF EXISTS (SELECT type_desc, type FROM sys.procedures WITH(NOLOCK) " +
                "WHERE NAME = 'sp_GetDishes' AND type = 'P') " +
                "DROP PROCEDURE dbo.sp_GetDishes";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE PROC sp_GetDishes AS SELECT * FROM Dishes";
            command.ExecuteNonQuery();

            //Stored Procedures of the table Consumptions
            command.CommandText = "IF EXISTS (SELECT type_desc, type FROM sys.procedures WITH(NOLOCK) " +
                "WHERE NAME = 'sp_AddConsumption' AND type = 'P') " +
                "DROP PROCEDURE dbo.sp_AddConsumption";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE PROC sp_AddConsumption @DisheName varchar(20), @ProdName Varchar(20), @Quantity float " +
                "AS BEGIN INSERT INTO ProdConsumptions(DisheName, ProdName, Quantity) values (@DisheName, @ProdName, @Quantity) END;";
            command.ExecuteNonQuery();

            command.CommandText = "IF EXISTS (SELECT type_desc, type FROM sys.procedures WITH(NOLOCK) " +
                "WHERE NAME = 'sp_GetConsumptions' AND type = 'P') " +
                "DROP PROCEDURE dbo.sp_GetConsumptions";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE PROC sp_GetConsumptions AS" +
                " SELECT ProdConsumptions.Id, ProdConsumptions.DisheName, ProdConsumptions.ProdName, ProdConsumptions.Quantity, Products.MeasureType as Measure " +
                "FROM ProdConsumptions, Products " +
                "WHERE ProdConsumptions.ProdName = Products.Name  ";
            command.ExecuteNonQuery();

            //Stored Procedures of the table Sales
            command.CommandText = "IF EXISTS (SELECT type_desc, type FROM sys.procedures WITH(NOLOCK) " +
                "WHERE NAME = 'sp_AddSale' AND type = 'P') " +
                "DROP PROCEDURE dbo.sp_AddSale";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE PROC sp_AddSale @DishName varchar(20), @Price money, @Quantity int " +
                "AS BEGIN INSERT INTO Sales(DishName, Price, Quantity) values (@DishName, @Price, @Quantity) END;";
            command.ExecuteNonQuery();

            command.CommandText = "IF EXISTS (SELECT type_desc, type FROM sys.procedures WITH(NOLOCK) " +
                "WHERE NAME = 'sp_GetSales' AND type = 'P') DROP PROCEDURE dbo.sp_GetSales";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE PROC sp_GetSales AS SELECT * FROM Sales";
            command.ExecuteNonQuery();

            //Stored Procedures of the table Recipes
            command.CommandText = "IF EXISTS (SELECT type_desc, type FROM sys.procedures WITH(NOLOCK) " +
                "WHERE NAME = 'sp_AddRecipe' AND type = 'P') " +
                "DROP PROCEDURE dbo.sp_AddRecipe";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE PROC sp_AddRecipe @RecipeName varchar(20), @RecipeText varchar(max) " +
                "AS BEGIN INSERT INTO Recipes(RecipeName, RecipeText) values (@RecipeName, @RecipeText); " +
                "UPDATE Dishes SET Dishes.RecipeId = Recipes.Id FROM Dishes INNER JOIN Recipes ON Dishes.id = Recipes.id " +
                "WHERE Dishes.Name = Recipes.RecipeName; END;";
            command.ExecuteNonQuery();

            command.CommandText = "IF EXISTS (SELECT type_desc, type FROM sys.procedures WITH(NOLOCK) " +
                "WHERE NAME = 'sp_GetRecipes' AND type = 'P') " +
                "DROP PROCEDURE dbo.sp_GetRecipes";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE PROC sp_GetRecipes AS SELECT * FROM Recipes";
            command.ExecuteNonQuery();
        }

    }
}
