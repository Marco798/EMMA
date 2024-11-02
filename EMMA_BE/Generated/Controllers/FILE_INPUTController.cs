using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EMMA_BE.Generated.Controller {
	[ApiController]
	[Route("[controller]")]
	public class FILE_INPUTController : ControllerBase {

		protected readonly IConfiguration _configuration;
		protected readonly FILE_INPUT_Query _query;

		public FILE_INPUTController(IConfiguration configuration) {
			_configuration = configuration;
			_query = new FILE_INPUT_Query(_configuration);
		}

		[HttpGet("SelectAll")]
		public IActionResult SelectAll() {
			try {
				List<FILE_INPUT_Record> _Record_List = _query.SelectAll();
				return Ok(_Record_List);
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("SelectAll_CustomRecord")]
		public IActionResult SelectAll_CustomRecord(List<FILE_INPUT_Field>? fields = null) {
			try {
				List<FILE_INPUT_NullRecord> _Record_List = _query.SelectAll(fields);
				return Ok(_Record_List);
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("SelectWithSimpleCriteria")]
		public IActionResult SelectWithSimpleCriteria(FILE_INPUT_NullRecord nullRecord) {
			try {
				List<FILE_INPUT_Record> _Record_List = _query.SelectWithSimpleCriteria(nullRecord);
				return Ok(_Record_List);
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("SelectWithSimpleCriteria_CustomRecord")]
		public IActionResult SelectWithSimpleCriteria_CustomRecord([FromQuery] FILE_INPUT_NullRecord nullRecord, [FromQuery] List<FILE_INPUT_Field>? fields = null) {
			try {
				List<FILE_INPUT_NullRecord> _Record_List = _query.SelectWithSimpleCriteria(nullRecord, fields);
				return Ok(_Record_List);
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("UpdateByKey")]
		public IActionResult UpdateByKey(FILE_INPUT_IdRecord record) {
			try {
				_query.UpdateByKey(record.ID, new FILE_INPUT_NullRecord(record));

				return Ok();
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("Insert")]
		public IActionResult Insert(FILE_INPUT_BaseRecord record) {
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
