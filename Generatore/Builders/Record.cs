using Generator.Classes;

namespace Generator {
	internal class Record : Program {

		public static void Generate(string directory) {
			string folder = @"Record\";
			directory += folder;

			string pattern_Record_Main = File.ReadAllText(pattern + folder + "Main.txt");
			string pattern_Record_Field = File.ReadAllText(pattern + folder + "Main_Field.txt");

			if (!Directory.Exists(directory))
				Directory.CreateDirectory(directory);

			foreach (Tables_Record tables_Record in tables_RecordList) {
				string value_Record_Main = pattern_Record_Main;

				value_Record_Main = value_Record_Main.Replace("%%NAME_SPACE%%", "Generator");
				value_Record_Main = value_Record_Main.Replace("%%CLASS_NAME%%", tables_Record.TABLE_NAME);

				string recordField_List = string.Empty;
				foreach (Columns_Record columns_Record in columns_RecordList.Where(x => x.TABLE_NAME == tables_Record.TABLE_NAME)) {
					string value_Record_Field = pattern_Record_Field;

					string dataType = string.Empty;
					dataType = columns_Record.DATA_TYPE switch {
						"varchar" or "varbinary" => "string",
						"date" => "DateTime",
						"time" => "TimeSpan",
						_ => throw new Exception(),
					};

					string isNullable = string.Empty;
					isNullable = columns_Record.IS_NULLABLE switch {
						"NO" => "",
						"YES" => "?",
						_ => throw new Exception(),
					};

					value_Record_Field = value_Record_Field.Replace("%%DATA_TYPE%%", dataType);
					value_Record_Field = value_Record_Field.Replace("%%IS_NULLABLE%%", isNullable);
					value_Record_Field = value_Record_Field.Replace("%%FIELD_NAME%%", columns_Record.COLUMN_NAME);

					recordField_List += "\r\n" + value_Record_Field;
				}

				value_Record_Main = value_Record_Main.Replace("%%RECORD_FIELD%%", recordField_List);

				File.WriteAllText(directory + $"{tables_Record.TABLE_NAME}_Record.cs", value_Record_Main);
			}
		}
	}
}
