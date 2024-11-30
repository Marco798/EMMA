using EMMA.Commons;

namespace EMMA_BE.Generated {
    public static class BANK_STATEMENT_DESC_PATTERN_FieldValues {
		public static readonly BANK_STATEMENT_DESC_PATTERN_Field ID = new("[ID]");
		public static readonly BANK_STATEMENT_DESC_PATTERN_Field PATTERN = new("[PATTERN]");
		public static readonly BANK_STATEMENT_DESC_PATTERN_Field DESCRIPTION = new("[DESCRIPTION]");
		public static readonly BANK_STATEMENT_DESC_PATTERN_Field INS_DATE = new("[INS_DATE]");
		public static readonly BANK_STATEMENT_DESC_PATTERN_Field INS_TIME = new("[INS_TIME]");
		public static readonly BANK_STATEMENT_DESC_PATTERN_Field INS_INFO = new("[INS_INFO]");

        public static List<BANK_STATEMENT_DESC_PATTERN_Field> GetAllFields() {
            return [
                ID,
                PATTERN,
                DESCRIPTION,
                INS_DATE,
                INS_TIME,
                INS_INFO
            ];
        }
    }
}
