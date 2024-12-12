using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace EMMA_BE.Generated {
	public static class BANK_STATEMENT_FIELD_ComboValues {

		public static readonly BANK_STATEMENT_FIELD_Combo REASON = new("REAS");
		public const string _REASON = "REAS";

		public static readonly BANK_STATEMENT_FIELD_Combo DESCRIPTION = new("DESC");
		public const string _DESCRIPTION = "DESC";

		public static readonly BANK_STATEMENT_FIELD_Combo TAG2 = new("TAG2");
		public const string _TAG2 = "TAG2";

		public static readonly BANK_STATEMENT_FIELD_Combo TAG3 = new("TAG3");
		public const string _TAG3 = "TAG3";

		public static readonly BANK_STATEMENT_FIELD_Combo TAG4 = new("TAG4");
		public const string _TAG4 = "TAG4";

        public static BANK_STATEMENT_FIELD_Combo GetCombo(ChangeEventArgs? changeEventArgs) {
            string value = changeEventArgs?.Value?.ToString() ?? string.Empty;
            CheckInputValue(value);
            return new(value);
        }

        private static void CheckInputValue(string value) {
            if (value != string.Empty && !GetValues().Contains(value))
                throw new Exception();
        }

        public static string[] GetNames() {
            return typeof(BANK_STATEMENT_FIELD_Combo).GetFields(BindingFlags.Public | BindingFlags.Static).Select(f => f.Name).ToArray();
        }

        public static List<BANK_STATEMENT_FIELD_Combo> GetItems() {
            return [
                REASON,
                DESCRIPTION,
                TAG2,
                TAG3,
                TAG4
            ];
        }

        public static HashSet<string> GetValues() {
            return [
                _REASON,
                _DESCRIPTION,
                _TAG2,
                _TAG3,
                _TAG4
            ];
        }

        public static string GetName(string value) {
            return value switch {
                "REAS" => nameof(REASON),
                "DESC" => nameof(DESCRIPTION),
                "TAG2" => nameof(TAG2),
                "TAG3" => nameof(TAG3),
                "TAG4" => nameof(TAG4),
                _ => throw new Exception(),
            };
        }
	}

}
