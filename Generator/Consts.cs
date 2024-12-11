namespace Generator {
	public static class Consts {
		public static readonly string generatedDirectory = @"..\..\..\Generated\";
		public static readonly string patternDirectory = @"..\..\..\Patterns\";

		public static readonly string ID = "ID";
		public static readonly string[] defaultFields = ["ID", "INS_DATE", "INS_TIME", "INS_INFO", "UPD_DATE", "UPD_TIME", "UPD_INFO"];
		public static readonly string[] auditFields = ["INS_DATE", "INS_TIME", "INS_INFO", "UPD_DATE", "UPD_TIME", "UPD_INFO"];
		public static readonly string[] insFields = ["INS_DATE", "INS_TIME", "INS_INFO"];
		public static readonly string[] updFields = ["UPD_DATE", "UPD_TIME", "UPD_INFO"];

		public static readonly string[] fieldsToBeInitialized = ["varchar", "char", "varbinary"];

		public const string _YES = "YES";
		public const string _NO = "NO";

		public const string _IsNullable = "?";

		public const string _DB_DataType_varchar = "varchar";
		public const string _DB_DataType_char = "char";
		public const string _DB_DataType_varbinary = "varbinary";
		public const string _DB_DataType_int = "int";
		public const string _DB_DataType_bigint = "bigint";
		public const string _DB_DataType_decimal = "decimal";
		public const string _DB_DataType_date = "date";
		public const string _DB_DataType_time = "time";

		public const string _CS_DataType_string = "string";
		public const string _CS_DataType_byteArray = "byte[]";
		public const string _CS_DataType_int = "int";
		public const string _CS_DataType_long = "long";
		public const string _CS_DataType_decimal = "decimal";
		public const string _CS_DataType_DateTime = "DateTime";
		public const string _CS_DataType_TimeSpan = "TimeSpan";

		public const string _Reader_DataType_String = "String";
		public const string _Reader_DataType_Int32 = "Int32";
		public const string _Reader_DataType_Int64 = "Int64";
		public const string _Reader_DataType_Decimal = "Decimal";
		public const string _Reader_DataType_DateTime = "DateTime";
		public const string _Reader_DataType_TimeSpan = "TimeSpan";

		public const string _Default_DataType_stringEmpty = "string.Empty";
		public const string _Default_DataType_emptyArray = "[]";
        public const string _Default_DataType_combo = "new(string.Empty)";
    }
}
