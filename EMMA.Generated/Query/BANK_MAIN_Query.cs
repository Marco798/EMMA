using EMMA.Commons;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace EMMA_BE.Generated {
	public class BANK_MAIN_Query(IConfiguration configuration) : QueryBase(configuration) {
		private const string NomeTabella = "BANK_Main";
		private const string NomeTabellaDB = "BANK_MAIN";
	
		public List<BANK_MAIN_Record> SelectAll() {
			using SqlConnection connection = new(connectionString);

			List<BANK_MAIN_Record> output = [];
			try {
				connection.Open();

				string query = "SELECT * FROM BANK_MAIN";
				using (SqlCommand command = new(query, connection)) {
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read()) {
						BANK_MAIN_Record record = new();
						int i = 0;

						record.ID = reader.GetInt64(i++);
						record.OPERATION_DATE = reader.GetDateTime(i++);
						record.VALUE_DATE = reader.GetDateTime(i++);
						record.REASON = reader.GetString(i++);
						record.DESCRIPTION = reader.GetString(i++);
						record.OUTCOME = reader.IsDBNull(i) ? null : reader.GetDecimal(i); i++;
						record.INCOME = reader.IsDBNull(i) ? null : reader.GetDecimal(i); i++;
						record.TAG1 = reader.GetString(i++);
						record.TAG2 = reader.GetString(i++);
						record.TAG3 = reader.GetString(i++);
						record.TAG4 = reader.GetString(i++);
						record.FLOW_INPUT_FILE_ID = reader.GetInt64(i++);
						record.INS_DATE = reader.GetDateTime(i++);
						record.INS_TIME = reader.GetTimeSpan(i++);
						record.INS_INFO = reader.GetString(i++);

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

		public void UpdateByKey(long id, BANK_MAIN_NullRecord record) {
			using SqlConnection connection = new(connectionString);

			try {
				StringBuilder query = new($"UPDATE BANK_MAIN SET ");
				List<SqlParameter> parameters = [];

				if (record.IsSet_OPERATION_DATE) {
					query.Append("OPERATION_DATE = @OPERATION_DATE, ");
					parameters.Add(new SqlParameter("@OPERATION_DATE", record.OPERATION_DATE));
				}

				if (record.IsSet_VALUE_DATE) {
					query.Append("VALUE_DATE = @VALUE_DATE, ");
					parameters.Add(new SqlParameter("@VALUE_DATE", record.VALUE_DATE));
				}

				if (record.IsSet_REASON) {
					query.Append("REASON = @REASON, ");
					parameters.Add(new SqlParameter("@REASON", record.REASON));
				}

				if (record.IsSet_DESCRIPTION) {
					query.Append("DESCRIPTION = @DESCRIPTION, ");
					parameters.Add(new SqlParameter("@DESCRIPTION", record.DESCRIPTION));
				}

				if (record.IsSet_OUTCOME) {
					query.Append("OUTCOME = @OUTCOME, ");
					parameters.Add(new SqlParameter("@OUTCOME", record.OUTCOME));
				}

				if (record.IsSet_INCOME) {
					query.Append("INCOME = @INCOME, ");
					parameters.Add(new SqlParameter("@INCOME", record.INCOME));
				}

				if (record.IsSet_TAG1) {
					query.Append("TAG1 = @TAG1, ");
					parameters.Add(new SqlParameter("@TAG1", record.TAG1));
				}

				if (record.IsSet_TAG2) {
					query.Append("TAG2 = @TAG2, ");
					parameters.Add(new SqlParameter("@TAG2", record.TAG2));
				}

				if (record.IsSet_TAG3) {
					query.Append("TAG3 = @TAG3, ");
					parameters.Add(new SqlParameter("@TAG3", record.TAG3));
				}

				if (record.IsSet_TAG4) {
					query.Append("TAG4 = @TAG4, ");
					parameters.Add(new SqlParameter("@TAG4", record.TAG4));
				}

				if (record.IsSet_FLOW_INPUT_FILE_ID) {
					query.Append("FLOW_INPUT_FILE_ID = @FLOW_INPUT_FILE_ID, ");
					parameters.Add(new SqlParameter("@FLOW_INPUT_FILE_ID", record.FLOW_INPUT_FILE_ID));
				}

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

		public long Insert(BANK_MAIN_BaseRecord record) {
			using SqlConnection connection = new(connectionString);

			try {
				StringBuilder query = new($"INSERT INTO BANK_MAIN OUTPUT INSERTED.ID VALUES (");
				List<SqlParameter> parameters = [];

				query.Append("@OPERATION_DATE, ");
				parameters.Add(new SqlParameter("@OPERATION_DATE", record.OPERATION_DATE));

				query.Append("@VALUE_DATE, ");
				parameters.Add(new SqlParameter("@VALUE_DATE", record.VALUE_DATE));

				query.Append("@REASON, ");
				parameters.Add(new SqlParameter("@REASON", record.REASON));

				query.Append("@DESCRIPTION, ");
				parameters.Add(new SqlParameter("@DESCRIPTION", record.DESCRIPTION));

				query.Append("@OUTCOME, ");
				parameters.Add(new SqlParameter("@OUTCOME", record.OUTCOME.HasValue ? record.OUTCOME.Value : DBNull.Value));

				query.Append("@INCOME, ");
				parameters.Add(new SqlParameter("@INCOME", record.INCOME.HasValue ? record.INCOME.Value : DBNull.Value));

				query.Append("@TAG1, ");
				parameters.Add(new SqlParameter("@TAG1", record.TAG1));

				query.Append("@TAG2, ");
				parameters.Add(new SqlParameter("@TAG2", record.TAG2));

				query.Append("@TAG3, ");
				parameters.Add(new SqlParameter("@TAG3", record.TAG3));

				query.Append("@TAG4, ");
				parameters.Add(new SqlParameter("@TAG4", record.TAG4));

				query.Append("@FLOW_INPUT_FILE_ID, ");
				parameters.Add(new SqlParameter("@FLOW_INPUT_FILE_ID", record.FLOW_INPUT_FILE_ID));

				query.Append("@INS_DATE, ");
				parameters.Add(new SqlParameter("@INS_DATE", DateTime.Now.Date));

				query.Append("@INS_TIME, ");
				parameters.Add(new SqlParameter("@INS_TIME", DateTime.Now.TimeOfDay));

				query.Append("@INS_INFO, ");
				parameters.Add(new SqlParameter("@INS_INFO", DateTime.Now.ToString("yyyy-MM-dd;HH:mm:ss")));

				query.Length -= 2;

				query.Append(")");

				SqlCommand command = new(query.ToString(), connection);
				command.Parameters.AddRange([.. parameters]);

				connection.Open();
				long id = (long)command.ExecuteScalar();
				connection.Close();

				return id;
			}
			catch (Exception ex) {
				connection.Close();
				throw new Exception(ex.Message);
			}
		}
	}
}
