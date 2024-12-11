namespace EMMA_BE.Generated {
	public class FILE_INPUT_IdRecord {
		public int ID { get; set; }
		public string FILE_NAME { get; set; }
		public FILE_TYPE_Combo FILE_TYPE { get; set; }
		public FILE_CATEGORY_Combo FILE_CATEGORY { get; set; }
		public byte[] CONTENT { get; set; }

		public FILE_INPUT_Id GetId() { return new FILE_INPUT_Id(ID); }

		public FILE_INPUT_IdRecord() { }

		public FILE_INPUT_IdRecord(FILE_INPUT_Record record) {
			ID = record.ID;
			FILE_NAME = record.FILE_NAME;
			FILE_TYPE = record.FILE_TYPE;
			FILE_CATEGORY = record.FILE_CATEGORY;
			CONTENT = record.CONTENT;
		}

		public FILE_INPUT_IdRecord Clone() {
			FILE_INPUT_IdRecord output = new() {
				ID = ID,
				FILE_NAME = FILE_NAME,
				FILE_TYPE = FILE_TYPE,
				FILE_CATEGORY = FILE_CATEGORY,
				CONTENT = CONTENT
			};
			return output;
		}
	}
}
