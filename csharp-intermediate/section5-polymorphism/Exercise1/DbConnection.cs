using System;

namespace Exercise1
{
    public abstract class DbConnection
    {
        public string ConnectionString { get; private set; }
        public TimeSpan Timeout;

        public DbConnection (string connectionString)
        {
            if(connectionString == null || connectionString == "")
            {
                throw new ArgumentNullException("connectionString may not be null or empty");
            }
            this.ConnectionString = connectionString;
            this.Timeout = TimeSpan.FromSeconds(10);
        }

        public abstract void Open();
        public abstract void Close();
    }
}
