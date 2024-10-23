namespace EMMA_BE.Generated {
	public class BANK_STATEMENT_PATTERN_BaseRecord {
		public string FIELD { get; private set; }
		public string ORIGINAL_VALUE { get; set; }
		public string PATTERN { get; set; }
		public string POSITION { get; private set; }

		public void Set_FIELD(BANK_STATEMENT_FIELD_Combo value) { FIELD = value.Value; }
		public void Set_POSITION(PATTERN_POSITION_Combo value) { POSITION = value.Value; }

		public BANK_STATEMENT_PATTERN_BaseRecord() {
			FIELD = string.Empty;
			ORIGINAL_VALUE = string.Empty;
			PATTERN = string.Empty;
			POSITION = string.Empty;
		}

		public BANK_STATEMENT_PATTERN_BaseRecord Clone() {
			BANK_STATEMENT_PATTERN_BaseRecord output = new() {
				FIELD = FIELD,
				ORIGINAL_VALUE = ORIGINAL_VALUE,
				PATTERN = PATTERN,
				POSITION = POSITION
			};
			return output;
		}
	}
}
