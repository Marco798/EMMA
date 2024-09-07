namespace EMMA_BE.Generated {
	public class FILE_INPUT_IdRecord {
		public int ID { get; set; }
		public string FILE_NAME { get; set; }
		public string FILE_TYPE { get; set; }
		public byte[] CONTENT { get; set; }

		public FILE_INPUT_IdRecord() { }

		public FILE_INPUT_IdRecord(FILE_INPUT_Record record) {
			ID = record.ID;
			FILE_NAME = record.FILE_NAME;
			FILE_TYPE = record.FILE_TYPE;
			CONTENT = record.CONTENT;
		}

		public FILE_INPUT_IdRecord Clone() {
			FILE_INPUT_IdRecord output = new() {
				ID = ID,
				FILE_NAME = FILE_NAME,
				FILE_TYPE = FILE_TYPE,
				CONTENT = CONTENT
			};
			return output;
		}
	}
}
