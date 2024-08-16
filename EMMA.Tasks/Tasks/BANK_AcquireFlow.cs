using System.Data.SqlClient;
using System.Data;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Text;
using EMMA_BE.Generated;

namespace EMMA.Tasks {
	internal class BANK_AcquireFlow : Program {
		public InputParams inputParams;

		public class InputParams {
			public string? FileName { get; set; }
		}

		public void Run() {
			if (inputParams == null) throw new Exception("InputParams not initialized");
			if(string.IsNullOrWhiteSpace(inputParams.FileName)) throw new Exception("FileName not initialized");

			string fileName = Path.GetFileName(inputParams.FileName);

			logger.Info(new string('=', 100));
			logger.Info($"Elaborating file [{fileName}]");

			if (!CheckFileName(fileName)) {
				logger.Error("Unrecognized file name");
				return;
			}

			string[] contenutoFile = File.ReadAllLines(inputParams.FileName, Encoding.ASCII);

			try {
				if (!Regex.IsMatch(contenutoFile[0], @"^Controvalori aggiornati al \d{2}/\d{2}/\d{4}$")) throw new Exception();
				if (!string.IsNullOrEmpty(contenutoFile[1])) throw new Exception();
				if (!Regex.IsMatch(contenutoFile[2], @$"^ ; ; ; ; ; ; ; ;Conto n\?: ;({possibiliValoriConti});")) throw new Exception();
				if (!contenutoFile[3].StartsWith(" ; ; ; ; ; ; ; ;Saldo: ;")) throw new Exception();
				if (contenutoFile[4] != " ; ; ; ; ; ; ; ;Intestato a:;MARCO ALLEGRI;") throw new Exception();
				if (contenutoFile[5] != "Data Operazione;Data valuta;Causale;Descrizione;Uscite;Entrate;Tag1;Tag2;Tag3;Tag4;") throw new Exception();
			}
			catch {
				logger.Error("Invalid file header");
			}

			List<Record_BMED> record_List = [];
			foreach (string line in contenutoFile.Skip(6)) {
				Record_BMED record = new(line);
				record_List.Add(record);
			}

			byte[] contenutoFile_Bytes = File.ReadAllBytes(inputParams.FileName);

			var compressedStream = new MemoryStream();
			var compressionStream = new GZipStream(compressedStream, CompressionMode.Compress);

			compressionStream.Write(contenutoFile_Bytes, 0, contenutoFile_Bytes.Length);

			compressionStream.Flush();

			byte[] compressedBytes = compressedStream.ToArray();

			FLOW_INPUT_FILE_Query _FLOW_INPUT_FILE_Query = new(configuration);
			BANK_MAIN_Query _BANK_MAIN_Query = new(configuration);

			FLOW_INPUT_FILE_BaseRecord _FLOW_INPUT_FILE_BaseRecord = new() {
				FLOW_NAME = fileName,
				FLOW_TYPE = "B",
				CONTENT = compressedBytes
			};

			long flowId = _FLOW_INPUT_FILE_Query.Insert(_FLOW_INPUT_FILE_BaseRecord);

			foreach(Record_BMED record in record_List) {
				BANK_MAIN_BaseRecord _BANK_MAIN_BaseRecord = new() {
					OPERATION_DATE = record.DataOperazione,
					VALUE_DATE = record.DataValuta,
					REASON = record.Causale,
					DESCRIPTION = record.Descrizione,
					OUTCOME = record.Uscite,
					INCOME = record.Entrate,
					TAG1 = record.Tag1,
					TAG2 = record.Tag2,
					TAG3 = record.Tag3,
					TAG4 = record.Tag4,
					FLOW_INPUT_FILE_ID = flowId
				};

				_BANK_MAIN_Query.Insert(_BANK_MAIN_BaseRecord);
			}
		}

		private class Record_BMED {
			public DateTime DataOperazione { get; set; }
			public DateTime DataValuta { get; set; }
			public string Causale { get; set; }
			public string Descrizione { get; set; }
			public decimal? Uscite { get; set; }
			public decimal? Entrate { get; set; }
			public string Tag1 { get; set; }
			public string Tag2 { get; set; }
			public string Tag3 { get; set; }
			public string Tag4 { get; set; }

			public Record_BMED(string line) {
				int i = 0;
				string[] campi = line.Split(';');

				DataOperazione = DateTime.Parse(campi[i]); i++;
				DataValuta = DateTime.Parse(campi[i]); i++;
				Causale = campi[i]; i++;
				Descrizione = campi[i]; i++;
				Uscite = string.IsNullOrEmpty(campi[i]) ? null : decimal.Parse(campi[i]); i++;
				Entrate = string.IsNullOrEmpty(campi[i]) ? null : decimal.Parse(campi[i]); i++;
				Tag1 = campi[i]; i++;
				Tag2 = campi[i]; i++;
				Tag3 = campi[i]; i++;
				Tag4 = campi[i]; i++;
			}
		}

		private bool CheckFileName(string fileName) {
			string pattern = $@"^EstrattoConto_({possibiliValoriIstituti})_({possibiliValoriMesi})20" + @"\d{2}.csv$";
			if (!Regex.IsMatch(fileName, pattern)) return false;

			try {
				string[] sezioniNomeFile = fileName.Split('_');

				if (sezioniNomeFile[0] != "EstrattoConto") return false;

				if (!istituti.Contains(sezioniNomeFile[1])) return false;

				string mese = sezioniNomeFile[2].Substring(0, sezioniNomeFile[2].Length - 8);
				if (!mesi.Contains(mese)) return false;

				int anno = int.Parse(sezioniNomeFile[2].Substring(sezioniNomeFile[2].Length - 8, 4));
				if (anno < 2017) return false;

				if (!sezioniNomeFile[2].EndsWith(".csv")) return false;

				logger.Info($"Institute [{sezioniNomeFile[1]}]");
				logger.Info($"Month [{mese}]");
				logger.Info($"Year [{anno}]");
				return true;
			}
			catch {
				return false;
			}
		}

		private static readonly string[] istituti = ["BMED"];

		private static readonly string[] mesi = ["Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre"];

		private static readonly string[] conti = ["001/01854908/05"];

		private static readonly string possibiliValoriIstituti = string.Join("|", istituti);

		private static readonly string possibiliValoriMesi = string.Join("|", mesi);

		private static readonly string possibiliValoriConti = string.Join("|", conti);
	}
}
