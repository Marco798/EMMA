namespace EMMA_BE.Generated {
	public class BANK_MAIN_BaseRecord {
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

		public BANK_MAIN_BaseRecord() {
			REASON = string.Empty;
			DESCRIPTION = string.Empty;
			TAG1 = string.Empty;
			TAG2 = string.Empty;
			TAG3 = string.Empty;
			TAG4 = string.Empty;
		}

		public BANK_MAIN_BaseRecord Clone() {
			BANK_MAIN_BaseRecord output = new() {
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
