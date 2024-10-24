namespace Generator {
	internal class Field : Program {

		private static string directory = string.Empty;

		private static string pattern_Main = string.Empty;
		private static string pattern_ValueField = string.Empty;
        private static string pattern_GetValueField = string.Empty;

        private static string valueField_List = string.Empty;
        private static string getValueField_List = string.Empty;

        public static void Generate() {
			const string folder = @"Field\";
			directory = Consts.generatedDirectory + folder;
			string pattern = Consts.patternDirectory + folder;

			if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

			#region Pattern
			pattern_Main = File.ReadAllText(pattern + "Main.txt");

			pattern_ValueField = File.ReadAllText(pattern + "ValueField.txt");
            pattern_GetValueField = File.ReadAllText(pattern + "GetValueField.txt");
            #endregion

            foreach (Tables_Record tables_Record in tables_RecordList) {
                TableElaboration(tables_Record);
            }

            if (Directory.Exists(@"..\..\..\..\EMMA.Generated\Field")) Directory.Delete(@"..\..\..\..\EMMA.Generated\Field", true);
			Directory.Move(@"..\..\..\Generated\Field", @"..\..\..\..\EMMA.Generated\Field");
		}

		private static void TableElaboration(Tables_Record tables_Record) {
			string _Main = pattern_Main;

			#region Sections declaration
			valueField_List = string.Empty;
            getValueField_List = string.Empty;
            #endregion

            foreach (Columns_Record columns_Record in columns_RecordList.Where(x => x.TABLE_NAME == tables_Record.TABLE_NAME)) {
                ColumnElaboration(columns_Record);
            }

            _Main = _Main.Replace("%%VALUE_FIELD%%", valueField_List[..^2]);
            _Main = _Main.Replace("%%GET_VALUE_FIELD%%", getValueField_List[..^3]);

            _Main = _Main.Replace("%%NAME_SPACE%%", "EMMA_BE.Generated");
            _Main = _Main.Replace("%%TABLE_NAME%%", tables_Record.TABLE_NAME);

            File.WriteAllText(directory + $"{tables_Record.TABLE_NAME}_Field.cs", _Main);
        }

        private static void ColumnElaboration(Columns_Record columns_Record) {
            #region GetField
            string valueField = pattern_ValueField;
			valueField_List += valueField.Replace("%%FIELD_VALUE_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
            #endregion

            #region GetValueField
            string getValueField = pattern_GetValueField;
            getValueField_List += getValueField.Replace("%%FIELD_VALUE_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
            #endregion
        }
    }
}
