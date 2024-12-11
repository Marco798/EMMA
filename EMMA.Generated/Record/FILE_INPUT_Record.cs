using System.Text.Json.Serialization;

namespace EMMA_BE.Generated {
	public class FILE_INPUT_Record {
		[JsonInclude]
		public int ID { get; set; }
		[JsonInclude]
		public string FILE_NAME { get; set; }
		[JsonInclude]
		public FILE_TYPE_Combo FILE_TYPE { get; set; }
		[JsonInclude]
		public FILE_CATEGORY_Combo FILE_CATEGORY { get; set; }
		[JsonInclude]
		public byte[] CONTENT { get; set; }
		[JsonInclude]
		public DateTime INS_DATE { get; set; }
		[JsonInclude]
		public TimeSpan INS_TIME { get; set; }
		[JsonInclude]
		public string INS_INFO { get; set; }

		public FILE_INPUT_Id GetId() { return new FILE_INPUT_Id(ID); }

		public FILE_INPUT_Record Clone() {
			FILE_INPUT_Record output = new() {
				ID = ID,
				FILE_NAME = FILE_NAME,
				FILE_TYPE = FILE_TYPE,
				FILE_CATEGORY = FILE_CATEGORY,
				CONTENT = CONTENT,
				INS_DATE = INS_DATE,
				INS_TIME = INS_TIME,
				INS_INFO = INS_INFO
			};
			return output;
		}
	}
}
