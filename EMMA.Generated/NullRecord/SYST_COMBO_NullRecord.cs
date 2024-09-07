namespace EMMA_BE.Generated {
	public class SYST_COMBO_NullRecord {
		public int? ID { get { return _ID; } internal set { _ID = value; IsSet_ID = true; } }
		public string? NAME { get { return _NAME; } set { _NAME = value; IsSet_NAME = true; } }
		public string? TYPE { get { return _TYPE; } set { _TYPE = value; IsSet_TYPE = true; } }

		private int? _ID;
		private string? _NAME;
		private string? _TYPE;

		internal bool IsSet_ID { get; private set; }
		internal bool IsSet_NAME { get; private set; }
		internal bool IsSet_TYPE { get; private set; }

		public SYST_COMBO_NullRecord() { }

		public SYST_COMBO_NullRecord(SYST_COMBO_Record record) {
			ID = record.ID;
			NAME = record.NAME;
			TYPE = record.TYPE;
		}

		public SYST_COMBO_NullRecord(SYST_COMBO_IdRecord record) {
			ID = record.ID;
			NAME = record.NAME;
			TYPE = record.TYPE;
		}
	}
}
