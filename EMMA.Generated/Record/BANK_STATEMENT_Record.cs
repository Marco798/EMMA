using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class BANK_STATEMENT_Record {
		[JsonInclude]
		public int ID { get; set; }
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
		public string TAG1 { get; private set; }
		[JsonInclude]
		public string TAG2 { get; set; }
		[JsonInclude]
		public string TAG3 { get; set; }
		[JsonInclude]
		public string TAG4 { get; set; }
		[JsonInclude]
		public int ID_FILE_INPUT { get; private set; }
		[JsonInclude]
		public int? ID_BANK_STATEMENT_DESC_PATTERN { get; private set; }
		[JsonInclude]
		public DateTime INS_DATE { get; set; }
		[JsonInclude]
		public TimeSpan INS_TIME { get; set; }
		[JsonInclude]
		public string INS_INFO { get; set; }
		[JsonInclude]
		public DateTime UPD_DATE { get; set; }
		[JsonInclude]
		public TimeSpan UPD_TIME { get; set; }
		[JsonInclude]
		public string UPD_INFO { get; set; }

		public void Set_TAG1(BALANCE_DIRECTION_Combo value) { TAG1 = value.Value; }

		public void Set_ID_FILE_INPUT(FILE_INPUT_Id value) { ID_FILE_INPUT = value.Value; }
		public void Set_ID_BANK_STATEMENT_DESC_PATTERN(BANK_STATEMENT_DESC_PATTERN_Id value) { ID_BANK_STATEMENT_DESC_PATTERN = value.Value; }

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
