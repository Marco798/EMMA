using EMMA.Commons;

namespace EMMA_BE.Generated {
    public class SYST_COMBO_VALUE_Field : FieldBase, IField {
        internal SYST_COMBO_VALUE_Field(string value) : base(value) { }

		public static readonly SYST_COMBO_VALUE_Field ID = new("[SYST_COMBO_VALUE.ID]");
		public static readonly SYST_COMBO_VALUE_Field NAME = new("[SYST_COMBO_VALUE.NAME]");
		public static readonly SYST_COMBO_VALUE_Field VALUE = new("[SYST_COMBO_VALUE.VALUE]");
		public static readonly SYST_COMBO_VALUE_Field COMBO = new("[SYST_COMBO_VALUE.COMBO]");

        public static List<SYST_COMBO_VALUE_Field> GetAllFields() {
            return [
                ID,
                NAME,
                VALUE,
                COMBO
            ];
        }
    }
}
