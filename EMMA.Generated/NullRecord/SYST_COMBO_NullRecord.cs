using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class SYST_COMBO_NullRecord {
		public int? ID { get { return _ID; } set { _ID = value; IsSet_ID = true; } }
		public string? NAME { get { return _NAME; } set { _NAME = value; IsSet_NAME = true; } }
		public string? TYPE { get { return _TYPE; } set { _TYPE = value; IsSet_TYPE = true; } }

		private int? _ID;
		private string? _NAME;
		private string? _TYPE;

		public bool IsSet_ID { get; private set; }
		public bool IsSet_NAME { get; private set; }
		public bool IsSet_TYPE { get; private set; }

		public SYST_COMBO_NullRecord() { }

        [JsonConstructor]
        public SYST_COMBO_NullRecord(
			int? id, bool isSet_id,
			string? name, bool isSet_name,
			string? type, bool isSet_type) {
			if (isSet_id) ID = id;
			if (isSet_name) NAME = name;
			if (isSet_type) TYPE = type;
        }

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
