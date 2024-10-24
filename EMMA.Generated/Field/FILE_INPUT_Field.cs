using EMMA.Commons;

namespace EMMA_BE.Generated {
    public class FILE_INPUT_Field : FieldBase, IField {
        internal FILE_INPUT_Field(string value) : base(value) { }

		public static readonly FILE_INPUT_Field ID = new("[FILE_INPUT.ID]");
		public static readonly FILE_INPUT_Field FILE_NAME = new("[FILE_INPUT.FILE_NAME]");
		public static readonly FILE_INPUT_Field FILE_TYPE = new("[FILE_INPUT.FILE_TYPE]");
		public static readonly FILE_INPUT_Field FILE_CATEGORY = new("[FILE_INPUT.FILE_CATEGORY]");
		public static readonly FILE_INPUT_Field CONTENT = new("[FILE_INPUT.CONTENT]");
		public static readonly FILE_INPUT_Field INS_DATE = new("[FILE_INPUT.INS_DATE]");
		public static readonly FILE_INPUT_Field INS_TIME = new("[FILE_INPUT.INS_TIME]");
		public static readonly FILE_INPUT_Field INS_INFO = new("[FILE_INPUT.INS_INFO]");

        public static List<FILE_INPUT_Field> GetAllFields() {
            return [
                ID,
                FILE_NAME,
                FILE_TYPE,
                FILE_CATEGORY,
                CONTENT,
                INS_DATE,
                INS_TIME,
                INS_INFO
            ];
        }
    }
}
