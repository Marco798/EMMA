namespace EMMA_BE.Generated {
	public class SYST_COLUMN_IdRecord {
		public int ID { get; set; }
		public string TABLE_NAME { get; set; }
		public string COLUMN_NAME { get; set; }
		public string DESCRIPTION { get; set; }
		public string SHORT_DESCRIPTION { get; set; }

		public SYST_COLUMN_Record Clone() {
			SYST_COLUMN_Record output = new() {
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
