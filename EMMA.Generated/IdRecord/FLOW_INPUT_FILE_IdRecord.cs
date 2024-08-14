namespace EMMA_BE.Generated {
	public class FLOW_INPUT_FILE_IdRecord {
		public long ID { get; set; }
		public string FLOW_NAME { get; set; }
		public string FLOW_TYPE { get; set; }
		public byte[] CONTENT { get; set; }

		public FLOW_INPUT_FILE_IdRecord() { }

		public FLOW_INPUT_FILE_IdRecord(FLOW_INPUT_FILE_Record record) {
			ID = record.ID;
			FLOW_NAME = record.FLOW_NAME;
			FLOW_TYPE = record.FLOW_TYPE;
			CONTENT = record.CONTENT;
		}

		public FLOW_INPUT_FILE_IdRecord Clone() {
			FLOW_INPUT_FILE_IdRecord output = new() {
				ID = ID,
				FLOW_NAME = FLOW_NAME,
				FLOW_TYPE = FLOW_TYPE,
				CONTENT = CONTENT
			};
			return output;
		}
	}
}
