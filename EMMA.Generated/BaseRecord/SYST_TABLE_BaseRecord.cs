namespace EMMA_BE.Generated {
	public class SYST_TABLE_BaseRecord {
		public string TABLE_NAME { get; set; }
		public string DESCRIPTION { get; set; }
		public string SHORT_DESCRIPTION { get; set; }

		public SYST_TABLE_BaseRecord() {
			TABLE_NAME = string.Empty;
			DESCRIPTION = string.Empty;
			SHORT_DESCRIPTION = string.Empty;
		}

		public SYST_TABLE_BaseRecord Clone() {
			SYST_TABLE_BaseRecord output = new() {
				TABLE_NAME = TABLE_NAME,
				DESCRIPTION = DESCRIPTION,
				SHORT_DESCRIPTION = SHORT_DESCRIPTION
			};
			return output;
		}
	}
}