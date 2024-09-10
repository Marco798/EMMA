namespace EMMA_BE.Generated {
	public class SYST_MENU_IdRecord {
		public int ID { get; set; }
		public string NAME { get; set; }
		public string PARENT { get; set; }
		public string DESCRIPTION { get; set; }
		public string SHORT_DESCRIPTION { get; set; }

		public SYST_MENU_Id GetId() { return new SYST_MENU_Id(ID); }

		public SYST_MENU_IdRecord() { }

		public SYST_MENU_IdRecord(SYST_MENU_Record record) {
			ID = record.ID;
			NAME = record.NAME;
			PARENT = record.PARENT;
			DESCRIPTION = record.DESCRIPTION;
			SHORT_DESCRIPTION = record.SHORT_DESCRIPTION;
		}

		public SYST_MENU_IdRecord Clone() {
			SYST_MENU_IdRecord output = new() {
				ID = ID,
				NAME = NAME,
				PARENT = PARENT,
				DESCRIPTION = DESCRIPTION,
				SHORT_DESCRIPTION = SHORT_DESCRIPTION
			};
			return output;
		}
	}
}
