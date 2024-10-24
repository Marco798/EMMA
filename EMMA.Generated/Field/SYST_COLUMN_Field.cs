using EMMA.Commons;

namespace EMMA_BE.Generated {
    public class SYST_COLUMN_Field : FieldBase, IField {
        internal SYST_COLUMN_Field(string value) : base(value) { }

		public static readonly SYST_COLUMN_Field ID = new("[SYST_COLUMN.ID]");
		public static readonly SYST_COLUMN_Field TABLE_NAME = new("[SYST_COLUMN.TABLE_NAME]");
		public static readonly SYST_COLUMN_Field COLUMN_NAME = new("[SYST_COLUMN.COLUMN_NAME]");
		public static readonly SYST_COLUMN_Field DESCRIPTION = new("[SYST_COLUMN.DESCRIPTION]");
		public static readonly SYST_COLUMN_Field SHORT_DESCRIPTION = new("[SYST_COLUMN.SHORT_DESCRIPTION]");
		public static readonly SYST_COLUMN_Field COMBO = new("[SYST_COLUMN.COMBO]");
		public static readonly SYST_COLUMN_Field EXTERNAL_TABLE_ID = new("[SYST_COLUMN.EXTERNAL_TABLE_ID]");

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
