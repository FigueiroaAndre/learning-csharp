using System;

namespace Exercise1
{
    public class OracleConnection : DbConnection
    {
        public OracleConnection(string connectionString)
            : base(connectionString)
        {
        }

        public override void Open()
        {
            System.Console.WriteLine("Open the Oracle connection using '{0}'.",this.ConnectionString);
        }

        public override void Close()
        {
            System.Console.WriteLine("Close the Oracle connection.");
        }
    }
}