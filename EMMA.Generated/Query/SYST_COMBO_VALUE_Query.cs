using EMMA.Commons;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EMMA_BE.Generated {
	public class SYST_COMBO_VALUE_Query(IConfiguration configuration) : QueryBase(configuration) {
		private const string TableName = "SYST_ComboValue";
		private const string TableNameDB = "SYST_COMBO_VALUE";

		#region Select
		#region SelectAll
		public List<SYST_COMBO_VALUE_Record> SelectAll() {
			using SqlConnection connection = new(connectionString);

			List<SYST_COMBO_VALUE_Record> output = [];
			try {
				connection.Open();

				string query = "SELECT * FROM SYST_COMBO_VALUE";
				using (SqlCommand command = new(query, connection)) {
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read()) {
						SYST_COMBO_VALUE_Record record = new();
						int i = 0;

						record.ID = reader.GetInt32(i++);
						record.NAME = reader.GetString(i++);
						record.VALUE = reader.GetString(i++);
						record.COMBO = reader.GetString(i++);

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
		public void UpdateByKey(int id, SYST_COMBO_VALUE_NullRecord record) {
			UpdateByKey(null, null, false, id, record);
		}

		public void UpdateByKey(SqlConnection? connection, SqlTransaction? transaction, bool keepAlive_transaction, int id, SYST_COMBO_VALUE_NullRecord record) {
			if (transaction != null && (connection == null || connection.State != ConnectionState.Open)) {
				throw new Exception();
			}

			connection ??= new(connectionString);
			ConnectionState initialConnectionState = connection.State;

			try {
				StringBuilder query = new($"UPDATE SYST_COMBO_VALUE SET ");
				List<SqlParameter> parameters = [];

				if (record.IsSet_NAME) {
					query.Append("NAME = @NAME, ");
					parameters.Add(new SqlParameter("@NAME", record.NAME));
				}

				if (record.IsSet_VALUE) {
					query.Append("VALUE = @VALUE, ");
					parameters.Add(new SqlParameter("@VALUE", record.VALUE));
				}

				if (record.IsSet_COMBO) {
					query.Append("COMBO = @COMBO, ");
					parameters.Add(new SqlParameter("@COMBO", record.COMBO));
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
		public void Insert(SYST_COMBO_VALUE_BaseRecord record) {
			Insert(null, null, false, record);
		}

		public int Insert(SqlConnection? connection, SqlTransaction? transaction, bool keepAlive_transaction, SYST_COMBO_VALUE_BaseRecord record) {
			if (transaction != null && (connection == null || connection.State != ConnectionState.Open)) {
				throw new Exception();
			}

			connection ??= new(connectionString);
			ConnectionState initialConnectionState = connection.State;

			try {
				StringBuilder query = new($"INSERT INTO SYST_COMBO_VALUE OUTPUT INSERTED.ID VALUES (");
				List<SqlParameter> parameters = [];

				query.Append("@NAME, ");
				parameters.Add(new SqlParameter("@NAME", record.NAME));

				query.Append("@VALUE, ");
				parameters.Add(new SqlParameter("@VALUE", record.VALUE));

				query.Append("@COMBO, ");
				parameters.Add(new SqlParameter("@COMBO", record.COMBO));

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
