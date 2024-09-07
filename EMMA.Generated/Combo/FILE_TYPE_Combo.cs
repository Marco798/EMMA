namespace EMMA_BE.Generated {
	public class FILE_TYPE_Combo {
		public readonly string Value;

		private FILE_TYPE_Combo(string value) {
			Value = value;
		}

		public static readonly FILE_TYPE_Combo CSV = new("CSV");

		public static readonly FILE_TYPE_Combo TEXT = new("TEXT");

		public static readonly FILE_TYPE_Combo EXCEL = new("EXCEL");
	}

}
