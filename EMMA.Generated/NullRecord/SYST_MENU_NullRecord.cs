namespace EMMA_BE.Generated {
	public class SYST_MENU_NullRecord {
		public int? ID { get { return _ID; } internal set { _ID = value; IsSet_ID = true; } }
		public string? NAME { get { return _NAME; } set { _NAME = value; IsSet_NAME = true; } }
		public int? PARENT { get { return _PARENT; } set { _PARENT = value; IsSet_PARENT = true; } }
		public string? DESCRIPTION { get { return _DESCRIPTION; } set { _DESCRIPTION = value; IsSet_DESCRIPTION = true; } }
		public string? SHORT_DESCRIPTION { get { return _SHORT_DESCRIPTION; } set { _SHORT_DESCRIPTION = value; IsSet_SHORT_DESCRIPTION = true; } }
		public int? INDEX { get { return _INDEX; } set { _INDEX = value; IsSet_INDEX = true; } }

		private int? _ID;
		private string? _NAME;
		private int? _PARENT;
		private string? _DESCRIPTION;
		private string? _SHORT_DESCRIPTION;
		private int? _INDEX;

		internal bool IsSet_ID { get; private set; }
		internal bool IsSet_NAME { get; private set; }
		internal bool IsSet_PARENT { get; private set; }
		internal bool IsSet_DESCRIPTION { get; private set; }
		internal bool IsSet_SHORT_DESCRIPTION { get; private set; }
		internal bool IsSet_INDEX { get; private set; }

		public SYST_MENU_NullRecord() { }

		public SYST_MENU_NullRecord(SYST_MENU_Record record) {
			ID = record.ID;
			NAME = record.NAME;
			PARENT = record.PARENT;
			DESCRIPTION = record.DESCRIPTION;
			SHORT_DESCRIPTION = record.SHORT_DESCRIPTION;
			INDEX = record.INDEX;
		}

		public SYST_MENU_NullRecord(SYST_MENU_IdRecord record) {
			ID = record.ID;
			NAME = record.NAME;
			PARENT = record.PARENT;
			DESCRIPTION = record.DESCRIPTION;
			SHORT_DESCRIPTION = record.SHORT_DESCRIPTION;
			INDEX = record.INDEX;
		}
	}
}
