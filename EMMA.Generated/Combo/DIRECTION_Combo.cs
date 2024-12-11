using EMMA.Commons;
using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class DIRECTION_Combo : ComboBase {
        [JsonConstructor]
		public DIRECTION_Combo(string value) : base(value) {
            if (value != string.Empty && !DIRECTION_ComboValues.GetValues().Contains(value))
                throw new Exception();
		}
	}
}
