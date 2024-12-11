using EMMA.Commons;
using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class DAY_OF_WEEK_Combo : ComboBase {
        [JsonConstructor]
		public DAY_OF_WEEK_Combo(string value) : base(value) {
            if (value != string.Empty && !DAY_OF_WEEK_ComboValues.GetValues().Contains(value))
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
