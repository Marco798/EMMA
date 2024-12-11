using EMMA.Commons;
using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class MONTH_Combo : ComboBase {
        [JsonConstructor]
		public MONTH_Combo(string value) : base(value) {
            if (value != string.Empty && !MONTH_ComboValues.GetValues().Contains(value))
                throw new Exception();
		}
	}
}
