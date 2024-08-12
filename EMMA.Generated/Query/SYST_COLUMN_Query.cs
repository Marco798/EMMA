using EMMA.Commons;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace EMMA_BE.Generated {
	public class SYST_COLUMN_Query(IConfiguration configuration) : QueryBase(configuration) {
		private const string NomeTabella = "SYST_Column";
		private const string NomeTabellaDB = "SYST_COLUMN";
	
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

		public void UpdateByKey(int id, SYST_COLUMN_NullRecord record) {
			using SqlConnection connection = new(connectionString);

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

		public void Insert(SYST_COLUMN_Record record) {
			using SqlConnection connection = new(connectionString);

			try {
				StringBuilder query = new($"INSERT INTO SYST_COLUMN VALUES ( ");
				List<SqlParameter> parameters = [];
				
				query.Append("@TABLE_NAME, ");
				parameters.Add(new SqlParameter("@TABLE_NAME", record.TABLE_NAME));

				query.Append("@COLUMN_NAME, ");
				parameters.Add(new SqlParameter("@COLUMN_NAME", record.COLUMN_NAME));

				query.Append("@DESCRIPTION, ");
				parameters.Add(new SqlParameter("@DESCRIPTION", record.DESCRIPTION));

				query.Append("@SHORT_DESCRIPTION, ");
				parameters.Add(new SqlParameter("@SHORT_DESCRIPTION", record.SHORT_DESCRIPTION));

				query.Length -= 2;

				query.Append(")");

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
	}
}
