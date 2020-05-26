using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sqlConnection = new SqlConnection("ROOT_SQL:1234");
            var oracleConnection = new OracleConnection("ROOT_ORACLE:5678");
            var allProducts = new DbCommand(sqlConnection,"SELECT * FROM Products");
            var allCostumers = new DbCommand(oracleConnection,"SELECT * FROM Costumers");
            System.Console.WriteLine("============");
            allProducts.Execute();
            System.Console.WriteLine("============");
            allCostumers.Execute();
            System.Console.WriteLine("============");
        }
    }
}
