namespace EMMA_BE.Generated {
	public class FILE_INPUT_Record {
		public int ID { get; set; }
		public string FILE_NAME { get; set; }
		public string FILE_TYPE { get; private set; }
		public string FILE_CATEGORY { get; private set; }
		public byte[] CONTENT { get; set; }
		public DateTime INS_DATE { get; set; }
		public TimeSpan INS_TIME { get; set; }
		public string INS_INFO { get; set; }

		public void Set_FILE_TYPE(FILE_TYPE_Combo value) { FILE_TYPE = value.Value; }
		public void Set_FILE_CATEGORY(FILE_CATEGORY_Combo value) { FILE_CATEGORY = value.Value; }

		public FILE_INPUT_Id GetId() { return new FILE_INPUT_Id(ID); }

		public FILE_INPUT_Record Clone() {
			FILE_INPUT_Record output = new() {
				ID = ID,
				FILE_NAME = FILE_NAME,
				FILE_TYPE = FILE_TYPE,
				FILE_CATEGORY = FILE_CATEGORY,
				CONTENT = CONTENT,
				INS_DATE = INS_DATE,
				INS_TIME = INS_TIME,
				INS_INFO = INS_INFO
			};
			return output;
		}
	}
}
