using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class BANK_STATEMENT_DESC_PATTERN_NullRecord {
		public int? ID { get { return _ID; } set { _ID = value; IsSet_ID = true; } }
		public string? PATTERN { get { return _PATTERN; } set { _PATTERN = value; IsSet_PATTERN = true; } }
		public string? DESCRIPTION { get { return _DESCRIPTION; } set { _DESCRIPTION = value; IsSet_DESCRIPTION = true; } }
		public DateTime? INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; IsSet_INS_DATE = true; } }
		public TimeSpan? INS_TIME { get { return _INS_TIME; } set { _INS_TIME = value; IsSet_INS_TIME = true; } }
		public string? INS_INFO { get { return _INS_INFO; } set { _INS_INFO = value; IsSet_INS_INFO = true; } }

		private int? _ID;
		private string? _PATTERN;
		private string? _DESCRIPTION;
		private DateTime? _INS_DATE;
		private TimeSpan? _INS_TIME;
		private string? _INS_INFO;

		public bool IsSet_ID { get; private set; }
		public bool IsSet_PATTERN { get; private set; }
		public bool IsSet_DESCRIPTION { get; private set; }
		public bool IsSet_INS_DATE { get; private set; }
		public bool IsSet_INS_TIME { get; private set; }
		public bool IsSet_INS_INFO { get; private set; }

		public BANK_STATEMENT_DESC_PATTERN_NullRecord() { }

        [JsonConstructor]
        public BANK_STATEMENT_DESC_PATTERN_NullRecord(
			int? id, bool isSet_id,
			string? pattern, bool isSet_pattern,
			string? description, bool isSet_description,
			DateTime? ins_date, bool isSet_ins_date,
			TimeSpan? ins_time, bool isSet_ins_time,
			string? ins_info, bool isSet_ins_info) {
			if (isSet_id) ID = id;
			if (isSet_pattern) PATTERN = pattern;
			if (isSet_description) DESCRIPTION = description;
			if (isSet_ins_date) INS_DATE = ins_date;
			if (isSet_ins_time) INS_TIME = ins_time;
			if (isSet_ins_info) INS_INFO = ins_info;
        }

		public BANK_STATEMENT_DESC_PATTERN_NullRecord(BANK_STATEMENT_DESC_PATTERN_Record record) {
			ID = record.ID;
			PATTERN = record.PATTERN;
			DESCRIPTION = record.DESCRIPTION;
			INS_DATE = record.INS_DATE;
			INS_TIME = record.INS_TIME;
			INS_INFO = record.INS_INFO;
		}

		public BANK_STATEMENT_DESC_PATTERN_NullRecord(BANK_STATEMENT_DESC_PATTERN_IdRecord record) {
			ID = record.ID;
			PATTERN = record.PATTERN;
			DESCRIPTION = record.DESCRIPTION;
		}
	}
}
