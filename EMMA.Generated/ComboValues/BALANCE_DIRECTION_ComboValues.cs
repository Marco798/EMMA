using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace EMMA_BE.Generated {
	public static class BALANCE_DIRECTION_ComboValues {

		public static readonly BALANCE_DIRECTION_Combo INCOME = new("I");
		public const string _INCOME = "I";

		public static readonly BALANCE_DIRECTION_Combo OUTCOME = new("O");
		public const string _OUTCOME = "O";

        public static BALANCE_DIRECTION_Combo GetCombo(ChangeEventArgs? changeEventArgs) {
            string value = changeEventArgs?.Value?.ToString() ?? string.Empty;
            CheckInputValue(value);
            return new(value);
        }

        private static void CheckInputValue(string value) {
            if (value != string.Empty && !GetValues().Contains(value))
                throw new Exception();
        }

        public static string[] GetNames() {
            return typeof(BALANCE_DIRECTION_Combo).GetFields(BindingFlags.Public | BindingFlags.Static).Select(f => f.Name).ToArray();
        }

        public static List<BALANCE_DIRECTION_Combo> GetItems() {
            return [
                INCOME,
                OUTCOME
            ];
        }

        public static HashSet<string> GetValues() {
            return [
                _INCOME,
                _OUTCOME
            ];
        }

        public static string GetName(string value) {
            return value switch {
                "I" => nameof(INCOME),
                "O" => nameof(OUTCOME),
                _ => throw new Exception(),
            };
        }
	}

}