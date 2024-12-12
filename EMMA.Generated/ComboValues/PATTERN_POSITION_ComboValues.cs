using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace EMMA_BE.Generated {
	public static class PATTERN_POSITION_ComboValues {

		public static readonly PATTERN_POSITION_Combo START = new("S");
		public const string _START = "S";

		public static readonly PATTERN_POSITION_Combo END = new("E");
		public const string _END = "E";

		public static readonly PATTERN_POSITION_Combo MIDDLE = new("M");
		public const string _MIDDLE = "M";

		public static readonly PATTERN_POSITION_Combo ALL = new("A");
		public const string _ALL = "A";

        public static PATTERN_POSITION_Combo GetCombo(ChangeEventArgs? changeEventArgs) {
            string value = changeEventArgs?.Value?.ToString() ?? string.Empty;
            CheckInputValue(value);
            return new(value);
        }

        private static void CheckInputValue(string value) {
            if (value != string.Empty && !GetValues().Contains(value))
                throw new Exception();
        }

        public static string[] GetNames() {
            return typeof(PATTERN_POSITION_Combo).GetFields(BindingFlags.Public | BindingFlags.Static).Select(f => f.Name).ToArray();
        }

        public static List<PATTERN_POSITION_Combo> GetItems() {
            return [
                START,
                END,
                MIDDLE,
                ALL
            ];
        }

        public static HashSet<string> GetValues() {
            return [
                _START,
                _END,
                _MIDDLE,
                _ALL
            ];
        }

        public static string GetName(string value) {
            return value switch {
                "S" => nameof(START),
                "E" => nameof(END),
                "M" => nameof(MIDDLE),
                "A" => nameof(ALL),
                _ => throw new Exception(),
            };
        }
	}

}
