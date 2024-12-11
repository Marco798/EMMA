using System.Reflection;

namespace EMMA_BE.Generated {
	public class DIRECTION_ComboValues {

		public static readonly DIRECTION_Combo INPUT = new("I");

		public static readonly DIRECTION_Combo OUTPUT = new("O");

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
                INPUT.Value,
                OUTPUT.Value
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
