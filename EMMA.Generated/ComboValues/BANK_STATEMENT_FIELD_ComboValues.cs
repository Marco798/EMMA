using System.Reflection;

namespace EMMA_BE.Generated {
	public class BANK_STATEMENT_FIELD_ComboValues {

		public static readonly BANK_STATEMENT_FIELD_Combo REASON = new("REAS");

		public static readonly BANK_STATEMENT_FIELD_Combo DESCRIPTION = new("DESC");

		public static readonly BANK_STATEMENT_FIELD_Combo TAG2 = new("TAG2");

		public static readonly BANK_STATEMENT_FIELD_Combo TAG3 = new("TAG3");

		public static readonly BANK_STATEMENT_FIELD_Combo TAG4 = new("TAG4");

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
                REASON.Value,
                DESCRIPTION.Value,
                TAG2.Value,
                TAG3.Value,
                TAG4.Value
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
