using System.Reflection;

namespace EMMA_BE.Generated {
	public class BALANCE_DIRECTION_ComboValues {

		public static readonly BALANCE_DIRECTION_Combo INCOME = new("I");

		public static readonly BALANCE_DIRECTION_Combo OUTCOME = new("O");

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
                INCOME.Value,
                OUTCOME.Value
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
