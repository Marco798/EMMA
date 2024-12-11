namespace Generator {
    internal class NullRecord : Program {

        private static string directory = string.Empty;

        private static string pattern_Main = string.Empty;
        private static string pattern_Field = string.Empty;
        private static string pattern_SetFieldCombo = string.Empty;
        private static string pattern_SetFieldId = string.Empty;
        private static string pattern_PrivateField = string.Empty;
        private static string pattern_IsSetField = string.Empty;
        private static string pattern_FromRecordField = string.Empty;
        private static string pattern_FromIdRecordField = string.Empty;
        private static string pattern_JsonConstructorIfIsSet = string.Empty;
        private static string pattern_JsonConstructorParam = string.Empty;

        private static string field_List = string.Empty;
        private static string setFieldCombo_List = string.Empty;
        private static string setFieldId_List = string.Empty;
        private static string privateField_List = string.Empty;
        private static string isSetField_List = string.Empty;
        private static string fromRecordField_List = string.Empty;
        private static string fromIdRecordField_List = string.Empty;
        private static string jsonConstructorParam_List = string.Empty;
        private static string jsonConstructorIfIsSet_List = string.Empty;

        public static void Generate() {
            const string folder = @"NullRecord\";
            directory = Consts.generatedDirectory + folder;
            string pattern = Consts.patternDirectory + folder;

            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            #region Pattern
            pattern_Main = File.ReadAllText(pattern + "Main.txt");

            pattern_Field = File.ReadAllText(pattern + "Field.txt");
            pattern_SetFieldCombo = File.ReadAllText(pattern + "SetFieldCombo.txt");
            pattern_SetFieldId = File.ReadAllText(pattern + "SetFieldId.txt");
            pattern_PrivateField = File.ReadAllText(pattern + "PrivateField.txt");
            pattern_IsSetField = File.ReadAllText(pattern + "IsSetField.txt");
            pattern_FromRecordField = File.ReadAllText(pattern + "FromRecordField.txt");
            pattern_FromIdRecordField = File.ReadAllText(pattern + "FromIdRecordField.txt");
            pattern_JsonConstructorParam = File.ReadAllText(pattern + "JsonConstructorParam.txt");
            pattern_JsonConstructorIfIsSet = File.ReadAllText(pattern + "JsonConstructorIfIsSet.txt");
            #endregion

            foreach (Tables_Record tables_Record in tables_RecordList) {
                TableElaboration(tables_Record);
            }

            if (Directory.Exists(@"..\..\..\..\EMMA.Generated\NullRecord")) Directory.Delete(@"..\..\..\..\EMMA.Generated\NullRecord", true);
            Directory.Move(@"..\..\..\Generated\NullRecord", @"..\..\..\..\EMMA.Generated\NullRecord");
        }

        private static void TableElaboration(Tables_Record tables_Record) {
            string _Main = pattern_Main;

            #region Sections declaration
            field_List = string.Empty;
            setFieldCombo_List = string.Empty;
            setFieldId_List = string.Empty;
            privateField_List = string.Empty;
            isSetField_List = string.Empty;
            fromRecordField_List = string.Empty;
            fromIdRecordField_List = string.Empty;
            jsonConstructorParam_List = string.Empty;
            jsonConstructorIfIsSet_List = string.Empty;
            #endregion

            foreach (Columns_Record columns_Record in columns_RecordList.Where(x => x.TABLE_NAME == tables_Record.TABLE_NAME)) {
                ColumnElaboration(columns_Record);
            }

            _Main = _Main.Replace("%%FIELD%%", field_List[..^2]);
            _Main = _Main.Replace("%%SET_FIELD_COMBO%%", string.IsNullOrWhiteSpace(setFieldCombo_List) ? string.Empty : "\r\n\r\n" + setFieldCombo_List[..^2]);
            _Main = _Main.Replace("%%SET_FIELD_ID%%", string.IsNullOrWhiteSpace(setFieldId_List) ? string.Empty : "\r\n\r\n" + setFieldId_List[..^2]);
            _Main = _Main.Replace("%%PRIVATE_FIELD%%", privateField_List[..^2]);
            _Main = _Main.Replace("%%IS_SET_FIELD%%", isSetField_List[..^2]);
            _Main = _Main.Replace("%%FROM_RECORD_FIELD%%", fromRecordField_List[..^2]);
            _Main = _Main.Replace("%%FROM_ID_RECORD_FIELD%%", fromIdRecordField_List[..^2]);
            _Main = _Main.Replace("%%JSON_CONSTRUCTOR_PARAM%%", jsonConstructorParam_List[..^3]);
            _Main = _Main.Replace("%%JSON_CONSTRUCTOR_IF_IS_SET%%", jsonConstructorIfIsSet_List[..^2]);

            _Main = _Main.Replace("%%NAME_SPACE%%", "EMMA_BE.Generated");
            _Main = _Main.Replace("%%TABLE_NAME%%", tables_Record.TABLE_NAME);

            File.WriteAllText(directory + $"{tables_Record.TABLE_NAME}_NullRecord.cs", _Main);
        }

        private static void ColumnElaboration(Columns_Record columns_Record) {
            string dataType = columns_Record.COMBO != null ? columns_Record.COMBO + "_Combo" : GetDataType_FromDB_ToCS(columns_Record.DATA_TYPE);
            string isDefaultValue = IsDefaultField(columns_Record.COLUMN_NAME) ? "internal " : "";
            string accessLevel = columns_Record.COMBO != null || columns_Record.EXTERNAL_TABLE_ID != null ? "private " : isDefaultValue;
            string lowerColumnName = columns_Record.COLUMN_NAME.ToLower();

            #region Field
            string field = pattern_Field;
            field = field.Replace("%%ACCESS_LEVEL%%", accessLevel);
            field = field.Replace("%%DATA_TYPE%%", dataType);
            field_List += field.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
            #endregion

            #region SetFieldCombo
            if (columns_Record.COMBO != null) {
                string setFieldCombo = pattern_SetFieldCombo;
                setFieldCombo = setFieldCombo.Replace("%%COMBO_NAME%%", columns_Record.COMBO);
                setFieldCombo_List += setFieldCombo.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
            }
            #endregion

            #region SetFieldId
            if (columns_Record.EXTERNAL_TABLE_ID != null) {
                string setfieldId = pattern_SetFieldId;
                setfieldId = setfieldId.Replace("%%EXTERNAL_TABLE%%", columns_Record.EXTERNAL_TABLE_ID);
                setFieldId_List += setfieldId.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
            }
            #endregion

            #region PrivateField
            string privateField = pattern_PrivateField;
            privateField = privateField.Replace("%%DATA_TYPE%%", dataType);
            privateField_List += privateField.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
            #endregion

            #region IsSetField
            string isSetField = pattern_IsSetField;
            isSetField_List += isSetField.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
            #endregion

            #region FromRecordField
            string fromRecordField = pattern_FromRecordField;
            fromRecordField_List += fromRecordField.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
            #endregion

            #region FromIdRecordField
            if (!Consts.auditFields.Contains(columns_Record.COLUMN_NAME)) {
                string fromIdRecordField = pattern_FromIdRecordField;
                fromIdRecordField_List += fromIdRecordField.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
            }
            #endregion

            #region JsonConstructorIfIsSet
            string jsonConstructorIfIsSet = pattern_JsonConstructorIfIsSet;
            jsonConstructorIfIsSet = jsonConstructorIfIsSet.Replace("%%DATA_TYPE%%", dataType);
            jsonConstructorIfIsSet = jsonConstructorIfIsSet.Replace("%%LOWER_COLUMN_NAME%%", lowerColumnName);
            jsonConstructorIfIsSet_List += jsonConstructorIfIsSet.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
            #endregion

            #region JsonConstructorParam
            string jsonConstructorParam = pattern_JsonConstructorParam;
            jsonConstructorParam = jsonConstructorParam.Replace("%%DATA_TYPE%%", dataType);
            jsonConstructorParam = jsonConstructorParam.Replace("%%LOWER_COLUMN_NAME%%", lowerColumnName);
            jsonConstructorParam_List += jsonConstructorParam.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
            #endregion
        }
    }
}
