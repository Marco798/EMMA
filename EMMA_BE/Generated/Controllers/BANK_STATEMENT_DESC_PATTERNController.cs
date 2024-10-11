using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EMMA_BE.Generated.Controller {
	[ApiController]
	[Route("[controller]")]
	public class BANK_STATEMENT_DESC_PATTERNController : ControllerBase {

		protected readonly IConfiguration _configuration;
		protected readonly BANK_STATEMENT_DESC_PATTERN_Query _query;

		public BANK_STATEMENT_DESC_PATTERNController(IConfiguration configuration) {
			_configuration = configuration;
			_query = new BANK_STATEMENT_DESC_PATTERN_Query(_configuration);
		}

		[HttpGet("SelectAll")]
		public IActionResult SelectAll() {
			try {
				List<BANK_STATEMENT_DESC_PATTERN_Record> _Record_List = _query.SelectAll();
				return Ok(_Record_List);
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("UpdateByKey")]
		public IActionResult UpdateByKey(BANK_STATEMENT_DESC_PATTERN_IdRecord record) {
			try {
				_query.UpdateByKey(record.ID, new BANK_STATEMENT_DESC_PATTERN_NullRecord(record));

				return Ok();
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("Insert")]
		public IActionResult Insert(BANK_STATEMENT_DESC_PATTERN_BaseRecord record) {
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