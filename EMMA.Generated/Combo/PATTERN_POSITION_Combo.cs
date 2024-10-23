using EMMA.Commons;
using System.Reflection;

namespace EMMA_BE.Generated {
	public class PATTERN_POSITION_Combo : ComboBase {
		internal PATTERN_POSITION_Combo(string value) : base(value) { }

		public static readonly PATTERN_POSITION_Combo START = new("S");

		public static readonly PATTERN_POSITION_Combo END = new("E");

		public static readonly PATTERN_POSITION_Combo MIDDLE = new("M");

		public static readonly PATTERN_POSITION_Combo ALL = new("A");

        public static string[] GetNames() {
            return typeof(PATTERN_POSITION_Combo).GetFields(BindingFlags.Public | BindingFlags.Static).Select(f => f.Name).ToArray();
        }

        public static List<PATTERN_POSITION_Combo> GetValues() {
            return [
                START,
                END,
                MIDDLE,
                ALL
            ];
        }
	}

}
