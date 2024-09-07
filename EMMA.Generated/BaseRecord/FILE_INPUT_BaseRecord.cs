namespace EMMA_BE.Generated {
	public class FILE_INPUT_BaseRecord {
		public string FILE_NAME { get; private set; }
		public string FILE_TYPE { get; private set; }
		public byte[] CONTENT { get; private set; }

		public void Set_FILE_NAME(string value) { FILE_NAME = value; }
		public void Set_FILE_TYPE(string value) { FILE_TYPE = value; }
		public void Set_CONTENT(byte[] value) { CONTENT = value; }

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
