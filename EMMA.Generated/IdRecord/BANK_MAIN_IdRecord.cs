namespace EMMA_BE.Generated {
	public class BANK_MAIN_IdRecord {
		public long ID { get; set; }
		public DateTime OPERATION_DATE { get; set; }
		public DateTime VALUE_DATE { get; set; }
		public string REASON { get; set; }
		public string DESCRIPTION { get; set; }
		public decimal? OUTCOME { get; set; }
		public decimal? INCOME { get; set; }
		public string TAG1 { get; set; }
		public string TAG2 { get; set; }
		public string TAG3 { get; set; }
		public string TAG4 { get; set; }
		public long FLOW_INPUT_FILE_ID { get; set; }

		public BANK_MAIN_IdRecord() { }

		public BANK_MAIN_IdRecord(BANK_MAIN_Record record) {
			ID = record.ID;
			OPERATION_DATE = record.OPERATION_DATE;
			VALUE_DATE = record.VALUE_DATE;
			REASON = record.REASON;
			DESCRIPTION = record.DESCRIPTION;
			OUTCOME = record.OUTCOME;
			INCOME = record.INCOME;
			TAG1 = record.TAG1;
			TAG2 = record.TAG2;
			TAG3 = record.TAG3;
			TAG4 = record.TAG4;
			FLOW_INPUT_FILE_ID = record.FLOW_INPUT_FILE_ID;
		}

		public BANK_MAIN_IdRecord Clone() {
			BANK_MAIN_IdRecord output = new() {
				ID = ID,
				OPERATION_DATE = OPERATION_DATE,
				VALUE_DATE = VALUE_DATE,
				REASON = REASON,
				DESCRIPTION = DESCRIPTION,
				OUTCOME = OUTCOME,
				INCOME = INCOME,
				TAG1 = TAG1,
				TAG2 = TAG2,
				TAG3 = TAG3,
				TAG4 = TAG4,
				FLOW_INPUT_FILE_ID = FLOW_INPUT_FILE_ID
			};
			return output;
		}
	}
}
