using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EMMA_BE.Generated.Controller {
	[ApiController]
	[Route("[controller]")]
	public class SYST_COLUMNController : ControllerBase {

		protected readonly IConfiguration _configuration;
		protected readonly SYST_COLUMN_Query _query;

		public SYST_COLUMNController(IConfiguration configuration) {
			_configuration = configuration;
			_query = new SYST_COLUMN_Query(_configuration);
		}

		[HttpGet("SelectAll")]
		public IActionResult SelectAll() {
			try {
				List<SYST_COLUMN_Record> _Record_List = _query.SelectAll();
				return Ok(_Record_List);
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("SelectAll_CustomRecord")]
		public IActionResult SelectAll_CustomRecord(List<SYST_COLUMN_Field>? fields = null) {
			try {
				List<SYST_COLUMN_NullRecord> _Record_List = _query.SelectAll(fields);
				return Ok(_Record_List);
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("SelectWithSimpleCriteria")]
		public IActionResult SelectWithSimpleCriteria(SYST_COLUMN_NullRecord nullRecord) {
			try {
				List<SYST_COLUMN_Record> _Record_List = _query.SelectWithSimpleCriteria(nullRecord);
				return Ok(_Record_List);
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("SelectWithSimpleCriteria_CustomRecord")]
		public IActionResult SelectWithSimpleCriteria_CustomRecord([FromQuery] SYST_COLUMN_NullRecord nullRecord, [FromQuery] List<SYST_COLUMN_Field>? fields = null) {
			try {
				List<SYST_COLUMN_NullRecord> _Record_List = _query.SelectWithSimpleCriteria(nullRecord, fields);
				return Ok(_Record_List);
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("UpdateByKey")]
		public IActionResult UpdateByKey(SYST_COLUMN_IdRecord record) {
			try {
				_query.UpdateByKey(record.ID, new SYST_COLUMN_NullRecord(record));

				return Ok();
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("Insert")]
		public IActionResult Insert(SYST_COLUMN_BaseRecord record) {
			try {
				_query.Insert(record);

				return Ok();
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}
	}
}
