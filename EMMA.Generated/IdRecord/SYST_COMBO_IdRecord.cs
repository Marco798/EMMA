namespace EMMA_BE.Generated {
	public class SYST_COMBO_IdRecord {
		public int ID { get; set; }
		public string NAME { get; set; }
		public string TYPE { get; set; }

		public SYST_COMBO_Id GetId() { return new SYST_COMBO_Id(ID); }

		public SYST_COMBO_IdRecord() { }

		public SYST_COMBO_IdRecord(SYST_COMBO_Record record) {
			ID = record.ID;
			NAME = record.NAME;
			TYPE = record.TYPE;
		}

		public SYST_COMBO_IdRecord Clone() {
			SYST_COMBO_IdRecord output = new() {
				ID = ID,
				NAME = NAME,
				TYPE = TYPE
			};
			return output;
		}
	}
}
