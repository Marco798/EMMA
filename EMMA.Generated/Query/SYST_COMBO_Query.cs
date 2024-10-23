using EMMA.Commons;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EMMA_BE.Generated {
	public class SYST_COMBO_Query(IConfiguration configuration) : QueryBase(configuration) {
		private const string TableName = "SYST_Combo";
		private const string TableNameDB = "SYST_COMBO";

		#region Select
		#region SelectAll
		public List<SYST_COMBO_Record> SelectAll() {
			using SqlConnection connection = new(connectionString);

			List<SYST_COMBO_Record> output = [];
			try {
				connection.Open();

				string query = "SELECT * FROM SYST_COMBO";
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
        public List<SYST_COMBO_Record> SelectWithSimpleCriteria(SYST_COMBO_NullRecord nullRecord) {
            using SqlConnection connection = new(connectionString);

            List<SYST_COMBO_Record> output = [];
            try {
                connection.Open();

                StringBuilder query = new($"SELECT * FROM SYST_COMBO WHERE ");
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
		public void UpdateByKey(int id, SYST_COMBO_NullRecord record) {
			UpdateByKey(null, null, false, id, record);
		}

		public void UpdateByKey(SqlConnection? connection, SqlTransaction? transaction, bool keepAlive_transaction, int id, SYST_COMBO_NullRecord nullRecord) {
			if (transaction != null && (connection == null || connection.State != ConnectionState.Open)) {
				throw new Exception();
			}

			connection ??= new(connectionString);
			ConnectionState initialConnectionState = connection.State;

			try {
				StringBuilder query = new($"UPDATE SYST_COMBO SET ");
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
		public SYST_COMBO_Id Insert(SYST_COMBO_BaseRecord record) {
			return Insert(null, null, false, record);
		}

		public SYST_COMBO_Id Insert(SqlConnection? connection, SqlTransaction? transaction, bool keepAlive_transaction, SYST_COMBO_BaseRecord record) {
			if (transaction != null && (connection == null || connection.State != ConnectionState.Open)) {
				throw new Exception();
			}

			connection ??= new(connectionString);
			ConnectionState initialConnectionState = connection.State;

			try {
				StringBuilder query = new($"INSERT INTO SYST_COMBO OUTPUT INSERTED.ID VALUES (");
				List<SqlParameter> parameters = [];

				query.Append("@NAME, ");
				parameters.Add(new SqlParameter("@NAME", record.NAME));

				query.Append("@TYPE, ");
				parameters.Add(new SqlParameter("@TYPE", record.TYPE));

				query.Length -= 2;

				query.Append(")");

				SqlCommand command = new(query.ToString(), connection);
				command.Parameters.AddRange([.. parameters]);
				if (transaction != null) command.Transaction = transaction;

				if (initialConnectionState != ConnectionState.Open) connection.Open();

				SYST_COMBO_Id id = new((int)command.ExecuteScalar());
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
        private static void CheckNullRecord(SYST_COMBO_NullRecord nullRecord, StringBuilder query, List<SqlParameter> parameters) {
			if (nullRecord.IsSet_NAME) {
				query.Append("NAME = @NAME, ");
				parameters.Add(new SqlParameter("@NAME", nullRecord.NAME));
			}

			if (nullRecord.IsSet_TYPE) {
				query.Append("TYPE = @TYPE, ");
				parameters.Add(new SqlParameter("@TYPE", nullRecord.TYPE));
			}

            query.Length -= 2;
        }

        private static SYST_COMBO_Record ReadRecord(SqlDataReader reader) {
			SYST_COMBO_Record record = new();
			int i = 0;

			record.ID = reader.GetInt32(i++);
			record.NAME = reader.GetString(i++);
			record.TYPE = reader.GetString(i++);

            return record;
        }
        #endregion
	}
}
