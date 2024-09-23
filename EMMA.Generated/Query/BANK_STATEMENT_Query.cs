using EMMA.Commons;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EMMA_BE.Generated {
	public class BANK_STATEMENT_Query(IConfiguration configuration) : QueryBase(configuration) {
		private const string TableName = "BANK_Statement";
		private const string TableNameDB = "BANK_STATEMENT";

		#region Select
		#region SelectAll
		public List<BANK_STATEMENT_Record> SelectAll() {
			using SqlConnection connection = new(connectionString);

			List<BANK_STATEMENT_Record> output = [];
			try {
				connection.Open();

				string query = "SELECT * FROM BANK_STATEMENT";
				using (SqlCommand command = new(query, connection)) {
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read()) {
						BANK_STATEMENT_Record record = new();
						int i = 0;

						record.ID = reader.GetInt32(i++);
						record.OPERATION_DATE = reader.GetDateTime(i++);
						record.VALUE_DATE = reader.GetDateTime(i++);
						record.REASON = reader.GetString(i++);
						record.DESCRIPTION = reader.GetString(i++);
						record.OUTCOME = reader.IsDBNull(i) ? null : reader.GetDecimal(i); i++;
						record.INCOME = reader.IsDBNull(i) ? null : reader.GetDecimal(i); i++;
						record.Set_TAG1(new BALANCE_DIRECTION_Combo(reader.GetString(i++)));
						record.TAG2 = reader.GetString(i++);
						record.TAG3 = reader.GetString(i++);
						record.TAG4 = reader.GetString(i++);
						record.ID_FILE_INPUT = reader.GetInt32(i++);
						record.ID_BANK_STATEMENT_DESC_PATTERN = reader.IsDBNull(i) ? null : reader.GetInt32(i); i++;
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
		#endregion
		#endregion
		
		#region Update
		#region UpdateByKey
		public void UpdateByKey(int id, BANK_STATEMENT_NullRecord record) {
			UpdateByKey(null, null, false, id, record);
		}

		public void UpdateByKey(SqlConnection? connection, SqlTransaction? transaction, bool keepAlive_transaction, int id, BANK_STATEMENT_NullRecord record) {
			if (transaction != null && (connection == null || connection.State != ConnectionState.Open)) {
				throw new Exception();
			}

			connection ??= new(connectionString);
			ConnectionState initialConnectionState = connection.State;

			try {
				StringBuilder query = new($"UPDATE BANK_STATEMENT SET ");
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

				if (record.IsSet_ID_FILE_INPUT) {
					query.Append("ID_FILE_INPUT = @ID_FILE_INPUT, ");
					parameters.Add(new SqlParameter("@ID_FILE_INPUT", record.ID_FILE_INPUT));
				}

				if (record.IsSet_ID_BANK_STATEMENT_DESC_PATTERN) {
					query.Append("ID_BANK_STATEMENT_DESC_PATTERN = @ID_BANK_STATEMENT_DESC_PATTERN, ");
					parameters.Add(new SqlParameter("@ID_BANK_STATEMENT_DESC_PATTERN", record.ID_BANK_STATEMENT_DESC_PATTERN));
				}

				query.Append("UPD_DATE = @UPD_DATE, ");
				parameters.Add(new SqlParameter("@UPD_DATE", DateTime.Now.Date));

				query.Append("UPD_TIME = @UPD_TIME, ");
				parameters.Add(new SqlParameter("@UPD_TIME", DateTime.Now.TimeOfDay));

				query.Append("UPD_INFO = @UPD_INFO, ");
				parameters.Add(new SqlParameter("@UPD_INFO", DateTime.Now.ToString("yyyy-MM-dd;HH:mm:ss.fffffff")));

				query.Length -= 2;

				query.Append(" WHERE ID = @ID");
				parameters.Add(new SqlParameter("@ID", id));

				SqlCommand command = new(query.ToString(), connection);
				command.Parameters.AddRange([.. parameters]);
				if (transaction != null) command.Transaction = transaction;

				if (initialConnectionState != ConnectionState.Open) connection.Open();

				command.ExecuteNonQuery();
				if (transaction != null && !keepAlive_transaction)
					transaction.Commit();

				if (initialConnectionState != ConnectionState.Open) connection.Close();
			}
			catch (Exception ex) {
				transaction?.Rollback();

				connection.Close();
				throw new Exception(ex.Message);
			}
		}
		#endregion
		#endregion
		
		#region Insert
		public int Insert(BANK_STATEMENT_BaseRecord record) {
			return Insert(null, null, false, record);
		}

		public int Insert(SqlConnection? connection, SqlTransaction? transaction, bool keepAlive_transaction, BANK_STATEMENT_BaseRecord record) {
			if (transaction != null && (connection == null || connection.State != ConnectionState.Open)) {
				throw new Exception();
			}

			connection ??= new(connectionString);
			ConnectionState initialConnectionState = connection.State;

			try {
				StringBuilder query = new($"INSERT INTO BANK_STATEMENT OUTPUT INSERTED.ID VALUES (");
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
				parameters.Add(new SqlParameter("@OUTCOME", record.OUTCOME.HasValue ? record.OUTCOME : DBNull.Value));

				query.Append("@INCOME, ");
				parameters.Add(new SqlParameter("@INCOME", record.INCOME.HasValue ? record.INCOME : DBNull.Value));

				query.Append("@TAG1, ");
				parameters.Add(new SqlParameter("@TAG1", record.TAG1));

				query.Append("@TAG2, ");
				parameters.Add(new SqlParameter("@TAG2", record.TAG2));

				query.Append("@TAG3, ");
				parameters.Add(new SqlParameter("@TAG3", record.TAG3));

				query.Append("@TAG4, ");
				parameters.Add(new SqlParameter("@TAG4", record.TAG4));

				query.Append("@ID_FILE_INPUT, ");
				parameters.Add(new SqlParameter("@ID_FILE_INPUT", record.ID_FILE_INPUT));

				query.Append("@ID_BANK_STATEMENT_DESC_PATTERN, ");
				parameters.Add(new SqlParameter("@ID_BANK_STATEMENT_DESC_PATTERN", record.ID_BANK_STATEMENT_DESC_PATTERN.HasValue ? record.ID_BANK_STATEMENT_DESC_PATTERN : DBNull.Value));

				query.Append("@INS_DATE, ");
				parameters.Add(new SqlParameter("@INS_DATE", DateTime.Now.Date));

				query.Append("@INS_TIME, ");
				parameters.Add(new SqlParameter("@INS_TIME", DateTime.Now.TimeOfDay));

				query.Append("@INS_INFO, ");
				parameters.Add(new SqlParameter("@INS_INFO", DateTime.Now.ToString("yyyy-MM-dd;HH:mm:ss.fffffff")));

				query.Append("@UPD_DATE, ");
				parameters.Add(new SqlParameter("@UPD_DATE", DateTime.Now.Date));

				query.Append("@UPD_TIME, ");
				parameters.Add(new SqlParameter("@UPD_TIME", DateTime.Now.TimeOfDay));

				query.Append("@UPD_INFO, ");
				parameters.Add(new SqlParameter("@UPD_INFO", DateTime.Now.ToString("yyyy-MM-dd;HH:mm:ss.fffffff")));

				query.Length -= 2;

				query.Append(")");

				SqlCommand command = new(query.ToString(), connection);
				command.Parameters.AddRange([.. parameters]);
				if (transaction != null) command.Transaction = transaction;

				if (initialConnectionState != ConnectionState.Open) connection.Open();

				int id = (int)command.ExecuteScalar();
				if (transaction != null && !keepAlive_transaction)
					transaction.Commit();

				if (initialConnectionState != ConnectionState.Open) connection.Close();

				return id;
			}
			catch (Exception ex) {
				transaction?.Rollback();

				connection.Close();
				throw new Exception(ex.Message);
			}
		}
		#endregion
	}
}
