using System;

namespace EditorDB.Classes {
	public class ComboValueData {
		public int Index { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }

		public ComboValueData() { }

		public ComboValueData(int index) {
			Index = index;
			Name = string.Empty;
			Value = string.Empty;
		}

		public ComboValueData Clone() {
			return new ComboValueData() {
				Index = Index,
				Name = Name,
				Value = Value
			};
		}

		public override bool Equals(object? obj) {
			return obj is ComboValueData data &&
				   Index == data.Index &&
				   Name == data.Name &&
				   Value == data.Value;
		}

		public override int GetHashCode() {
			HashCode hash = new();
			hash.Add(Index);
			hash.Add(Name);
			hash.Add(Value);
			return hash.ToHashCode();
		}
	}
}
