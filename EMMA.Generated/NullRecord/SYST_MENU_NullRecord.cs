using System.Text.Json.Serialization;

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

		public bool IsSet_ID { get; private set; }
		public bool IsSet_NAME { get; private set; }
		public bool IsSet_PARENT { get; private set; }
		public bool IsSet_DESCRIPTION { get; private set; }
		public bool IsSet_SHORT_DESCRIPTION { get; private set; }
		public bool IsSet_INDEX { get; private set; }

		public SYST_MENU_NullRecord() { }

        [JsonConstructor]
        public SYST_MENU_NullRecord(
			int? id, bool isSet_id,
			string? name, bool isSet_name,
			int? parent, bool isSet_parent,
			string? description, bool isSet_description,
			string? short_description, bool isSet_short_description,
			int? index, bool isSet_index) {
			if (isSet_id) ID = id;
			if (isSet_name) NAME = name;
			if (isSet_parent) PARENT = parent;
			if (isSet_description) DESCRIPTION = description;
			if (isSet_short_description) SHORT_DESCRIPTION = short_description;
			if (isSet_index) INDEX = index;
        }

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
