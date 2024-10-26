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

				string query = $"SELECT * FROM FILE_INPUT";
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

		public List<FILE_INPUT_NullRecord> SelectAll(List<FILE_INPUT_Field>? fields = null) {
			using SqlConnection connection = new(connectionString);

			List<FILE_INPUT_NullRecord> output = [];
			try {
				connection.Open();

                StringBuilder selectFields = new(string.Empty);
                if (fields == null || fields.Count == 0) fields = FILE_INPUT_Field.GetAllFields();
                foreach (FILE_INPUT_Field field in fields) {
                    selectFields.Append($"{field.Value}, ");
                }

				string query = $"SELECT {selectFields.ToString()[..^2]} FROM FILE_INPUT";
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
        public List<FILE_INPUT_Record> SelectWithSimpleCriteria(FILE_INPUT_NullRecord nullRecord) {
            using SqlConnection connection = new(connectionString);

            List<FILE_INPUT_Record> output = [];
            try {
                connection.Open();

                StringBuilder query = new($"SELECT * FROM FILE_INPUT WHERE ");
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

        public List<FILE_INPUT_NullRecord> SelectWithSimpleCriteria(FILE_INPUT_NullRecord nullRecord, List<FILE_INPUT_Field>? fields = null) {
            using SqlConnection connection = new(connectionString);

            List<FILE_INPUT_NullRecord> output = [];
            try {
                connection.Open();

                StringBuilder selectFields = new(string.Empty);
                if (fields == null || fields.Count == 0) fields = FILE_INPUT_Field.GetAllFields();
                foreach (FILE_INPUT_Field field in fields) {
                    selectFields.Append($"{field.Value}, ");
                }

                StringBuilder query = new($"SELECT {selectFields.ToString()[..^2]} FROM FILE_INPUT WHERE ");
                List<SqlParameter> parameters = [];

                CheckNullRecord(nullRecord, query, parameters);

                if (parameters.Count == 0) return SelectAll(fields);

                using (SqlCommand command = new(query.ToString(), connection)) {
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
		public void UpdateByKey(int id, FILE_INPUT_NullRecord record) {
			UpdateByKey(null, null, false, id, record);
		}

		public void UpdateByKey(SqlConnection? connection, SqlTransaction? transaction, bool keepAlive_transaction, int id, FILE_INPUT_NullRecord nullRecord) {
			if (transaction != null && (connection == null || connection.State != ConnectionState.Open)) {
				throw new Exception();
			}

			connection ??= new(connectionString);
			ConnectionState initialConnectionState = connection.State;

			try {
				StringBuilder query = new($"UPDATE FILE_INPUT SET ");
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
		public FILE_INPUT_Id Insert(FILE_INPUT_BaseRecord record) {
			return Insert(null, null, false, record);
		}

		public FILE_INPUT_Id Insert(SqlConnection? connection, SqlTransaction? transaction, bool keepAlive_transaction, FILE_INPUT_BaseRecord record) {
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

				query.Append("@FILE_CATEGORY, ");
				parameters.Add(new SqlParameter("@FILE_CATEGORY", record.FILE_CATEGORY));

				query.Append("@CONTENT, ");
				parameters.Add(new SqlParameter("@CONTENT", record.CONTENT));

				query.Append("@INS_DATE, ");
				parameters.Add(new SqlParameter("@INS_DATE", DateTime.Now.Date));

				query.Append("@INS_TIME, ");
				parameters.Add(new SqlParameter("@INS_TIME", DateTime.Now.TimeOfDay));

				query.Append("@INS_INFO, ");
				parameters.Add(new SqlParameter("@INS_INFO", DateTime.Now.ToString("yyyy-MM-dd;HH:mm:ss.fffffff")));

				query.Length -= 2;

				query.Append(")");

				SqlCommand command = new(query.ToString(), connection);
				command.Parameters.AddRange([.. parameters]);
				if (transaction != null) command.Transaction = transaction;

				if (initialConnectionState != ConnectionState.Open) connection.Open();

				FILE_INPUT_Id id = new((int)command.ExecuteScalar());
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
        private static void CheckNullRecord(FILE_INPUT_NullRecord nullRecord, StringBuilder query, List<SqlParameter> parameters) {
			if (nullRecord.IsSet_FILE_NAME) {
				query.Append("FILE_NAME = @FILE_NAME, ");
				parameters.Add(new SqlParameter("@FILE_NAME", nullRecord.FILE_NAME));
			}

			if (nullRecord.IsSet_FILE_TYPE) {
				query.Append("FILE_TYPE = @FILE_TYPE, ");
				parameters.Add(new SqlParameter("@FILE_TYPE", nullRecord.FILE_TYPE));
			}

			if (nullRecord.IsSet_FILE_CATEGORY) {
				query.Append("FILE_CATEGORY = @FILE_CATEGORY, ");
				parameters.Add(new SqlParameter("@FILE_CATEGORY", nullRecord.FILE_CATEGORY));
			}

			if (nullRecord.IsSet_CONTENT) {
				query.Append("CONTENT = @CONTENT, ");
				parameters.Add(new SqlParameter("@CONTENT", nullRecord.CONTENT));
			}

            query.Length -= 2;
        }

        private static FILE_INPUT_Record ReadRecord(SqlDataReader reader) {
			FILE_INPUT_Record record = new();
			int i = 0;

			record.ID = reader.GetInt32(i++);
			record.FILE_NAME = reader.GetString(i++);
			record.Set_FILE_TYPE(new FILE_TYPE_Combo(reader.GetString(i++)));
			record.Set_FILE_CATEGORY(new FILE_CATEGORY_Combo(reader.GetString(i++)));
			record.CONTENT = new byte[reader.GetBytes(i, 0, null, 0, 0)];
			reader.GetBytes(i++, 0, record.CONTENT, 0, record.CONTENT.Length);
			record.INS_DATE = reader.GetDateTime(i++);
			record.INS_TIME = reader.GetTimeSpan(i++);
			record.INS_INFO = reader.GetString(i++);

            return record;
        }

        private static FILE_INPUT_NullRecord ReadNullRecord(SqlDataReader reader, List<FILE_INPUT_Field> fields) {
			FILE_INPUT_NullRecord record = new();
			int i = 0;

			if (fields.Contains(FILE_INPUT_Field.ID)) { record.ID = reader.GetInt32(i++); }
			if (fields.Contains(FILE_INPUT_Field.FILE_NAME)) { record.FILE_NAME = reader.GetString(i++); }
			if (fields.Contains(FILE_INPUT_Field.FILE_TYPE)) { record.Set_FILE_TYPE(new FILE_TYPE_Combo(reader.GetString(i++))); }
			if (fields.Contains(FILE_INPUT_Field.FILE_CATEGORY)) { record.Set_FILE_CATEGORY(new FILE_CATEGORY_Combo(reader.GetString(i++))); }
			if (fields.Contains(FILE_INPUT_Field.CONTENT)) { 
				record.CONTENT = new byte[reader.GetBytes(i, 0, null, 0, 0)];
				reader.GetBytes(i++, 0, record.CONTENT, 0, record.CONTENT.Length);
			}
			if (fields.Contains(FILE_INPUT_Field.INS_DATE)) { record.INS_DATE = reader.GetDateTime(i++); }
			if (fields.Contains(FILE_INPUT_Field.INS_TIME)) { record.INS_TIME = reader.GetTimeSpan(i++); }
			if (fields.Contains(FILE_INPUT_Field.INS_INFO)) { record.INS_INFO = reader.GetString(i++); }

            return record;
        }
        #endregion
	}
}
