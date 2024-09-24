using System.Reflection.PortableExecutable;

namespace Generator {
	internal class Query : Program {

		private static string directory = string.Empty;

		private static string pattern_Main = string.Empty;
		private static string pattern_SelectAllField_Binary = string.Empty;
		private static string pattern_SelectAllField_NotNullable = string.Empty;
		private static string pattern_SelectAllField_NotNullableCombo = string.Empty;
		private static string pattern_SelectAllField_NotNullableId = string.Empty;
		private static string pattern_SelectAllField_Nullable = string.Empty;
		private static string pattern_SelectAllField_NullableId = string.Empty;
		private static string pattern_UpdateByKeyField_UpdateByKey = string.Empty;
		private static string pattern_UpdateByKeyField_DefaultField = string.Empty;
		private static string pattern_InsertField_Insert_Nullable = string.Empty;
		private static string pattern_InsertField_Insert_NotNullable = string.Empty;
		private static string pattern_InsertField_DefaultField = string.Empty;

		private static string selectAllField_List = string.Empty;
		private static string updateByKeyField_List = string.Empty;
		private static string insertField_List = string.Empty;

		public static void Generate() {
			const string folder = @"Query\";
			directory = Consts.generatedDirectory + folder;
			string pattern = Consts.patternDirectory + folder;

			if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

			#region Pattern
			pattern_Main = File.ReadAllText(pattern + "Main.txt");

			pattern_SelectAllField_Binary = File.ReadAllText(pattern + @"SelectAllField\Binary.txt");
			pattern_SelectAllField_NotNullable = File.ReadAllText(pattern + @"SelectAllField\NotNullable.txt");
			pattern_SelectAllField_NotNullableCombo = File.ReadAllText(pattern + @"SelectAllField\NotNullableCombo.txt");
			pattern_SelectAllField_NotNullableId = File.ReadAllText(pattern + @"SelectAllField\NotNullableId.txt");
			pattern_SelectAllField_Nullable = File.ReadAllText(pattern + @"SelectAllField\Nullable.txt");
			pattern_SelectAllField_NullableId = File.ReadAllText(pattern + @"SelectAllField\NullableId.txt");

			pattern_UpdateByKeyField_UpdateByKey = File.ReadAllText(pattern + @"UpdateByKeyField\UpdateByKey.txt");
			pattern_UpdateByKeyField_DefaultField = File.ReadAllText(pattern + @"UpdateByKeyField\DefaultField.txt");

			pattern_InsertField_Insert_Nullable = File.ReadAllText(pattern + @"InsertField\Insert_Nullable.txt");
			pattern_InsertField_Insert_NotNullable = File.ReadAllText(pattern + @"InsertField\Insert_NotNullable.txt");
			pattern_InsertField_DefaultField = File.ReadAllText(pattern + @"InsertField\DefaultField.txt");
			#endregion

			foreach (Tables_Record tables_Record in tables_RecordList) {
				TableElaboration(tables_Record);
			}

			if (Directory.Exists(@"..\..\..\..\EMMA.Generated\Query")) Directory.Delete(@"..\..\..\..\EMMA.Generated\Query", true);
			Directory.Move(@"..\..\..\Generated\Query", @"..\..\..\..\EMMA.Generated\Query");
		}

		private static void TableElaboration(Tables_Record tables_Record) {
			string _Main = pattern_Main;
			string tableName = ToPascalCase(tables_Record.TABLE_NAME);

			#region Sections declaration
			selectAllField_List = string.Empty;
			updateByKeyField_List = string.Empty;
			insertField_List = string.Empty;
			#endregion

			foreach (Columns_Record columns_Record in columns_RecordList.Where(x => x.TABLE_NAME == tables_Record.TABLE_NAME)) {
				ColumnElaboration(columns_Record);
			}

			_Main = _Main.Replace("%%SELECT_ALL_FIELD%%", selectAllField_List[..^2]);
			_Main = _Main.Replace("%%UPDATE_BY_KEY_FIELD%%", updateByKeyField_List[..^2]);
			_Main = _Main.Replace("%%INSERT_FIELD%%", insertField_List[..^2]);

			_Main = _Main.Replace("%%NAME_SPACE%%", "EMMA_BE.Generated");
			_Main = _Main.Replace("%%TABLE_NAME%%", tables_Record.TABLE_NAME);
			_Main = _Main.Replace("%%TABLE_NAME_PC%%", tableName);
			_Main = _Main.Replace("%%ID_TYPE%%", GetIdType_FromDB_ToCS(tables_Record.TABLE_NAME));

			File.WriteAllText(directory + $"{tables_Record.TABLE_NAME}_Query.cs", _Main);
		}

		private static void ColumnElaboration(Columns_Record columns_Record) {
			string dataType = GetDataType_FromDB_ToReader(columns_Record.DATA_TYPE);

			#region SelectAllField
			string selectAllField = string.Empty;
			if (columns_Record.DATA_TYPE == "varbinary") {
				selectAllField = pattern_SelectAllField_Binary;
			}
			else {
				switch (columns_Record.IS_NULLABLE) {
					case "NO":
						if (columns_Record.COMBO == null && columns_Record.EXTERNAL_TABLE_ID != null)
							selectAllField = pattern_SelectAllField_NotNullableId;
						else if (columns_Record.COMBO != null && columns_Record.EXTERNAL_TABLE_ID == null)
							selectAllField = pattern_SelectAllField_NotNullableCombo;
						else if (columns_Record.COMBO != null && columns_Record.EXTERNAL_TABLE_ID != null)
							throw new Exception();
						else
							selectAllField = pattern_SelectAllField_NotNullable;
						break;
					case "YES":
						if (columns_Record.COMBO == null && columns_Record.EXTERNAL_TABLE_ID != null)
							selectAllField = pattern_SelectAllField_NullableId;
						//else if (columns_Record.COMBO != null && columns_Record.EXTERNAL_TABLE_ID == null)
						//	selectAllField = pattern_SelectAllField_NullableCombo;
						else if (columns_Record.COMBO != null && columns_Record.EXTERNAL_TABLE_ID != null)
							throw new Exception();
						else
							selectAllField = pattern_SelectAllField_Nullable;
						break;
					default: break;
				}
			}
			selectAllField = selectAllField.Replace("%%DATA_TYPE%%", dataType);
			selectAllField = selectAllField.Replace("%%COMBO_NAME%%", columns_Record.COMBO);
			selectAllField = selectAllField.Replace("%%EXTERNAL_TABLE%%", columns_Record.EXTERNAL_TABLE_ID);
			selectAllField_List += selectAllField.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
			#endregion

			#region UpdateByKeyField
			string updateByKeyField = string.Empty;
			switch (columns_Record.COLUMN_NAME) {
				case "ID":
				case "INS_DATE":
				case "INS_TIME":
				case "INS_INFO":
					break;
				case "UPD_DATE":
					updateByKeyField = pattern_UpdateByKeyField_DefaultField;
					updateByKeyField = updateByKeyField.Replace("%%DEFAULT_DATA_TYPE%%", "DateTime.Now.Date");
					updateByKeyField_List += updateByKeyField.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
					break;
				case "UPD_TIME":
					updateByKeyField = pattern_UpdateByKeyField_DefaultField;
					updateByKeyField = updateByKeyField.Replace("%%DEFAULT_DATA_TYPE%%", "DateTime.Now.TimeOfDay");
					updateByKeyField_List += updateByKeyField.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
					break;
				case "UPD_INFO":
					updateByKeyField = pattern_UpdateByKeyField_DefaultField;
					updateByKeyField = updateByKeyField.Replace("%%DEFAULT_DATA_TYPE%%", "DateTime.Now.ToString(\"yyyy-MM-dd;HH:mm:ss.fffffff\")");
					updateByKeyField_List += updateByKeyField.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
					break;
				default:
					updateByKeyField = pattern_UpdateByKeyField_UpdateByKey;
					updateByKeyField_List += updateByKeyField.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
					break;
			}
			#endregion

			#region insertField_List
			string insertField = string.Empty;
			switch (columns_Record.COLUMN_NAME) {
				case "ID":
					break;
				case "INS_DATE":
				case "UPD_DATE":
					insertField = pattern_InsertField_DefaultField;
					insertField = insertField.Replace("%%DEFAULT_DATA_TYPE%%", "DateTime.Now.Date");
					insertField_List += insertField.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
					break;
				case "INS_TIME":
				case "UPD_TIME":
					insertField = pattern_InsertField_DefaultField;
					insertField = insertField.Replace("%%DEFAULT_DATA_TYPE%%", "DateTime.Now.TimeOfDay");
					insertField_List += insertField.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
					break;
				case "INS_INFO":
				case "UPD_INFO":
					insertField = pattern_InsertField_DefaultField;
					insertField = insertField.Replace("%%DEFAULT_DATA_TYPE%%", "DateTime.Now.ToString(\"yyyy-MM-dd;HH:mm:ss.fffffff\")");
					insertField_List += insertField.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
					break;
				default:
					switch (columns_Record.IS_NULLABLE) {
						case "NO": insertField = pattern_InsertField_Insert_NotNullable; break;
						case "YES": insertField = pattern_InsertField_Insert_Nullable; break;
						default: break;
					}
					insertField_List += insertField.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
					break;
			}
			#endregion
		}
	}
}
