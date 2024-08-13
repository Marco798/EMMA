namespace EMMA_BE.Generated {
	public class FLOW_INPUT_FILE_BaseRecord {
		public string NOME_FLUSSO { get; set; }
		public string TIPO_FLUSSO { get; set; }
		public byte[] CONTENUTO { get; set; }

		public FLOW_INPUT_FILE_BaseRecord() {
			NOME_FLUSSO = string.Empty;
			TIPO_FLUSSO = string.Empty;
			CONTENUTO = [];
		}

		public FLOW_INPUT_FILE_BaseRecord Clone() {
			FLOW_INPUT_FILE_BaseRecord output = new() {
				NOME_FLUSSO = NOME_FLUSSO,
				TIPO_FLUSSO = TIPO_FLUSSO,
				CONTENUTO = CONTENUTO
			};
			return output;
		}
	}
}
