using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class SYST_TABLE_Record {
		[JsonInclude]
		public int ID { get; set; }
		[JsonInclude]
		public string TABLE_NAME { get; set; }
		[JsonInclude]
		public string DESCRIPTION { get; set; }
		[JsonInclude]
		public string SHORT_DESCRIPTION { get; set; }

		public SYST_TABLE_Id GetId() { return new SYST_TABLE_Id(ID); }

		public SYST_TABLE_Record Clone() {
			SYST_TABLE_Record output = new() {
				ID = ID,
				TABLE_NAME = TABLE_NAME,
				DESCRIPTION = DESCRIPTION,
				SHORT_DESCRIPTION = SHORT_DESCRIPTION
			};
			return output;
		}
	}
}
