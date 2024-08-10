namespace EMMA_BE.Generated {
	public class SYST_MENU_NullRecord {
		public int? ID { get { return _ID; } internal set { _ID = value; IsSet_ID = true; } }
		public string? NAME { get { return _NAME; } set { _NAME = value; IsSet_NAME = true; } }
		public string? PARENT { get { return _PARENT; } set { _PARENT = value; IsSet_PARENT = true; } }
		public string? DESCRIPTION { get { return _DESCRIPTION; } set { _DESCRIPTION = value; IsSet_DESCRIPTION = true; } }
		public string? SHORT_DESCRIPTION { get { return _SHORT_DESCRIPTION; } set { _SHORT_DESCRIPTION = value; IsSet_SHORT_DESCRIPTION = true; } }
		public DateTime? INS_DATE { get { return _INS_DATE; } internal set { _INS_DATE = value; IsSet_INS_DATE = true; } }
		public TimeSpan? INS_TIME { get { return _INS_TIME; } internal set { _INS_TIME = value; IsSet_INS_TIME = true; } }
		public string? INS_INFO { get { return _INS_INFO; } internal set { _INS_INFO = value; IsSet_INS_INFO = true; } }
		public DateTime? UPD_DATE { get { return _UPD_DATE; } internal set { _UPD_DATE = value; IsSet_UPD_DATE = true; } }
		public TimeSpan? UPD_TIME { get { return _UPD_TIME; } internal set { _UPD_TIME = value; IsSet_UPD_TIME = true; } }
		public string? UPD_INFO { get { return _UPD_INFO; } internal set { _UPD_INFO = value; IsSet_UPD_INFO = true; } }
	
		private int? _ID;
		private string? _NAME;
		private string? _PARENT;
		private string? _DESCRIPTION;
		private string? _SHORT_DESCRIPTION;
		private DateTime? _INS_DATE;
		private TimeSpan? _INS_TIME;
		private string? _INS_INFO;
		private DateTime? _UPD_DATE;
		private TimeSpan? _UPD_TIME;
		private string? _UPD_INFO;

		internal bool IsSet_ID { get; private set; }
		internal bool IsSet_NAME { get; private set; }
		internal bool IsSet_PARENT { get; private set; }
		internal bool IsSet_DESCRIPTION { get; private set; }
		internal bool IsSet_SHORT_DESCRIPTION { get; private set; }
		internal bool IsSet_INS_DATE { get; private set; }
		internal bool IsSet_INS_TIME { get; private set; }
		internal bool IsSet_INS_INFO { get; private set; }
		internal bool IsSet_UPD_DATE { get; private set; }
		internal bool IsSet_UPD_TIME { get; private set; }
		internal bool IsSet_UPD_INFO { get; private set; }

		public SYST_MENU_NullRecord(SYST_MENU_Record record) {
			ID = record.ID;
			NAME = record.NAME;
			PARENT = record.PARENT;
			DESCRIPTION = record.DESCRIPTION;
			SHORT_DESCRIPTION = record.SHORT_DESCRIPTION;
			INS_DATE = record.INS_DATE;
			INS_TIME = record.INS_TIME;
			INS_INFO = record.INS_INFO;
			UPD_DATE = record.UPD_DATE;
			UPD_TIME = record.UPD_TIME;
			UPD_INFO = record.UPD_INFO;
		}
	}
}
