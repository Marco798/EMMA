namespace EMMA_BE.Generated {
	public class FLOW_INPUT_FILE_BaseRecord {
		public string FLOW_NAME { get; set; }
		public string FLOW_TYPE { get; set; }
		public byte[] CONTENT { get; set; }

		public FLOW_INPUT_FILE_BaseRecord() {
			FLOW_NAME = string.Empty;
			FLOW_TYPE = string.Empty;
			CONTENT = [];
		}

		public FLOW_INPUT_FILE_BaseRecord Clone() {
			FLOW_INPUT_FILE_BaseRecord output = new() {
				FLOW_NAME = FLOW_NAME,
				FLOW_TYPE = FLOW_TYPE,
				CONTENT = CONTENT
			};
			return output;
		}
	}
}
