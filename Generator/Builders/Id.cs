namespace Generator {
	internal class Id : Program {

		private static string directory = string.Empty;
		private static string pattern = string.Empty;

		private static string pattern_Main = string.Empty;

		public static void Generate() {
			string folder = @"Id\";
			directory = generatedDirectory + folder;
			pattern = patternDirectory + folder;

			if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

			#region Pattern
			pattern_Main = File.ReadAllText(pattern + "Main.txt");
			#endregion

			foreach (Tables_Record tables_Record in tables_RecordList) {
				TableElaboration(tables_Record);
			}

			if (Directory.Exists(@"..\..\..\..\EMMA.Generated\Id")) Directory.Delete(@"..\..\..\..\EMMA.Generated\Id", true);
			Directory.Move(@"..\..\..\Generated\Id", @"..\..\..\..\EMMA.Generated\Id");
		}

		private static void TableElaboration(Tables_Record tables_Record) {
			string _Main = pattern_Main;

			string idDataType = columns_RecordList.First(x => x.TABLE_NAME == tables_Record.TABLE_NAME && x.COLUMN_NAME == "ID").DATA_TYPE;
			string idFieldType = GetDataType_FromDB_ToCS(idDataType);

			#region Sections declaration
			#endregion

			foreach (Columns_Record columns_Record in columns_RecordList.Where(x => x.TABLE_NAME == tables_Record.TABLE_NAME).OrderBy(x => x.ORDINAL_POSITION)) {
				ColumnElaboration(columns_Record);
			}

			_Main = _Main.Replace("%%NAME_SPACE%%", "EMMA_BE.Generated");
			_Main = _Main.Replace("%%FIELD_TYPE%%", idFieldType);
			_Main = _Main.Replace("%%TABLE_NAME%%", tables_Record.TABLE_NAME);

			File.WriteAllText(directory + $"{tables_Record.TABLE_NAME}_Id.cs", _Main);
		}

		private static void ColumnElaboration(Columns_Record columns_Record) {

		}
	}
}
