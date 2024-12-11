using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class SYST_COLUMN_NullRecord {
		public int? ID { get { return _ID; } set { _ID = value; IsSet_ID = true; } }
		public string? TABLE_NAME { get { return _TABLE_NAME; } set { _TABLE_NAME = value; IsSet_TABLE_NAME = true; } }
		public string? COLUMN_NAME { get { return _COLUMN_NAME; } set { _COLUMN_NAME = value; IsSet_COLUMN_NAME = true; } }
		public string? DESCRIPTION { get { return _DESCRIPTION; } set { _DESCRIPTION = value; IsSet_DESCRIPTION = true; } }
		public string? SHORT_DESCRIPTION { get { return _SHORT_DESCRIPTION; } set { _SHORT_DESCRIPTION = value; IsSet_SHORT_DESCRIPTION = true; } }
		public string? COMBO { get { return _COMBO; } set { _COMBO = value; IsSet_COMBO = true; } }
		public string? EXTERNAL_TABLE_ID { get { return _EXTERNAL_TABLE_ID; } set { _EXTERNAL_TABLE_ID = value; IsSet_EXTERNAL_TABLE_ID = true; } }

		private int? _ID;
		private string? _TABLE_NAME;
		private string? _COLUMN_NAME;
		private string? _DESCRIPTION;
		private string? _SHORT_DESCRIPTION;
		private string? _COMBO;
		private string? _EXTERNAL_TABLE_ID;

		public bool IsSet_ID { get; private set; }
		public bool IsSet_TABLE_NAME { get; private set; }
		public bool IsSet_COLUMN_NAME { get; private set; }
		public bool IsSet_DESCRIPTION { get; private set; }
		public bool IsSet_SHORT_DESCRIPTION { get; private set; }
		public bool IsSet_COMBO { get; private set; }
		public bool IsSet_EXTERNAL_TABLE_ID { get; private set; }

		public SYST_COLUMN_NullRecord() { }

        [JsonConstructor]
        public SYST_COLUMN_NullRecord(
			int? id, bool isSet_id,
			string? table_name, bool isSet_table_name,
			string? column_name, bool isSet_column_name,
			string? description, bool isSet_description,
			string? short_description, bool isSet_short_description,
			string? combo, bool isSet_combo,
			string? external_table_id, bool isSet_external_table_id) {
			if (isSet_id) ID = id;
			if (isSet_table_name) TABLE_NAME = table_name;
			if (isSet_column_name) COLUMN_NAME = column_name;
			if (isSet_description) DESCRIPTION = description;
			if (isSet_short_description) SHORT_DESCRIPTION = short_description;
			if (isSet_combo) COMBO = combo;
			if (isSet_external_table_id) EXTERNAL_TABLE_ID = external_table_id;
        }

		public SYST_COLUMN_NullRecord(SYST_COLUMN_Record record) {
			ID = record.ID;
			TABLE_NAME = record.TABLE_NAME;
			COLUMN_NAME = record.COLUMN_NAME;
			DESCRIPTION = record.DESCRIPTION;
			SHORT_DESCRIPTION = record.SHORT_DESCRIPTION;
			COMBO = record.COMBO;
			EXTERNAL_TABLE_ID = record.EXTERNAL_TABLE_ID;
		}

		public SYST_COLUMN_NullRecord(SYST_COLUMN_IdRecord record) {
			ID = record.ID;
			TABLE_NAME = record.TABLE_NAME;
			COLUMN_NAME = record.COLUMN_NAME;
			DESCRIPTION = record.DESCRIPTION;
			SHORT_DESCRIPTION = record.SHORT_DESCRIPTION;
			COMBO = record.COMBO;
			EXTERNAL_TABLE_ID = record.EXTERNAL_TABLE_ID;
		}
	}
}
