using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Text;
using EMMA_BE.Generated;

namespace EMMA.Tasks {
	internal partial class BANK_AcquireFlow {

		public override void Run() {
			#region InputParams check
			if (string.IsNullOrWhiteSpace(inputParams.FileName)) throw new Exception("FileName not initialized");
			#endregion

			#region input file recover and check
			string fileName = Path.GetFileName(inputParams.FileName);

			logger.Info(new string('=', 100));
			logger.Info($"Elaborating file [{fileName}]");

			if (!CheckFileName(fileName)) {
				logger.Error("Unrecognized file name");
				return;
			}

			string[] fileContent = File.ReadAllLines(inputParams.FileName, Encoding.ASCII);
			#endregion

			#region Header area check
			try {
				if (!Regex.IsMatch(fileContent[0], @"^Controvalori aggiornati al \d{2}/\d{2}/\d{4}$")) throw new Exception();
				if (!string.IsNullOrEmpty(fileContent[1])) throw new Exception();
				if (!Regex.IsMatch(fileContent[2], @$"^ ; ; ; ; ; ; ; ;Conto n\?: ;({acceptedValues_Account});")) throw new Exception();
				if (!fileContent[3].StartsWith(" ; ; ; ; ; ; ; ;Saldo: ;")) throw new Exception();
				if (fileContent[4] != " ; ; ; ; ; ; ; ;Intestato a:;MARCO ALLEGRI;") throw new Exception();
				if (fileContent[5] != "Data Operazione;Data valuta;Causale;Descrizione;Uscite;Entrate;Tag1;Tag2;Tag3;Tag4;") throw new Exception();
			}
			catch {
				logger.Error("Invalid file header");
			}
			#endregion

			#region From csv to BMED_Record class convertion
			List<BMED_Record> _BMED_record_List = [];
			foreach (string line in fileContent.Skip(6)) {
				BMED_Record _BMED_record = new(line);
				_BMED_record_List.Add(_BMED_record);
			}

			#region Check data intregrity
			if (_BMED_record_List.Select(x => x.OperationDate.Month).Distinct().Count() != 1)
				throw new Exception("Incogruent data. There are differente months in the same report");
			if (_BMED_record_List.Select(x => x.OperationDate.Year).Distinct().Count() != 1)
				throw new Exception("Incogruent data. There are differente years in the same report");

			int intMonth = _BMED_record_List.Select(x => x.OperationDate.Month).Distinct().First();
			int intYear = _BMED_record_List.Select(x => x.OperationDate.Year).Distinct().First();
			string fileName_DateSection = fileName.Split('_')[2];
			string fileNameMonth = fileName_DateSection[..^8];
			switch (intMonth) {
				case 1: if (fileNameMonth != "Gennaio") throw new Exception(); break;
				case 2: if (fileNameMonth != "Febbraio") throw new Exception(); break;
				case 3: if (fileNameMonth != "Marzo") throw new Exception(); break;
				case 4: if (fileNameMonth != "Aprile") throw new Exception(); break;
				case 5: if (fileNameMonth != "Maggio") throw new Exception(); break;
				case 6: if (fileNameMonth != "Giugno") throw new Exception(); break;
				case 7: if (fileNameMonth != "Luglio") throw new Exception(); break;
				case 8: if (fileNameMonth != "Agosto") throw new Exception(); break;
				case 9: if (fileNameMonth != "Settembre") throw new Exception(); break;
				case 10: if (fileNameMonth != "Ottobre") throw new Exception(); break;
				case 11: if (fileNameMonth != "Novembre") throw new Exception(); break;
				case 12: if (fileNameMonth != "Dicembre") throw new Exception(); break;
			}

			int fileNameYear = int.Parse(fileName_DateSection.Substring(fileName_DateSection.Length - 8, 4));
			if (fileNameYear != intYear) throw new Exception();
			#endregion

			//The CSV start with the most recent operations so revert the list order
			_BMED_record_List.Reverse();
			#endregion

			#region Re-read file as byte array for db data saving
			byte[] fileContent_Bytes = File.ReadAllBytes(inputParams.FileName);

			MemoryStream compressedStream = new();
			GZipStream compressionStream = new(compressedStream, CompressionMode.Compress);

			compressionStream.Write(fileContent_Bytes, 0, fileContent_Bytes.Length);

			compressionStream.Flush();

			byte[] compressedBytes = compressedStream.ToArray();
			#endregion

			#region Insert FILE_INPUT
			FILE_INPUT_Query _FILE_INPUT_Query = new(configuration);

			FILE_INPUT_BaseRecord _FILE_INPUT_BaseRecord = new() {
				FILE_NAME = fileName,
				CONTENT = compressedBytes
			};
			_FILE_INPUT_BaseRecord.Set_FILE_TYPE(FILE_TYPE_ComboValues.CSV);
			_FILE_INPUT_BaseRecord.Set_FILE_CATEGORY(FILE_CATEGORY_ComboValues.BANK_STATEMENT);

			FILE_INPUT_Id _ID_FILE_INPUT = _FILE_INPUT_Query.Insert(_FILE_INPUT_BaseRecord);
			#endregion

			#region Insert all BANK_STATEMENT records
			BANK_STATEMENT_Query _BANK_MAIN_Query = new(configuration);

			foreach (BMED_Record record in _BMED_record_List) {
				BANK_STATEMENT_BaseRecord _BANK_MAIN_BaseRecord = new() {
					OPERATION_DATE = record.OperationDate,
					VALUE_DATE = record.ValueDate,
					REASON = record.Reason,
					DESCRIPTION = record.Description,
					OUTCOME = record.Outcome,
					INCOME = record.Income,
					TAG2 = record.Tag2,
					TAG3 = record.Tag3,
					TAG4 = record.Tag4
				};
				_BANK_MAIN_BaseRecord.Set_TAG1(Get_BALANCE_DIRECTION(record.Tag1));
				_BANK_MAIN_BaseRecord.Set_ID_FILE_INPUT(_ID_FILE_INPUT);

				_BANK_MAIN_Query.Insert(_BANK_MAIN_BaseRecord);
			}
			#endregion
		}

		private static BALANCE_DIRECTION_Combo Get_BALANCE_DIRECTION(string tag1) {
			return tag1 switch {
				"Entrata" => BALANCE_DIRECTION_ComboValues.INCOME,
				"Uscita" => BALANCE_DIRECTION_ComboValues.OUTCOME,
				_ => throw new Exception(),
			};
		}

		private static bool CheckFileName(string fileName) {
			string pattern = $@"^EstrattoConto_({acceptedValues_Institute})_({acceptedValues_Month})20" + @"\d{2}.csv$";
			if (!Regex.IsMatch(fileName, pattern)) return false;

			try {
				string[] fileName_Split = fileName.Split('_');

				if (fileName_Split[0] != "EstrattoConto") return false;

				if (!institutes.Contains(fileName_Split[1])) return false;

				string month = fileName_Split[2][..^8];
				if (!months.Contains(month)) return false;

				int year = int.Parse(fileName_Split[2].Substring(fileName_Split[2].Length - 8, 4));
				if (year < 2017) return false;

				if (!fileName_Split[2].EndsWith(".csv")) return false;

				logger.Info($"Institute [{fileName_Split[1]}]");
				logger.Info($"Month [{month}]");
				logger.Info($"Year [{year}]");
				return true;
			}
			catch {
				return false;
			}
		}

		private static readonly string[] institutes = ["BMED"];

		private static readonly string[] months = ["Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre"];

		private static readonly string[] accounts = ["001/01854908/05"];

		private static readonly string acceptedValues_Institute = string.Join("|", institutes);

		private static readonly string acceptedValues_Month = string.Join("|", months);

		private static readonly string acceptedValues_Account = string.Join("|", accounts);

		private class BMED_Record {
			public DateTime OperationDate { get; set; }
			public DateTime ValueDate { get; set; }
			public string Reason { get; set; }
			public string Description { get; set; }
			public decimal? Outcome { get; set; }
			public decimal? Income { get; set; }
			public string Tag1 { get; set; }
			public string Tag2 { get; set; }
			public string Tag3 { get; set; }
			public string Tag4 { get; set; }

			public BMED_Record(string line) {
				int i = 0;
				string[] fields = line.Split(';');

				OperationDate = DateTime.Parse(fields[i++]);
				ValueDate = DateTime.Parse(fields[i++]);
				Reason = fields[i++];
				Description = fields[i++];
				Outcome = string.IsNullOrEmpty(fields[i]) ? null : decimal.Parse(fields[i], cultureInfo_en_US); i++;
				Income = string.IsNullOrEmpty(fields[i]) ? null : decimal.Parse(fields[i], cultureInfo_en_US); i++;
				Tag1 = fields[i++];
				Tag2 = fields[i++];
				Tag3 = fields[i++];
				Tag4 = fields[i++];
			}
		}
	}
}
