namespace EMMA_BE.Generated {
	public class BANK_STATEMENT_IdRecord {
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

		public void Set_TAG1(BALANCE_DIRECTION_Combo value) { TAG1 = value.Value; }

		public BANK_STATEMENT_Id GetId() { return new BANK_STATEMENT_Id(ID); }

		public BANK_STATEMENT_IdRecord() { }

		public BANK_STATEMENT_IdRecord(BANK_STATEMENT_Record record) {
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
			ID_FILE_INPUT = record.ID_FILE_INPUT;
			ID_BANK_STATEMENT_DESC_PATTERN = record.ID_BANK_STATEMENT_DESC_PATTERN;
		}

		public BANK_STATEMENT_IdRecord Clone() {
			BANK_STATEMENT_IdRecord output = new() {
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
				ID_BANK_STATEMENT_DESC_PATTERN = ID_BANK_STATEMENT_DESC_PATTERN
			};
			return output;
		}
	}
}
