using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class BANK_STATEMENT_PATTERN_Record {
		[JsonInclude]
		public int ID { get; set; }
		[JsonInclude]
		public string FIELD { get; private set; }
		[JsonInclude]
		public string ORIGINAL_VALUE { get; set; }
		[JsonInclude]
		public string PATTERN { get; set; }
		[JsonInclude]
		public string POSITION { get; private set; }

		public void Set_FIELD(BANK_STATEMENT_FIELD_Combo value) { FIELD = value.Value; }
		public void Set_POSITION(PATTERN_POSITION_Combo value) { POSITION = value.Value; }

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
