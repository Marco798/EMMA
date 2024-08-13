namespace EMMA_BE.Generated {
	public class FLOW_INPUT_FILE_BaseRecord {
		public string NOME_FLUSSO { get; set; }
		public string TIPO_FLUSSO { get; set; }
		public byte[] CONTENUTO { get; set; }

		public FLOW_INPUT_FILE_Record Clone() {
			FLOW_INPUT_FILE_Record output = new() {
				NOME_FLUSSO = NOME_FLUSSO,
				TIPO_FLUSSO = TIPO_FLUSSO,
				CONTENUTO = CONTENUTO
			};
			return output;
		}
	}
}
