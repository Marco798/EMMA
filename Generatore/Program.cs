using Generator.Classes;
using System.Data.SqlClient;

namespace Generator {
	internal class Program {
		protected static readonly List<Tables_Record> tables_RecordList = [];
		protected static readonly List<Columns_Record> columns_RecordList = [];

		protected static string directory = @"..\..\..\Generated\";
		protected static string pattern = @"..\..\..\Patterns\";

		static void Main() {
			GetTableData();

			Record.Generate(directory);
			NullRecord.Generate(directory);
		}

		private static void GetTableData() {
			string connectionString = "Server=localhost\\SQLEXPRESS;Database=EMMA;Integrated Security=True;";
			SqlConnection connection = new(connectionString);

			try {
				connection.Open();

				string queryTables = $"SELECT * " +
					$"FROM INFORMATION_SCHEMA.TABLES " +
					$"	LEFT JOIN SYST_TABLE ON (INFORMATION_SCHEMA.TABLES.TABLE_NAME = SYST_TABLE.TABLE_NAME)";

				using (SqlCommand command = new(queryTables, connection)) {
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read()) {
						Tables_Record tables_Record = new();
						int i = 0;

						tables_Record.TABLE_CATALOG = reader.GetString(i++);
						tables_Record.TABLE_SCHEMA = reader.GetString(i++);
						tables_Record.TABLE_NAME = reader.GetString(i++);
						tables_Record.TABLE_TYPE = reader.GetString(i++);

						i++;
						tables_Record.DESCRIPTION = reader.GetString(i++);
						tables_Record.SHORT_DESCRIPTION = reader.GetString(i++);

						tables_RecordList.Add(tables_Record);
					}
				}

				connection.Close();
				connection.Open();

				string queryColumns = $"SELECT * " +
					$"FROM INFORMATION_SCHEMA.COLUMNS " +
					$"	LEFT JOIN SYST_COLUMN ON (INFORMATION_SCHEMA.COLUMNS.TABLE_NAME = SYST_COLUMN.TABLE_NAME AND INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME = SYST_COLUMN.COLUMN_NAME)";

				using (SqlCommand command = new(queryColumns, connection)) {
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read()) {
						Columns_Record columns_Record = new();
						int i = 0;

						columns_Record.TABLE_CATALOG = reader.GetString(i++);
						columns_Record.TABLE_SCHEMA = reader.GetString(i++);
						columns_Record.TABLE_NAME = reader.GetString(i++);
						columns_Record.COLUMN_NAME = reader.GetString(i++);
						columns_Record.ORDINAL_POSITION = reader.GetInt32(i++);
						columns_Record.COLUMN_DEFAULT = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
						columns_Record.IS_NULLABLE = reader.GetString(i++);
						columns_Record.DATA_TYPE = reader.GetString(i++);
						columns_Record.CHARACTER_MAXIMUM_LENGTH = reader.IsDBNull(i) ? null : reader.GetInt32(i); i++;
						columns_Record.CHARACTER_OCTET_LENGTH = reader.IsDBNull(i) ? null : reader.GetInt32(i); i++;
						columns_Record.NUMERIC_PRECISION = reader.IsDBNull(i) ? null : reader.GetInt32(i); i++;
						columns_Record.NUMERIC_PRECISION_RADIX = reader.IsDBNull(i) ? null : reader.GetInt32(i); i++;
						columns_Record.NUMERIC_SCALE = reader.IsDBNull(i) ? null : reader.GetInt32(i); i++;
						columns_Record.DATETIME_PRECISION = reader.IsDBNull(i) ? null : reader.GetInt16(i); i++;
						columns_Record.CHARACTER_SET_CATALOG = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
						columns_Record.CHARACTER_SET_SCHEMA = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
						columns_Record.CHARACTER_SET_NAME = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
						columns_Record.COLLATION_CATALOG = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
						columns_Record.COLLATION_SCHEMA = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
						columns_Record.COLLATION_NAME = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
						columns_Record.DOMAIN_CATALOG = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
						columns_Record.DOMAIN_SCHEMA = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
						columns_Record.DOMAIN_NAME = reader.IsDBNull(i) ? null : reader.GetString(i); i++;

						i += 2;
						columns_Record.DESCRIPTION = reader.GetString(i++);
						columns_Record.SHORT_DESCRIPTION = reader.GetString(i++);

						columns_RecordList.Add(columns_Record);
					}
				}

				connection.Close();
			}
			catch (Exception e) {
				connection.Close();
				throw new Exception($"Error while retrieving tables and columns data: {e.Message}");
			}
		}
	}
}
