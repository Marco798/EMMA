using EMMA.Commons;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EMMA_BE.Generated {
	public class SYST_TABLE_Query(IConfiguration configuration) : QueryBase(configuration) {
		private const string TableName = "SYST_Table";
		private const string TableNameDB = "SYST_TABLE";

		#region Select
		#region SelectAll
		public List<SYST_TABLE_Record> SelectAll(List<SYST_TABLE_Field>? fields = null) {
			using SqlConnection connection = new(connectionString);

			List<SYST_TABLE_Record> output = [];
			try {
				connection.Open();

                StringBuilder selectFields = new(string.Empty);
                if (fields == null || fields.Count == 0) fields = SYST_TABLE_Field.GetAllFields();
                foreach (SYST_TABLE_Field field in fields) {
                    selectFields.Append($"{field.Value}, ");
                }

				string query = $"SELECT {selectFields.ToString()[..^2]} FROM SYST_TABLE";
				using (SqlCommand command = new(query, connection)) {
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read()) {
                        output.Add(ReadRecord(reader));
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

        #region SelectWithSimpleCriteria
        public List<SYST_TABLE_Record> SelectWithSimpleCriteria(SYST_TABLE_NullRecord nullRecord, List<SYST_TABLE_Field>? fields = null) {
            using SqlConnection connection = new(connectionString);

            List<SYST_TABLE_Record> output = [];
            try {
                connection.Open();

                StringBuilder selectFields = new(string.Empty);
                if (fields == null || fields.Count == 0) fields = SYST_TABLE_Field.GetAllFields();
                foreach (SYST_TABLE_Field field in fields) {
                    selectFields.Append($"{field.Value}, ");
                }

                StringBuilder query = new($"SELECT {selectFields.ToString()[..^2]} FROM SYST_TABLE WHERE ");
                List<SqlParameter> parameters = [];

                CheckNullRecord(nullRecord, query, parameters);

                if (parameters.Count == 0) return SelectAll();

                using (SqlCommand command = new(query.ToString(), connection)) {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        output.Add(ReadRecord(reader));
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
		public void UpdateByKey(int id, SYST_TABLE_NullRecord record) {
			UpdateByKey(null, null, false, id, record);
		}

		public void UpdateByKey(SqlConnection? connection, SqlTransaction? transaction, bool keepAlive_transaction, int id, SYST_TABLE_NullRecord nullRecord) {
			if (transaction != null && (connection == null || connection.State != ConnectionState.Open)) {
				throw new Exception();
			}

			connection ??= new(connectionString);
			ConnectionState initialConnectionState = connection.State;

			try {
				StringBuilder query = new($"UPDATE SYST_TABLE SET ");
				List<SqlParameter> parameters = [];

                CheckNullRecord(nullRecord, query, parameters);

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
		public SYST_TABLE_Id Insert(SYST_TABLE_BaseRecord record) {
			return Insert(null, null, false, record);
		}

		public SYST_TABLE_Id Insert(SqlConnection? connection, SqlTransaction? transaction, bool keepAlive_transaction, SYST_TABLE_BaseRecord record) {
			if (transaction != null && (connection == null || connection.State != ConnectionState.Open)) {
				throw new Exception();
			}

			connection ??= new(connectionString);
			ConnectionState initialConnectionState = connection.State;

			try {
				StringBuilder query = new($"INSERT INTO SYST_TABLE OUTPUT INSERTED.ID VALUES (");
				List<SqlParameter> parameters = [];

				query.Append("@TABLE_NAME, ");
				parameters.Add(new SqlParameter("@TABLE_NAME", record.TABLE_NAME));

				query.Append("@DESCRIPTION, ");
				parameters.Add(new SqlParameter("@DESCRIPTION", record.DESCRIPTION));

				query.Append("@SHORT_DESCRIPTION, ");
				parameters.Add(new SqlParameter("@SHORT_DESCRIPTION", record.SHORT_DESCRIPTION));

				query.Length -= 2;

				query.Append(")");

				SqlCommand command = new(query.ToString(), connection);
				command.Parameters.AddRange([.. parameters]);
				if (transaction != null) command.Transaction = transaction;

				if (initialConnectionState != ConnectionState.Open) connection.Open();

				SYST_TABLE_Id id = new((int)command.ExecuteScalar());
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

        #region Common
        private static void CheckNullRecord(SYST_TABLE_NullRecord nullRecord, StringBuilder query, List<SqlParameter> parameters) {
			if (nullRecord.IsSet_TABLE_NAME) {
				query.Append("TABLE_NAME = @TABLE_NAME, ");
				parameters.Add(new SqlParameter("@TABLE_NAME", nullRecord.TABLE_NAME));
			}

			if (nullRecord.IsSet_DESCRIPTION) {
				query.Append("DESCRIPTION = @DESCRIPTION, ");
				parameters.Add(new SqlParameter("@DESCRIPTION", nullRecord.DESCRIPTION));
			}

			if (nullRecord.IsSet_SHORT_DESCRIPTION) {
				query.Append("SHORT_DESCRIPTION = @SHORT_DESCRIPTION, ");
				parameters.Add(new SqlParameter("@SHORT_DESCRIPTION", nullRecord.SHORT_DESCRIPTION));
			}

            query.Length -= 2;
        }

        private static SYST_TABLE_Record ReadRecord(SqlDataReader reader) {
			SYST_TABLE_Record record = new();
			int i = 0;

			record.ID = reader.GetInt32(i++);
			record.TABLE_NAME = reader.GetString(i++);
			record.DESCRIPTION = reader.GetString(i++);
			record.SHORT_DESCRIPTION = reader.GetString(i++);

            return record;
        }
        #endregion
	}
}
