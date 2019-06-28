using System;

namespace DapperTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string sqlOrderDetails = "SELECT TOP 5 * FROM OrderDetails;";
            string sqlOrderDetail = "SELECT * FROM OrderDetails WHERE OrderDetailID = @OrderDetailID;";
            string sqlCustomerInsert = "INSERT INTO Customers (CustomerName) Values (@CustomerName);";

            using (var connection = new SqlConnection(FiddleHelper.GetConnectionStringSqlServerW3Schools()))
            {
                var orderDetails = connection.Query<OrderDetail>(sqlOrderDetails).ToList();
                var orderDetail = connection.QueryFirstOrDefault<OrderDetail>(sqlOrderDetail, new { OrderDetailID = 1 });
                var affectedRows = connection.Execute(sqlCustomerInsert, new { CustomerName = "Mark" });

                Console.WriteLine(orderDetails.Count);
                Console.WriteLine(affectedRows);

                FiddleHelper.WriteTable(orderDetails);
                FiddleHelper.WriteTable(new List<OrderDetail>() { orderDetail });
            }
        }
    }
}
