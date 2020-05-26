using System;

namespace Exercise1
{
    public class DbCommand
    {
        private DbConnection _dbConnection;
        private string _instruction;

        public DbCommand(DbConnection dbConnection,string instruction)
        {
            if (dbConnection == null)
            {
                throw new ArgumentNullException("dbConnection must not be null.");
            }
            if (instruction == null || instruction == "")
            {
                throw new ArgumentNullException("instruction must not be null or empty.");
            }
            this._dbConnection = dbConnection;
            this._instruction = instruction;
        }

        public void Execute()
        {
            _dbConnection.Open();
            System.Console.WriteLine("Run: {0}",_instruction);
            _dbConnection.Close();
        }
    }
}