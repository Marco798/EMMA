using EMMA.Commons;

namespace EMMA_BE.Generated {
    public static class SYST_COLUMN_FieldValues {
		public static readonly SYST_COLUMN_Field ID = new("[ID]");
		public static readonly SYST_COLUMN_Field TABLE_NAME = new("[TABLE_NAME]");
		public static readonly SYST_COLUMN_Field COLUMN_NAME = new("[COLUMN_NAME]");
		public static readonly SYST_COLUMN_Field DESCRIPTION = new("[DESCRIPTION]");
		public static readonly SYST_COLUMN_Field SHORT_DESCRIPTION = new("[SHORT_DESCRIPTION]");
		public static readonly SYST_COLUMN_Field COMBO = new("[COMBO]");
		public static readonly SYST_COLUMN_Field EXTERNAL_TABLE_ID = new("[EXTERNAL_TABLE_ID]");

        public static List<SYST_COLUMN_Field> GetAllFields() {
            return [
                ID,
                TABLE_NAME,
                COLUMN_NAME,
                DESCRIPTION,
                SHORT_DESCRIPTION,
                COMBO,
                EXTERNAL_TABLE_ID
            ];
        }
    }
}
