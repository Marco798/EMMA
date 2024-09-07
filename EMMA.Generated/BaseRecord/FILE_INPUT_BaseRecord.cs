namespace EMMA_BE.Generated {
	public class FILE_INPUT_BaseRecord {
		public string FILE_NAME { get; set; }
		public string FILE_TYPE { get; private set; }
		public byte[] CONTENT { get; set; }

		public void Set_FILE_TYPE(FILE_TYPE_Combo value) { FILE_TYPE = value.Value; }

		public FILE_INPUT_BaseRecord() {
			FILE_NAME = string.Empty;
			FILE_TYPE = string.Empty;
			CONTENT = [];
		}

		public FILE_INPUT_BaseRecord Clone() {
			FILE_INPUT_BaseRecord output = new() {
				FILE_NAME = FILE_NAME,
				FILE_TYPE = FILE_TYPE,
				CONTENT = CONTENT
			};
			return output;
		}
	}
}
