using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SQL_ADO_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("7.1");
            OutputResultToConsole(GetProductCategotyAndSumOfSold());
            Console.WriteLine("7.2");
            OutputResultToConsole(GetCustomersWithDiscountBiggerThan40());
            Console.WriteLine("7.3");
            OutputResultToConsole(GetCustomersThatBuyProductsOnSumBiggerThan15000());
            Console.WriteLine("6.6");
            OutputResultToConsole(GetMinAndMaxProductWeight());
            Console.WriteLine("6.5");
            OutputResultToConsole(GetAverageProductWeight());
            Console.WriteLine("6.3");
            OutputResultToConsole(GetCountOfProductsWithoutWeight());
            Console.Read();
        }

        private static void OutputResultToConsole(List<string> result) 
        {
            foreach (var resString in result)
            {
                Console.WriteLine(resString);
            }
        }

        private static List<string> GetProductCategotyAndSumOfSold()
        {
            string sqlExpression = "select pc.ProductCategoryID ,pc.Name ,SUM(sod.UnitPrice) 'Total price of sold' from SalesLT.Product prod JOIN SalesLT.ProductCategory pc ON pc.ProductCategoryID = prod.ProductCategoryID JOIN SalesLT.SalesOrderDetail sod ON sod.ProductID = prod.ProductID Group by pc.ProductCategoryID,pc.Name";
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorksLT2019;Integrated Security=True";
            var result = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sqlExpression;
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            return result;
                        }

                        while (reader.Read())
                        {
                            var prodCatId = (int)reader.GetValue(0);
                            var prodCatName = (string)reader.GetValue(1);
                            var soldSum = (Decimal)reader.GetValue(2);

                            result.Add($"{prodCatId} :: {prodCatName} :: {soldSum}");
                        }
                    }
                }
            }
            return result;
        }

        static List<string> GetCustomersWithDiscountBiggerThan40()
        {
            string sqlExpression = "Select CustomerID,Title,FirstName,MiddleName,LastName  from SalesLT.Customer cust1 Where cust1.CustomerID IN(select cust.CustomerID from SalesLT.SalesOrderHeader soh JOIN SalesLT.Customer cust ON cust.CustomerID = soh.CustomerID JOIN SalesLT.SalesOrderDetail sod ON sod.SalesOrderID = soh.SalesOrderID group by cust.CustomerID having MAX(sod.UnitPriceDiscount) *100 >= @discount)";
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorksLT2019;Integrated Security=True";
            int discount = 40;
            var result = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sqlExpression;
                    command.Parameters.AddWithValue("@discount", discount);
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            return result;
                        }

                        while (reader.Read())
                        {
                            var custId = (int)reader.GetValue(0);
                            var custTitle = (string)reader.GetValue(1);
                            var custFirstName = (string)reader.GetValue(2);
                            var custMiddleName = reader.GetValue(3);
                            var custLastName = (string)reader.GetValue(4);

                            var custMiddleNameNullChecked = custMiddleName is DBNull ? "" : (string)custMiddleName;

                            result.Add($"{custId} :: {custTitle} :: {custFirstName} :: {custMiddleNameNullChecked} :: {custLastName}");
                        }
                    }
                }
            }
            return result;
        }

        static List<string> GetCustomersThatBuyProductsOnSumBiggerThan15000()
        {
            string sqlExpression = "Select cust1.CustomerID,cust1.Title,cust1.FirstName,cust1.MiddleName,cust1.LastName from SalesLT.Customer cust1 Where cust1.CustomerID IN( select cust.CustomerID from SalesLT.SalesOrderHeader soh JOIN SalesLT.Customer cust ON cust.CustomerID = soh.CustomerID JOIN SalesLT.SalesOrderDetail sod ON sod.SalesOrderID = soh.SalesOrderID group by cust.CustomerID having SUM(sod.UnitPrice)>@sum)";
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorksLT2019;Integrated Security=True";
            int sum = 15000;
            var result = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sqlExpression;
                    command.Parameters.AddWithValue("@sum", sum);
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            return result;
                        }

                        while (reader.Read())
                        {
                            var custId = (int)reader.GetValue(0);
                            var custTitle = (string)reader.GetValue(1);
                            var custFirstName = (string)reader.GetValue(2);
                            var custMiddleName = reader.GetValue(3);
                            var custLastName = (string)reader.GetValue(4);

                            var custMiddleNameNullChecked = custMiddleName is DBNull ? "" : (string)custMiddleName;

                            result.Add($"{custId} :: {custTitle} :: {custFirstName} :: {custMiddleNameNullChecked} :: {custLastName}");
                        }
                    }
                }
            }
            return result;
        }

        private static List<string> GetMinAndMaxProductWeight()
        {
            string sqlExpression = "select max(prod.Weight) 'Max' , min(prod.Weight) 'Min' from SalesLT.Product prod";
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorksLT2019;Integrated Security=True";
            var result = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sqlExpression;
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            return result;
                        }

                        while (reader.Read())
                        {
                            var max = (Decimal)reader.GetValue(0);
                            var min = (Decimal)reader.GetValue(1);

                            result.Add($"Min : {min} :: Max : {max}");
                        }
                    }
                }
            }
            return result;
        }

        private static List<string> GetAverageProductWeight()
        {
            string sqlExpression = "select avg(prod.Weight) from SalesLT.Product prod";
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorksLT2019;Integrated Security=True";
            var result = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sqlExpression;
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            return result;
                        }

                        while (reader.Read())
                        {
                            var avg = (Decimal)reader.GetValue(0);

                            result.Add($"Avg : {avg}");
                        }
                    }
                }
            }
            return result;
        }

        private static List<string> GetCountOfProductsWithoutWeight()
        {
            string sqlExpression = "select count(*) from SalesLT.Product prod where prod.Weight is null";
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorksLT2019;Integrated Security=True";
            var result = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sqlExpression;
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            return result;
                        }

                        while (reader.Read())
                        {
                            var count = (int)reader.GetValue(0);

                            result.Add($"Count of products : {count}");
                        }
                    }
                }
            }
            return result;
        }
    }
}
