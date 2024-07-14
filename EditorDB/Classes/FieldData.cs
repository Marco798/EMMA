namespace EditorDB.Classes {
	public class FieldData {
		public int Index { get; set; }
		public bool Enabled { get; set; }
		public string Name { get; set; }
		public bool Nullable { get; set; }
		public string Category { get; set; }
		public string Type { get; set; }
		public int? Length { get; set; }
		public int? IntegerDigits { get; set; }
		public int? DecimalDigits { get; set; }

		public FieldData(int index) {
			Index = index;
			Enabled = true;
			Name = string.Empty;
			Nullable = true;
			Category = string.Empty;
			Type = string.Empty;
			Length = null;
			IntegerDigits = null;
			DecimalDigits = null;
		}

        public FieldData(int index, string name, bool nullable, string category, string type, int? length = null) {
			Index = index;
			Enabled = true;
			Name = name.ToUpper();
			Nullable = nullable;
			Category = category;
            Type = type;
			Length = length;
			IntegerDigits = null;
			DecimalDigits = null;
		}
	}
}
