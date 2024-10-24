using EMMA.Commons;

namespace EMMA_BE.Generated {
    public class BANK_STATEMENT_DESC_PATTERN_Field : FieldBase, IField {
        internal BANK_STATEMENT_DESC_PATTERN_Field(string value) : base(value) { }

		public static readonly BANK_STATEMENT_DESC_PATTERN_Field ID = new("[BANK_STATEMENT_DESC_PATTERN.ID]");
		public static readonly BANK_STATEMENT_DESC_PATTERN_Field PATTERN = new("[BANK_STATEMENT_DESC_PATTERN.PATTERN]");
		public static readonly BANK_STATEMENT_DESC_PATTERN_Field DESCRIPTION = new("[BANK_STATEMENT_DESC_PATTERN.DESCRIPTION]");
		public static readonly BANK_STATEMENT_DESC_PATTERN_Field INS_DATE = new("[BANK_STATEMENT_DESC_PATTERN.INS_DATE]");
		public static readonly BANK_STATEMENT_DESC_PATTERN_Field INS_TIME = new("[BANK_STATEMENT_DESC_PATTERN.INS_TIME]");
		public static readonly BANK_STATEMENT_DESC_PATTERN_Field INS_INFO = new("[BANK_STATEMENT_DESC_PATTERN.INS_INFO]");

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
