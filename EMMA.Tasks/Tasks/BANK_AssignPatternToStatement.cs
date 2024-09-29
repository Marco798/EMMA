using EMMA.Commons;
using EMMA_BE.Generated;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace EMMA.Tasks {
	internal partial class BANK_AssignPatternToStatement {
		public override void Run() {
			QueryBase queryBase = new(configuration);
			BANK_STATEMENT_Query _BANK_STATEMENT_Query = new(configuration);
			BANK_STATEMENT_DESC_PATTERN_Query _BANK_STATEMENT_DESC_PATTERN_Query = new(configuration);

			string query = "SELECT ID, DESCRIPTION FROM BANK_STATEMENT WHERE ID_BANK_STATEMENT_DESC_PATTERN IS NULL";
			List<BANK_STATEMENT_CustomRecord> _BANK_STATEMENT_CustomRecord_List = queryBase.CustomSelect<BANK_STATEMENT_CustomRecord>(query);

			List<BANK_STATEMENT_DESC_PATTERN_Record> _BANK_STATEMENT_DESC_PATTERN_Record_List = _BANK_STATEMENT_DESC_PATTERN_Query.SelectAll();

			foreach (BANK_STATEMENT_CustomRecord _BANK_STATEMENT_CustomRecord in _BANK_STATEMENT_CustomRecord_List) {
				BANK_STATEMENT_NullRecord _BANK_STATEMENT_NullRecord = new();

				foreach (BANK_STATEMENT_DESC_PATTERN_Record _BANK_STATEMENT_DESC_PATTERN_Record in _BANK_STATEMENT_DESC_PATTERN_Record_List) {
					Regex regex = new(_BANK_STATEMENT_DESC_PATTERN_Record.PATTERN);

					if (regex.IsMatch(_BANK_STATEMENT_CustomRecord.DESCRIPTION)) {
						if (_BANK_STATEMENT_NullRecord.ID_BANK_STATEMENT_DESC_PATTERN != null)
							throw new Exception();
						else
							_BANK_STATEMENT_NullRecord.Set_ID_BANK_STATEMENT_DESC_PATTERN(_BANK_STATEMENT_DESC_PATTERN_Record.GetId());
					}
				}

				if (_BANK_STATEMENT_NullRecord.ID_BANK_STATEMENT_DESC_PATTERN != null) {
					_BANK_STATEMENT_Query.UpdateByKey(_BANK_STATEMENT_CustomRecord.ID, _BANK_STATEMENT_NullRecord);
				}
			}
		}

		private class BANK_STATEMENT_CustomRecord : ICustomSelect_Record {
			public int ID { get; set; }
			public string DESCRIPTION { get; set; }

			public BANK_STATEMENT_CustomRecord() {
				DESCRIPTION = string.Empty;
			}

			public ICustomSelect_Record GetRecord(SqlDataReader reader) {
				BANK_STATEMENT_CustomRecord record = new();
				int i = 0;

				record.ID = reader.GetInt32(i++);
				record.DESCRIPTION = reader.GetString(i++);

				return record;
			}
		}
	}
}
