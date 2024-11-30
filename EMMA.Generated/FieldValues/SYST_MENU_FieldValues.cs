using EMMA.Commons;

namespace EMMA_BE.Generated {
    public static class SYST_MENU_FieldValues {
		public static readonly SYST_MENU_Field ID = new("[ID]");
		public static readonly SYST_MENU_Field NAME = new("[NAME]");
		public static readonly SYST_MENU_Field PARENT = new("[PARENT]");
		public static readonly SYST_MENU_Field DESCRIPTION = new("[DESCRIPTION]");
		public static readonly SYST_MENU_Field SHORT_DESCRIPTION = new("[SHORT_DESCRIPTION]");
		public static readonly SYST_MENU_Field INDEX = new("[INDEX]");

        public static List<SYST_MENU_Field> GetAllFields() {
            return [
                ID,
                NAME,
                PARENT,
                DESCRIPTION,
                SHORT_DESCRIPTION,
                INDEX
            ];
        }
    }
}
