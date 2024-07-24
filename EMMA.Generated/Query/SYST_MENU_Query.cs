using EMMA.Commons;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace EMMA_BE.Generated {
	public class SYST_MENU_Query(IConfiguration configuration) : QueryBase(configuration) {
		private const string NomeTabella = "SYST_Menu";
		private const string NomeTabellaDB = "SYST_MENU";
	
		public List<SYST_MENU_Record> SelectAll() {
			using SqlConnection connection = new(connectionString);

			List<SYST_MENU_Record> output = [];
			try {
				connection.Open();

				string query = "SELECT * FROM SYST_MENU";
				using (SqlCommand command = new(query, connection)) {
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read()) {
						SYST_MENU_Record record = new();
						int i = 0;
						
						record.ID = reader.GetInt32(i++);
						record.NAME = reader.GetString(i++);
						record.PARENT = reader.GetString(i++);
						record.DESCRIPTION = reader.GetString(i++);
						record.SHORT_DESCRIPTION = reader.GetString(i++);
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
