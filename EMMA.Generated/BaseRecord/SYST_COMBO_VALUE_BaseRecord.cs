using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class SYST_COMBO_VALUE_BaseRecord {
		[JsonInclude]
		public string NAME { get; set; }
		[JsonInclude]
		public string VALUE { get; set; }
		[JsonInclude]
		public string COMBO { get; set; }

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
