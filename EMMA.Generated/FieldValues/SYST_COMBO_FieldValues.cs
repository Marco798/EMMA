using EMMA.Commons;

namespace EMMA_BE.Generated {
    public static class SYST_COMBO_FieldValues {
		public static readonly SYST_COMBO_Field ID = new("[ID]");
		public static readonly SYST_COMBO_Field NAME = new("[NAME]");
		public static readonly SYST_COMBO_Field TYPE = new("[TYPE]");

        public static List<SYST_COMBO_Field> GetAllFields() {
            return [
                ID,
                NAME,
                TYPE
            ];
        }
    }
}
