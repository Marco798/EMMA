namespace Generator
{
    internal class Component : Program {

		public static void Generate(string directory) {
			string folder = @"Component\";
			directory += folder;

			string pattern_Record_Main = File.ReadAllText(pattern + folder + "Main.txt");
			string pattern_Css = File.ReadAllText(pattern + folder + "Css.txt");

			if (!Directory.Exists(directory))
				Directory.CreateDirectory(directory);

			foreach (Tables_Record tables_Record in tables_RecordList) {
				string value_Record_Main = pattern_Record_Main;

				string tableName = ToPascalCase(tables_Record.TABLE_NAME);

				value_Record_Main = value_Record_Main.Replace("%%TABLE_NAME%%", tables_Record.TABLE_NAME);

				string field_List = string.Empty;
				string edit_Form = string.Empty;

				string[] fieldsToSkip = ["ID", "INS_DATE", "INS_TIME", "INS_INFO", "UPD_DATE", "UPD_TIME", "UPD_INFO"];
				foreach (Columns_Record columns_Record in columns_RecordList.Where(x => x.TABLE_NAME == tables_Record.TABLE_NAME).OrderBy(x => x.ORDINAL_POSITION)) {
					field_List += $"\r\n					<td>@record.{columns_Record.COLUMN_NAME}</td>";

					if (!fieldsToSkip.Contains(columns_Record.COLUMN_NAME)) {
						int? length = columns_Record.CHARACTER_MAXIMUM_LENGTH == -1 ? null : columns_Record.CHARACTER_MAXIMUM_LENGTH;
						string lengthSection = length == null ? string.Empty : $"Length=\"{length}\" Width=\"{length}\" ";
						switch (columns_Record.DATA_TYPE) {
							case "varchar": edit_Form += $"\r\n			<tr><TextBox IsTable=true Value=\"@_{tables_Record.TABLE_NAME}_EditRecord.{columns_Record.COLUMN_NAME}\" Description=\"{columns_Record.COLUMN_NAME}\" {lengthSection}/></tr>"; break;
							default: edit_Form += $"\r\n			<tr><td style=\"border: none; text-align: right; display: block;\">{columns_Record.COLUMN_NAME}</td></tr>"; break;
						};
					}
				}
				value_Record_Main = value_Record_Main.Replace("%%FIELD_LIST%%", field_List);
				value_Record_Main = value_Record_Main.Replace("%%EDIT_FORM%%", edit_Form);

				File.WriteAllText(directory + $"{tables_Record.TABLE_NAME}.razor", value_Record_Main);
				File.WriteAllText(directory + $"{tables_Record.TABLE_NAME}.razor.css", pattern_Css);
			}
		}
	}
}
