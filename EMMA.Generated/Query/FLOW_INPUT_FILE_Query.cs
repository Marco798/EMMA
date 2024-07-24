using EMMA.Commons;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace EMMA_BE.Generated {
	public class FLOW_INPUT_FILE_Query(IConfiguration configuration) : QueryBase(configuration) {
		private const string NomeTabella = "FLOW_InputFile";
		private const string NomeTabellaDB = "FLOW_INPUT_FILE";
	
		public List<FLOW_INPUT_FILE_Record> SelectAll() {
			using SqlConnection connection = new(connectionString);

			List<FLOW_INPUT_FILE_Record> output = [];
			try {
				connection.Open();

				string query = "SELECT * FROM FLOW_INPUT_FILE";
				using (SqlCommand command = new(query, connection)) {
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read()) {
						FLOW_INPUT_FILE_Record record = new();
						int i = 0;
						
						record.ID = reader.GetInt64(i++);
						record.NOME_FLUSSO = reader.GetString(i++);
						record.TIPO_FLUSSO = reader.GetString(i++);
						record.CONTENUTO = reader.GetString(i++);
						record.DATA_INS = reader.GetDateTime(i++);
						record.ORA_INS = reader.GetTimeSpan(i++);
						record.INFO_INS = reader.GetString(i++);
						record.DATA_AGG = reader.GetDateTime(i++);
						record.ORA_AGG = reader.GetTimeSpan(i++);
						record.INFO_AGG = reader.GetString(i++);

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
