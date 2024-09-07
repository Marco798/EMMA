namespace EMMA_BE.Generated {
	public class SYST_COMBO_VALUE_BaseRecord {
		public string NAME { get; private set; }
		public string VALUE { get; private set; }
		public string COMBO { get; private set; }

		public void Set_NAME(string value) { NAME = value; }
		public void Set_VALUE(string value) { VALUE = value; }
		public void Set_COMBO(string value) { COMBO = value; }

		public SYST_COMBO_VALUE_BaseRecord() {
			NAME = string.Empty;
			VALUE = string.Empty;
			COMBO = string.Empty;
		}

		public SYST_COMBO_VALUE_BaseRecord Clone() {
			SYST_COMBO_VALUE_BaseRecord output = new() {
				NAME = NAME,
				VALUE = VALUE,
				COMBO = COMBO
			};
			return output;
		}
	}
}
