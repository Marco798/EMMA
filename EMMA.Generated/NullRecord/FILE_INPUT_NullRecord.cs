namespace EMMA_BE.Generated {
	public class FILE_INPUT_NullRecord {
		public int? ID { get { return _ID; } internal set { _ID = value; IsSet_ID = true; } }
		public string? FILE_NAME { get { return _FILE_NAME; } set { _FILE_NAME = value; IsSet_FILE_NAME = true; } }
		public string? FILE_TYPE { get { return _FILE_TYPE; } private set { _FILE_TYPE = value; IsSet_FILE_TYPE = true; } }
		public string? FILE_CATEGORY { get { return _FILE_CATEGORY; } private set { _FILE_CATEGORY = value; IsSet_FILE_CATEGORY = true; } }
		public byte[]? CONTENT { get { return _CONTENT; } set { _CONTENT = value; IsSet_CONTENT = true; } }
		public DateTime? INS_DATE { get { return _INS_DATE; } internal set { _INS_DATE = value; IsSet_INS_DATE = true; } }
		public TimeSpan? INS_TIME { get { return _INS_TIME; } internal set { _INS_TIME = value; IsSet_INS_TIME = true; } }
		public string? INS_INFO { get { return _INS_INFO; } internal set { _INS_INFO = value; IsSet_INS_INFO = true; } }

		public void Set_FILE_TYPE(FILE_TYPE_Combo value) { FILE_TYPE = value.Value; }
		public void Set_FILE_CATEGORY(FILE_CATEGORY_Combo value) { FILE_CATEGORY = value.Value; }

		private int? _ID;
		private string? _FILE_NAME;
		private string? _FILE_TYPE;
		private string? _FILE_CATEGORY;
		private byte[]? _CONTENT;
		private DateTime? _INS_DATE;
		private TimeSpan? _INS_TIME;
		private string? _INS_INFO;

		internal bool IsSet_ID { get; private set; }
		internal bool IsSet_FILE_NAME { get; private set; }
		internal bool IsSet_FILE_TYPE { get; private set; }
		internal bool IsSet_FILE_CATEGORY { get; private set; }
		internal bool IsSet_CONTENT { get; private set; }
		internal bool IsSet_INS_DATE { get; private set; }
		internal bool IsSet_INS_TIME { get; private set; }
		internal bool IsSet_INS_INFO { get; private set; }

		public FILE_INPUT_NullRecord() { }

		public FILE_INPUT_NullRecord(FILE_INPUT_Record record) {
			ID = record.ID;
			FILE_NAME = record.FILE_NAME;
			FILE_TYPE = record.FILE_TYPE;
			FILE_CATEGORY = record.FILE_CATEGORY;
			CONTENT = record.CONTENT;
			INS_DATE = record.INS_DATE;
			INS_TIME = record.INS_TIME;
			INS_INFO = record.INS_INFO;
		}

		public FILE_INPUT_NullRecord(FILE_INPUT_IdRecord record) {
			ID = record.ID;
			FILE_NAME = record.FILE_NAME;
			FILE_TYPE = record.FILE_TYPE;
			FILE_CATEGORY = record.FILE_CATEGORY;
			CONTENT = record.CONTENT;
		}
	}
}
