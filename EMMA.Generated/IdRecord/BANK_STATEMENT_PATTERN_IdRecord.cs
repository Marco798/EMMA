namespace EMMA_BE.Generated {
	public class BANK_STATEMENT_PATTERN_IdRecord {
		public int ID { get; set; }
		public string FIELD { get; private set; }
		public string ORIGINAL_VALUE { get; set; }
		public string PATTERN { get; set; }
		public string POSITION { get; private set; }

		public void Set_FIELD(BANK_STATEMENT_FIELD_Combo value) { FIELD = value.Value; }
		public void Set_POSITION(PATTERN_POSITION_Combo value) { POSITION = value.Value; }

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
