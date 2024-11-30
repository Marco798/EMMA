namespace Generator {
    internal class Field : Program {

        private static string directory = string.Empty;

        private static string pattern_Main = string.Empty;

        public static void Generate() {
            const string folder = @"Field\";
            directory = Consts.generatedDirectory + folder;
            string pattern = Consts.patternDirectory + folder;

            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            #region Pattern
            pattern_Main = File.ReadAllText(pattern + "Main.txt");
            #endregion

            foreach (Tables_Record tables_Record in tables_RecordList) {
                TableElaboration(tables_Record);
            }

            if (Directory.Exists(@"..\..\..\..\EMMA.Generated\Field")) Directory.Delete(@"..\..\..\..\EMMA.Generated\Field", true);
            Directory.Move(@"..\..\..\Generated\Field", @"..\..\..\..\EMMA.Generated\Field");
        }

        private static void TableElaboration(Tables_Record tables_Record) {
            string _Main = pattern_Main;

            foreach (Columns_Record columns_Record in columns_RecordList.Where(x => x.TABLE_NAME == tables_Record.TABLE_NAME)) {
                ColumnElaboration(columns_Record);
            }

            _Main = _Main.Replace("%%NAME_SPACE%%", "EMMA_BE.Generated");
            _Main = _Main.Replace("%%TABLE_NAME%%", tables_Record.TABLE_NAME);

            File.WriteAllText(directory + $"{tables_Record.TABLE_NAME}_Field.cs", _Main);
        }

        private static void ColumnElaboration(Columns_Record columns_Record) {

        }
    }
}
