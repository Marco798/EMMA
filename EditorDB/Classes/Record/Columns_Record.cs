namespace EditorDB {
	public class Columns_Record {
		public string TABLE_CATALOG { get; set; }
		public string TABLE_SCHEMA { get; set; }
		public string TABLE_NAME { get; set; }
		public string COLUMN_NAME { get; set; }
		public int ORDINAL_POSITION { get; set; }
		public string? COLUMN_DEFAULT { get; set; }
		public string IS_NULLABLE { get; set; }
		public string DATA_TYPE { get; set; }
		public int? CHARACTER_MAXIMUM_LENGTH { get; set; }
		public int? CHARACTER_OCTET_LENGTH { get; set; }
		public int? NUMERIC_PRECISION { get; set; }
		public int? NUMERIC_PRECISION_RADIX { get; set; }
		public int? NUMERIC_SCALE { get; set; }
		public short? DATETIME_PRECISION { get; set; }
		public string? CHARACTER_SET_CATALOG { get; set; }
		public string? CHARACTER_SET_SCHEMA { get; set; }
		public string? CHARACTER_SET_NAME { get; set; }
		public string? COLLATION_CATALOG { get; set; }
		public string? COLLATION_SCHEMA { get; set; }
		public string? COLLATION_NAME { get; set; }
		public string? DOMAIN_CATALOG { get; set; }
		public string? DOMAIN_SCHEMA { get; set; }
		public string? DOMAIN_NAME { get; set; }

		public string DESCRIPTION { get; set; }
		public string SHORT_DESCRIPTION { get; set; }
		public string? COMBO { get; set; }

		public Columns_Record() {
			TABLE_CATALOG = string.Empty;
			TABLE_SCHEMA = string.Empty;
			TABLE_NAME = string.Empty;
			COLUMN_NAME = string.Empty;
			ORDINAL_POSITION = 0;
			IS_NULLABLE = string.Empty;
			DATA_TYPE = string.Empty;

			DESCRIPTION = string.Empty;
			SHORT_DESCRIPTION = string.Empty;
		}
	}
}
