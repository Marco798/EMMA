namespace Generator {
	internal class Table : Program {

		private static string directory = string.Empty;
		private static string pattern = string.Empty;

		private static string pattern_Main = string.Empty;
		private static string pattern_GetFieldField = string.Empty;

		private static string getFieldField_List = string.Empty;

		public static void Generate() {
			string folder = @"Table\";
			directory = generatedDirectory + folder;
			pattern = patternDirectory + folder;

			if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

			#region Pattern
			pattern_Main = File.ReadAllText(pattern + "Main.txt");

			pattern_GetFieldField = File.ReadAllText(pattern + "GetFieldField.txt");
			#endregion

			foreach (Tables_Record tables_Record in tables_RecordList) {
				TableElaboration(tables_Record);
			}
		}

		private static void TableElaboration(Tables_Record tables_Record) {
			string _Main = pattern_Main;

			#region Sections declaration
			getFieldField_List = string.Empty;
			#endregion

			foreach (Columns_Record columns_Record in columns_RecordList.Where(x => x.TABLE_NAME == tables_Record.TABLE_NAME).OrderBy(x => x.ORDINAL_POSITION)) {
				ColumnElaboration(columns_Record);
			}

			_Main = _Main.Replace("%%GET_FIELD_FIELD%%", getFieldField_List[..^3]);

			_Main = _Main.Replace("%%NAME_SPACE%%", "EMMA_BE.Generated");
			_Main = _Main.Replace("%%TABLE_NAME%%", tables_Record.TABLE_NAME);

			File.WriteAllText(directory + $"{tables_Record.TABLE_NAME}_Table.cs", _Main);
		}

		private static void ColumnElaboration(Columns_Record columns_Record) {
			#region GetField
			string getFieldField = pattern_GetFieldField;
			getFieldField_List += getFieldField.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
			#endregion
		}
	}
}
