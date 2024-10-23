using EMMA.Commons;
using System.Reflection;

namespace EMMA_BE.Generated {
	public class DIRECTION_Combo : ComboBase {
		internal DIRECTION_Combo(string value) : base(value) { }

		public static readonly DIRECTION_Combo INPUT = new("I");

		public static readonly DIRECTION_Combo OUTPUT = new("O");

        public static string[] GetNames() {
            return typeof(DIRECTION_Combo).GetFields(BindingFlags.Public | BindingFlags.Static).Select(f => f.Name).ToArray();
        }

        public static List<DIRECTION_Combo> GetValues() {
            return [
                INPUT,
                OUTPUT
            ];
        }
	}

}
