using EMMA.Commons;
using System.Reflection;

namespace EMMA_BE.Generated {
	public class DAY_OF_WEEK_Combo : ComboBase {
		internal DAY_OF_WEEK_Combo(string value) : base(value) { }

		public static readonly DAY_OF_WEEK_Combo LUNEDI = new("Lunedi");

		public static readonly DAY_OF_WEEK_Combo MARTEDI = new("Martedi");

		public static readonly DAY_OF_WEEK_Combo MERCOLEDI = new("Mercoledi");

		public static readonly DAY_OF_WEEK_Combo GIOVEDI = new("Giovedi");

		public static readonly DAY_OF_WEEK_Combo VENERDI = new("Venerdi");

		public static readonly DAY_OF_WEEK_Combo SABATO = new("Sabato");

		public static readonly DAY_OF_WEEK_Combo DOMENICA = new("Domenica");

        public static string[] GetNames() {
            return typeof(DAY_OF_WEEK_Combo).GetFields(BindingFlags.Public | BindingFlags.Static).Select(f => f.Name).ToArray();
        }

        public static List<DAY_OF_WEEK_Combo> GetItems() {
            return [
                LUNEDI,
                MARTEDI,
                MERCOLEDI,
                GIOVEDI,
                VENERDI,
                SABATO,
                DOMENICA
            ];
        }

        public static HashSet<string> GetValues() {
            return [
                LUNEDI.Value,
                MARTEDI.Value,
                MERCOLEDI.Value,
                GIOVEDI.Value,
                VENERDI.Value,
                SABATO.Value,
                DOMENICA.Value
            ];
        }

        public static string GetNames(string value) {
            return value switch {
                "Lunedi" => nameof(LUNEDI),
                "Martedi" => nameof(MARTEDI),
                "Mercoledi" => nameof(MERCOLEDI),
                "Giovedi" => nameof(GIOVEDI),
                "Venerdi" => nameof(VENERDI),
                "Sabato" => nameof(SABATO),
                "Domenica" => nameof(DOMENICA),
                _ => throw new Exception(),
            };
        }
	}

}
