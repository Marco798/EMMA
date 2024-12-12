using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace EMMA_BE.Generated {
	public static class FILE_CATEGORY_ComboValues {

		public static readonly FILE_CATEGORY_Combo BANK_STATEMENT = new("BANKSTAT");
		public const string _BANK_STATEMENT = "BANKSTAT";

        public static FILE_CATEGORY_Combo GetCombo(ChangeEventArgs? changeEventArgs) {
            string value = changeEventArgs?.Value?.ToString() ?? string.Empty;
            CheckInputValue(value);
            return new(value);
        }

        private static void CheckInputValue(string value) {
            if (value != string.Empty && !GetValues().Contains(value))
                throw new Exception();
        }

        public static string[] GetNames() {
            return typeof(FILE_CATEGORY_Combo).GetFields(BindingFlags.Public | BindingFlags.Static).Select(f => f.Name).ToArray();
        }

        public static List<FILE_CATEGORY_Combo> GetItems() {
            return [
                BANK_STATEMENT
            ];
        }

        public static HashSet<string> GetValues() {
            return [
                _BANK_STATEMENT
            ];
        }

        public static string GetName(string value) {
            return value switch {
                "BANKSTAT" => nameof(BANK_STATEMENT),
                _ => throw new Exception(),
            };
        }
	}

}
