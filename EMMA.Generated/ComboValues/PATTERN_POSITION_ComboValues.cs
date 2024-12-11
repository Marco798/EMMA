using System.Reflection;

namespace EMMA_BE.Generated {
	public class PATTERN_POSITION_ComboValues {

		public static readonly PATTERN_POSITION_Combo START = new("S");

		public static readonly PATTERN_POSITION_Combo END = new("E");

		public static readonly PATTERN_POSITION_Combo MIDDLE = new("M");

		public static readonly PATTERN_POSITION_Combo ALL = new("A");

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
                START.Value,
                END.Value,
                MIDDLE.Value,
                ALL.Value
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
