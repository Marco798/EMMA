using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class SYST_MENU_Record {
		[JsonInclude]
		public int ID { get; set; }
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

		public SYST_MENU_Id GetId() { return new SYST_MENU_Id(ID); }

		public SYST_MENU_Record Clone() {
			SYST_MENU_Record output = new() {
				ID = ID,
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
