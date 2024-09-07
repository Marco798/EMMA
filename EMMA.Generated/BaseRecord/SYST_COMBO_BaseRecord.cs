namespace EMMA_BE.Generated {
	public class SYST_COMBO_BaseRecord {
		public string NAME { get; private set; }
		public string TYPE { get; private set; }

		public void Set_NAME(string value) { NAME = value; }
		public void Set_TYPE(string value) { TYPE = value; }

		public SYST_COMBO_BaseRecord() {
			NAME = string.Empty;
			TYPE = string.Empty;
		}

		public SYST_COMBO_BaseRecord Clone() {
			SYST_COMBO_BaseRecord output = new() {
				NAME = NAME,
				TYPE = TYPE
			};
			return output;
		}
	}
}
