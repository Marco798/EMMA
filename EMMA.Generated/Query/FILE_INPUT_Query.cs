using EMMA.Commons;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EMMA_BE.Generated {
	public class FILE_INPUT_Query(IConfiguration configuration) : QueryBase(configuration) {
		private const string TableName = "FILE_Input";
		private const string TableNameDB = "FILE_INPUT";

		#region Select
		#region SelectAll
		public List<FILE_INPUT_Record> SelectAll() {
			using SqlConnection connection = new(connectionString);

			List<FILE_INPUT_Record> output = [];
			try {
				connection.Open();

				string query = "SELECT * FROM FILE_INPUT";
				using (SqlCommand command = new(query, connection)) {
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read()) {
						FILE_INPUT_Record record = new();
						int i = 0;

						record.ID = reader.GetInt32(i++);
						record.FILE_NAME = reader.GetString(i++);
						record.Set_FILE_TYPE(new FILE_TYPE_Combo(reader.GetString(i++)));
						record.CONTENT = new byte[reader.GetBytes(i, 0, null, 0, 0)];
						reader.GetBytes(i++, 0, record.CONTENT, 0, record.CONTENT.Length);
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
		public void UpdateByKey(int id, FILE_INPUT_NullRecord record) {
			UpdateByKey(null, null, false, id, record);
		}

		public void UpdateByKey(SqlConnection? connection, SqlTransaction? transaction, bool keepAlive_transaction, int id, FILE_INPUT_NullRecord record) {
			if (transaction != null && (connection == null || connection.State != ConnectionState.Open)) {
				throw new Exception();
			}

			connection ??= new(connectionString);
			ConnectionState initialConnectionState = connection.State;

			try {
				StringBuilder query = new($"UPDATE FILE_INPUT SET ");
				List<SqlParameter> parameters = [];

				if (record.IsSet_FILE_NAME) {
					query.Append("FILE_NAME = @FILE_NAME, ");
					parameters.Add(new SqlParameter("@FILE_NAME", record.FILE_NAME));
				}

				if (record.IsSet_FILE_TYPE) {
					query.Append("FILE_TYPE = @FILE_TYPE, ");
					parameters.Add(new SqlParameter("@FILE_TYPE", record.FILE_TYPE));
				}

				if (record.IsSet_CONTENT) {
					query.Append("CONTENT = @CONTENT, ");
					parameters.Add(new SqlParameter("@CONTENT", record.CONTENT));
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
		public void Insert(FILE_INPUT_BaseRecord record) {
			Insert(null, null, false, record);
		}

		public int Insert(SqlConnection? connection, SqlTransaction? transaction, bool keepAlive_transaction, FILE_INPUT_BaseRecord record) {
			if (transaction != null && (connection == null || connection.State != ConnectionState.Open)) {
				throw new Exception();
			}

			connection ??= new(connectionString);
			ConnectionState initialConnectionState = connection.State;

			try {
				StringBuilder query = new($"INSERT INTO FILE_INPUT OUTPUT INSERTED.ID VALUES (");
				List<SqlParameter> parameters = [];

				query.Append("@FILE_NAME, ");
				parameters.Add(new SqlParameter("@FILE_NAME", record.FILE_NAME));

				query.Append("@FILE_TYPE, ");
				parameters.Add(new SqlParameter("@FILE_TYPE", record.FILE_TYPE));

				query.Append("@CONTENT, ");
				parameters.Add(new SqlParameter("@CONTENT", record.CONTENT));

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
