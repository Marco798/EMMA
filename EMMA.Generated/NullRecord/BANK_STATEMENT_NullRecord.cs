using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class BANK_STATEMENT_NullRecord {
		public int? ID { get { return _ID; } internal set { _ID = value; IsSet_ID = true; } }
		public DateTime? OPERATION_DATE { get { return _OPERATION_DATE; } set { _OPERATION_DATE = value; IsSet_OPERATION_DATE = true; } }
		public DateTime? VALUE_DATE { get { return _VALUE_DATE; } set { _VALUE_DATE = value; IsSet_VALUE_DATE = true; } }
		public string? REASON { get { return _REASON; } set { _REASON = value; IsSet_REASON = true; } }
		public string? DESCRIPTION { get { return _DESCRIPTION; } set { _DESCRIPTION = value; IsSet_DESCRIPTION = true; } }
		public decimal? OUTCOME { get { return _OUTCOME; } set { _OUTCOME = value; IsSet_OUTCOME = true; } }
		public decimal? INCOME { get { return _INCOME; } set { _INCOME = value; IsSet_INCOME = true; } }
		public string? TAG1 { get { return _TAG1; } private set { _TAG1 = value; IsSet_TAG1 = true; } }
		public string? TAG2 { get { return _TAG2; } set { _TAG2 = value; IsSet_TAG2 = true; } }
		public string? TAG3 { get { return _TAG3; } set { _TAG3 = value; IsSet_TAG3 = true; } }
		public string? TAG4 { get { return _TAG4; } set { _TAG4 = value; IsSet_TAG4 = true; } }
		public int? ID_FILE_INPUT { get { return _ID_FILE_INPUT; } private set { _ID_FILE_INPUT = value; IsSet_ID_FILE_INPUT = true; } }
		public int? ID_BANK_STATEMENT_DESC_PATTERN { get { return _ID_BANK_STATEMENT_DESC_PATTERN; } private set { _ID_BANK_STATEMENT_DESC_PATTERN = value; IsSet_ID_BANK_STATEMENT_DESC_PATTERN = true; } }
		public DateTime? INS_DATE { get { return _INS_DATE; } internal set { _INS_DATE = value; IsSet_INS_DATE = true; } }
		public TimeSpan? INS_TIME { get { return _INS_TIME; } internal set { _INS_TIME = value; IsSet_INS_TIME = true; } }
		public string? INS_INFO { get { return _INS_INFO; } internal set { _INS_INFO = value; IsSet_INS_INFO = true; } }
		public DateTime? UPD_DATE { get { return _UPD_DATE; } internal set { _UPD_DATE = value; IsSet_UPD_DATE = true; } }
		public TimeSpan? UPD_TIME { get { return _UPD_TIME; } internal set { _UPD_TIME = value; IsSet_UPD_TIME = true; } }
		public string? UPD_INFO { get { return _UPD_INFO; } internal set { _UPD_INFO = value; IsSet_UPD_INFO = true; } }

		public void Set_TAG1(BALANCE_DIRECTION_Combo value) { TAG1 = value.Value; }

		public void Set_ID_FILE_INPUT(FILE_INPUT_Id value) { ID_FILE_INPUT = value.Value; }
		public void Set_ID_BANK_STATEMENT_DESC_PATTERN(BANK_STATEMENT_DESC_PATTERN_Id value) { ID_BANK_STATEMENT_DESC_PATTERN = value.Value; }

		private int? _ID;
		private DateTime? _OPERATION_DATE;
		private DateTime? _VALUE_DATE;
		private string? _REASON;
		private string? _DESCRIPTION;
		private decimal? _OUTCOME;
		private decimal? _INCOME;
		private string? _TAG1;
		private string? _TAG2;
		private string? _TAG3;
		private string? _TAG4;
		private int? _ID_FILE_INPUT;
		private int? _ID_BANK_STATEMENT_DESC_PATTERN;
		private DateTime? _INS_DATE;
		private TimeSpan? _INS_TIME;
		private string? _INS_INFO;
		private DateTime? _UPD_DATE;
		private TimeSpan? _UPD_TIME;
		private string? _UPD_INFO;

		public bool IsSet_ID { get; private set; }
		public bool IsSet_OPERATION_DATE { get; private set; }
		public bool IsSet_VALUE_DATE { get; private set; }
		public bool IsSet_REASON { get; private set; }
		public bool IsSet_DESCRIPTION { get; private set; }
		public bool IsSet_OUTCOME { get; private set; }
		public bool IsSet_INCOME { get; private set; }
		public bool IsSet_TAG1 { get; private set; }
		public bool IsSet_TAG2 { get; private set; }
		public bool IsSet_TAG3 { get; private set; }
		public bool IsSet_TAG4 { get; private set; }
		public bool IsSet_ID_FILE_INPUT { get; private set; }
		public bool IsSet_ID_BANK_STATEMENT_DESC_PATTERN { get; private set; }
		public bool IsSet_INS_DATE { get; private set; }
		public bool IsSet_INS_TIME { get; private set; }
		public bool IsSet_INS_INFO { get; private set; }
		public bool IsSet_UPD_DATE { get; private set; }
		public bool IsSet_UPD_TIME { get; private set; }
		public bool IsSet_UPD_INFO { get; private set; }

		public BANK_STATEMENT_NullRecord() { }

        [JsonConstructor]
        public BANK_STATEMENT_NullRecord(
			int? id, bool isSet_id,
			DateTime? operation_date, bool isSet_operation_date,
			DateTime? value_date, bool isSet_value_date,
			string? reason, bool isSet_reason,
			string? description, bool isSet_description,
			decimal? outcome, bool isSet_outcome,
			decimal? income, bool isSet_income,
			string? tag1, bool isSet_tag1,
			string? tag2, bool isSet_tag2,
			string? tag3, bool isSet_tag3,
			string? tag4, bool isSet_tag4,
			int? id_file_input, bool isSet_id_file_input,
			int? id_bank_statement_desc_pattern, bool isSet_id_bank_statement_desc_pattern,
			DateTime? ins_date, bool isSet_ins_date,
			TimeSpan? ins_time, bool isSet_ins_time,
			string? ins_info, bool isSet_ins_info,
			DateTime? upd_date, bool isSet_upd_date,
			TimeSpan? upd_time, bool isSet_upd_time,
			string? upd_info, bool isSet_upd_info) {
			if (isSet_id) ID = id;
			if (isSet_operation_date) OPERATION_DATE = operation_date;
			if (isSet_value_date) VALUE_DATE = value_date;
			if (isSet_reason) REASON = reason;
			if (isSet_description) DESCRIPTION = description;
			if (isSet_outcome) OUTCOME = outcome;
			if (isSet_income) INCOME = income;
			if (isSet_tag1) TAG1 = tag1;
			if (isSet_tag2) TAG2 = tag2;
			if (isSet_tag3) TAG3 = tag3;
			if (isSet_tag4) TAG4 = tag4;
			if (isSet_id_file_input) ID_FILE_INPUT = id_file_input;
			if (isSet_id_bank_statement_desc_pattern) ID_BANK_STATEMENT_DESC_PATTERN = id_bank_statement_desc_pattern;
			if (isSet_ins_date) INS_DATE = ins_date;
			if (isSet_ins_time) INS_TIME = ins_time;
			if (isSet_ins_info) INS_INFO = ins_info;
			if (isSet_upd_date) UPD_DATE = upd_date;
			if (isSet_upd_time) UPD_TIME = upd_time;
			if (isSet_upd_info) UPD_INFO = upd_info;
        }

		public BANK_STATEMENT_NullRecord(BANK_STATEMENT_Record record) {
			ID = record.ID;
			OPERATION_DATE = record.OPERATION_DATE;
			VALUE_DATE = record.VALUE_DATE;
			REASON = record.REASON;
			DESCRIPTION = record.DESCRIPTION;
			OUTCOME = record.OUTCOME;
			INCOME = record.INCOME;
			TAG1 = record.TAG1;
			TAG2 = record.TAG2;
			TAG3 = record.TAG3;
			TAG4 = record.TAG4;
			ID_FILE_INPUT = record.ID_FILE_INPUT;
			ID_BANK_STATEMENT_DESC_PATTERN = record.ID_BANK_STATEMENT_DESC_PATTERN;
			INS_DATE = record.INS_DATE;
			INS_TIME = record.INS_TIME;
			INS_INFO = record.INS_INFO;
			UPD_DATE = record.UPD_DATE;
			UPD_TIME = record.UPD_TIME;
			UPD_INFO = record.UPD_INFO;
		}

		public BANK_STATEMENT_NullRecord(BANK_STATEMENT_IdRecord record) {
			ID = record.ID;
			OPERATION_DATE = record.OPERATION_DATE;
			VALUE_DATE = record.VALUE_DATE;
			REASON = record.REASON;
			DESCRIPTION = record.DESCRIPTION;
			OUTCOME = record.OUTCOME;
			INCOME = record.INCOME;
			TAG1 = record.TAG1;
			TAG2 = record.TAG2;
			TAG3 = record.TAG3;
			TAG4 = record.TAG4;
			ID_FILE_INPUT = record.ID_FILE_INPUT;
			ID_BANK_STATEMENT_DESC_PATTERN = record.ID_BANK_STATEMENT_DESC_PATTERN;
		}
	}
}
