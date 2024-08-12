using System.Reflection.PortableExecutable;

namespace Generator {
	internal class Query : Program {

		private static string directory = string.Empty;
		private static string pattern = string.Empty;

		public static void Generate() {
			string folder = @"Query\";
			directory = generatedDirectory + folder;
			pattern = patternDirectory + folder;

			string pattern_Main = File.ReadAllText(pattern + "Main.txt");

			if (!Directory.Exists(directory))
				Directory.CreateDirectory(directory);

			foreach (Tables_Record tables_Record in tables_RecordList) {
				string value_Record_Main = pattern_Main;

				string tableName = ToPascalCase(tables_Record.TABLE_NAME);

				value_Record_Main = value_Record_Main.Replace("%%NAME_SPACE%%", "EMMA_BE.Generated");
				value_Record_Main = value_Record_Main.Replace("%%TABLE_NAME%%", tables_Record.TABLE_NAME);
				value_Record_Main = value_Record_Main.Replace("%%TABLE_NAME_PC%%", tableName);

				string idType = columns_RecordList.First(x => x.TABLE_NAME == tables_Record.TABLE_NAME && x.COLUMN_NAME == "ID").DATA_TYPE switch {
					"int" => "int",
					"bigint" => "long",
					_ => throw new Exception(),
				};
				value_Record_Main = value_Record_Main.Replace("%%ID_TYPE%%", idType);

				string recordField_List = string.Empty;
				string updateByKeyField_List = string.Empty;
				string insertField_List = string.Empty;

				foreach (Columns_Record columns_Record in columns_RecordList.Where(x => x.TABLE_NAME == tables_Record.TABLE_NAME)) {
					#region recordField_List
					string value_Record_Field = string.Empty;
					if (columns_Record.DATA_TYPE == "varbinary") {
						value_Record_Field += "						record.%%FIELD_NAME%% = new byte[reader.GetBytes(i, 0, null, 0, 0)];";
						value_Record_Field += "\r\n						reader.GetBytes(i++, 0, record.%%FIELD_NAME%%, 0, record.%%FIELD_NAME%%.Length);";
					}
					else {
						value_Record_Field += "						record.%%FIELD_NAME%% = %%GET_FIELD%%;";

						string dataType = string.Empty;
						dataType = columns_Record.DATA_TYPE switch {
							"varchar" => "String",
							"int" => "Int32",
							"bigint" => "Int64",
							"date" => "DateTime",
							"time" => "TimeSpan",
							_ => throw new Exception(),
						};

						string getField = string.Empty;
						switch (columns_Record.IS_NULLABLE) {
							case "NO":
								getField = $@"reader.Get{dataType}(i++)";
								break;
							case "YES":
								getField = $@"reader.IsDBNull(i) ? null : reader.Get{dataType}(i); i++";
								break;
							default: break;
						}
						value_Record_Field = value_Record_Field.Replace("%%GET_FIELD%%", getField);
					}

					value_Record_Field = value_Record_Field.Replace("%%FIELD_NAME%%", columns_Record.COLUMN_NAME);
					recordField_List += "\r\n" + value_Record_Field;
					#endregion

					#region updateByKeyField_List
					switch (columns_Record.COLUMN_NAME) {
						case "ID":
						case "INS_DATE":
						case "INS_TIME":
						case "INS_INFO":
							break;
						case "UPD_DATE":
							updateByKeyField_List += $"\r\n				query.Append(\"UPD_DATE = @UPD_DATE, \");";
							updateByKeyField_List += $"\r\n				parameters.Add(new SqlParameter(\"@UPD_DATE\", DateTime.Now.Date));\r\n";
							break;
						case "UPD_TIME":
							updateByKeyField_List += $"\r\n				query.Append(\"UPD_TIME = @UPD_TIME, \");";
							updateByKeyField_List += $"\r\n				parameters.Add(new SqlParameter(\"@UPD_TIME\", DateTime.Now.TimeOfDay));\r\n";
							break;
						case "UPD_INFO":
							updateByKeyField_List += $"\r\n				query.Append(\"UPD_INFO = @UPD_INFO, \");";
							updateByKeyField_List += $"\r\n				parameters.Add(new SqlParameter(\"@UPD_INFO\", DateTime.Now.ToString(\"yyyy-MM-dd;HH:mm:ss\")));\r\n";
							break;
						default:
							string updateByKey_Field = string.Empty;

							updateByKey_Field += "				if (record.IsSet_%%FIELD_NAME%%) {\r\n";
							updateByKey_Field += "					query.Append(\"%%FIELD_NAME%% = @%%FIELD_NAME%%, \");\r\n";
							updateByKey_Field += "					parameters.Add(new SqlParameter(\"@%%FIELD_NAME%%\", record.%%FIELD_NAME%%));\r\n";
							updateByKey_Field += "				}\r\n";

							updateByKey_Field = updateByKey_Field.Replace("%%FIELD_NAME%%", columns_Record.COLUMN_NAME);
							updateByKeyField_List += "\r\n" + updateByKey_Field;
							break;
					}
					#endregion

					#region insertField_List
					switch (columns_Record.COLUMN_NAME) {
						case "ID":
							break;
						case "INS_DATE":
							insertField_List += $"\r\n				query.Append(\"@INS_DATE, \");";
							insertField_List += $"\r\n				parameters.Add(new SqlParameter(\"@INS_DATE\", DateTime.Now.Date));\r\n";
							break;
						case "INS_TIME":
							insertField_List += $"\r\n				query.Append(\"@INS_TIME, \");";
							insertField_List += $"\r\n				parameters.Add(new SqlParameter(\"@INS_TIME\", DateTime.Now.TimeOfDay));\r\n";
							break;
						case "INS_INFO":
							insertField_List += $"\r\n				query.Append(\"@INS_INFO, \");";
							insertField_List += $"\r\n				parameters.Add(new SqlParameter(\"@INS_INFO\", DateTime.Now.ToString(\"yyyy-MM-dd;HH:mm:ss\")));\r\n";
							break;
						case "UPD_DATE":
							insertField_List += $"\r\n				query.Append(\"@UPD_DATE, \");";
							insertField_List += $"\r\n				parameters.Add(new SqlParameter(\"@UPD_DATE\", DateTime.Now.Date));\r\n";
							break;
						case "UPD_TIME":
							insertField_List += $"\r\n				query.Append(\"@UPD_TIME, \");";
							insertField_List += $"\r\n				parameters.Add(new SqlParameter(\"@UPD_TIME\", DateTime.Now.TimeOfDay));\r\n";
							break;
						case "UPD_INFO":
							insertField_List += $"\r\n				query.Append(\"@UPD_INFO, \");";
							insertField_List += $"\r\n				parameters.Add(new SqlParameter(\"@UPD_INFO\", DateTime.Now.ToString(\"yyyy-MM-dd;HH:mm:ss\")));\r\n";
							break;
						default:
							string insert_Field = string.Empty;

							insert_Field += "				query.Append(\"@%%FIELD_NAME%%, \");\r\n";
							insert_Field += "				parameters.Add(new SqlParameter(\"@%%FIELD_NAME%%\", record.%%FIELD_NAME%%));\r\n";

							insert_Field = insert_Field.Replace("%%FIELD_NAME%%", columns_Record.COLUMN_NAME);
							insertField_List += "\r\n" + insert_Field;
							break;
					}
					#endregion
				}

				value_Record_Main = value_Record_Main.Replace("%%SELECT_ALL_FIELDS%%", recordField_List);
				value_Record_Main = value_Record_Main.Replace("%%UPDATE_BY_KEY_FIELDS%%", updateByKeyField_List);
				value_Record_Main = value_Record_Main.Replace("%%INSERT_FIELDS%%", insertField_List);

				File.WriteAllText(directory + $"{tables_Record.TABLE_NAME}_Query.cs", value_Record_Main);
			}
		}
	}
}
