using System.IO;

namespace Generator {
	internal class Component : Program {

		private static string directory = string.Empty;
		private static string pattern = string.Empty;

		private static string pattern_Main = string.Empty;
		private static string pattern_Css = string.Empty;
		private static string pattern_InquiryRecord = string.Empty;
		private static string pattern_insertField_TextBox = string.Empty;
		private static string pattern_insertField_Default = string.Empty;
		private static string pattern_updateField_TextBox = string.Empty;
		private static string pattern_updateField_Default = string.Empty;

		private static string inquiryRecord_List = string.Empty;
		private static string insertField_List = string.Empty;
		private static string updateField_List = string.Empty;

		public static void Generate() {
			string folder = @"Component\";
			directory = generatedDirectory + folder;
			pattern = patternDirectory + folder;

			if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

			#region Pattern
			pattern_Main = File.ReadAllText(pattern + "Main.txt");
			pattern_Css = File.ReadAllText(pattern + "Css.txt");

			pattern_InquiryRecord = File.ReadAllText(pattern + "InquiryRecord.txt");

			pattern_insertField_TextBox = File.ReadAllText(pattern + @"InsertField\TextBox.txt");
			pattern_insertField_Default = File.ReadAllText(pattern + @"InsertField\Default.txt");

			pattern_updateField_TextBox = File.ReadAllText(pattern + @"UpdateField\TextBox.txt");
			pattern_updateField_Default = File.ReadAllText(pattern + @"UpdateField\Default.txt");
			#endregion

			foreach (Tables_Record tables_Record in tables_RecordList) {
				TableElaboration(tables_Record);
			}

			if (Directory.Exists(@"..\..\..\..\EMMA_FE\Components\Generated")) Directory.Delete(@"..\..\..\..\EMMA_FE\Components\Generated", true);
			Directory.Move(@"..\..\..\Generated\Component", @"..\..\..\..\EMMA_FE\Components\Generated");
		}

		private static void TableElaboration(Tables_Record tables_Record) {
			string _Main = pattern_Main;

			#region Sections declaration
			inquiryRecord_List = string.Empty;
			insertField_List = string.Empty;
			updateField_List = string.Empty;
			#endregion

			foreach (Columns_Record columns_Record in columns_RecordList.Where(x => x.TABLE_NAME == tables_Record.TABLE_NAME).OrderBy(x => x.ORDINAL_POSITION)) {
				ColumnElaboration(columns_Record);
			}

			_Main = _Main.Replace("%%INQUIRY_RECORD%%", inquiryRecord_List[..^2]);
			_Main = _Main.Replace("%%INSERT_FIELD%%", insertField_List[..^2]);
			_Main = _Main.Replace("%%UPDATE_FIELD%%", updateField_List[..^2]);

			_Main = _Main.Replace("%%TABLE_NAME%%", tables_Record.TABLE_NAME);

			File.WriteAllText(directory + $"{tables_Record.TABLE_NAME}.razor", _Main);
			File.WriteAllText(directory + $"{tables_Record.TABLE_NAME}.razor.css", pattern_Css);
		}

		private static void ColumnElaboration(Columns_Record columns_Record) {
			int? fieldLength = columns_Record.CHARACTER_MAXIMUM_LENGTH == -1 ? null : columns_Record.CHARACTER_MAXIMUM_LENGTH;
			string length = fieldLength == null ? string.Empty : $" Length=\"{fieldLength}\"";
			string width = fieldLength == null ? string.Empty : $" Width=\"{fieldLength}\"";

			#region InquiryRecord
			string inquiryRecord_Record = pattern_InquiryRecord;
			inquiryRecord_List += inquiryRecord_Record.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
			#endregion

			#region InsertField
			string insertField_Record = string.Empty;
			if (!IsDefaultField(columns_Record.COLUMN_NAME)) {
				switch (columns_Record.DATA_TYPE) {
					case "varchar":
						insertField_Record = pattern_insertField_TextBox;
						insertField_Record = insertField_Record.Replace("%%LENGTH%%", length);
						insertField_Record = insertField_Record.Replace("%%WIDTH%%", width);
						break;
					default:
						insertField_Record = pattern_insertField_Default;
						break;
				}
				insertField_List += insertField_Record.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
			}
			#endregion

			#region UpdateField
			string updateField_Record = string.Empty;
			if (!IsDefaultField(columns_Record.COLUMN_NAME)) {
				switch (columns_Record.DATA_TYPE) {
					case "varchar":
						updateField_Record = pattern_updateField_TextBox;
						updateField_Record = updateField_Record.Replace("%%LENGTH%%", length);
						updateField_Record = updateField_Record.Replace("%%WIDTH%%", width);
						break;
					default:
						updateField_Record = pattern_updateField_Default;
						break;
				}
				updateField_List += updateField_Record.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
			}
			#endregion
		}
	}
}