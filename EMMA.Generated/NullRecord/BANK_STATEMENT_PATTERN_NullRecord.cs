using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class BANK_STATEMENT_PATTERN_NullRecord {
		public int? ID { get { return _ID; } internal set { _ID = value; IsSet_ID = true; } }
		public string? FIELD { get { return _FIELD; } private set { _FIELD = value; IsSet_FIELD = true; } }
		public string? ORIGINAL_VALUE { get { return _ORIGINAL_VALUE; } set { _ORIGINAL_VALUE = value; IsSet_ORIGINAL_VALUE = true; } }
		public string? PATTERN { get { return _PATTERN; } set { _PATTERN = value; IsSet_PATTERN = true; } }
		public string? POSITION { get { return _POSITION; } private set { _POSITION = value; IsSet_POSITION = true; } }

		public void Set_FIELD(BANK_STATEMENT_FIELD_Combo value) { FIELD = value.Value; }
		public void Set_POSITION(PATTERN_POSITION_Combo value) { POSITION = value.Value; }

		private int? _ID;
		private string? _FIELD;
		private string? _ORIGINAL_VALUE;
		private string? _PATTERN;
		private string? _POSITION;

		public bool IsSet_ID { get; private set; }
		public bool IsSet_FIELD { get; private set; }
		public bool IsSet_ORIGINAL_VALUE { get; private set; }
		public bool IsSet_PATTERN { get; private set; }
		public bool IsSet_POSITION { get; private set; }

		public BANK_STATEMENT_PATTERN_NullRecord() { }

        [JsonConstructor]
        public BANK_STATEMENT_PATTERN_NullRecord(
			int? id, bool isSet_id,
			string? field, bool isSet_field,
			string? original_value, bool isSet_original_value,
			string? pattern, bool isSet_pattern,
			string? position, bool isSet_position) {
			if (isSet_id) ID = id;
			if (isSet_field) FIELD = field;
			if (isSet_original_value) ORIGINAL_VALUE = original_value;
			if (isSet_pattern) PATTERN = pattern;
			if (isSet_position) POSITION = position;
        }

		public BANK_STATEMENT_PATTERN_NullRecord(BANK_STATEMENT_PATTERN_Record record) {
			ID = record.ID;
			FIELD = record.FIELD;
			ORIGINAL_VALUE = record.ORIGINAL_VALUE;
			PATTERN = record.PATTERN;
			POSITION = record.POSITION;
		}

		public BANK_STATEMENT_PATTERN_NullRecord(BANK_STATEMENT_PATTERN_IdRecord record) {
			ID = record.ID;
			FIELD = record.FIELD;
			ORIGINAL_VALUE = record.ORIGINAL_VALUE;
			PATTERN = record.PATTERN;
			POSITION = record.POSITION;
		}
	}
}