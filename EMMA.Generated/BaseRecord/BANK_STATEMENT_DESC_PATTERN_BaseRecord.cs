namespace EMMA_BE.Generated {
	public class BANK_STATEMENT_DESC_PATTERN_BaseRecord {
		public string PATTERN { get; set; }
		public string DESCRIPTION { get; set; }

		public BANK_STATEMENT_DESC_PATTERN_BaseRecord() {
			PATTERN = string.Empty;
			DESCRIPTION = string.Empty;
		}

		public BANK_STATEMENT_DESC_PATTERN_BaseRecord Clone() {
			BANK_STATEMENT_DESC_PATTERN_BaseRecord output = new() {
				PATTERN = PATTERN,
				DESCRIPTION = DESCRIPTION
			};
			return output;
		}
	}
}
