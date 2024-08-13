namespace EMMA_BE.Generated {
	public class SYST_TABLE_BaseRecord {
		public string TABLE_NAME { get; set; }
		public string DESCRIPTION { get; set; }
		public string SHORT_DESCRIPTION { get; set; }

		public SYST_TABLE_Record Clone() {
			SYST_TABLE_Record output = new() {
				TABLE_NAME = TABLE_NAME,
				DESCRIPTION = DESCRIPTION,
				SHORT_DESCRIPTION = SHORT_DESCRIPTION
			};
			return output;
		}
	}
}
