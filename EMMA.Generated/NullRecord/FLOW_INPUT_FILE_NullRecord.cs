namespace EMMA_BE.Generated {
	public class FLOW_INPUT_FILE_NullRecord {
		public long? ID { get { return _ID; } internal set { _ID = value; IsSet_ID = true; } }
		public string? FLOW_NAME { get { return _FLOW_NAME; } set { _FLOW_NAME = value; IsSet_FLOW_NAME = true; } }
		public string? FLOW_TYPE { get { return _FLOW_TYPE; } set { _FLOW_TYPE = value; IsSet_FLOW_TYPE = true; } }
		public byte[]? CONTENT { get { return _CONTENT; } set { _CONTENT = value; IsSet_CONTENT = true; } }
		public DateTime? INS_DATE { get { return _INS_DATE; } internal set { _INS_DATE = value; IsSet_INS_DATE = true; } }
		public TimeSpan? INS_TIME { get { return _INS_TIME; } internal set { _INS_TIME = value; IsSet_INS_TIME = true; } }
		public string? INS_INFO { get { return _INS_INFO; } internal set { _INS_INFO = value; IsSet_INS_INFO = true; } }
		public DateTime? UPD_DATE { get { return _UPD_DATE; } internal set { _UPD_DATE = value; IsSet_UPD_DATE = true; } }
		public TimeSpan? UPD_TIME { get { return _UPD_TIME; } internal set { _UPD_TIME = value; IsSet_UPD_TIME = true; } }
		public string? UPD_INFO { get { return _UPD_INFO; } internal set { _UPD_INFO = value; IsSet_UPD_INFO = true; } }

		private long? _ID;
		private string? _FLOW_NAME;
		private string? _FLOW_TYPE;
		private byte[]? _CONTENT;
		private DateTime? _INS_DATE;
		private TimeSpan? _INS_TIME;
		private string? _INS_INFO;
		private DateTime? _UPD_DATE;
		private TimeSpan? _UPD_TIME;
		private string? _UPD_INFO;

		internal bool IsSet_ID { get; private set; }
		internal bool IsSet_FLOW_NAME { get; private set; }
		internal bool IsSet_FLOW_TYPE { get; private set; }
		internal bool IsSet_CONTENT { get; private set; }
		internal bool IsSet_INS_DATE { get; private set; }
		internal bool IsSet_INS_TIME { get; private set; }
		internal bool IsSet_INS_INFO { get; private set; }
		internal bool IsSet_UPD_DATE { get; private set; }
		internal bool IsSet_UPD_TIME { get; private set; }
		internal bool IsSet_UPD_INFO { get; private set; }

		public FLOW_INPUT_FILE_NullRecord() { }

		public FLOW_INPUT_FILE_NullRecord(FLOW_INPUT_FILE_Record record) {
			ID = record.ID;
			FLOW_NAME = record.FLOW_NAME;
			FLOW_TYPE = record.FLOW_TYPE;
			CONTENT = record.CONTENT;
			INS_DATE = record.INS_DATE;
			INS_TIME = record.INS_TIME;
			INS_INFO = record.INS_INFO;
			UPD_DATE = record.UPD_DATE;
			UPD_TIME = record.UPD_TIME;
			UPD_INFO = record.UPD_INFO;
		}

		public FLOW_INPUT_FILE_NullRecord(FLOW_INPUT_FILE_IdRecord record) {
			ID = record.ID;
			FLOW_NAME = record.FLOW_NAME;
			FLOW_TYPE = record.FLOW_TYPE;
			CONTENT = record.CONTENT;
		}
	}
}
