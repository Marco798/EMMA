using System.Text.Json.Serialization;

namespace EMMA.Commons {
    public class ComboBase {
        [JsonInclude]
        public readonly string Value;

        protected ComboBase(string value) {
            Value = value;
        }

        public override bool Equals(object? obj) {
            return obj is ComboBase comboBase &&
                   Value == comboBase.Value;
        }

        public override int GetHashCode() {
            return HashCode.Combine(Value);
        }
    }
}