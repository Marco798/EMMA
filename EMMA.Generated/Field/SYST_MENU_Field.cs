using EMMA.Commons;

namespace EMMA_BE.Generated {
    public class SYST_MENU_Field : FieldBase, IField {
        internal SYST_MENU_Field(string value) : base(value) { }

		public static readonly SYST_MENU_Field ID = new("[SYST_MENU.ID]");
		public static readonly SYST_MENU_Field NAME = new("[SYST_MENU.NAME]");
		public static readonly SYST_MENU_Field PARENT = new("[SYST_MENU.PARENT]");
		public static readonly SYST_MENU_Field DESCRIPTION = new("[SYST_MENU.DESCRIPTION]");
		public static readonly SYST_MENU_Field SHORT_DESCRIPTION = new("[SYST_MENU.SHORT_DESCRIPTION]");
		public static readonly SYST_MENU_Field INDEX = new("[SYST_MENU.INDEX]");

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
