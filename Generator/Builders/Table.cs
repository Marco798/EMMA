namespace Generator {
	internal class Table : Program {
		public static void Generate(string directory) {
			string folder = @"Table\";
			directory += folder;

			string pattern_Record_Main = File.ReadAllText(pattern + folder + "Main.txt");

			if (!Directory.Exists(directory))
				Directory.CreateDirectory(directory);

			foreach (Tables_Record tables_Record in tables_RecordList) {
				string value_Record_Main = pattern_Record_Main;

				string tableName = ToPascalCase(tables_Record.TABLE_NAME);

				value_Record_Main = value_Record_Main.Replace("%%NAME_SPACE%%", "EMMA_BE.Generated");
				value_Record_Main = value_Record_Main.Replace("%%TABLE_NAME%%", tables_Record.TABLE_NAME);

				string field_List = string.Empty;
				foreach (Columns_Record columns_Record in columns_RecordList.Where(x => x.TABLE_NAME == tables_Record.TABLE_NAME).OrderBy(x => x.ORDINAL_POSITION)) {
					field_List += $"\r\n				\"{columns_Record.COLUMN_NAME}\",";
				}
				value_Record_Main = value_Record_Main.Replace("%%FIELD_LIST%%", field_List[..^1]);

				File.WriteAllText(directory + $"{tables_Record.TABLE_NAME}_Table.cs", value_Record_Main);
			}
		}
	}
}
