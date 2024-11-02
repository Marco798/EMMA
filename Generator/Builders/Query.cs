using System.Reflection.PortableExecutable;

namespace Generator {
    internal class Query : Program {

        private static string directory = string.Empty;

        private static string pattern_Main = string.Empty;
        private static string pattern_ReadRecord_Binary = string.Empty;
        private static string pattern_ReadRecord_NotNullable = string.Empty;
        private static string pattern_ReadRecord_NotNullableCombo = string.Empty;
        private static string pattern_ReadRecord_NotNullableId = string.Empty;
        private static string pattern_ReadRecord_Nullable = string.Empty;
        private static string pattern_ReadRecord_NullableId = string.Empty;
        private static string pattern_ReadNullRecord_Binary = string.Empty;
        private static string pattern_ReadNullRecord_NotNullable = string.Empty;
        private static string pattern_ReadNullRecord_NotNullableCombo = string.Empty;
        private static string pattern_ReadNullRecord_NotNullableId = string.Empty;
        private static string pattern_ReadNullRecord_Nullable = string.Empty;
        private static string pattern_ReadNullRecord_NullableId = string.Empty;
        private static string pattern_CheckNullRecord_CheckNullRecord = string.Empty;
        private static string pattern_CheckNullRecord_DefaultField = string.Empty;
        private static string pattern_InsertField_Insert_Nullable = string.Empty;
        private static string pattern_InsertField_Insert_NullableString = string.Empty;
        private static string pattern_InsertField_Insert_NotNullable = string.Empty;
        private static string pattern_InsertField_DefaultField = string.Empty;

        private static string readRecordField_List = string.Empty;
        private static string readNullRecordField_List = string.Empty;
        private static string checkNullRecordField_List = string.Empty;
        private static string insertField_List = string.Empty;

        public static void Generate() {
            const string folder = @"Query\";
            directory = Consts.generatedDirectory + folder;
            string pattern = Consts.patternDirectory + folder;

            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            #region Pattern
            pattern_Main = File.ReadAllText(pattern + "Main.txt");

            pattern_ReadRecord_Binary = File.ReadAllText(pattern + @"ReadRecord\Binary.txt");
            pattern_ReadRecord_NotNullable = File.ReadAllText(pattern + @"ReadRecord\NotNullable.txt");
            pattern_ReadRecord_NotNullableCombo = File.ReadAllText(pattern + @"ReadRecord\NotNullableCombo.txt");
            pattern_ReadRecord_NotNullableId = File.ReadAllText(pattern + @"ReadRecord\NotNullableId.txt");
            pattern_ReadRecord_Nullable = File.ReadAllText(pattern + @"ReadRecord\Nullable.txt");
            pattern_ReadRecord_NullableId = File.ReadAllText(pattern + @"ReadRecord\NullableId.txt");

            pattern_ReadNullRecord_Binary = File.ReadAllText(pattern + @"ReadNullRecord\Binary.txt");
            pattern_ReadNullRecord_NotNullable = File.ReadAllText(pattern + @"ReadNullRecord\NotNullable.txt");
            pattern_ReadNullRecord_NotNullableCombo = File.ReadAllText(pattern + @"ReadNullRecord\NotNullableCombo.txt");
            pattern_ReadNullRecord_NotNullableId = File.ReadAllText(pattern + @"ReadNullRecord\NotNullableId.txt");
            pattern_ReadNullRecord_Nullable = File.ReadAllText(pattern + @"ReadNullRecord\Nullable.txt");
            pattern_ReadNullRecord_NullableId = File.ReadAllText(pattern + @"ReadNullRecord\NullableId.txt");

            pattern_CheckNullRecord_CheckNullRecord = File.ReadAllText(pattern + @"CheckNullRecord\CheckNullRecord.txt");
            pattern_CheckNullRecord_DefaultField = File.ReadAllText(pattern + @"CheckNullRecord\DefaultField.txt");

            pattern_InsertField_Insert_Nullable = File.ReadAllText(pattern + @"InsertField\Insert_Nullable.txt");
            pattern_InsertField_Insert_NullableString = File.ReadAllText(pattern + @"InsertField\Insert_NullableString.txt");
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
            readRecordField_List = string.Empty;
            readNullRecordField_List = string.Empty;
            checkNullRecordField_List = string.Empty;
            insertField_List = string.Empty;
            #endregion

            foreach (Columns_Record columns_Record in columns_RecordList.Where(x => x.TABLE_NAME == tables_Record.TABLE_NAME)) {
                ColumnElaboration(columns_Record);
            }

            _Main = _Main.Replace("%%READ_RECORD%%", readRecordField_List[..^2]);
            _Main = _Main.Replace("%%READ_NULL_RECORD%%", readNullRecordField_List[..^2]);
            _Main = _Main.Replace("%%CHECK_NULL_RECORD%%", checkNullRecordField_List[..^2]);
            _Main = _Main.Replace("%%INSERT_FIELD%%", insertField_List[..^2]);

            _Main = _Main.Replace("%%NAME_SPACE%%", "EMMA_BE.Generated");
            _Main = _Main.Replace("%%TABLE_NAME%%", tables_Record.TABLE_NAME);
            _Main = _Main.Replace("%%TABLE_NAME_PC%%", tableName);
            _Main = _Main.Replace("%%ID_TYPE%%", GetIdType_FromDB_ToCS(tables_Record.TABLE_NAME));

            File.WriteAllText(directory + $"{tables_Record.TABLE_NAME}_Query.cs", _Main);
        }

        private static void ColumnElaboration(Columns_Record columns_Record) {
            string dataType = GetDataType_FromDB_ToReader(columns_Record.DATA_TYPE);
            string csDataType = GetDataType_FromDB_ToCS(columns_Record.DATA_TYPE);

            #region ReadRecordField
            string readRecordField = string.Empty;
            if (columns_Record.DATA_TYPE == "varbinary") {
                readRecordField = pattern_ReadRecord_Binary;
            }
            else {
                switch (columns_Record.IS_NULLABLE) {
                    case "NO":
                        if (columns_Record.COMBO == null && columns_Record.EXTERNAL_TABLE_ID != null)
                            readRecordField = pattern_ReadRecord_NotNullableId;
                        else if (columns_Record.COMBO != null && columns_Record.EXTERNAL_TABLE_ID == null)
                            readRecordField = pattern_ReadRecord_NotNullableCombo;
                        else if (columns_Record.COMBO != null && columns_Record.EXTERNAL_TABLE_ID != null)
                            throw new Exception();
                        else
                            readRecordField = pattern_ReadRecord_NotNullable;
                        break;
                    case "YES":
                        if (columns_Record.COMBO == null && columns_Record.EXTERNAL_TABLE_ID != null)
                            readRecordField = pattern_ReadRecord_NullableId;
                        //else if (columns_Record.COMBO != null && columns_Record.EXTERNAL_TABLE_ID == null)
                        //	selectAllField = pattern_SelectAllField_NullableCombo;
                        else if (columns_Record.COMBO != null && columns_Record.EXTERNAL_TABLE_ID != null)
                            throw new Exception();
                        else
                            readRecordField = pattern_ReadRecord_Nullable;
                        break;
                    default: break;
                }
            }
            readRecordField = readRecordField.Replace("%%DATA_TYPE%%", dataType);
            readRecordField = readRecordField.Replace("%%COMBO_NAME%%", columns_Record.COMBO);
            readRecordField = readRecordField.Replace("%%EXTERNAL_TABLE%%", columns_Record.EXTERNAL_TABLE_ID);
            readRecordField_List += readRecordField.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
            #endregion

            #region ReadNullRecordField
            string readNullRecordField = string.Empty;
            if (columns_Record.DATA_TYPE == "varbinary") {
                readNullRecordField = pattern_ReadNullRecord_Binary;
            }
            else {
                switch (columns_Record.IS_NULLABLE) {
                    case "NO":
                        if (columns_Record.COMBO == null && columns_Record.EXTERNAL_TABLE_ID != null)
                            readNullRecordField = pattern_ReadNullRecord_NotNullableId;
                        else if (columns_Record.COMBO != null && columns_Record.EXTERNAL_TABLE_ID == null)
                            readNullRecordField = pattern_ReadNullRecord_NotNullableCombo;
                        else if (columns_Record.COMBO != null && columns_Record.EXTERNAL_TABLE_ID != null)
                            throw new Exception();
                        else
                            readNullRecordField = pattern_ReadNullRecord_NotNullable;
                        break;
                    case "YES":
                        if (columns_Record.COMBO == null && columns_Record.EXTERNAL_TABLE_ID != null)
                            readNullRecordField = pattern_ReadNullRecord_NullableId;
                        //else if (columns_Record.COMBO != null && columns_Record.EXTERNAL_TABLE_ID == null)
                        //	selectAllField = pattern_SelectAllField_NullableCombo;
                        else if (columns_Record.COMBO != null && columns_Record.EXTERNAL_TABLE_ID != null)
                            throw new Exception();
                        else
                            readNullRecordField = pattern_ReadNullRecord_Nullable;
                        break;
                    default: break;
                }
            }
            readNullRecordField = readNullRecordField.Replace("%%DATA_TYPE%%", dataType);
            readNullRecordField = readNullRecordField.Replace("%%COMBO_NAME%%", columns_Record.COMBO);
            readNullRecordField = readNullRecordField.Replace("%%EXTERNAL_TABLE%%", columns_Record.EXTERNAL_TABLE_ID);
            readNullRecordField_List += readNullRecordField.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
            #endregion

            #region CheckNullRecordField
            string checkNullRecordField = string.Empty;
            switch (columns_Record.COLUMN_NAME) {
                case "ID":
                case "INS_DATE":
                case "INS_TIME":
                case "INS_INFO":
                    break;
                case "UPD_DATE":
                    checkNullRecordField = pattern_CheckNullRecord_DefaultField;
                    checkNullRecordField = checkNullRecordField.Replace("%%DEFAULT_DATA_TYPE%%", "DateTime.Now.Date");
                    checkNullRecordField_List += checkNullRecordField.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
                    break;
                case "UPD_TIME":
                    checkNullRecordField = pattern_CheckNullRecord_DefaultField;
                    checkNullRecordField = checkNullRecordField.Replace("%%DEFAULT_DATA_TYPE%%", "DateTime.Now.TimeOfDay");
                    checkNullRecordField_List += checkNullRecordField.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
                    break;
                case "UPD_INFO":
                    checkNullRecordField = pattern_CheckNullRecord_DefaultField;
                    checkNullRecordField = checkNullRecordField.Replace("%%DEFAULT_DATA_TYPE%%", "DateTime.Now.ToString(\"yyyy-MM-dd;HH:mm:ss.fffffff\")");
                    checkNullRecordField_List += checkNullRecordField.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
                    break;
                default:
                    checkNullRecordField = pattern_CheckNullRecord_CheckNullRecord;
                    checkNullRecordField_List += checkNullRecordField.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
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
                        case "YES":
                            if (csDataType == Consts._CS_DataType_string)
                                insertField = pattern_InsertField_Insert_NullableString;
                            else
                                insertField = pattern_InsertField_Insert_Nullable;
                            break;
                        default: break;
                    }
                    insertField_List += insertField.Replace("%%COLUMN_NAME%%", columns_Record.COLUMN_NAME) + $"\r\n";
                    break;
            }
            #endregion
        }
    }
}
