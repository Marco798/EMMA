namespace EMMA_BE.Generated {
	public class BANK_STATEMENT_DESC_PATTERN_IdRecord {
		public int ID { get; set; }
		public string PATTERN { get; set; }
		public string DESCRIPTION { get; set; }

		public BANK_STATEMENT_DESC_PATTERN_Id GetId() { return new BANK_STATEMENT_DESC_PATTERN_Id(ID); }

		public BANK_STATEMENT_DESC_PATTERN_IdRecord() { }

		public BANK_STATEMENT_DESC_PATTERN_IdRecord(BANK_STATEMENT_DESC_PATTERN_Record record) {
			ID = record.ID;
			PATTERN = record.PATTERN;
			DESCRIPTION = record.DESCRIPTION;
		}

		public BANK_STATEMENT_DESC_PATTERN_IdRecord Clone() {
			BANK_STATEMENT_DESC_PATTERN_IdRecord output = new() {
				ID = ID,
				PATTERN = PATTERN,
				DESCRIPTION = DESCRIPTION
			};
			return output;
		}
	}
}
