﻿using System.Data.SqlClient;

namespace EditorDB.Services {
	public class MainService {
		public List<Tables_Record> Tables_RecordList { get; set; }
		public List<Columns_Record> Columns_RecordList { get; set; }
		public List<Combo_Record> Combo_RecordList { get; set; }
		public List<ComboValues_Record> ComboValues_RecordList { get; set; }

		static string connectionString = string.Empty;
		public SqlConnection connection = new();
		public MainService() {
			//connectionString = "Server=localhost\\SQLEXPRESS;Database=EMMA;Integrated Security=True;";
			//connectionString = "Server=localhost,1433;Database=EMMA;User Id=sa;Password=<YourStrong!Passw0rd>;";
            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\EMMA\\EMMA_DB\\EMMA_DB.mdf;Integrated Security=True;Connect Timeout=30";
            connection = new(connectionString);

			Tables_RecordList = [];
			Columns_RecordList = [];
			Combo_RecordList = [];
			ComboValues_RecordList = [];

			Update();
		}

		public void Update() {
			Tables_RecordList = [];
			Columns_RecordList = [];

			try {
				connection.Open();

				string queryTables = $"SELECT * FROM INFORMATION_SCHEMA.TABLES FULL JOIN SYST_TABLE ON (INFORMATION_SCHEMA.TABLES.TABLE_NAME = SYST_TABLE.TABLE_NAME)";

				using (SqlCommand command = new(queryTables, connection)) {
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read()) {
						Tables_Record tables_Record = new();
						int i = 0;

						tables_Record.TABLE_CATALOG = reader.GetString(i++);
						tables_Record.TABLE_SCHEMA = reader.GetString(i++);
						tables_Record.TABLE_NAME = reader.GetString(i++);
						tables_Record.TABLE_TYPE = reader.GetString(i++);

						i += 2;
						tables_Record.DESCRIPTION = reader.GetString(i++);
						tables_Record.SHORT_DESCRIPTION = reader.GetString(i++);

						Tables_RecordList.Add(tables_Record);
					}
				}

				connection.Close();
				connection.Open();

				string queryColumns = $"SELECT * FROM INFORMATION_SCHEMA.COLUMNS FULL JOIN SYST_COLUMN ON (INFORMATION_SCHEMA.COLUMNS.TABLE_NAME = SYST_COLUMN.TABLE_NAME AND INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME = SYST_COLUMN.COLUMN_NAME)";

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
						columns_Record.NUMERIC_PRECISION = reader.IsDBNull(i) ? null : reader.GetByte(i); i++;
						columns_Record.NUMERIC_PRECISION_RADIX = reader.IsDBNull(i) ? null : reader.GetInt16(i); i++;
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

						i += 3;
						columns_Record.DESCRIPTION = reader.GetString(i++);
						columns_Record.SHORT_DESCRIPTION = reader.GetString(i++);
						columns_Record.COMBO = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
						columns_Record.EXTERNAL_TABLE_ID = reader.IsDBNull(i) ? null : reader.GetString(i); i++;

						Columns_RecordList.Add(columns_Record);
					}
				}

				connection.Close();
				connection.Open();

				string queryCombo = $"SELECT * FROM SYST_COMBO";

				using (SqlCommand command = new(queryCombo, connection)) {
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read()) {
						Combo_Record combo_Record = new();
						int i = 1;

						combo_Record.NAME = reader.GetString(i++);
						combo_Record.TYPE = reader.GetString(i++);

						Combo_RecordList.Add(combo_Record);
					}
				}

				connection.Close();
				connection.Open();

				string queryComboValues = $"SELECT * FROM SYST_COMBO_VALUE";

				using (SqlCommand command = new(queryComboValues, connection)) {
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read()) {
						ComboValues_Record comboValue_Record = new();
						int i = 1;

						comboValue_Record.NAME = reader.GetString(i++);
						comboValue_Record.VALUE = reader.GetString(i++);
						comboValue_Record.COMBO = reader.GetString(i++);

						ComboValues_RecordList.Add(comboValue_Record);
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
