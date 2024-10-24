using EMMA.Commons;

namespace EMMA_BE.Generated {
    public class BANK_STATEMENT_Field : FieldBase, IField {
        internal BANK_STATEMENT_Field(string value) : base(value) { }

		public static readonly BANK_STATEMENT_Field ID = new("[BANK_STATEMENT.ID]");
		public static readonly BANK_STATEMENT_Field OPERATION_DATE = new("[BANK_STATEMENT.OPERATION_DATE]");
		public static readonly BANK_STATEMENT_Field VALUE_DATE = new("[BANK_STATEMENT.VALUE_DATE]");
		public static readonly BANK_STATEMENT_Field REASON = new("[BANK_STATEMENT.REASON]");
		public static readonly BANK_STATEMENT_Field DESCRIPTION = new("[BANK_STATEMENT.DESCRIPTION]");
		public static readonly BANK_STATEMENT_Field OUTCOME = new("[BANK_STATEMENT.OUTCOME]");
		public static readonly BANK_STATEMENT_Field INCOME = new("[BANK_STATEMENT.INCOME]");
		public static readonly BANK_STATEMENT_Field TAG1 = new("[BANK_STATEMENT.TAG1]");
		public static readonly BANK_STATEMENT_Field TAG2 = new("[BANK_STATEMENT.TAG2]");
		public static readonly BANK_STATEMENT_Field TAG3 = new("[BANK_STATEMENT.TAG3]");
		public static readonly BANK_STATEMENT_Field TAG4 = new("[BANK_STATEMENT.TAG4]");
		public static readonly BANK_STATEMENT_Field ID_FILE_INPUT = new("[BANK_STATEMENT.ID_FILE_INPUT]");
		public static readonly BANK_STATEMENT_Field ID_BANK_STATEMENT_DESC_PATTERN = new("[BANK_STATEMENT.ID_BANK_STATEMENT_DESC_PATTERN]");
		public static readonly BANK_STATEMENT_Field INS_DATE = new("[BANK_STATEMENT.INS_DATE]");
		public static readonly BANK_STATEMENT_Field INS_TIME = new("[BANK_STATEMENT.INS_TIME]");
		public static readonly BANK_STATEMENT_Field INS_INFO = new("[BANK_STATEMENT.INS_INFO]");
		public static readonly BANK_STATEMENT_Field UPD_DATE = new("[BANK_STATEMENT.UPD_DATE]");
		public static readonly BANK_STATEMENT_Field UPD_TIME = new("[BANK_STATEMENT.UPD_TIME]");
		public static readonly BANK_STATEMENT_Field UPD_INFO = new("[BANK_STATEMENT.UPD_INFO]");

        public static List<BANK_STATEMENT_Field> GetAllFields() {
            return [
                ID,
                OPERATION_DATE,
                VALUE_DATE,
                REASON,
                DESCRIPTION,
                OUTCOME,
                INCOME,
                TAG1,
                TAG2,
                TAG3,
                TAG4,
                ID_FILE_INPUT,
                ID_BANK_STATEMENT_DESC_PATTERN,
                INS_DATE,
                INS_TIME,
                INS_INFO,
                UPD_DATE,
                UPD_TIME,
                UPD_INFO
            ];
        }
    }
}
