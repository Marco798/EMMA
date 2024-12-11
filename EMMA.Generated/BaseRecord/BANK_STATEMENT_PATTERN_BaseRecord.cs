using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class BANK_STATEMENT_PATTERN_BaseRecord {
		[JsonInclude]
		public string FIELD { get; private set; }
		[JsonInclude]
		public string ORIGINAL_VALUE { get; set; }
		[JsonInclude]
		public string PATTERN { get; set; }
		[JsonInclude]
		public string POSITION { get; private set; }

		public void Set_FIELD(BANK_STATEMENT_FIELD_Combo value) { FIELD = value.Value; }
		public void Set_FIELD(string value) { if (BANK_STATEMENT_FIELD_ComboValues.GetValues().Contains(value)) FIELD = value; else throw new Exception(); }
		public void Set_POSITION(PATTERN_POSITION_Combo value) { POSITION = value.Value; }
		public void Set_POSITION(string value) { if (PATTERN_POSITION_ComboValues.GetValues().Contains(value)) POSITION = value; else throw new Exception(); }

		public BANK_STATEMENT_PATTERN_BaseRecord() {
			FIELD = string.Empty;
			ORIGINAL_VALUE = string.Empty;
			PATTERN = string.Empty;
			POSITION = string.Empty;
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
