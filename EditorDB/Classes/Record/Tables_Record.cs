namespace EditorDB {
	public class Tables_Record {
		public string TABLE_CATALOG { get; set; }
		public string TABLE_SCHEMA { get; set; }
		public string TABLE_NAME { get; set; }
		public string TABLE_TYPE { get; set; }

		public string DESCRIPTION { get; set; }
		public string SHORT_DESCRIPTION { get; set; }

		public Tables_Record() {
			TABLE_CATALOG = string.Empty;
			TABLE_SCHEMA = string.Empty;
			TABLE_NAME = string.Empty;
			TABLE_TYPE = string.Empty;

			DESCRIPTION = string.Empty;
			SHORT_DESCRIPTION = string.Empty;
		}

		public Tables_Record Clone() {
			return new Tables_Record() {
				TABLE_CATALOG = TABLE_CATALOG,
				TABLE_SCHEMA = TABLE_SCHEMA,
				TABLE_NAME = TABLE_NAME,
				TABLE_TYPE = TABLE_TYPE,
				DESCRIPTION = DESCRIPTION,
				SHORT_DESCRIPTION = SHORT_DESCRIPTION
			};
		}
	}
}
