using EMMA.Commons;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EMMA_BE.Generated {
	public class BANK_STATEMENT_PATTERN_Query(IConfiguration configuration) : QueryBase(configuration) {
		private const string TableName = "BANK_StatementPattern";
		private const string TableNameDB = "BANK_STATEMENT_PATTERN";

		#region Select
		#region SelectAll
		public List<BANK_STATEMENT_PATTERN_Record> SelectAll() {
			using SqlConnection connection = new(connectionString);

			List<BANK_STATEMENT_PATTERN_Record> output = [];
			try {
				connection.Open();

				string query = "SELECT * FROM BANK_STATEMENT_PATTERN";
				using (SqlCommand command = new(query, connection)) {
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read()) {
						BANK_STATEMENT_PATTERN_Record record = new();
						int i = 0;

						record.ID = reader.GetInt32(i++);
						record.Set_FIELD(new BANK_STATEMENT_FIELD_Combo(reader.GetString(i++)));
						record.ORIGINAL_VALUE = reader.GetString(i++);
						record.PATTERN = reader.GetString(i++);
						record.Set_POSITION(new PATTERN_POSITION_Combo(reader.GetString(i++)));

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
		public void UpdateByKey(int id, BANK_STATEMENT_PATTERN_NullRecord record) {
			UpdateByKey(null, null, false, id, record);
		}

		public void UpdateByKey(SqlConnection? connection, SqlTransaction? transaction, bool keepAlive_transaction, int id, BANK_STATEMENT_PATTERN_NullRecord record) {
			if (transaction != null && (connection == null || connection.State != ConnectionState.Open)) {
				throw new Exception();
			}

			connection ??= new(connectionString);
			ConnectionState initialConnectionState = connection.State;

			try {
				StringBuilder query = new($"UPDATE BANK_STATEMENT_PATTERN SET ");
				List<SqlParameter> parameters = [];

				if (record.IsSet_FIELD) {
					query.Append("FIELD = @FIELD, ");
					parameters.Add(new SqlParameter("@FIELD", record.FIELD));
				}

				if (record.IsSet_ORIGINAL_VALUE) {
					query.Append("ORIGINAL_VALUE = @ORIGINAL_VALUE, ");
					parameters.Add(new SqlParameter("@ORIGINAL_VALUE", record.ORIGINAL_VALUE));
				}

				if (record.IsSet_PATTERN) {
					query.Append("PATTERN = @PATTERN, ");
					parameters.Add(new SqlParameter("@PATTERN", record.PATTERN));
				}

				if (record.IsSet_POSITION) {
					query.Append("POSITION = @POSITION, ");
					parameters.Add(new SqlParameter("@POSITION", record.POSITION));
				}

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
		public BANK_STATEMENT_PATTERN_Id Insert(BANK_STATEMENT_PATTERN_BaseRecord record) {
			return Insert(null, null, false, record);
		}

		public BANK_STATEMENT_PATTERN_Id Insert(SqlConnection? connection, SqlTransaction? transaction, bool keepAlive_transaction, BANK_STATEMENT_PATTERN_BaseRecord record) {
			if (transaction != null && (connection == null || connection.State != ConnectionState.Open)) {
				throw new Exception();
			}

			connection ??= new(connectionString);
			ConnectionState initialConnectionState = connection.State;

			try {
				StringBuilder query = new($"INSERT INTO BANK_STATEMENT_PATTERN OUTPUT INSERTED.ID VALUES (");
				List<SqlParameter> parameters = [];

				query.Append("@FIELD, ");
				parameters.Add(new SqlParameter("@FIELD", record.FIELD));

				query.Append("@ORIGINAL_VALUE, ");
				parameters.Add(new SqlParameter("@ORIGINAL_VALUE", record.ORIGINAL_VALUE));

				query.Append("@PATTERN, ");
				parameters.Add(new SqlParameter("@PATTERN", record.PATTERN));

				query.Append("@POSITION, ");
				parameters.Add(new SqlParameter("@POSITION", record.POSITION));

				query.Length -= 2;

				query.Append(")");

				SqlCommand command = new(query.ToString(), connection);
				command.Parameters.AddRange([.. parameters]);
				if (transaction != null) command.Transaction = transaction;

				if (initialConnectionState != ConnectionState.Open) connection.Open();

				BANK_STATEMENT_PATTERN_Id id = new((int)command.ExecuteScalar());
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
