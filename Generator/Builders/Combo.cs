namespace Generator {
	internal class Combo : Program {

		private static string directory = string.Empty;

		private static string pattern_Main = string.Empty;
		private static string pattern_ValueField = string.Empty;
		private static string pattern_GetItemField = string.Empty;
        private static string pattern_GetValueField = string.Empty;
        private static string pattern_GetNameField = string.Empty;

        private static string valueField_List = string.Empty;
        private static string getItemField_List = string.Empty;
        private static string getValueField_List = string.Empty;
        private static string getNameField_List = string.Empty;

        public static void Generate() {
			const string folder = @"Combo\";
			directory = Consts.generatedDirectory + folder;
			string pattern = Consts.patternDirectory + folder;

			if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

			#region Pattern
			pattern_Main = File.ReadAllText(pattern + "Main.txt");

			pattern_ValueField = File.ReadAllText(pattern + "ValueField.txt");
            pattern_GetItemField = File.ReadAllText(pattern + "GetItemField.txt");
            pattern_GetValueField = File.ReadAllText(pattern + "GetValueField.txt");
            pattern_GetNameField = File.ReadAllText(pattern + "GetNameField.txt");
            #endregion

            foreach (Combo_Record combo_record in combo_RecordList) {
				ComboElaboration(combo_record);
			}

			if (Directory.Exists(@"..\..\..\..\EMMA.Generated\Combo")) Directory.Delete(@"..\..\..\..\EMMA.Generated\Combo", true);
			Directory.Move(@"..\..\..\Generated\Combo", @"..\..\..\..\EMMA.Generated\Combo");
		}

		private static void ComboElaboration(Combo_Record combo_record) {
			string _Main = pattern_Main;

			#region Sections declaration
			valueField_List = string.Empty;
            getItemField_List = string.Empty;
            getValueField_List = string.Empty;
            getNameField_List = string.Empty;
            #endregion

            foreach (ComboValues_Record comboValues_record in comboValues_RecordList.Where(x => x.COMBO == combo_record.NAME)) {
				ComboValueElaboration(comboValues_record);
			}

			_Main = _Main.Replace("%%VALUE_FIELD%%", valueField_List[..^4]);
            _Main = _Main.Replace("%%GET_ITEM_FIELD%%", getItemField_List[..^3]);
            _Main = _Main.Replace("%%GET_VALUE_FIELD%%", getValueField_List[..^3]);
            _Main = _Main.Replace("%%GET_NAME_FIELD%%", getNameField_List[..^2]);

            _Main = _Main.Replace("%%NAME_SPACE%%", "EMMA_BE.Generated");
			_Main = _Main.Replace("%%COMBO_NAME%%", combo_record.NAME);

			File.WriteAllText(directory + $"{combo_record.NAME}_Combo.cs", _Main);
		}

		private static void ComboValueElaboration(ComboValues_Record comboValue_record) {
			#region GetField
			string valueField = pattern_ValueField;
			valueField = valueField.Replace("%%COMBO_VALUE_VALUE%%", comboValue_record.VALUE);
			valueField_List += valueField.Replace("%%COMBO_VALUE_NAME%%", comboValue_record.NAME) + $"\r\n";
            #endregion

            #region GetItemField
            string getItemField = pattern_GetItemField;
            getItemField_List += getItemField.Replace("%%COMBO_VALUE_NAME%%", comboValue_record.NAME) + $"\r\n";
            #endregion

            #region GetValueField
            string getValueField = pattern_GetValueField;
            getValueField_List += getValueField.Replace("%%COMBO_VALUE_NAME%%", comboValue_record.NAME) + $"\r\n";
            #endregion

            #region GetNameField
            string getNameField = pattern_GetNameField;
            getNameField = getNameField.Replace("%%COMBO_VALUE_VALUE%%", comboValue_record.VALUE);
            getNameField_List += getNameField.Replace("%%COMBO_VALUE_NAME%%", comboValue_record.NAME) + $"\r\n";
            #endregion
        }
    }
}
