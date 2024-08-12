using EMMA.Commons;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Text;

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
			}
			catch (Exception ex) {
				connection.Close();
				throw new Exception(ex.Message);
			}

			return output;
		}

		public void UpdateByKey(long id, FLOW_INPUT_FILE_NullRecord record) {
			using SqlConnection connection = new(connectionString);

			try {
				StringBuilder query = new($"UPDATE FLOW_INPUT_FILE SET ");
				List<SqlParameter> parameters = [];
				
				if (record.IsSet_NOME_FLUSSO) {
					query.Append("NOME_FLUSSO = @NOME_FLUSSO, ");
					parameters.Add(new SqlParameter("@NOME_FLUSSO", record.NOME_FLUSSO));
				}

				if (record.IsSet_TIPO_FLUSSO) {
					query.Append("TIPO_FLUSSO = @TIPO_FLUSSO, ");
					parameters.Add(new SqlParameter("@TIPO_FLUSSO", record.TIPO_FLUSSO));
				}

				if (record.IsSet_CONTENUTO) {
					query.Append("CONTENUTO = @CONTENUTO, ");
					parameters.Add(new SqlParameter("@CONTENUTO", record.CONTENUTO));
				}

				query.Append("UPD_DATE = @UPD_DATE, ");
				parameters.Add(new SqlParameter("@UPD_DATE", DateTime.Now.Date));

				query.Append("UPD_TIME = @UPD_TIME, ");
				parameters.Add(new SqlParameter("@UPD_TIME", DateTime.Now.TimeOfDay));

				query.Append("UPD_INFO = @UPD_INFO, ");
				parameters.Add(new SqlParameter("@UPD_INFO", DateTime.Now.ToString("yyyy-MM-dd;HH:mm:ss")));

				query.Length -= 2;

				query.Append(" WHERE ID = @ID");
				parameters.Add(new SqlParameter("@ID", id));

				SqlCommand command = new(query.ToString(), connection);
				command.Parameters.AddRange([.. parameters]);

				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();
			}
			catch (Exception ex) {
				connection.Close();
				throw new Exception(ex.Message);
			}
		}

		public void Insert(FLOW_INPUT_FILE_Record record) {
			using SqlConnection connection = new(connectionString);

			try {
				StringBuilder query = new($"INSERT INTO FLOW_INPUT_FILE VALUES ( ");
				List<SqlParameter> parameters = [];
				
				query.Append("@NOME_FLUSSO, ");
				parameters.Add(new SqlParameter("@NOME_FLUSSO", record.NOME_FLUSSO));

				query.Append("@TIPO_FLUSSO, ");
				parameters.Add(new SqlParameter("@TIPO_FLUSSO", record.TIPO_FLUSSO));

				query.Append("@CONTENUTO, ");
				parameters.Add(new SqlParameter("@CONTENUTO", record.CONTENUTO));

				query.Append("@INS_DATE, ");
				parameters.Add(new SqlParameter("@INS_DATE", DateTime.Now.Date));

				query.Append("@INS_TIME, ");
				parameters.Add(new SqlParameter("@INS_TIME", DateTime.Now.TimeOfDay));

				query.Append("@INS_INFO, ");
				parameters.Add(new SqlParameter("@INS_INFO", DateTime.Now.ToString("yyyy-MM-dd;HH:mm:ss")));

				query.Append("@UPD_DATE, ");
				parameters.Add(new SqlParameter("@UPD_DATE", DateTime.Now.Date));

				query.Append("@UPD_TIME, ");
				parameters.Add(new SqlParameter("@UPD_TIME", DateTime.Now.TimeOfDay));

				query.Append("@UPD_INFO, ");
				parameters.Add(new SqlParameter("@UPD_INFO", DateTime.Now.ToString("yyyy-MM-dd;HH:mm:ss")));

				query.Length -= 2;

				query.Append(")");

				SqlCommand command = new(query.ToString(), connection);
				command.Parameters.AddRange([.. parameters]);

				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();
			}
			catch (Exception ex) {
				connection.Close();
				throw new Exception(ex.Message);
			}
		}
	}
}
