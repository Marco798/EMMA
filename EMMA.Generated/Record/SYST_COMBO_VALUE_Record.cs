using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class SYST_COMBO_VALUE_Record {
		[JsonInclude]
		public int ID { get; set; }
		[JsonInclude]
		public string NAME { get; set; }
		[JsonInclude]
		public string VALUE { get; set; }
		[JsonInclude]
		public string COMBO { get; set; }

		public SYST_COMBO_VALUE_Id GetId() { return new SYST_COMBO_VALUE_Id(ID); }

		public SYST_COMBO_VALUE_Record Clone() {
			SYST_COMBO_VALUE_Record output = new() {
				ID = ID,
				NAME = NAME,
				VALUE = VALUE,
				COMBO = COMBO
			};
			return output;
		}
	}
}
