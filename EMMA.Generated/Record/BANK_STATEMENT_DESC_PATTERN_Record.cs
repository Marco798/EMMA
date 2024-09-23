namespace EMMA_BE.Generated {
	public class BANK_STATEMENT_DESC_PATTERN_Record {
		public int ID { get; set; }
		public string PATTERN { get; set; }
		public string DESCRIPTION { get; set; }
		public DateTime INS_DATE { get; set; }
		public TimeSpan INS_TIME { get; set; }
		public string INS_INFO { get; set; }

		public BANK_STATEMENT_DESC_PATTERN_Id GetId() { return new BANK_STATEMENT_DESC_PATTERN_Id(ID); }

		public BANK_STATEMENT_DESC_PATTERN_Record Clone() {
			BANK_STATEMENT_DESC_PATTERN_Record output = new() {
				ID = ID,
				PATTERN = PATTERN,
				DESCRIPTION = DESCRIPTION,
				INS_DATE = INS_DATE,
				INS_TIME = INS_TIME,
				INS_INFO = INS_INFO
			};
			return output;
		}
	}
}
