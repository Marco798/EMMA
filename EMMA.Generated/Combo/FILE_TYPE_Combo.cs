using EMMA.Commons;

namespace EMMA_BE.Generated {
	public class FILE_TYPE_Combo : ComboBase {
		internal FILE_TYPE_Combo(string value) : base(value) { }

		public static readonly FILE_TYPE_Combo CSV = new("CSV");

		public static readonly FILE_TYPE_Combo TEXT = new("TEXT");

		public static readonly FILE_TYPE_Combo EXCEL = new("EXCEL");
	}

}
