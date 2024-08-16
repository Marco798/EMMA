namespace EMMA_BE.Generated {
	public class BANK_MAIN_Record {
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
		public DateTime INS_DATE { get; set; }
		public TimeSpan INS_TIME { get; set; }
		public string INS_INFO { get; set; }

		public BANK_MAIN_Record Clone() {
			BANK_MAIN_Record output = new() {
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
				FLOW_INPUT_FILE_ID = FLOW_INPUT_FILE_ID,
				INS_DATE = INS_DATE,
				INS_TIME = INS_TIME,
				INS_INFO = INS_INFO
			};
			return output;
		}
	}
}
