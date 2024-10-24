using EMMA.Commons;

namespace EMMA_BE.Generated {
    public class SYST_TABLE_Field : FieldBase, IField {
        internal SYST_TABLE_Field(string value) : base(value) { }

		public static readonly SYST_TABLE_Field ID = new("[SYST_TABLE.ID]");
		public static readonly SYST_TABLE_Field TABLE_NAME = new("[SYST_TABLE.TABLE_NAME]");
		public static readonly SYST_TABLE_Field DESCRIPTION = new("[SYST_TABLE.DESCRIPTION]");
		public static readonly SYST_TABLE_Field SHORT_DESCRIPTION = new("[SYST_TABLE.SHORT_DESCRIPTION]");

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
