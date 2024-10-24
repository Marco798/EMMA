using EMMA.Commons;

namespace EMMA_BE.Generated {
    public class SYST_COMBO_Field : FieldBase, IField {
        internal SYST_COMBO_Field(string value) : base(value) { }

		public static readonly SYST_COMBO_Field ID = new("[SYST_COMBO.ID]");
		public static readonly SYST_COMBO_Field NAME = new("[SYST_COMBO.NAME]");
		public static readonly SYST_COMBO_Field TYPE = new("[SYST_COMBO.TYPE]");

        public static List<SYST_COMBO_Field> GetAllFields() {
            return [
                ID,
                NAME,
                TYPE
            ];
        }
    }
}
