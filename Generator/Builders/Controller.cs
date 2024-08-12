namespace Generator
{
    internal class Controller : Program {

		private static string directory = string.Empty;
		private static string pattern = string.Empty;

		private static string pattern_Main = string.Empty;

		public static void Generate() {
			string folder = @"Controller\";
			directory = generatedDirectory + folder;
			pattern = patternDirectory + folder;

			if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

			#region Pattern
			pattern_Main = File.ReadAllText(pattern + "Main.txt");
			#endregion

			foreach (Tables_Record tables_Record in tables_RecordList) {
				TableElaboration(tables_Record);
			}
		}

		private static void TableElaboration(Tables_Record tables_Record) {
			string _Main = pattern_Main;

			_Main = _Main.Replace("%%NAME_SPACE%%", "EMMA_BE.Generated.Controller");
			_Main = _Main.Replace("%%TABLE_NAME%%", tables_Record.TABLE_NAME);

			File.WriteAllText(directory + $"{tables_Record.TABLE_NAME}Controller.cs", _Main);
		}
	}
}
