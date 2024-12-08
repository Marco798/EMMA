using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class SYST_COMBO_BaseRecord {
		[JsonInclude]
		public string NAME { get; set; }
		[JsonInclude]
		public string TYPE { get; set; }

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
