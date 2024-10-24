using EMMA.Commons;

namespace EMMA_BE.Generated {
    public class BANK_STATEMENT_PATTERN_Field : FieldBase, IField {
        internal BANK_STATEMENT_PATTERN_Field(string value) : base(value) { }

		public static readonly BANK_STATEMENT_PATTERN_Field ID = new("[BANK_STATEMENT_PATTERN.ID]");
		public static readonly BANK_STATEMENT_PATTERN_Field FIELD = new("[BANK_STATEMENT_PATTERN.FIELD]");
		public static readonly BANK_STATEMENT_PATTERN_Field ORIGINAL_VALUE = new("[BANK_STATEMENT_PATTERN.ORIGINAL_VALUE]");
		public static readonly BANK_STATEMENT_PATTERN_Field PATTERN = new("[BANK_STATEMENT_PATTERN.PATTERN]");
		public static readonly BANK_STATEMENT_PATTERN_Field POSITION = new("[BANK_STATEMENT_PATTERN.POSITION]");

        public static List<BANK_STATEMENT_PATTERN_Field> GetAllFields() {
            return [
                ID,
                FIELD,
                ORIGINAL_VALUE,
                PATTERN,
                POSITION
            ];
        }
    }
}
