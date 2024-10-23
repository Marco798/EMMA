using EMMA.Commons;
using System.Reflection;

namespace EMMA_BE.Generated {
	public class BANK_STATEMENT_FIELD_Combo : ComboBase {
		internal BANK_STATEMENT_FIELD_Combo(string value) : base(value) { }

		public static readonly BANK_STATEMENT_FIELD_Combo REASON = new("REAS");

		public static readonly BANK_STATEMENT_FIELD_Combo DESCRIPTION = new("DESC");

		public static readonly BANK_STATEMENT_FIELD_Combo TAG2 = new("TAG2");

		public static readonly BANK_STATEMENT_FIELD_Combo TAG3 = new("TAG3");

		public static readonly BANK_STATEMENT_FIELD_Combo TAG4 = new("TAG4");

        public static string[] GetNames() {
            return typeof(BANK_STATEMENT_FIELD_Combo).GetFields(BindingFlags.Public | BindingFlags.Static).Select(f => f.Name).ToArray();
        }

        public static List<BANK_STATEMENT_FIELD_Combo> GetValues() {
            return [
                REASON,
                DESCRIPTION,
                TAG2,
                TAG3,
                TAG4
            ];
        }
	}

}
