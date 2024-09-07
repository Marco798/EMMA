namespace Generator {
	internal class IdRecord : Program {

		private static string directory = string.Empty;
		private static string pattern = string.Empty;

		private static string pattern_Main = string.Empty;
		private static string pattern_Field = string.Empty;
		private static string pattern_SetFieldCombo = string.Empty;
		private static string pattern_FromRecordField = string.Empty;
		private static string pattern_CloneField = string.Empty;

		private static string field_List = string.Empty;
		private static string setFieldCombo_List = string.Empty;
		private static string fromRecordField_List = string.Empty;
		private static string cloneField_List = string.Empty;

		public static void Generate() {
			string folder = @"IdRecord\";
			directory = generatedDirectory + folder;
			pattern = patternDirectory + folder;

			if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

			#region Pattern
			pattern_Main = File.ReadAllText(pattern + "Main.txt");

			pattern_Field = File.ReadAllText(pattern + "Field.txt");
			pattern_SetFieldCombo = File.ReadAllText(pattern + "SetFieldCombo.txt");
			pattern_FromRecordField = File.ReadAllText(pattern + "FromRecordField.txt");
			pattern_CloneField = File.ReadAllText(pattern + "CloneField.txt");
			#endregion

			foreach (Tables_Record tables_Record in tables_RecordList) {
				TableElaboration(tables_Record);
			}

			if (Directory.Exists(@"..\..\..\..\EMMA.Generated\IdRecord")) Directory.Delete(@"..\..\..\..\EMMA.Generated\IdRecord", true);
			Directory.Move(@"..\..\..\Generated\IdRecord", @"..\..\..\..\EMMA.Generated\IdRecord");
		}

		private static void TableElaboration(Tables_Record tables_Record) {
			string _Main = pattern_Main;

			#region Sections declaration
			field_List = string.Empty;
			setFieldCombo_List = string.Empty;
			fromRecordField_List = string.Empty;
			cloneField_List = string.Empty;
			#endregion

			foreach (Columns_Record columns_Record in columns_RecordList.Where(x => x.TABLE_NAME == tables_Record.TABLE_NAME)) {
				ColumnElaboration(columns_Record);
			}

			_Main = _Main.Replace("%%FIELD%%", field_List[..^2]);
			_Main = _Main.Replace("%%SET_FIELD_COMBO%%", string.IsNullOrWhiteSpace(setFieldCombo_List) ? string.Empty : "\r\n\r\n" + setFieldCombo_List[..^2]);
			_Main = _Main.Replace("%%FROM_RECORD_FIELD%%", fromRecordField_List[..^2]);
			_Main = _Main.Replace("%%CLONE_FIELD%%", cloneField_List[..^3]);

			_Main = _Main.Replace("%%NAME_SPACE%%", "EMMA_BE.Generated");
			_Main = _Main.Replace("%%TABLE_NAME%%", tables_Record.TABLE_NAME);

			File.WriteAllText(directory + $"{tables_Record.TABLE_NAME}_IdRecord.cs", _Main);
		}

		private static void ColumnElaboration(Columns_Record columns_Record) {
			if (auditFields.Contains(columns_Record.COLUMN_NAME))
				return;

			string dataType = GetDataType_FromDB_ToCS(columns_Record.DATA_TYPE);
			string isNullable = GetIsNullable(columns_Record.IS_NULLABLE);
			string accessLevel = columns_Record.COMBO != null ? "private " : "";

			#region Field
			string field = pattern_Field;
			field = field.Replace("%%DATA_TYPE%%", dataType);
			field = field.Replace("%%IS_NULLABLE%%", isNullable);
			field = field.Replace("%%ACCESS_LEVEL%%", accessLevel);
			field_List += field.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
			#endregion

			#region SetFieldCombo
			if (columns_Record.COMBO != null) {
				string setFieldCombo = pattern_SetFieldCombo;
				setFieldCombo = setFieldCombo.Replace("%%COMBO_NAME%%", columns_Record.COMBO);
				setFieldCombo_List += setFieldCombo.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
			}
			#endregion

			#region FromRecordField
			string fromRecordField = pattern_FromRecordField;
			fromRecordField_List += fromRecordField.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
			#endregion

			#region CloneField
			string cloneField = pattern_CloneField;
			cloneField_List += cloneField.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
			#endregion
		}
	}
}
