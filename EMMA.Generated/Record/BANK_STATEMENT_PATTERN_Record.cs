namespace EMMA_BE.Generated {
	public class BANK_STATEMENT_PATTERN_Record {
		public int ID { get; set; }
		public string FIELD { get; private set; }
		public string ORIGINAL_VALUE { get; set; }
		public string PATTERN { get; set; }
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
