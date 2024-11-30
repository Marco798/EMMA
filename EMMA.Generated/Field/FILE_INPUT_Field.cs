using EMMA.Commons;
using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
    public class FILE_INPUT_Field : FieldBase, IField {
        [JsonConstructor]
        internal FILE_INPUT_Field(string value) : base(value) { }

        public override bool Equals(object? obj) {
            return obj is BANK_STATEMENT_Field field &&
                   Value == field.Value;
        }

        public override int GetHashCode() {
            return HashCode.Combine(Value);
        }
    }
}