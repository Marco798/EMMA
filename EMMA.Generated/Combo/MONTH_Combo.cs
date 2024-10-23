using EMMA.Commons;
using System.Reflection;

namespace EMMA_BE.Generated {
	public class MONTH_Combo : ComboBase {
		internal MONTH_Combo(string value) : base(value) { }

		public static readonly MONTH_Combo GENNAIO = new("Gennaio");

		public static readonly MONTH_Combo FEBBRAIO = new("Febbraio");

		public static readonly MONTH_Combo MARZO = new("Marzo");

		public static readonly MONTH_Combo APRILE = new("Aprile");

		public static readonly MONTH_Combo MAGGIO = new("Maggio");

		public static readonly MONTH_Combo GIUGNO = new("Giugno");

		public static readonly MONTH_Combo LUGLIO = new("Luglio");

		public static readonly MONTH_Combo AGOSTO = new("Agosto");

		public static readonly MONTH_Combo SETTEMBRE = new("Settembre");

		public static readonly MONTH_Combo OTTOBRE = new("Ottobre");

		public static readonly MONTH_Combo NOVEMBRE = new("Novembre");

		public static readonly MONTH_Combo DICEMBRE = new("Dicembre");

        public static string[] GetNames() {
            return typeof(MONTH_Combo).GetFields(BindingFlags.Public | BindingFlags.Static).Select(f => f.Name).ToArray();
        }

        public static List<MONTH_Combo> GetValues() {
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
	}

}
