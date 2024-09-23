namespace EMMA_BE.Generated {
	public class BANK_STATEMENT_Record {
		public int ID { get; set; }
		public DateTime OPERATION_DATE { get; set; }
		public DateTime VALUE_DATE { get; set; }
		public string REASON { get; set; }
		public string DESCRIPTION { get; set; }
		public decimal? OUTCOME { get; set; }
		public decimal? INCOME { get; set; }
		public string TAG1 { get; private set; }
		public string TAG2 { get; set; }
		public string TAG3 { get; set; }
		public string TAG4 { get; set; }
		public int ID_FILE_INPUT { get; set; }
		public int? ID_BANK_STATEMENT_DESC_PATTERN { get; set; }
		public DateTime INS_DATE { get; set; }
		public TimeSpan INS_TIME { get; set; }
		public string INS_INFO { get; set; }
		public DateTime UPD_DATE { get; set; }
		public TimeSpan UPD_TIME { get; set; }
		public string UPD_INFO { get; set; }

		public void Set_TAG1(BALANCE_DIRECTION_Combo value) { TAG1 = value.Value; }

		public BANK_STATEMENT_Id GetId() { return new BANK_STATEMENT_Id(ID); }

		public BANK_STATEMENT_Record Clone() {
			BANK_STATEMENT_Record output = new() {
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
				ID_FILE_INPUT = ID_FILE_INPUT,
				ID_BANK_STATEMENT_DESC_PATTERN = ID_BANK_STATEMENT_DESC_PATTERN,
				INS_DATE = INS_DATE,
				INS_TIME = INS_TIME,
				INS_INFO = INS_INFO,
				UPD_DATE = UPD_DATE,
				UPD_TIME = UPD_TIME,
				UPD_INFO = UPD_INFO
			};
			return output;
		}
	}
}
