namespace EMMA_BE.Generated {
	public class SYST_MENU_Record {
		public int ID { get; set; }
		public string NAME { get; set; }
		public int PARENT { get; set; }
		public string DESCRIPTION { get; set; }
		public string SHORT_DESCRIPTION { get; set; }
		public int? INDEX { get; set; }

		public SYST_MENU_Id GetId() { return new SYST_MENU_Id(ID); }

		public SYST_MENU_Record Clone() {
			SYST_MENU_Record output = new() {
				ID = ID,
				NAME = NAME,
				PARENT = PARENT,
				DESCRIPTION = DESCRIPTION,
				SHORT_DESCRIPTION = SHORT_DESCRIPTION,
				INDEX = INDEX
			};
			return output;
		}
	}
}
