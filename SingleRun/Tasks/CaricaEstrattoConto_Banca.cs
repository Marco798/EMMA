using System.Data;
using System.Data.SqlClient;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;
using SingleRun;

namespace SingleRun {
	internal class CaricaEstrattoConto_Banca : Program {
		public void Run() {
			string baseDir = Path.GetFullPath(@"..\..\..\INPUT");
			logger.Info($"Directory di input: {baseDir}");

			string[] elencoFile = Directory.GetFiles(baseDir);

			if (elencoFile.Length == 0) {
				logger.Warn("Nessun file trovato");
				return;
			}

			foreach (string file in elencoFile) {
				string fileName = Path.GetFileName(file);

				logger.Info(new string('=', 100));
				logger.Info($"Elaborazione file [{fileName}]");

				if (!CheckFileName(fileName)) {
					logger.Error("Nome file non riconosciuto");
					return;
				}

				string[] contenutoFile = File.ReadAllLines(file, Encoding.ASCII);

				try {
					if (!Regex.IsMatch(contenutoFile[0], @"^Controvalori aggiornati al \d{2}/\d{2}/\d{4}$")) throw new Exception();
					if (!string.IsNullOrEmpty(contenutoFile[1])) throw new Exception();
					if (!Regex.IsMatch(contenutoFile[2], @$"^ ; ; ; ; ; ; ; ;Conto n\?: ;({possibiliValoriConti});")) throw new Exception();
					if (!contenutoFile[3].StartsWith(" ; ; ; ; ; ; ; ;Saldo: ;")) throw new Exception();
					if (contenutoFile[4] != " ; ; ; ; ; ; ; ;Intestato a:;MARCO ALLEGRI;") throw new Exception();
					if (contenutoFile[5] != "Data Operazione;Data valuta;Causale;Descrizione;Uscite;Entrate;Tag1;Tag2;Tag3;Tag4;") throw new Exception();
				}
				catch {
					logger.Error("Testata del file non valida");
					continue;
				}

				foreach (string line in contenutoFile.Skip(6)) {
					Record_BMED record = new(line);
				}

				byte[] contenutoFile_Bytes = File.ReadAllBytes(file);

				var compressedStream = new MemoryStream();
				var compressionStream = new GZipStream(compressedStream, CompressionMode.Compress);

				compressionStream.Write(contenutoFile_Bytes, 0, contenutoFile_Bytes.Length);

				compressionStream.Flush();

				byte[] compressedBytes = compressedStream.ToArray();

				DateTime dtNow = DateTime.Now;
				string query = $"INSERT INTO FL_ESTRATTO_CONTO VALUES ('{fileName}', 'B', @compressedBytes, '{dtNow:yyyy-MM-dd}', '{dtNow:HH:mm:ss}', '', '', '', '')";


				connection.Open();

				SqlTransaction transaction = connection.BeginTransaction();
				try {

					using (SqlCommand command = new(query, connection)) {
						command.Transaction = transaction;

						command.Parameters.Add("@compressedBytes", SqlDbType.VarBinary, compressedBytes.Length).Value = compressedBytes;

						command.ExecuteNonQuery();
					}

					transaction.Commit();
					connection.Close();
				}
				catch (Exception ex) {
					transaction.Rollback();
					connection.Close();
					throw new Exception($"Errore nell'esecuzione della 'Insert' della tabella: {ex}");
				}

				connection.Open();

				try {
					query = $"SELECT * FROM FL_ESTRATTO_CONTO";
					byte[] datiCompressi = [];

					using (SqlCommand command = new(query, connection)) {
						SqlDataReader reader = command.ExecuteReader();
						while (reader.Read()) {
							datiCompressi = (byte[])reader["CONTENUTO"];


						}
					}

					connection.Close();

					var compressedStreamm = new MemoryStream(datiCompressi);
					var decompressionStream = new GZipStream(compressedStreamm, CompressionMode.Decompress);
					using (var reader = new StreamReader(decompressionStream)) {
						string datiDecompressi = reader.ReadToEnd();
						logger.Info(datiDecompressi);
					}
				}
				catch (Exception e) {
					connection.Close();
					throw new Exception($"Errore nell'esecuzione della 'SelectAll' della tabella CNT_TRANSAZIONE: {e.Message}");
				}
			}
		}
		private class Record_BMED {
			DateTime DataOperazione { get; set; }
			DateTime DataValuta { get; set; }
			string Causale { get; set; }
			string Descrizione { get; set; }
			decimal? Uscite { get; set; }
			decimal? Entrate { get; set; }
			string Tag1 { get; set; }
			string Tag2 { get; set; }
			string Tag3 { get; set; }
			string Tag4 { get; set; }

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

				logger.Info($"Istituto [{sezioniNomeFile[1]}]");
				logger.Info($"Mese [{mese}]");
				logger.Info($"Anno [{anno}]");
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
