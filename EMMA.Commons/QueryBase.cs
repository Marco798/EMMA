using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace EMMA.Commons
{
    public class QueryBase
    {

        private readonly IConfiguration _configuration;
        protected readonly string connectionString;

        public QueryBase(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("locale") ?? throw new Exception($"Stringa di connessione [locale] non trovata");
        }

        public List<T> CustomSelect<T>(string query) where T : ICustomSelect_Record, new()
        {
            using SqlConnection connection = new(connectionString);

            List<T> output = [];
            try
            {
                connection.Open();

                using (SqlCommand command = new(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    T customSelect_Record = new();
                    while (reader.Read())
                    {
                        T record = (T)customSelect_Record.GetRecord(reader);
                        output.Add(record);
                    }
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                throw new Exception(ex.Message);
            }

            return output;
        }

        public void UpdateSingleField(StringBuilder query, List<SqlParameter> parameters)
        {
            using SqlConnection connection = new(connectionString);

            try
            {
                SqlCommand command = new(query.ToString(), connection);
                command.Parameters.AddRange([.. parameters]);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                throw new Exception(ex.Message);
            }

        }
    }
}
