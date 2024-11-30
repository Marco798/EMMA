using EMMA.Commons;

namespace EMMA_BE.Generated {
    public static class BANK_STATEMENT_PATTERN_FieldValues {
		public static readonly BANK_STATEMENT_PATTERN_Field ID = new("[ID]");
		public static readonly BANK_STATEMENT_PATTERN_Field FIELD = new("[FIELD]");
		public static readonly BANK_STATEMENT_PATTERN_Field ORIGINAL_VALUE = new("[ORIGINAL_VALUE]");
		public static readonly BANK_STATEMENT_PATTERN_Field PATTERN = new("[PATTERN]");
		public static readonly BANK_STATEMENT_PATTERN_Field POSITION = new("[POSITION]");

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
