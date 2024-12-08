using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class FILE_INPUT_BaseRecord {
		[JsonInclude]
		public string FILE_NAME { get; set; }
		[JsonInclude]
		public string FILE_TYPE { get; private set; }
		[JsonInclude]
		public string FILE_CATEGORY { get; private set; }
		[JsonInclude]
		public byte[] CONTENT { get; set; }

		public void Set_FILE_TYPE(FILE_TYPE_Combo value) { FILE_TYPE = value.Value; }
		public void Set_FILE_TYPE(string value) { if (FILE_TYPE_Combo.GetValues().Contains(value)) FILE_TYPE = value; else throw new Exception(); }
		public void Set_FILE_CATEGORY(FILE_CATEGORY_Combo value) { FILE_CATEGORY = value.Value; }
		public void Set_FILE_CATEGORY(string value) { if (FILE_CATEGORY_Combo.GetValues().Contains(value)) FILE_CATEGORY = value; else throw new Exception(); }

		public FILE_INPUT_BaseRecord() {
			FILE_NAME = string.Empty;
			FILE_TYPE = string.Empty;
			FILE_CATEGORY = string.Empty;
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
