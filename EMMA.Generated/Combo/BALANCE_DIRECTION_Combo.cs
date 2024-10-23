using EMMA.Commons;
using System.Reflection;

namespace EMMA_BE.Generated {
	public class BALANCE_DIRECTION_Combo : ComboBase {
		internal BALANCE_DIRECTION_Combo(string value) : base(value) { }

		public static readonly BALANCE_DIRECTION_Combo INCOME = new("I");

		public static readonly BALANCE_DIRECTION_Combo OUTCOME = new("O");

        public static string[] GetNames() {
            return typeof(BALANCE_DIRECTION_Combo).GetFields(BindingFlags.Public | BindingFlags.Static).Select(f => f.Name).ToArray();
        }

        public static List<BALANCE_DIRECTION_Combo> GetValues() {
            return [
                INCOME,
                OUTCOME
            ];
        }
	}

}
