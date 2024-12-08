using EMMA.Commons;
using System.Reflection;

namespace EMMA_BE.Generated {
	public class FILE_TYPE_Combo : ComboBase {
		internal FILE_TYPE_Combo(string value) : base(value) { }

		public static readonly FILE_TYPE_Combo CSV = new("CSV");

		public static readonly FILE_TYPE_Combo TEXT = new("TEXT");

		public static readonly FILE_TYPE_Combo EXCEL = new("EXCEL");

        public static string[] GetNames() {
            return typeof(FILE_TYPE_Combo).GetFields(BindingFlags.Public | BindingFlags.Static).Select(f => f.Name).ToArray();
        }

        public static List<FILE_TYPE_Combo> GetItems() {
            return [
                CSV,
                TEXT,
                EXCEL
            ];
        }

        public static HashSet<string> GetValues() {
            return [
                CSV.Value,
                TEXT.Value,
                EXCEL.Value
            ];
        }

        public static string GetNames(string value) {
            return value switch {
                "CSV" => nameof(CSV),
                "TEXT" => nameof(TEXT),
                "EXCEL" => nameof(EXCEL),
                _ => throw new Exception(),
            };
        }
	}

}
