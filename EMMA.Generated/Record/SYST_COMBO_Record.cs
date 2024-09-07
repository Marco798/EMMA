namespace EMMA_BE.Generated {
	public class SYST_COMBO_Record {
		public int ID { get; set; }
		public string NAME { get; set; }
		public string TYPE { get; set; }

		public SYST_COMBO_Record Clone() {
			SYST_COMBO_Record output = new() {
				ID = ID,
				NAME = NAME,
				TYPE = TYPE
			};
			return output;
		}
	}
}
