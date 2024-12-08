using EMMA.Commons;
using System.Reflection;

namespace EMMA_BE.Generated {
	public class FILE_CATEGORY_Combo : ComboBase {
		internal FILE_CATEGORY_Combo(string value) : base(value) { }

		public static readonly FILE_CATEGORY_Combo BANK_STATEMENT = new("BANKSTAT");

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
                BANK_STATEMENT.Value
            ];
        }

        public static string GetNames(string value) {
            return value switch {
                "BANKSTAT" => nameof(BANK_STATEMENT),
                _ => throw new Exception(),
            };
        }
	}

}
