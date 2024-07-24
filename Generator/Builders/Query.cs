using System.Reflection.PortableExecutable;

namespace Generator
{
    internal class Query : Program {

		public static void Generate(string directory) {
			string folder = @"Query\";
			directory += folder;

			string pattern_Main = File.ReadAllText(pattern + folder + "Main.txt");
			string pattern_SelectAll_Field = File.ReadAllText(pattern + folder + "SelectAll_Field.txt");

			if (!Directory.Exists(directory))
				Directory.CreateDirectory(directory);

			foreach (Tables_Record tables_Record in tables_RecordList) {
				string value_Record_Main = pattern_Main;

				string tableName = ToPascalCase(tables_Record.TABLE_NAME);

				value_Record_Main = value_Record_Main.Replace("%%NAME_SPACE%%", "EMMA_BE.Generated");
				value_Record_Main = value_Record_Main.Replace("%%TABLE_NAME%%", tables_Record.TABLE_NAME);
				value_Record_Main = value_Record_Main.Replace("%%TABLE_NAME_PC%%", tableName);

				string recordField_List = string.Empty;
				foreach (Columns_Record columns_Record in columns_RecordList.Where(x => x.TABLE_NAME == tables_Record.TABLE_NAME)) {
					string value_Record_Field = pattern_SelectAll_Field;

					string dataType = string.Empty;
					dataType = columns_Record.DATA_TYPE switch {
						"varchar" or "varbinary" => "String",
						"int" => "Int32",
						"bigint" => "Int64",
						"date" => "DateTime",
						"time" => "TimeSpan",
						_ => throw new Exception(),
					};

					string getField = string.Empty;
					switch (columns_Record.IS_NULLABLE) {
						case "NO":
							getField = $@"reader.Get{dataType}(i++)";
							break;
						case "YES":
							getField = $@"reader.IsDBNull(i) ? null : reader.Get{dataType}(i); i++";
							break;
						default: break;
					}

					value_Record_Field = value_Record_Field.Replace("%%FIELD_NAME%%", columns_Record.COLUMN_NAME);
					value_Record_Field = value_Record_Field.Replace("%%GET_FIELD%%", getField);

					recordField_List += "\r\n" + value_Record_Field;
				}

				value_Record_Main = value_Record_Main.Replace("%%SELECT_ALL_FIELDS%%", recordField_List);

				File.WriteAllText(directory + $"{tables_Record.TABLE_NAME}_Query.cs", value_Record_Main);
			}
		}
	}
}
