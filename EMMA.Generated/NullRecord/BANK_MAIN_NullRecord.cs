namespace EMMA_BE.Generated {
	public class BANK_MAIN_NullRecord {
		public long? ID { get { return _ID; } internal set { _ID = value; IsSet_ID = true; } }
		public DateTime? OPERATION_DATE { get { return _OPERATION_DATE; } set { _OPERATION_DATE = value; IsSet_OPERATION_DATE = true; } }
		public DateTime? VALUE_DATE { get { return _VALUE_DATE; } set { _VALUE_DATE = value; IsSet_VALUE_DATE = true; } }
		public string? REASON { get { return _REASON; } set { _REASON = value; IsSet_REASON = true; } }
		public string? DESCRIPTION { get { return _DESCRIPTION; } set { _DESCRIPTION = value; IsSet_DESCRIPTION = true; } }
		public decimal? OUTCOME { get { return _OUTCOME; } set { _OUTCOME = value; IsSet_OUTCOME = true; } }
		public decimal? INCOME { get { return _INCOME; } set { _INCOME = value; IsSet_INCOME = true; } }
		public string? TAG1 { get { return _TAG1; } set { _TAG1 = value; IsSet_TAG1 = true; } }
		public string? TAG2 { get { return _TAG2; } set { _TAG2 = value; IsSet_TAG2 = true; } }
		public string? TAG3 { get { return _TAG3; } set { _TAG3 = value; IsSet_TAG3 = true; } }
		public string? TAG4 { get { return _TAG4; } set { _TAG4 = value; IsSet_TAG4 = true; } }
		public long? FLOW_INPUT_FILE_ID { get { return _FLOW_INPUT_FILE_ID; } set { _FLOW_INPUT_FILE_ID = value; IsSet_FLOW_INPUT_FILE_ID = true; } }
		public DateTime? INS_DATE { get { return _INS_DATE; } internal set { _INS_DATE = value; IsSet_INS_DATE = true; } }
		public TimeSpan? INS_TIME { get { return _INS_TIME; } internal set { _INS_TIME = value; IsSet_INS_TIME = true; } }
		public string? INS_INFO { get { return _INS_INFO; } internal set { _INS_INFO = value; IsSet_INS_INFO = true; } }

		private long? _ID;
		private DateTime? _OPERATION_DATE;
		private DateTime? _VALUE_DATE;
		private string? _REASON;
		private string? _DESCRIPTION;
		private decimal? _OUTCOME;
		private decimal? _INCOME;
		private string? _TAG1;
		private string? _TAG2;
		private string? _TAG3;
		private string? _TAG4;
		private long? _FLOW_INPUT_FILE_ID;
		private DateTime? _INS_DATE;
		private TimeSpan? _INS_TIME;
		private string? _INS_INFO;

		internal bool IsSet_ID { get; private set; }
		internal bool IsSet_OPERATION_DATE { get; private set; }
		internal bool IsSet_VALUE_DATE { get; private set; }
		internal bool IsSet_REASON { get; private set; }
		internal bool IsSet_DESCRIPTION { get; private set; }
		internal bool IsSet_OUTCOME { get; private set; }
		internal bool IsSet_INCOME { get; private set; }
		internal bool IsSet_TAG1 { get; private set; }
		internal bool IsSet_TAG2 { get; private set; }
		internal bool IsSet_TAG3 { get; private set; }
		internal bool IsSet_TAG4 { get; private set; }
		internal bool IsSet_FLOW_INPUT_FILE_ID { get; private set; }
		internal bool IsSet_INS_DATE { get; private set; }
		internal bool IsSet_INS_TIME { get; private set; }
		internal bool IsSet_INS_INFO { get; private set; }

		public BANK_MAIN_NullRecord() { }

		public BANK_MAIN_NullRecord(BANK_MAIN_Record record) {
			ID = record.ID;
			OPERATION_DATE = record.OPERATION_DATE;
			VALUE_DATE = record.VALUE_DATE;
			REASON = record.REASON;
			DESCRIPTION = record.DESCRIPTION;
			OUTCOME = record.OUTCOME;
			INCOME = record.INCOME;
			TAG1 = record.TAG1;
			TAG2 = record.TAG2;
			TAG3 = record.TAG3;
			TAG4 = record.TAG4;
			FLOW_INPUT_FILE_ID = record.FLOW_INPUT_FILE_ID;
			INS_DATE = record.INS_DATE;
			INS_TIME = record.INS_TIME;
			INS_INFO = record.INS_INFO;
		}

		public BANK_MAIN_NullRecord(BANK_MAIN_IdRecord record) {
			ID = record.ID;
			OPERATION_DATE = record.OPERATION_DATE;
			VALUE_DATE = record.VALUE_DATE;
			REASON = record.REASON;
			DESCRIPTION = record.DESCRIPTION;
			OUTCOME = record.OUTCOME;
			INCOME = record.INCOME;
			TAG1 = record.TAG1;
			TAG2 = record.TAG2;
			TAG3 = record.TAG3;
			TAG4 = record.TAG4;
			FLOW_INPUT_FILE_ID = record.FLOW_INPUT_FILE_ID;
		}
	}
}
