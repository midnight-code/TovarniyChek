using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;

namespace TovarniyChek.Classes.DataClass
{
    public abstract class DataSql
    {
        private string _connectionString = "";
        protected string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }
        protected int ExecuteNonQuery(DbCommand cmd)
        {
            return cmd.ExecuteNonQuery();
        }

        protected IDataReader ExecuteReader(DbCommand cmd)
        {
            return ExecuteReader(cmd, CommandBehavior.Default);
        }

        protected IDataReader ExecuteReader(DbCommand cmd, CommandBehavior behavior)
        {
            return cmd.ExecuteReader(behavior);
        }

        protected object ExecuteScalar(DbCommand cmd)
        {
            return cmd.ExecuteScalar();
        }
        protected static string ConvertNullToEmptyString(string input)
        {
            return (input == null ? "" : input);
        }
    }
}
