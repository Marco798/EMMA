namespace EMMA_BE.Generated {
	public class SYST_COMBO_VALUE_NullRecord {
		public int? ID { get { return _ID; } internal set { _ID = value; IsSet_ID = true; } }
		public string? NAME { get { return _NAME; } set { _NAME = value; IsSet_NAME = true; } }
		public string? VALUE { get { return _VALUE; } set { _VALUE = value; IsSet_VALUE = true; } }
		public string? COMBO { get { return _COMBO; } set { _COMBO = value; IsSet_COMBO = true; } }

		private int? _ID;
		private string? _NAME;
		private string? _VALUE;
		private string? _COMBO;

		internal bool IsSet_ID { get; private set; }
		internal bool IsSet_NAME { get; private set; }
		internal bool IsSet_VALUE { get; private set; }
		internal bool IsSet_COMBO { get; private set; }

		public SYST_COMBO_VALUE_NullRecord() { }

		public SYST_COMBO_VALUE_NullRecord(SYST_COMBO_VALUE_Record record) {
			ID = record.ID;
			NAME = record.NAME;
			VALUE = record.VALUE;
			COMBO = record.COMBO;
		}

		public SYST_COMBO_VALUE_NullRecord(SYST_COMBO_VALUE_IdRecord record) {
			ID = record.ID;
			NAME = record.NAME;
			VALUE = record.VALUE;
			COMBO = record.COMBO;
		}
	}
}
