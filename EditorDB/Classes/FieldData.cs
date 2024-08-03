using EditorDB.Components.Pages.Table.Common.Create;
using System;
using static EditorDB.Classes.BusinessValues.BV_DataType;
using System.Data.SqlTypes;
using System.Reflection;
using System.Xml.Linq;

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

		public FieldData() { }

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

		public FieldData Clone() {
			return new FieldData() {
				Index = Index,
				Enabled = Enabled,
				Name = Name,
				Nullable = Nullable,
				Category = Category,
				Type = Type,
				Length = Length,
				IntegerDigits = IntegerDigits,
				DecimalDigits = DecimalDigits
			};
		}

		public override bool Equals(object? obj) {
			return obj is FieldData data &&
				   Index == data.Index &&
				   Enabled == data.Enabled &&
				   Name == data.Name &&
				   Nullable == data.Nullable &&
				   Category == data.Category &&
				   Type == data.Type &&
				   Length == data.Length &&
				   IntegerDigits == data.IntegerDigits &&
				   DecimalDigits == data.DecimalDigits;
		}

		public override int GetHashCode() {
			HashCode hash = new HashCode();
			hash.Add(Index);
			hash.Add(Enabled);
			hash.Add(Name);
			hash.Add(Nullable);
			hash.Add(Category);
			hash.Add(Type);
			hash.Add(Length);
			hash.Add(IntegerDigits);
			hash.Add(DecimalDigits);
			return hash.ToHashCode();
		}
	}
}
