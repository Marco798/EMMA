using EMMA.Commons;

namespace EMMA_BE.Generated {
    public static class BANK_STATEMENT_FieldValues {
		public static readonly BANK_STATEMENT_Field ID = new("[ID]");
		public static readonly BANK_STATEMENT_Field OPERATION_DATE = new("[OPERATION_DATE]");
		public static readonly BANK_STATEMENT_Field VALUE_DATE = new("[VALUE_DATE]");
		public static readonly BANK_STATEMENT_Field REASON = new("[REASON]");
		public static readonly BANK_STATEMENT_Field DESCRIPTION = new("[DESCRIPTION]");
		public static readonly BANK_STATEMENT_Field OUTCOME = new("[OUTCOME]");
		public static readonly BANK_STATEMENT_Field INCOME = new("[INCOME]");
		public static readonly BANK_STATEMENT_Field TAG1 = new("[TAG1]");
		public static readonly BANK_STATEMENT_Field TAG2 = new("[TAG2]");
		public static readonly BANK_STATEMENT_Field TAG3 = new("[TAG3]");
		public static readonly BANK_STATEMENT_Field TAG4 = new("[TAG4]");
		public static readonly BANK_STATEMENT_Field ID_FILE_INPUT = new("[ID_FILE_INPUT]");
		public static readonly BANK_STATEMENT_Field ID_BANK_STATEMENT_DESC_PATTERN = new("[ID_BANK_STATEMENT_DESC_PATTERN]");
		public static readonly BANK_STATEMENT_Field INS_DATE = new("[INS_DATE]");
		public static readonly BANK_STATEMENT_Field INS_TIME = new("[INS_TIME]");
		public static readonly BANK_STATEMENT_Field INS_INFO = new("[INS_INFO]");
		public static readonly BANK_STATEMENT_Field UPD_DATE = new("[UPD_DATE]");
		public static readonly BANK_STATEMENT_Field UPD_TIME = new("[UPD_TIME]");
		public static readonly BANK_STATEMENT_Field UPD_INFO = new("[UPD_INFO]");

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
