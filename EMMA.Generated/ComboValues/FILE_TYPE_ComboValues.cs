using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace EMMA_BE.Generated {
	public static class FILE_TYPE_ComboValues {

		public static readonly FILE_TYPE_Combo CSV = new("CSV");
		public const string _CSV = "CSV";

		public static readonly FILE_TYPE_Combo TEXT = new("TEXT");
		public const string _TEXT = "TEXT";

		public static readonly FILE_TYPE_Combo EXCEL = new("EXCEL");
		public const string _EXCEL = "EXCEL";

        public static FILE_TYPE_Combo GetCombo(ChangeEventArgs? changeEventArgs) {
            string value = changeEventArgs?.Value?.ToString() ?? string.Empty;
            CheckInputValue(value);
            return new(value);
        }

        private static void CheckInputValue(string value) {
            if (value != string.Empty && !GetValues().Contains(value))
                throw new Exception();
        }

        public static string[] GetNames() {
            return typeof(FILE_TYPE_Combo).GetFields(BindingFlags.Public | BindingFlags.Static).Select(f => f.Name).ToArray();
        }

        public static List<FILE_TYPE_Combo> GetItems() {
            return [
                CSV,
                TEXT,
                EXCEL
            ];
        }

        public static HashSet<string> GetValues() {
            return [
                _CSV,
                _TEXT,
                _EXCEL
            ];
        }

        public static string GetName(string value) {
            return value switch {
                "CSV" => nameof(CSV),
                "TEXT" => nameof(TEXT),
                "EXCEL" => nameof(EXCEL),
                _ => throw new Exception(),
            };
        }
	}

}
