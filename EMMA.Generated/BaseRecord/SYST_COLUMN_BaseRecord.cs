namespace EMMA_BE.Generated {
	public class SYST_COLUMN_BaseRecord {
		public string TABLE_NAME { get; set; }
		public string COLUMN_NAME { get; set; }
		public string DESCRIPTION { get; set; }
		public string SHORT_DESCRIPTION { get; set; }
		public string? COMBO { get; set; }

		public SYST_COLUMN_BaseRecord() {
			TABLE_NAME = string.Empty;
			COLUMN_NAME = string.Empty;
			DESCRIPTION = string.Empty;
			SHORT_DESCRIPTION = string.Empty;
			COMBO = string.Empty;
		}

		public SYST_COLUMN_BaseRecord Clone() {
			SYST_COLUMN_BaseRecord output = new() {
				TABLE_NAME = TABLE_NAME,
				COLUMN_NAME = COLUMN_NAME,
				DESCRIPTION = DESCRIPTION,
				SHORT_DESCRIPTION = SHORT_DESCRIPTION,
				COMBO = COMBO
			};
			return output;
		}
	}
}
