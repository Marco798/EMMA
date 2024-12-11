using EMMA.Commons;
using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class FILE_TYPE_Combo : ComboBase {
        [JsonConstructor]
		public FILE_TYPE_Combo(string value) : base(value) {
            if (value != string.Empty && !FILE_TYPE_ComboValues.GetValues().Contains(value))
                throw new Exception();
		}
	}
}
