using System.Reflection;

namespace EMMA_BE.Generated {
	public static class MONTH_ComboValues {

		public static readonly MONTH_Combo GENNAIO = new("Gennaio");
		public const string _GENNAIO = "Gennaio";

		public static readonly MONTH_Combo FEBBRAIO = new("Febbraio");
		public const string _FEBBRAIO = "Febbraio";

		public static readonly MONTH_Combo MARZO = new("Marzo");
		public const string _MARZO = "Marzo";

		public static readonly MONTH_Combo APRILE = new("Aprile");
		public const string _APRILE = "Aprile";

		public static readonly MONTH_Combo MAGGIO = new("Maggio");
		public const string _MAGGIO = "Maggio";

		public static readonly MONTH_Combo GIUGNO = new("Giugno");
		public const string _GIUGNO = "Giugno";

		public static readonly MONTH_Combo LUGLIO = new("Luglio");
		public const string _LUGLIO = "Luglio";

		public static readonly MONTH_Combo AGOSTO = new("Agosto");
		public const string _AGOSTO = "Agosto";

		public static readonly MONTH_Combo SETTEMBRE = new("Settembre");
		public const string _SETTEMBRE = "Settembre";

		public static readonly MONTH_Combo OTTOBRE = new("Ottobre");
		public const string _OTTOBRE = "Ottobre";

		public static readonly MONTH_Combo NOVEMBRE = new("Novembre");
		public const string _NOVEMBRE = "Novembre";

		public static readonly MONTH_Combo DICEMBRE = new("Dicembre");
		public const string _DICEMBRE = "Dicembre";

        public static string[] GetNames() {
            return typeof(MONTH_Combo).GetFields(BindingFlags.Public | BindingFlags.Static).Select(f => f.Name).ToArray();
        }

        public static List<MONTH_Combo> GetItems() {
            return [
                GENNAIO,
                FEBBRAIO,
                MARZO,
                APRILE,
                MAGGIO,
                GIUGNO,
                LUGLIO,
                AGOSTO,
                SETTEMBRE,
                OTTOBRE,
                NOVEMBRE,
                DICEMBRE
            ];
        }

        public static HashSet<string> GetValues() {
            return [
                _GENNAIO,
                _FEBBRAIO,
                _MARZO,
                _APRILE,
                _MAGGIO,
                _GIUGNO,
                _LUGLIO,
                _AGOSTO,
                _SETTEMBRE,
                _OTTOBRE,
                _NOVEMBRE,
                _DICEMBRE
            ];
        }

        public static string GetName(string value) {
            return value switch {
                "Gennaio" => nameof(GENNAIO),
                "Febbraio" => nameof(FEBBRAIO),
                "Marzo" => nameof(MARZO),
                "Aprile" => nameof(APRILE),
                "Maggio" => nameof(MAGGIO),
                "Giugno" => nameof(GIUGNO),
                "Luglio" => nameof(LUGLIO),
                "Agosto" => nameof(AGOSTO),
                "Settembre" => nameof(SETTEMBRE),
                "Ottobre" => nameof(OTTOBRE),
                "Novembre" => nameof(NOVEMBRE),
                "Dicembre" => nameof(DICEMBRE),
                _ => throw new Exception(),
            };
        }
	}

}
