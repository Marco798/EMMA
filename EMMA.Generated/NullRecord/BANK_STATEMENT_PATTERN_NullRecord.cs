using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class BANK_STATEMENT_PATTERN_NullRecord {
		public int? ID { get { return _ID; } set { _ID = value; IsSet_ID = true; } }
		public BANK_STATEMENT_FIELD_Combo? FIELD { get { return _FIELD; } set { _FIELD = value; IsSet_FIELD = true; } }
		public string? ORIGINAL_VALUE { get { return _ORIGINAL_VALUE; } set { _ORIGINAL_VALUE = value; IsSet_ORIGINAL_VALUE = true; } }
		public string? PATTERN { get { return _PATTERN; } set { _PATTERN = value; IsSet_PATTERN = true; } }
		public PATTERN_POSITION_Combo? POSITION { get { return _POSITION; } set { _POSITION = value; IsSet_POSITION = true; } }

		private int? _ID;
		private BANK_STATEMENT_FIELD_Combo? _FIELD;
		private string? _ORIGINAL_VALUE;
		private string? _PATTERN;
		private PATTERN_POSITION_Combo? _POSITION;

		public bool IsSet_ID { get; private set; }
		public bool IsSet_FIELD { get; private set; }
		public bool IsSet_ORIGINAL_VALUE { get; private set; }
		public bool IsSet_PATTERN { get; private set; }
		public bool IsSet_POSITION { get; private set; }

		public BANK_STATEMENT_PATTERN_NullRecord() { }

        [JsonConstructor]
        public BANK_STATEMENT_PATTERN_NullRecord(
			int? id, bool isSet_id,
			BANK_STATEMENT_FIELD_Combo? field, bool isSet_field,
			string? original_value, bool isSet_original_value,
			string? pattern, bool isSet_pattern,
			PATTERN_POSITION_Combo? position, bool isSet_position) {
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
