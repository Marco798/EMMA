using EMMA.Commons;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EMMA_BE.Generated {
	public class SYST_MENU_Query(IConfiguration configuration) : QueryBase(configuration) {
		private const string TableName = "SYST_Menu";
		private const string TableNameDB = "SYST_MENU";

		#region Select
		#region SelectAll
		public List<SYST_MENU_Record> SelectAll() {
			using SqlConnection connection = new(connectionString);

			List<SYST_MENU_Record> output = [];
			try {
				connection.Open();

				string query = $"SELECT * FROM SYST_MENU";
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

		public List<SYST_MENU_NullRecord> SelectAll(List<SYST_MENU_Field>? fields = null) {
			using SqlConnection connection = new(connectionString);

			List<SYST_MENU_NullRecord> output = [];
			try {
				connection.Open();

                StringBuilder selectFields = new(string.Empty);
                if (fields == null || fields.Count == 0) fields = SYST_MENU_Field.GetAllFields();
                foreach (SYST_MENU_Field field in fields) {
                    selectFields.Append($"{field.Value}, ");
                }

				string query = $"SELECT {selectFields.ToString()[..^2]} FROM SYST_MENU";
				using (SqlCommand command = new(query, connection)) {
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read()) {
                        output.Add(ReadNullRecord(reader, fields));
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
        public List<SYST_MENU_Record> SelectWithSimpleCriteria(SYST_MENU_NullRecord nullRecord) {
            using SqlConnection connection = new(connectionString);

            List<SYST_MENU_Record> output = [];
            try {
                connection.Open();

                StringBuilder query = new($"SELECT * FROM SYST_MENU WHERE ");
                List<SqlParameter> parameters = [];

                CheckNullRecord(nullRecord, query, parameters);

                if (parameters.Count == 0) return SelectAll();

                using (SqlCommand command = new(query.ToString(), connection)) {
					command.Parameters.AddRange([.. parameters]);
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

        public List<SYST_MENU_NullRecord> SelectWithSimpleCriteria(SYST_MENU_NullRecord nullRecord, List<SYST_MENU_Field>? fields = null) {
            using SqlConnection connection = new(connectionString);

            List<SYST_MENU_NullRecord> output = [];
            try {
                connection.Open();

                StringBuilder selectFields = new(string.Empty);
                if (fields == null || fields.Count == 0) fields = SYST_MENU_Field.GetAllFields();
                foreach (SYST_MENU_Field field in fields) {
                    selectFields.Append($"{field.Value}, ");
                }

                StringBuilder query = new($"SELECT {selectFields.ToString()[..^2]} FROM SYST_MENU WHERE ");
                List<SqlParameter> parameters = [];

                CheckNullRecord(nullRecord, query, parameters);

                if (parameters.Count == 0) return SelectAll(fields);

                using (SqlCommand command = new(query.ToString(), connection)) {
					command.Parameters.AddRange([.. parameters]);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        output.Add(ReadNullRecord(reader, fields));
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
		public void UpdateByKey(int id, SYST_MENU_NullRecord record) {
			UpdateByKey(null, null, false, id, record);
		}

		public void UpdateByKey(SqlConnection? connection, SqlTransaction? transaction, bool keepAlive_transaction, int id, SYST_MENU_NullRecord nullRecord) {
			if (transaction != null && (connection == null || connection.State != ConnectionState.Open)) {
				throw new Exception();
			}

			connection ??= new(connectionString);
			ConnectionState initialConnectionState = connection.State;

			try {
				StringBuilder query = new($"UPDATE SYST_MENU SET ");
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
		public SYST_MENU_Id Insert(SYST_MENU_BaseRecord record) {
			return Insert(null, null, false, record);
		}

		public SYST_MENU_Id Insert(SqlConnection? connection, SqlTransaction? transaction, bool keepAlive_transaction, SYST_MENU_BaseRecord record) {
			if (transaction != null && (connection == null || connection.State != ConnectionState.Open)) {
				throw new Exception();
			}

			connection ??= new(connectionString);
			ConnectionState initialConnectionState = connection.State;

			try {
				StringBuilder query = new($"INSERT INTO SYST_MENU OUTPUT INSERTED.ID VALUES (");
				List<SqlParameter> parameters = [];

				query.Append("@NAME, ");
				parameters.Add(new SqlParameter("@NAME", record.NAME));

				query.Append("@PARENT, ");
				parameters.Add(new SqlParameter("@PARENT", record.PARENT));

				query.Append("@DESCRIPTION, ");
				parameters.Add(new SqlParameter("@DESCRIPTION", record.DESCRIPTION));

				query.Append("@SHORT_DESCRIPTION, ");
				parameters.Add(new SqlParameter("@SHORT_DESCRIPTION", record.SHORT_DESCRIPTION));

				query.Append("@INDEX, ");
				parameters.Add(new SqlParameter("@INDEX", record.INDEX.HasValue ? record.INDEX : DBNull.Value));

				query.Length -= 2;

				query.Append(")");

				SqlCommand command = new(query.ToString(), connection);
				command.Parameters.AddRange([.. parameters]);
				if (transaction != null) command.Transaction = transaction;

				if (initialConnectionState != ConnectionState.Open) connection.Open();

				SYST_MENU_Id id = new((int)command.ExecuteScalar());
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
        private static void CheckNullRecord(SYST_MENU_NullRecord nullRecord, StringBuilder query, List<SqlParameter> parameters) {
			if (nullRecord.IsSet_NAME) {
				query.Append("NAME = @NAME, ");
				parameters.Add(new SqlParameter("@NAME", nullRecord.NAME));
			}

			if (nullRecord.IsSet_PARENT) {
				query.Append("PARENT = @PARENT, ");
				parameters.Add(new SqlParameter("@PARENT", nullRecord.PARENT));
			}

			if (nullRecord.IsSet_DESCRIPTION) {
				query.Append("DESCRIPTION = @DESCRIPTION, ");
				parameters.Add(new SqlParameter("@DESCRIPTION", nullRecord.DESCRIPTION));
			}

			if (nullRecord.IsSet_SHORT_DESCRIPTION) {
				query.Append("SHORT_DESCRIPTION = @SHORT_DESCRIPTION, ");
				parameters.Add(new SqlParameter("@SHORT_DESCRIPTION", nullRecord.SHORT_DESCRIPTION));
			}

			if (nullRecord.IsSet_INDEX) {
				query.Append("INDEX = @INDEX, ");
				parameters.Add(new SqlParameter("@INDEX", nullRecord.INDEX));
			}

            query.Length -= 2;
        }

        private static SYST_MENU_Record ReadRecord(SqlDataReader reader) {
			SYST_MENU_Record record = new();
			int i = 0;

			record.ID = reader.GetInt32(i++);
			record.NAME = reader.GetString(i++);
			record.PARENT = reader.GetInt32(i++);
			record.DESCRIPTION = reader.GetString(i++);
			record.SHORT_DESCRIPTION = reader.GetString(i++);
			record.INDEX = reader.IsDBNull(i) ? null : reader.GetInt32(i); i++;

            return record;
        }

        private static SYST_MENU_NullRecord ReadNullRecord(SqlDataReader reader, List<SYST_MENU_Field> fields) {
			SYST_MENU_NullRecord record = new();
			int i = 0;

			if (fields.Contains(SYST_MENU_Field.ID)) { record.ID = reader.GetInt32(i++); }
			if (fields.Contains(SYST_MENU_Field.NAME)) { record.NAME = reader.GetString(i++); }
			if (fields.Contains(SYST_MENU_Field.PARENT)) { record.PARENT = reader.GetInt32(i++); }
			if (fields.Contains(SYST_MENU_Field.DESCRIPTION)) { record.DESCRIPTION = reader.GetString(i++); }
			if (fields.Contains(SYST_MENU_Field.SHORT_DESCRIPTION)) { record.SHORT_DESCRIPTION = reader.GetString(i++); }
			if (fields.Contains(SYST_MENU_Field.INDEX)) { record.INDEX = reader.IsDBNull(i) ? null : reader.GetInt32(i); i++; }

            return record;
        }
        #endregion
	}
}
