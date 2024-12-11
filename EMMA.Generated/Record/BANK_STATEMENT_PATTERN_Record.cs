using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class BANK_STATEMENT_PATTERN_Record {
		[JsonInclude]
		public int ID { get; set; }
		[JsonInclude]
		public BANK_STATEMENT_FIELD_Combo FIELD { get; set; }
		[JsonInclude]
		public string ORIGINAL_VALUE { get; set; }
		[JsonInclude]
		public string PATTERN { get; set; }
		[JsonInclude]
		public PATTERN_POSITION_Combo POSITION { get; set; }

		public BANK_STATEMENT_PATTERN_Id GetId() { return new BANK_STATEMENT_PATTERN_Id(ID); }

		public BANK_STATEMENT_PATTERN_Record Clone() {
			BANK_STATEMENT_PATTERN_Record output = new() {
				ID = ID,
				FIELD = FIELD,
				ORIGINAL_VALUE = ORIGINAL_VALUE,
				PATTERN = PATTERN,
				POSITION = POSITION
			};
			return output;
		}
	}
}
