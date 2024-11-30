using EMMA.Commons;

namespace EMMA_BE.Generated {
    public static class SYST_TABLE_FieldValues {
		public static readonly SYST_TABLE_Field ID = new("[ID]");
		public static readonly SYST_TABLE_Field TABLE_NAME = new("[TABLE_NAME]");
		public static readonly SYST_TABLE_Field DESCRIPTION = new("[DESCRIPTION]");
		public static readonly SYST_TABLE_Field SHORT_DESCRIPTION = new("[SHORT_DESCRIPTION]");

        public static List<SYST_TABLE_Field> GetAllFields() {
            return [
                ID,
                TABLE_NAME,
                DESCRIPTION,
                SHORT_DESCRIPTION
            ];
        }
    }
}
