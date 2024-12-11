using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class FILE_INPUT_BaseRecord {
		[JsonInclude]
		public string FILE_NAME { get; set; }
		[JsonInclude]
		public FILE_TYPE_Combo FILE_TYPE { get; set; }
		[JsonInclude]
		public FILE_CATEGORY_Combo FILE_CATEGORY { get; set; }
		[JsonInclude]
		public byte[] CONTENT { get; set; }

		public FILE_INPUT_BaseRecord() {
			FILE_NAME = string.Empty;
			FILE_TYPE = new(string.Empty);
			FILE_CATEGORY = new(string.Empty);
			CONTENT = [];
		}

		public FILE_INPUT_BaseRecord Clone() {
			FILE_INPUT_BaseRecord output = new() {
				FILE_NAME = FILE_NAME,
				FILE_TYPE = FILE_TYPE,
				FILE_CATEGORY = FILE_CATEGORY,
				CONTENT = CONTENT
			};
			return output;
		}
	}
}
