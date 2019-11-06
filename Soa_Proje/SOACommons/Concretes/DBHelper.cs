using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;

namespace SOACommons.Concretes
{
    public static class DBHelper
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public static string GetConnectionProvider()
        {
            return ConfigurationManager.ConnectionStrings["Default"].ProviderName;
        }

        public static void AddParameter(DbCommand command, string paramName, object value)
        {
            if (command == null)
                throw new ArgumentNullException("command", "The AddParameter's Command value is null.");

            try
            {
                DbParameter parameter = command.CreateParameter();
                parameter.ParameterName = paramName;
                parameter.Value = value ?? DBNull.Value;
                command.Parameters.Add(parameter);
            }
            catch (Exception ex)
            {

                throw new Exception("DBHelper::AddParameter::Error occured.", ex);
            }
        }
    }
}
