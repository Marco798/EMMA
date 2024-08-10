﻿namespace Generator
{
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

				string tableName = ToPascalCase(tables_Record.TABLE_NAME);

				value_Record_Main = value_Record_Main.Replace("%%NAME_SPACE%%", "EMMA_BE.Generated");
				value_Record_Main = value_Record_Main.Replace("%%TABLE_NAME%%", tables_Record.TABLE_NAME);

				string recordField_List = string.Empty;
				string cloneField_List = string.Empty;
				foreach (Columns_Record columns_Record in columns_RecordList.Where(x => x.TABLE_NAME == tables_Record.TABLE_NAME)) {
					string value_Record_Field = pattern_Record_Field;

					string dataType = string.Empty;
					dataType = columns_Record.DATA_TYPE switch {
						"varchar" => "string",
						"varbinary" => "byte[]",
						"int" => "int",
						"bigint" => "long",
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

					cloneField_List += $"\t\t\t\t{columns_Record.COLUMN_NAME} = {columns_Record.COLUMN_NAME},\r\n";
				}

				value_Record_Main = value_Record_Main.Replace("%%RECORD_FIELD%%", recordField_List);
				value_Record_Main = value_Record_Main.Replace("%%CLONE_FIELD%%", cloneField_List[..^3]);

				File.WriteAllText(directory + $"{tables_Record.TABLE_NAME}_Record.cs", value_Record_Main);
			}
		}
	}
}
