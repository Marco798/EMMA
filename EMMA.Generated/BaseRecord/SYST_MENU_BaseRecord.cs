using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class SYST_MENU_BaseRecord {
		[JsonInclude]
		public string NAME { get; set; }
		[JsonInclude]
		public int PARENT { get; set; }
		[JsonInclude]
		public string DESCRIPTION { get; set; }
		[JsonInclude]
		public string SHORT_DESCRIPTION { get; set; }
		[JsonInclude]
		public int? INDEX { get; set; }

		public SYST_MENU_BaseRecord() {
			NAME = string.Empty;
			DESCRIPTION = string.Empty;
			SHORT_DESCRIPTION = string.Empty;
		}

		public SYST_MENU_BaseRecord Clone() {
			SYST_MENU_BaseRecord output = new() {
				NAME = NAME,
				PARENT = PARENT,
				DESCRIPTION = DESCRIPTION,
				SHORT_DESCRIPTION = SHORT_DESCRIPTION,
				INDEX = INDEX
			};
			return output;
		}
	}
}
