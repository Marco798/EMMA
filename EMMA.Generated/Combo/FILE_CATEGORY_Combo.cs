using EMMA.Commons;
using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class FILE_CATEGORY_Combo : ComboBase {
        [JsonConstructor]
		internal FILE_CATEGORY_Combo(string value) : base(value) {
            if (value != string.Empty && !FILE_CATEGORY_ComboValues.GetValues().Contains(value))
                throw new Exception();
		}

        public override bool Equals(object? obj) {
            return base.Equals(obj);
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }
	}
}
