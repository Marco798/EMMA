using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace EMMA_BE.Generated {
	public static class DAY_OF_WEEK_ComboValues {

		public static readonly DAY_OF_WEEK_Combo LUNEDI = new("Lunedi");
		public const string _LUNEDI = "Lunedi";

		public static readonly DAY_OF_WEEK_Combo MARTEDI = new("Martedi");
		public const string _MARTEDI = "Martedi";

		public static readonly DAY_OF_WEEK_Combo MERCOLEDI = new("Mercoledi");
		public const string _MERCOLEDI = "Mercoledi";

		public static readonly DAY_OF_WEEK_Combo GIOVEDI = new("Giovedi");
		public const string _GIOVEDI = "Giovedi";

		public static readonly DAY_OF_WEEK_Combo VENERDI = new("Venerdi");
		public const string _VENERDI = "Venerdi";

		public static readonly DAY_OF_WEEK_Combo SABATO = new("Sabato");
		public const string _SABATO = "Sabato";

		public static readonly DAY_OF_WEEK_Combo DOMENICA = new("Domenica");
		public const string _DOMENICA = "Domenica";

        public static DAY_OF_WEEK_Combo GetCombo(ChangeEventArgs? changeEventArgs) {
            string value = changeEventArgs?.Value?.ToString() ?? string.Empty;
            CheckInputValue(value);
            return new(value);
        }

        private static void CheckInputValue(string value) {
            if (value != string.Empty && !GetValues().Contains(value))
                throw new Exception();
        }

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
                _LUNEDI,
                _MARTEDI,
                _MERCOLEDI,
                _GIOVEDI,
                _VENERDI,
                _SABATO,
                _DOMENICA
            ];
        }

        public static string GetName(string value) {
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
