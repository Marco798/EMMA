namespace EMMA_BE.Generated {
	public class SYST_MENU_BaseRecord {
		public string NAME { get; private set; }
		public string PARENT { get; private set; }
		public string DESCRIPTION { get; private set; }
		public string SHORT_DESCRIPTION { get; private set; }

		public void Set_NAME(string value) { NAME = value; }
		public void Set_PARENT(string value) { PARENT = value; }
		public void Set_DESCRIPTION(string value) { DESCRIPTION = value; }
		public void Set_SHORT_DESCRIPTION(string value) { SHORT_DESCRIPTION = value; }

		public SYST_MENU_BaseRecord() {
			NAME = string.Empty;
			PARENT = string.Empty;
			DESCRIPTION = string.Empty;
			SHORT_DESCRIPTION = string.Empty;
		}

		public SYST_MENU_BaseRecord Clone() {
			SYST_MENU_BaseRecord output = new() {
				NAME = NAME,
				PARENT = PARENT,
				DESCRIPTION = DESCRIPTION,
				SHORT_DESCRIPTION = SHORT_DESCRIPTION
			};
			return output;
		}
	}
}
