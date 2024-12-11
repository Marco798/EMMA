using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class BANK_STATEMENT_BaseRecord {
		[JsonInclude]
		public DateTime OPERATION_DATE { get; set; }
		[JsonInclude]
		public DateTime VALUE_DATE { get; set; }
		[JsonInclude]
		public string REASON { get; set; }
		[JsonInclude]
		public string DESCRIPTION { get; set; }
		[JsonInclude]
		public decimal? OUTCOME { get; set; }
		[JsonInclude]
		public decimal? INCOME { get; set; }
		[JsonInclude]
		public BALANCE_DIRECTION_Combo TAG1 { get; set; }
		[JsonInclude]
		public string TAG2 { get; set; }
		[JsonInclude]
		public string TAG3 { get; set; }
		[JsonInclude]
		public string TAG4 { get; set; }
		[JsonInclude]
		public int ID_FILE_INPUT { get; set; }
		[JsonInclude]
		public int? ID_BANK_STATEMENT_DESC_PATTERN { get; set; }

		public void Set_ID_FILE_INPUT(FILE_INPUT_Id value) { ID_FILE_INPUT = value.Value; }
		public void Set_ID_BANK_STATEMENT_DESC_PATTERN(BANK_STATEMENT_DESC_PATTERN_Id value) { ID_BANK_STATEMENT_DESC_PATTERN = value.Value; }

		public BANK_STATEMENT_BaseRecord() {
			REASON = string.Empty;
			DESCRIPTION = string.Empty;
			TAG1 = new(string.Empty);
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
