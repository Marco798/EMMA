using System.Text.Json.Serialization;

namespace EMMA.Commons {
    public class ComboBase {
        [JsonInclude]
        public readonly string Value;

        protected ComboBase(string value) {
            Value = value;
        }
    }
}