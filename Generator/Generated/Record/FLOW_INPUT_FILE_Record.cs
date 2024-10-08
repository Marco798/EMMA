namespace Generator {
	internal class FLOW_INPUT_FILE_Record {
		public Long ID { get; set; }
		public string NOME_FLUSSO { get; set; }
		public string TIPO_FLUSSO { get; set; }
		public string CONTENUTO { get; set; }
		public DateTime DATA_INS { get; set; }
		public TimeSpan ORA_INS { get; set; }
		public string INFO_INS { get; set; }
		public DateTime DATA_AGG { get; set; }
		public TimeSpan ORA_AGG { get; set; }
		public string INFO_AGG { get; set; }
	}
}
