namespace EMMA_BE.Generated {
	public class SYST_TABLE_BaseRecord {
		public string TABLE_NAME { get; private set; }
		public string DESCRIPTION { get; private set; }
		public string SHORT_DESCRIPTION { get; private set; }

		public void Set_TABLE_NAME(string value) { TABLE_NAME = value; }
		public void Set_DESCRIPTION(string value) { DESCRIPTION = value; }
		public void Set_SHORT_DESCRIPTION(string value) { SHORT_DESCRIPTION = value; }

		public SYST_TABLE_BaseRecord() {
			TABLE_NAME = string.Empty;
			DESCRIPTION = string.Empty;
			SHORT_DESCRIPTION = string.Empty;
		}

		public SYST_TABLE_BaseRecord Clone() {
			SYST_TABLE_BaseRecord output = new() {
				TABLE_NAME = TABLE_NAME,
				DESCRIPTION = DESCRIPTION,
				SHORT_DESCRIPTION = SHORT_DESCRIPTION
			};
			return output;
		}
	}
}
