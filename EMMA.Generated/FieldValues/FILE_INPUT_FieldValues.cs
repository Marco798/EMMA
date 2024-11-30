using EMMA.Commons;

namespace EMMA_BE.Generated {
    public static class FILE_INPUT_FieldValues {
		public static readonly FILE_INPUT_Field ID = new("[ID]");
		public static readonly FILE_INPUT_Field FILE_NAME = new("[FILE_NAME]");
		public static readonly FILE_INPUT_Field FILE_TYPE = new("[FILE_TYPE]");
		public static readonly FILE_INPUT_Field FILE_CATEGORY = new("[FILE_CATEGORY]");
		public static readonly FILE_INPUT_Field CONTENT = new("[CONTENT]");
		public static readonly FILE_INPUT_Field INS_DATE = new("[INS_DATE]");
		public static readonly FILE_INPUT_Field INS_TIME = new("[INS_TIME]");
		public static readonly FILE_INPUT_Field INS_INFO = new("[INS_INFO]");

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
