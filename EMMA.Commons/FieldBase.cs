using System.Text.Json.Serialization;

namespace EMMA.Commons {
    public class FieldBase {
        public string Value { get; private set; }

        [JsonConstructor]
        protected FieldBase(string value) {
            Value = value;
        }
    }
}