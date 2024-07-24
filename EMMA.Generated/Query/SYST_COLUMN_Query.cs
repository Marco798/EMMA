using EMMA.Commons;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace EMMA_BE.Generated {
	public class SYST_COLUMN_Query(IConfiguration configuration) : QueryBase(configuration) {
		private const string NomeTabella = "SYST_Column";
		private const string NomeTabellaDB = "SYST_COLUMN";
	
		public List<SYST_COLUMN_Record> SelectAll() {
			using SqlConnection connection = new(connectionString);

			List<SYST_COLUMN_Record> output = [];
			try {
				connection.Open();

				string query = "SELECT * FROM SYST_COLUMN";
				using (SqlCommand command = new(query, connection)) {
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read()) {
						SYST_COLUMN_Record record = new();
						int i = 0;
						
						record.TABLE_NAME = reader.GetString(i++);
						record.COLUMN_NAME = reader.GetString(i++);
						record.DESCRIPTION = reader.GetString(i++);
						record.SHORT_DESCRIPTION = reader.GetString(i++);

						output.Add(record);
					}
				}

				connection.Close();
			} catch(Exception ex) {
				connection.Close();
				throw new Exception(ex.Message);
			}

			return output;
		}
	}
}
