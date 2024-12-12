using EMMA.Commons;
using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class DIRECTION_Combo : ComboBase {
        [JsonConstructor]
		internal DIRECTION_Combo(string value) : base(value) {
            if (value != string.Empty && !DIRECTION_ComboValues.GetValues().Contains(value))
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
