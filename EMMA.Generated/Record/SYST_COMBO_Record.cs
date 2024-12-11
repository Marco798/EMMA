using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class SYST_COMBO_Record {
		[JsonInclude]
		public int ID { get; set; }
		[JsonInclude]
		public string NAME { get; set; }
		[JsonInclude]
		public string TYPE { get; set; }

		public SYST_COMBO_Id GetId() { return new SYST_COMBO_Id(ID); }

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
