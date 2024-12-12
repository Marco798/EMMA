using EMMA.Commons;
using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class PATTERN_POSITION_Combo : ComboBase {
        [JsonConstructor]
		internal PATTERN_POSITION_Combo(string value) : base(value) {
            if (value != string.Empty && !PATTERN_POSITION_ComboValues.GetValues().Contains(value))
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
