using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace EMMA_BE.Generated {
	public static class DIRECTION_ComboValues {

		public static readonly DIRECTION_Combo INPUT = new("I");
		public const string _INPUT = "I";

		public static readonly DIRECTION_Combo OUTPUT = new("O");
		public const string _OUTPUT = "O";

        public static DIRECTION_Combo GetCombo(ChangeEventArgs? changeEventArgs) {
            string value = changeEventArgs?.Value?.ToString() ?? string.Empty;
            CheckInputValue(value);
            return new(value);
        }

        private static void CheckInputValue(string value) {
            if (value != string.Empty && !GetValues().Contains(value))
                throw new Exception();
        }

        public static string[] GetNames() {
            return typeof(DIRECTION_Combo).GetFields(BindingFlags.Public | BindingFlags.Static).Select(f => f.Name).ToArray();
        }

        public static List<DIRECTION_Combo> GetItems() {
            return [
                INPUT,
                OUTPUT
            ];
        }

        public static HashSet<string> GetValues() {
            return [
                _INPUT,
                _OUTPUT
            ];
        }

        public static string GetName(string value) {
            return value switch {
                "I" => nameof(INPUT),
                "O" => nameof(OUTPUT),
                _ => throw new Exception(),
            };
        }
	}

}
