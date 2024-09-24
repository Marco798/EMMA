using EMMA.Commons;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EMMA_BE.Generated {
	public class SYST_COLUMN_Query(IConfiguration configuration) : QueryBase(configuration) {
		private const string TableName = "SYST_Column";
		private const string TableNameDB = "SYST_COLUMN";

		#region Select
		#region SelectAll
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

						record.ID = reader.GetInt32(i++);
						record.TABLE_NAME = reader.GetString(i++);
						record.COLUMN_NAME = reader.GetString(i++);
						record.DESCRIPTION = reader.GetString(i++);
						record.SHORT_DESCRIPTION = reader.GetString(i++);
						record.COMBO = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
						record.EXTERNAL_TABLE_ID = reader.IsDBNull(i) ? null : reader.GetString(i); i++;

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
		public void UpdateByKey(int id, SYST_COLUMN_NullRecord record) {
			UpdateByKey(null, null, false, id, record);
		}

		public void UpdateByKey(SqlConnection? connection, SqlTransaction? transaction, bool keepAlive_transaction, int id, SYST_COLUMN_NullRecord record) {
			if (transaction != null && (connection == null || connection.State != ConnectionState.Open)) {
				throw new Exception();
			}

			connection ??= new(connectionString);
			ConnectionState initialConnectionState = connection.State;

			try {
				StringBuilder query = new($"UPDATE SYST_COLUMN SET ");
				List<SqlParameter> parameters = [];

				if (record.IsSet_TABLE_NAME) {
					query.Append("TABLE_NAME = @TABLE_NAME, ");
					parameters.Add(new SqlParameter("@TABLE_NAME", record.TABLE_NAME));
				}

				if (record.IsSet_COLUMN_NAME) {
					query.Append("COLUMN_NAME = @COLUMN_NAME, ");
					parameters.Add(new SqlParameter("@COLUMN_NAME", record.COLUMN_NAME));
				}

				if (record.IsSet_DESCRIPTION) {
					query.Append("DESCRIPTION = @DESCRIPTION, ");
					parameters.Add(new SqlParameter("@DESCRIPTION", record.DESCRIPTION));
				}

				if (record.IsSet_SHORT_DESCRIPTION) {
					query.Append("SHORT_DESCRIPTION = @SHORT_DESCRIPTION, ");
					parameters.Add(new SqlParameter("@SHORT_DESCRIPTION", record.SHORT_DESCRIPTION));
				}

				if (record.IsSet_COMBO) {
					query.Append("COMBO = @COMBO, ");
					parameters.Add(new SqlParameter("@COMBO", record.COMBO));
				}

				if (record.IsSet_EXTERNAL_TABLE_ID) {
					query.Append("EXTERNAL_TABLE_ID = @EXTERNAL_TABLE_ID, ");
					parameters.Add(new SqlParameter("@EXTERNAL_TABLE_ID", record.EXTERNAL_TABLE_ID));
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
		public SYST_COLUMN_Id Insert(SYST_COLUMN_BaseRecord record) {
			return Insert(null, null, false, record);
		}

		public SYST_COLUMN_Id Insert(SqlConnection? connection, SqlTransaction? transaction, bool keepAlive_transaction, SYST_COLUMN_BaseRecord record) {
			if (transaction != null && (connection == null || connection.State != ConnectionState.Open)) {
				throw new Exception();
			}

			connection ??= new(connectionString);
			ConnectionState initialConnectionState = connection.State;

			try {
				StringBuilder query = new($"INSERT INTO SYST_COLUMN OUTPUT INSERTED.ID VALUES (");
				List<SqlParameter> parameters = [];

				query.Append("@TABLE_NAME, ");
				parameters.Add(new SqlParameter("@TABLE_NAME", record.TABLE_NAME));

				query.Append("@COLUMN_NAME, ");
				parameters.Add(new SqlParameter("@COLUMN_NAME", record.COLUMN_NAME));

				query.Append("@DESCRIPTION, ");
				parameters.Add(new SqlParameter("@DESCRIPTION", record.DESCRIPTION));

				query.Append("@SHORT_DESCRIPTION, ");
				parameters.Add(new SqlParameter("@SHORT_DESCRIPTION", record.SHORT_DESCRIPTION));

				query.Append("@COMBO, ");
				parameters.Add(new SqlParameter("@COMBO", record.COMBO.HasValue ? record.COMBO : DBNull.Value));

				query.Append("@EXTERNAL_TABLE_ID, ");
				parameters.Add(new SqlParameter("@EXTERNAL_TABLE_ID", record.EXTERNAL_TABLE_ID.HasValue ? record.EXTERNAL_TABLE_ID : DBNull.Value));

				query.Length -= 2;

				query.Append(")");

				SqlCommand command = new(query.ToString(), connection);
				command.Parameters.AddRange([.. parameters]);
				if (transaction != null) command.Transaction = transaction;

				if (initialConnectionState != ConnectionState.Open) connection.Open();

				SYST_COLUMN_Id id = new((int)command.ExecuteScalar());
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
