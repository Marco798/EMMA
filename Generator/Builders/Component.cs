namespace Generator
{
    internal class Component : Program {

		public static void Generate(string directory) {
			string folder = @"Component\";
			directory += folder;

			string pattern_Record_Main = File.ReadAllText(pattern + folder + "Main.txt");

			if (!Directory.Exists(directory))
				Directory.CreateDirectory(directory);

			foreach (Tables_Record tables_Record in tables_RecordList) {
				string value_Record_Main = pattern_Record_Main;

				string tableName = ToPascalCase(tables_Record.TABLE_NAME);

				value_Record_Main = value_Record_Main.Replace("%%TABLE_NAME%%", tables_Record.TABLE_NAME);

				File.WriteAllText(directory + $"{tables_Record.TABLE_NAME}.razor", value_Record_Main);
				File.WriteAllText(directory + $"{tables_Record.TABLE_NAME}.razor.css", null);
			}
		}
	}
}
