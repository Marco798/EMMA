namespace EMMA_BE.Generated {
	public class SYST_COLUMN_IdRecord {
		public int ID { get; set; }
		public string TABLE_NAME { get; set; }
		public string COLUMN_NAME { get; set; }
		public string DESCRIPTION { get; set; }
		public string SHORT_DESCRIPTION { get; set; }

		public SYST_COLUMN_IdRecord() { }

		public SYST_COLUMN_IdRecord(SYST_COLUMN_Record record) {
			ID = record.ID;
			TABLE_NAME = record.TABLE_NAME;
			COLUMN_NAME = record.COLUMN_NAME;
			DESCRIPTION = record.DESCRIPTION;
			SHORT_DESCRIPTION = record.SHORT_DESCRIPTION;
		}

		public SYST_COLUMN_IdRecord Clone() {
			SYST_COLUMN_IdRecord output = new() {
				ID = ID,
				TABLE_NAME = TABLE_NAME,
				COLUMN_NAME = COLUMN_NAME,
				DESCRIPTION = DESCRIPTION,
				SHORT_DESCRIPTION = SHORT_DESCRIPTION
			};
			return output;
		}
	}
}
