namespace EMMA_BE.Generated {
	public class SYST_TABLE_NullRecord {
		public int? ID { get { return _ID; } internal set { _ID = value; IsSet_ID = true; } }
		public string? TABLE_NAME { get { return _TABLE_NAME; } set { _TABLE_NAME = value; IsSet_TABLE_NAME = true; } }
		public string? DESCRIPTION { get { return _DESCRIPTION; } set { _DESCRIPTION = value; IsSet_DESCRIPTION = true; } }
		public string? SHORT_DESCRIPTION { get { return _SHORT_DESCRIPTION; } set { _SHORT_DESCRIPTION = value; IsSet_SHORT_DESCRIPTION = true; } }
	
		private int? _ID;
		private string? _TABLE_NAME;
		private string? _DESCRIPTION;
		private string? _SHORT_DESCRIPTION;

		internal bool IsSet_ID { get; private set; }
		internal bool IsSet_TABLE_NAME { get; private set; }
		internal bool IsSet_DESCRIPTION { get; private set; }
		internal bool IsSet_SHORT_DESCRIPTION { get; private set; }

		public SYST_TABLE_NullRecord() { }

		public SYST_TABLE_NullRecord(SYST_TABLE_Record record) {
			ID = record.ID;
			TABLE_NAME = record.TABLE_NAME;
			DESCRIPTION = record.DESCRIPTION;
			SHORT_DESCRIPTION = record.SHORT_DESCRIPTION;
		}
	}
}
