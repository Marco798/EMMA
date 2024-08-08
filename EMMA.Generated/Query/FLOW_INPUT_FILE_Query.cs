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

						record.CONTENUTO = new byte[reader.GetBytes(i, 0, null, 0, 0)];
						reader.GetBytes(i++, 0, record.CONTENUTO, 0, record.CONTENUTO.Length);
						record.INS_DATE = reader.GetDateTime(i++);
						record.INS_TIME = reader.GetTimeSpan(i++);
						record.INS_INFO = reader.GetString(i++);
						record.UPD_DATE = reader.GetDateTime(i++);
						record.UPD_TIME = reader.GetTimeSpan(i++);
						record.UPD_INFO = reader.GetString(i++);

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
