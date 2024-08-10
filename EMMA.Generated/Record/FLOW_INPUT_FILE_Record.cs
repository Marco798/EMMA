namespace EMMA_BE.Generated {
	public class FLOW_INPUT_FILE_Record {
		public long ID { get; set; }
		public string NOME_FLUSSO { get; set; }
		public string TIPO_FLUSSO { get; set; }
		public byte[] CONTENUTO { get; set; }
		public DateTime INS_DATE { get; set; }
		public TimeSpan INS_TIME { get; set; }
		public string INS_INFO { get; set; }
		public DateTime UPD_DATE { get; set; }
		public TimeSpan UPD_TIME { get; set; }
		public string UPD_INFO { get; set; }

		public FLOW_INPUT_FILE_Record Clone() {
			FLOW_INPUT_FILE_Record output = new() {
				ID = ID,
				NOME_FLUSSO = NOME_FLUSSO,
				TIPO_FLUSSO = TIPO_FLUSSO,
				CONTENUTO = CONTENUTO,
				INS_DATE = INS_DATE,
				INS_TIME = INS_TIME,
				INS_INFO = INS_INFO,
				UPD_DATE = UPD_DATE,
				UPD_TIME = UPD_TIME,
				UPD_INFO = UPD_INFO
			};
			return output;
		}
	}
}
