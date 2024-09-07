namespace EMMA_BE.Generated {
	public class SYST_MENU_BaseRecord {
		public string NAME { get; set; }
		public string PARENT { get; set; }
		public string DESCRIPTION { get; set; }
		public string SHORT_DESCRIPTION { get; set; }

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
