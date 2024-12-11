using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class BANK_STATEMENT_PATTERN_BaseRecord {
		[JsonInclude]
		public BANK_STATEMENT_FIELD_Combo FIELD { get; set; }
		[JsonInclude]
		public string ORIGINAL_VALUE { get; set; }
		[JsonInclude]
		public string PATTERN { get; set; }
		[JsonInclude]
		public PATTERN_POSITION_Combo POSITION { get; set; }

		public BANK_STATEMENT_PATTERN_BaseRecord() {
			FIELD = new(string.Empty);
			ORIGINAL_VALUE = string.Empty;
			PATTERN = string.Empty;
			POSITION = new(string.Empty);
		}

		public BANK_STATEMENT_PATTERN_BaseRecord Clone() {
			BANK_STATEMENT_PATTERN_BaseRecord output = new() {
				FIELD = FIELD,
				ORIGINAL_VALUE = ORIGINAL_VALUE,
				PATTERN = PATTERN,
				POSITION = POSITION
			};
			return output;
		}
	}
}
