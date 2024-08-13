namespace EMMA_BE.Generated {
	public class SYST_MENU_BaseRecord {
		public string NAME { get; set; }
		public string PARENT { get; set; }
		public string DESCRIPTION { get; set; }
		public string SHORT_DESCRIPTION { get; set; }

		public SYST_MENU_Record Clone() {
			SYST_MENU_Record output = new() {
				NAME = NAME,
				PARENT = PARENT,
				DESCRIPTION = DESCRIPTION,
				SHORT_DESCRIPTION = SHORT_DESCRIPTION
			};
			return output;
		}
	}
}
