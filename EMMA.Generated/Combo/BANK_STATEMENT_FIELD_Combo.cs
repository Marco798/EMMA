using EMMA.Commons;
using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class BANK_STATEMENT_FIELD_Combo : ComboBase {
        [JsonConstructor]
		public BANK_STATEMENT_FIELD_Combo(string value) : base(value) {
            if (value != string.Empty && !BANK_STATEMENT_FIELD_ComboValues.GetValues().Contains(value))
                throw new Exception();
		}
	}
}
