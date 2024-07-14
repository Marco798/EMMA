namespace EditorDB.Classes.BusinessValues {
	public static class BV_DataType {

		public class Type(string name, string value) {
			public string Name { get; set; } = name;
			public string Value { get; set; } = value;
		}

		public static class Category {
			public const string String = "string";
			public const string Integer = "integer";
			public const string Decimal = "decimal";
			public const string Binary = "binary";
			public const string Boolean = "boolean";
			public const string DateTime = "datetime";

			public static List<Type> GetValues() {
				return [
					new Type("String", String),
					new Type("Integer", Integer),
					new Type("Decimal", Decimal),
					new Type("Binary", Binary),
					new Type("Boolean", Boolean),
					new Type("DateTime", DateTime)
				];
			}
		}

		public static class String {
			public const string Varchar = "varchar";
			public const string Nvarchar = "nvarchar";
			public const string Char = "char";
			public const string Nchar = "nchar";

			public static List<Type> GetValues() {
				return [
					new Type("Varchar", Varchar),
					new Type("Nvarchar", Nvarchar),
					new Type("Char", Char),
					new Type("Nchar", Nchar)
				];
			}
		}

		public static class Integer {
			public const string Int = "int";
			public const string BigInt = "bigint";
			public const string SmallInt = "smallint";

			public static List<Type> GetValues() {
				return [
					new Type("Int", Int),
					new Type("BigInt", BigInt),
					new Type("SmallInt", SmallInt)
				];
			}
		}

		public static class Decimal_ {
			public const string Decimal = "decimal";
			public const string Float = "float";

			public static List<Type> GetValues() {
				return [
					new Type("Decimal", Decimal),
					new Type("Float", Float)
				];
			}
		}

		public static class Binary_ {
			public const string Binary = "binary";
			public const string VarBinary = "varbinary";

			public static List<Type> GetValues() {
				return [
					new Type("Binary", Binary),
					new Type("VarBinary", VarBinary)
				];
			}
		}

		public static class Boolean_ {
			public const string Boolean = "bit";

			public static List<Type> GetValues() {
				return [
					new Type("Boolean", Boolean)
				];
			}
		}

		public static class DateTime_ {
			public const string Date = "date";
			public const string DateTime = "datetime";
			public const string DateTime2 = "datetime2";
			public const string DateTimeOffset = "datetimeoffset";
			public const string Time = "time";
			public const string TimeStamp = "timestamp";

			public static List<Type> GetValues() {
				return [
					new Type("Date", Date),
					new Type("DateTime2", DateTime2),
					new Type("DateTimeOffset", DateTimeOffset),
					new Type("Time", Time)
				];
			}
		}
	}
}
