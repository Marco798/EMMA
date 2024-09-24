namespace EMMA_BE.Generated {
	public class BANK_STATEMENT_BaseRecord {
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
		public int ID_FILE_INPUT { get; private set; }
		public int? ID_BANK_STATEMENT_DESC_PATTERN { get; private set; }

		public void Set_TAG1(BALANCE_DIRECTION_Combo value) { TAG1 = value.Value; }

		public void Set_ID_FILE_INPUT(FILE_INPUT_Id value) { ID_FILE_INPUT = value.Value; }
		public void Set_ID_BANK_STATEMENT_DESC_PATTERN(BANK_STATEMENT_DESC_PATTERN_Id value) { ID_BANK_STATEMENT_DESC_PATTERN = value.Value; }

		public BANK_STATEMENT_BaseRecord() {
			REASON = string.Empty;
			DESCRIPTION = string.Empty;
			TAG1 = string.Empty;
			TAG2 = string.Empty;
			TAG3 = string.Empty;
			TAG4 = string.Empty;
		}

		public BANK_STATEMENT_BaseRecord Clone() {
			BANK_STATEMENT_BaseRecord output = new() {
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
