using Generator.Exceptions;
using System.Data.SqlClient;
using System.Text;

namespace Generator {
	public class Program {
		internal static readonly List<Tables_Record> tables_RecordList = [];
		internal static readonly List<Columns_Record> columns_RecordList = [];
		internal static readonly List<Combo_Record> combo_RecordList = [];
		internal static readonly List<ComboValues_Record> comboValues_RecordList = [];

		private const string queryTables = $"SELECT * FROM INFORMATION_SCHEMA.TABLES FULL JOIN SYST_TABLE ON (INFORMATION_SCHEMA.TABLES.TABLE_NAME = SYST_TABLE.TABLE_NAME)";
		private const string queryColumns = $"SELECT * FROM INFORMATION_SCHEMA.COLUMNS FULL JOIN SYST_COLUMN ON (INFORMATION_SCHEMA.COLUMNS.TABLE_NAME = SYST_COLUMN.TABLE_NAME AND INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME = SYST_COLUMN.COLUMN_NAME)";
		private const string queryCombo = $"SELECT * FROM SYST_COMBO";
		private const string queryComboValues = $"SELECT * FROM SYST_COMBO_VALUE";

		private static SqlConnection connection = new();

		protected Program() {

		}

		public static void Main() {
			GetTableData();

			if (Directory.Exists(Consts.generatedDirectory)) {
				Directory.Delete(Consts.generatedDirectory, true);
			}

			BaseRecord.Generate();
			IdRecord.Generate();
			NullRecord.Generate();
			Record.Generate();

			Component.Generate();
			Controller.Generate();
			Query.Generate();
			Table.Generate();

			Combo.Generate();
			Id.Generate();
            Field.Generate();
        }

		static void GetData(string query, Action<SqlDataReader> addToList) {
			SqlCommand command = new(query, connection);
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read()) {
				addToList(reader);
			}
			reader.Close();
		}

		private static void GetTableData() {
			const string connectionString = "Server=localhost,1433;Database=EMMA;User Id=sa;Password=<YourStrong!Passw0rd>;";
			connection = new(connectionString);

			try {
				connection.Open();

				GetData(queryTables, reader => tables_RecordList.Add(GetTablesRecord(reader)));
				GetData(queryColumns, reader => columns_RecordList.Add(GetColumnsRecord(reader)));
				GetData(queryCombo, reader => combo_RecordList.Add(GetComboRecord(reader)));
				GetData(queryComboValues, reader => comboValues_RecordList.Add(GetComboValuesRecord(reader)));

				connection.Close();
			}
			catch (Exception e) {
				connection.Close();
				throw new RetrievingSystDataException($"Error while retrieving syst data: {e.Message}");
			}
		}

		private static Tables_Record GetTablesRecord(SqlDataReader reader) {
			Tables_Record tables_Record = new();
			int i = 0;

			tables_Record.TABLE_CATALOG = reader.GetString(i++);
			tables_Record.TABLE_SCHEMA = reader.GetString(i++);
			tables_Record.TABLE_NAME = reader.GetString(i++);
			tables_Record.TABLE_TYPE = reader.GetString(i++);

			i++;
			tables_Record.DESCRIPTION = reader.GetString(i++);
			tables_Record.SHORT_DESCRIPTION = reader.GetString(i);

			return tables_Record;
		}

		private static Columns_Record GetColumnsRecord(SqlDataReader reader) {
			Columns_Record columns_Record = new();
			int i = 0;

			columns_Record.TABLE_CATALOG = reader.GetString(i++);
			columns_Record.TABLE_SCHEMA = reader.GetString(i++);
			columns_Record.TABLE_NAME = reader.GetString(i++);
			columns_Record.COLUMN_NAME = reader.GetString(i++);
			columns_Record.ORDINAL_POSITION = reader.GetInt32(i++);
			columns_Record.COLUMN_DEFAULT = ReaderGetNullableString(reader, i++);
			columns_Record.IS_NULLABLE = reader.GetString(i++);
			columns_Record.DATA_TYPE = reader.GetString(i++);
			columns_Record.CHARACTER_MAXIMUM_LENGTH = ReaderGetNullableInt32(reader, i++);
			columns_Record.CHARACTER_OCTET_LENGTH = ReaderGetNullableInt32(reader, i++);
			columns_Record.NUMERIC_PRECISION = ReaderGetNullableByte(reader, i++);
			columns_Record.NUMERIC_PRECISION_RADIX = ReaderGetNullableInt16(reader, i++);
			columns_Record.NUMERIC_SCALE = ReaderGetNullableInt32(reader, i++);
			columns_Record.DATETIME_PRECISION = ReaderGetNullableInt16(reader, i++);
			columns_Record.CHARACTER_SET_CATALOG = ReaderGetNullableString(reader, i++);
			columns_Record.CHARACTER_SET_SCHEMA = ReaderGetNullableString(reader, i++);
			columns_Record.CHARACTER_SET_NAME = ReaderGetNullableString(reader, i++);
			columns_Record.COLLATION_CATALOG = ReaderGetNullableString(reader, i++);
			columns_Record.COLLATION_SCHEMA = ReaderGetNullableString(reader, i++);
			columns_Record.COLLATION_NAME = ReaderGetNullableString(reader, i++);
			columns_Record.DOMAIN_CATALOG = ReaderGetNullableString(reader, i++);
			columns_Record.DOMAIN_SCHEMA = ReaderGetNullableString(reader, i++);
			columns_Record.DOMAIN_NAME = ReaderGetNullableString(reader, i++);

			i += 3;
			columns_Record.DESCRIPTION = reader.GetString(i++);
			columns_Record.SHORT_DESCRIPTION = reader.GetString(i++);
			columns_Record.COMBO = ReaderGetNullableString(reader, i++);
			columns_Record.EXTERNAL_TABLE_ID = ReaderGetNullableString(reader, i);

			return columns_Record;
		}

		private static Combo_Record GetComboRecord(SqlDataReader reader) {
			Combo_Record combo_Record = new();
			int i = 1;

			combo_Record.NAME = reader.GetString(i++);
			combo_Record.TYPE = reader.GetString(i);

			return combo_Record;
		}

		private static ComboValues_Record GetComboValuesRecord(SqlDataReader reader) {
			ComboValues_Record comboValue_Record = new();
			int i = 1;

			comboValue_Record.NAME = reader.GetString(i++);
			comboValue_Record.VALUE = reader.GetString(i++);
			comboValue_Record.COMBO = reader.GetString(i);

			return comboValue_Record;
		}

		private static string? ReaderGetNullableString(SqlDataReader reader, int i) {
			return reader.IsDBNull(i) ? null : reader.GetString(i);
		}

		private static byte? ReaderGetNullableByte(SqlDataReader reader, int i) {
			return reader.IsDBNull(i) ? null : reader.GetByte(i);
		}

		private static short? ReaderGetNullableInt16(SqlDataReader reader, int i) {
			return reader.IsDBNull(i) ? null : reader.GetInt16(i);
		}

		private static int? ReaderGetNullableInt32(SqlDataReader reader, int i) {
			return reader.IsDBNull(i) ? null : reader.GetInt32(i);
		}

		protected static string ToPascalCase(string constantCase) {
			string[] words = constantCase.Split('_');

			StringBuilder output = new();
			output.Append(words[0] + "_");
			foreach (string word in words.Skip(1)) {
				output.Append(word.ToUpper()[0]);
				output.Append(word[1..].ToLower());
			}

			return output.ToString();
		}

		protected static bool IsDefaultField(string columnName) {
			return Consts.defaultFields.Contains(columnName);
		}

		protected static string GetDataType_FromDB_ToCS(string dataType) {
			return dataType switch {
				Consts._DB_DataType_varchar => Consts._CS_DataType_string,
				Consts._DB_DataType_char => Consts._CS_DataType_string,
				Consts._DB_DataType_varbinary => Consts._CS_DataType_byteArray,
				Consts._DB_DataType_int => Consts._CS_DataType_int,
				Consts._DB_DataType_bigint => Consts._CS_DataType_long,
				Consts._DB_DataType_decimal => Consts._CS_DataType_decimal,
				Consts._DB_DataType_date => Consts._CS_DataType_DateTime,
				Consts._DB_DataType_time => Consts._CS_DataType_TimeSpan,
				_ => throw new UnmanagedDataTypeException()
			};
		}

		protected static string GetDataType_FromDB_ToReader(string dataType) {
			return dataType switch {
				Consts._DB_DataType_varchar => Consts._Reader_DataType_String,
				Consts._DB_DataType_char => Consts._Reader_DataType_String,
				Consts._DB_DataType_varbinary => string.Empty,
				Consts._DB_DataType_int => Consts._Reader_DataType_Int32,
				Consts._DB_DataType_bigint => Consts._Reader_DataType_Int64,
				Consts._DB_DataType_decimal => Consts._Reader_DataType_Decimal,
				Consts._DB_DataType_date => Consts._Reader_DataType_DateTime,
				Consts._DB_DataType_time => Consts._Reader_DataType_TimeSpan,
				_ => throw new UnmanagedDataTypeException()
			};
		}

		protected static string GetDefaultValue(string dataType) {
			return dataType switch {
				Consts._DB_DataType_varchar => Consts._Default_DataType_stringEmpty,
				Consts._DB_DataType_char => Consts._Default_DataType_stringEmpty,
				Consts._DB_DataType_varbinary => Consts._Default_DataType_emptyArray,
				_ => throw new UnmanagedDataTypeException()
			};
		}

		protected static string GetIdType_FromDB_ToCS(string tableName) {
			return columns_RecordList.First(x => x.TABLE_NAME == tableName && x.COLUMN_NAME == Consts.ID).DATA_TYPE switch {
				Consts._DB_DataType_int => Consts._CS_DataType_int,
				Consts._DB_DataType_bigint => Consts._CS_DataType_long,
				_ => throw new UnmanagedDataTypeException(),
			};
		}

		protected static string GetIsNullable(string isNullable) {
			return isNullable switch {
				Consts._NO => string.Empty,
				Consts._YES => Consts._IsNullable,
				_ => throw new NotIsNullableValueException(),
			};
		}
	}
}
