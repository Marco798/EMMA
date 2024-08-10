namespace Generator
{
    internal class NullRecord : Program {

		public static void Generate(string directory) {
			string folder = @"NullRecord\";
			directory += folder;

			string pattern_Record_Main = File.ReadAllText(pattern + folder + "Main.txt");

			if (!Directory.Exists(directory))
				Directory.CreateDirectory(directory);

			foreach (Tables_Record tables_Record in tables_RecordList) {
				string value_Record_Main = pattern_Record_Main;

				value_Record_Main = value_Record_Main.Replace("%%NAME_SPACE%%", "EMMA_BE.Generated");
				value_Record_Main = value_Record_Main.Replace("%%TABLE_NAME%%", tables_Record.TABLE_NAME);

				string recordField_List = string.Empty;
				string privateRecordField_List = string.Empty;
				string isSetField_List = string.Empty;
				string fromRecordField_List = string.Empty;
				string[] internalFields = ["ID", "INS_DATE", "INS_TIME", "INS_INFO", "UPD_DATE", "UPD_TIME", "UPD_INFO"];
				foreach (Columns_Record columns_Record in columns_RecordList.Where(x => x.TABLE_NAME == tables_Record.TABLE_NAME)) {
					string value_Record_Field = "\t\tpublic %%DATA_TYPE%%? %%FIELD_NAME%% { get { return _%%FIELD_NAME%%; } %%ACCESS_LEVEL%%set { _%%FIELD_NAME%% = value; IsSet_%%FIELD_NAME%% = true; } }";
					string privateValue_Record_Field = "\t\tprivate %%DATA_TYPE%%? _%%FIELD_NAME%%;";
					string isSet_Field = "\t\tinternal bool IsSet_%%FIELD_NAME%% { get; private set; }";
					string fromRecord_Field = "\t\t\t%%FIELD_NAME%% = record.%%FIELD_NAME%%;";

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

					value_Record_Field = value_Record_Field.Replace("%%DATA_TYPE%%", dataType);
					value_Record_Field = value_Record_Field.Replace("%%FIELD_NAME%%", columns_Record.COLUMN_NAME);
					if (internalFields.Contains(columns_Record.COLUMN_NAME)) {
						value_Record_Field = value_Record_Field.Replace("%%ACCESS_LEVEL%%", "internal ");
					} else {
						value_Record_Field = value_Record_Field.Replace("%%ACCESS_LEVEL%%", "");
					}

					privateValue_Record_Field = privateValue_Record_Field.Replace("%%DATA_TYPE%%", dataType);
					privateValue_Record_Field = privateValue_Record_Field.Replace("%%FIELD_NAME%%", columns_Record.COLUMN_NAME);

					isSet_Field = isSet_Field.Replace("%%FIELD_NAME%%", columns_Record.COLUMN_NAME);
					fromRecord_Field = fromRecord_Field.Replace("%%FIELD_NAME%%", columns_Record.COLUMN_NAME);

					recordField_List += "\r\n" + value_Record_Field;
					privateRecordField_List += "\r\n" + privateValue_Record_Field;
					isSetField_List += "\r\n" + isSet_Field;
					fromRecordField_List += "\r\n" + fromRecord_Field;
				}

				value_Record_Main = value_Record_Main.Replace("%%RECORD_FIELD%%", recordField_List);
				value_Record_Main = value_Record_Main.Replace("%%PRIVATE_RECORD_FIELD%%", privateRecordField_List);
				value_Record_Main = value_Record_Main.Replace("%%IS_SET_FIELD%%", isSetField_List);
				value_Record_Main = value_Record_Main.Replace("%%FROM_RECORD_FIELD%%", fromRecordField_List);

				File.WriteAllText(directory + $"{tables_Record.TABLE_NAME}_NullRecord.cs", value_Record_Main);
			}
		}
	}
}
