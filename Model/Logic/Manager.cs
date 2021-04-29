using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Model.Entity;

namespace Model.Logic
{
    public class Manager : SqlAbstractDAO
    {
        private const string SELECT_ALL_PRODUCTS = "SELECT * FROM Products";
        private const string SELECT_PRODUCT_NAMES = "SELECT name FROM Products GROUP BY name";
        private const string SELECT_PRODUCT_COLORS = "SELECT color FROM Products GROUP BY color";
        private const string SELECT_MIN_CALORIES = "SELECT MIN(calories) FROM Products";
        private const string SELECT_MAX_CALORIES  = "SELECT MAX(calories) FROM Products";
        private const string SELECT_AVG_CALORIES  = "SELECT AVG(calories) FROM Products";
        private const string SELECT_COUNT_VEGETABLE = "SELECT COUNT (id) FROM Products WHERE type = 'vegetable'";
        private const string SELECT_COUNT_FRUIT = "SELECT COUNT (id) FROM Products WHERE type = 'fruit'";
        private const string SELECT_COUNT_PRODUCTS_OF_COLOR = "SELECT COUNT (id) FROM Products WHERE color = @color";
        private const string SELECT_PRODUCTS_WITH_CALORIES_BELOW_INDICATE = "SELECT * FROM Products WHERE calories < @calories";
        private const string SELECT_PRODUCTS_WITH_CALORIES_HIGHER_INDICATE = "SELECT * FROM Products WHERE calories > @calories";
        private const string SELECT_PRODUCTS_WITH_CALORIES_RANGE = "SELECT * FROM Products WHERE calories >= @min AND calories <= @max";
        private const string SELECT_PRODUCTS_WITH_YELLOW_OR_RED_COLOR = "SELECT * FROM Products WHERE color IN ('yellow', 'red')";
        private const string SELECT_COUNT_PRODUCTS_WITH_COLOR = "SELECT color, COUNT(*) FROM Products GROUP BY color";
        private const string LIST_IS_EMPTY = "Sorry, no products with these parameters...\n";
        
        public IList<Product> GetAllProducts()
        {
            SqlConnection connection = (SqlConnection) GetConnection();
            SqlCommand command = new SqlCommand(SELECT_ALL_PRODUCTS, connection);
            SqlDataReader reader = command.ExecuteReader();
            IList<Product> products = new List<Product>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product product = new Product();
                    product.Name = reader.GetString(1);
                    product.Type = reader.GetString(2);
                    product.Color = reader.GetString(3);
                    product.Calorific = reader.GetInt32(4);
                    products.Add(product);
                }
            }
            
            ReleaseConnection(connection);
            return products;
        }

        public IList<string> GetAllProductNames()
        {
            SqlConnection connection = (SqlConnection) GetConnection();
            SqlCommand command = new SqlCommand(SELECT_PRODUCT_NAMES, connection);
            SqlDataReader reader = command.ExecuteReader();
            IList<string> productNames = new List<string>();
            
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string productName = reader.GetString(0);
                    productNames.Add(productName);
                }
            }
            
            ReleaseConnection(connection);
            return productNames;
        }
        
        public IList<string> GetAllProductColors()
        {
            SqlConnection connection = (SqlConnection) GetConnection();
            SqlCommand command = new SqlCommand(SELECT_PRODUCT_COLORS, connection);
            SqlDataReader reader = command.ExecuteReader();
            IList<string> productColors = new List<string>();
            
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string productColor = reader.GetString(0);
                    productColors.Add(productColor);
                }
            }
            
            ReleaseConnection(connection);
            return productColors;
        }
        
        public int GetMinCalories()
        {
            SqlConnection connection = (SqlConnection) GetConnection();
            SqlCommand command = new SqlCommand(SELECT_MIN_CALORIES, connection);
            int answer = (int)command.ExecuteScalar();
            ReleaseConnection(connection);
            return answer;
        }
        
        public int GetMaxCalories()
        {
            SqlConnection connection = (SqlConnection) GetConnection();
            SqlCommand command = new SqlCommand(SELECT_MAX_CALORIES, connection);
            int answer = (int)command.ExecuteScalar();
            ReleaseConnection(connection);
            return answer;
        }
        
        public int GetAVGCalories()
        {
            SqlConnection connection = (SqlConnection) GetConnection();
            SqlCommand command = new SqlCommand(SELECT_AVG_CALORIES, connection);
            int answer = (int)command.ExecuteScalar();
            ReleaseConnection(connection);
            return answer;
        }
        
        public int GetCountVegetable()
        {
            SqlConnection connection = (SqlConnection) GetConnection();
            SqlCommand command = new SqlCommand(SELECT_COUNT_VEGETABLE, connection);
            int answer = (int)command.ExecuteScalar();
            ReleaseConnection(connection);
            return answer;
        }
        
        public int GetCountFruit()
        {
            SqlConnection connection = (SqlConnection) GetConnection();
            SqlCommand command = new SqlCommand(SELECT_COUNT_FRUIT, connection);
            int answer = (int)command.ExecuteScalar();
            ReleaseConnection(connection);
            return answer;
        }
        
        public int GetCountProductsOfColor()
        {
            Console.Write("Enter color: ");
            string color = Console.ReadLine();
            Console.WriteLine();
            SqlConnection connection = (SqlConnection) GetConnection();
            SqlCommand command = new SqlCommand(SELECT_COUNT_PRODUCTS_OF_COLOR, connection);
            SqlParameter colorParam = new SqlParameter
            {
                ParameterName = "@color",
                Value = color,
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input
            };
            command.Parameters.Add(colorParam);
            
            int answer = (int)command.ExecuteScalar();
            ReleaseConnection(connection);
            return answer;
        }
        
        public IList<Product> GetProductsWithCaloriesBelowIndicate()
        {
            Console.Write("Enter calories: ");
            int calories = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            SqlConnection connection = (SqlConnection) GetConnection();
            SqlCommand command = new SqlCommand(SELECT_PRODUCTS_WITH_CALORIES_BELOW_INDICATE, connection);
            SqlParameter caloriesParam = new SqlParameter
            {
                ParameterName = "@calories",
                Value = calories,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };
            command.Parameters.Add(caloriesParam);
            SqlDataReader reader = command.ExecuteReader();
            
            IList<Product> products = new List<Product>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product product = new Product();
                    product.Name = reader.GetString(1);
                    product.Type = reader.GetString(2);
                    product.Color = reader.GetString(3);
                    product.Calorific = reader.GetInt32(4);
                    products.Add(product);
                }
            }
            
            ReleaseConnection(connection);
            return products;
        }
        
        public IList<Product> GetProductsWithCaloriesHigherIndicate()
        {
            Console.Write("Enter calories: ");
            int calories = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            SqlConnection connection = (SqlConnection) GetConnection();
            SqlCommand command = new SqlCommand(SELECT_PRODUCTS_WITH_CALORIES_HIGHER_INDICATE, connection);
            SqlParameter caloriesParam = new SqlParameter
            {
                ParameterName = "@calories",
                Value = calories,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };
            command.Parameters.Add(caloriesParam);
            SqlDataReader reader = command.ExecuteReader();
            
            IList<Product> products = new List<Product>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product product = new Product();
                    product.Name = reader.GetString(1);
                    product.Type = reader.GetString(2);
                    product.Color = reader.GetString(3);
                    product.Calorific = reader.GetInt32(4);
                    products.Add(product);
                }
            }
            
            ReleaseConnection(connection);
            return products;
        }
        
        public IList<Product> GetProductsWithCaloriesRange()
        {
            Console.Write("Enter min calories: ");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter max calories: ");
            int max = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            SqlConnection connection = (SqlConnection) GetConnection();
            SqlCommand command = new SqlCommand(SELECT_PRODUCTS_WITH_CALORIES_RANGE, connection);
            SqlParameter minParam = new SqlParameter
            {
                ParameterName = "@min",
                Value = min,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };
            command.Parameters.Add(minParam);
            
            SqlParameter maxParam = new SqlParameter
            {
                ParameterName = "@max",
                Value = max,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };
            command.Parameters.Add(maxParam);
            
            SqlDataReader reader = command.ExecuteReader();
            IList<Product> products = new List<Product>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product product = new Product();
                    product.Name = reader.GetString(1);
                    product.Type = reader.GetString(2);
                    product.Color = reader.GetString(3);
                    product.Calorific = reader.GetInt32(4);
                    products.Add(product);
                }
            }
            
            ReleaseConnection(connection);
            return products;
        }
        
        public IList<Product> GetProductsWithYellowOrRedColor()
        {
            SqlConnection connection = (SqlConnection) GetConnection();
            SqlCommand command = new SqlCommand(SELECT_PRODUCTS_WITH_YELLOW_OR_RED_COLOR, connection);
            SqlDataReader reader = command.ExecuteReader();
            IList<Product> products = new List<Product>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product product = new Product();
                    product.Name = reader.GetString(1);
                    product.Type = reader.GetString(2);
                    product.Color = reader.GetString(3);
                    product.Calorific = reader.GetInt32(4);
                    products.Add(product);
                }
            }
            
            ReleaseConnection(connection);
            return products;
        }
        
        public void PrintCountProductsWithColor()
        {
            SqlConnection connection = (SqlConnection) GetConnection();
            SqlCommand command = new SqlCommand(SELECT_COUNT_PRODUCTS_WITH_COLOR, connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                Console.WriteLine("Products (color - count):");
                
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0) + " - " + reader.GetInt32(1));
                }
            }
            else
            {
                Console.WriteLine(LIST_IS_EMPTY);
            }
            
            ReleaseConnection(connection);
        }
    }
}