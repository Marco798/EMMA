namespace EMMA_BE.Generated {
	public class SYST_COLUMN_BaseRecord {
		public string TABLE_NAME { get; private set; }
		public string COLUMN_NAME { get; private set; }
		public string DESCRIPTION { get; private set; }
		public string SHORT_DESCRIPTION { get; private set; }
		public string? COMBO { get; private set; }

		public void Set_TABLE_NAME(string value) { TABLE_NAME = value; }
		public void Set_COLUMN_NAME(string value) { COLUMN_NAME = value; }
		public void Set_DESCRIPTION(string value) { DESCRIPTION = value; }
		public void Set_SHORT_DESCRIPTION(string value) { SHORT_DESCRIPTION = value; }
		public void Set_COMBO(string value) { COMBO = value; }

		public SYST_COLUMN_BaseRecord() {
			TABLE_NAME = string.Empty;
			COLUMN_NAME = string.Empty;
			DESCRIPTION = string.Empty;
			SHORT_DESCRIPTION = string.Empty;
			COMBO = string.Empty;
		}

		public SYST_COLUMN_BaseRecord Clone() {
			SYST_COLUMN_BaseRecord output = new() {
				TABLE_NAME = TABLE_NAME,
				COLUMN_NAME = COLUMN_NAME,
				DESCRIPTION = DESCRIPTION,
				SHORT_DESCRIPTION = SHORT_DESCRIPTION,
				COMBO = COMBO
			};
			return output;
		}
	}
}
