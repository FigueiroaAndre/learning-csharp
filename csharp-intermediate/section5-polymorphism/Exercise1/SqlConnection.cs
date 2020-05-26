using System;

namespace Exercise1
{
    public class SqlConnection : DbConnection
    {
        public SqlConnection(string connectionString)
            : base(connectionString)
        {
        }

        public override void Open()
        {
            System.Console.WriteLine("Open the SQL connection using '{0}'.",this.ConnectionString);
        }

        public override void Close()
        {
            System.Console.WriteLine("Close the SQL connection.");
        }
    }
}