using EMMA.Commons;
using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class BALANCE_DIRECTION_Combo : ComboBase {
        [JsonConstructor]
		public BALANCE_DIRECTION_Combo(string value) : base(value) {
            if (value != string.Empty && !BALANCE_DIRECTION_ComboValues.GetValues().Contains(value))
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
