namespace EMMA_BE.Generated {
	public class BANK_STATEMENT_PATTERN_IdRecord {
		public int ID { get; set; }
		public BANK_STATEMENT_FIELD_Combo FIELD { get; set; }
		public string ORIGINAL_VALUE { get; set; }
		public string PATTERN { get; set; }
		public PATTERN_POSITION_Combo POSITION { get; set; }

		public BANK_STATEMENT_PATTERN_Id GetId() { return new BANK_STATEMENT_PATTERN_Id(ID); }

		public BANK_STATEMENT_PATTERN_IdRecord() { }

		public BANK_STATEMENT_PATTERN_IdRecord(BANK_STATEMENT_PATTERN_Record record) {
			ID = record.ID;
			FIELD = record.FIELD;
			ORIGINAL_VALUE = record.ORIGINAL_VALUE;
			PATTERN = record.PATTERN;
			POSITION = record.POSITION;
		}

		public BANK_STATEMENT_PATTERN_IdRecord Clone() {
			BANK_STATEMENT_PATTERN_IdRecord output = new() {
				ID = ID,
				FIELD = FIELD,
				ORIGINAL_VALUE = ORIGINAL_VALUE,
				PATTERN = PATTERN,
				POSITION = POSITION
			};
			return output;
		}
	}
}
