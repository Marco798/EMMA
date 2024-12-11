using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class SYST_COLUMN_Record {
		[JsonInclude]
		public int ID { get; set; }
		[JsonInclude]
		public string TABLE_NAME { get; set; }
		[JsonInclude]
		public string COLUMN_NAME { get; set; }
		[JsonInclude]
		public string DESCRIPTION { get; set; }
		[JsonInclude]
		public string SHORT_DESCRIPTION { get; set; }
		[JsonInclude]
		public string? COMBO { get; set; }
		[JsonInclude]
		public string? EXTERNAL_TABLE_ID { get; set; }

		public SYST_COLUMN_Id GetId() { return new SYST_COLUMN_Id(ID); }

		public SYST_COLUMN_Record Clone() {
			SYST_COLUMN_Record output = new() {
				ID = ID,
				TABLE_NAME = TABLE_NAME,
				COLUMN_NAME = COLUMN_NAME,
				DESCRIPTION = DESCRIPTION,
				SHORT_DESCRIPTION = SHORT_DESCRIPTION,
				COMBO = COMBO,
				EXTERNAL_TABLE_ID = EXTERNAL_TABLE_ID
			};
			return output;
		}
	}
}
