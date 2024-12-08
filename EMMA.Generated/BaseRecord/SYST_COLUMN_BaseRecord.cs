using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class SYST_COLUMN_BaseRecord {
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

		public SYST_COLUMN_BaseRecord() {
			TABLE_NAME = string.Empty;
			COLUMN_NAME = string.Empty;
			DESCRIPTION = string.Empty;
			SHORT_DESCRIPTION = string.Empty;
			COMBO = string.Empty;
			EXTERNAL_TABLE_ID = string.Empty;
		}

		public SYST_COLUMN_BaseRecord Clone() {
			SYST_COLUMN_BaseRecord output = new() {
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
